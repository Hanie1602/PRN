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

namespace AirConditionerShop_LuongNgocThuyDuong
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	//Class MainWindow kế thừa Class Window - class có sẵn trong .NET SDK
	//Class MainWindow này có 2 khả năng:
	// - OOP như bình thường
	// - Render ra màn hình như mọi cửa sổ của các App khác
	//Thêm khả năng thứ 3:
	// - Vì có phần Render nên: ta có thể thay đổi các prop/ property của cửa sổ thông qua code, hoặc qua màn hình design kéo thả chuột, hoặc qua phần gõ tag theo style xaml - giống html - tạm gọi html/css kiểu của microsoft
	//Nhưng tag này chỉ Render ra UI cửa sổ chạy trên Desktop, chạy trên Browser????

	//Để chuyển qua lại giữa 2 Mode: Code OOP và Design -> Dùng phím F7 từ Design -> Code
	//													   Phím Shift F7 từ Code -> Design
	//Phần Code OOP - File .xaml.cs -> Được gọi là Code Behind -> Code nằm sau trang/Render UI
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
	}
}