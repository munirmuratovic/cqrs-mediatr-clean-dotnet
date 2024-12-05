using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public record CreateLeaveAllocationCommand(int LeaveTypeId) : IRequest<Unit>;
