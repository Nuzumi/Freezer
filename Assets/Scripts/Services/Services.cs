using Fridge.Controller;

namespace Fridge.Services
{
    public interface IServices
    {
        void Init(IReferences references);

        IPrefabFactory PrefabFactory { get; }
        IJsonService JsonService { get; }
        IHTTPService HTTPService { get; }
    }

    public class Services : IServices
    {
        public IPrefabFactory PrefabFactory { get; set; }
        public IJsonService JsonService { get; set; }
        public IHTTPService HTTPService { get; set; }

        public void Init(IReferences references)
        {
            //PrefabFactory = new PrefabFactory(this, references.PrefabReferences);
            JsonService = new JsonService(references, this);
            HTTPService = new HTTPService(references, this);
        }
    }
}