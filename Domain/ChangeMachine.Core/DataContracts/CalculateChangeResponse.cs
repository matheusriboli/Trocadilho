using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Entities;

namespace ChangeMachine.Core.DataContracts {
    public class CalculateChangeResponse {


        public CalculateChangeResponse() {         
            this.CoinDict = new Dictionary<CoinEnum, int>();
            this.OperationReport = new OperationReport();
        }

        public Dictionary<CoinEnum, int> CoinDict { get; set; }
        public OperationReport OperationReport { get; set; }
        public bool Success { get; set; }

    }
}
