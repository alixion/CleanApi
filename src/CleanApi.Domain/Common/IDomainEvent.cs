using System;
using MediatR;

namespace CleanApi.Domain.Common
{
    public interface IDomainEvent:INotification
    {
        Guid Id { get; }
        DateTime OccurredOn { get; }
    }
}
