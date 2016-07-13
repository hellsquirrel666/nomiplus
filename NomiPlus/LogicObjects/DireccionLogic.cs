using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace NomiPlus.LogicObjects
{
    public class DireccionLogic
    {
        public Direccion ActualizarOGuardarDireccion(Direccion direccion)
        {
            try
            {
                if (direccion == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Direccion.", "direccion");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(direccion).State = direccion.nIdDireccion == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                    return direccion;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Direccion ObtenerDireccion(int idDireccion)
        {
            try
            {
                if (idDireccion == null || idDireccion == 0)
                {
                    throw new ArgumentException("No se puede obtener la Direccion. idDireccion no puede estar vacío.", "idDireccion");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    Direccion dir = db.Direccion.Where(d => d.nIdDireccion == idDireccion).SingleOrDefault();
                    if (dir == null)
                    {
                        throw new FaultException(string.Format("Direccion {0} no existe.", idDireccion));
                    }
                    return dir;
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