using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDBHandling
{
    public class DocumentManager
    {
        // Cliente de conexion
        public DocumentClient client;
        // Nombre en "cache" de la coleccion para poder referenciar
        public string mainCollection;
        // Instancia de base de datos
        Database db;
        string dbPath;
        
        public DocumentManager()
        {
            // Los campos EndpointUri y AuthorizationKey salen de los settings de la coleccion en Azure
            // DatabaseName y CollectionName son los que le pusimos al crearla
            client = new DocumentClient(new Uri("<EndpointUri>"), "<AuthorizationKey>");
            db = client.CreateDatabaseQuery().Where(x => x.Id == "<DatabaseName>").AsEnumerable().FirstOrDefault();
            dbPath = $"dbs/{db.Id}";
            var collection = client.CreateDocumentCollectionQuery(dbPath)
                .Where(c => c.Id == "<CollectionName>").AsEnumerable().FirstOrDefault();
            mainCollection =
                collection == null ? String.Empty : collection.SelfLink;
        }
    }
}
