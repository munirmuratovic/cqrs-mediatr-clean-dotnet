using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;

public record DeleteLeaveAllocationCommand(int Id) : IRequest<Unit>;