using Challenge.Application.Commands;
using Challenge.Application.Handlers;
using Challenge.Domain.Bus;
using Challenge.Domain.Interfaces;
using Challenge.Domain.Notifications;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace Challenge.Tests;

public class NewsCacheHandlerTest
{
    private readonly DomainNotificationHandler _domainNotificationHandler;
    private readonly Mock<IMediatorHandler> _mockMediatorHandler;
    private readonly Mock<INewsCache> _mockNewHackCache;
    private readonly Mock<ILogger<NewsCacheHandler>> _mockNewHackLogger;
    private readonly Mock<INotificationHandler<DomainNotification>> _mockNotificationHandler;
    private readonly Mock<NewsCacheHandler> _newsCacheHandlerMock;

    private NewsCacheHandler _handler = null!;
    public NewsCacheHandlerTest()
    {
        _domainNotificationHandler = new DomainNotificationHandler();
        _mockMediatorHandler = new Mock<IMediatorHandler>();
        _mockNewHackCache = new Mock<INewsCache>();
        _mockNewHackLogger = new Mock<ILogger<NewsCacheHandler>>();
        _mockNotificationHandler = new Mock<INotificationHandler<DomainNotification>>();
        _newsCacheHandlerMock = new Mock<NewsCacheHandler>();

        _handler = new NewsCacheHandler(_mockNewHackCache.Object,
            _mockMediatorHandler.Object,
            _mockNewHackLogger.Object,
            _mockNotificationHandler.Object);
    }

    [Fact(DisplayName = "Delete news hack with success")]
    public async Task Delete_News_Hack_With_Success()
    {
        var command = new DeleteNewsCache(1);

        var result = _newsCacheHandlerMock.Setup(x => x.Handle(command, default(CancellationToken))).ReturnsAsync(false);

        result.Should().Be(true);
    }

    [Fact(DisplayName = "Delete news hack with error")]
    public async Task Delete_News_Hack_With_Error()
    {
        var command = new DeleteNewsCache(2);

        var result = _newsCacheHandlerMock.Setup(x => x.Handle(command, default(CancellationToken))).ReturnsAsync(false);

        result.Should().Be(false);
    }

    [Fact(DisplayName = "Delete news hack with error Null")]
    public async Task Delete_News_Hack_With_Error_Null()
    {
        var command = new DeleteNewsCache(2);

        var result = _newsCacheHandlerMock.Setup(x => x.Handle(command, default(CancellationToken))).ReturnsAsync(false);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "Insert news hack with success")]
    public async Task Insert_News_Hack_With_Success()
    {
        var command = new DeleteNewsCache(1);

        var result = _newsCacheHandlerMock.Setup(x => x.Handle(command, default(CancellationToken))).ReturnsAsync(false);

        result.Should().Be(true);
    }

    [Fact(DisplayName = "Insert news hack with error")]
    public async Task Insert_News_Hack_With_Error()
    {
        var command = new DeleteNewsCache(2);

        var result = _newsCacheHandlerMock.Setup(x => x.Handle(command, default(CancellationToken))).ReturnsAsync(false);

        result.Should().Be(false);
    }

    [Fact(DisplayName = "Insert news hack with error Null")]
    public async Task Insert_News_Hack_With_Error_Null()
    {
        var command = new DeleteNewsCache(2);

        var result = _newsCacheHandlerMock.Setup(x => x.Handle(command, default(CancellationToken))).ReturnsAsync(false);

        Assert.NotNull(result);
    }
}
