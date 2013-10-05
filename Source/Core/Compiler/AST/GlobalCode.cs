/*

 Copyright (c) 2007- DEVSENSE
 Copyright (c) 2004-2006 Tomas Matousek and Vaclav Novak.

 The use and distribution terms for this software are contained in the file named License.txt, 
 which can be found in the root of the Phalanger distribution. By using this software 
 in any fashion, you are agreeing to be bound by the terms of this license.
 
 You must not remove this notice from this software.

*/

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;

using PHP.Core;
using PHP.Core.Parsers;
using PHP.Core.Emit;
using PHP.Core.Reflection;

namespace PHP.Core.AST
{
    #region GlobalCode

    /// <summary>
    /// Represents a container for global statements.
    /// </summary>
    /// <remarks>
    /// PHP source file can contain global code definition which is represented in AST 
    /// by GlobalCode node. Finally, it is emitted into Main() method of concrete PHPPage 
    /// class. The sample code below illustrates a part of PHP global code
    /// </remarks>
    [Serializable]
    public sealed class GlobalCode : AstNode
    {
        /// <summary>
        /// Array of nodes representing statements in PHP global code
        /// </summary>
        public List<Statement>/*!*/ Statements { get { return statements; } }
        private readonly List<Statement>/*!*/ statements;

        /// <summary>
        /// Represented source unit.
        /// </summary>
        public SourceUnit/*!*/ SourceUnit { get { return sourceUnit; } }
        private readonly SourceUnit/*!*/ sourceUnit;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the GlobalCode class.
        /// </summary>
        public GlobalCode(List<Statement>/*!*/ statements, SourceUnit/*!*/ sourceUnit)
        {
            Debug.Assert(statements != null && sourceUnit != null);

            this.sourceUnit = sourceUnit;
            this.statements = statements;
        }

        #endregion

        /// <summary>
        /// Call the right Visit* method on the given Visitor object.
        /// </summary>
        /// <param name="visitor">Visitor to be called.</param>
        public void VisitMe(TreeVisitor visitor)
        {
            visitor.VisitGlobalCode(this);
        }

        /// <summary>
        /// <see cref="PHPDocBlock"/> instance or <c>null</c> reference.
        /// </summary>
        public PHPDocBlock PHPDoc
        {
            get { return this.GetPHPDoc(); }
            set { this.SetPHPDoc(value); }
        }
    }

    #endregion

    #region NamespaceDecl

    [Serializable]
    public sealed class NamespaceDecl : Statement
    {
        internal override bool IsDeclaration { get { return true; } }

        /// <summary>
        /// Whether the namespace was declared using PHP simple syntax.
        /// </summary>
        public readonly bool IsSimpleSyntax;

        public QualifiedName QualifiedName { get { return qualifiedName; } }
        private QualifiedName qualifiedName;

        /// <summary>
        /// Dictionary of PHP aliases.
        /// </summary>
        public Dictionary<string, QualifiedName>/*!*/ Aliases { get { return aliases; } }
        private readonly Dictionary<string, QualifiedName>/*!*/ aliases = new Dictionary<string, QualifiedName>(StringComparer.OrdinalIgnoreCase);

        public bool IsAnonymous { get { return isAnonymous; } }
        private readonly bool isAnonymous;

        public List<Statement>/*!*/ Statements
        {
            get { return statements; }
            internal /* friend Parser */ set { statements = value; }
        }
        private List<Statement>/*!*/ statements;

        #region Construction

        public NamespaceDecl(Position p)
            : base(p)
        {
            this.isAnonymous = true;
            this.qualifiedName = new QualifiedName(Core.Name.EmptyBaseName, Core.Name.EmptyNames);
            this.IsSimpleSyntax = false;
        }

        public NamespaceDecl(Position p, List<string>/*!*/ names, bool simpleSyntax)
            : base(p)
        {
            this.isAnonymous = false;
            this.qualifiedName = new QualifiedName(names, false, true);
            this.IsSimpleSyntax = simpleSyntax;
        }

        /// <summary>
        /// Finish parsing of namespace, complete its position.
        /// </summary>
        /// <param name="p"></param>
        public void UpdatePosition(Position p)
        {
            this.Position = p;
        }

        #endregion

        /// <summary>
        /// Call the right Visit* method on the given Visitor object.
        /// </summary>
        /// <param name="visitor">Visitor to be called.</param>
        public override void VisitMe(TreeVisitor visitor)
        {
            visitor.VisitNamespaceDecl(this);
        }

        /// <summary>
        /// <see cref="PHPDocBlock"/> instance or <c>null</c> reference.
        /// </summary>
        public PHPDocBlock PHPDoc
        {
            get { return this.GetPHPDoc(); }
            set { this.SetPHPDoc(value); }
        }
    }

    #endregion

    #region GlobalConstDeclList, GlobalConstantDecl

    [Serializable]
    public sealed class GlobalConstDeclList : Statement
    {
        /// <summary>
        /// Gets collection of CLR attributes annotating this statement.
        /// </summary>
        public CustomAttributes Attributes
        {
            get { return this.GetCustomAttributes(); }
            set { this.SetCustomAttributes(value); }
        }

        public List<GlobalConstantDecl>/*!*/ Constants { get { return constants; } }
        private readonly List<GlobalConstantDecl>/*!*/ constants;
        
        public GlobalConstDeclList(Position position, List<GlobalConstantDecl>/*!*/ constants, List<CustomAttribute> attributes)
            : base(position)
        {
            Debug.Assert(constants != null);

            this.constants = constants;
            if (attributes != null && attributes.Count != 0)
                this.Attributes = new CustomAttributes(attributes);
        }

        /// <summary>
        /// Call the right Visit* method on the given Visitor object.
        /// </summary>
        /// <param name="visitor">Visitor to be called.</param>
        public override void VisitMe(TreeVisitor visitor)
        {
            visitor.VisitGlobalConstDeclList(this);
        }

        /// <summary>
        /// <see cref="PHPDocBlock"/> instance or <c>null</c> reference.
        /// </summary>
        public PHPDocBlock PHPDoc
        {
            get { return this.GetPHPDoc(); }
            set { this.SetPHPDoc(value); }
        }
    }

    [Serializable]
    public sealed class GlobalConstantDecl : ConstantDecl
    {
        /// <summary>
        /// Namespace.
        /// </summary>
        public NamespaceDecl Namespace { get { return ns; } }
        private NamespaceDecl ns;

        /// <summary>
        /// Gets value indicating whether this global constant is declared conditionally.
        /// </summary>
        public bool IsConditional { get; private set; }

        /// <summary>
        /// Scope.
        /// </summary>
        internal Scope Scope { get; private set; }

        /// <summary>
        /// Source unit.
        /// </summary>
        internal SourceUnit SourceUnit { get; private set; }

        public GlobalConstantDecl(SourceUnit/*!*/ sourceUnit, Position position, bool isConditional, Scope scope,
            string/*!*/ name, NamespaceDecl ns, Expression/*!*/ initializer)
            : base(position, name, initializer)
        {
            this.ns = ns;
            this.IsConditional = IsConditional;
            this.Scope = scope;
            this.SourceUnit = sourceUnit;
        }

        /// <summary>
        /// Call the right Visit* method on the given Visitor object.
        /// </summary>
        /// <param name="visitor">Visitor to be called.</param>
        public override void VisitMe(TreeVisitor visitor)
        {
            visitor.VisitGlobalConstantDecl(this);
        }
    }

    #endregion

}
