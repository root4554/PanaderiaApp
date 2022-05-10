using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace data;
public interface IRepoPanaderia<T>
    {

        public void Guardar(List<T> datos);
        public List<T> Leer();
    }
