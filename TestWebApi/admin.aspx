<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="TestWebApi.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
        <link rel="stylesheet" type="text/css" href="/Styles/Style.css"/>
    <div class="b-popup" id="popup1">
    <div class="b-popup-content">
        <p id="title">Enter login and password</p>
        <input id="login" type="text"/>
        <input id="password" type="text"/>
        <input id="cancel" type="button" onclick="PopUpHide()" value="Cancel"/>
        <input id="ok" type="button" onclick="Auth()" value="Ok"/>
    </div>
</div>
    <form id="form1" runat="server">
    <div>
    <input id="SignOut" type="button" value="Siqn Out" onclick="document.location.replace('/default.aspx');"/>
    </div>
    </form>
    <script src="/Scripts/default.js"></script>
    <script>window.onload = PopUpShow();</script>
</body>
</html>
