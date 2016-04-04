using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Entities;

namespace ChangeMachine.Core.Factories {
    class CandyCashTypeFactory {

        public static CashType GetCashType() {
            var cashType = new CashType();
            cashType.Name = "Candy";
            cashType.Itens.Add(new CashItem() { AmountInCents = 3, Description = "3 Cents Candy" });
            cashType.Itens.Add(new CashItem() { AmountInCents = 1, Description = "1 Cent Candy" });
            return cashType;
        }
        
    }
}
