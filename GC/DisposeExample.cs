// 
// DisposeExample.cs
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

    using System.IO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DisposeExample
    {
        public static void TestDispose()
        {
            try
            {
                string path = Environment.CurrentDirectory + "\\App.config";

                FileStream fs = File.OpenRead(path);

                DisposableResource dr = new DisposableResource(fs);
                
                //
                dr.DoSomethingWithResource();

                //
                dr.Dispose();
            }
            catch (FileNotFoundException expt)
            {
                Console.WriteLine(expt.Message);
            }
        }
    }

    public class DisposableResource : IDisposable
    {
        private Stream resource = null;
        private bool disposed = false;

        public DisposableResource(Stream stream)
        {
            if (null == stream)
            {
                throw new ArgumentNullException("stream is null ...");
            }

            if (!stream.CanRead)
            {
                throw new ArgumentException("stream must be readable ...");
            }

            resource = stream;
            disposed = false;
        }

        public void DoSomethingWithResource()
        {
            if (disposed)
            {
                throw new ObjectDisposedException("resource was disposed ...");
            }

            int num = (int)resource.Length;
            Console.WriteLine("Number of bytes: {0}", num.ToString());
        }

        public void Dispose()
        {
            Dispose(true);

            //  Using SuppressFinalize in case a subclass
            //  of this type implements a finalizer.
            System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these 
            // operations, as well as in your methods that use the resource.
            if (!disposed)
            {
                if (disposing)
                {
                    // Release unmanage resource

                    if (null != resource)
                    {
                        resource.Dispose();
                        Console.WriteLine("Object disposed ...");
                    }
                }

                // Release manage resource

                // Indicate that the instance has been disposed.
                resource = null;
                disposed = true;
            }
        }
    }
}
