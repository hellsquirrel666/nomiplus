using NomiPlus.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace NomiPlus.LogicObjects
{
    public class DepartamentoLogic
    {
        public Departamento GuardarDepartamento(Departamento departamento)
        {
            try
            {
                if (departamento == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Departamento.", "Departamento");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(departamento).State = departamento.nIdDepartamento == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
                return departamento;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<Departamento> ListaDepartamentos()
        {
            try
            {
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    var query = db.Departamento.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Departamento ObtenerDepartamento(int idDepartamento)
        {
            try
            {
                if (idDepartamento == null || idDepartamento == 0)
                {
                    throw new ArgumentException("No se puede obtener el departamento. idDepartamento no puede estar vacío.", "idDepartamento");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    Departamento pac = db.Departamento.Where(p => p.nIdDepartamento == idDepartamento).SingleOrDefault();
                    if (pac == null)
                    {
                        throw new FaultException(string.Format("Departamento {0} no existe.", idDepartamento));
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