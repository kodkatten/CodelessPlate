using Raven.Client;

namespace CodelessPlate.Data
{
    public interface IRavenInstance
    {
        IDocumentSession Session { get; set; }
        string Store(dynamic entity);
        T Load<T>(string id);
    }
}