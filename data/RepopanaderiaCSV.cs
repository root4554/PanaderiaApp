using System.Collections.Generic;
using System.IO;
using System.Linq;
using Entidades;

namespace data;
public class RepoPanaderiaCSV : IRepoPanaderia<Tienda>
{
    string _path = "../RepoPanaderiaCSV.csv";

    //persistencia
    public void Guardar(List<Tienda> clientes)
    {
        List<string> data = new() { };
        foreach (var item in clientes)
        {
            var str = $"{item.NombreTienda},{item.NombreDueño},{item.Credito}";
            data.Add(str);
        }
        File.WriteAllLines(_path, data);
    }

    //lectura
    public List<Tienda> Leer()
    {
        List<Tienda> clientes = new();
        var data = File.ReadAllLines(_path).Where(l => l.Length > 0).ToList();
        foreach (var item in data)
        {
            var campos = item.Split(",");
            var nombreTienda = campos[0];
            var nombreDueño = campos[1];
            var credito = int.Parse(campos[2]);
            var tienda = new Tienda(nombreTienda, nombreDueño, credito);
            clientes.Add(tienda);
        }
        return clientes;

    }
}


