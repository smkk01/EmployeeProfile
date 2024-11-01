using Microsoft.AspNetCore.Mvc;
using EmployeeProfile.Data;
using EmployeeProfile.Model;
using Microsoft.EntityFrameworkCore;
namespace EmployeeProfile.Controllers
{
    
    public class EmployeeController : Controller
    {
        private readonly HrdbContext _context;
        public EmployeeController(HrdbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                var emplist = from emp in _context.Employees
                              join d in _context.Departments
                              on emp.DeptId equals d.DeptId
                              into Dept
                              from d in Dept.DefaultIfEmpty()
                              select new Employee
                              {
                                  EmpId = emp.EmpId,
                                  EmpName = emp.EmpName,
                                  Age = emp.Age,
                                  Gender = emp.Gender,
                                  Mobile = emp.Mobile,
                                  Salary = emp.Salary,
                                  DeptId = emp.DeptId,
                                  Department = d == null? "" : d.Department1
                              };
                return View(emplist);
            }
            catch (Exception)
            {

                return View();
            }

            
        }

        public async Task<IActionResult> Create(int id)
        {
            ViewBag.Department =await _context.Departments.ToListAsync();
            var emp = _context.Employees.Where(X=>X.EmpId == id).FirstOrDefault();
            return View(emp);
        }
        public async Task<IActionResult> Save(Employee emp)
        {
            try
            {
                ModelState.Remove("EmpId");
                if (ModelState.IsValid)
                {
                    if (emp.EmpId == 0)
                    {
                        _context.Employees.Add(emp);
                        await _context.SaveChangesAsync();
                        ModelState.Clear();
                        TempData["success"] = "Employee Added Successfully";
                    }
                    else
                    {
                        _context.Entry(emp).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        ModelState.Clear();
                        TempData["success"] = "Employee updated Successfully";
                    }
                    return RedirectToAction("Index");
                }


                return View("Create");
            }
            catch (Exception)
            {
                  
                throw;
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var employee =await _context.Employees.FindAsync(id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Employee Deleted Successfully";
                    return RedirectToAction("Index");
                }
                return NotFound ();
            }
            catch (Exception)
            {

                return RedirectToAction("Index"); 
            }

            return View();
        }
    }
}
