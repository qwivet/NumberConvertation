using System;
using System.Windows;

namespace NumberConvertation
{
	public partial class MainWindow : Window
	{
		private void FirstSystem_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (calculations != null)
			{
				calculations.FirstSystem = Convert.ToInt32(FirstSystem.Value);
				if (FirstSystemPointer != null)
				{
					FirstSystemPointer.Text = FirstSystem.Value.ToString();
				}
				isWorked[0] = true;
				calculations.Execute(false);
				isWorked[0] = false;
			}
		}
		private void SecondSystem_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (calculations != null)
			{
				calculations.SecondSystem = Convert.ToInt32(SecondSystem.Value);
				if (SecondSystemPointer != null && SecondSystem != null)
				{
					SecondSystemPointer.Text = SecondSystem.Value.ToString();
				}
				isWorked[0] = true;
				calculations.Execute(false);
				isWorked[0] = false;
			}
		}
	}
}
