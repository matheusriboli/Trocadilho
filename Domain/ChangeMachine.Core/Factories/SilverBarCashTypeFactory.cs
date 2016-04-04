using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Entities;

namespace ChangeMachine.Core.Factories {
    class SilverBarCashTypeFactory {
        public static CashType GetCashType() {
            var cashType = new CashType();
            cashType.Name = "Silver Bar";
            cashType.Itens.Add(new CashItem() { AmountInCents = 100000, Description = "1000 Silver Bar" });
            cashType.Itens.Add(new CashItem() { AmountInCents = 50000, Description = "500 Silver Bar" });
            cashType.Itens.Add(new CashItem() { AmountInCents = 25000, Description = "250 Silver Bar" });                        
            return cashType;
        }
    }
}
