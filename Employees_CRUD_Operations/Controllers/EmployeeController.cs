using AutoMapper;
using Employee_CRUD_Operations.BLL.IRepositories;
using Employee_CRUD_Operations.DAL.Models;
using Employees_CRUD_Operations.Helper;
using Employees_CRUD_Operations.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_CRUD_Operations.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public EmployeeController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<IActionResult> Index()
        {
            
                var employees = await _unitOfWork.Repository<Employees>().GetAllAsync();
                var employeesViewModel =
               _mapper.Map<IEnumerable<Employees>, IEnumerable<EmployeeModelView>>(employees);

                return View(employeesViewModel);
           

        }

        [HttpGet]
        public async Task<IActionResult> Details(string id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var employee = await _unitOfWork.Repository<Employees>().GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            return View(_mapper.Map<Employees, EmployeeModelView>(employee));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            return await Details(id , "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] string id, EmployeeModelView employee)
        {
            if (id != employee.Id)
                return BadRequest();
          

                var emp = _mapper.Map<EmployeeModelView, Employees>(employee);
                if (employee.FileImage != null)
                {
                  emp.ProfileImage = DocumentSettings.SettingUploadFiles(employee.FileImage, "Images");
                }
                
                emp.ModifiedDate = DateTime.Now;
                _unitOfWork.Repository<Employees>().Update(emp);
                return RedirectToAction(nameof(Index));
           
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<Departments> departments = await _unitOfWork.Repository<Departments>().GetAllAsync();
            ViewData["departments"] = departments.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeModelView employee)
        {
            
                employee.ProfileImage = DocumentSettings.SettingUploadFiles(employee.FileImage, "images");
                employee.CreatedDate = DateTime.Now;
                var emp = _mapper.Map<EmployeeModelView, Employees>(employee);
                 _unitOfWork.Repository<Employees>().Add(emp);
                return RedirectToAction("Index");
            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] string id, EmployeeModelView employee)
        {
            if (id != employee.Id)
                return BadRequest();
            var emp =  _unitOfWork.Repository<Employees>().GetByIdAsync(id).Result;
            DocumentSettings.DeleteFile(emp.ProfileImage, "images");
            _unitOfWork.Repository<Employees>().Delete(emp);

            return RedirectToAction("Index");
        }
    }
}
