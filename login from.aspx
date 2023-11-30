<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login from.aspx.cs" Inherits="crud.login_from" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
    <link rel="stylesheet" href="style.css" />
    <style>
        .login{
            box-shadow:0 0 20px 0;
            background-color:transparent;
            width:500px;
            padding:50px;
            display:flex;
            flex-direction:column;
            color:white;
        }
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            width:100vw;
            background:linear-gradient(to right,skyblue,purple);
        }
        .input{
            background-color:transparent;
            color:white;
            font-weight:bold;
            border-radius:10px;
            outline:none;
            border:1px solid white;
            padding:10px;
            width:100%;
        }
        .btn1{
            background-color:transparent;
            color:white;
            padding:10px;
            outline:none;
            border:1px solid white;
            border-radius:10px;
            padding-top:5px;
            transition:0.3s;
        }
        .btn1:hover{
            background-color:blue;
        }
    </style>
</head>
<body>
    <form id="login" runat="server" >
        <div class="login">
            <h1 class="text-center">Admin Login</h1>
            <div class="mb-3">
                <label class="form-label">Username</label>
                <asp:TextBox ID="username" runat="server" CssClass=" input" ></asp:TextBox>
                <asp:Label ID="Error1" runat="server" Text="Label" Visible="false" CssClass="text-danger "></asp:Label>
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox ID="password1" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                <asp:Label ID="Error2" runat="server" Text="Label" Visible="false" CssClass="text-danger"></asp:Label>
            </div>
            <a href="#" class="pb-2">forget your password?</a>
            <asp:Button ID="submit" runat="server" Text="Sign In" CssClass="btn1" OnClick="submit_Click"/>

       </div>
    </form>
</body>
</html>
