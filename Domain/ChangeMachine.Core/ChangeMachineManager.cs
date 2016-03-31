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


            if (request.PaidValue == 0 || request.DueValue == 0)
                return new CalculateChangeResponse("Valor informado invalido");

            int valuesDifference = request.PaidValue - request.DueValue;

            if (valuesDifference == 0)
                return new CalculateChangeResponse();

            CalculateChangeResponse response = new CalculateChangeResponse();
            Dictionary<CoinEnum, int> coinDict = new Dictionary<CoinEnum, int>();

            foreach (var coin in this.GenerateCoinsDesc()) {
                int coinQtt = valuesDifference / (int)coin;
                valuesDifference = valuesDifference % (int)coin;
                if(coinQtt != 0) 
                    coinDict.Add(coin, coinQtt);

                if (valuesDifference == 0) {
                    break;
                }
            }
            response.CoinDict = coinDict;

            return response;
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
