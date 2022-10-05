using System;
using System.Windows;
using System.Windows.Controls;

namespace NumberConvertation
{
	public partial class MainWindow : Window
	{
		int accuracy = 2;
		private void AccuracyText_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (calculations != null)
			{
				try
				{
					if (AccuracyText.Text == "")
					{

					}
					else if (Int32.Parse(AccuracyText.Text) > 99)
					{
						AccuracyText.Text = "99";
						calculations.Accuracy = 99;
						accuracy = 99;
					}
					else if (Int32.Parse(AccuracyText.Text) < 1)
					{
						AccuracyText.Text = "1";
						calculations.Accuracy = 1;
						accuracy = 1;
					}
					else
					{
						calculations.Accuracy = Int32.Parse(AccuracyText.Text);
						accuracy = Int32.Parse(accuracy.ToString());
					}
				}
				catch
				{
					AccuracyText.Text = accuracy.ToString();
				}
				isWorked[Convert.ToInt32(isInverted)] = true;
				calculations.Execute(isInverted);
				isWorked[Convert.ToInt32(isInverted)] = false;
			}
		}
	}
}
