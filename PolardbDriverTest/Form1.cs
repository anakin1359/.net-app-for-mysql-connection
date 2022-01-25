using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PolardbDriverTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			StartPosition = FormStartPosition.CenterScreen;
		}

		private void DataTableReadButton_Click(object sender, EventArgs e)
		{
			// 本番環境模倣
			// MySQL接続用
			//string connStr = "server=polardb-mysql-dev.rwlb.singapore.rds.aliyuncs.com;user id=snadmin;password=Gorilla0#;database=isono_database";
			//MySqlConnection connection = new MySqlConnection(connStr);

			// 検証用
			var builder = new MySqlConnectionStringBuilder();
			builder.Server = "polardb-mysql-dev.rwlb.singapore.rds.aliyuncs.com";
			builder.Database = "isono_database";
			builder.UserID = "snadmin";
			builder.Password = "Gorilla0#";
			//builder.IntegratedSecurity = true;
			var ConnectionString = builder.ToString();

			var sql = @"select * from gorilla_table";

			DataTable dataTable = new DataTable();
			using (var connection = new MySqlConnection(ConnectionString))
			using (var adapter = new MySqlDataAdapter(sql, connection))
			{
				connection.Open();
				adapter.Fill(dataTable);
			}
			
			dataGridView1.DataSource = dataTable;
		}
	}
}
