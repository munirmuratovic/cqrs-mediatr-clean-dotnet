using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;
