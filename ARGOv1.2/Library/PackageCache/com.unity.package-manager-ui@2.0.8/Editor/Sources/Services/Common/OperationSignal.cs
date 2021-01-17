<<<<<<< HEAD
﻿using System;

namespace UnityEditor.PackageManager.UI
{
    [Serializable]
    internal class OperationSignal<T> where T: IBaseOperation
    {
        public event Action<T> OnOperation = delegate { };

        public T Operation { get; set; }

        public void SetOperation(T operation)
        {
            Operation = operation;
            OnOperation(operation);
        }

        public void WhenOperation(Action<T> callback)
        {
            if (Operation != null)
                callback(Operation);
            OnOperation += callback;
        }

        internal void ResetEvents()
        {
            OnOperation = delegate { };
        }
    }
=======
﻿using System;

namespace UnityEditor.PackageManager.UI
{
    [Serializable]
    internal class OperationSignal<T> where T: IBaseOperation
    {
        public event Action<T> OnOperation = delegate { };

        public T Operation { get; set; }

        public void SetOperation(T operation)
        {
            Operation = operation;
            OnOperation(operation);
        }

        public void WhenOperation(Action<T> callback)
        {
            if (Operation != null)
                callback(Operation);
            OnOperation += callback;
        }

        internal void ResetEvents()
        {
            OnOperation = delegate { };
        }
    }
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
}