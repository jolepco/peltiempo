using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Web.Datos.Entidades;

namespace Web.AccesoDatos
{
    public class CiudadVendedor
    {
        public CiudadVendedor()
        {
        }

        #region ciudades
        public async System.Threading.Tasks.Task<List<Ciudad>> listarCiudades()
        {
            List<Ciudad> ciudades = new List<Ciudad>();
            try
            {
                using (ContextoDatos db = new ContextoDatos())
                {
                    ciudades = await db.Ciudades.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ciudades;
        }

        public async System.Threading.Tasks.Task<bool> EliminarCiudad(int ciudad)
        {
            bool respuesta = false;
            Ciudad ciudades = new Ciudad();
            try
            {
                using (ContextoDatos db = new ContextoDatos())
                {
                    Ciudad _ciudad = db.Ciudades.Find(ciudad);
                    if (_ciudad.CiudadId > 0)
                    {
                        db.Entry(_ciudad).State = EntityState.Deleted;
                        System.Threading.Tasks.Task<int> rta = db.SaveChangesAsync();
                        respuesta = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return respuesta;
        }

        #endregion

        #region vendedor
        public async System.Threading.Tasks.Task<Vendedor> listarunVendedor(int vendedor)
        {
            Vendedor _vendedor = new Vendedor();
            try
            {
                using (ContextoDatos db = new ContextoDatos())
                {
                    _vendedor = await db.Vendedores.FindAsync(vendedor);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _vendedor;
        }

        public async System.Threading.Tasks.Task<bool> EliminarVendedor(int vendedor)
        {
            bool respuesta = false;
            Ciudad ciudades = new Ciudad();
            try
            {
                using (ContextoDatos db = new ContextoDatos())
                {
                    Vendedor _vendedor = db.Vendedores.Find(vendedor);
                    if (_vendedor.CiudadId > 0)
                    {
                        db.Entry(_vendedor).State = EntityState.Deleted;
                        System.Threading.Tasks.Task<int> rta = db.SaveChangesAsync();
                        respuesta = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return respuesta;
        }

        #endregion

        #region modelo
        public async System.Threading.Tasks.Task<Models.ModeloCompleto> ObtenerTodoModeloAsing(int ciudad)
        {
            Models.ModeloCompleto modelo = new Models.ModeloCompleto();
            List<Vendedor> vendedores = new List<Vendedor>();
            List<Ciudad> ciudadesTodas = new List<Ciudad>();
            try
            {
                using (ContextoDatos db = new ContextoDatos())
                {
                    ciudadesTodas = await db.Ciudades.ToListAsync();
                    vendedores = await db.Vendedores.Where(c => c.CiudadId == ciudad).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            modelo.ciudad = new Ciudad();
            modelo.ciudad = ciudadesTodas.Where(c => c.CiudadId == ciudad).FirstOrDefault();
            modelo.vendedores = new List<Vendedor>();
            modelo.vendedores = vendedores;
            modelo.listaCiudades = new SelectList(ciudadesTodas, "CiudadId", "Nombre");
            return modelo;
        }

        #endregion

        #region transaccion 
        public async System.Threading.Tasks.Task<bool> GuardarTransaccionAsing(Models.ModeloCompleto modelo)
        {
            bool respuesta = false;

            using (ContextoDatos db = new ContextoDatos())
            {
                using (DbContextTransaction transaccion = db.Database.BeginTransaction())
                {
                    try
                    {
                        Datos.Entidades.Ciudad _ciudad = new Ciudad
                        {
                            CiudadId = modelo.ciudad.CiudadId,
                            Codigo = modelo.ciudad.Codigo,
                            Nombre = modelo.ciudad.Nombre,
                        };

                        if (_ciudad.CiudadId == 0)
                        {
                            db.Entry(_ciudad).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(_ciudad).State = EntityState.Modified;
                        }
                        int numero = await db.SaveChangesAsync();

                        foreach (Vendedor vendedor in modelo.vendedores)
                        {
                            Vendedor _vendedor = new Datos.Entidades.Vendedor
                            {
                                Apellido = vendedor.Apellido,
                                CiudadId = vendedor.CiudadId,
                                Codigo = vendedor.Codigo,
                                Nombre = vendedor.Nombre,
                                Numero_Identificacion = vendedor.Numero_Identificacion,
                                VendedorId = vendedor.VendedorId,
                            };

                            if (_vendedor.CiudadId == 0)
                            {
                                db.Entry(_vendedor).State = EntityState.Added;
                            }
                            else
                            {
                                db.Entry(_vendedor).State = EntityState.Modified;
                            }
                            int numero2 = await db.SaveChangesAsync();
                        }
                        transaccion.Commit();
                        respuesta = true;
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw (ex);
                    }
                    return respuesta;
                }
            }

        }
        #endregion

    }
}