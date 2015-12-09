﻿/*
The MIT License (MIT)

Copyright (c) 2015 Objectivity Bespoke Software Specialists

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace Objectivity.Test.Automation.Tests.NUnit
{
    using global::NUnit.Framework;

    using Objectivity.Test.Automation.NUnit;

    /// <summary>
    /// The base class for all tests
    /// </summary>
    public class ProjectTestBase : TestBase
    {
        /// <summary>
        /// Before the class.
        /// </summary>
        [TestFixtureSetUp]
        public void BeforeClass()
        {
            StartPerformanceMeasure();
        }

        /// <summary>
        /// After the class.
        /// </summary>
        [TestFixtureTearDown]
        public void AfterClass()
        {
            StopPerfromanceMeasure();
        }

        /// <summary>
        /// Before the test.
        /// </summary>
        [SetUp]
        public void BeforeTest()
        {
            this.DriverContext.TestTitle = TestContext.CurrentContext.Test.Name;
            this.LogTest.LogTestStarting();
            this.DriverContext.Start();
        }

        /// <summary>
        /// After the test.
        /// </summary>
        [TearDown]
        public void AfterTest()
        {
            this.DriverContext.IsTestFailed = TestContext.CurrentContext.Result.Status == TestStatus.Failed;
            this.SaveTestDetailsIfTestFailed();
            this.DriverContext.Stop();
            this.FailTestIfVerifyFailed();
            this.LogTest.LogTestEnding();
            this.LogTest = null;
        }
    }
}