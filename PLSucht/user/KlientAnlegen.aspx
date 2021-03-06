﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KlientAnlegen.aspx.cs" Inherits="PLSucht.KlientAnlegen" MasterPageFile="~/user/user.Master" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ScriptManager1" runat="server"></asp:ToolkitScriptManager>



        <div class="row">
            <div class="col-md-8">

                <div class="form-inline">
                    <div class="input-group">
                        <h2>Klient -
                            <asp:Label ID="headertxt" runat="server"></asp:Label>
                        </h2>
                    </div>
                </div>
                <div class="form-group" style="margin-top: -15px;">
                    <h2 style="padding-top: 0px; margin-top: 0px">
                        <small>
                            <asp:Label ID="label_klient" runat="server" Text=""></asp:Label>
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
        <div class="form-horizontal">
            <div class="row">
                <div class="col-md-4">
                     <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <img runat="server" class="col-sm-4" id="imgDisplay" width="50" alt="" src="../upload/dummy-user.jpg" />
                                <asp:AsyncFileUpload CssClass="col-sm-8 btn btn-primary btn-file" OnClientUploadComplete="uploadComplete" runat="server" ID="AsyncFileUpload1"
                                    UploaderStyle="Traditional" EnableTheming="true"
                                    ThrobberID="imgLoader" OnUploadedComplete="FileUploadComplete" OnClientUploadStarted="uploadStarted" />

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_vorname" runat="server" Text="Vorname"  AssociatedControlID="input_vorname"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_vorname" runat="server" type="text" />
                            <div class="bg-danger">
                                <small>
                                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="bg-danger" ID="RequiredFieldValidator1" runat="server" ControlToValidate="input_vorname" ErrorMessage="Bitte geben Sie den Vornamen ein!"></asp:RequiredFieldValidator>
                                </small>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_nachname" runat="server" Text="Nachname"  AssociatedControlID="input_nachname"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_nachname" runat="server" type="text" />
                            <div class="bg-danger">
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" CssClass="bg-danger" runat="server" ControlToValidate="input_nachname" ErrorMessage="Bitte geben Sie den Nachnamen ein!"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_adresse" runat="server" Text="Adresse"  AssociatedControlID="input_adresse"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_adresse" runat="server" type="text" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_plz" runat="server" Text="PLZ"  AssociatedControlID="input_plz"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_plz" runat="server" type="text" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_ort" runat="server" Text="Ort"  AssociatedControlID="input_ort"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_ort" runat="server" type="text" />
                        </div>
                    </div>
                   
                </div>
                <div class="col-md-4">
                     <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_telnr" runat="server" Text="Tel. Nr"  AssociatedControlID="input_telnr"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_telnr" runat="server" type="text" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_mobilnr" runat="server" Text="Mobil Nr"  AssociatedControlID="input_mobilnr"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_mobilnr" runat="server" type="text" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_email" runat="server" Text="E-mail"  AssociatedControlID="input_email"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_email" runat="server" type="text" />
                            <div class="bg-danger">
                                <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" CssClass="bg-danger" runat="server" ControlToValidate="input_email" ErrorMessage="E-Mail Adresse im Format: example@example.at" ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_gebdat" runat="server" Text="Geburtsdat."  AssociatedControlID="input_gebdat"></asp:Label>
                        <div class="col-sm-8">
                            <asp:TextBox class="form-control" ID="input_gebdat" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="input_gebdat" Format="dd.MM.yyyy"></asp:CalendarExtender>
                            <div class="bg-danger">
                                <asp:RangeValidator ID="rvDateGebDat" runat="server" CssClass="bg-danger" ControlToValidate="input_gebdat" ErrorMessage="Ungültiges Datum muss zwischen 1.1.1900 und 1.1.2100 liegen!" Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2100" Display="Dynamic"></asp:RangeValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_nationalitaet" runat="server" Text="Nationalität"  AssociatedControlID="input_nationalitaet"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_nationalitaet" runat="server" type="text" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_schule" runat="server" Text="Schule"  AssociatedControlID="input_schule"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_schule" runat="server" type="text" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_erstkontakt" runat="server" Text="Erstkontakt"  AssociatedControlID="input_erstkontakt"></asp:Label>
                        <div class="col-sm-8">
                            <asp:TextBox class="form-control" ID="input_erstkontakt" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="input_erstkontakt" Format="dd.MM.yyyy"></asp:CalendarExtender>
                            <div class="bg-danger">
                                <asp:RangeValidator ID="rvDateErstkontakt" CssClass="bg-danger" runat="server" ControlToValidate="input_erstkontakt" ErrorMessage="Ungültiges Datum muss zwischen 1.1.1900 und 1.1.2100 liegen!" Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2100" Display="Dynamic"></asp:RangeValidator>
                            </div>
                        </div>
                    </div>
                   
                </div>
                <div class="col-md-4">
                     <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_status" runat="server" Text="Status"  AssociatedControlID="input_status"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_status" runat="server" type="text" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_stufe" runat="server" Text="Stufe"  AssociatedControlID="input_stufe"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_stufe" runat="server" type="text" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="label_geschlecht" class="col-sm-4" runat="server" Text="Geschlecht"  AssociatedControlID="M" Font-Bold="true"></asp:Label>
                        <div class="radio col-sm-8">
                            <label  id="label_sex_m">
                                <input class="radio-inline" id="M" groupname="input_sex" runat="server" type="radio" name="sex" value="M" />
                                Männlich
                            </label>
                            <label  id="label_sex_w">
                                <input class="radio-inline" id="W" groupname="input_sex" runat="server" type="radio" name="sex" value="W" />
                                Weiblich
                            </label>
                        </div>
                    </div>
                   
                </div>
            </div>
        </div>

        <div>
            <div>
                <div class="form-inline">
                    <div class="input-group">
                        <asp:Button class="btn btn-primary" ID="btnSave" runat="server" UseSubmitBehavior="true" OnClick="btnSaveClick" Text="Speichern" CausesValidation="true" />
                    </div>
                    <div class="input-group">
                        <asp:Button class="btn btn-primary" ID="btnSaveBeratung" runat="server" UseSubmitBehavior="true" OnClick="btnSaveClickBeratung" CausesValidation="true" Text="Speichern -> Beratungsgespräch" />
                    </div>
                    <div class="input-group">
                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" OnClick="btnCancelClick" Text="Abbrechen" CausesValidation="false" />
                    </div>
                </div>
            </div>
        </div>
        <div>
            <asp:Label ID="lblFehlermeldung" runat="server"></asp:Label>
        </div>
        <asp:HiddenField ID="example" runat="server" />
    </form>

</asp:Content>
