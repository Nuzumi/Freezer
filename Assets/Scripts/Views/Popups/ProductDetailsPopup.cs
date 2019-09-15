using Fridge.Model;
using Fridge.Services;
using Fridge.View;
using UnityEngine;

namespace Fridge.Popup
{
    [Prefab("Popup/ProductDetailsPopup/ProductDetailsPopup")]
    public class ProductDetailsPopup : Popup<ProductDetailsPopupComponent>
    {
        private ProductDetail Product;

        public ProductDetailsPopup(IServices services, IViews views) : base(services, views) { }

        public void Show(ProductDetail product)
        {
            Product = product;
            SetText();
            Services.FoodSpriteService.GetSprite(Product, SetSprite);

            Show();
        }

        private void SetText()
        {
            component.dataDodania.text = Product.buyDate.ToShortDateString();
            component.dataWaznosci.text = Product.expiryDate.ToShortDateString();
        }

        private void SetSprite(Sprite sprite)
        {
            component.image.sprite = sprite;
        }
        
        protected override void OnPopupHidden()
        {
            
        }

        protected override void OnPopupShown()
        {
        }
    }
}
