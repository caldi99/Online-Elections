using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per PartitoDataAccessLayer
/// </summary>
public class PartitoDataAccessLayer
{
    public static List<Partito> GetAllPartiti(string tipoScheda)
    {
        List<Partito> lista = new List<Partito>();
        Partito partito;
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\user\Desktop\Nuova cartella\Database\Votazioni.accdb");
        OleDbCommand cmd = new OleDbCommand("select Partito.Id as IdPartito , Partito.Nome as NomePartito, Coalizione.Nome as NomeCoalizione, PercorsoSimbolo from Partito left join Coalizione on Partito.FkIdCoalizione = Coalizione.ID", conn);
        conn.Open();
        OleDbDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            partito = new Partito();
            partito.IdPartito = (int)dr["IdPartito"];
            partito.NomeCoalizione = dr["NomeCoalizione"].ToString();
            partito.NomePartito = dr["NomePartito"].ToString();
            partito.PercorsoLogo = dr["PercorsoSimbolo"].ToString();
            partito.TipoElezioni = tipoScheda;
            lista.Add(partito);
        }
        dr.Close();
        conn.Close();
        return lista;
    }
}