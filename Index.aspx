<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Votazioni On-Line</title>
    <style>
        @import url(Css/class.css);
        @import url(Css/style.css);
    </style>
</head>
<body>
    <center>
         <h1 class="Titolo">VOTAZIONI ON-LINE</h1>
        <table class="IntestazioneIndex">            
            <tr>
                <td class="IntestazioneIndex">
                    <form id="form1" runat="server">
                        <asp:Label ID="Label1" runat="server" Text="Email : " CssClass="Testo"></asp:Label>
                        <asp:TextBox ID="Email" runat="server" CssClass="AspTextBox" PlaceHolder="La tua email"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" Text="Password :" CssClass="Testo"></asp:Label>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="AspTextBox" PlaceHolder="La tua password"></asp:TextBox>
                        <asp:Button ID="btnAccedi" runat="server" Text="Accedi" OnClick="btnAccedi_Click" CssClass="ButtonAsp" /><br />
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registrati.aspx" CssClass="HyperLink">Non sei Ancora Registrato? Registati</asp:HyperLink><br />
                        <asp:HyperLink ID="Risultati" runat="server" CssClass="HyperLink" NavigateUrl="~/Risultati.aspx">Mostra Risultati</asp:HyperLink><br />
                    </form>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="CorpoIndex">
                    Lorem ipsum dolor sit amet, consectetuer adipiscing elit. 
                    Aenean commodo ligula eget dolor. Aenean massa. 
                    Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. 
                    Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. 
                    Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. 
                    In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. 
                    Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. 
                    Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. 
                    Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. 
                    Phasellus viverra nulla ut metus varius laoreet. 
                    Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. 
                    Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. 
                    Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. 
                    Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. 
                    Maecenas nec odio et ante tincidunt tempus. 
                    Donec vitae sapien ut libero venenatis faucibus. 
                    Nullam quis ante. 
                    Etiam sit amet orci eget eros faucibus tincidunt. 
                    Duis leo. Sed fringilla mauris sit amet nibh. 
                    Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc,
                </td>
            </tr>
        </table>
    </center>
</body>
</html>
