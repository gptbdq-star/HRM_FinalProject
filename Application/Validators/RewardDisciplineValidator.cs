using Domain.Entities;
using System;

namespace Application.Validators;

public static class RewardDisciplineValidator
{
    public static void Validate(RewardDiscipline item)
    {
        if (item.EmployeeId <= 0)
            throw new Exception("Nhân viên không hợp lệ.");

        if (item.Amount <= 0)
            throw new Exception("Số tiền phải lớn hơn 0.");

        if (string.IsNullOrWhiteSpace(item.Reason))
            throw new Exception("Lý do không được để trống.");

        if (item.DecisionDate > DateTime.Now)
            throw new Exception("Ngày quyết định không hợp lệ.");
    }
}
