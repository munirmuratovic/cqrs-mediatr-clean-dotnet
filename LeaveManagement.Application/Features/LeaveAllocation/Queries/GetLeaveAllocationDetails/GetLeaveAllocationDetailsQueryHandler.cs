using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationDetailsQueryHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, LeaveAllocationDetailsDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationDetailsQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }
    public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveTypeDetails = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

        var dto = _mapper.Map<LeaveAllocationDetailsDto>(leaveTypeDetails);

        return dto;
    }
}
