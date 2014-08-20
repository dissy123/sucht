<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PLSucht.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:LoginName ID="LoginName1" runat="server" />
        <div>
         <div>
                <asp:Label ID="label_vorname" runat="server" Text="Vorname"></asp:Label>
                <input id="input_vorname" runat="server" type="text" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="input_vorname" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>

            </div>
            <div>
                <asp:Label ID="label_nachname" runat="server" Text="Nachname"></asp:Label>
                <input id="input_nachname" runat="server" type="text" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="input_nachname" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>

            </div>
            <div>
                <asp:Label ID="label_adresse" runat="server" Text="Adresse"></asp:Label>
                <input id="input_adresse" runat="server" type="text" />
            </div>
            <div>
                <asp:Label ID="label_plz" runat="server" Text="PLZ"></asp:Label>
                <input id="input_plz" runat="server" type="text" />
            </div>
            <div>
                <asp:Label ID="label_ort" runat="server" Text="Ort"></asp:Label>
                <input id="input_ort" runat="server" type="text" />
            </div>
            <div>
                <asp:Label ID="label_telnr" runat="server" Text="TelNr"></asp:Label>
                <input id="input_telnr" runat="server" type="text" />
            </div>
            <div>
                <asp:Label ID="label_mobilnr" runat="server" Text="MobilNr"></asp:Label>
                <input id="input_mobilnr" runat="server" type="text" />
            </div>
        </div>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" OnCreatedUser="CreateUserWizard1_CreatedUser">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" />
                <asp:CompleteWizardStep runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
   
    </form>
</body>
</html>
