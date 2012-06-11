// 
// Program.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
// 		 leezhm <2012/4/9> 
// 
// Modified:
// 	     leezhm <2012/5/30> 
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

namespace CSnippets
{
	public class CSnippets
	{
		public static void Main()
		{
            //#region Array
            //// ArrayClass
            //ArrayClass.ArrayClass.RunArrayClass();
            //Console.WriteLine();
			
            //// ArrayQueue
            //ArrayQueue.ArrayQueue aq = new ArrayQueue.ArrayQueue();
            //aq.RunArrayQueue();
            //Console.WriteLine();
            //#endregion // Array
		
            //#region Threads
            //SimpleThreadPool.SimpleThreadPool.RunSimpleThreadPool();
            //Console.WriteLine();
			
			
            //AutoResetEventDemo.AutoResetEventDemo.RunAutoResetEventDemo();
            //#endregion // Threads
			
            //#region Queue
            //BasicQueue.BasicQueue.RunBasicQueue();
            //ShareQueueInThread.ShareQueueInThread.RunShareQueueInThread();
            //#endregion // Queue
			
            //#region Directory
            //EnumerateDirectory.EnumerateDirectory.ShowCurrentDirectory();
            //#endregion // Directory

            //#region DataType
            //DataType.DataType.SizeofType();
            //#endregion // DataType

            //#region Classes
            //Classes.ConstructorAndDestructor.TestIt();
            //#endregion // Classes

            //#region GC
            //GC.DisposeExample.TestDispose();
            //GC.UsingStatement.TestUsingStatement();
            //GC.FinalizeExample.TestFinalizeExample();
            //#endregion // GC

            //#region Ref and Out
            //RefAndOut.ArgumentWithRefAndOut.TestArgumentWithRefAndOut();
            //#endregion // Ref and Out

            //#region Operator Overloading
            //OperatorOverload.OperatorExample.TestOperatorExample();
            //#endregion // Operator Overloading

            //#region Indexer and Property
            //IndexerAndProperty.IndexerExample.TestIndexerExample();
            //#endregion // Indexer and Property

            //#region Interface
            //Interfacce.InterfaceExample.TestInterfaceExample();
            //#endregion // Interface

            //#region Exception
            //Exception.ExceptionExample.TestExceptionExample();
            //#endregion // Exception

            //#region Delegate
            //Delegate.DelegateExample.TestDelegateExample();
            //#endregion // Delegate

            //#region Lambda
            //Lambda.LambdaExample.TestLambdaExample();
            //#endregion // Lambda

            //#warning Just a error testing message
            //#line 45 "Event/EventExample.cs"

            //#region Event
            //Event.EventExample.TestEventExample();
            //#endregion // Event

            #region RTTI
            Type t = typeof(ValueType);
            Console.WriteLine("Full Name -> {0} and it is a class<{1}>", t.FullName, t.IsClass);
            #endregion // RTTI

            #region Reflection
            Reflection.ReflectionExample.TestReflectionExample();
            Reflection.ReflectionExample.TestReflectionExample2();
            #endregion // Reflection 

            Console.ReadKey();
        }
	}
}