using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace NomiPlus.LogicObjects
{
    public class OcupacionesLogic
    {
        public Ocupaciones ActualizarOGuardarOcupacion(Ocupaciones ocupacion)
        {
            try
            {
                if (ocupacion == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Ocupacion.", "direccion");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(ocupacion).State = ocupacion.nIdOcupacion == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                    return ocupacion;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Ocupaciones ObtenerOcupacion(int idOcupacion)
        {
            try
            {
                if (idOcupacion == null || idOcupacion == 0)
                {
                    throw new ArgumentException("No se puede obtener la Ocupacion. idOcupacion no puede estar vacío.", "idOcupacion");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    Ocupaciones dir = db.Ocupaciones.Where(d => d.nIdOcupacion == idOcupacion).SingleOrDefault();
                    if (dir == null)
                    {
                        throw new FaultException(string.Format("Ocupacion {0} no existe.", idOcupacion));
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

        public List<Ocupaciones> ListaOcupaciones()
        {
            try
            {
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    var query = db.Ocupaciones.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

    }
}