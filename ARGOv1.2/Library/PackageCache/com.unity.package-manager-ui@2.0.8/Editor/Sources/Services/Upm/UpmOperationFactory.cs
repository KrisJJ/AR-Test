<<<<<<< HEAD
﻿namespace UnityEditor.PackageManager.UI
{
    internal class UpmOperationFactory : IOperationFactory
    {
        public IListOperation CreateListOperation(bool offlineMode = false)
        {
            return new UpmListOperation(offlineMode);
        }

        public ISearchOperation CreateSearchOperation()
        {
            return new UpmSearchOperation();
        }

        public IAddOperation CreateAddOperation()
        {
            return new UpmAddOperation();
        }

        public IRemoveOperation CreateRemoveOperation()
        {
            return new UpmRemoveOperation();
        }
    }
}
=======
﻿namespace UnityEditor.PackageManager.UI
{
    internal class UpmOperationFactory : IOperationFactory
    {
        public IListOperation CreateListOperation(bool offlineMode = false)
        {
            return new UpmListOperation(offlineMode);
        }

        public ISearchOperation CreateSearchOperation()
        {
            return new UpmSearchOperation();
        }

        public IAddOperation CreateAddOperation()
        {
            return new UpmAddOperation();
        }

        public IRemoveOperation CreateRemoveOperation()
        {
            return new UpmRemoveOperation();
        }
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
