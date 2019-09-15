using Fridge.Controller;
using Fridge.Popup;
using Fridge.Services;
using Fridge.View;

namespace Fridge.View
{
    public interface IPopups
    {
        void CreatePopups();
        ProductDetailsPopup ProductDetailsPopup { get; }
    }

    public class Popups : IPopups
    {
        readonly IViews Views;
        readonly IServices Services;

        public ProductDetailsPopup ProductDetailsPopup { get; set; }

        public Popups(IServices services, IViews views ){
            Views = views;
            Services = services;

            CreatePopups();
        }

        public void CreatePopups()
        {
            ProductDetailsPopup = new ProductDetailsPopup(Services, Views);
        }
    }
}