<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PLSucht.admin.Register" MasterPageFile="~/admin/adminuser.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="row">
            <div class="col-md-8">

                <div class="form-inline">
                    <div class="input-group">
                        <h2>Berater - Hinzufügen </h2>
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
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_vorname" runat="server" Text="Vorname"></asp:Label>
                        <div class="col-sm-8">
                            <input class="form-control" id="input_vorname" runat="server" type="text" />
                            <div class="bg-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationGroup="CreateUserWizard1" ControlToValidate="input_vorname" ErrorMessage="Bitte geben Sie einen Vornamen ein!"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_nachname" runat="server" Text="Nachname"></asp:Label>
                        <div class="col-sm-8">
                            <input id="input_nachname" class="form-control" runat="server" type="text" />
                            <div class="bg-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationGroup="CreateUserWizard1" ControlToValidate="input_nachname" ErrorMessage="Bitte geben Sie einen Nachnamen ein!"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_adresse" runat="server" Text="Adresse"></asp:Label>
                        <div class="col-sm-8">
                            <input id="input_adresse" class="form-control" runat="server" type="text" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_plz" runat="server" Text="PLZ"></asp:Label>
                        <div class="col-sm-8">
                            <input id="input_plz" class="form-control" runat="server" type="text" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_ort" runat="server" Text="Ort"></asp:Label>
                        <div class="col-sm-8">
                            <input id="input_ort" class="form-control" runat="server" type="text" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_telnr" runat="server" Text="TelNr"></asp:Label>
                        <div class="col-sm-8">
                            <input id="input_telnr" class="form-control" runat="server" type="text" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class="col-sm-4" ID="label_mobilnr" runat="server" Text="MobilNr"></asp:Label>
                        <div class="col-sm-8">
                            <input id="input_mobilnr" class="form-control" runat="server" type="text" />
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" OnCreatedUser="CreateUserWizard1_CreatedUser">
                        <WizardSteps>
                            <asp:CreateUserWizardStep runat="server">
                                <ContentTemplate>

                                    <div class="form-group">
                                        <asp:Label class="col-sm-5" ID="UserNameLabel" runat="server">Benutzername:</asp:Label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="UserName" class="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" Display="Dynamic" ErrorMessage="Der Benutzername ist erforderlich." ToolTip="Der Benutzername ist erforderlich." ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label class="col-sm-5" ID="PasswordLabel" runat="server">Kennwort:</asp:Label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="Password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                            <div class="bg-danger">
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" Display="Dynamic" ErrorMessage="Das Kennwort ist erforderlich." ToolTip="Das Kennwort ist erforderlich." ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label class="col-sm-5" ID="ConfirmPasswordLabel" runat="server">Kennwort bestätigen:</asp:Label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="ConfirmPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                            <div class="bg-danger">
                                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="Das Bestätigungskennwort ist erforderlich." ToolTip="Das Bestätigungskennwort ist erforderlich." ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" Display="Dynamic" ControlToValidate="ConfirmPassword" ErrorMessage="Das Kennwort und das Bestätigungskennwort müssen übereinstimmen." ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label class="col-sm-5" ID="EmailLabel" runat="server">E-Mail:</asp:Label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="Email" class="form-control" runat="server"></asp:TextBox>
                                            <div class="bg-danger">
                                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" Display="Dynamic" ErrorMessage="E-Mail ist erforderlich." ToolTip="E-Mail ist erforderlich." ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label class="col-sm-5" ID="QuestionLabel" runat="server">Sicherheitsfrage:</asp:Label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="Question" class="form-control" runat="server"></asp:TextBox>
                                            <div class="bg-danger">
                                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" Display="Dynamic" ErrorMessage="Die Sicherheitsfrage ist erforderlich." ToolTip="Die Sicherheitsfrage ist erforderlich." ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label class="col-sm-5" ID="AnswerLabel" runat="server">Sicherheitsantwort:</asp:Label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="Answer" class="form-control" runat="server"></asp:TextBox>
                                            <div class="bg-danger">
                                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" Display="Dynamic" ErrorMessage="Die Sicherheitsantwort ist erforderlich." ToolTip="Die Sicherheitsantwort ist erforderlich." ValidationGroup="CreateUserWizard1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                    </div>
                                    <div class="form-group">
                                        <asp:Literal ID="ErrorMessage" Mode="Transform" runat="server" EnableViewState="False"></asp:Literal>
                                    </div>
                                </ContentTemplate>
                                <CustomNavigationTemplate>

                                    <asp:Button class="btn btn-primary" ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Benutzer erstellen" ValidationGroup="CreateUserWizard1" />

                                </CustomNavigationTemplate>
                            </asp:CreateUserWizardStep>
                            <asp:CompleteWizardStep runat="server">
                                <ContentTemplate>
                                    Abschließen
                       Ihr Konto wurde erfolgreich erstellt.
                      <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue" Text="Weiter" ValidationGroup="CreateUserWizard1" />

                                </ContentTemplate>
                            </asp:CompleteWizardStep>
                        </WizardSteps>


                    </asp:CreateUserWizard>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
