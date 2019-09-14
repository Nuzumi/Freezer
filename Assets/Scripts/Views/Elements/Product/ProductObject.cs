using System.Collections;
using System.Collections.Generic;
using Fridge.Model;
using Fridge.Services;
using UnityEngine;

namespace Fridge.View
{
    public interface IProductObject
    {
        void SetProduct(ProductDetail productDetail);
    }

    public class ProductObject : Element<ProductComponent>, IProductObject
    {
        protected ProductObject(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
            SetBorderActive(false);
        }

        public void SetBorderActive(bool active)
        {
            var color = component.borderImage.color;
            component.borderImage.color = new Color(color.r, color.g, color.b, active ? 1 : 0);
        }

        public void SetBorderColor(Color color)
        {
            component.borderImage.color = color;
        }

        public void SetProduct(ProductDetail productDetail)
        {
            throw new System.NotImplementedException();
        }

        public void SetSprite(Sprite sprite)
        {
            throw new System.NotImplementedException();
        }
    }
}

