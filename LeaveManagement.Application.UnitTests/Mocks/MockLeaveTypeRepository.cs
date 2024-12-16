using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using Moq;

namespace LeaveManagement.Application.UnitTests.Mocks;

public class MockLeaveTypeRepository
{
    public static Mock<ILeaveTypeRepository> GetRepository()
    {
        var leaveTypes = new List<LeaveType>
        {
            new LeaveType { Id = 1, Name = "a", DefaultDays = 7 },
            new LeaveType { Id = 2, Name = "b", DefaultDays = 9 },
            new LeaveType { Id = 3, Name = "c", DefaultDays = 5 }
        };

        var mockRepo = new Mock<ILeaveTypeRepository>();

        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync((List<LeaveType>)leaveTypes);

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
        {
            leaveTypes.Add(leaveType);
            return leaveType;
        });

        return mockRepo;
    }
}