using System;

namespace InfoSystem.App.DataBase.Interfaces
{
    public interface IMessage
    {
        Guid Sender { get; }
        Guid Addressee { get; }
        string Text { get; }
    }
}