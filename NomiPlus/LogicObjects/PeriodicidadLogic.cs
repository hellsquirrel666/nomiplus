using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace NomiPlus.LogicObjects
{
    public class PeriodicidadLogic
    {
        public Periodicidad GuardarPeriodicidad(Periodicidad periodicidad)
        {
            try
            {
                if (periodicidad == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Periodicidad.", "Periodicidad");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(periodicidad).State = periodicidad.nIdPeriodicidad == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
                return periodicidad;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<Periodicidad> ListaPeriodicidades()
        {
            try
            {
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    var query = db.Periodicidad.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Periodicidad ObtenerPeriodicidad(int idPeriodicidad)
        {
            try
            {
                if (idPeriodicidad == null || idPeriodicidad == 0)
                {
                    throw new ArgumentException("No se puede obtener el periodicidad. idPeriodicidad no puede estar vacío.", "idPeriodicidad");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    Periodicidad pac = db.Periodicidad.Where(p => p.nIdPeriodicidad == idPeriodicidad).SingleOrDefault();
                    if (pac == null)
                    {
                        throw new FaultException(string.Format("Periodicidad {0} no existe.", idPeriodicidad));
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