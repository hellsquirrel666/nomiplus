﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NomiPlus.Modelo;
using System.Data.Entity;
using System.ServiceModel;

namespace NomiPlus.LogicObjects
{
    public class EmpresaLogic 
    {
        public Empresa GuardarEmpresa(Empresa empresa)
        {
            try
            {
                if (empresa == null)
                {
                    throw new ArgumentException("No se puede guardar un valor nulo en Empresa.", "Empresa");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    db.Entry(empresa).State = empresa.nIdEmpresa == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();
                }
                return empresa;
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public List<Empresa> ListaEmpresas()
        {
            try
            {
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    var query = db.Empresa.AsQueryable();
                    return query.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrió un error en el servicio web.", e);
            }
        }

        public Empresa ObtenerEmpresa(int idEmpresa)
        {
            try
            {
                if (idEmpresa == null || idEmpresa == 0)
                {
                    throw new ArgumentException("No se puede obtener el empresa. idEmpresa no puede estar vacío.", "idEmpresa");
                }
                using (var db = new DB_A06759_NOMINASEntities())
                {
                    Empresa pac = db.Empresa.Where(p => p.nIdEmpresa == idEmpresa).SingleOrDefault();
                    if (pac == null)
                    {
                        throw new FaultException(string.Format("Empresa {0} no existe.", idEmpresa));
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