using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace NomiPlus.LogicObjects
{
    public class EmpleadoLogic
    {
        public Empleado GuardarEmpleado(Empleado empleado)
        {
            try
            {
                if (empleado == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Empleado.", "Empleado");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(empleado).State = empleado.nIdEmpleado == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
                return empleado;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<Empleado> ListaEmpleados()
        {
            try
            {
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    var query = db.Empleado.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Empleado ObtenerEmpleado(int idEmpleado)
        {
            try
            {
                if (idEmpleado == null || idEmpleado == 0)
                {
                    throw new ArgumentException("No se puede obtener el empleado. idEmpleado no puede estar vacío.", "idEmpleado");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    Modelo.Empleado pac = db.Empleado.Where(p => p.nIdEmpleado == idEmpleado).SingleOrDefault();
                    if (pac == null)
                    {
                        throw new FaultException(string.Format("Empleado {0} no existe.", idEmpleado));
                    }
                    return pac;
                }
            }
            catch (FaultException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }
    }
}