﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FirstService.Repository.Implementations
{
    public interface SubmitOrder
    {
        string OrderId { get; }
    }

    public interface OrderAccepted
    {
        string OrderId { get; }
    }

    public interface IPubSub
    {
        string Message { get; set; }
    }
    public class PubSub : IPubSub
    {
        public string Message { get; set; }
    }
}
