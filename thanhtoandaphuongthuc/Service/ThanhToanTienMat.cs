public class ThanhToanTienMat : IThanhToan
{
    public bool ThanhToan(double soTien)
    {
        Console.WriteLine($"Đã thanh toán {soTien} bằng tiền mặt!");
        return true;
    }
}
