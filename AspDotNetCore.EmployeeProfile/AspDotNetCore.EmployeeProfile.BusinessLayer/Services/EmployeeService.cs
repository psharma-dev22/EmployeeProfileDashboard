﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCore.EmployeeProfile.BusinessLayer.Services.IServices;
using AspDotNetCore.EmployeeProfile.BusinessLayer.Utilities.CustomException;
using AspDotNetCore.EmployeeProfile.DAL.Entities;
using AspDotNetCore.EmployeeProfile.DAL.Repositories;
using AspDotNetCore.EmployeeProfile.DAL.Repositories.IRepositories;
using AspDotNetCore.EmployeeProfile.DTO.DTO;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ExcelDataReader;

namespace AspDotNetCore.EmployeeProfile.BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) 
        { 
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeDTO> GetAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetAsync(e => e.EmployeeId== employeeId);

            if (employee == null)
            {
                throw new UserNotFoundException();
            }

            return _mapper.Map<EmployeeDTO>(employee);
        }
        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeToAddDTO employeeToAddDTO)
        {
            var addedEmployee= await _employeeRepository.AddEmployeeAsync(_mapper.Map<Employee>(employeeToAddDTO));
            return _mapper.Map<EmployeeDTO>(addedEmployee);
        }

        public async Task<int> DeleteEmployeeAsync(int employeeId)
        {
            var employeeToDelete = await _employeeRepository.GetAsync(x => x.EmployeeId == employeeId);
            if (employeeToDelete is null)
            {
                throw new UserNotFoundException();
            }
            return await _employeeRepository.DeleteEmployeeAsync(employeeToDelete);
        }

        public async Task<List<EmployeeDTO>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return _mapper.Map<List<EmployeeDTO>>(await _employeeRepository.GetListAsync(cancellationToken));
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeToUpdateDTO employeeToUpdateDTO)
        {
            var employeeToUpdate = await _employeeRepository.GetAsync(x => x.EmployeeId == employeeToUpdateDTO.EmployeeId);
            if (employeeToUpdate is null)
            {
                throw new UserNotFoundException();
            }
            var employeeUpdated= await _employeeRepository.UpdateEmployeeAsync(_mapper.Map<Employee>(employeeToUpdateDTO));

            return _mapper.Map<EmployeeDTO>(employeeUpdated);
        }

        public DataSet ReadExcelFile(string filePath)
        {
            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    return reader.AsDataSet();
                }
            }
        }

        public async Task UploadEmployeeFromFileAsync(string filePath)
        {
            DataSet dataSet=ReadExcelFile(filePath);
            List<EmployeeToAddDTO>? list = null;
            if (dataSet.Tables.Count > 0)
            {
                list = new List<EmployeeToAddDTO>();
                var table = dataSet.Tables[0];
                var rows = table.AsEnumerable().Skip(1);
                foreach (DataRow row in rows)
                {
                    var employeeToAddDTO = new EmployeeToAddDTO()
                    {
                        EmployeeName = row["Column0"].ToString(),
                        DOB = DateOnly.ParseExact(row["Column1"].ToString(), "dd/mm/yyyy", CultureInfo.InvariantCulture),
                        Gender = row["Column2"].ToString(),
                        Email = row["Column3"].ToString(),
                        State = row["Column4"].ToString(),
                    };
                    list.Add(employeeToAddDTO);
                }
            }
            if (list is null)
            {
                throw new UserNotFoundException();
            }
            await _employeeRepository.UploadEmployeeFromFileAsync(_mapper.Map<List<Employee>>(list));
        }        
    }
}
