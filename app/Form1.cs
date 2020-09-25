using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void order_dBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.order_dBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tSOOPEXDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void order_dDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ConnectionStringSettingsCollection sett = ConfigurationManager.ConnectionStrings;
            string conStr = sett[0].ConnectionString;
            SqlConnection Connection = new SqlConnection(conStr);

            SqlCommand sql = new SqlCommand();

            sql.Connection = Connection;
            Connection.Open();
            sql.CommandText = "select * from [TSOOPEX].dbo.order_d";
            Connection.Close();
        }
    }
}
