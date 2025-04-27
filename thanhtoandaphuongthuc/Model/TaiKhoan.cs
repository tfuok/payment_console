public class TaiKhoan
{
    public static int countId = 1;
    public int Id { get; set; }
    public string Name { get; set; }
    public string PIN { get; set; }

    public TaiKhoan()
    {
    }

    public TaiKhoan(string name, string pin)
    {
        Id = countId++;
        Name = name;
        PIN = pin;
    }

}