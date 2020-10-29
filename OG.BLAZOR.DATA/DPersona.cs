using OG.BLAZOR.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace OG.BLAZOR.DATA
{
    public class DPersona
    {
        string cadenaConexion = "Server=(local); Database=Ronaldo; User Id=sa; Password=12345";
        SqlConnection connection;

        public async Task<DataTable> GetPersonas()
        {
            DataTable dt = new DataTable();
            try
            {
                connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_Persona_CON", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("DPersona GetPersonas: " + ex.Message);
            }
            return await Task.FromResult(dt);
        }
        public async Task<DataRow> GetPersona(int Id)
        {
            DataRow r;
            try
            {
                #region SQL
                connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_Persona_Id", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = Id });
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                connection.Close();
                r = dt.Rows[0];
                #endregion
            }
            catch (Exception ex)
            {
                r = new DataTable().NewRow();
                throw new ApplicationException("DPersona GetPersona: " + ex.Message);
            }
            return await Task.FromResult(r);
        }
        public async Task<int> Ingresar(EPersona persona)
        {
            int commandResult = 0;
            try
            {
                connection = new SqlConnection(cadenaConexion);
                connection.Open();
                string insertStatement = "SP_Persona_INS";
                SqlCommand command = new SqlCommand(insertStatement, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = persona.Nombre });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@AP", SqlDbType = SqlDbType.VarChar, Value = persona.AP });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@AM", SqlDbType = SqlDbType.VarChar, Value = persona.AM });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Edad", SqlDbType = SqlDbType.Int, Value = persona.Edad });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Estatura", SqlDbType = SqlDbType.Decimal, Value = persona.Estatura });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Peso", SqlDbType = SqlDbType.Decimal, Value = persona.Peso });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@FechaN", SqlDbType = SqlDbType.DateTime, Value = persona.FechaN });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Activo", SqlDbType = SqlDbType.Bit, Value = persona.Activo });
                commandResult = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                commandResult = 0;
                throw new ApplicationException("DPersona Ingresar: " + ex.Message);
            }
            return await Task.FromResult(commandResult);
        }
        public async Task<int> Modificar(EPersona persona)
        {
            int commandResult = 0;
            try
            {
                connection = new SqlConnection(cadenaConexion);
                connection.Open();
                string insertStatement = "SP_Persona_UPD";
                SqlCommand command = new SqlCommand(insertStatement, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = persona.Id });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = persona.Nombre });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@AP", SqlDbType = SqlDbType.VarChar, Value = persona.AP });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@AM", SqlDbType = SqlDbType.VarChar, Value = persona.AM });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Edad", SqlDbType = SqlDbType.Int, Value = persona.Edad });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Estatura", SqlDbType = SqlDbType.Decimal, Value = persona.Estatura });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Peso", SqlDbType = SqlDbType.Decimal, Value = persona.Peso });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@FechaN", SqlDbType = SqlDbType.DateTime, Value = persona.FechaN });
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Activo", SqlDbType = SqlDbType.Bit, Value = persona.Activo });
                commandResult = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                commandResult = 0;
                throw new ApplicationException("DPersona Modificar: " + ex.Message);
            }
            return await Task.FromResult(commandResult);
        }
        public async Task<int> Eliminar(EPersona persona)
        {
            int commandResult = 0;
            try
            {
                connection = new SqlConnection(cadenaConexion);
                connection.Open();
                string insertStatement = "SP_Persona_DEL";
                SqlCommand command = new SqlCommand(insertStatement, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.Input, ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = persona.Id });
                commandResult = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                commandResult = 0;
                throw new ApplicationException("DPersona Eliminar: " + ex.Message);
            }
            return await Task.FromResult(commandResult);
        }

    }
}
