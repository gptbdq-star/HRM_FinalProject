using Application.Interfaces;
using Domain.Entities;
using System;
using System.Linq;

namespace Application.Validators;

public class LaborContractBusinessValidator
{
    private readonly IUnitOfWork _unitOfWork;

    public LaborContractBusinessValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void ValidateForCreate(LaborContract contract)
    {
        bool hasActive = _unitOfWork.LaborContracts.Any(c =>
            c.EmployeeId == contract.EmployeeId &&
            c.Status == "Active");

        if (hasActive)
            throw new Exception("Nhân viên này đã có hợp đồng đang hiệu lực.");
    }
}
