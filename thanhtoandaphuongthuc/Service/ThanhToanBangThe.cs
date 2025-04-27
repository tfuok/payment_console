public class ThanhToanBangThe : IThanhToan
{
    XacThucMaPin xacThucMaPin = new();
    public bool ThanhToan(double soTien)
    {
        Console.Write("Vui lòng nhập mã PIN để xác nhận giao dịch: ");
        string pin = Console.ReadLine();
        if (xacThucMaPin.xacThuc(pin) == true)
        {
            Console.WriteLine($"Đã thanh toán {soTien} bằng thẻ!");
            return true;
        }
        else
        {
            Console.WriteLine("Mã PIN không đúng. Giao dịch thất bại.");
            return false;
        }
    }

}
