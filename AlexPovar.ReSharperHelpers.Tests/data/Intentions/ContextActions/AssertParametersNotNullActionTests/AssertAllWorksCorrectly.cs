﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexPovar.ReSharperHelpers.Tests.data.Intentions.ContextActions.AssertParametersNotNullActionTests
{
  class AssertAllWorksCorrectly
  {
    void TestMethod(object ar{caret:Assert:all:parameters:are:not:null}g1, int arg2, string arg3)
    {
    }
  }

  public static class Assert
  {
    public static void ArgumentNotNull<T>(T value, string argName);
    public static void ArgumentNotOrEmptyNull<T>(T value, string argName);
  }
}