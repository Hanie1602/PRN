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
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
			//Check email và pass, check role trong Db
			//if role == 1 && role == 2 thì vào màn hình chính
			//ngược lại popup chửi không có quyền trong đề thi

			//Giả bộ show Main Window trước đã
			MainWindow mainWindow = new MainWindow();
			//ta đã thiết kế class MainWindow, giờ new nó, render nó
			mainWindow.Show();  //render Main Win
								//ẩn chính thằng Login đang đứng
			this.Hide();    //bỏ this cũng được, mình đang đứng trong Login Window, cái class này kế thừa class cha Window có sẵn hàm ẩn chính mình, ẩn 1 cửa sổ nào khác
		}

		private void QuitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
			//Window Forms: Application.Exit();
		}
	}
}
