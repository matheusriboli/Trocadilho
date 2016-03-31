using System;
using ChangeMachine.Core.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChangeMachine.Core.Test {
    [TestClass]
    public class ChangeMachineManagerTest {
        [TestMethod]
        public void CalcChangeFromZeroCents() {


            var request = new CalculateChangeRequest();

            request.PaidValue = 0;
            request.DueValue = 0;

            ChangeMachineManager changeMachineManager = new ChangeMachineManager();
            var response = changeMachineManager.CalculateChange(request);

            Assert.IsTrue(response.FlagError);
        }

        [TestMethod]
        public void NoChange() {


            var request = new CalculateChangeRequest();

            request.PaidValue = 100;
            request.DueValue = 100;

            ChangeMachineManager changeMachineManager = new ChangeMachineManager();
            var response = changeMachineManager.CalculateChange(request);

            Assert.IsFalse(response.FlagError);
            Assert.AreEqual(0, response.CoinDict.Count);
        }

        [TestMethod]
        public void CalcChangeFromOneReal() {


            var request = new CalculateChangeRequest();

            request.PaidValue = 200;
            request.DueValue = 100;

            ChangeMachineManager changeMachineManager = new ChangeMachineManager();
            var response = changeMachineManager.CalculateChange(request);

            Assert.IsFalse(response.FlagError);
            Assert.AreEqual(1, response.CoinDict.Count);
            Assert.AreEqual(1, response.CoinDict[Entities.CoinEnum.OneReal]);
        }

        [TestMethod]
        public void divZero() {


            var request = new CalculateChangeRequest();

            request.PaidValue = 150;
            request.DueValue = 100;

            ChangeMachineManager changeMachineManager = new ChangeMachineManager();
            var response = changeMachineManager.CalculateChange(request);

            Assert.IsFalse(response.FlagError);
            Assert.AreEqual(1, response.CoinDict.Count);
            Assert.AreEqual(1, response.CoinDict[Entities.CoinEnum.FiftyCents]);
        }

        [TestMethod]
        public void CalculateChangeDifficult() {


            var request = new CalculateChangeRequest();

            request.PaidValue = 78598;
            request.DueValue = 100;

            ChangeMachineManager changeMachineManager = new ChangeMachineManager();
            var response = changeMachineManager.CalculateChange(request);

            Assert.IsFalse(response.FlagError);
            Assert.AreEqual(784, response.CoinDict[Entities.CoinEnum.OneReal]);
            Assert.AreEqual(1, response.CoinDict[Entities.CoinEnum.FiftyCents]);
            Assert.AreEqual(1, response.CoinDict[Entities.CoinEnum.TwentyFiveCents]);
            Assert.AreEqual(2, response.CoinDict[Entities.CoinEnum.TenCents]);
            Assert.AreEqual(3, response.CoinDict[Entities.CoinEnum.OneCent]);
        }


    }
}
