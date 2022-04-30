using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per Voto
/// </summary>
[Serializable]
public class Voto
{
    public string CodiceFiscale{ get; set;}
    public string TipoVoto { get; set;}
    public int IdPartito{ get; set;}
	
}