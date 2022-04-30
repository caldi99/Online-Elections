using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per ControllaDate
/// </summary>
public class ControllaDate
{
    int giornoCorrente;
    int meseCorrente;           
    int annoCorrente;
	public ControllaDate()
	{
        giornoCorrente = DateTime.Today.Day;
        meseCorrente = DateTime.Today.Month;
        annoCorrente = DateTime.Today.Year;
	}

    public bool ControllaData(int giorno,int mese,int anno,int nAnni)
    {
        int annoMinimo = annoCorrente - nAnni;
        bool ritorno;
        if (anno < annoMinimo)
            ritorno = true;
        else if (anno == annoMinimo)
        {
            if (mese < meseCorrente)
                ritorno = true;
            else if (mese == meseCorrente)
            {
                if (giorno <= giornoCorrente)
                    ritorno = true;
                else
                    ritorno = false;
            }
            else
                ritorno = false;
        }
        else
            ritorno = false;
        return ritorno;
    }
}