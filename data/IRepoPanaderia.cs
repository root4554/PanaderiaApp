using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace data;
public interface IRepoPanaderia<T>
    {

         void Guardar(List<T> datos);
         List<T> Leer();
    }
