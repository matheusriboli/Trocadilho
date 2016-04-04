using System;
using System.Linq;
using ChangeMachine.Core.DataContracts;
using ChangeMachine.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChangeMachine.Core.Test {
    [TestClass]
    public class ChangeMachineManagerTest {
        [TestMethod]
        public void CalcChangeFromZeroCents() {


            var request = new CalculateChangeRequest();

            request.PaidValue = 0;
            request.ProductValue = 0;

            ChangeMachineManager changeMachineManager = new ChangeMachineManager();
            var response = changeMachineManager.CalculateChange(request);

            Assert.IsFalse(response.Success);
        }

        [TestMethod]
        public void NoChange() {


            var request = new CalculateChangeRequest();

            request.PaidValue = 100;
            request.ProductValue = 100;

            ChangeMachineManager changeMachineManager = new ChangeMachineManager();
            var response = changeMachineManager.CalculateChange(request);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(0, response.CashDict.Count);
        }

        [TestMethod]
        public void CalcChangeFromOneReal() {


            var request = new CalculateChangeRequest();

            request.PaidValue = 200;
            request.ProductValue = 100;

            ChangeMachineManager changeMachineManager = new ChangeMachineManager();
            var response = changeMachineManager.CalculateChange(request);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.CashDict.Count);
            Assert.AreEqual(1, response.CashDict["1"]);
        }

        [TestMethod]
        public void SingleCoin() {


            var request = new CalculateChangeRequest();

            request.PaidValue = 150;
            request.ProductValue = 100;

            ChangeMachineManager changeMachineManager = new ChangeMachineManager();
            var response = changeMachineManager.CalculateChange(request);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.CashDict.Count);
            Assert.AreEqual(1, response.CashDict["50 Cents"]); //[Entities.CoinEnum.FiftyCents]);
        }

        [TestMethod]
        public void CalculateChangeDifficult() {


            var request = new CalculateChangeRequest();

            request.PaidValue = 78598;
            request.ProductValue = 100;

            ChangeMachineManager changeMachineManager = new ChangeMachineManager();
            var response = changeMachineManager.CalculateChange(request);
            
            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.CashDict["500 Silver Bar"]);
            Assert.AreEqual(1, response.CashDict["250 Silver Bar"]);
            Assert.AreEqual(1, response.CashDict["20 Bill"]);
            Assert.AreEqual(1, response.CashDict["10 Bill"]);
            Assert.AreEqual(2, response.CashDict["2 Bill"]);
            Assert.AreEqual(1, response.CashDict["50 Cents"]);
            Assert.AreEqual(1, response.CashDict["25 Cents"]);
            Assert.AreEqual(2, response.CashDict["10 Cents"]);
            Assert.AreEqual(1, response.CashDict["3 Cents Candy"]);
        }


    }
}
