// 
// FinalizeExample.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
//       leezhm <2012/5/23> 
// 
// Modified:
//       leezhm <2012/5/23> 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

namespace CSnippets.GC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Runtime.InteropServices;

    public abstract class Base : IDisposable
    {
        private bool disposed = false;
        private List<object> trackingList = null;

        public Base(string name, List<object> tracking)
        {
            this.InstanceName = name;
            trackingList = tracking;
            trackingList.Add(this);
        }

        public string InstanceName
        {
            get;
            private set;
        }

        public void Dispose()
        {
            Console.WriteLine("\n[{0}].Base.Dispose()", InstanceName);

            //
            Dispose(true);

            //
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free 
                    Console.WriteLine("\n[{0}].Base.Dispose(true)", InstanceName);
                    trackingList.Remove(this);
                    Console.WriteLine("[{0}] Removed from tracking list: {1:x16}", InstanceName, this.GetHashCode());
                }
                else
                {
                    Console.WriteLine("\n[{0}].Base.Dispose(false)", InstanceName);
                }

                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~Base()
        {
            // Simply call Dispose(false).
            Console.WriteLine("\n[{0}].Base.Finalize()", InstanceName);
            Dispose(false);
        }
    }

    public class Derived : Base
    {
        private bool disposed = false;

        private IntPtr umResource = IntPtr.Zero;

        public Derived(string name, List<object> tracking)
            : base(name, tracking)
        {
            // Save the instance name as an unmanaged resource
            umResource = Marshal.StringToCoTaskMemAuto(InstanceName);
        }

        new protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("\n[{0}].Base.Dispose(true)", InstanceName);
                }
                else
                {
                    Console.WriteLine("\n[{0}].Base.Dispose(false)", InstanceName);
                }

                // Release unmanaged resource
                if (IntPtr.Zero == umResource)
                {
                    Marshal.FreeCoTaskMem(umResource);
                    Console.WriteLine("[{0}] Unmanaged memory freed at {1:x16}",InstanceName, umResource.ToInt64());
                    umResource = IntPtr.Zero;
                }

                disposed = true;
            }

            //
            base.Dispose(disposing);
        }

        // The derived class does not have a Finalize method
        // or a Dispose method without parameters because it inherits
        // them from the base class.
    }


    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class FinalizeExample
    {
        public static void TestFinalizeExample()
        {
            List<object> tracking = new List<object>();

            // Dispose is not called, Finalize will be called later.
            using (null)
            {
                Console.WriteLine("\nDisposal Scenario: #1\n");
                Derived d3 = new Derived("d1", tracking);
            }

            // Dispose is implicitly called in the scope of the using statement.
            using (Derived d1 = new Derived("d2", tracking))
            {
                Console.WriteLine("\nDisposal Scenario: #2\n");
            }

            // Dispose is explicitly called.
            using (null)
            {
                Console.WriteLine("\nDisposal Scenario: #3\n");
                Derived d2 = new Derived("d3", tracking);
                d2.Dispose();
            }

            // Again, Dispose is not called, Finalize will be called later.
            using (null)
            {
                Console.WriteLine("\nDisposal Scenario: #4\n");
                Derived d4 = new Derived("d4", tracking);
            }

            // List the objects remaining to dispose.
            Console.WriteLine("\nObjects remaining to dispose = {0:d}", tracking.Count);
            foreach (Derived dd in tracking)
            {
                Console.WriteLine("    Reference Object: {0:s}, {1:x16}",
                    dd.InstanceName, dd.GetHashCode());
            }

            // Queued finalizers will be exeucted when Main() goes out of scope.
            Console.WriteLine("\nDequeueing finalizers...");
        }
    }
}
