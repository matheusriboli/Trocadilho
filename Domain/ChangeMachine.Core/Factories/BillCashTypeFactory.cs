using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Entities;

namespace ChangeMachine.Core.Factories {
    class BillCashTypeFactory {
        public static CashType GetCashType() {
            var cashType = new CashType();
            cashType.Name = "Bill";
            cashType.Itens.Add(new CashItem() { AmountInCents = 10000, Description = "100 Bill" });
            cashType.Itens.Add(new CashItem() { AmountInCents = 5000, Description = "50 Bill" });            
            cashType.Itens.Add(new CashItem() { AmountInCents = 2000, Description = "20 Bill" });
            cashType.Itens.Add(new CashItem() { AmountInCents = 1000, Description = "10 Bill" });
            cashType.Itens.Add(new CashItem() { AmountInCents = 500, Description = "5 Bill" });
            cashType.Itens.Add(new CashItem() { AmountInCents = 200, Description = "2 Bill" });
            return cashType;
        }
    }
}
