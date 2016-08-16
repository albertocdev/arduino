using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Arduino
{
    class dbConnection
    {
        private MySqlConnection sqlConnection;
        private MySqlCommand command;
        public MySqlDataReader reader;
        public void connect()
        {
            sqlConnection = new MySqlConnection();
            sqlConnection.ConnectionString = "server=localhost; database=arduino; Uid=root; pwd=undefined";
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con el servidor, intente de nuevo.");
                return;
            }
        }

        public void disconnect()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            
        }

        public void ExecuteReader(string sql)
        {
            try
            {
                command = new MySqlCommand();
                command.CommandText = sql;
                command.Connection = sqlConnection;
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron obtener los datos, intente de nuevo.");
            }
        }

        public void executeSql(string sql)
        {
            try
            {
                command = new MySqlCommand();
                command.CommandText = sql;
                command.Connection = sqlConnection;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(" -> Fallo al Ejecutar la Consulta SQL: " + ex.Message);
            }
        }

        public MySqlDataReader getReader
        {
            get
            {
                return reader;
            }

        }
    }
}
