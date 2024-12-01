using AutoMapper;
using LeaveManagement.Application.Contracts.Logging;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Exceptions;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

    public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<UpdateLeaveTypeCommandHandler> logger)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update request {0} - {1}", nameof(LeaveType), request.Id);
            throw new BadRequestException("Invalid leave type: " + validationResult.Errors);
        }

        var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

        await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
        
        return Unit.Value;
    }
}
