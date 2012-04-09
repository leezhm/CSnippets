// 
// ArrayClass.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
// 	2012/4/9
// 
// Modified:
// 	leezhm <2012/4/9> 
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

using System.Threading.Tasks;

namespace ArrayClass
{
	class ArrayClass
	{
		private static void PrintArray(string [] arr)
		{
			for(int i = 0; i < arr.Length; ++ i)
			{
				Console.Write(arr[i] + "{0}", i < arr.Length - 1 ? " -> " : "\n");
			}
		}
		
		private static void ChangeArray(string [] arr)
		{
			// Reserve array
			Array.Reverse(arr);
			
			Console.Write("Print Array in ChangeArray, after reversing current Array ... ");
			PrintArray(arr);
		}
		
		private static void ChangeArrayElements(string [] arr)
		{
			// Change array element
			arr[0] = "Sun";
			arr[1] = "Mon";
			arr[2] = "Tues";
			
			Console.Write("Print Array in ChangeArrayElement ... ");
			PrintArray(arr);
		}
		
		public static void RunArrayClass()
		{
			// Declare and initialize an array
			string [] weekDays = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday",
							      "Friday", "Saturday"};
			
			
			// Print the array as an argument to PrintArray
			PrintArray(weekDays);
			
			// ChangeArray tries to change the array by assigning something new
	        // to the array in the method.
			ChangeArray(weekDays);
			
			// Print array again after invoking function ChangeArray
			PrintArray(weekDays);
			
			// ChangeArrayElements assigns new values to individual array elements.
			ChangeArrayElements(weekDays);
			
			// Print array again after invoking function ChangeArrayElement
			PrintArray(weekDays);
		}
	}
}