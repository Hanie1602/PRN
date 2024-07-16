using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string BookName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime PublicationDate { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }

    public string Author { get; set; } = null!;

    public int BookCategoryId { get; set; }

    //BookCategoryId chính là FK trỏ vào table Category
    //muốn lấy đc GenreType/Name thì phải JOIN 2 table

    //Tư duy OOP: Cuốn sách Book thuộc về Category (class/object)
    //Tư duy DB: Cuốn sách Book có CategoryID = ??
    //          muốn lấy đc CategoryID, GenreType, Desc thì
    //          chấm ở biến Category, object Category
    // Trong Book có đủ info của object Category (3 cột - 3prop)
    // tức là nếu có join thì join ngầm trong RAM, đối vs dev thì chỉ thấy object và chấm để lấy bên trong or bên kia table
    
    public virtual BookCategory BookCategory { get; set; } = null!;
    //Cuốn sách thuộc về Category
    //                          biến nói về Cate cụ thể trong 5 Cate trong table Category
    //                          biến này chấm là ra 3 cột cụ thể
    //                          biến đc gọi là NAVIGATION PATH
    //                          con đường sang table Category kia
    //biến path này mặc định khi select table Book, new từng scahs trong ram, biến này ko mang giá trị, ko join để biết cuốn sách thuộc cate nào, - LAZY LOADING
    // ĐỂ TĂNG PERFORMANCE, KO NÀO CẦN THÌ BÁO DB LẤY GIÚP

    //ĐỂ JOIN, TA DÙNG HÀM INCLUDE (BIẾN OBJECT MÓC SANG BÊN KIA)
}
