using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Entities;

namespace ChangeMachine.Core.Processors {
    public interface IProcessor {

        Tuple<int, Dictionary<string, int>> CalculateChange(int value, CashType cashType);
    }
}
