﻿using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.Banking.Domain.Events;

public class TransfercreatedEvent : Event
{
    public TransfercreatedEvent(int from, int to, decimal amount)
    {
        From = from;
        To = to;
        Amount = amount;
    }

    public int From { get; private set; }
    public int To { get; private set; }
    public decimal Amount { get; private set; }
}