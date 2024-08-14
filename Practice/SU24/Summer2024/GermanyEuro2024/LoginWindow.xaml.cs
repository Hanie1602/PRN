using GermanyEuro2024_BLL.Services;
using GermanyEuro2024_DAL.Entities;
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
using System.Windows.Shapes;

namespace GermanyEuro2024
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		private UefaaccountService _service = new();

		public LoginWindow()
		{
			InitializeComponent();
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			string email = EmailTextBox.Text;
			string password = PasswordTextBox.Text;

			Uefaaccount u = _service.Authenticate(email, password);
			if (u == null)
			{
				MessageBox.Show("Invalid email or password", "Invalid credentials", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if(u.Role == 1 || u.Role == 4)
			{
				MessageBox.Show("You have no permission to access this function!", "Wrong permission", MessageBoxButton.OK, MessageBoxImage.Error);
				return ;
			}
			MainWindow window = new MainWindow();
			window.Uefaaccount = u;
			window.Show();
			this.Hide();
		}

		private void QuitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
