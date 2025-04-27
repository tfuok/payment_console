using System.Text.Json;

public class HeThongThanhToan
{
    private readonly IThanhToan _thanhToanTienMat;
    private readonly IThanhToan _thanhToanBangThe;
    private readonly IThanhToan _thanhToanOnline;
    private List<GiaoDich> _lichSuGiaoDich = new List<GiaoDich>();
    private string filePath = "C:\\Users\\Admin\\Documents\\dotnet03\\HeThongThanhToanDaPhuongThuc\\thanhtoandaphuongthuc\\data.json";

    public HeThongThanhToan()
    {
        ReadData();
    }

    public HeThongThanhToan(IThanhToan thanhToanTienMat, IThanhToan thanhToanBangThe, IThanhToan thanhToanOnline)
    {
        _thanhToanTienMat = thanhToanTienMat;
        _thanhToanBangThe = thanhToanBangThe;
        _thanhToanOnline = thanhToanOnline;
        ReadData();
    }

    public void ThucHienThanhToan(IThanhToan thanhToan, double soTien, string phuongThuc)
    {
        bool thanhToanThanhCong = thanhToan.ThanhToan(soTien);
        if (thanhToanThanhCong)
        {
            GiaoDich giaoDich = new GiaoDich(phuongThuc, soTien, DateTime.Now);
            _lichSuGiaoDich.Add(giaoDich);
            XemLichSuGiaoDich();
            LuuLichSuGiaoDich();
        }
    }

    public void LuuLichSuGiaoDich()
    {
        try
        {
            var json = JsonSerializer.Serialize(_lichSuGiaoDich);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi lưu dữ liệu: {ex.Message}");
        }
    }

    public void XemLichSuGiaoDich()
    {
        foreach (GiaoDich x in _lichSuGiaoDich)
        {
            x.Print();
        }
    }

    public void ReadData()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                _lichSuGiaoDich = JsonSerializer.Deserialize<List<GiaoDich>>(json) ?? new List<GiaoDich>();

                var last = _lichSuGiaoDich.LastOrDefault();
                if (last != null)
                {
                    GiaoDich.countId = last.Id + 1; 
                }
                else
                {
                    GiaoDich.countId = 1;  
                }
            }
            else
            {
                Console.WriteLine("File dữ liệu không tồn tại, tạo mới danh sách giao dịch.");
                _lichSuGiaoDich = new List<GiaoDich>();
                GiaoDich.countId = 1;  
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi đọc dữ liệu: {ex.Message}");
        }
    }
}
