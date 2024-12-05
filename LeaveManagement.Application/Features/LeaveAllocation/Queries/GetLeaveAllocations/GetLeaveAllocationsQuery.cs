using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public record GetLeaveAllocationsQuery : IRequest<List<LeaveAllocationDto>>;
