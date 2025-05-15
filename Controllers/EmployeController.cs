using EmployeAdminPortal.Data;
using EmployeAdminPortal.Models;
using EmployeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeAdminPortal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployes()
        {
           var allemployes =  dbContext.Employes.ToList();

            return Ok(allemployes); // Retorna 200 OK
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeById(Guid id)
        {
            var employe = dbContext.Employes.Find(id);
            if (employe == null)
                return NotFound(); // Retorna 404 Caso não exista

            return Ok(employe); // Retorna 200 OK
        }


        [HttpPost]
        public IActionResult PostEmploye(AddEmployeDTO addEmployeDTO)
        {
            var employeEntity = new Employe()
            {
                Name = addEmployeDTO.Name,
                Email = addEmployeDTO.Email,
                Phone = addEmployeDTO.Phone,
                Salary = addEmployeDTO.Salary

            };

            dbContext.Employes.Add(employeEntity);
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetEmployeById), new { id = employeEntity.Id }, employeEntity); // Retorna 201 Created


        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmploy (Guid id, UpdateEmployeDTO updateEmployDto)
        {
            var employ = dbContext.Employes.Find(id);

            if(employ is null)
            {
                return NotFound();  // Retorna 404 caso não exista
            }

            employ.Email = updateEmployDto.Email;

            employ.Phone = updateEmployDto.Phone;

            employ.Salary = updateEmployDto.Salary;

            dbContext.SaveChanges();

            return Ok(employ); // Retorna 200 OK

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmploy(Guid id)
        {
            var employ = dbContext.Employes.Find(id);

            if (employ is null)
            {
                return NotFound(); // Retorna 404 caso não exista
            }

            dbContext.Employes.Remove(employ);
            dbContext.SaveChanges();

            return NoContent(); // Retorna 204 No Content 
        }
    }
}
