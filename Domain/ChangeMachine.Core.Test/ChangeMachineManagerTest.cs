using System;
using System.Linq;
using ChangeMachine.Core.DataContracts;
using ChangeMachine.Core.Utilities;
using ChangeMachine.Core.Entities;
using Dlp.Framework.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChangeMachine.Core.Processors;
using System.Collections.Generic;

namespace ChangeMachine.Core.Test {
    [TestClass]
    public class ChangeMachineManagerTest {

        [TestInitialize]
        public void Initialize() {
            IocFactory.Reset();
            IocFactory.Register(
                Component.For<ILogger>().ImplementedBy<StubLogger>("Event_viewer"),
                Component.For<ILogger>().ImplementedBy<StubLogger>("Log_file")
                );
        }

        [TestMethod]
        public void CalcChangeFromZeroCents() {


            var request = new CalculateChangeRequest();

            request.PaidValue = 0;
            request.ProductValue = 0;

            ChangeMachineManager changeMachineManager = new ChangeMachineManager();
            var response = changeMachineManager.CalculateChange(request);

            Assert.IsFalse(response.Success);
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.OperationReport.StatusCode);
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

        [TestMethod]
        public void TestProcessorFail() {
            IocFactory.Register(
                Component.For<IProcessor>().ImplementedBy<StubProcessor>()
                );
            var request = new CalculateChangeRequest();

            request.PaidValue = 78598;
            request.ProductValue = 13;

            ChangeMachineManager changeMachineManager = new ChangeMachineManager();
            CalculateChangeResponse response = changeMachineManager.CalculateChange(request);
            Assert.IsFalse(response.Success);
            Assert.IsNotNull(response.OperationReport.Messages);
            Assert.IsTrue(response.OperationReport.Messages.Any());
            Assert.IsNotNull(response.OperationReport.Messages.First());
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.OperationReport.StatusCode);


        }


        [TestMethod]
        public void ValidaRequestTest() {
            //PrivateObject privateObject = new PrivateObject(typeof(CalculateChangeRequest));
            PrivateObject privateObject = new PrivateObject(new CalculateChangeRequest());
            privateObject.Invoke("Validate");
        }
    }
}
