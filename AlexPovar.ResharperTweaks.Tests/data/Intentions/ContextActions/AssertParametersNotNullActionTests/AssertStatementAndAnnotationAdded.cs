﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexPovar.ResharperTweaks.Tests.data.Intentions.ContextActions.AssertParametersNotNullActionTests
{
  class AssertStatementIsAdded
  {
    void SampleMethod(object ar{caret:Assert:parameter:is:not:null}g1)
    {
    }
  }
}