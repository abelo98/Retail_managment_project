using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<ProductModel> _products;
        private IProductEndpoint _productEndpoint;

        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;

        }

        protected async override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        public async Task LoadProducts()
        {
            var products = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(products);
        }

        public BindingList<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private ProductModel _slectedProduct;

        public ProductModel SelectedProduct
        {
            get { return _slectedProduct; }
            set
            {
                _slectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }


        private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();

        public BindingList<CartItemModel> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        public bool CanAddToCart
        {
            get
            {
                bool output = false;
                if (ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity)
                {
                    output = true;
                }
                return output;
            }
        }

        public void AddToCart()
        {
            var existingItem = Cart.FirstOrDefault(x => x.ProductModel == SelectedProduct);

            if (existingItem != null)
            {
                existingItem.QuantityInCart += ItemQuantity;

                //Hack - This should be change for somthing better.
                Cart.Remove(existingItem);
                Cart.Add(existingItem);
            }
            else
            {
                CartItemModel cartItem = new CartItemModel()
                {
                    ProductModel = SelectedProduct,
                    QuantityInCart = ItemQuantity
                };
                Cart.Add(cartItem);
            }

            SelectedProduct.QuantityInStock -= ItemQuantity;
            ItemQuantity = 1;
            NotifyOfPropertyChange(() => Subtotal);

        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;
                // Somthing is selected
                return output;
            }
        }


        private int _itemQuantity = 1;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        public string Subtotal
        {
            get
            {
                decimal subtotal = 0;
                foreach (var item in Cart)
                {
                    subtotal += (item.QuantityInCart * item.ProductModel.RetailPrice);
                }
                return subtotal.ToString("C");
            }
        }


        public string Tax
        {
            get
            {
                // TODO: replace for calculations
                return "$0.00";
            }
        }


        public string Total
        {
            get
            {
                // TODO: replace for calculations
                return "$0.00";
            }
        }

        public void RemoveFromCart()
        {
            NotifyOfPropertyChange(() => Subtotal);
        }

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
