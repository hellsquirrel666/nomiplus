using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace NomiPlus.LogicObjects
{
    public class TipoTrabajadorLogic
    {
        public TipoTrabajador GuardarTipoTrabajador(TipoTrabajador tipoTrabajador)
        {
            try
            {
                if (tipoTrabajador == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en TipoTrabajador.", "TipoTrabajador");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(tipoTrabajador).State = tipoTrabajador.nIdTipoTrabajador == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
                return tipoTrabajador;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<TipoTrabajador> ListaTipoTrabajadores()
        {
            try
            {
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    var query = db.TipoTrabajador.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public TipoTrabajador ObtenerTipoTrabajador(int idTipoTrabajador)
        {
            try
            {
                if (idTipoTrabajador == null || idTipoTrabajador == 0)
                {
                    throw new ArgumentException("No se puede obtener el empleado. idTipoTrabajador no puede estar vacío.", "idTipoTrabajador");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    Modelo.TipoTrabajador pac = db.TipoTrabajador.Where(p => p.nIdTipoTrabajador == idTipoTrabajador).SingleOrDefault();
                    if (pac == null)
                    {
                        throw new FaultException(string.Format("TipoTrabajador {0} no existe.", idTipoTrabajador));
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