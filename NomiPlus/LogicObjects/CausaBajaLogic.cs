using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace NomiPlus.LogicObjects
{
    public class CausaBajaLogic
    {
        public CausaBaja GuardarCausaBaja(CausaBaja causaBaja)
        {
            try
            {
                if (causaBaja == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en CausaBaja.", "CausaBaja");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(causaBaja).State = causaBaja.nIdCausaBaja == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
                return causaBaja;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<CausaBaja> ListaCausaBaja()
        {
            try
            {
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    var query = db.CausaBaja.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public CausaBaja ObtenerCausaBaja(int idCausaBaja)
        {
            try
            {
                if (idCausaBaja == null || idCausaBaja == 0)
                {
                    throw new ArgumentException("No se puede obtener el causaBaja. idCausaBaja no puede estar vacío.", "idCausaBaja");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    CausaBaja pac = db.CausaBaja.Where(p => p.nIdCausaBaja == idCausaBaja).SingleOrDefault();
                    if (pac == null)
                    {
                        throw new FaultException(string.Format("CausaBaja {0} no existe.", idCausaBaja));
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