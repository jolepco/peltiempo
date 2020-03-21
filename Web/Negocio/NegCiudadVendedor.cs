using System;
using System.Collections.Generic;

namespace Web.Negocio
{
    public class NegCiudadVendedor
    {
        #region ciudad
        /// <summary>
        /// Obtiene todas las ciudades
        /// </summary>
        /// <returns>lista de ciudades</returns>
        public async System.Threading.Tasks.Task<List<Datos.Entidades.Ciudad>> ObtenerTodaslasCiudades()
        {
            try
            {
                System.Threading.Tasks.Task<List<Datos.Entidades.Ciudad>> resultado = new AccesoDatos.CiudadVendedor().listarCiudades();
                return await resultado;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Elimina ciudad
        /// </summary>
        /// <param name="ciudad">ciudad</param>
        /// <returns>valida si lo elimino o no</returns>
        public async System.Threading.Tasks.Task<bool> EliminarCiudad(int ciudad)
        {
            try
            {
                System.Threading.Tasks.Task<bool> resultado = new AccesoDatos.CiudadVendedor().EliminarCiudad(ciudad);
                return await resultado;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Vendedor
        /// <summary>
        /// Obtiene un vendedor
        /// </summary>
        /// <param name="vendedor">id</param>
        /// <returns>entida de vendedor</returns>
        public async System.Threading.Tasks.Task<Datos.Entidades.Vendedor> ObtenerunVendedor(int vendedor)
        {
            try
            {
                System.Threading.Tasks.Task<Datos.Entidades.Vendedor> resultado = new AccesoDatos.CiudadVendedor().listarunVendedor(vendedor);
                return await resultado;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Elimina un vendedor
        /// </summary>
        /// <param name="vendedor">id</param>
        /// <returns>retorna respuesta </returns>
        public async System.Threading.Tasks.Task<bool> EliminarVendedor(int vendedor)
        {
            try
            {
                System.Threading.Tasks.Task<bool> resultado = new AccesoDatos.CiudadVendedor().EliminarVendedor(vendedor);
                return await resultado;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Modelo

        /// <summary>
        /// obtiene modelo completo 
        /// </summary>
        /// <param name="ciudad">idciudad</param>
        /// <returns>modelo</returns>
        public async System.Threading.Tasks.Task<Models.ModeloCompleto> ObtenerunCiudadVendedor(int ciudad)
        {
            try
            {
                System.Threading.Tasks.Task<Models.ModeloCompleto> resultado = new AccesoDatos.CiudadVendedor().ObtenerTodoModeloAsing(ciudad);
                return await resultado;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region transaccion 

        /// <summary>
        /// guardar modelo completo
        /// </summary>
        /// <param name="modelo">modelo</param>
        /// <returns>true o false</returns>
        public async System.Threading.Tasks.Task<bool> GuardarCiudadVendedor(Models.ModeloCompleto modelo)
        {
            try
            {
                System.Threading.Tasks.Task<bool> resultado = new AccesoDatos.CiudadVendedor().GuardarTransaccionAsing(modelo);
                return await resultado;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}