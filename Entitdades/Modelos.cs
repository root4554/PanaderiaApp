namespace Entitdades;
public class Modelos
{
    // diccionario de tipos de pan
    public static Dictionary<string, double> TiposPan = 
        new Dictionary<string, double>();
    TiposPan.Add("Pan de trigo", 0.80);
    TiposPan.Add("Pan de arroz", 1.20);
    TiposPan.Add("Pan de centeno", 1.40);
    TiposPan.Add("Pan de trigo integral", 0.70);
    public class Tienda
    {
        public string NombreTienda {get; set;}
        public string NombreDueño {get; set;}
        public int CantidadPan {get; set;}

        public Tienda(string nombreTienda, string nombreDueño, int cantidadPan){
            NombreTienda = nombreTienda;
            NombreDueño = nombreDueño;
            CantidadPan = cantidadPan;
        }

        public override string ToString()=>$"Nombre de la tienda: {NombreTienda} \nNombre del dueño: {NombreDueño} \nCantidad de pan: {CantidadPan}";
    }
}
