namespace Entidades;


public class Tienda
{
    public string NombreTienda { get; set; }
    public string NombreDueño { get; set; }
    public double Credito { get; set; }




    public Tienda(string nombreTienda, string nombreDueño, double credito)
    {
        NombreTienda = nombreTienda;
        NombreDueño = nombreDueño;
        Credito = credito;
    }

    public override string ToString() => $"Nombre de la tienda: {NombreTienda}\tNombre del dueño: {NombreDueño}\t   Su Credito: {Credito} EURO ";
}
public class Panderia
{
    public int StockDelDia { get; set; }
    public double PrecioDepan { get; set; }

    public Panderia(int stockDelDia)
    {
        StockDelDia = stockDelDia;
        PrecioDepan = 1.20;
    }


    public override string ToString() => $"Nombre de la tienda: {StockDelDia} UNIDAD\n";
}

