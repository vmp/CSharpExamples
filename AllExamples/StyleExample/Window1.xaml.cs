﻿/*
 * Created by SharpDevelop.
 * User: user
 * Date: 12/19/2012
 * Time: 15:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace StyleExample
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		
		private void element_MouseEnter(object sender, MouseEventArgs e)
		{
			((TextBlock)sender).Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
		}
		
		private void element_MouseLeave(object sender, MouseEventArgs e)
		{
			((TextBlock)sender).Background = null;
		}
	}
}