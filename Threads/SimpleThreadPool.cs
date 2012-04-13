// 
// SimpleThreadPool.cs
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

namespace SimpleThreadPool
{
	public class TaskInfo
	{
		private string sBoilerplate;
		private int iValue;
		
		public string Boilerplate
		{
			get
			{
				return this.sBoilerplate;
			}
			
			set
			{
				this.sBoilerplate = value;
			}
		}
		
		public int Value
		{
			get 
			{
				return this.iValue;
			}
			
			set
			{
				this.iValue = value;
			}
		}
		
		public TaskInfo(string text, int number)
		{
			this.Boilerplate = text;
			this.Value = number;
		}
	}
	
	public class SimpleThreadPool
	{
		public static int currentThreadNo = 1;
		
		public SimpleThreadPool ()
		{
		}
		
		public static void RunSimpleThreadPool()
		{
			// Queue the tasks
			ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));
			
			// Create an object containing the information needed for this task
			TaskInfo info = new TaskInfo("This report display the number {0} ... ", 433);
			
			ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProcWithParameter), info);
			
			Console.WriteLine("Main thread does some work, then sleep ... ");
			
			// If you comment out the Sleep, the main thread exits before
			// the thread pool task runs.  The thread pool uses background
			// threads, which do not keep the application running.  (This
			// is a simple example of a race condition.)
			Thread.Sleep(1000);
			
			Console.WriteLine("Main thread exits ... ");
		}
		
		private static void ThreadProc(Object stateInfo)
		{
			Console.WriteLine("Hello from the thread pool ... ");
			
			System.Threading.Tasks.Parallel.For(0, 1000, index =>
			{
				Console.Write(index + ((index < 1000) ? " " : "\n"));
			});
		}
		
		private static void ThreadProcWithParameter(Object stateInfo)
		{
			try
			{
				TaskInfo ti = (TaskInfo)stateInfo;
				
				Console.WriteLine(ti.Boilerplate, ti.Value);
			}
			catch(ThreadAbortException expt)
			{
				Console.Write(expt.ToString());
			}
		}
	}
}

