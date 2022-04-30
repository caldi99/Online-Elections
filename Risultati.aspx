<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Risultati.aspx.cs" Inherits="Risultati" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Risultati Elezioni</title>
     <style>
        @import url(Css/class.css);
        @import url(Css/style.css);
    </style>
</head>
<body>
    <center>
        <h1 class="Titolo">RISULTATI ELEZIONI</h1>
    </center>
    <form id="form1" runat="server">       
        <ul>
             <li><asp:Button ID="home" runat="server" Text="Home" OnClick="home_Click"  CssClass="ButtonAsp"/></li>
        </ul>
        <br />
        <center>
            <table class="Risultati">
            <tr>
                <td class="Risultati">
                    <h1 class="Sottotitolo">
                        RISULTATI CAMERA DEI DEPUTATI
                    </h1>
                </td>
                <td class="Risultati">
                    <h1 class="Sottotitolo">
                        RISULTATI SENATO
                    </h1>
                </td>
            </tr>
            <tr>
                <td class="Risultati">
                    <asp:GridView ID="RisultatiCamera" runat="server" HorizontalAlign="Center">
                        <HeaderStyle BackColor="#DDB104" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#FFCC00" BorderStyle="Solid" BorderWidth="3px" />
                        <RowStyle BackColor="#FFFF80" ForeColor="#333333" Font-Names="" BorderColor="#FFCC00" BorderStyle="Solid" BorderWidth="3px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                </td>
                <td class="Risultati">
                    <asp:GridView ID="RisultatiSenato" runat="server" HorizontalAlign="Center">
                        <HeaderStyle BackColor="#BF5BAE" BorderColor="#D975D7" BorderStyle="Solid" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <RowStyle BackColor="#FEBCF4" BorderColor="#D975D7" BorderWidth="3px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                </td>
            </tr>
            </table>
        </center>
    </form>
</body>
</html>
