using LibraryManagement.GUI.Entities;
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

namespace LibraryManagement.GUI
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

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//đổ gird
			LibraryDbContext context = new();
			BookListDataGrid.ItemsSource = context.Books.ToList();

		}

		private void CreateButton_Click(object sender, RoutedEventArgs e)
		{
			//nút save màn hình detail
			LibraryDbContext context = new();
			Book b = new() { };
			//b.BookId = gõ từ ô book id; VÌ KEY TỰ TĂNG, KO GÁN BOOKID
			b.BookName = "TOTOCHAN cô bé bên cửa sổ"; //Ô text chứa tên cuốn sách gõ vào
			b.Author = "JAPAN";
			b.BookCategoryId = 5;
			context.Books.Add(b);
			context.SaveChanges();

			//f5 lại gird
			context = new();
			BookListDataGrid.ItemsSource = null;	//xóa gird, load lại
			BookListDataGrid.ItemsSource = context.Books.ToList();
		}
	}
}