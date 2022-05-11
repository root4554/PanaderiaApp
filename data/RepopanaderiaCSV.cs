using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace data;
 public class RepoPanaderiaCSV : IRepoPanaderia<Tienda>
    {
        string _path = "../RepoPanaderiaCSV.csv";

        //persistencia
        public void Guardar(List<Tienda> panaderia)
        {
            List<string> data = new() { };
            foreach (var item in panaderia)
            {
                var str = $"{item.NombreTienda},{item.NombreDueño},{item.CantidadPan}";
                data.Add(str);
            }
            File.WriteAllLines(_path, data);
        }

        //lectura
        public List<Tienda> Leer()
        {
            List<Tienda> panaderias = new();
            var data = File.ReadAllLines(_path).Where(l => l.Length > 0).ToList();
            foreach (var item in data)
            {
                var campos = item.Split(",");
                Tienda panderia = new Tienda(campos[0], campos[1], int.Parse(campos[2]));
                panaderias.Add(panderia);
            }
            return panaderias;
        }
    }

