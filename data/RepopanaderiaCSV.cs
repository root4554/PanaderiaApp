using System.Collections.Generic;
using System.IO;
using System.Linq;
using Entidades;

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
                var str = $"{item.NombreTienda},{item.NombreDueño},{item.CantidadDepan}";
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
                var nombreTienda = campos[0];
                var nombreDueño = campos[1];
                var cantidadPan = campos[2];
                var cantidadPanDict = new Dictionary<string, int>();
                var cantidadPanSplit = cantidadPan.Split(";");
                foreach (var item2 in cantidadPanSplit)
                {
                    var pan = item2.Split(":")[0];
                    var cantidad = int.Parse(item2.Split(":")[1]);
                    cantidadPanDict.Add(pan, cantidad);
                }
                var tienda = new Tienda(nombreTienda, nombreDueño, cantidadPanDict);
                panaderias.Add(tienda);
            }
            return panaderias;
        }
    }

    //              Tienda panderia = new Tienda(campos[0], campos[1], int.Parse(campos[2]));
    //             panaderias.Add(panderia);
    //         }
    //         return panaderias;
    //     }
    // }

