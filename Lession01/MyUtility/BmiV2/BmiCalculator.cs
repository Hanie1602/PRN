namespace BmiV2
{
    /// <summary>
    /// Class này chứa các hàm liên quan đến chỉ số BMI, là chỉ số dựa trên chiều cao và cân nặng giúp đánh giá 1 ai đó có mập ốm hay không (Đây là class document khi ai đó đọc code của mình)
    /// </summary>
    public class BmiCalculator
    {
        //Khai báo biến, và hàm => gọi chung là member của 1 class
        //Biến: gọi là field, property, attribute, instance variable (non-static), class-variable (static)
        //Math.sqrt()   Math.Sqrt()

        //Tên hàm trong java: Verb + Object, chữ hoa từng đầu từ, từ đầu tiên chữ thường, gọi là  cú pháp con lạc đà
        //camel Case Notation, ví dụ: sqlrt() toString() getGpa()
        //Tên hàm trong C#: Verb + Object, chữ hoa từng đầu từ kể cả từ đầu tiên, gọi là cú pháp Pascal
        //Pascal Case Notation, ví dụ: Sqrt() ToString() GetGpa()
        //===============================================================================================================

        /// <summary>
        /// Hàm này tính trị số BMI của 1 cá nhân bất kì và trả về con số đó. Phép tính BMI dựa trên chiều cao, cân nặng
        /// </summary>
        /// <param name="weigh">Cân nặng đo bằng kg</param>
        /// <param name="height">Chiều cao đo bằng m</param>
        /// <returns></returns>

        //Nếu hàm chỉ có 1 câu lệnh duy nhất; Cho phép ăn bớt, rút gọn code
        //Bỏ luôn { bỏ luôn retur, bỏ luôn }
        //Kỹ thuật viết thân hàm {...} theo style rút gọn, được gọi là Expression Body - thên hàm như 1 biểu thức.
        //Cấm ko được nhầm lẫn với biểu thức Lambda,  cũng xài chung => //Học sau
        //Cách 1:
        public static double GetBmi(double weigh, double height) => weigh / (height * height);

        //Cách 2:
        //static double GetBmi(double weigh, double height) 
        //    =>
        //        weigh / (height * height);

        //Cách 3:
        //static double GetBmi(double weigh, double height) =>
        //    weigh / (height * height);



        //====================================================================================
        //static double GetBmi(double weigh, double height)
        //{
        //    //Quy tắc đặt tên biến - biến local
        //    //Cú pháp con lạc đà, Noun
        //    return weigh / (height * height);
        //}

        //====================================================================================
        //VIẾT THỬ NGHIỆM THÊM 1 CÁI HÀM KHÁC, HÀM VOID, STYLE EXPRESSION BODY

        static void PrintBmiString() => Console.WriteLine("BMI stands for Body Mass Index - chỉ số khối của cơ thể - con số được tính dựa trên chiều cao và cân nặng");
        
        //Cách 2:
        //static void PrintBmiString()
        //{
        //    Console.WriteLine("BMI stands for Body Mass Index - chỉ số khối của cơ thể - con số được tính dựa trên chiều cao và cân nặng");
        //}
    }
}
