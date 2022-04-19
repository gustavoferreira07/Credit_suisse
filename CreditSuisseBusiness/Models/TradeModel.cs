using CreditSuisseBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisseBusiness.Models
{
    public class TradeModel
    {
        public double Value { get; set; }

        public string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }
        public DateTime ReferenceDate { get; set; }

    }
}
