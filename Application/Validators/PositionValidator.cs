using Domain.Entities;

namespace Application.Validators;

public static class PositionValidator
{
    public static void Validate(Position position)
    {
        if (string.IsNullOrWhiteSpace(position.PositionName))
            throw new Exception("Tên chức vụ không được để trống");

        if (position.PositionName.Length < 2)
            throw new Exception("Tên chức vụ quá ngắn");

        if (string.IsNullOrWhiteSpace(position.Level))
            throw new Exception("Cấp bậc không được để trống");
    }
}
