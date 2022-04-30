<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registrati.aspx.cs" Inherits="Registrati" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registrati</title>
    <style>
        @import url(Css/class.css);
        @import url(Css/style.css);
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <center>
             <h1 class="Titolo">
                 REGISTRATI
             </h1>
        </center>
        <ul>
             <li><asp:Button id="Home" runat="server" Text="Home" OnClick="Home_Click" CssClass="ButtonAsp"/></li>
        </ul>
        <br />
        <center>
            <table class="Registrati">
                <tr>
                    <td class="Registrati">
                        <asp:Label ID="Label6" runat="server" Text="Codice Fiscale" CssClass="AspLabelRegistrati"></asp:Label><br />
                        <asp:TextBox ID="CodiceFiscale" runat="server" CssClass="AspTextBoxRegistrati" PlaceHolder="Il tuo CodiceFiscale"></asp:TextBox><br />
                    </td>
                    <td class="Registrati">
                         <asp:Label ID="Label1" runat="server" Text="Nome" CssClass="AspLabelRegistrati"></asp:Label><br />
                        <asp:TextBox ID="Nome" runat="server" CssClass="AspTextBoxRegistrati" PlaceHolder="Il tuo Nome"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="Registrati">
                         <asp:Label ID="Label2" runat="server" Text="Cognome" CssClass="AspLabelRegistrati"></asp:Label><br />
                        <asp:TextBox ID="Cognome" runat="server" CssClass="AspTextBoxRegistrati" PlaceHolder="Il tuo Cognome"></asp:TextBox><br />
                    </td>
                    <td class="Registrati">
                        <asp:Label ID="Label3" runat="server" Text="Email" CssClass="AspLabelRegistrati"></asp:Label><br />
                        <asp:TextBox ID="Email" runat="server" CssClass="AspTextBoxRegistrati" PlaceHolder="La tua Email"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="Registrati"> 
                        <asp:Label ID="Label5" runat="server" Text="Data di Nascita" CssClass="AspLabelRegistrati"></asp:Label><br />
                        <asp:TextBox ID="DataNascita" runat="server" TextMode="Date" CssClass="AspDateRegistrati"></asp:TextBox><br />
                    </td>
                    <td class="Registrati">
                        <asp:Label ID="Label4" runat="server" Text="Password" CssClass="AspLabelRegistrati"></asp:Label><br />
                        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="AspTextBoxRegistrati" PlaceHolder="La tua Password"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="Registrati">
                        <asp:Button ID="btnRegistarti" runat="server" Text="Registrati" OnClick="btnRegistarti_Click" CssClass="ButtonAspRegistrati" />
                    </td>
                </tr>
            </table>
        </center>       
   </form>
</body>
</html>
