using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DatosDropDownList
    {
        private readonly AccesoDatos ad = new AccesoDatos(); 
        //-----------------------------------------------------------------------------------------------------------------------------------------------ALTA
        public List<Genero> ObtenerGeneros()
        {
            List<Genero> generos = new List<Genero>();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT IdGenero_g, Descripcion_g FROM Generos");
            DataTable dt = ad.ObtenerTablaConComando("Generos", cmd);

            foreach (DataRow row in dt.Rows)
            {
                generos.Add(new Genero
                {
                    IdGenero_g = Convert.ToInt32(row["IdGenero_g"]),
                    Descripcion = row["Descripcion_g"].ToString()
                });
            }

            return generos;
        }

        public List<Especialidad> ObtenerEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT IdEspecialidad_esp, Nombre_esp from Especialidades");
            DataTable dt = ad.ObtenerTablaConComando("Especialidades", cmd);

            foreach (DataRow row in dt.Rows)
            {
                especialidades.Add(new Especialidad
                {
                    IdEspecialidad_esp = Convert.ToInt32(row["IdEspecialidad_esp"]),
                    Descripcion = row["Nombre_esp"].ToString()
                });
            }

            return especialidades;
        }

        public List<Pais> ObtenerPaises()
        {
            List<Pais> paises = new List<Pais>();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT IdPais_p, Nombre_pais FROM Paises");
            DataTable dt = ad.ObtenerTablaConComando("Paises", cmd);

            foreach (DataRow row in dt.Rows)
            {
                paises.Add(new Pais
                {
                    IdPais_p = Convert.ToInt32(row["IdPais_p"]),
                    Descripcion = row["Nombre_pais"].ToString()
                });
            }

            return paises;
        }

        public List<Provincia> ObtenerProvincias()
        {
            List<Provincia> provincias = new List<Provincia>();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT IdProvincia_prov, Nombre_prov FROM Provincias");
            DataTable dt = ad.ObtenerTablaConComando("Provincias", cmd);

            foreach (DataRow row in dt.Rows)
            {
                provincias.Add(new Provincia
                {
                    IdProvincia_prov = Convert.ToInt32(row["IdProvincia_prov"]),
                    Descripcion = row["Nombre_prov"].ToString()
                });
            }

            return provincias;
        }

        public List<Localidad> ObtenerLocalidadesPorProvincia(int IdProvincia)
        {
            List<Localidad> localidades = new List<Localidad>();
            string consulta = "SELECT IdLocalidad_loc, Nombre_loc FROM Localidades WHERE IdProvincia_loc = @IdProvincia";
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@IdProvincia", IdProvincia);

            DataTable dt = ad.ObtenerTablaConComando("Localidades", cmd);

            foreach (DataRow row in dt.Rows)
            {
                localidades.Add(new Localidad
                {
                    IdLocalidad_loc = Convert.ToInt32(row["IdLocalidad_loc"]),
                    Descripcion = row["Nombre_loc"].ToString()
                });
            }

            return localidades;
        }
    }
}