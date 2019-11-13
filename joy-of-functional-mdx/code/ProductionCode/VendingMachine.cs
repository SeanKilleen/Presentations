using System;
using System.Collections.Generic;

namespace ProductionCode
{
    public class VendingMachine
    {
        private int _insertedChange;
        private List<Product> _products;
        public VendingMachine() { }

        public VendingMachine(List<Product> products)
        {
            _products = products;
        }

        public int GetProductCount()
        {
            return _products.Count;
        }

        public void Add(int cents)
        {
            _insertedChange += cents;
        }

        public Product PurchaseProduct()
        {
            if (_insertedChange >= 50)
            {
                _insertedChange -= 50;
                return new Product();
            }

            return null;
        }

        public List<Product> GetCurrentProducts()
        {
            return _products;
        }
    }
}
