<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

namespace UnityEditor.PackageManager.UI
{
    internal interface ISearchOperation : IBaseOperation
    {
        void GetAllPackageAsync(Action<IEnumerable<PackageInfo>> doneCallbackAction = null, Action<Error> errorCallbackAction = null);
    }
}
=======
﻿using System;
using System.Collections.Generic;

namespace UnityEditor.PackageManager.UI
{
    internal interface ISearchOperation : IBaseOperation
    {
        void GetAllPackageAsync(Action<IEnumerable<PackageInfo>> doneCallbackAction = null, Action<Error> errorCallbackAction = null);
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
