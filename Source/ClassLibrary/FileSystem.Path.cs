/*

 Copyright (c) 2004-2006 Jan Benda and Tomas Matousek.  

 The use and distribution terms for this software are contained in the file named License.txt, 
 which can be found in the root of the Phalanger distribution. By using this software 
 in any fashion, you are agreeing to be bound by the terms of this license.
 
 You must not remove this notice from this software.

	TODO:
		-	Fixed tempnam() 2nd parameter to be checked against path components. (PHP 5.1.3) 
*/

using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Threading;
using System.ComponentModel;

using PHP.Core;
using System.Collections.Generic;
using System.Text.RegularExpressions;

#if SILVERLIGHT
using DirectoryEx = PHP.CoreCLR.DirectoryEx;
#else
using DirectoryEx = System.IO.Directory;
using System.Diagnostics;
#endif

namespace PHP.Library
{
	/// <summary>
	/// Provides path strings manipulation.
	/// </summary>
	/// <threadsafety static="true"/>
	public static class PhpPath
	{
		#region Scheme, Url, Absolute Path

		/// <summary>
		/// Wrapper-safe method of getting the schema portion from an URL.
		/// </summary>
		/// <param name="path">A <see cref="string"/> containing an URL or a local filesystem path.</param>
		/// <returns>
		/// The schema portion of the given <paramref name="path"/> or <c>"file"</c>
		/// for a local filesystem path.
		/// </returns>
		/// <exception cref="ArgumentException">Invalid path.</exception>
		internal static string GetScheme(string/*!*/ path)
		{
			int colon_index = path.IndexOf(':');

			// When there is not scheme present (or it's a local path) return "file".
			if (colon_index == -1 || Path.IsPathRooted(path))
				return "file";

			// Otherwise assume that it's the string before first ':'.
			return path.Substring(0, colon_index);
		}

		/// <summary>
		/// Concatenates a scheme with the given absolute path if necessary.
		/// </summary>
		/// <param name="absolutePath">Absolute path.</param>
		/// <returns>The given url or absolute path preceded by a <c>file://</c>.</returns>
		/// <exception cref="ArgumentException">Invalid path.</exception>
		internal static string GetUrl(string/*!*/ absolutePath)
		{
			// Assert that the path is absolute
            Debug.Assert(
                !string.IsNullOrEmpty(absolutePath) &&
                (absolutePath.IndexOf(':') > 0 ||   // there is a protocol (http://) or path is rooted (c:\)
                    (Path.VolumeSeparatorChar != ':' && // or on linux, if there is no protocol, file path is rooted
                        (absolutePath[0] == Path.DirectorySeparatorChar || absolutePath[0] == Path.AltDirectorySeparatorChar)))                      
                );

			if (Path.IsPathRooted(absolutePath))
				return String.Concat("file://", absolutePath);

			// Otherwise assume that it's the string before first ':'.
			return absolutePath;
		}

		/// <summary>
		/// Returns the given filesystem url without the scheme.
		/// </summary>
		/// <param name="path">A path or url of a local filesystem file.</param>
		/// <returns>The filesystem path or <b>null</b> if the <paramref name="path"/> is not a local file.</returns>
		/// <exception cref="ArgumentException">Invalid path.</exception>
		internal static string GetFilename(string/*!*/ path)
		{
			if (path.IndexOf(':') == -1 || Path.IsPathRooted(path)) return path;
			if (path.IndexOf("file://") == 0) return path.Substring("file://".Length);
			return null;
		}

		/// <summary>
		/// Check if the given path is a path to a local file.
		/// </summary>
		/// <param name="url">The path to test.</param>
		/// <returns><c>true</c> if it's not a fully qualified name of a remote resource.</returns>
		/// <exception cref="ArgumentException">Invalid path.</exception>
		internal static bool IsLocalFile(string/*!*/ url)
		{
			return GetScheme(url) == "file";
		}

		/// <summary>
		/// Check if the given path is a remote url.
		/// </summary>
		/// <param name="url">The path to test.</param>
		/// <returns><c>true</c> if it's a fully qualified name of a remote resource.</returns>
		/// <exception cref="ArgumentException">Invalid path.</exception>
		internal static bool IsRemoteFile(string/*!*/ url)
		{
			return GetScheme(url) != "file";
		}

		/// <summary>
		/// Merges the path with the current working directory
		/// to get a canonicalized absolute pathname representing the same path
		/// (local files only). If the provided <paramref name="path"/>
		/// is absolute (rooted local path or an URL) it is returned unchanged.
		/// </summary>
		/// <param name="path">An absolute or relative path to a directory or an URL.</param>
		/// <returns>Canonicalized absolute path in case of a local directory or the original 
		/// <paramref name="path"/> in case of an URL.</returns>
		internal static string AbsolutePath(string path)
		{
			// Don't combine remote file paths with CWD.
			try
			{
				if (IsRemoteFile(path))
					return path;

				// Remove the file:// schema if any.
				path = GetFilename(path);

				// Combine the path and simplify it.
				string combinedPath = Path.Combine(PhpDirectory.GetWorking(), path);

				// Note: GetFullPath handles "C:" incorrectly
				if (combinedPath[combinedPath.Length - 1] == ':') combinedPath += '\\';
				return Path.GetFullPath(combinedPath);
			}
			catch (Exception)
			{
				PhpException.Throw(PhpError.Notice,
				  LibResources.GetString("invalid_path", FileSystemUtils.StripPassword(path)));
				return null;
			}
		}

		#endregion

		#region basename, dirname, pathinfo

		/// <summary>
		/// Returns path component of path.
		/// </summary>
		/// <param name="path">A <see cref="string"/> containing a path to a file.</param>
		/// <returns>The path conponent of the given <paramref name="path"/>.</returns>
		/// <exception cref="ArgumentException">Invalid path.</exception>
		[ImplementsFunction("basename")]
		[PureFunction]
        public static string GetBase(string path)
		{
			return GetBase(path, null);
		}

		/// <summary>
		/// Returns path component of path.
		/// </summary>
		/// <remarks>
		/// Given a <see cref="string"/> containing a path to a file, this function will return the base name of the file. 
		/// If the path ends in this will also be cut off. 
		/// On Windows, both slash (/) and backslash (\) are used as path separator character. 
		/// In other environments, it is the forward slash (/). 
		/// </remarks>
		/// <param name="path">A <see cref="string"/> containing a path to a file.</param>
		/// <param name="suffix">A <see cref="string"/> containing suffix to be cut off the path if present.</param>
		/// <returns>The path conponent of the given <paramref name="path"/>.</returns>
        [ImplementsFunction("basename")]
        [PureFunction]
        public static string GetBase(string path, string suffix)
        {
            if (String.IsNullOrEmpty(path)) return string.Empty;

            int end = path.Length - 1;
            while (end >= 0 && IsDirectorySeparator(path[end])) end--;

            int start = end;
            while (start >= 0 && !IsDirectorySeparator(path[start])) start--;
            start++;

            int name_length = end - start + 1;
            if (!string.IsNullOrEmpty(suffix) &&
                suffix.Length < name_length &&
                String.Compare(path, end - suffix.Length + 1, suffix, 0, suffix.Length, StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                name_length -= suffix.Length;
            }

            return path.Substring(start, name_length);
        }

		private static bool IsDirectorySeparator(char c)
		{
			return c == Path.DirectorySeparatorChar || c == Path.AltDirectorySeparatorChar;
		}

		/// <summary>
		/// Returns directory name component of path.
		/// </summary>
		/// <param name="path">The full path.</param>
		/// <returns>The directory portion of the given path.</returns>
		[ImplementsFunction("dirname")]
        [PureFunction]
        public static string GetDirectory(string path)
		{
			if (String.IsNullOrEmpty(path)) return null;

			int start = 0;
			int end = path.Length - 1;

			// advance start position beyond drive specifier:
			if (path.Length >= 2 && path[1] == ':' && (path[0] >= 'a' && path[0] <= 'z' || path[0] >= 'A' && path[0] <= 'Z'))
			{
				start = 2;
				if (path.Length == 2)
					return path;
			}

			// strip slashes from the end:
			while (end >= start && IsDirectorySeparator(path[end])) end--;
			if (end < start)
				return path.Substring(0, end + 1) + Path.DirectorySeparatorChar;

			// strip file name:
			while (end >= start && !IsDirectorySeparator(path[end])) end--;
			if (end < start)
				return path.Substring(0, end + 1) + '.';

			// strip slashes from the end:
			while (end >= start && IsDirectorySeparator(path[end])) end--;
			if (end < start)
				return path.Substring(0, end + 1) + Path.DirectorySeparatorChar;

			return path.Substring(0, end + 1);
		}

		/// <summary>
		/// Extracts parts from a specified path.
		/// </summary>
		/// <param name="path">The path to be parsed.</param>
		/// <returns>Array keyed by <c>"dirname"</c>, <c>"basename"</c>, and <c>"extension"</c>.
		/// </returns>
		[ImplementsFunction("pathinfo")]
        public static object GetInfo(string path)
		{
			return GetInfo(path, PathInfoOptions.All);
		}

		/// <summary>
		/// Extracts part(s) from a specified path.
		/// </summary>
		/// <param name="path">The path to be parsed.</param>
		/// <param name="options">Flags determining the result.</param>
		/// <returns>
		/// If <paramref name="options"/> is <see cref="PathInfoOptions.All"/> then returns array
		/// keyed by <c>"dirname"</c>, <c>"basename"</c>, and <c>"extension"</c>. Otherwise,
		/// it returns string value containing a single part of the path.
		/// </returns>
		[ImplementsFunction("pathinfo")]
        public static object GetInfo(string path, PathInfoOptions options)
		{
            // collect strings
			string dirname = null, basename = null, extension = null, filename = null;

			if ((options & PathInfoOptions.BaseName) != 0 ||
                (options & PathInfoOptions.Extension) != 0 ||
                (options & PathInfoOptions.FileName) != 0 )
				basename = GetBase(path);

			if ((options & PathInfoOptions.DirName) != 0)
				dirname = GetDirectory(path);

			if ((options & PathInfoOptions.Extension) != 0)
			{
				int last_dot = basename.LastIndexOf('.');
				if (last_dot >= 0)
					extension = basename.Substring(last_dot + 1);
			}

            if ((options & PathInfoOptions.FileName) != 0)
            {
                int last_dot = basename.LastIndexOf('.');
                if (last_dot >= 0)
                    filename = basename.Substring(0, last_dot);
                else
                    filename = basename;
            }

            // return requested value or all of them in an associative array
			if (options == PathInfoOptions.All)
			{
				PhpArray result = new PhpArray(0, 4);
				result.Add("dirname", dirname);
				result.Add("basename", basename);
				result.Add("extension", extension);
                result.Add("filename", filename);
				return result;
			}

			if ((options & PathInfoOptions.DirName) != 0)
				return dirname;

			if ((options & PathInfoOptions.BaseName) != 0)
				return basename;

			if ((options & PathInfoOptions.Extension) != 0)
				return extension;

            if ((options & PathInfoOptions.FileName) != 0)
                return filename;

			return null;
		}

		#endregion

        #region tempnam, realpath, sys_get_temp_dir

        /// <summary>
		/// Creates a file with a unique path in the specified directory. 
		/// If the directory does not exist, <c>tempnam()</c> may generate 
		/// a file in the system's temporary directory, and return the name of that.
		/// </summary>
		/// <param name="dir">The directory where the temporary file should be created.</param>
		/// <param name="prefix">The prefix of the unique path.</param>
		/// <returns>A unique path for a temporary file 
		/// in the given <paramref name="dir"/>.</returns>
		[ImplementsFunction("tempnam")]
		public static string GetTemporaryFilename(string dir, string prefix)
		{
			// makes "dir" a valid directory:
			if (string.IsNullOrEmpty(dir) || !System.IO.Directory.Exists(dir))
				dir = Path.GetTempPath();

			// makes "prefix" a valid file prefix:
			if (prefix == null || prefix.Length == 0 || prefix.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
				prefix = "tmp_";

			string path = Path.Combine(dir, prefix);
			string result;

			for (; ; )
			{
				result = String.Concat(path, Interlocked.Increment(ref tempCounter), ".tmp");
				if (!File.Exists(result))
				{
					try
					{
						File.Open(result, FileMode.CreateNew).Close();
						break;
					}
					catch (UnauthorizedAccessException)
					{
						// try system temp directory:
						dir = Path.GetTempPath();
						path = Path.Combine(dir, prefix);
					}
					catch (PathTooLongException e)
					{
						PhpException.Throw(PhpError.Notice, PhpException.ToErrorMessage(e.Message));
						return Path.GetTempFileName();
					}
					catch (Exception)
					{
					}
				}
			}

			return result;
		}

        /// <summary>
        /// Returns the path of the directory PHP stores temporary files in by default.
        /// </summary>
        /// <returns>Returns the path of the temporary directory.</returns>
        /// <remarks>Path ends with "\"</remarks>
        [ImplementsFunction("sys_get_temp_dir")]
        public static string GetTempDirectoryName()
        {
            return Path.GetTempPath();
        }

		/// <summary>
		/// A counter used to generate unique filenames for <see cref="GetTemporaryFilename"/>.
		/// </summary>
		private static int tempCounter = 0;

		/// <summary>
		/// Returns canonicalized absolute path name.
		/// </summary>
		/// <param name="path">Arbitrary path.</param>
		/// <returns>
		/// The given <paramref name="path"/> combined with the current working directory or
		/// <B>null</B> (<B>false</B> in PHP) if the path is invalid or doesn't exists.
		/// </returns>
		[ImplementsFunction("realpath")]
		[return: CastToFalse]
		public static string RealPath(string path)
		{
			if (String.IsNullOrEmpty(path)) return null;

			// string ending slash
			if (IsDirectorySeparator(path[path.Length - 1]))
				path = path.Substring(0, path.Length - 1);

			string realpath = PhpPath.AbsolutePath(path);
			if (!File.Exists(realpath) && !System.IO.Directory.Exists(realpath))
			{
				return null;
			}

			return realpath;
		}

		#endregion
	}
}
