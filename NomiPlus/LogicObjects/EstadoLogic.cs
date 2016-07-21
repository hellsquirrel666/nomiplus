using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace NomiPlus.LogicObjects
{
    public class EstadoLogic
    {
        public Estado GuardarEstado(Estado estado)
        {
            try
            {
                if (estado == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Estado.", "Estado");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(estado).State = estado.nIdEstado == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
                return estado;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<Estado> ListaEstados()
        {
            try
            {
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    var query = db.Estado.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Estado ObtenerEstado(int idEstado)
        {
            try
            {
                if (idEstado == null || idEstado == 0)
                {
                    throw new ArgumentException("No se puede obtener el estado. idEstado no puede estar vacío.", "idEstado");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    Estado pac = db.Estado.Where(p => p.nIdEstado == idEstado).SingleOrDefault();
                    if (pac == null)
                    {
                        throw new FaultException(string.Format("Estado {0} no existe.", idEstado));
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