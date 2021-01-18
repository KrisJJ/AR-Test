<<<<<<< HEAD
﻿using NUnit.Framework;

namespace UnityEditor.PackageManager.UI.Tests
{
    internal class PackageBaseTests
    {
        protected MockOperationFactory Factory;
        protected const string kPackageTestName = "com.unity.test";


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Factory = new MockOperationFactory();
            OperationFactory.Instance = Factory;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            OperationFactory.Reset();
        }
    }
=======
﻿using NUnit.Framework;

namespace UnityEditor.PackageManager.UI.Tests
{
    internal class PackageBaseTests
    {
        protected MockOperationFactory Factory;
        protected const string kPackageTestName = "com.unity.test";


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Factory = new MockOperationFactory();
            OperationFactory.Instance = Factory;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            OperationFactory.Reset();
        }
    }
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
}