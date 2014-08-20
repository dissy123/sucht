<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PLSucht.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
             <Scripts>
                <asp:ScriptReference Name="jquery"/>
              </Scripts>
        </asp:ScriptManager>
        <asp:Login ID="Login1" runat="server" OnLoggedIn="Login1_LoggedIn" ></asp:Login>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1" />
    </div>
    </form>
</body>
</html>
