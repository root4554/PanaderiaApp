using System.Collections.Generic;
using data;
using Entidades;


namespace AppSystem;

public class Gestor
{
    public Gestor(RepoPanaderiaCSV repoPanaderia)
    {
        _repoPanaderia = repoPanaderia;
        panaderias = _repoPanaderia.Leer();
    }
    RepoPanaderiaCSV _repoPanaderia;
    public List<Tienda> panaderias {get; set;} = new();

    // === Gestion de tiendas ===
    public void RegistrarIngreso(Tienda t)
    {
        panaderias.Add(t);
        _repoPanaderia.Guardar(panaderias);
    }

   // === Add Stock ===
    public void AddStock(Panderia p, int cantidad)
    {
        p.StockDelDia += cantidad;
        _repoPanaderia.Guardar(panaderias);
    }
    
    // === borrar Tienda ===
    public void BorrarTienda(Tienda tienda)
    {
        panaderias.Remove(tienda);
        _repoPanaderia.Guardar(panaderias);
    }

    // === buscar Tienda ===
    public Tienda BuscarTienda(string nombreTienda)
        => panaderias.Find(t => t.NombreTienda == nombreTienda);
    
    // === listar Tiendas ===
    public List<Tienda> ListarTiendas()
    {
        return panaderias;
    }
    

    // === buscar panes ===
    public double BuscarPanes(string pan, Dictionary<string, double> precioPan){
        if(precioPan.ContainsKey(pan)){
            return precioPan[pan];
        }
        else
        {
            return 0;
        }
    }
        
    // === Buscar Stock ===
    public int BuscarStock(string pan,Dictionary<string, int> cantidadPan){
        if(cantidadPan.ContainsKey(pan)){
            return cantidadPan[pan];
        }
        else
        {
            return 0;
        }
    }
    
    // === Hacer compra ===
     



    

    

    
}
