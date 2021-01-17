<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

namespace UnityEditor.PackageManager.UI.Tests
{
    internal class MockListOperation : MockOperation, IListOperation
    {
        public new event Action<Error> OnOperationError = delegate { };
        public new event Action OnOperationFinalized = delegate { };

        public bool OfflineMode { get; set; }

        public MockListOperation(MockOperationFactory factory) : base(factory)
        {
        }

        public void GetPackageListAsync(Action<IEnumerable<PackageInfo>> doneCallbackAction,
            Action<Error> errorCallbackAction = null)
        {
            if (ForceError != null)
            {
                if (errorCallbackAction != null)
                    errorCallbackAction(ForceError);

                IsCompleted = true;
                OnOperationError(ForceError);
            }
            else
            {
                if (doneCallbackAction != null)
                    doneCallbackAction(Factory.Packages);

                IsCompleted = true;
            }

            OnOperationFinalized();
        }
    }
=======
﻿using System;
using System.Collections.Generic;

namespace UnityEditor.PackageManager.UI.Tests
{
    internal class MockListOperation : MockOperation, IListOperation
    {
        public new event Action<Error> OnOperationError = delegate { };
        public new event Action OnOperationFinalized = delegate { };

        public bool OfflineMode { get; set; }

        public MockListOperation(MockOperationFactory factory) : base(factory)
        {
        }

        public void GetPackageListAsync(Action<IEnumerable<PackageInfo>> doneCallbackAction,
            Action<Error> errorCallbackAction = null)
        {
            if (ForceError != null)
            {
                if (errorCallbackAction != null)
                    errorCallbackAction(ForceError);

                IsCompleted = true;
                OnOperationError(ForceError);
            }
            else
            {
                if (doneCallbackAction != null)
                    doneCallbackAction(Factory.Packages);

                IsCompleted = true;
            }

            OnOperationFinalized();
        }
    }
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
}