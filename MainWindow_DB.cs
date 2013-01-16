using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtQ.FormFiles;
using System.Data.SqlClient;
using ThoughtQ.Data;

namespace ThoughtQ
{
    public partial class MainWindow : Form
    {
        private String sql_Server = "lonelydev.dyndns.org";
        private String sql_User = "jdipierro";
        private String sql_Password = "am633kqw5C";
        private String sql_dbName = "thought_db";
        private String sql_tableName = "thoughts";

        SqlConnection connection;

        private void sql_connect()
        {
            if (connection == null)
            {
                connection = new SqlConnection("user id=" + sql_User + ";" +
                                       "password=" + sql_Password + ";server=" + sql_Server + ";" +
                                       "Trusted_Connection=yes;" +
                                       "database=" + sql_dbName + "; " +
                                       "connection timeout=30");
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

    }
}
