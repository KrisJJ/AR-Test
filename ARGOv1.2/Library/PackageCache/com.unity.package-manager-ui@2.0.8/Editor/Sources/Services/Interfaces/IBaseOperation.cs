<<<<<<< HEAD
﻿using System;

namespace UnityEditor.PackageManager.UI
{
    internal interface IBaseOperation
    {
        event Action<Error> OnOperationError;
        event Action OnOperationFinalized;

        bool IsCompleted { get; }
                
        void Cancel();
    }
}
=======
﻿using System;

namespace UnityEditor.PackageManager.UI
{
    internal interface IBaseOperation
    {
        event Action<Error> OnOperationError;
        event Action OnOperationFinalized;

        bool IsCompleted { get; }
                
        void Cancel();
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
