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

        //Khai báo cái prop/propfull để chứa info user đã login thành cong6
        //để mình còn disable các chức năng!!! tùy role 
        //role admin -> full tính năng 
        //role staff -> cấm create, delet, update
        public UserAccount Account { get; set; }


        public MainWindow()
        {
            InitializeComponent();
        }

		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{
            //nếu người dùng chon 1 dòng trong grid, ta có 1 object mà thực ra là 1 new Book từ table lên mà nay đang ở trong Ram của BookService
            //ta convert nó trở lại thành Book và đảy sang cái form detail để GetId() GetName() GetPrice() GetAuthor()...
            Book selected = BookListDataGrid.SelectedItem as Book;
			//java, C# cũ: Book selected = (Book)BookListDataGrid.SelectedItem;
            //ép kiểu thô bạo này dễ bị ngoại lệ
            // ép kiểu ms as Boook, ép ko đc ko ném ngoại lệ, cho null

            //if (selected != null)
            //    MessageBox.Show(selected.BookId + " | " + selected.BookName);

            if(selected == null)
            {
                MessageBox.Show("Please select a book before updating", "Select one", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

			//Đoạn này có sẵn 1 cuôn sách trong RAM được trỏ bởi selected
			//gán cuốn này sang cửa số màn hình detail qua prop SelectedBook
			BookDetailWindow detail = new();
			//trước khi render thì chuyển gán cuốn sách đang chọn trong grid sang bên kia
            detail.SelectedBook = selected;
			detail.ShowDialog();
			//F5 lại Grid đề phòng bà con update info sách, grid phải có info mới
			LoadDateGrid();
		}

		private void BookMainWindow_Loaded(object sender, RoutedEventArgs e)
		{
            //khi màn hình dc render, thì hàm này đc gọi và ta đổ data Books vào Grid, thay vì phải bấm nút
            //LƯU Ý VỀ VIỆC ĐỔ DATA VÀO GRID, VIỆC ANYF PHẢI LÀM NHIỀU LẦN
            //1. KHI MÀN HÌNH MỞ
            //2. KHI NHẤN NÚT XÓA 1 CUỐN SÁCH
            //3. KHI UPDATE 1 CUỐN SÁCH ... SỬA GIÁ -> ĐỎ LẠI ĐỂ CÓ GIÁ MS
            //4. KHI THÊM MS CUỐN SÁCH
            //ta tách việc đổ lưới này thành 1 hàm riêng, gọi lại ở nơi thích hợp -> giúp code dễ đọc
            LoadDateGrid();

            HelloMsgLabel.Content = "Hello " + Account.FullName;

			//Cấm các nút bấm
			if (Account.Role == 2)
			{
				CreateButton.IsEnabled = false;
				UpdateButton.IsEnabled = false;
				DeleteButton.IsEnabled = false;
			}
		}
        //HÀM HELPER - CHỈ CẦN PRIVATE
        private void LoadDateGrid()
        {
            BookListDataGrid.ItemsSource = null; //xóa data
            BookListDataGrid.ItemsSource = _service.GetAllBooks();

        }

		private void QuitButton_Click(object sender, RoutedEventArgs e)
		{
            Application.Current.Shutdown();
		}

		private void CreateButton_Click(object sender, RoutedEventArgs e)
		{
            //gọi màn hình detail trống lên để bà con nhập thông tin cuốn sách muốn tạo mới
            BookDetailWindow detail = new();
            //render
            detail.ShowDialog();
            //F5 GRID
            LoadDateGrid();
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			Book selected = BookListDataGrid.SelectedItem as Book;

			if (selected == null)
			{
				MessageBox.Show("Please select a book before deleting", "Select one", MessageBoxButton.OK, MessageBoxImage.Stop);
				return;
			}

            MessageBoxResult answer = MessageBox.Show("Do you really want to delete the selected book?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
                return;

            //đến đây, đủ info để chính thức xóa
            //gửi thằng selectedd cho hàm xóa của bên Service
            _service.DeleteBook(selected);
            //f5 Gird
            LoadDateGrid() ;
		}

		private void DescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void BookNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
            //Gọi Service lấ về 1 tập List<Book> và đẩy vào grid
            string name = BookNameTextBox.Text.ToLower();
            string desc = DescriptionTextBox.Text.ToLower();

            List<Book> result = _service.SearchBooksByNameAndDesc(name, desc);
            //F5 Grid
            BookListDataGrid.ItemsSource = null;    //xóa gird
            //Ko lấy data từ đâu cả
            BookListDataGrid.ItemsSource = result;
		}
	}
}