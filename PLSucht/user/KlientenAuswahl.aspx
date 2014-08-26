<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KlientenAuswahl.aspx.cs" Inherits="PLSucht.KlientenAuswahl" MasterPageFile="~/user/user.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" defaultbutton="button_search">
    <asp:ToolkitScriptManager ID="ScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div class="row">
            <div class="col-md-6">
                <h2 class="no-pad">Klientenauswahl</h2>
            </div>
            <div class="col-md-6" style="text-align:right">

                <h3 class="no-pad"><small>Herzlich Willkommen,
                    <asp:LoginName ID="LoginName2" runat="server" />(<!--
                  --><asp:LoginStatus ID="LoginStatus2" runat="server" />)
                </small></h3>
            </div>
        </div>
 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-inline" role="form">
                 <div runat="server" visible="false" id="berater_anlegen" class="input-group" style="padding-top:15px;margin-top:15px;padding-bottom:15px;margin-bottom:15px">
                    <div class="input-group-addon"><i class="fa fa-plus"></i></div>
                    <asp:Button class="btn btn-success" ID="Button1"  runat="server" Text="Neuen Berater anlegen" OnClick="btnNeuBerater_Click" />
                </div>
                <div class="input-group" style="padding-top:15px;margin-top:15px;padding-bottom:15px;margin-bottom:15px">
                    <div class="input-group-addon"><i class="fa fa-plus"></i></div>
                    <asp:Button class="btn btn-success" ID="btnNeuKlient"  runat="server" Text="Neuen Klienten anlegen" OnClick="btnNeuKlient_Click" />
                </div>
            </div>
            <div class="form-inline" role="form" style="padding-bottom:15px;margin-bottom:15px">
                <div class="input-group">
                    <div class="input-group-addon"><i class="fa fa-search"></i></div>
                    <asp:Button class="btn btn-primary" ID="button_search" runat="server" Text="Suche..." OnClick="button_search_Click" CausesValidation="False" />
                </div>

                <div class="input-group">
                    <asp:TextBox class="form-control" placeholder="Vorname" ID="input_search_vorname" CausesValidation="false"  runat="server" OnTextChanged="input_search_vorname_TextChanged" style="margin-bottom:0px !important"></asp:TextBox>
                </div>

                <div class="input-group">
                    <asp:Label class="sr-only" ID="label_suche2" runat="server" Text="Nachname" for="input_search_nachname"></asp:Label>
                    <asp:TextBox class="form-control" placeholder="Nachname" ID="input_search_nachname" CausesValidation="false" runat="server" OnTextChanged="input_search_vorname_TextChanged"  style="margin-bottom:0px !important"></asp:TextBox>
                </div>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="GVKlienten" runat="server" CssClass="table table-striped"
                    AutoGenerateColumns="False"
                    OnSelectedIndexChanged="GVKlient_SelectedIndexChanged" BorderWidth="0" GridLines="None"
                    EmptyDataText="Keine Klienten gefunden!" OnRowDeleting="GVKlienten_RowDeleting" OnRowEditing="GVKlienten_RowEditing">
                    <Columns>
                        <asp:CommandField ItemStyle-CssClass="table-button"  ControlStyle-CssClass="btn btn-primary" ButtonType="Link" ShowSelectButton="true" SelectText="<span class='fa fa-hand-o-up'/>" />
                        <asp:CommandField ItemStyle-CssClass="table-button"  ControlStyle-CssClass="btn btn-success" ButtonType="Link" ShowEditButton="true"  EditText="<span class='fa fa-edit'/>" />
                        <asp:CommandField ItemStyle-CssClass="table-button" ControlStyle-CssClass="btn btn-danger" ButtonType="Link" ShowDeleteButton="true"  DeleteText="<span class='fa fa-times'/>" />
                        <asp:ImageField DataImageUrlField="avatar" HeaderText=" " NullImageUrl="../upload/dummy-user.jpg" ItemStyle-Width="50px" ControlStyle-Width="50px">
                        </asp:ImageField>
                        <asp:BoundField DataField="vorname" HeaderText="Vorname" />
                        <asp:BoundField DataField="nachname" HeaderText="Nachname" />
                        <asp:BoundField DataField="mobilnr" HeaderText="Mobilnummer" />
                        <asp:BoundField DataField="email" HeaderText="E-Mail" />
                        <asp:BoundField DataField="schule" HeaderText="Schule" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </>  
        
        </>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </form>
</asp:Content>

