using System.Collections;
using System.Collections.Generic;
using Fridge.Model;
using Fridge.Services;
using UnityEngine;

namespace Fridge.View
{
    public interface IProductObject
    {
    }

    [Prefab("Elements/Products/Product")]
    public class ProductObject : Element<ProductComponent>, IProductObject
    {
        readonly Product product;

        public ProductObject(IServices services, IViews views, Transform parent, Product product) : base(services, views, parent)
        {
            this.product = product;
            
            AddListeners();
        }
        
        private void SetSprite()
        {
        }

        private void AddListeners()
        {
            component.button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            //go to different view
        }
    }
}

