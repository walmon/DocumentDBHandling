using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDBHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentManager dm = new DocumentManager();
            var entity = new Usuario() { Id = "12346665", Name = "Foo Name" };

            // Crear un objeto
            dm.client.CreateDocumentAsync(dm.mainCollection, entity);

            // Obtener un objeto
            var savedEntity= dm.client.CreateDocumentQuery(dm.mainCollection)
                .Where(x => x.Id == "12346665").AsEnumerable().FirstOrDefault();

            entity.Name = "Foo Name Cooler";
            // Actualizar un objeto
            dm.client.ReplaceDocumentAsync(savedEntity.SelfLink, savedEntity);
        }
    }
    public class Usuario
    {
        public string Name { get; set; }
        // Debe tener esta propiedad para que la utilice como un Id "predecible" por nosotros
        public string Id { get; set; }
    }
}
