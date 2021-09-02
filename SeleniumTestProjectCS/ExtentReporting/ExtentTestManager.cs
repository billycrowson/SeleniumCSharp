using AventStack.ExtentReports;
using System;
using System.Runtime.CompilerServices;

namespace SeleniumTestProjectCS.ExtentReporting
{
    public class ExtentTestManager
    {

        [ThreadStatic]
        private static ExtentTest _test;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string testName, string description = null)
        {
            _test = ExtentManager.Instance.CreateTest(testName, description);
            return _test;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        {
            return _test;
        }

        //This is if we want to have parent tests with child test nodes under them in the report ie. multiple tests per class
        //[ThreadStatic]
        //private static ExtentTest _parentTest;

        //[ThreadStatic]
        //private static ExtentTest _childTest;

        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public static ExtentTest CreateParentTest(string testName, string description = null)
        //{
        //    _parentTest = ExtentManager.Instance.CreateTest(testName, description);
        //    return _parentTest;
        //}

        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public static ExtentTest CreateTest(string testName, string description = null)
        //{
        //    _childTest = _parentTest.CreateNode(testName, description);
        //    return _childTest;
        //}

        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public static ExtentTest GetTest()
        //{
        //    return _childTest;
        //}
    }
}
