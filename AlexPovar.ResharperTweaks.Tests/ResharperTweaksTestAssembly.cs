﻿using AlexPovar.ResharperTweaks.Tests;
using JetBrains.TestFramework;
using NUnit.Framework;

#pragma warning disable 618

[assembly: TestDataPathBase(@".\data")]
#pragma warning restore 618

// ReSharper disable once CheckNamespace
[SetUpFixture]
public class ResharperTweaksTestAssembly : ExtensionTestEnvironmentAssembly<ResharperTweaksTestEnvironmentZone>
{
}