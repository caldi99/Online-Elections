using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Risultati : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OleDbConnection conn = new OleDbConnection(Application["ConnectionString"].ToString());
        string queryCamera ="select Coalizione.Nome as NomeCoalizione,T1.NomePartito,T1.VotiPartito,T1.VotiTotali,T1.PercentualeVoti from (select Partito.Nome as NomePartito,T.VotiPartito,T.VotiTotali,T.PercentualeVoti,Partito.FkIdCoalizione from (select V.FkIdPartito ,count(*) as VotiPartito ,(select count(*) from Voti where Voti.TipoVoto='Camera') As VotiTotali,(VotiPartito/VotiTotali)*100 as PercentualeVoti from Voti as V where V.TipoVoto='Camera' group by(V.FkIdPArtito)) as T left outer join Partito on T.FkIdPartito=Partito.Id) as T1 left outer join Coalizione on T1.FkIdCoalizione = Coalizione.Id";
        string querySenato = "select Coalizione.Nome as NomeCoalizione,T1.NomePartito,T1.VotiPartito,T1.VotiTotali,T1.PercentualeVoti from (select Partito.Nome as NomePartito,T.VotiPartito,T.VotiTotali,T.PercentualeVoti,Partito.FkIdCoalizione from (select V.FkIdPartito ,count(*) as VotiPartito ,(select count(*) from Voti where Voti.TipoVoto='Senato') As VotiTotali,(VotiPartito/VotiTotali)*100 as PercentualeVoti from Voti as V where V.TipoVoto='Senato' group by(V.FkIdPArtito)) as T left outer join Partito on T.FkIdPartito=Partito.Id) as T1 left outer join Coalizione on T1.FkIdCoalizione = Coalizione.Id";
        RisultatiCamera.DataSource = GetTabella(queryCamera, conn);
        RisultatiSenato.DataSource = GetTabella(querySenato, conn);
        RisultatiCamera.DataBind();
        RisultatiSenato.DataBind();        
    }
    public DataTable GetTabella(string query,OleDbConnection conn)
    {
        DataTable dt = new DataTable();
        DataRow riga;

        DataColumn col = new DataColumn();
        col.ColumnName = "NomePartito";
        col.DataType = typeof(string);
        dt.Columns.Add(col);

        col = new DataColumn();
        col.ColumnName = "NomeCoalizione";
        col.DataType = typeof(string);
        dt.Columns.Add(col);

        col = new DataColumn();
        col.ColumnName = "VotiPartito";
        col.DataType = typeof(int);
        dt.Columns.Add(col);

        col = new DataColumn();
        col.ColumnName = "VotiTotali";
        col.DataType = typeof(int);
        dt.Columns.Add(col);

        col = new DataColumn();
        col.ColumnName = "PercentualeVoti";
        col.DataType = typeof(double);
        dt.Columns.Add(col);

       
        OleDbCommand cmd = new OleDbCommand(query, conn);
        conn.Open();
        OleDbDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            riga = dt.NewRow();
            if (dr["NomePartito"].ToString() != "")
                riga["NomePartito"] = dr["NomePartito"];
            else
                riga["NomePartito"] = "Voti Nulli";
            riga["NomeCoalizione"] = dr["NomeCoalizione"];
            riga["VotiPartito"] = dr["VotiPartito"];
            riga["VotiTotali"] = dr["VotiTotali"];
            riga["PercentualeVoti"] = Math.Round((double)dr["PercentualeVoti"],3);
            dt.Rows.Add(riga);
        }
        dr.Close();
        conn.Close();
        return dt;
    }
    protected void home_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Server.Transfer("Index.aspx");
    }
}