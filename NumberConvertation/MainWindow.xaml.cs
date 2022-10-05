using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NumberConvertation
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		SystemConvert calculations;
		public MainWindow()
		{
			InitializeComponent();
			calculations = new SystemConvert(Input1, Input2, new TextConvert());
			calculations.FirstSystem = 2;
			calculations.SecondSystem = 10;
			calculations.Accuracy = 2;
		}

	}
}
