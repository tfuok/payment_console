public class GiaoDich
{
    public static int countId = 1;  
    public int Id { get; set; }
    public string PhuongThuc { get; set; }
    public double SoTien { get; set; }
    public DateTime ThoiGian { get; set; }

    public GiaoDich()
    {
    }

    public GiaoDich(string phuongThuc, double soTien, DateTime tgian) 
    {
        Id = countId++;  
        PhuongThuc = phuongThuc;
        SoTien = soTien;
        ThoiGian = tgian;
    }

    public void Print()
    {
        Console.WriteLine($"ID: {Id}, Phương thức: {PhuongThuc}, Số Tiền: {SoTien}, TGian: {ThoiGian}");
    }
}
