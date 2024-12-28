using LeaveManagement.Application.Contracts.Identity;
using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Models.Identity;
using LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace LeaveManagement.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Employee> GetEmployee(string userId)
    {
        var employee = await _userManager.FindByIdAsync(userId);

        if (employee == null) throw new NotFoundException("User not found {id}", userId);

        return new Employee
        {
            Email = employee.Email,
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
        };
    }

    public async Task<List<Employee>> GetEmployees()
    {
        var employees = await _userManager.GetUsersInRoleAsync("Employee");

        return employees.Select(q => new Employee
        {
            Id = q.Id,
            FirstName = q.FirstName,
            LastName = q.LastName,
            Email = q.Email,
        }).ToList();
    }
}
