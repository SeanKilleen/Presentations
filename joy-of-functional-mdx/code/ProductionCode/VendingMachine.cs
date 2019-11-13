using System;

namespace ProductionCode
{
    public class VendingMachine
    {
        private int _insertedChange;

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
    }
}
