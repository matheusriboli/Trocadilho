using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.DataContracts;
using ChangeMachine.Core.Entities;

namespace ChangeMachine.Core {
    public class ChangeMachineManager {

        public CalculateChangeResponse CalculateChange(CalculateChangeRequest request) {
            // TODO logar request
            try {
                request.Validate();
                if (!request.ValuesAreValid) {
                    return new CalculateChangeResponse() {
                        OperationReport = request.OperationReport,
                        Success = false
                    };
                }
                int valuesDifference = request.PaidValue - request.ProductValue;

                if (valuesDifference == 0)
                    return new CalculateChangeResponse() {
                        Success = true
                    };

                CalculateChangeResponse response = new CalculateChangeResponse();
                Dictionary<CoinEnum, int> coinDict = new Dictionary<CoinEnum, int>();

                foreach (var coin in this.GenerateCoinsDesc()) {
                    int coinQtt = valuesDifference / (int)coin;
                    valuesDifference = valuesDifference % (int)coin;
                    if (coinQtt != 0)
                        coinDict.Add(coin, coinQtt);

                    if (valuesDifference == 0) {
                        break;
                    }
                }
                response.CoinDict = coinDict;
                response.Success = true;
                // TODO logar a resposta
                return response;                
            }
            catch (Exception e) {
                // TODO logar exception
                var response =new CalculateChangeResponse() {
                    Success = false
                };
                response.OperationReport.Messages.Add(e.Message);
                return response;
            }
            
        }


        private List<CoinEnum> GenerateCoinsDesc() {
            var coins = new List<CoinEnum>() {
                CoinEnum.OneReal,
                CoinEnum.FiftyCents,
                CoinEnum.TwentyFiveCents,
                CoinEnum.TenCents,
                CoinEnum.FiveCents,
                CoinEnum.OneCent
            };

            return coins;
        }

    }
}
