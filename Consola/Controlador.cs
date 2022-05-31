using System.Collections.Generic;
using System.Linq;
using AppSystem;
using Entidades;

namespace Consola;
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
                { "añadir Stock del dia", AddStock },
                { "Mostrar Stock", MostrarStock },
                { "Registrar una nueva tienda", RegistrarIngreso },
                { "Mostrar lista de Clientes/Tiendas", ListarTiendas },
                { "Hacer un Pedido", Hacerpedido},
                { "Pagar Credito de Cliente", PagarCredito},
                { "Borrar un cliente/tienda", BorrarTienda}
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
    private void AddStock()
    {
        try
        {
            _sistema.AnadirStock( _vista.TryObtenerDatoDeTipo<int>("Cantidad de Stock a añadir (UNIDAD)"));
            _vista.Mostrar("Stock actual: " + _sistema.MostrarStock());
        }
        catch (Exception e)
        {
            _vista.Mostrar($"UC:{e.Message}");
        }
    }

    private void RegistrarIngreso()
    {
        try
        {
            var nt = _vista.TryObtenerDatoDeTipo<string>("Nombre de la tienda");
            var nd = _vista.TryObtenerDatoDeTipo<string>("Nombre del dueño");

            Tienda tienda = new Tienda(nt, nd, 0);
            _sistema.RegistrarIngreso(tienda);
        }
        catch (Exception e)
        {
            _vista.Mostrar($"UC:{e.Message}");
        }
    }
    //Pedido
    private void Hacerpedido()
    {
        try
        {   _vista.Mostrar("1- Persona");
            _vista.Mostrar("2- Tienda");
            var opcion = _vista.TryObtenerDatoDeTipo<int>("Selecciona una opción");
            if(opcion == 1 || opcion == 2)
            {
                var cp = _vista.TryObtenerDatoDeTipo<int>("Mete la Cantidad de pan que va pedir (UNIDAD)");
                if(cp > _sistema.MostrarStock())
                {
                    _vista.Mostrar("No hay stock suficiente");
                    _vista.Mostrar("Stock actual: " + _sistema.MostrarStock());
                    return;
                }

                else
                {
                    if(opcion == 1)
                    {
                        _sistema.RestarCantidad(cp);
                    }

                    if(opcion == 2)
                    {
                        ListarTiendas();

                        var idc = _vista.TryObtenerValorEnRangoInt(1, _sistema.clientes.Count, "Seleccione una tienda");
                        var cliente = _sistema.clientes[idc - 1];
                                                
                        _sistema.RestarCantidad(cp);
                        _sistema.SumarCredito(cliente, cp);
                        _vista.Mostrar("Credito actual: " + _sistema.MostrarCredito(cliente) +" EURO");
                        
                    }
                    _vista.Mostrar("Pedido realizado");
                    _vista.Mostrar("Stock actual: " + _sistema.MostrarStock());
                }
                
            }
            else
            {
                _vista.Mostrar("Opcion no valida");
                return;
            }
        }
        catch (Exception e)
        {
            _vista.Mostrar($"UC: {e.Message}");
        }
    }

    //Pagar Credito

    private void PagarCredito()
    {
        try
        {
            ListarTiendas();
            var idc = _vista.TryObtenerValorEnRangoInt(1, _sistema.clientes.Count, "Seleccione una tienda");
            var cliente = _sistema.clientes[idc - 1];

            var cp = _vista.TryObtenerDatoDeTipo<int>("Cuanto va a pagar?");
            _sistema.PagarCredito(cliente, cp);
            _vista.Mostrar("Credito actual: " + _sistema.MostrarCredito(cliente) + " EURO");
        }
        catch (Exception e)
        {
            _vista.Mostrar($"UC: {e.Message}");
        }
    }
    //borrar tiendas
    private void BorrarTienda()
    {
        try
        {
            ListarTiendas();

            var idc = _vista.TryObtenerValorEnRangoInt(1, _sistema.clientes.Count, "Seleccione una tienda  ");
            var cliente = _sistema.clientes[idc - 1];

            if( _sistema.MostrarCredito(cliente)>0)
            {
                _vista.Mostrar("No se puede borrar tienda con credito");
                return;
            }
            else
            {
                _sistema.BorrarTienda(cliente);
                _vista.Mostrar("se va borrar todos los datos de la tienda" + $"Tienda: {cliente.NombreTienda}");
            }
        }
        catch (Exception e)
        {
            _vista.Mostrar($"UC: {e.Message}");
        }
    }
    //Mostrar Stock
    public void MostrarStock()
    {
        _vista.Mostrar("Stock actual: " + _sistema.MostrarStock() +" UNIDAD");
    }
   //Mostrar lista de clientes/tiendas
    public void ListarTiendas()
    {
         _vista.MostrarListaEnumerada<Tienda>("Tiendas/Clientes", _sistema.clientes);
    }
}