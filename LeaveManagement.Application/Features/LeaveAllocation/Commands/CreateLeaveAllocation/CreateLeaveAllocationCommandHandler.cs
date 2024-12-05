using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Exceptions;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);

        var validationResult = validator.Validate(request);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Leave Allocation Request " + validationResult);
        }

        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

        var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);

        await _leaveAllocationRepository.CreateAsync(leaveAllocation);

        return Unit.Value;
    }
}
