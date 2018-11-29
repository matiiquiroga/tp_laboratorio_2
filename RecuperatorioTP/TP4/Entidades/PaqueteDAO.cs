﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand _comando;
        private static SqlConnection _conexion;

        static PaqueteDAO()
        {
            _conexion = new SqlConnection(Properties.Settings.Default.conexion);
            _comando = new SqlCommand();
        }

        public static bool Insertar(Paquete p)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("insert into Paquetes values('{0}','{1}','Matias Quiroga')", p.DireccionEntrega, p.TrackingID);

                _comando.CommandText = sb.ToString();
                _comando.CommandType = System.Data.CommandType.Text;
                _comando.Connection = _conexion;

                _conexion.Open();

                _comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _conexion.Close();
            }
        }

    }
}
