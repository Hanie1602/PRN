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
	/// <summary>
	/// Interaction logic for BookDetailWindow.xaml
	/// </summary>
	public partial class BookDetailWindow : Window
	{
		private BookService _bookService = new(); //vai trò chính vì sẽ đưa cuốn sách xuống table
												  //màn hình tạo ms + sửa sách
		private CategoryService _cateService = new();
		//Vì sẽ đưa cuốn sách xuống table
		//Màn hình này là màn hình tạo mới hoặc chỉnh sửa sách!!!!

		//ta khai báo 1 biến/property để hứng/chứa cái cuốn sách
		//cần update/edit thì user chọn 1 cuốn Grid ở Main window
		//Biến này sẽ được set value = dòng selected bên Grid
		//trong mode edit
		//còn mode new mới cuốn sách, biến này sẽ mang null
		//BIẾN NÀY GỌI LÀ BIE1N FLAG/PHẤT CỜ KIỂM SOÁT TRẠNG THÁI DATA/ MÀN HÌNH - CỘT STATUS
		//fullprop hoặc prop (auto generated prop)
		public Book SelectedBook { get; set; } = null;
		//_selectetdBook tự sinh ra            = null
		//int yob = 2004 => hàm Set() value cho 1 biến
		//  cw(yob)      => hàm Get() lấy giá trị của biến

		//Nếu tạo mới sác, không cần quan tâm biến này
		//Nếu edit sách, biến này phải có value của biến Gird gửi sang

		public BookDetailWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//đổ catagory vào đây, nhưng lừa đảo số cột cụ thể
			//ta cần nhờ CategorySevice, có hàm select * from Cate
			BookCategoryIdComboBox.ItemsSource = _cateService.GetAllCategories();
			//treo đầu dê, bán thịt heo
			//show type, nhưng thực sự lưu ID để lấy FK cho table Book, vì ta đang cần chọn Category ID khi tạo 1 cuốn sách mới thì phải chọn mã tên
			BookCategoryIdComboBox.DisplayMemberPath = "BookGenreType"; //show cột nào
			BookCategoryIdComboBox.SelectedValuePath = "BookCategoryId"; //lấy value nào để dùng

			BookCategoryIdComboBox.SelectedValue = 1;   //Hard-code cate đầu tiên trong new mode
			BookModeLabel.Content = "Create a New Book";


			//Kiểm tra Mode của màn hình nỳ: Edit hay Create
			//Thông qua biến Flag SelectedBook
			if (SelectedBook != null)
			{
				//Đổ từng ô nhập, disable ô ID, cấm Edit ID
				//.....
				//MessageBox.Show(SelectedBook.BookId + " | " + SelectedBook.BookName);

				//đổi label thông báo của window tùy theo mình edit hay create
				BookModeLabel.Content = "Update a Selected Book Info";

				BookIdTextBox.Text = SelectedBook.BookId.ToString();
				BookIdTextBox.IsEnabled = false;    //Cấm không cho Edit FK cuốn sách

				BookNameTextBox.Text = SelectedBook.BookName;
				DescriptionTextBox.Text = SelectedBook.Description;
				PublicationDateDatePicker.Text = SelectedBook.PublicationDate.ToString();
				QuantityTextBox.Text = SelectedBook.Quantity.ToString();
				PriceTextBox.Text = SelectedBook.Price.ToString();
				AuthorTextBox.Text = SelectedBook.Author;

				//QUAN TRỌNG: ĐỪNG QUÊN JUMP NHẢY ĐẾN ĐÚNG CÁI CATEGORY MÀ CUỐN SÁCH ĐANG THUỘC VÊ
				BookCategoryIdComboBox.SelectedValue = SelectedBook.BookCategoryId;
			}
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show("You select cate: " + BookCategoryIdComboBox.SelectedValue);
			//new cuốn sách, set các property, gọi Service save xuống

			//TODO: BẮT VALIDATION CHO CÁC Ô NHẬP
			//Required 1 ô text: Is null or empty (WSF)

			//Bắt số nằm trong khoảng, đoạn,...chắc chắn if, nhưng phải convert data trong ô text về số - int .Parse() là 1 cách
			//														còn cách convert mà ko bị Exception

			int quantity = int.Parse(QuantityTextBox.Text);	
			if (quantity < 0 || quantity > 4_000_000)
			{
				MessageBox.Show("The quantity must be between 1....4,000,000");
				return;
			}
			//chửi hết 1 loạt, return sớm, đoạn cuối là data ngon!!!

			Book x = new();
			x.BookId = int.Parse(BookIdTextBox.Text);
			x.BookName = BookNameTextBox.Text;
			x.Description = DescriptionTextBox.Text;

			x.PublicationDate = (DateTime)PublicationDateDatePicker.SelectedDate;

			x.Quantity = int.Parse(QuantityTextBox.Text);
			x.Price = double.Parse(PriceTextBox.Text);
			x.Author = AuthorTextBox.Text;
			x.BookCategoryId = int.Parse(BookCategoryIdComboBox.SelectedValue.ToString());

			//check mode
			if (SelectedBook == null)    //Create mode
				_bookService.CreateBook(x);
			else
				_bookService.UpdateBook(x);

			this.Close(); //hàm thừa kế từ class Window
						  //bên màn hình chính phải F5 lại lưới -> đã có LoadedGrid
		}
	}
}
