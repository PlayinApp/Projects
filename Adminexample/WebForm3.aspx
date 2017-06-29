<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Adminexample.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="panel panel-primary">
      <div class="panel-heading">Panel with panel-primary class</div>
      <div class="panel-body">
        
  <div class="form-group">
    <label for="email">Email address:</label>
    <input type="email" class="form-control" id="email"/>
  </div>
  <div class="form-group">
    <label for="pwd">Password:</label>
   
      <asp:TextBox ID="txtpassword" runat="server" class="form-control" ></asp:TextBox>
  </div>
  <div class="checkbox">
    <label><input type="checkbox"/> Remember me</label>
  </div>
  <button type="submit" class="btn btn-default">Submit</button>

      </div>
    </div>
   


</asp:Content>
