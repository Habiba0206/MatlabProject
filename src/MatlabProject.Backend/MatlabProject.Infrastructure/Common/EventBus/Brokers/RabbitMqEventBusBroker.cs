﻿using MatlabProject.Application.Common.EventBus.Brokers;
using MatlabProject.Domain.Common.Events;
using MediatR;

namespace MatlabProject.Infrastructure.Common.EventBus.Brokers;

public class RabbitMqEventBusBroker(IPublisher publisher) : IEventBusBroker
{
    public async ValueTask PublishAsync<TEvent>(
        TEvent @event,
        CancellationToken cancellationToken = default)
        where TEvent : EventBase =>
    await publisher.Publish(@event, cancellationToken);

    public async ValueTask PublishLocalAsync<TEvent>(
        TEvent @event,
        CancellationToken cancellationToken = default)
        where TEvent : EventBase =>
    await publisher.Publish(@event, cancellationToken);
}
