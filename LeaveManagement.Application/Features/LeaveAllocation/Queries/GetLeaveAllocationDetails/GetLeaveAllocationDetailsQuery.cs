using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public record GetLeaveAllocationDetailsQuery(int Id) : IRequest<LeaveAllocationDetailsDto>;
