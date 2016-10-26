<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Splash.aspx.cs" Inherits="BattlingElementalTitans.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" type="text/css" href="css/Welcome.css" />
    <title>Welcome to B.E.T.T.E.R</title>
     <style type="text/css">
         .auto-style1 {
             left: 10px;
             bottom: 0;
         }
     </style>
</head>
<body>
    <audio controls="controls" autoplay="autoplay">
        <source src="sounds/The Dawn.mp3" type="audio/mpeg" />
        Your browser does not support the audio element.
    </audio>
    <div id="background"><img src="images/background/WelcomeBG.jpg" /></div> 
    <form id="form1" runat="server">
    <div id ="buttons">
        <a href="Login.aspx" class="buttons">Log  in</a>
        <a href="Register.aspx" class="buttons">Register</a>
    </div>
    </form>
    <footer id="footer" class="auto-style1">
        <p>Posted by: NewU Company</p>
        <p>Contact information: c3218124@uon.edu.au c3198416@uon.edu.au</p>
    </footer>
</body>
</html>
