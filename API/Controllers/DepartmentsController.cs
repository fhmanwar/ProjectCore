using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseController<Department, DepartmentRepo>
    {
        readonly DepartmentRepo _departRepo;
        public DepartmentsController(DepartmentRepo departmentRepo) : base(departmentRepo)
        {
            _departRepo = departmentRepo;
        }
    }
}
