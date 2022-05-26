namespace Entidades;


    public class Tienda
    {
        public string NombreTienda {get; set;}
        public string NombreDueño {get; set;}
        public int CantidadDepan {get; set;}
        

        

        public Tienda(string nombreTienda, string nombreDueño, int cantidadDepan){
            NombreTienda = nombreTienda;
            NombreDueño = nombreDueño;
            CantidadDepan = cantidadDepan;
            }

        public override string ToString()=>$"Nombre de la tienda: {NombreTienda} \nNombre del dueño: {NombreDueño} \nCantidad de pan: {CantidadDepan}";
    }
    public class Panderia
    {
        public int StockDelDia {get; set;}
        
        public Panderia(int stockDelDia){
            StockDelDia = stockDelDia;
            }

        public override string ToString()=>$"Nombre de la tienda: {StockDelDia} \n";
    }
    public class Pan
    {
        public enum Tipo
        {
            Bagguette,
            Integral,
            Centeno,
            Maiz,
        }

        public Tipo tipo { get; set; }

        public decimal precio
        {
            get
            {
                decimal precio = tipo switch
                {
                    Tipo.Bagguette =>0.50m,
                    Tipo.Integral => 1.00m,
                    Tipo.Centeno => 2.00m,
                    Tipo.Maiz => 3.00m
                };
                return precio;
            }
        }
    }
