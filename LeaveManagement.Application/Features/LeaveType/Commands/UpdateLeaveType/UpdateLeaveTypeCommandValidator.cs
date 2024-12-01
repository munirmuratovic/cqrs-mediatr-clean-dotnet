using FluentValidation;
using LeaveManagement.Application.Contracts.Persistence;

namespace LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(LeaveTypeMustExist);

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName must have less than 70 characters.");

        RuleFor(p => p.DefaultDays)
            .GreaterThan(100).WithMessage("Cannot exceed 100")
            .LessThan(1).WithMessage("Cannot be less than 1");

        RuleFor(q => q)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("Leave type already exists.");

        _leaveTypeRepository = leaveTypeRepository;
    }

    private async Task<bool> LeaveTypeMustExist(int id, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
        return leaveType != null;
    }

    private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken cancellationToken)
    {
        return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}
