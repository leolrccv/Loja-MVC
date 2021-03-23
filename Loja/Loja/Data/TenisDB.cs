using Loja.Models;
using Loja.Util;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Loja.Data {
    public class TenisDB {
        private static ConnectionDB _conn;

        public void Insert(Tenis tenis) {
            var query = $"INSERT INTO TENIS VALUES ('{tenis.Nome}', {tenis.Tamanho})";
            using (_conn = new ConnectionDB()) {
                _conn.ExecQuery(query);
            }
        }

        public List<Tenis> Select() {
            var query = $"SELECT * FROM TENIS";
            using (_conn = new ConnectionDB()) {
                var returnData = _conn.ExecQueryReturn(query);
                return TransformSQLReaderToList(returnData);
            }
        }

        public Tenis SelectById(int id) {
            var query = $"SELECT * FROM TENIS WHERE ID = {id}";

            using (_conn = new ConnectionDB()) {
                var returnData = _conn.ExecQueryReturn(query);
                return TransformSQLReaderToList(returnData)[0];
            }
        }

        public void Update(Tenis tenis) {
            var query = $"UPDATE TENIS SET NOME = '{tenis.Nome}', TAMANHO = {tenis.Tamanho} WHERE ID = {tenis.Id}";

            using (_conn = new ConnectionDB()) {
                _conn.ExecQuery(query);
            }

        }

        public void Delete(int id) {
            var query = $"DELETE FROM TENIS WHERE Id = {id}";

            using (_conn = new ConnectionDB()) {
                _conn.ExecQuery(query);
            }
        }

        private List<Tenis> TransformSQLReaderToList(SqlDataReader returnData) {
            var list = new List<Tenis>();

            while (returnData.Read()) {
                var item = new Tenis {
                    Id = int.Parse(returnData["Id"].ToString()),
                    Nome = returnData["Nome"].ToString(),
                    Tamanho = float.Parse(returnData["Tamanho"].ToString())
                };
                list.Add(item);
            }
            return list;
        }
    }
}