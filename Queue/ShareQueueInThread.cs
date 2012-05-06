// 
// ShareQueueInThread.cs
//  
// Author:
//       Leezhm <leezhm@126.com>
//             
// Copyright (c) 2012 leezhm@126.com
// 
// Created:
//       Leezhm <12-4-25 下2:20>
// 
// Modified:
//       Leezhm <12-4-25 下2:20>
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
		private static Thread task1 = new Thread(task1Proc);
		private static Thread task2 = new Thread(task2Proc);
		
		private static Queue<int[]> testQueue = new Queue<int[]>();
		
		public static void RunShareQueueInThread ()
		{
			if (ThreadState.Unstarted == task1.ThreadState &&
			    !task1.IsAlive) {
				task1.Start ();
			}
			
		    if (ThreadState.Unstarted == task1.ThreadState &&
			    !task1.IsAlive) {
				task1.Start ();
			}
		}
		
		private static void task1Proc ()
		{
			int [] newDatas = new int[100];
			
			foreach (int item in newDatas) {
				//item = 12;
			}
		}
		
		private static void task2Proc()
		{
			
		}
	}
}

