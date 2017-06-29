<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Adminexample.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:TextBox ID="txtstring" runat ="server"></asp:TextBox>
        <br />
       <asp:Button ID="btnsubmit" runat="server" Text="submit" OnClick="btnsubmit_Click" />
        <asp:Label ID="lbl" runat="server"></asp:Label>
        <asp:Label ID="lblcom" runat="server" ></asp:Label>

    
    </div>
    </form>
</body>
</html>
