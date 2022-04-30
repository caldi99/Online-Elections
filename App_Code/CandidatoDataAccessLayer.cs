using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per CandidatoDataAccessLayer
/// </summary>
public class CandidatoDataAccessLayer
{
    public static List<Candidato> GetAllCandidatiPerPartito(int IdPartito, string tiposcheda)
    {
        List<Candidato> candidati = new List<Candidato>();
        Candidato candidato;
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\user\Desktop\Nuova cartella\Database\Votazioni.accdb");
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;
        cmd.Parameters.Add("@IdPartito", OleDbType.Integer);
        cmd.Parameters.Add("@TipoScheda", OleDbType.VarChar);
        cmd.Parameters["@IdPartito"].Value = IdPartito;
        cmd.Parameters["@TipoScheda"].Value = tiposcheda;
        cmd.CommandText = "select Nome,Cognome,DataNascita,PercorsoFoto from Candidato where FkIdpartito = ? and TipoCandidato = ?";
        conn.Open();
        OleDbDataReader dr = cmd.ExecuteReader();
        while(dr.Read())
        {
            candidato = new Candidato();
            candidato.Nome = dr["Nome"].ToString();
            candidato.Cognome = dr["Cognome"].ToString();
            candidato.DataNascita = dr["DataNascita"].ToString().Substring(0,10);
            candidato.PercorsoFoto = dr["PercorsoFoto"].ToString();
            candidati.Add(candidato);
        }
        dr.Close();
        conn.Close();
        return candidati;
    }
}