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