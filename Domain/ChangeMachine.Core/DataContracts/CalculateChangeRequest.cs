using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.DataContracts {
    public class CalculateChangeRequest {

        public int DueValue { get; set; }
        public int PaidValue { get; set; }

    }
}
