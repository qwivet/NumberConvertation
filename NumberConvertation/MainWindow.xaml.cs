using System.Windows;

namespace NumberConvertation
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		readonly SystemConvert calculations;
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
