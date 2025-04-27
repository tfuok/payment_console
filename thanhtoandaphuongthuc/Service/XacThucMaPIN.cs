using System.Text.Json;

public class XacThucMaPin
{
    public List<TaiKhoan> list = new();
    private readonly string path = "C:\\Users\\Admin\\Documents\\dotnet03\\HeThongThanhToanDaPhuongThuc\\thanhtoandaphuongthuc\\account.json";

    public XacThucMaPin()
    {
        ReadData();
    }
    public void Add()
    {
        Console.Write("Tên:");
        string name = Console.ReadLine();
        Console.Write("Mã PIN:");
        string pin = Console.ReadLine();
        if (list.Any(tk => tk.PIN == pin))
        {
            Console.WriteLine("Mã PIN đã tồn tại, vui lòng chọn mã PIN khác.");
            return;
        }
        TaiKhoan taiKhoan = new TaiKhoan(name, pin);
        list.Add(taiKhoan);
        SaveData();
    }
    public bool xacThuc(string pin)
    {
        return list.Any(x => x.PIN == pin);
    }

    public void SaveData()
    {
        var json = JsonSerializer.Serialize(list);
        File.WriteAllText(path, json);
    }

    public void ReadData()
    {
        string json = File.ReadAllText(path);
        list = JsonSerializer.Deserialize<List<TaiKhoan>>(json);
        var last = list.LastOrDefault();
        if (last != null)
        {
            TaiKhoan.countId = last.Id + 1;
        }
        else
        {
            TaiKhoan.countId = 1;
        }
    }
}