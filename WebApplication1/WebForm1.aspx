<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txt" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbltext" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btn" runat="server" Text="submit" OnClick="btn_Click" />
        
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true">
        </asp:GridView>
    </form>
</body>
</html>
