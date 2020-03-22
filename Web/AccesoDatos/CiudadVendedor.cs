using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.Datos.Entidades;
using Web.Datos.Modelos;

namespace Web.AccesoDatos
{
    public class CiudadVendedor
    {
        public CiudadVendedor()
        {
        }

        #region ciudades
        public async Task<bool> GuardarCiudadAsing(CiudadModel modelo)
        {
            bool respuesta = false;
            Ciudad ciudades = new Ciudad();
            try
            {
                using (ContextoDatos db = new ContextoDatos())
                {
                    Ciudad ciudad = new Ciudad
                    {
                        CiudadId = modelo.CiudadId,
                        Codigo = modelo.Codigo,
                        Nombre = modelo.Nombre,
                    };
                    if (ciudad.CiudadId > 0)
                    {
                        db.Entry(ciudad).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(ciudad).State = EntityState.Added;

                    }
                    db.SaveChanges();
                   // System.Threading.Tasks.Task<int> rta = db.SaveChangesAsync();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return respuesta;
        }

        public async System.Threading.Tasks.Task<List<Datos.Modelos.CiudadModel>> listarCiudades()
        {
            List<Datos.Modelos.CiudadModel> ciudades = new List<Datos.Modelos.CiudadModel>();
            try
            {
                using (ContextoDatos db = new ContextoDatos())
                {
                   var  ciudades1 = db.Ciudades.ToList();
                    ciudades.AddRange(ciudades1.Select(c => new Datos.Modelos.CiudadModel
                    {
                        CiudadId = c.CiudadId, 
                        Codigo = c.Codigo, 
                        Nombre = c.Nombre, 
                    }).ToList());
                   // ciudades = await Task.Run (()=> {  return db.Ciudades.ToList(); });

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
                        db.SaveChanges();
                        //System.Threading.Tasks.Task<int> rta = db.SaveChangesAsync();
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

        public async Task<bool> EliminarVendedor(int codigo)
        {
            bool respuesta = false;
            using (var db = new ContextoDatos())
            {
                var buscar = db.Vendedores.Find(codigo);
               
                    if (buscar.VendedorId > 0)
                    {
                        db.Entry(buscar).State = EntityState.Deleted;
                        db.SaveChanges();
                        respuesta = true;
                    }
            }
            return respuesta;
        }

        #endregion

        #region vendedor
        public async System.Threading.Tasks.Task<Datos.Modelos.VendedoresModel> listarunVendedor(int vendedor)
        {
            Datos.Modelos.VendedoresModel _vendedor = new Datos.Modelos.VendedoresModel();
            try
            {
                using (ContextoDatos db = new ContextoDatos())
                {
                    var _ciudad = db.Ciudades.ToList();
                  var  _ve = db.Vendedores.Find(vendedor);
                    _vendedor = new Datos.Modelos.VendedoresModel
                    {
                        Apellido = _ve.Apellido,
                        CiudadId = _ve.CiudadId,
                        Codigo = _ve.Codigo,
                        Nombre = _ve.Nombre,
                        Numero_Identificacion = _ve.Numero_Identificacion,
                        VendedorId = _ve.VendedorId,
                        Ciudad = new Datos.Modelos.CiudadModel
                        {
                            CiudadId = _ve.Ciudad.CiudadId,
                            Codigo = _ve.Ciudad.Codigo,
                            Nombre = _ve.Ciudad.Nombre,
                        }, combociudades= _ciudad?.Select(c=> new Datos.Modelos.ComboModel { 
                        Id = c.CiudadId.ToString(), Nombre = c.Nombre,
                        }).ToList(), 
                    };
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _vendedor;
        }

        public async Task<bool> GuardarVendedorAsing(VendedoresModel modelo)
        {
            bool respuesta = false;
            Ciudad ciudades = new Ciudad();
            try
            {
                using (ContextoDatos db = new ContextoDatos())
                {
                    Vendedor vendedor = new Vendedor
                    {
                        Apellido = modelo.Apellido, 
                        Numero_Identificacion= modelo.Numero_Identificacion, 
                        VendedorId= modelo.VendedorId,
                        CiudadId = modelo.CiudadId,
                        Codigo = modelo.Codigo,
                        Nombre = modelo.Nombre,
                    };
                    if (vendedor.VendedorId > 0)
                    {
                        db.Entry(vendedor).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(vendedor).State = EntityState.Added;

                    }
                    db.SaveChanges();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return respuesta;
        }

        public async Task<List<Datos.Modelos.VendedoresModel>> ObtenerunVendedorCiudad(int modelo)
        {
            try
            {
                List<Datos.Modelos.VendedoresModel> vendedor = new List<VendedoresModel>();
                using (ContextoDatos db = new ContextoDatos())
                {
                    var _vend = db.Vendedores.Where(r => r.CiudadId == modelo).ToList();
                    var ciudadesN = db.Ciudades.ToList();

                    vendedor.AddRange(
                        _vend?.Select(v => new Datos.Modelos.VendedoresModel
                        {
                            Apellido = v.Apellido,
                            ciudadantiguaid = v.CiudadId,
                            CiudadId = v.Ciudad.CiudadId,
                            Ciudad = new CiudadModel
                            {
                                CiudadId = v.Ciudad.CiudadId,
                                Codigo = v.Ciudad.Codigo,
                                Nombre = v.Ciudad.Nombre,
                            },
                            Codigo = v.Codigo,
                            combociudades = ciudadesN?.Select(r => new ComboModel
                            {
                                Id = r.CiudadId.ToString(),
                                Nombre = r.Nombre
                            }).ToList(),
                            Nombre = v.Nombre,
                            Numero_Identificacion = v.Numero_Identificacion,
                            VendedorId = v.VendedorId,
                        }).ToList());
                    return vendedor;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
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
                    ciudadesTodas = db.Ciudades.ToList();
                    vendedores = db.Vendedores.Where(c => c.CiudadId == ciudad).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            List<Datos.Modelos.CiudadModel> _ciudad = new List<Datos.Modelos.CiudadModel>();
            _ciudad.AddRange(ciudadesTodas.Select( r => new Datos.Modelos.CiudadModel {
                CiudadId = r.CiudadId, 
                Codigo = r.Codigo, 
                Nombre = r.Nombre,
            }).ToList());

            modelo.ciudad = new Datos.Modelos.CiudadModel();
            modelo.ciudad = ciudadesTodas.Where(c => c.CiudadId == ciudad).Select(r=> new Datos.Modelos.CiudadModel { 
            CiudadId = r.CiudadId,  Codigo = r.Codigo, Nombre =r.Nombre, 
            }).FirstOrDefault();
            modelo.vendedores = new List<Datos.Modelos.VendedoresModel>();

            modelo.vendedores.AddRange(
                
                vendedores.Select(v => new Datos.Modelos.VendedoresModel
                {
                    Apellido = v.Apellido, 
                    Ciudad =                  
                    new Datos.Modelos.CiudadModel {
                        CiudadId = v.Ciudad.CiudadId, 
                    Codigo = v.Ciudad.Codigo, 
                    Nombre = v.Ciudad.Nombre,
                    }, CiudadId = v.CiudadId, 
                    Codigo = v.Codigo,
                    Nombre= v.Nombre, 
                    Numero_Identificacion = v.Numero_Identificacion, 
                    VendedorId =v.VendedorId, 
                }
                ).ToList());

            List<Datos.Modelos.ComboModel> combo = new List<Datos.Modelos.ComboModel>();
            combo.AddRange(ciudadesTodas.Select(c => new Datos.Modelos.ComboModel
                {
                    Id = c.CiudadId.ToString(),
                    Nombre = c.Nombre,
                }).ToList()
                );
            modelo.Combosciudad = combo;
           // modelo.listaCiudades = new SelectList(combo, "Id", "Nombre");
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

                        foreach (var vendedor in modelo.vendedores)
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