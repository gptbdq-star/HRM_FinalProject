using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Services;

public class LaborContractService : ILaborContractService
{
    private readonly IUnitOfWork _unitOfWork;

    public LaborContractService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<LaborContract> GetAll()
    {
        // Trả về toàn bộ hợp đồng, UnitOfWork sẽ tự động Include thông tin Employee nếu bạn cấu hình Repository đúng
        return _unitOfWork.LaborContracts.GetAll();
    }

    public LaborContract? GetById(int id)
    {
        return _unitOfWork.LaborContracts.GetById(id);
    }

    public void Create(LaborContract contract)
    {
        // Logic nghiệp vụ: Ngày kết thúc phải sau ngày bắt đầu
        if (contract.EndDate <= contract.StartDate)
        {
            throw new Exception("Ngày kết thúc hợp đồng phải sau ngày bắt đầu.");
        }

        if (contract.BasicSalary < 0)
        {
            throw new Exception("Lương cơ bản không được nhỏ hơn 0.");
        }

        _unitOfWork.LaborContracts.Add(contract);
        _unitOfWork.Save();
    }

    public void Update(LaborContract contract)
    {
        var existing = _unitOfWork.LaborContracts.GetById(contract.Id);
        if (existing == null) throw new Exception("Không tìm thấy hợp đồng để cập nhật.");

        if (contract.EndDate <= contract.StartDate)
        {
            throw new Exception("Ngày kết thúc hợp đồng phải sau ngày bắt đầu.");
        }

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
}