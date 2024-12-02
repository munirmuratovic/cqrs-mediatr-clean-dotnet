using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        return await _context.LeaveAllocations
            .AnyAsync(x => x.EmployeeId == userId
                && x.LeaveTypeId == leaveTypeId
                && x.Period == period);
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        return await _context.LeaveAllocations
            .Include(x => x.LeaveType)
            .ToListAsync();
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
    {
        return await _context.LeaveAllocations
            .Where(x => x.EmployeeId == userId)
            .Include(x => x.LeaveType)
            .ToListAsync();
    }

    public async Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int id)
    {
        return await _context.LeaveAllocations
            .Include (x => x.LeaveType)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<LeaveAllocation?> GetUserAllocations(string userId, int leaveTypeId)
    {
        return await _context.LeaveAllocations
            .FirstOrDefaultAsync(x => x.EmployeeId == userId && x.LeaveTypeId == leaveTypeId);
    }
}
