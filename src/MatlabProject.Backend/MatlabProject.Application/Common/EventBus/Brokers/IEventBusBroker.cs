using MatlabProject.Domain.Common.Events;

namespace MatlabProject.Application.Common.EventBus.Brokers;

public interface IEventBusBroker
{
    ValueTask PublishLocalAsync<TEvent>(
        TEvent @event,
        CancellationToken cancellationToken = default)
        where TEvent : EventBase;

    ValueTask PublishAsync<TEvent>(
        TEvent @event,
        CancellationToken cancellationToken = default)
        where TEvent : EventBase;
}
