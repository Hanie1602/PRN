using Repositories.Models;
using Services;
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

namespace BookManagement_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookService _service = new();

        public MainWindow()
        {
            InitializeComponent();
        }

		private void BookListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

        }

		private void LoadBooksButton_Click(object sender, RoutedEventArgs e)
		{
            //ta cần class BookService giúp CRUD Book table
            BookListDataGrid.ItemsSource = _service.GetAllBooks();
		}

		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{
            //Nếu user chọn 1 dòng trong grid, ta có 1 oject mà thực ra là 1 new Book() từ table mà nay đang ở trong RAM của  BookService
            //ta convert nó troo37 lại thành Book object và đẩy sang form Detail để GetId(), GetName(), GetAuthor()...

            Book? selected = BookListDataGrid.SelectedItem as Book;

			//Book selected = (Book)BookListDataGrid.SelectedItem;
            //Ép kiểu thô bạo này dễ bị ngoại lệ
            //Ép kiểu mới as Book, ép ko được ko ném ngoại lệ, cho null

            if(selected != null)
            {
                MessageBox.Show(selected.BookId + " | " +
                    selected.BookName);
            }
		}
	}
}