using System.Collections.Generic;
using System.Linq;
using AppSystem;
using Entidades;

namespace Consola
{
    class Controlador
    {
        private Vista _vista;
        private Gestor _sistema;
        private Dictionary<string, Action> _casosDeUso;
        private Dictionary<string, double> _tiposDePan;
       
        public Controlador(Vista vista, Gestor businessLogic)
        {
            _vista = vista;
            _sistema = businessLogic;
            _casosDeUso = new Dictionary<string, Action>(){
                { "Stock del dia", RegistrarIngreso },
                { "Registrar una nueva tienda", RegistrarIngreso },
                { "Comprobación de PCR", RegistrarIngreso},
                { "Mostrar Ingresados", RegistrarIngreso}
            };
            _tiposDePan = new Dictionary<string, double>(){
                {"Pan de trigo", 1.00},
                {"Pan de arroz", 1.50},
                {"Pan de soja", 1.40},
                {"Pan de trigo integral", 0.70}
            };
        }

        // === Ciclo de la Aplicacin ===
        public void Run()
        {
              _vista.LimpiarPantalla();
            // Acceso a las Claves del diccionario
            var menu = _casosDeUso.Keys.ToList<String>();

            while (true)
                try
                {
                    //Limpiamos
                     _vista.LimpiarPantalla();
                    // Menu
                    var key = _vista.TryObtenerElementoDeLista("Menu de Usuario", menu, "Seleciona una opción");
                    _vista.Mostrar("");
                    // Ejecución de la opción escogida
                    _casosDeUso[key].Invoke();
                    // Fin
                    _vista.MostrarYReturn("Pulsa <Return> para continuar");
                }
                catch { return; }
        }

        // === Casos de Uso ===
        private void RegistrarIngreso()
        {
            try
            {
                var nt = _vista.TryObtenerDatoDeTipo<string>("Nombre de la tienda");
                var nd = _vista.TryObtenerDatoDeTipo<string>("Nombre del dueño");
                var cp = _vista.TryObtenerDatoDeTipo<int>("Cantidad de pan");
                
               

                Tienda tienda = new Tienda(nt,nd,cp);
                    _sistema.RegistrarIngreso(tienda);
                    _sistema.panaderias.Add(tienda);
            } 
            catch (Exception e)
            {
                _vista.Mostrar($"UC:{e.Message}");
            }
        }
            public void AnadirPedido()
        {
                var panaderia = _vista.TryObtenerElementoDeLista<Tienda>("Tiendas", _sistema.panaderias, "");
                var _tipo = _vista.TryObtenerElementoDeLista<Pan.Tipo>("Tipos de pan ", _vista.EnumToList<Pan.Tipo>(), "Indica el tipo de pan");
                
                var cantidad = _vista.TryObtenerDatoDeTipo<int>("Cantidad ");
                var fecha = _vista.TryObtenerFecha("Para cuando? ");

                Pedido pedido = new Pedido
                {
                    id_cliente = cliente.id_cliente,
                    pan = new Pan{
                    tipo=_tipo
                    },
                    cantidad = cantidad,
                    fecha = fecha
                };
                _sistema.AnadirPedido(pedido);
        }


    }
}