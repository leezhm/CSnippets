﻿// 
// Program.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
// 		 2012/4/9
// 
// Modified:
// 	     leezhm <2012/4/9> 
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

namespace Program
{
	public class Program
	{
		public static void Main()
		{
			#region Array
			// ArrayClass
			ArrayClass.ArrayClass.RunArrayClass();
			
			// ArrayQueue
			ArrayQueue.ArrayQueue aq = new ArrayQueue.ArrayQueue();
			aq.RunArrayQueue();
			#endregion // Array
		
			#region Threads
			SimpleThreadPool.SimpleThreadPool.RunSimpleThreadPool();
			#endregion // Threads
		}
	}
}