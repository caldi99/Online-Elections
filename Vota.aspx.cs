using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vota : System.Web.UI.Page
{
    ControllaDate controlla;
    OleDbConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new OleDbConnection(Application["ConnectionString"].ToString());
        controlla = new ControllaDate();
        if (Session["CodiceFiscale"] != null)
        {
            if(!ControllaVoto(Session["CodiceFiscale"].ToString(),conn))
            {
                if (controlla.ControllaData(Convert.ToInt32(Session["DataNascita"].ToString().Substring(0, 2)), Convert.ToInt32(Session["DataNascita"].ToString().Substring(3, 2)), Convert.ToInt32(Session["DataNascita"].ToString().Substring(6, 4)), 25))
                {
                    TabellaSchedaSenato.DataSource = PartitoDataAccessLayer.GetAllPartiti("Senato");
                    TabellaSchedaSenato.DataBind();
                }
                else
                {
                    CellaSenato1.Visible = false;
                    CellaSenato2.Visible = false;
                    CellaSenato3.Visible = false;
                    CellaSenato4.Visible = false;
                    TabellaSchedaCamera.HorizontalAlign = HorizontalAlign.Center;
                }
                TabellaSchedaCamera.DataSource = PartitoDataAccessLayer.GetAllPartiti("Camera");
                TabellaSchedaCamera.DataBind();
                
            }else
            {
                Informazioni.Text = "HAI GIA' VOTATO !";
                Table1.Visible = false;
                VisualizzaRisultati.Visible = true;
                Home.Visible = true;
                btnConferma.Visible = false;
            }
        }
        else
            Server.Transfer("Index.aspx");
    }    

    protected void Tabella_SelectedIndexChanged(object sender, EventArgs e)
    {
        string tiposcheda;
        if((sender as GridView).ID == "TabellaSchedaSenato")
            tiposcheda="Senato";
        else
            tiposcheda="Camera";
        if (ViewState["Voto"+tiposcheda] == null)
        {
            ViewState["Voto" + tiposcheda] = new Voto();
        }
        Voto v = (Voto)ViewState["Voto" + tiposcheda];
        v.CodiceFiscale = Session["CodiceFiscale"].ToString();
        List<Partito> l = PartitoDataAccessLayer.GetAllPartiti(tiposcheda);
        v.IdPartito = Convert.ToInt32(l[(sender as GridView).SelectedIndex].IdPartito);
        v.TipoVoto = tiposcheda;
    }
    protected void btnConferma_Click(object sender, EventArgs e)
    {
                      
        if (controlla.ControllaData(Convert.ToInt32(Session["DataNascita"].ToString().Substring(0, 2)), Convert.ToInt32(Session["DataNascita"].ToString().Substring(3, 2)), Convert.ToInt32(Session["DataNascita"].ToString().Substring(6, 4)), 25))
        {
            InsertVoto("Senato", conn);
        }
        InsertVoto("Camera", conn);
        Server.Transfer("Risultati.aspx");
    }
    public void InsertVoto(string tipoVoto,OleDbConnection conn)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;
        conn.Open();
        cmd.Parameters.Add("@CodiceFiscale", OleDbType.VarChar);
        cmd.Parameters.Add("@TipoVoto", OleDbType.VarChar);
        cmd.Parameters.Add("@IdPartito", OleDbType.Integer);
        if (ViewState["Voto"+tipoVoto] == null)
        {
            cmd.Parameters["@CodiceFiscale"].Value = Session["CodiceFiscale"];
            cmd.Parameters["@TipoVoto"].Value = tipoVoto;
            cmd.CommandText = "insert into Voti (FkUtente,TipoVoto) values (?,?)";
        }
        else
        {
            cmd.Parameters["@CodiceFiscale"].Value = ((Voto)ViewState["Voto" + tipoVoto]).CodiceFiscale;
            cmd.Parameters["@TipoVoto"].Value = ((Voto)ViewState["Voto" + tipoVoto]).TipoVoto;
            cmd.Parameters["@IdPartito"].Value = ((Voto)ViewState["Voto" + tipoVoto]).IdPartito;
            cmd.CommandText = "insert into Voti (FkUtente,TipoVoto,FkIdPartito) values (?,?,?)";
        }
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    public bool ControllaVoto(string CodiceFiscale,OleDbConnection conn)
    {
        bool ritorno = false;
        OleDbCommand cmd = new OleDbCommand("select * from Voti where FkUtente = ?", conn);
        cmd.Parameters.Add("@CodiceFiscale", OleDbType.VarChar);
        cmd.Parameters["@CodiceFiscale"].Value = CodiceFiscale;
        conn.Open();
        OleDbDataReader dr = cmd.ExecuteReader();
        if(dr.Read())
        {
            ritorno = true;
        }
        dr.Close();
        conn.Close();
        return ritorno;
    }
    protected void Home_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Server.Transfer("Index.aspx");
    }
    protected void VisualizzaRisultati_Click(object sender, EventArgs e)
    {
        Server.Transfer("Risultati.aspx");
    }
}
