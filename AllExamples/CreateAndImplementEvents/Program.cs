﻿/*
 * Created by SharpDevelop.
 * User: VMP
 * Date: 11.08.2013
 * Time: 13:13
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace CreateAndImplementEvents
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			UseDelegate();
			
			Multicast();
			
			UsingLambdaExpressions();
			
			CreatingLambdaWithMultipleStatements();
			
			CreateAndRaise();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		#region -= Using delegates =-
		
		public delegate int Calculate(int x, int y);
		public static int Add(int x, int y) { return x + y; }
		public static int Multiply(int x, int y) { return x * y; }
		
		public static void UseDelegate()
		{
			Calculate calc = Add;
			Console.WriteLine(calc(3,4));
			
			calc = Multiply;
			Console.WriteLine(calc(3,4));
		}
		
		#endregion
		
		#region -= Multicast Delegate =-
		
		public static void MethodOne()
		{
			Console.WriteLine("MethodOne");
		}
		
		public static void MethodTwo()
		{
			Console.WriteLine("MethodTwo");
		}
		
		public delegate void Del();
		
		public static void Multicast()
		{
			Del d = MethodOne;
			d += MethodTwo;
			
			d();
			
			int invocationCount = d.GetInvocationList().GetLength(0);
			Console.WriteLine(invocationCount);
		}
		
		#endregion
		
		#region -= UsingLambdaExpressions =-
		
		public static void UsingLambdaExpressions()
		{
			Console.WriteLine("Example with lambda expressions:");
			Calculate calc = (x, y) => x + y;
			Console.WriteLine(calc(3,4));
			calc = (x, y) => x * y;
			Console.WriteLine(calc(3,4));
		}
		
		#endregion
		
		#region -= Creating a lambda expression with multiple statements =-
		
		public static void CreatingLambdaWithMultipleStatements()
		{
			Console.WriteLine("Creating a lambda expression with multiple statements:");
			Calculate calc = (x, y) =>
			{
				Console.WriteLine("Adding numbers");
				return x + y;
			};
			int result = calc(3, 4);
			Console.WriteLine(result);
		}
		
		#endregion
		
		#region -= Using an Action to expose an event =-
		
		public static void CreateAndRaise()
		{
			Pub p = new Pub();
			p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called");
			p.OnChange += (sender, e) => { throw new Exception(); };
			p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called");
			
			try
			{
				p.Raise();
			}
			catch (AggregateException ex)
			{
				Console.WriteLine(ex.InnerExceptions.Count);
			}
		}
		
		#endregion
	}
	
	public class Pub
	{
		public event EventHandler OnChange = delegate {};
		
		public void Raise()
		{
			var exceptions = new List<Exception>();
			foreach (Delegate handler in OnChange.GetInvocationList())
			{
				try
				{
					handler.DynamicInvoke(this, EventArgs.Empty);
				}
				catch (Exception ex)
				{
					exceptions.Add(ex);
				}
			}
			
			if (exceptions.Any())
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}