using System;

namespace InfoSystem.Infrastructure.Interfaces
{
    public interface IMessage
    {
        Guid Sender { get; }
        Guid Addressee { get; }
        string Text { get; }
    }
}