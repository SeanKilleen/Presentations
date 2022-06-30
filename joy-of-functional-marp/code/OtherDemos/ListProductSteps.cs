using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ProductionCode;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace OtherDemos
{
    [Binding]
    public class ListProductSteps
    {
        private List<Product> _products;
        private VendingMachine vm;
        private int productCount;
        private List<Product> currentProducts;


        [Given(@"I have the following products:")]
        public void GivenIHaveTheFollowingProducts(Table table)
        {
            _products = table.CreateSet<Product>().ToList();
        }

        [Given(@"I am at the vending machine with the products")]
        public void GivenIAmAtTheVendingMachineWithTheProducts()
        {
            vm = new VendingMachine(_products);
        }

        [When(@"I get the product count")]
        public void WhenIGetTheProductCount()
        {
            productCount = vm.GetProductCount();
        }

        [Then(@"the product count should be (.*)")]
        public void ThenTheProductCountShouldBe(int amount)
        {
            Assert.That(productCount, Is.EqualTo(amount));
        }

        [When(@"I get the current products")]
        public void WhenIGetTheCurrentProducts()
        {
            currentProducts = vm.GetCurrentProducts();
        }

        [Then(@"the products should include (.*)")]
        public void ThenTheProductsShouldInclude(string productName)
        {
            var containsName = _products.Any(x => x.Name == productName);
            Assert.That(containsName, Is.True);
        }

        [Then(@"the products should not include (.*)")]
        public void ThenTheProductsShouldNotInclude(string productName)
        {
            var containsName = _products.Any(x => x.Name == productName);
            Assert.That(containsName, Is.False);
        }



    }
}
