<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Employee_Management_Systum.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management Systum</title>
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/style.css") %>" />
    <style>
        body{
            height:100vh;
            width:100vw;
            background:linear-gradient(to right,mediumpurple,purple);
            overflow:hidden;
        }
        .logout{
            background-color:transparent;
            border:none;
            font-size:15px;
            color:white;
            cursor:pointer;
        }
        .logout:hover{
            color:rebeccapurple;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
            <nav>
                <div class="logo">
                    <a href="home.aspx"><img src="img/12-121714_thumb-image-hd-png-download-removebg-preview.png" /></a>
                </div>
                <ul>
                    <li><a href="login from.aspx">Welcom <asp:Label runat ="server" ID="User"></asp:Label></a></li>
                    <li><a href="#" class="active">Home</a></li>
                    <li><a href="employee.aspx">Employee Record</a></li>
                    <li><a href="department.aspx">Department List</a></li>
                    <%if (Session["user"] != null)
                        {%>

                    <li><a href="chpwd.aspx">Change Password</a></li>
            <%}%>
                    <%if (Session["user"] != null)
                        {%>
                    <li><a href="#"><asp:Button runat="server" ID="Logout1" OnClick="Logout1_Click" Text="Logout" CssClass="logout"/></a></li>
                    <%}%>
                </ul>
            </nav>

        <div class="hero">
            <div class="img">
                <img src="img/employee_man-removebg-preview.png"/>
            </div>
            <div class="text">
                <h1>Employee <br />
                    Management<br />
                    System
                </h1>
                <p>
                    In the midst of a bustling city, hidden gems await discovery. Vibrant markets bustle with activity, while tranquil parks provide an oasis of calm. Each corner tells a story, and every step is a chance to uncover new adventures.
                </p>

                <button><a href="#">Get Start</a></button>
            </div>

        </div>
        <footer>
            <p>Under the canopy of stars, nature's symphony emerges. Crickets chirp in rhythmic harmony, a gentle breeze rustles through leaves, and the moon casts its silvery glow. In this tranquil night, worries dissipate, replaced by a profound sense of connection to the universe and the peace it offers</p>
        </footer>
           




        
    </form>
</body>
</html>
