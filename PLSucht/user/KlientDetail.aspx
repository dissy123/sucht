<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KlientDetail.aspx.cs" Inherits="PLSucht.KlientDetail" MasterPageFile="~/user/user.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div>
            <div class="form-inline">
                <div class="input-group">
                    <asp:Button class="btn btn-primary" ID="Button3_" runat="server" Text="Klienten auswahl" OnClick="ImageButton3_Click" />
                </div>
                <div class="input-group">
                    <asp:Button class="btn btn-primary " ID="Button1_" runat="server" Text="Beratungsgespräch beginnen" OnClick="ImageButton1_Click" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="form-inline">
                    <div class="input-group">
                        <h2>Klient -
                            <asp:Label ID="input_vorname" runat="server" type="text"></asp:Label>
                            <asp:Label ID="input_nachname" runat="server" type="text"></asp:Label></h2>
                    </div>
                    <div class="input-group">
                        <div class="input-group-addon"><i class="fa fa-pencil-square-o"></i></div>
                        <asp:Button class="btn btn-primary" ID="Button2_" runat="server" Text="Bearbeiten" OnClick="ImageButton2_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-6" style="text-align: right">
                <h3><small>
                    <asp:LoginName ID="LoginName2" runat="server" />
                    (<!--
                  --><asp:LoginStatus ID="LoginStatus2" runat="server" />
                    )
                </small></h3>
            </div>
        </div>

        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


            <div class="row">
                <div class="col-md-3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <img class="klient-detail" width="100" runat="server" id="imgDisplay" alt="" src="../upload/dummy-user.jpg" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-3">
                    <div class="form-inline">
                         <asp:Label ID="label_adresse" runat="server" Text="Adresse" AssociatedControlID="input_adresse"></asp:Label><br />
                        <asp:Label ID="input_adresse" runat="server" type="text"></asp:Label><br />
                           <asp:Label ID="input_plz" runat="server" type="text"></asp:Label> - <!--
                    --><asp:Label ID="input_ort" runat="server" type="text"></asp:Label>
                    </div>
                    
                    <div class="form-inline">
                        <asp:Label ID="label_telnr" runat="server" Text="Telefon Nr." AssociatedControlID="input_telnr"></asp:Label><br />
                        <asp:Label ID="input_telnr" runat="server" type="text"></asp:Label>
                    </div>
                    <div class="form-inline">
                        <asp:Label ID="label_mobilnr" runat="server" Text="Mobil Nr." AssociatedControlID="input_mobilnr"></asp:Label><br />
                        <asp:Label ID="input_mobilnr" runat="server" type="text"></asp:Label>
                    </div>
                      <div class="form-inline">
                        <asp:Label ID="label_email" runat="server" Text="E-mail" AssociatedControlID="input_email"></asp:Label><br />
                        <asp:Label ID="input_email" runat="server" type="text"></asp:Label>
                    </div>
                </div>

                <div class="col-md-3">
                  
                    <div class="form-inline">
                        <asp:Label ID="label_geschlecht" runat="server" Text="Geschlecht" AssociatedControlID="input_sex"></asp:Label><br />
                        <asp:Label ID="input_sex" runat="server"></asp:Label>
                    </div>
                    <div class="form-inline">
                        <asp:Label ID="label_gebdat" runat="server" Text="Geburtsdatum" AssociatedControlID="input_gebdat"></asp:Label><br />
                        <asp:Label ID="input_gebdat" runat="server"></asp:Label>

                    </div>
                    <div class="form-inline">
                        <asp:Label ID="label_nationalitaet" runat="server" Text="Nationalität" AssociatedControlID="input_nationalitaet"></asp:Label><br />
                        <asp:Label ID="input_nationalitaet" runat="server" type="text"></asp:Label>
                    </div>
                    <div class="form-inline">
                        <asp:Label ID="label_schule" runat="server" Text="Schule" AssociatedControlID="input_schule"></asp:Label><br />
                        <asp:Label ID="input_schule" runat="server" type="text"></asp:Label>
                    </div>

                </div>
                <div class="col-md-3">
                    
                    <div class="form-inline">
                        <asp:Label ID="label_erstkontakt" runat="server" Text="Erstkontakt" AssociatedControlID="input_erstkontakt"></asp:Label><br />
                        <asp:Label ID="input_erstkontakt" runat="server"></asp:Label>

                    </div>
                    <div class="form-inline">
                        <asp:Label ID="label_status" runat="server" Text="Status" AssociatedControlID="input_status"></asp:Label><br />
                        <asp:Label ID="input_status" runat="server" type="text"></asp:Label>
                    </div>
                    <div class="form-inline">
                        <asp:Label ID="label_stufe" runat="server" Text="Stufe" AssociatedControlID="input_stufe"></asp:Label><br />
                        <asp:Label ID="input_stufe" runat="server" type="text"></asp:Label>
                    </div>
                </div>
            </div>
        </div>


        <div class="table-responsive">
            <asp:GridView CssClass="table table-striped" ID="GVBesprechungsuebersicht" runat="server"
                AutoGenerateColumns="False" BorderWidth="0" GridLines="None"
                OnSelectedIndexChanged="GVBesprechungsuebersicht_SelectedIndexChanged"
                EmptyDataText="Kein Beratungsgespräch gefunden!">
                <Columns>
                    <asp:CommandField ItemStyle-CssClass="table-button" ControlStyle-CssClass="btn btn-primary" ButtonType="Link" ShowSelectButton="true" SelectText="<span class='fa fa-hand-o-up'/>" />
                    <asp:BoundField DataField="datum_formatted" HeaderText="Datum" />
                    <asp:BoundField DataField="beratungsart_formatted" HeaderText="Beratungsart" />
                    <asp:BoundField DataField="ueberweisungskontext" HeaderText="Überweisungskontext" />
                    <asp:BoundField DataField="Anmerkungen_formatted" HeaderText="Anmerkungen" HtmlEncode="False" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</asp:Content>
