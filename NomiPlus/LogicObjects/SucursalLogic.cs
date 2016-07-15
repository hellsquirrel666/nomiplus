using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace NomiPlus.LogicObjects
{
    public class SucursalLogic
    {
        public Sucursal GuardarSucursal(Sucursal sucursal)
        {
            try
            {
                if (sucursal == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Sucursal.", "Sucursal");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(sucursal).State = sucursal.nIdSucursal == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
                return sucursal;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<Sucursal> ListaSucursales()
        {
            try
            {
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    var query = db.Sucursal.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Sucursal ObtenerSucursal(int idSucursal)
        {
            try
            {
                if (idSucursal == null || idSucursal == 0)
                {
                    throw new ArgumentException("No se puede obtener el sucursal. idSucursal no puede estar vacío.", "idSucursal");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    Sucursal pac = db.Sucursal.Where(p => p.nIdSucursal == idSucursal).SingleOrDefault();
                    if (pac == null)
                    {
                        throw new FaultException(string.Format("Sucursal {0} no existe.", idSucursal));
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