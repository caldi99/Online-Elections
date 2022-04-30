using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        
    }
    protected void btnAccedi_Click(object sender, EventArgs e)
    {
        if (Email.Text != "" && Password.Text != "")
        {
            OleDbConnection conn = new OleDbConnection(Application["ConnectionString"].ToString());
            OleDbCommand cmd = new OleDbCommand();

            //definizione parametri            
            cmd.Parameters.Add(new OleDbParameter("@email", OleDbType.VarChar, 50));
            cmd.Parameters.Add(new OleDbParameter("@password", OleDbType.VarChar, 50));

            //settaggio parametri
            cmd.Parameters["@email"].Value = Email.Text;
            cmd.Parameters["@password"].Value = Password.Text;
            cmd.CommandText = "select * from Utente where Email = ? and Pass = ?";

            cmd.Connection = conn;
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                Session["CodiceFiscale"] = dr["CodiceFiscale"];
                Session["DataNascita"] = dr["DataNascita"];
                Server.Transfer("Vota.aspx"); 
            }                       
        }
    }
}