public class ThanhToanOnline : IThanhToan
{
    private static string generatedOtp;
    public bool ThanhToan(double soTien)
    {
        generatedOtp = GenerateOtp();
        Console.WriteLine($"Mã OTP của bạn là: {generatedOtp}");
        Console.Write("Vui lòng nhập mã OTP để xác nhận giao dịch: ");
        string otp = Console.ReadLine();
        if (otp == generatedOtp)
        {
            Console.WriteLine($"Đã thanh toán {soTien} bằng thanh toán Online!");
            return true;
        }
        else
        {
            Console.WriteLine("Mã OTP không đúng. Giao dịch thất bại.");
            return false;
        }
    }
    private string GenerateOtp()
    {
        Random random = new Random();
        string otp = random.Next(1000, 9999).ToString();
        return otp;
    }
}
