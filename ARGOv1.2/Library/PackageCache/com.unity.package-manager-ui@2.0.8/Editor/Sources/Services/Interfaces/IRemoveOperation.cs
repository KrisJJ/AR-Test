<<<<<<< HEAD
﻿using System;

namespace UnityEditor.PackageManager.UI
{
    internal interface IRemoveOperation : IBaseOperation
    {
        event Action<PackageInfo> OnOperationSuccess;

        void RemovePackageAsync(PackageInfo package, Action<PackageInfo> doneCallbackAction = null,  Action<Error> errorCallbackAction = null);
    }
}
=======
﻿using System;

namespace UnityEditor.PackageManager.UI
{
    internal interface IRemoveOperation : IBaseOperation
    {
        event Action<PackageInfo> OnOperationSuccess;

        void RemovePackageAsync(PackageInfo package, Action<PackageInfo> doneCallbackAction = null,  Action<Error> errorCallbackAction = null);
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
