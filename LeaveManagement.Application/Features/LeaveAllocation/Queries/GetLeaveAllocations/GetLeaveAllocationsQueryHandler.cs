using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class GetLeaveAllocationsQueryHandler : IRequestHandler<GetLeaveAllocationsQuery, List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationsQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();

        var dto = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

        return dto;
    }
}
