namespace Fridge.Services
{
    public interface IServices
    {
        IPrefabFactory PrefabFactory { get; }
    }

    public class Services : IServices
    {
        public IPrefabFactory PrefabFactory { get; set; }
    }
}