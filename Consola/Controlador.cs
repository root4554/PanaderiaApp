using System;
using AppSystem;
using System.Collections.Generic;
using System.Linq;


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
                { "Registrar ingreso de paciente", RealizarIngreso },
                { "Alta de paciente", DarDeAlta },
                { "Comprobación de PCR", VerificarPruebaPCR },
                { "Mostrar Ingresados", MostarIngresados}
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



        

    }
}