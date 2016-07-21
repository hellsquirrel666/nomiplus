using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace NomiPlus.LogicObjects
{
    public class TipoSalarioLogic
    {
        public TipoSalario GuardarTipoSalario(TipoSalario tipoSalario)
        {
            try
            {
                if (tipoSalario == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en TipoSalario.", "TipoSalario");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(tipoSalario).State = tipoSalario.nIdTipoSalario == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
                return tipoSalario;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<TipoSalario> ListaTipoSalarioes()
        {
            try
            {
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    var query = db.TipoSalario.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public TipoSalario ObtenerTipoSalario(int idTipoSalario)
        {
            try
            {
                if (idTipoSalario == null || idTipoSalario == 0)
                {
                    throw new ArgumentException("No se puede obtener el empleado. idTipoSalario no puede estar vacío.", "idTipoSalario");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    Modelo.TipoSalario pac = db.TipoSalario.Where(p => p.nIdTipoSalario == idTipoSalario).SingleOrDefault();
                    if (pac == null)
                    {
                        throw new FaultException(string.Format("TipoSalario {0} no existe.", idTipoSalario));
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