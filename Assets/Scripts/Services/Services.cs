using Fridge.Controller;
using Fridge.Popup;
using Fridge.View;

namespace Fridge.Services
{
    public interface IServices
    {
        void Init(IReferences references, IViews views);

        IPrefabFactory PrefabFactory { get; }
        IJsonService JsonService { get; }
        IHTTPService HTTPService { get; }
        IFoodSpriteService FoodSpriteService { get; }
    }

    public class Services : IServices
    {
        private IViews Views;

        public IPrefabFactory PrefabFactory { get; set; }
        public IJsonService JsonService { get; set; }
        public IHTTPService HTTPService { get; set; }
        public IFoodSpriteService FoodSpriteService { get; set; }

        public void Init(IReferences references, IViews views)
        {
            Views = views;

            PrefabFactory = new PrefabFactory(this, references.PrefabReferences);
            JsonService = new JsonService(references, this);
            HTTPService = new HTTPService(references, this);
            FoodSpriteService = new FoodSpriteService(references, this);
        }
    }
}