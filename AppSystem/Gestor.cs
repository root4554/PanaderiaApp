using System.Collections.Generic;
using data;
using Entidades;


namespace AppSystem;

public class Gestor
{
    public Gestor(RepoPanaderiaCSV repoPanaderia)
    {
        _repoPanaderia = repoPanaderia;
        clientes = _repoPanaderia.Leer();
    }
    RepoPanaderiaCSV _repoPanaderia;
    public List<Tienda> clientes { get; set; } = new();
    public Panderia panderia { get; set; } = new(0);

    // === Gestion de tiendas ===
    public void RegistrarIngreso(Tienda t)
    {
        clientes.Add(t);
        _repoPanaderia.Guardar(clientes);
    }

    // === anadir Stock ===
    public void AnadirStock( int cantidad)
    {
        panderia.StockDelDia += cantidad;
    }
    // === Mostrar Stock ===

    public int MostrarStock()
    {
        return panderia.StockDelDia;
    }

    // === borrar Tienda ===
    public void BorrarTienda(Tienda t)
    {
        clientes.Remove(t);
        _repoPanaderia.Guardar(clientes);
    }

    // === restar cantidad ===
    public void RestarCantidad(int cantidad)
    {
        panderia.StockDelDia -= cantidad;
    }

    // === summar credito ===  
    public void SumarCredito(Tienda t, int cantidad)
    {

        t.Credito += cantidad * panderia.PrecioDepan;
        _repoPanaderia.Guardar(clientes);
    }

    // === Mostrar credito ===
    public double MostrarCredito(Tienda t)
    {
        return t.Credito;
    }

    // === Pagar credito ===
    public void PagarCredito(Tienda t, double pago)
    {
        t.Credito -= pago;
        _repoPanaderia.Guardar(clientes);
    }
    

}
