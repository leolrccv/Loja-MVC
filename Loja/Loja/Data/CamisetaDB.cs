using Loja.Util;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teste.Models;

namespace Teste.Data {
    public class CamisetaDB {
        private static ConnectionDB _conn;

        public void Insert(Camiseta camiseta) {
            var query = $"INSERT INTO CAMISETA VALUES ('{camiseta.Modelo}', '{camiseta.Tamanho}')";

            using (_conn = new ConnectionDB()) {
                _conn.ExecQuery(query);
            }
        }

        public List<Camiseta> Select() {
            var query = $"SELECT * FROM CAMISETA";
            using (_conn = new ConnectionDB()) {
                var returnData = _conn.ExecQueryReturn(query);
                return TransformDataReaderToList(returnData);
            }
        }

        public Camiseta SelectById(int id) {
            var query = $"SELECT * FROM CAMISETA WHERE ID = {id}";

            using (_conn = new ConnectionDB()) {
                var returnData = _conn.ExecQueryReturn(query);
                return TransformDataReaderToList(returnData)[0];
            }
        }

        public void Update(Camiseta camiseta) {
            var query = $"UPDATE CAMISETA SET MODELO = '{camiseta.Modelo}', TAMANHO = '{camiseta.Tamanho}' WHERE ID = {camiseta.Id}";

            using (_conn = new ConnectionDB()) {
                _conn.ExecQuery(query);
            }
        }

        public void Delete(int id) {
            var query = $"DELETE FROM CAMISETA WHERE ID = {id}";

            using (_conn = new ConnectionDB()) {
                _conn.ExecQuery(query);
            }
        }

        public List<Camiseta> TransformDataReaderToList(SqlDataReader returnData) {
            var list = new List<Camiseta>();

            while (returnData.Read()) {
                var item = new Camiseta() {
                    Id = int.Parse(returnData["Id"].ToString()),
                    Modelo = returnData["Modelo"].ToString(),
                    Tamanho = returnData["Tamanho"].ToString()
                };
                list.Add(item);
            }
            return list;
        }
    }
}