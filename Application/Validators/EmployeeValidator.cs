using Domain.Entities;
using System;
using System.Text.RegularExpressions;

namespace Application.Validators;

public static class EmployeeValidator
{
    public static void Validate(Employee e)
    {
        // 1. Validate Mã NV
        // 2. Validate Tên NV
        if (string.IsNullOrWhiteSpace(e.FullName))
            throw new Exception("Tên nhân viên không được để trống");

        if (e.FullName.Trim().Length < 3)
            throw new Exception("Tên nhân viên quá ngắn");

        // 3. Validate Email
        // Regex này đơn giản và hiệu quả cho hầu hết email
        if (!Regex.IsMatch(e.Email ?? "", @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new Exception("Email không đúng định dạng (VD: abc@gmail.com)");

        // 4. Validate SĐT (VN: 10 số, bắt đầu bằng 0)
        if (!Regex.IsMatch(e.Phone ?? "", @"^0\d{9}$"))
            throw new Exception("Số điện thoại phải bắt đầu bằng số 0 và có 10 chữ số");

        // 5. Validate Ngày sinh & Tuổi
        if (e.DateOfBirth > DateTime.Now)
            throw new Exception("Ngày sinh không được lớn hơn ngày hiện tại");

        int age = DateTime.Now.Year - e.DateOfBirth.Year;
        if (e.DateOfBirth.Date > DateTime.Now.AddYears(-age)) age--;

        if (age < 18)
            throw new Exception($"Nhân viên chưa đủ 18 tuổi (Hiện tại: {age} tuổi)");

        // 6. Validate Khóa ngoại
        if (e.DepartmentId <= 0)
            throw new Exception("Vui lòng chọn phòng ban");

        if (e.PositionId <= 0)
            throw new Exception("Vui lòng chọn chức vụ");
    }
}