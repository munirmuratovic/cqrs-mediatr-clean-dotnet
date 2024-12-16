using AutoMapper;
using LeaveManagement.Application.Contracts.Logging;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using LeaveManagement.Application.MappingProfiles;
using LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace LeaveManagement.Application.UnitTests.Features.LeaveTypes.Queries;

public class GetLeaveTypesQueryHandlerTests
{
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private IMapper _mapper;
    private Mock<IAppLogger<GetLeaveTypesQueryHandler>> _mockLogger;

    public GetLeaveTypesQueryHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepository.GetRepository();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<LeaveTypeProfile>();
        });

        _mapper = mapperConfig.CreateMapper();

        _mockLogger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>();
    }

    [Fact]
    public async Task GetLeaveTypesTest()
    {
        // Arrange
        var handler = new GetLeaveTypesQueryHandler(_mapper, _mockRepo.Object, _mockLogger.Object);

        // Act
        var result = await handler.Handle(new GetLeaveTypesQuery(), CancellationToken.None);

        // Assert
        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count.ShouldBe(3);
    }
}
