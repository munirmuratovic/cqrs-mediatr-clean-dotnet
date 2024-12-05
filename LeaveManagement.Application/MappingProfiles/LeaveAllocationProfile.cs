using AutoMapper;
using LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using LeaveManagement.Domain;

namespace LeaveManagement.Application.MappingProfiles;

public class LeaveAllocationProfile : Profile
{
    public LeaveAllocationProfile()
    {
        CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
        CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
        CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
    }
}
