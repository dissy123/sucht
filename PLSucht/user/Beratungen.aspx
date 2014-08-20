<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Beratungen.aspx.cs" Inherits="PLSucht.Beratungen" MasterPageFile="~/user/user.Master" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>
        <form id="form1" runat="server">
            <asp:ToolkitScriptManager ID="ScriptManager1" runat="server"></asp:ToolkitScriptManager>
            <div class="row">
                <div class="col-md-8">
                    <div class="form-inline">
                        <div class="input-group">
                            <h2>Besprechung - Bearbeiten/Hinzufügen </h2>
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
            <!-- <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate> -->
            <script type="text/javascript">
                function uploadComplete(sender, args) {
                    debugger;
                    var contentType = args.get_contentType();
                    var text;
                }
            </script>
            <!-- </ContentTemplate>
            </asp:UpdatePanel>-->
            <div class="form-horizontal">
                <div class="row">
                    <div class="col-md-3">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <img runat="server" id="imgDisplay" alt="" src="../upload/dummy-user.jpg" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label class="col-sm-4" ID="label_datum" runat="server" Text="Datum"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control" ID="input_datum" runat="server" TextMode="Date"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd.MM.yyyy" TargetControlID="input_datum"></asp:CalendarExtender>
                                <div class="bg-danger">
                                    <asp:RangeValidator CssClass="bg-danger" Display="Dynamic" ID="rvDateGebDat" runat="server" ControlToValidate="input_datum" ErrorMessage="Invalid Date" Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2100"></asp:RangeValidator>
                                    <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator5"
                                        runat="server" ControlToValidate="input_datum"
                                        ErrorMessage="Ungültiges Datum muss zwischen 1.1.1900 und 1.1.2100 liegen!"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label  class="col-sm-4" ID="label_beratungsart" runat="server" Text="Beratungsart"></asp:Label>
                            <div class="col-sm-8">
                                <asp:DropDownList  ID="input_beratungsart" CssClass="form-control" runat="server"></asp:DropDownList>

                                <div class="bg-danger">
                                    <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator2"
                                        runat="server" ControlToValidate="input_beratungsart"
                                        ErrorMessage="Bitte geben Sie die Beratungsart ein!"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label class="col-sm-4" ID="label_ueberweisungskontext" runat="server" Text="Überweisungskontext"></asp:Label>
                            <div class="col-sm-8">
                                <input class="form-control" id="input_ueberweisungskontext" runat="server" type="text" />
                                <div class="bg-danger">
                                    <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator1"
                                        runat="server" ControlToValidate="input_ueberweisungskontext"
                                        ErrorMessage="Bitte geben Sie den Überweisungskontext ein!"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <asp:Label class="form-control" ID="label_gespraechsart" runat="server" Text="Gesprächsart"></asp:Label>
                            </div>
                            <div class="col-sm-8">
                                <input  class="form-control" id="input_gespraechsart" runat="server" type="text" />
                                <div class="bg-danger">
                                    <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator4"
                                        runat="server" ControlToValidate="input_gespraechsart"
                                        ErrorMessage="Bitte geben Sie die Gesprächsart ein!"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label  ID="label_kontaktort" runat="server" Text="Kontaktort"></asp:Label>
                            <div class="col-sm-8">
                                <div class="col-md-4">
                                    <input class="form-control" id="input_kontaktort" runat="server" type="text" />
                                </div>
                                <div class="bg-danger">
                                    <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator3"
                                        runat="server" ControlToValidate="input_kontaktort"
                                        ErrorMessage="Bitte geben Sie den Kontaktort ein!"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-5">
                        <div class="form-group">
                            <asp:Label class="col-sm-3" ID="label_dauer" runat="server" Text="Dauer"></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox class="form-control " ID="input_dauer" runat="server" TextMode="Time" CausesValidation="false"></asp:TextBox>
                            </div>

                            <input class="btn btn-primary col-sm-5" type="button" id="input_stop_time" value="Stop Time"></input>
                            <!-- TODO maybe automatic timer? -->
                            <div class="bg-danger">
                                <asp:RegularExpressionValidator CssClass="bg-danger" Display="Dynamic" ID="RegularExpressionValidator1"
                                    runat="server" ControlToValidate="input_dauer" ValidationExpression="[0-2][0-3]:[0-5][0-9]:[0-5][0-9]"
                                    ErrorMessage="Bitte geben Sie die Dauer im Format HH:MM:SS ein!"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator6"
                                    runat="server" ControlToValidate="input_dauer"
                                    ErrorMessage="Bitte geben Sie die Dauer des Gesprächs ein!"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <div class="form-group">
                            <asp:Label class="col-sm-3" ID="label_anhang" runat="server" Text="Anhang"></asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:AsyncFileUpload CssClass="btn btn-primary btn-file col-sm-4" OnClientUploadComplete="uploadComplete" runat="server" ID="input_anhang"
                                        UploaderStyle="Traditional" EnableTheming="true"
                                        ThrobberID="imgLoader" />

                                    <asp:HyperLink class="btn btn-primary col-sm-5" ID="link_anhang" runat="server" Target="_blank">Download</asp:HyperLink>
                                    <!-- <asp:ImageButton class="col-sm-8" ID="download_anhang" runat="server" OnClick="Anhang_Download_Click" CausesValidation="false" />
                                    -->
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="form-group bg-warning">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                    <div class="form-inline">
                                        <asp:Label class="col-sm-3" ID="label_themen" runat="server" Text="Themen"></asp:Label>
                                        <div class="col-sm-4">
                                        <input class="form-control" id="input_thema" runat="server" type="text" />
                                        </div>
                                            <asp:Button class="col-sm-5 btn btn-primary" ID="add_thema" runat="server" OnClick="add_thema_Click" CausesValidation="false" Text="Thema hinzufügen" />
                                        <div class="bg-danger">
                                            <asp:Label CssClass="bg-danger" Display="Dynamic" ID="lbl_error_add_thema" runat="server"></asp:Label>
                                        </div>

                                    </div>

                                    <div class="form-inline">
                                        <asp:CheckBoxList RepeatColumns="4" class="col-sm-12" ID="input_themen" OnSelectedIndexChanged="input_themen_SelectedIndexChanged" runat="server" SelectMethod="">
                                        </asp:CheckBoxList>
                                    </div>


                                </ContentTemplate>

                            </asp:UpdatePanel>

                        </div>

                    </div>
                </div>
                <div>


                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_anmerkungen" runat="server" Text="Anmerkungen"></asp:Label>
                        <div>

                            <textarea id="input_anmerkungen" name="elm1" rows="15" cols="80" style="width: 80%"
                                runat="server"></textarea>
                            <div class="bg-danger">

                                <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator7"
                                    runat="server" ControlToValidate="input_anmerkungen"
                                    ErrorMessage="Bitte geben Sie Anmerkungen ein!"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="table-responsive">
                <asp:GridView ID="GVBesprechungsuebersicht" runat="server" CssClass="table table-striped"
                    AutoGenerateColumns="False"
                    OnSelectedIndexChanged="GVBesprechungsuebersicht_SelectedIndexChanged" BorderWidth="0" GridLines="None"
                    EmptyDataText="Keine Klienten in der Datenbank">
                    <Columns>
                        <asp:CommandField ItemStyle-CssClass="table-button" ControlStyle-CssClass="btn btn-primary" ButtonType="Link" ShowSelectButton="true" SelectText="<span class='fa fa-hand-o-up'/>" />
                        <asp:BoundField DataField="datum_formatted" HeaderText="Datum" />
                        <asp:BoundField DataField="beratungsart" HeaderText="Beratungsart" />
                        <asp:BoundField DataField="ueberweisungskontext" HeaderText="Überweisungskontext" />
                        <asp:BoundField DataField="Anmerkungen_formatted" HeaderText="Anmerkungen" HtmlEncode="False" />
                    </Columns>
                </asp:GridView>
            </div>


            <div>
                <asp:Button ID="btnSave" class="btn btn-primary" runat="server" OnClick="btnSaveClick" Text="Speichern" />
                &nbsp;
                    <asp:Button ID="btnCancel" class="btn btn-primary" runat="server" OnClick="btnCancelClick" Text="Abbrechen" CausesValidation="False" />
            </div>
            <div>
                <asp:Label ID="lblFehlermeldung" runat="server"></asp:Label>
            </div>

            </div>

        </form>
</asp:Content>
