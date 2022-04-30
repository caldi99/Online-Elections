<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vota.aspx.cs" Inherits="Vota" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Vota</title>
    <style>
        @import url(Css/class.css);
        @import url(Css/style.css);
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <h1 class="Titolo">VOTA</h1>
        </center>
        <ul>
            <li>
                <asp:Button ID="Home" runat="server" Text="Home" OnClick="Home_Click" CssClass="ButtonAsp" />
            </li>
            <li>
                <asp:Button Text="Conferma" runat="server" ID="btnConferma" OnClick="btnConferma_Click" cssClass="ButtonAsp"/>
            </li>
            <li>
                <asp:Button ID="VisualizzaRisultati" runat="server" Text="Visualizza Risultati" Visible="false" OnClick="VisualizzaRisultati_Click" CssClass="ButtonAsp" />
            </li>
        </ul>
        <br />
        <center>
            <div class="Vota">
                <asp:Label ID="Informazioni" runat="server" Text="" CssClass="Testo"></asp:Label>
            </div>
            <table class="Vota" id="Table1" runat="server">
                <tr>
                    <td class="VotaGridView">
                        <h1 class="Sottotitolo">
                            SCHEDA ELETTORALE CAMERA DEI DEPUTATI
                        </h1>
                    </td>
                    <td class="VotaButton" id="CellaSenato1" runat="server"></td>
                    <td class="VotaGridView" id ="CellaSenato2" runat="server">
                        <h1 class="Sottotitolo">
                            SCHEDA ELETTORALE SENATO
                        </h1>
                    </td>
                </tr>
                <tr>
                    <td class="VotaGridView">
                        <asp:GridView ID="TabellaSchedaCamera" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Tabella_SelectedIndexChanged" CellPadding="8">
                        <Columns>
                            <asp:BoundField DataField="NomePartito" HeaderText="Nome Partito">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NomeCoalizione" HeaderText="Nome Coalizione">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Logo">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# Bind("PercorsoLogo") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Candidati">
                                <ItemTemplate>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSource='<%# Bind("ListaCandidati") %>'>
                                        <Columns>
                                            <asp:BoundField DataField="Nome" HeaderText="Nome">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Cognome" HeaderText="Cognome">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DataNascita" HeaderText="Data di Nascita">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Immagine Candidato">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image3" runat="server" Height="50px" ImageUrl='<%# Bind("PercorsoFoto") %>' Width="50px" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <asp:Image ID="Image2" runat="server" />
                                        </EmptyDataTemplate>
                                        <HeaderStyle BackColor="#AC0202" BorderColor="#990000" BorderStyle="Solid" BorderWidth="2px" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <RowStyle BorderColor="Maroon" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:ButtonField CommandName="Select" Text="Vota" ButtonType="Button" ControlStyle-CssClass="ButtonFieldCamera">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:ButtonField>
                        </Columns>
                        <HeaderStyle BackColor="#DDB104" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#FFCC00" BorderStyle="Solid" BorderWidth="3px" />
                        <RowStyle BackColor="#FFFF80" ForeColor="#333333" Font-Names="" BorderColor="#FFCC00" BorderStyle="Solid" BorderWidth="3px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#AC8CE8" BorderColor="#6712B4" BorderStyle="Ridge" BorderWidth="3px"  />
                    </asp:GridView>
                    </td>
                    <td class="VotaButton" id="CellaSenato3" runat="server">
                    </td>
                    <td class="VotaGridView" id="CellaSenato4" runat="server">
                        <asp:GridView ID="TabellaSchedaSenato" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Tabella_SelectedIndexChanged" CellPadding="8">
            <Columns>
                <asp:BoundField DataField="NomePartito" HeaderText="Nome Partito">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="NomeCoalizione" HeaderText="Nome Coalizione">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Logo">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# Bind("PercorsoLogo") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Candidati">
                    <ItemTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSource='<%# Bind("ListaCandidati") %>'>
                            <Columns>
                                <asp:BoundField DataField="Nome" HeaderText="Nome">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cognome" HeaderText="Cognome">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DataNascita" HeaderText="Data di Nascita">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Immagine Candidato">
                                    <ItemTemplate>
                                        <asp:Image ID="Image3" runat="server" Height="50px" ImageUrl='<%# Bind("PercorsoFoto") %>' Width="50px" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Image ID="Image2" runat="server" />
                            </EmptyDataTemplate>
                            <HeaderStyle BackColor="#009933" BorderColor="#005B00" BorderStyle="Solid" BorderWidth="2px" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <RowStyle BorderColor="#005B00" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="2px" />
                        </asp:GridView>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:ButtonField CommandName="Select" Text="Vota" ButtonType="Button" ControlStyle-CssClass="ButtonFieldSenato">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:ButtonField>
            </Columns>
            <HeaderStyle BackColor="#BF5BAE" BorderColor="#D975D7" BorderStyle="Solid" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle BackColor="#FEBCF4" BorderColor="#D975D7" BorderWidth="3px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#AED7FF" BorderColor="#0080FF" BorderStyle="Solid" BorderWidth="3px" />
        </asp:GridView>
                    </td>
                </tr>
            </table>
        </center>
    </form>
</body>
</html>
