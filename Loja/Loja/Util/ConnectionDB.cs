using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Loja.Util {
    public class ConnectionDB : IDisposable {
        private static SqlConnection _conn;
        private static SqlCommand _cmd;

        public ConnectionDB() {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString);
            _conn.Open();
        }

        public void ExecQuery(string query) {
            _cmd = new SqlCommand(query, _conn);
            _cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecQueryReturn(string query) {
            _cmd = new SqlCommand(query, _conn);
            return _cmd.ExecuteReader();
        }

        public void Dispose() {
            if (_conn.State == ConnectionState.Open) {
                _conn.Close();
                _conn.Dispose();
            }
        }
    }
}