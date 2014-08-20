<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Beratungen.aspx.cs" Inherits="PLSucht.Beratungen" MasterPageFile="~/user/user.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>
        <form id="form1" runat="server">
            <asp:ToolkitScriptManager ID="ScriptManager1" runat="server"></asp:ToolkitScriptManager>
            <h2><small>
                <asp:LoginName ID="LoginName1" runat="server" />
                (<!--
            --><asp:LoginStatus ID="LoginStatus1" runat="server" />
                )
            </small></h2>

            <h3>Besprechung - Bearbeiten/Hinzufügen</h3>
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
                                <h3><small><asp:Label ID="label_klient" runat="server" Text=""></asp:Label></small></h3>
                                
                                <img runat="server" id="imgDisplay" alt="" src="../upload/dummy-user.jpg" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-md-4">
                        
                        <div class="form-group">
                            <asp:Label class="col-sm-4" ID="label_beratungsart" runat="server" Text="Beratungsart"></asp:Label>
                            <div class="col-sm-8">
                                <asp:ComboBox ID="input_beratungsart" runat="server"></asp:ComboBox>
                                <div class="bg-danger">
                                    <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ControlToValidate="input_beratungsart" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label class="col-sm-4" ID="label_datum" runat="server" Text="Datum"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox  ID="input_datum" runat="server" TextMode="Date"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="input_datum"></asp:CalendarExtender>
                                <div class="bg-danger">

                                    <asp:RangeValidator CssClass="bg-danger" Display="Dynamic" ID="rvDateGebDat" runat="server" ControlToValidate="input_datum" ErrorMessage="Invalid Date" Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2100"></asp:RangeValidator>
                                    <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ControlToValidate="input_datum" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label class="col-sm-4" ID="label_dauer" runat="server" Text="Dauer"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox  ID="input_dauer" runat="server" TextMode="Time"></asp:TextBox>
                                <!-- TODO maybe automatic timer? -->
                                <div class="bg-danger">

                                    <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator6" runat="server" ControlToValidate="input_dauer" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                    </div>


                    <div class="col-md-5">
                        <div class="form-group">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="form-inline">
                                        <asp:Label class="col-sm-3" ID="label_themen" runat="server" Text="Themen"></asp:Label>
                                        <input class="col-sm-4" id="input_thema" runat="server" type="text" />
                                        <asp:Button class="col-sm-5 btn btn-primary" ID="add_thema" runat="server" OnClick="add_thema_Click" CausesValidation="false" Text="Thema hinzufügen" />
                                        <div class="bg-danger">
                                            <asp:Label CssClass="bg-danger" Display="Dynamic" ID="lbl_error_add_thema" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-inline">
                                        <div class="col-sm-3"></div>
                                        <asp:CheckBoxList class="col-sm-4" ID="input_themen" OnSelectedIndexChanged="input_themen_SelectedIndexChanged" runat="server" SelectMethod="">
                                        </asp:CheckBoxList>
                                    </div>

                                </ContentTemplate>

                            </asp:UpdatePanel>

                        </div>
                        <div class="form-group">
                            <asp:Label class="col-sm-4" ID="label_anhang" runat="server" Text="Anhang"></asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:AsyncFileUpload CssClass="btn btn-primary btn-file" OnClientUploadComplete="uploadComplete" runat="server" ID="input_anhang"
                                        UploaderStyle="Traditional" EnableTheming="true"
                                        ThrobberID="imgLoader" />

                                    <asp:HyperLink class="btn btn-primary" ID="link_anhang" runat="server" Target="_blank">Download</asp:HyperLink>
                                    <!-- <asp:ImageButton class="col-sm-8" ID="download_anhang" runat="server" OnClick="Anhang_Download_Click" CausesValidation="false" />
                                    -->
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-7">
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_ueberweisungskontext" runat="server" Text="Überweisungskontext"></asp:Label>
                        <div class="col-sm-8">
                            <input  id="input_ueberweisungskontext" runat="server" type="text" />
                            <div class="bg-danger">
                                <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="input_ueberweisungskontext" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_gespraechsart" runat="server" Text="Gesprächsart"></asp:Label>
                        <div class="col-sm-8">
                            <input  id="input_gespraechsart" runat="server" type="text" />
                            <div class="bg-danger">
                                <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ControlToValidate="input_gespraechsart" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_kontaktort" runat="server" Text="Kontaktort"></asp:Label>
                        <div class="col-sm-8">
                            <input id="input_kontaktort" runat="server" type="text" />
                            <div class="bg-danger">
                                <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ControlToValidate="input_kontaktort" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_anmerkungen" runat="server" Text="Anmerkungen"></asp:Label>
                        <div class="col-sm-8">
                            <asp:TextBox  ID="input_anmerkungen" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <div class="bg-danger">

                                <asp:RequiredFieldValidator CssClass="bg-danger" Display="Dynamic" ID="RequiredFieldValidator7" runat="server" ControlToValidate="input_anmerkungen" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
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
                            <asp:BoundField DataField="anmerkungen" HeaderText="Anmerkungen" />
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
