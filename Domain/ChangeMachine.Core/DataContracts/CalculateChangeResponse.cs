using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Entities;

namespace ChangeMachine.Core.DataContracts {
    public class CalculateChangeResponse {


        public CalculateChangeResponse() {         
            this.CashDict = new Dictionary<string, int>();
            this.OperationReport = new OperationReport();
        }

        public Dictionary<string, int> CashDict { get; set; }
        public OperationReport OperationReport { get; set; }
        public bool Success { get; set; }

    }
}
