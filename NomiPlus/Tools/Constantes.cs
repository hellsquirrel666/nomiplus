using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomiPlus.Tools
{
    public static class Constantes
    {
        public static class TiempoPeriodo
        {
            public static double Diario = 1;
            public static double Semanal = 7;
            public static double Catorcenal = 14;
            public static double Quincenal = 15.2;
            public static double Mensual = 30.4;

            public static List<double> getListPeriodos() 
            {
                List<double> lista = new List<double>();
                lista.Add(Diario);
                lista.Add(Semanal);
                lista.Add(Catorcenal);
                lista.Add(Quincenal);
                lista.Add(Mensual);
                return lista;
            }
        }
    }
}