// 
// EnumerateDirectory.cs
//  
// Author:
//       Leezhm <leezhm@126.com>
//             
// Copyright (c) 2012 leezhm@126.com
// 
// Created:
//       Leezhm <12-5-6 下9:14>
// 
// Modified:
//       Leezhm <12-5-6 下9:14>
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
// 
// 

using System;
using System.IO; // for Directory

using System.Collections.Generic; // for List

namespace EnumerateDirectory
{
	public class EnumerateDirectory
	{
		public EnumerateDirectory()
		{
		}		
		
		/// <summary>
		/// Gets the files from the designated directory.
		/// </summary>
		/// <returns>
		/// The files.
		/// </returns>
		/// <param name='path'>
		/// Path.
		/// </param>
		public static string[] GetFiles(string path)
		{
			if (String.Empty == path)
			{
				Console.WriteLine("Path is Empty ...");
				return null;
			}
			
			try
			{
				var files = Directory.EnumerateFiles(path);
				
				List<string> listFiles = new List<string>(files);
				
				return listFiles.ToArray();
			}
			catch (PathTooLongException expt)
			{
				Console.WriteLine(expt.ToString());
			}
			catch (UnauthorizedAccessException expt)
			{
				Console.WriteLine(expt.ToString());
			}
			catch (DirectoryNotFoundException expt)
			{
				Console.WriteLine(expt.ToString());
			}
			
			return null;
		}
		
		/// <summary>
		/// Gets the directories.
		/// </summary>
		/// <returns>
		/// The directories.
		/// </returns>
		/// <param name='path'>
		/// Path.
		/// </param>
		public static string[] GetDirectories(string path)
		{
			if (String.Empty == path)
			{
				Console.WriteLine("Path is Empty ...");
				return null;
			}
			
			try
			{
				var dirs = Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories);
				
				List<string> listDirs = new List<string>(dirs);
				
				// Don't forget the current directory.
				listDirs.Add(path);
				
				return listDirs.ToArray();
			}
			catch (UnauthorizedAccessException expt)
			{
				Console.WriteLine(expt.ToString());
			}
			catch (DirectoryNotFoundException expt)
			{
				Console.WriteLine(expt.ToString());
			}
			catch (PathTooLongException expt)
			{
				Console.WriteLine(expt.ToString());
			}
			
			return null;
		}
				
		public static void ShowCurrentDirectory()
		{
			//string path = Directory.GetCurrentDirectory();
            string path = System.Environment.CurrentDirectory;
			
			string [] dirs = GetDirectories(path);
			
			foreach (string dir in dirs)
			{
				string [] files = GetFiles(dir);
				foreach (string file in files)
				{
					Console.WriteLine(file);
				}
			}
		}
	}
}

