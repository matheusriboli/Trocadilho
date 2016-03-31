using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Entities;

namespace ChangeMachine.Core.DataContracts {
    public class CalculateChangeResponse {


        public CalculateChangeResponse() {
            this.FlagError = false;
            this.CoinDict = new Dictionary<CoinEnum, int>();
        }

        public CalculateChangeResponse(string messageErrorReturn) {
            this.MessageErrorReturn = messageErrorReturn;
            this.FlagError = true;
        }


        public Dictionary<CoinEnum, int> CoinDict { get; set; }
        public string MessageErrorReturn { get; set; }
        public bool FlagError { get; set; }

    }
}
