using System.Reflection;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace CodelessPlate.Data
{
    public class RavenInstance
    {
        private static RavenInstance _singleInstance;

        private RavenInstance()
        {
            
        }

        public static RavenInstance Current
        {
            get
            {
                if (_singleInstance == null)
                {
                    _singleInstance = new RavenInstance();
                    _singleInstance.Initialize();
                }

                return _singleInstance;
            }
        }

        public EmbeddableDocumentStore DocumentStore { get; private set; }

        public IDocumentSession Session { get; set; }

        private void Initialize()
        {
            this.DocumentStore = new EmbeddableDocumentStore
            {
                DataDirectory = "Data"
            };

            IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), this.DocumentStore);

            this.DocumentStore.Initialize();

            this.Session = DocumentStore.OpenSession();
        }

        public string Store(dynamic entity)
        {
            this.Session.Store(entity);
            this.Session.SaveChanges();

            return entity.Id;
        }

        public T Load<T>(string id)
        {
            return this.Session.Load<T>(id);
        }
    }
}
