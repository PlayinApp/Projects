﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Adminexample.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<meta name="viewport" content="width=1,initial-scale=1,user-scalable=1" />
	<title>Login</title>

	<link href="http://fonts.googleapis.com/css?family=Lato:100italic,100,300italic,300,400italic,400,700italic,700,900italic,900" rel="stylesheet" type="text/css">
	<link rel="stylesheet" type="text/css" href="assets/bootstrap/css/bootstrap.min.css" />
	<link rel="stylesheet" type="text/css" href="assets/css/styles.css" />
	
	<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>+
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
     
  
        
    <section class="container login-form">
		<section>
			  <form id="form1" runat="server">
				<img src="https://s3.amazonaws.com/uploads.hipchat.com/669844/4702539/MWhn0nBbDMp8d8o/Untitled.png" alt="" class="img-responsive" />
			
				<div class="form-group">
					<input type="email" name="email" required class="form-control" placeholder="Enter email or nickname" />
					<span class="glyphicon glyphicon-user"></span>
				</div>
				
				<div class="form-group">
					<input type="password" name="password" required class="form-control" placeholder="Enter password" />
					<span class="glyphicon glyphicon-lock"></span>
				</div>
				
				<button type="submit" name="go" class="btn btn-primary btn-block">Login Now</button>
				
				<a href="#">Reset password</a> or <a href="#">create account</a> 
		 </form>
		</section>
	</section>
	
   
</body>
</html>