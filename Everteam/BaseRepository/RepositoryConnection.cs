using Everteam.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Everteam.BaseRepository
{
    public class RepositoryConnection : IRepositoryConnection
    {
        private readonly IConfiguration _configuration;

        public RepositoryConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection Connection()
        {
            SqlConnection _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return _connection;
        }

        public int InsertCommand(string procedure, Dictionary<string, string> parameters)
        {
            int id;
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

                foreach (var value in parameters)
                {
                    cmd.Parameters.AddWithValue(value.Key, value.Value);
                }

                cmd.Connection = Connection();
                cmd.Connection.Open();

                id = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Connection.Close();
                cmd.Dispose();

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SearchCommand(string procedure, Dictionary<string, string> parameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

                foreach(var value in parameters)
                {
                    cmd.Parameters.AddWithValue(value.Key, value.Value);
                }

                cmd.Connection = Connection();
                cmd.Connection.Open();

                SqlDataReader dataReader = cmd.ExecuteReader();

                var dataTable = new DataTable();
                dataTable.Load(dataReader);

                dataReader.Close();
                dataReader.Dispose();

                cmd.Connection.Close();
                cmd.Dispose();

                return JsonConvert.SerializeObject(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SimpleExecuteCommand(string procedure, Dictionary<string, string> parameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

                foreach (var value in parameters)
                {
                    cmd.Parameters.AddWithValue(value.Key, value.Value);
                }

                cmd.Connection = Connection();
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();

                cmd.Connection.Close();
                cmd.Dispose();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
