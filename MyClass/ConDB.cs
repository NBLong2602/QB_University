using MySql.Data.MySqlClient;
using System.Data;

namespace QB_University.MyClass
{
    public class ConDB
    {
        private string ConString = "Server=localhost;username=root;password=;Database=trangadmin;";
        public MySqlConnection myConnection;

        public ConDB()
        {
            myConnection = new MySqlConnection(ConString);
            myConnection.Open();
        }

         public DataTable GetData(string _sqlCommand) {
            MySqlCommand cmd = new MySqlCommand(_sqlCommand, myConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public void ExecuteQuery(string _sqlCommand)
        {
            MySqlCommand cmd = new MySqlCommand( _sqlCommand, myConnection);
            cmd.CommandText = _sqlCommand;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;
            cmd.ExecuteNonQuery();
        }
    }
}
