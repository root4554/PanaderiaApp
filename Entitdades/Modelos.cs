namespace Entitdades;
public class Modelos
{

    public class Tienda
    {
        public string NombreTienda {get; set;}
        public string NombreDueño {get; set;}
        public Dictionary<string, int> CantidadDepan {get; set;}
        

        public Tienda(string nombreTienda, string nombreDueño, Dictionary<string, int> cantidadPan){
            NombreTienda = nombreTienda;
            NombreDueño = nombreDueño;
            CantidadDepan = cantidadPan;
            }

        public override string ToString()=>$"Nombre de la tienda: {NombreTienda} \nNombre del dueño: {NombreDueño} \nCantidad de pan: {CantidadPan}";
    }
}
