// 
// ArrayQueue.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
//       2012/4/9
// 
// Modified:
//       leezhm <2012/4/9> 
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

using System.Collections.Generic;

namespace ArrayQueue
{
    public class ArrayQueue
	{
		private Queue<string[]> arrayQueue = new Queue<string[]>();
		
		// Declare an array
		private string[] btWeighing = new string[10];
		
		public ArrayQueue ()
		{
		}
		
		public void RunArrayQueue()
		{
			// init
			ArrayQueueWithoutDeepCopy();
			
			// print
			PrintQueue();
			
			// init
			ArrayQueueWithDeepCopy();
			
			// print
			PrintQueue();
		}
		
		private void ArrayQueueWithoutDeepCopy()
		{
			string str = "";
			arrayQueue.Clear();
			
			for(int index = 0; index < 10; ++ index)
			{
				for(int i = 0; i < btWeighing.Length; ++ i)
				{
					str = index.ToString();
					str += i.ToString();
					
					btWeighing[i] = str;
					
					str = "";
				}
				
				// Invoke function Array4Enqueue
				arrayQueue.Enqueue(btWeighing);
			}			
		}
		
		private void ArrayQueueWithDeepCopy()
		{
			string str = "";
			arrayQueue.Clear();
			
			for(int index = 0; index < 10; ++ index)
			{
				for(int i = 0; i < btWeighing.Length; ++ i)
				{
					str = index.ToString();
					str += i.ToString();
					
					btWeighing[i] = str;
					
					str = "";
				}
				
				//
				// More information, Please access the bellow page
			    // http://msdn.microsoft.com/zh-cn/library/system.array.clone(v=vs.100).aspx
				//
				// A shallow copy of an Array copies only the elements of the Array, whether 
				// they are reference types or value types, but it does not copy the objects 
				// that the references refer to. The references in the new Array point to the 
				// same objects that the references in the original Array point to.
				//
                // In contrast, a deep copy of an Array copies the elements and everything 
				// directly or indirectly referenced by the elements.
				//
                // The clone is of the same Type as the original Array.
				//
                // This method is an O(n) operation, where n is Length.
				//
				// So according to the upper describle, If the object in array is value type,
				// the array will copy all the elements when we invoke the function 'Clone'.
				// It really had do a deep copy.
				//
				string [] btClone = (String [])btWeighing.Clone();
				
				// Invoke function Array4Enqueue
				arrayQueue.Enqueue(btClone);
			}			
		}
		
		/// <summary>
		/// Array4s the enqueue.
		/// </summary>
		private void PrintQueue()
		{
			Console.WriteLine("Print current Queue ... ");
			
			foreach(var item in arrayQueue)
			{
				foreach(string str in item)
				{
					Console.Write(str + " ");
				}
				
				Console.Write("\n");
			}
			
			Console.WriteLine("End of current Queue ... ");
		}
	}
}

