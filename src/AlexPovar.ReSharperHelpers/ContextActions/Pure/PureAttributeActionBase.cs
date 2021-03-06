﻿using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.ContextActions;
using JetBrains.ReSharper.Feature.Services.Intentions;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CodeAnnotations;
using JetBrains.ReSharper.Psi.CSharp.Impl;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.Util;

namespace AlexPovar.ReSharperHelpers.ContextActions.Pure
{
  public abstract class PureAttributeActionBase : ContextActionBase
  {
    [NotNull] protected readonly ICSharpContextActionDataProvider Provider;

    protected PureAttributeActionBase([NotNull] ICSharpContextActionDataProvider provider)
    {
      this.Provider = provider ?? throw new ArgumentNullException(nameof(provider));
    }

    [NotNull]
    protected string PureAttributeShortName => PureAnnotationProvider.PureAttributeShortName;

    public override IEnumerable<IntentionAction> CreateBulbItems() => this.ToAnnotateActionIntentions();

    [CanBeNull]
    protected IAttribute FindPureAttribute([NotNull] IMethodDeclaration methodDeclaration)
    {
      var pureProvider = methodDeclaration.GetPsiServices().GetCodeAnnotationsCache().GetProvider<PureAnnotationProvider>();

      return methodDeclaration
        .AttributesEnumerable
        .FirstOrDefault(attr => pureProvider.IsPureAttribute(attr.GetAttributeInstance().GetClrName()));
    }

    public override bool IsAvailable(IUserDataHolder cache)
    {
      var methodName = this.Provider.GetSelectedElement<ICSharpIdentifier>();
      var methodDeclaration = MethodDeclarationNavigator.GetByNameIdentifier(methodName);

      var declaredMethod = methodDeclaration?.DeclaredElement;
      if (declaredMethod == null) return false;

      var isAlreadyDeclared = this.FindPureAttribute(methodDeclaration) != null;

      return this.ResolveIsAvailable(isAlreadyDeclared, declaredMethod);
    }

    protected abstract bool ResolveIsAvailable(bool isAlreadyDeclared, [NotNull] IMethod method);
  }
}