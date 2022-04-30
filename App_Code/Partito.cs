using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per RigaScheda
/// </summary>
public class Partito
{
    public string TipoElezioni { get; set; }
    public int IdPartito { get; set; }
    public string NomePartito { get; set; }
    public string NomeCoalizione { get; set; }
    public string PercorsoLogo { get; set; }
    public List<Candidato> ListaCandidati 
    { 
        get
        {
            return CandidatoDataAccessLayer.GetAllCandidatiPerPartito(this.IdPartito, this.TipoElezioni);
        }
    }       
}

