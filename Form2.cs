using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLKOMUT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            /*
           * string Contact = "Select Phone from Person.Contact union all Select Name from Production.Product";
          SqlDataAdapter da = new SqlDataAdapter(Contact, conn);
          DataSet ds = new DataSet();

          da.Fill(ds, "Person.Contact");
          da.Fill(ds, "Production.Product");

          dataGridView1.DataSource = ds.Tables["Person.Contact"];
          dataGridView1.DataSource = ds.Tables["Production.Product"];
           */
            //birden fazla tabloda işlemde önce union all yaptı!!
        }
    }
}
