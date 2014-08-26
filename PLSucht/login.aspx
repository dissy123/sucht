<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PLSucht.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="/content/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Name="jquery" />
                </Scripts>
            </asp:ScriptManager>
            <asp:Login ID="Login1" EnableTheming="True" runat="server" OnLoggedIn="Login1_LoggedIn" Width="336px" CssClass="center-block">
                <CheckBoxStyle CssClass="form-control"></CheckBoxStyle>
                <LayoutTemplate>
                    <div class="form-group">
                        <h1 style="text-align: center;">Anmelden</h1>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Benutzername:</asp:Label>

                        <asp:TextBox ID="UserName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" Display="None" ControlToValidate="UserName" ErrorMessage="Der Benutzername ist erforderlich." ToolTip="Der Benutzername ist erforderlich." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Kennwort:</asp:Label>

                        <asp:TextBox ID="Password" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" Display="None" ErrorMessage="Das Kennwort ist erforderlich." ToolTip="Das Kennwort ist erforderlich." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:CheckBox CssClass="form-control" ID="RememberMe" runat="server" Text="Anmeldedaten speichern." />

                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </div>
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" CssClass="form-control btn btn-primary" Text="Anmelden" ValidationGroup="Login1" />
                </LayoutTemplate>

                <FailureTextStyle CssClass="bg-danger"></FailureTextStyle>

                <LoginButtonStyle CssClass="form-control btn btn-primary"></LoginButtonStyle>
            </asp:Login>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1" />
        </div>
        <script src="/scripts/bootstrap.min.js" type="text/javascript"></script>
    </form>
</body>
</html>
