using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        // Khởi tạo DI container và tiêm dịch vụ
        var serviceProvider = new ServiceCollection()
            .AddTransient<ThanhToanTienMat>()  // Đăng ký các lớp thanh toán
            .AddTransient<ThanhToanBangThe>()
            .AddTransient<ThanhToanOnline>()
            .AddTransient<HeThongThanhToan>()  // Đăng ký HeThongThanhToan
            .BuildServiceProvider();

        // Lấy đối tượng HeThongThanhToan từ DI container
        var heThongThanhToan = serviceProvider.GetService<HeThongThanhToan>();
        XacThucMaPin xacThucMaPin = new();
        bool cont = true;
        while (cont)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. Thanh toán bằng tiền mặt");
            Console.WriteLine("2. Thanh toán bằng thẻ");
            Console.WriteLine("3. Thanh toán online");
            Console.WriteLine("4. Xem lịch sử giao dịch");
            Console.WriteLine("5. Đăng ký tài khoản");
            Console.WriteLine("6. Thoát");
            Console.Write("Chọn chức năng: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Nhập số tiền cần thanh toán: ");
                    double soTienMat = Convert.ToDouble(Console.ReadLine());
                    var thanhToanTienMat = serviceProvider.GetService<ThanhToanTienMat>(); // Lấy đối tượng thanh toán tiền mặt
                    heThongThanhToan.ThucHienThanhToan(thanhToanTienMat, soTienMat, "Tien mat");
                    break;

                case "2":
                    Console.Write("Nhập số tiền cần thanh toán: ");
                    double soTienThe = Convert.ToDouble(Console.ReadLine());
                    var thanhToanBangThe = serviceProvider.GetService<ThanhToanBangThe>(); // Lấy đối tượng thanh toán bằng thẻ
                    heThongThanhToan.ThucHienThanhToan(thanhToanBangThe, soTienThe, "The");
                    break;

                case "3":
                    Console.Write("Nhập số tiền cần thanh toán: ");
                    double soTienOnline = Convert.ToDouble(Console.ReadLine());
                    var thanhToanOnline = serviceProvider.GetService<ThanhToanOnline>(); // Lấy đối tượng thanh toán online
                    heThongThanhToan.ThucHienThanhToan(thanhToanOnline, soTienOnline, "Online");
                    break;

                case "4":
                    heThongThanhToan.XemLichSuGiaoDich();
                    break;

                case "5":
                    xacThucMaPin.Add();
                    break;

                case "6":
                    cont = false;
                    break;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        }
    }
}
