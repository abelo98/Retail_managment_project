using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
    public class SalesViewModel:Screen
    {
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get { return _products; }
            set
            {
                _products = value; 
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        private string _subtotal;

        public string Subtotal
        {
            get
            {
                // TODO: replace for calculations
                return "$0.00";
            }
        }

        private string _tax;

        public string Tax
        {
            get
            {
                // TODO: replace for calculations
                return "$0.00";
            }
        }

        private string _total;

        public string Total
        {
            get
            {
                // TODO: replace for calculations
                return "$0.00";
            }
        }


        public bool CanAddToCart
        {
            get
            {
                bool output = false;
                // Somthing is selected
                // There is the qty of the product
                return output;
            }
        }

        public void AddToCart() { }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;
                // Somthing is selected
                return output;
            }
        }

        public void RemoveFromCart() { }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;
                // Somthing is selected in the cart
                return output;
            }
        }

        public void CheckOut() { }

    }
}
