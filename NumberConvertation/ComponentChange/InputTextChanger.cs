using System.Windows.Controls;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace NumberConvertation
{
	public partial class MainWindow : Window
	{
		private bool isInverted = false;
		private bool[] isWorked = new bool[2] { false, false };
		private void Input1_TextChanged(object sender, TextChangedEventArgs e)
		{
			isWorked[0] = true;
			if (calculations != null && !isWorked[1])
			{
				calculations.Execute(false);
				isInverted = false;
			}
			isWorked[0] = false;
		}
		private void Input2_TextChanged(object sender, TextChangedEventArgs e)
		{
			isWorked[1] = true;
			if (calculations != null && !isWorked[0])
			{
				calculations.Execute(true);
				isInverted = true;
			}
			isWorked[1] = false;
		}
	}
}
