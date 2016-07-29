using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace NomiPlus.LogicObjects
{
    public class NominaLogic
    {
        public void GuardarNomina(Nomina nomina)
        {
            try
            {
                if (nomina == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Empresa.", "Empresa");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(nomina).State = nomina.nIdNomina == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<Nomina> ListaNominas()
        {
            try
            {
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    var query = db.Nomina.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Nomina ObtenerNomina(int idNomina)
        {
            try
            {
                if (idNomina == null || idNomina == 0)
                {
                    throw new ArgumentException("No se puede obtener la nómina. idNomina no puede estar vacío.", "idNomina");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    Nomina pac = db.Nomina.Where(p => p.nIdNomina == idNomina).SingleOrDefault();
                    if (pac == null)
                    {
                        throw new FaultException(string.Format("Nomina {0} no existe.", idNomina));
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