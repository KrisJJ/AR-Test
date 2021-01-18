<<<<<<< HEAD
﻿using System;

namespace UnityEditor.PackageManager.UI
{
    internal interface IAddOperation : IBaseOperation
    {
        event Action<PackageInfo> OnOperationSuccess;
        
        PackageInfo PackageInfo { get; }

        void AddPackageAsync(PackageInfo packageInfo, Action<PackageInfo> doneCallbackAction = null,  Action<Error> errorCallbackAction = null);
    }
}
=======
﻿using System;

namespace UnityEditor.PackageManager.UI
{
    internal interface IAddOperation : IBaseOperation
    {
        event Action<PackageInfo> OnOperationSuccess;
        
        PackageInfo PackageInfo { get; }

        void AddPackageAsync(PackageInfo packageInfo, Action<PackageInfo> doneCallbackAction = null,  Action<Error> errorCallbackAction = null);
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
