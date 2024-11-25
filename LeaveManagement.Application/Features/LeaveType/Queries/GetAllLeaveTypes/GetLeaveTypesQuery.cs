using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;
