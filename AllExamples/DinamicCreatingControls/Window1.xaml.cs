﻿/*
 * Created by SharpDevelop.
 * User: VMP
 * Date: 04.11.2012
 * Time: 18:20
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

namespace DinamicCreatingControls
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
			
			CreateButtonArray(this.wrpPanel1, new RoutedEventHandler(btn_Click));
			CreateButtonArray(this.wrpPanel2, new RoutedEventHandler(btn2_Click));
			CreateButtonArray(this.wrpPanel3, new RoutedEventHandler(btn3_Click));
		}
		
		/// <summary>
		/// Dynamic creating components in WrapPanel.
		/// </summary>
		/// <param name="pnl"></param>
		public void CreateButtonArray(WrapPanel pnl, RoutedEventHandler routedEventHandler)
		{
			Button btn = null;
			
			for (int i=0; i<30; i++)
			{
				btn = new Button();
				btn.Content = "button" + i.ToString();
				btn.Width = 100;
				btn.Height = 23;
				btn.Margin = new Thickness(5,5,5,5);
				btn.Click += routedEventHandler;
				pnl.Children.Add(btn);
			}
		}

		void btn_Click(object sender, RoutedEventArgs e)
		{
			Button btn = sender as Button;
			this.txbBox1.AppendText(DateTime.Now.ToString() + " Нажата кнопка " + btn.Content.ToString() + "\r\n");
			this.txbBox1.ScrollToEnd();
		}
		
		void btn2_Click(object sender, RoutedEventArgs e)
		{
			Button btn = sender as Button;
			this.txbBox1.AppendText(DateTime.Now.ToString() + " Нажата кнопка " + btn.Content.ToString() + "\r\n");
			this.txbBox1.ScrollToEnd();
		}
		
		void btn3_Click(object sender, RoutedEventArgs e)
		{
			Button btn = sender as Button;
			this.txbBox1.AppendText(DateTime.Now.ToString() + " Нажата кнопка " + btn.Content.ToString() + "\r\n");
			this.txbBox1.ScrollToEnd();
		}
	}
}