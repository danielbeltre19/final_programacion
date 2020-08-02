using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa1;
using System.Data;
using System.Data.SqlClient;

namespace capa2
{
  public class ventascapa2
    {

      public int AgregarVenta(ventas pventas) 
      {
          IDbConnection _conn = DB.Conexion();
          _conn.Open();
          SqlCommand _comand = new SqlCommand("AGREGAR_VENTAS", _conn as SqlConnection);
          _comand.CommandType = CommandType.StoredProcedure;
          _comand.Parameters.Add(new SqlParameter("@NOMBRE", pventas.Nombre));
          _comand.Parameters.Add(new SqlParameter("@Total_Ventas", pventas.TotalVentas));
          _comand.Parameters.Add(new SqlParameter("@ESTADO", pventas.Estado));
          int resultado = _comand.ExecuteNonQuery();
          _conn.Close();
          return resultado;

      
      }

      public List<ventas> MostrarVentas()
      {
          IDbConnection _conn = DB.Conexion();
          _conn.Open();
          SqlCommand _comand = new SqlCommand("CONSULTAR_VENTAS", _conn as SqlConnection);
          _comand.CommandType = CommandType.StoredProcedure;
          IDataReader _reader = _comand.ExecuteReader();
          List<ventas> Lista = new List<ventas>();
          while (_reader.Read())
          {
              ventas _ventas = new ventas();
              _ventas.Id = _reader.GetInt64(0);
              _ventas.Nombre = _reader.GetString(1);
              _ventas.TotalVentas = _reader.GetInt64(2);
              _ventas.Estado = _reader.GetString(3);
              Lista.Add(_ventas);
          }
          _conn.Close();
          return Lista;
      }

      public List<ventas> MostrarVentasNombre(ventas pventas)
      {
          IDbConnection _conn = DB.Conexion();
          _conn.Open();
          SqlCommand _comand = new SqlCommand("CONSULTAR_VENTAS_NOMBRE", _conn as SqlConnection);
          _comand.CommandType = CommandType.StoredProcedure;
          _comand.Parameters.Add(new SqlParameter("@NOMBRE", pventas.Nombre));
          IDataReader _reader = _comand.ExecuteReader();
          List<ventas> Lista = new List<ventas>();
          while (_reader.Read())
          {
              ventas _ventas = new ventas();
              _ventas.Id = _reader.GetInt64(0);
              _ventas.Nombre = _reader.GetString(1);
              _ventas.TotalVentas = _reader.GetInt64(2);
              _ventas.Estado = _reader.GetString(3);
              Lista.Add(_ventas);

          }
          _conn.Close();
          return Lista;
      }

      public int ModificarVentas(ventas pventas)
      {
          IDbConnection _conn = DB.Conexion();
          _conn.Open();
          SqlCommand _comand = new SqlCommand("MODIFICAR_VENTAS", _conn as SqlConnection);
          _comand.CommandType = CommandType.StoredProcedure;
          _comand.Parameters.Add(new SqlParameter("@ID", pventas.Id));
          _comand.Parameters.Add(new SqlParameter("@NOMBRE", pventas.Nombre));
          _comand.Parameters.Add(new SqlParameter("@Total_Ventas", pventas.TotalVentas));
          _comand.Parameters.Add(new SqlParameter("@ESTADO", pventas.Estado));
          int resultado = _comand.ExecuteNonQuery();
          _conn.Close();
          return resultado;

      }

      public int EliminarVentas(ventas pventas)
      {
          IDbConnection _conn = DB.Conexion();
          _conn.Open();
          SqlCommand _comand = new SqlCommand("ELIMINAR_VENTAS", _conn as SqlConnection);
          _comand.CommandType = CommandType.StoredProcedure;
          _comand.Parameters.Add(new SqlParameter("@ID", pventas.Id));
          int resultado = _comand.ExecuteNonQuery();
          _comand.Clone();
          return resultado;


      }


    }
}
