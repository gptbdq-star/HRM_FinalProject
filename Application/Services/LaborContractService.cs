using Application.Interfaces;
using Application.Validators;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services;

public class LaborContractService : ILaborContractService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly LaborContractBusinessValidator _businessValidator;

    public LaborContractService(IUnitOfWork unitOfWork, LaborContractBusinessValidator businessValidator)
    {
        _unitOfWork = unitOfWork;
        _businessValidator = businessValidator;
    }

    public IEnumerable<LaborContract> GetAll()
    {
        return _unitOfWork.LaborContracts.GetAll();
    }

    public LaborContract? GetById(int id)
    {
        return _unitOfWork.LaborContracts.GetById(id);
    }

    public void Create(LaborContract contract)
    {
        LaborContractValidator.Validate(contract);

        contract.ContractNumber = GenerateContractNumber();
        contract.Status = "Active";

        _businessValidator.ValidateForCreate(contract);

        var oldContracts = _unitOfWork.LaborContracts.GetAll()
            .Where(c => c.EmployeeId == contract.EmployeeId && c.Status == "Active")
            .ToList();

        foreach (var old in oldContracts)
        {
            old.Status = "Expired";
            _unitOfWork.LaborContracts.Update(old);
        }

        _unitOfWork.LaborContracts.Add(contract);
        _unitOfWork.Save();
    }

    public void Update(LaborContract contract)
    {
        LaborContractValidator.Validate(contract);

        _unitOfWork.LaborContracts.Update(contract);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        var contract = _unitOfWork.LaborContracts.GetById(id);
        if (contract != null)
        {
            _unitOfWork.LaborContracts.Delete(contract);
            _unitOfWork.Save();
        }
    }

    private string GenerateContractNumber()
    {
        var lastCode = _unitOfWork.LaborContracts.GetAll()
            .Where(c => c.ContractNumber.StartsWith("HD"))
            .Select(c => c.ContractNumber)
            .OrderByDescending(c => c)
            .FirstOrDefault();

        int next = 1;

        if (!string.IsNullOrEmpty(lastCode))
        {
            int.TryParse(lastCode.Substring(2), out next);
            next++;
        }

        return $"HD{next.ToString("D3")}";
    }
}
