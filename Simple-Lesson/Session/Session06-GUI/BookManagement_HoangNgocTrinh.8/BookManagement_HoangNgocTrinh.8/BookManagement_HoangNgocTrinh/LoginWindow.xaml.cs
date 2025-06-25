using Repositories.Models;
using Services;
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

namespace BookManagement_HoangNgocTrinh
{

    public partial class LoginWindow : Window
    {
        private UserAccountService _service = new();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //check email-pass, check role trong db
            //if role == 1 or role == 2 thì vào màn hình main
            //ngược lại, popup chửi ko có quyền trong đề thi

            string email = EmailTextBox.Text;
            string pass = PasswordTextBox.Text;

            UserAccount user = _service.Authenticate(email, pass);
            //user == null, sai user/pass rồi
            //user != null, check role, nếu role 3, ko cho vào, ngược lại là 1 và 2 thì vào Main đi
            if (user == null)
            {
                MessageBox.Show("Invalid email or password", "Invalid credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } 
            if (user.Role == 3)   //Cấm vào vì là Member
            {
				MessageBox.Show("You have no permission to access this function!", "Wrong permission", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
			}

            //giả bộ show mainWWindow trước
            MainWindow mainWindow = new MainWindow();
            
            //trước khi render, đẩy user sang bên kia
            mainWindow.Account = user;

            // ta đã thiết kế class MainWindow, giờ new nó và render nó
            mainWindow.Show(); //RENDER MAIN WINdow
            //ẩn loginwindow
            this.Hide(); //bỏ this cũng đc, mình đang đứng trông LoginWindow, kế thừa class cha Window, có hàm ẩn chính mình, ẩn 1 cửa sổ nào khác
         
        }

		private void QuitButton_Click(object sender, RoutedEventArgs e)
		{
            Application.Current.Shutdown();
            //Window Forms: Application.Exit();
		}

		private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

        }
    }
}
