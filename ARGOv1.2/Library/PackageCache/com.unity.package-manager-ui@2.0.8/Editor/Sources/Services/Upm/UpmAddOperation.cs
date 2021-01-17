<<<<<<< HEAD
﻿using System;
using UnityEditor.PackageManager.Requests;
using System.Linq;

namespace UnityEditor.PackageManager.UI
{
    internal class UpmAddOperation : UpmBaseOperation, IAddOperation
    {
        public PackageInfo PackageInfo { get; protected set; }

        public event Action<PackageInfo> OnOperationSuccess = delegate { };

        public void AddPackageAsync(PackageInfo packageInfo, Action<PackageInfo> doneCallbackAction = null, Action<Error> errorCallbackAction = null)
        {
            PackageInfo = packageInfo;
            OnOperationError += errorCallbackAction;
            OnOperationSuccess += doneCallbackAction;

            Start();
        }

        protected override Request CreateRequest()
        {
            return Client.Add(PackageInfo.PackageId);
        }

        protected override void ProcessData()
        {
            var request = CurrentRequest as AddRequest;
            var package = FromUpmPackageInfo(request.Result).First();
            OnOperationSuccess(package);
        }
    }
}
=======
﻿using System;
using UnityEditor.PackageManager.Requests;
using System.Linq;

namespace UnityEditor.PackageManager.UI
{
    internal class UpmAddOperation : UpmBaseOperation, IAddOperation
    {
        public PackageInfo PackageInfo { get; protected set; }

        public event Action<PackageInfo> OnOperationSuccess = delegate { };

        public void AddPackageAsync(PackageInfo packageInfo, Action<PackageInfo> doneCallbackAction = null, Action<Error> errorCallbackAction = null)
        {
            PackageInfo = packageInfo;
            OnOperationError += errorCallbackAction;
            OnOperationSuccess += doneCallbackAction;

            Start();
        }

        protected override Request CreateRequest()
        {
            return Client.Add(PackageInfo.PackageId);
        }

        protected override void ProcessData()
        {
            var request = CurrentRequest as AddRequest;
            var package = FromUpmPackageInfo(request.Result).First();
            OnOperationSuccess(package);
        }
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
