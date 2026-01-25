using Domain.Entities;
using System.Text.RegularExpressions;

namespace Application.Validators;

public static class EmployeeValidator
{
    public static void Validate(Employee e)
    {
        if (string.IsNullOrWhiteSpace(e.EmployeeCode))
            throw new Exception("Mã nhân viên không được để trống");

        if (e.EmployeeCode.Length < 3)
            throw new Exception("Mã nhân viên quá ngắn");

        if (string.IsNullOrWhiteSpace(e.FullName))
            throw new Exception("Tên nhân viên không được để trống");

        if (e.FullName.Length < 3)
            throw new Exception("Tên nhân viên quá ngắn");

        if (!Regex.IsMatch(e.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new Exception("Email không hợp lệ");

        if (!Regex.IsMatch(e.Phone, @"^(0|\+84)[0-9]{9}$"))
            throw new Exception("Số điện thoại không hợp lệ");

        if (e.DateOfBirth > DateTime.Now)
            throw new Exception("Ngày sinh không hợp lệ");

        var age = DateTime.Now.Year - e.DateOfBirth.Year;
        if (e.DateOfBirth.Date > DateTime.Now.AddYears(-age)) age--;
        if (age < 18) 
            throw new Exception("Nhân viên chưa đủ 18 tuổi");

        if (e.DepartmentId <= 0)
            throw new Exception("Chưa chọn phòng ban");

        if (e.PositionId <= 0)
            throw new Exception("Chưa chọn chức vụ");
    }

}
