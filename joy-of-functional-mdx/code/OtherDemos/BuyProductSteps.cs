using NUnit.Framework;
using ProductionCode;
using TechTalk.SpecFlow;

namespace OtherDemos
{
    [Binding]
    public class VendingMachineProductSteps
    {
        private VendingMachine vm;
        private Product product;

        [Given(@"I am at the vending machine")]
        public void GivenIAmAtTheVendingMachine()
        {
            vm = new VendingMachine();
        }

        [When(@"I insert a quarter")]
        public void WhenIInsertAQuarter()
        {
            vm.Add(25);
        }

        [When(@"I purchase a product")]
        public void WhenIPurchaseAProduct()
        {
            product = vm.PurchaseProduct();
        }

        [Then(@"I should receive the product")]
        public void ThenIShouldReceiveTheProduct()
        {
            Assert.That(product, Is.Not.Null);
        }
    }
}
