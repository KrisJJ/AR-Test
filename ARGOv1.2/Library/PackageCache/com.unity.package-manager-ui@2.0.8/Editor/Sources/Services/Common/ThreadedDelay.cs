<<<<<<< HEAD
﻿using System.Threading;

namespace UnityEditor.PackageManager.UI
{
    internal class ThreadedDelay
    {
        public int Length { get; set; }            // In milliseconds
        public bool IsDone { get; private set; }

        public ThreadedDelay(int length = 0)
        {
            Length = length;
            IsDone = false;
        }

        public void Start()
        {
            if (Length <= 0)
            {
                IsDone = true;
                return;
            }

            IsDone = false;
            
            Thread newThread = new Thread(() =>
            {
                Thread.Sleep(Length);
                IsDone = true;
            });
            
            newThread.Start();
        }
    }
}
=======
﻿using System.Threading;

namespace UnityEditor.PackageManager.UI
{
    internal class ThreadedDelay
    {
        public int Length { get; set; }            // In milliseconds
        public bool IsDone { get; private set; }

        public ThreadedDelay(int length = 0)
        {
            Length = length;
            IsDone = false;
        }

        public void Start()
        {
            if (Length <= 0)
            {
                IsDone = true;
                return;
            }

            IsDone = false;
            
            Thread newThread = new Thread(() =>
            {
                Thread.Sleep(Length);
                IsDone = true;
            });
            
            newThread.Start();
        }
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
