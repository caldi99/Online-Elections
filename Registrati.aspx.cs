using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registrati : System.Web.UI.Page
{
    ControllaDate controlla;
    protected void Page_Load(object sender, EventArgs e)
    {
        controlla = new ControllaDate();
    }
    protected void btnRegistarti_Click(object sender, EventArgs e)
    {
        if (CodiceFiscale.Text != "" && CodiceFiscale.Text.Length == 16 && Nome.Text != "" && Cognome.Text != "" && Email.Text != "" && Password.Text != "" && DataNascita.Text != "" && 
            controlla.ControllaData(Convert.ToInt32(DataNascita.Text.Substring(8,2)),Convert.ToInt32(DataNascita.Text.Substring(5,2)),Convert.ToInt32(DataNascita.Text.Substring(0,4)),18))
        {
            OleDbConnection conn = new OleDbConnection(Application["ConnectionString"].ToString());
            OleDbCommand cmd = new OleDbCommand();

            //definizione parametri
            cmd.Parameters.Add(new OleDbParameter("@codicefiscale", OleDbType.VarChar, 16));
            
            //settaggio parametri
            cmd.Parameters["@codicefiscale"].Value = CodiceFiscale.Text;
            
            cmd.CommandText="select count(*) from Utente where CodiceFiscale = ?";
            cmd.Connection = conn;

            conn.Open();                       
            int x = (int)cmd.ExecuteScalar();
            conn.Close();

            if(x == 0)
            {
                //definizione parametri
                cmd.Parameters.Add(new OleDbParameter("@nome", OleDbType.VarChar, 50));
                cmd.Parameters.Add(new OleDbParameter("@cognome", OleDbType.VarChar, 50));
                cmd.Parameters.Add(new OleDbParameter("@email", OleDbType.VarChar, 50));
                cmd.Parameters.Add(new OleDbParameter("@pass", OleDbType.VarChar, 50));
                cmd.Parameters.Add(new OleDbParameter("@datanascita", OleDbType.DBDate));

                //settaggio parametri
                cmd.Parameters["@nome"].Value = Nome.Text;
                cmd.Parameters["@cognome"].Value = Cognome.Text;
                cmd.Parameters["@email"].Value = Email.Text;
                cmd.Parameters["@pass"].Value = Password.Text;
                cmd.Parameters["@datanascita"].Value = DataNascita.Text;

                cmd.CommandText = "Insert Into Utente (CodiceFiscale,Nome,Cognome,Email,Pass,DataNascita) Values (?,?,?,?,?,?)";
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Server.Transfer("Index.aspx");
            }
        }
    }
   
    protected void Home_Click(object sender, EventArgs e)
    {
        Server.Transfer("Index.aspx");
    }
}