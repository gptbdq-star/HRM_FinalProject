using Domain.Entities;
using System.Text.RegularExpressions;

namespace Application.Validators;

public static class DepartmentValidator
{
    public static void Validate(Department department)
    {
        if (string.IsNullOrWhiteSpace(department.DepartmentName))
            throw new Exception("Tên phòng ban không được để trống");

        if (department.DepartmentName.Length < 3)
            throw new Exception("Tên phòng ban phải có ít nhất 3 ký tự");

        // Chỉ cho chữ, số, khoảng trắng (hỗ trợ tiếng Việt)
        if (!Regex.IsMatch(department.DepartmentName, @"^[\p{L}0-9\s]+$"))
            throw new Exception("Tên phòng ban không được chứa ký tự đặc biệt");
    }
}
