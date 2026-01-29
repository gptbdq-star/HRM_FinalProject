using Domain.Entities;
using System;

namespace Application.Validators;

public static class LaborContractValidator
{
    public static void Validate(LaborContract contract)
    {
        if (contract.EmployeeId <= 0)
            throw new Exception("Nhân viên không hợp lệ.");

        if (contract.BasicSalary <= 0)
            throw new Exception("Lương cơ bản phải lớn hơn 0.");

        if (contract.EndDate <= contract.StartDate)
            throw new Exception("Ngày kết thúc hợp đồng phải sau ngày bắt đầu.");
    }
}
