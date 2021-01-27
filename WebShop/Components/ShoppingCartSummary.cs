using System;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.ViewModels;

namespace WebShop.Components
{
    public class ShoppingCartSummary: ViewComponent
    {
        //avem nevoie de datele din shoppingcart
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        //metoda specifica pt view components
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }
    }
}
