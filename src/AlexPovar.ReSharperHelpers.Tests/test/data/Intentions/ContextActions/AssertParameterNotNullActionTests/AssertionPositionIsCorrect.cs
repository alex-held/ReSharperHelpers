﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace AlexPovar.ReSharperHelpers.Tests.data.Intentions.ContextActions.AssertParametersNotNullActionTests
{
  class AssertionPositionIsCorrect
  {
    void Method([NotNull] object arg1, object ar{caret:Assert:parameter:is:not:null}g2, [NotNull] object arg3)
    {
      Assert.ArgumentNotNull(arg1, nameof(arg1));
      Assert.ArgumentNotNull(arg3, nameof(arg3));
    }
  }

  public static class Assert
  {
    public static void ArgumentNotNull<T>(T value, string argName);
    public static void ArgumentNotOrEmptyNull<T>(T value, string argName);
  }
}
