// 
// ShareQueueInThread.cs
//  
// Author:
//       Leezhm <leezhm@126.com>
//             
// Copyright (c) 2012 leezhm@126.com
// 
// Created:
//       leezhm <2012/4/26>
// 
// Modified:
//       leezhm <2012/4/26> 
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
using System.Collections.Generic;

namespace ShareQueueInThread
{
	public class ShareQueueInThread
	{
		/// <summary>
		/// The task1.
		/// </summary>
		private static Thread task1 = new Thread(Task1ThreadProc);
		private static Thread task2 = new Thread(Task2ThreadProc);
		
		/// <summary>
		/// The share queue.
		/// </summary>
		private static Queue<int[]> shareQueue = new Queue<int[]>();
		
		private static readonly object syncLock = new object();
		
		public static void RunShareQueueInThread()
		{
			if(ThreadState.Unstarted == task1.ThreadState &&
			   !task1.IsAlive)
			{
				task1.Start();
			}
			
			if(ThreadState.Unstarted == task2.ThreadState &&
			   !task2.IsAlive)
			{
				task2.Start();
			}
		}
		
		private static void Task1ThreadProc()
		{
			try
			{
				int localIndex = 0;
				
				while(true)
				{
					Thread.Sleep(1);
					
					int[] tmp = new int[50];
					
					// Init 
					for(int i = 0; i < tmp.Length; ++ i)
					{
						tmp[i] = localIndex + i;
					}
					
					lock(syncLock)
					{
						shareQueue.Enqueue(tmp);
					}
					++ localIndex;
				}
			}
			catch(System.Exception expt)
			{
				Console.WriteLine(expt.ToString());
			}
		}
		
		private static void Task2ThreadProc()
		{
			try
			{
				while(true)
				{
					Thread.Sleep(5);
					lock(syncLock)
					{
						foreach(var item in shareQueue)
						{
							for(int i = 0; i < item.Length; ++ i)
							{
								Console.Write(item[i] + (i < (item.Length - 1) ? " " : "\n" ));
							}
							
							shareQueue.Dequeue();
						}
					}
				}
			}
			catch(Exception expt)
			{
				Console.WriteLine(expt.ToString());
			}
		}
	}
}

