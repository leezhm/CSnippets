// 
// AutoResetEvent.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
//       leezhm <2012/4/13>
// 
// Modified:
//       leezhm <2012/4/13> 
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

using System;
using System.Threading;

namespace AutoResetEventDemo
{
	public class AutoResetEventDemo
	{
		private static AutoResetEvent event1 = new AutoResetEvent(true);
		private static AutoResetEvent event2 = new AutoResetEvent(false);
		
		public AutoResetEventDemo()
		{
		}
		
		public static void RunAutoResetEventDemo()
		{
			Console.WriteLine("Press Enter to create three threads and start them.\r\n" +
						      "The threads wait on AutoResetEvent #1, which was created\r\n" +
						      "in the signaled state, so the first thread is released.\r\n" +
						      "This puts AutoResetEvent #1 into the unsignaled state.");
			Console.ReadLine();
			
			for(int i = 0; i < 4; ++ i)
			{
				Thread t = new Thread(ThreadProc);
				t.Name = "Thread__" + i;
				t.Start();
			}
			
			// Let the main thread sleep
			Thread.Sleep(250);
			
			for(int i = 0; i < 3; ++ i)
			{
				Console.WriteLine("Press Enter to release another thread (event1)... ");
				Console.ReadLine();
				
				// release
				event1.Set();
				Thread.Sleep(250);
			}
			
			Console.WriteLine("\r\nAll threads are now waiting on AutoResetEvent #2 .... ");
			for(int i = 0; i < 4; ++ i)
			{
				Console.WriteLine("Press Enter to release another thread (event2)... ");
				Console.ReadLine();
				
				// release
				event2.Set();
				Thread.Sleep(250);
			}
			
			Console.WriteLine("\nOk, now all thread are end and press enter to exits ... ");
			Console.ReadLine();
		}
		
		private static void ThreadProc()
		{
			string name = Thread.CurrentThread.Name;
			
			Console.WriteLine("{0} waits on AutoResetEvent #1 ... ", name);
			event1.WaitOne();
			Console.WriteLine("{0} is released on AutoResetEvent #1 ... ", name);
			
			Console.WriteLine("{0} waits on AutoResetEvent #2 ... ", name);
			event2.WaitOne();
			Console.WriteLine("{0} is released on AutoResetEvent #2 ... ", name);
			
			Console.WriteLine("{0} ends ... ", name);
		}
	}
}

