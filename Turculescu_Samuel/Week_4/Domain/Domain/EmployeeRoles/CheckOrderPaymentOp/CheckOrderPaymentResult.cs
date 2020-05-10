﻿using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.EmployeeRoles.CheckOrderPaymentOp
{
    [AsChoice]
    public static partial class CheckOrderPaymentResult
    {        
        public interface ICheckOrderPaymentResult { }

        public class CheckOrderPaymentStatus : ICheckOrderPaymentResult
        {
            public PaymentStatus PaymentStatus { get; }

            public CheckOrderPaymentStatus(PaymentStatus paymentStatus)
            {
                PaymentStatus = paymentStatus;
            }
        }
    }
}
