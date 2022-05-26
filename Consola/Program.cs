using data;
using Consola;
using AppSystem;
using System.Collections.Generic;
using System;

class AppSanitaria
{
    public static void Main()
    {
        // Más sencillo no puede
        var repositorio = new RepoPanaderiaCSV();
        var view = new Vista();
        var sistema = new Gestor(repositorio);
        var controlador = new Controlador(view, sistema);
        controlador.Run();

    }
}