using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookManagerGUIWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void AboutButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(@"Welcome to Book Store
A product of NET1815
Copyright © 2024 giáo làng"
, "About us", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void QuitButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult answer = MessageBox.Show("Do you want to quit?", "Quit?", MessageBoxButton.YesNo, MessageBoxImage.Question);
			
			if (answer == MessageBoxResult.Yes)
			{
				Application.Current.Shutdown();
			}
		}
	}
}