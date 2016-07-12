using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NomiPlus.Modelo;
using System.Data.Entity;

namespace NomiPlus.LogicObjects
{
    public class EmpresaLogic 
    {
        public Modelo.Empresa GuardarEmpresa(Modelo.Empresa empresa)
        {
            try
            {
                if (empresa == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Empresa.", "Empresa");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(empresa).State = empresa.nIdEmpresa == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
                return empresa;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }

        }
    }
}