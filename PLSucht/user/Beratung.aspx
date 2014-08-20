<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Beratung.aspx.cs" Inherits="PLSucht.Beratung" MasterPageFile="~/user/user.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div>
            <div class="form-inline">
                <div class="input-group">
                    <asp:Button class="btn btn-primary" ID="Button3_" runat="server" Text="Klienten auswahl" OnClick="ImageButton3_Click" />
                </div>
                <div class="input-group">
                    <asp:Button class="btn btn-primary" ID="Button2_" runat="server" Text="Klient anzeigen" OnClick="ImageButton2_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <div class="form-inline">
                    <div class="input-group">
                        <h2>Beratungsgespräch </h2>
                    </div>
                    <div class="input-group">
                        <div class="input-group-addon"><i class="fa fa-pencil-square-o"></i></div>
                        <asp:Button class="btn btn-primary" ID="Button1_" runat="server" Text="Bearbeiten" OnClick="ImageButton1_Click" />
                    </div>
                </div>

                <div class="form-group" style="margin-top: -15px;">
                    <h2 style="padding-top: 0px; margin-top: 0px">
                        <small>
                            <asp:Label ID="label_klient" runat="server" Text=""></asp:Label>
                            vom 
                            <asp:Label ID="input_datum" runat="server" TextMode="Date"></asp:Label>
                        </small>
                    </h2>
                </div>
            </div>
            <div class="col-md-4" style="text-align: right">
                <h3><small>
                    <asp:LoginName ID="LoginName2" runat="server" />
                    (<!--
                  --><asp:LoginStatus ID="LoginStatus2" runat="server" />
                    )
                </small></h3>
            </div>
        </div>
        <div>

            <div class="row no-pad">
                <div class="col-md-3">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <img runat="server" id="imgDisplay" alt="" src="upload/dummy-user.jpg" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="col-md-3">
                    <div>
                        <asp:Label ID="label_ueberweisungskontext" runat="server" Text="Überweisungskontext"></asp:Label>
                        <asp:Label ID="input_ueberweisungskontext" runat="server" type="text" />
                    </div>
                    <div>
                        <asp:Label ID="label_beratungsart" runat="server" Text="Beratungsart"></asp:Label>
                        <asp:Label ID="input_beratungsart" runat="server"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="label_gespraechsart" runat="server" Text="Gesprächsart"></asp:Label>
                        <asp:Label ID="input_gespraechsart" runat="server" type="text" />
                    </div>
                    <div>
                        <asp:Label ID="label_kontaktort" runat="server" Text="Kontaktort"></asp:Label>
                        <asp:Label ID="input_kontaktort" runat="server" type="text" />
                    </div>
                    <div>
                        <asp:Label ID="label_dauer" runat="server" Text="Dauer"></asp:Label>
                        <asp:Label ID="input_dauer" runat="server" TextMode="Time"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="label_anhang" runat="server" Text="Anhang"></asp:Label>
                        <asp:HyperLink ID="link_anhang" runat="server" Target="_blank">Download</asp:HyperLink>
                    </div>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="label_themen" runat="server" Text="Themen"></asp:Label>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li><%#Eval("Thema.Titel")%></li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="label_anmerkungen" runat="server" Text="Anmerkungen"></asp:Label>
                    <br />
                    <asp:Label ID="input_anmerkungen" runat="server"></asp:Label>

                </div>
            </div>

        </div>
    </form>
</asp:Content>
