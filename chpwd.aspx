<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chpwd.aspx.cs" Inherits="Employee_Management_Systum.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
     <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/style.css") %>" />
     <style>
        body{
            height:100vh;
            width:100vw;
            background:linear-gradient(to right,mediumpurple,purple);
            overflow-x:hidden;
            
        }
        .body{
            display:flex;
            justify-content:space-around;
            align-items:center;
            height:100vh;
        }
        .form{
            box-shadow:0 0 10px 0;
            color:white;
            padding:20px;
        }
        .form label{
            color:white;
        }
        .img{
            width:40%;
        }
        .img img{
            width:100%;
            object-fit:contain;
        }
        
         </style>
</head>
<body>
    
    <nav>
                <div class="logo">
                    <a href="home.aspx"><img src="img/12-121714_thumb-image-hd-png-download-removebg-preview.png" /></a>
                </div>
                <ul>
                    <li><a href="home.aspx">Home</a></li>
                    <li><a href="employee.aspx" >Employee Record</a></li>
                    <li><a href="department.aspx" >Department List</a></li>
                    <li><a href="#" class="active">Change Password</a></li>
                    
                </ul>
            </nav>
    <div class="body">
        <div class="img">
            <img src="img/employee_man-removebg-preview.png"/>
        </div>
    <form id="form1" runat="server">
        <div class="form">
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Old Password</label>
                            <asp:TextBox ID="Oldpwd" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label runat="server" ID="err1" Visible="false" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="mb-3">
                            <label for="exampleInputPassword1" class="form-label">New Password</label>
                            <asp:TextBox ID="Newpwd" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label runat="server" ID="err3" Visible="false" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="mb-3">
                            <label for="exampleInputPassword1" class="form-label">Confirm Password</label>
                            <asp:TextBox ID="Conpwd" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Label runat="server"  ID="err2" Visible="false" ForeColor="Red"></asp:Label>
                        </div>
                        
                        
                        
                        <div>
                        <asp:Button runat="server"  ID="Submit" CssClass="btn btn-success" Text="Update"  OnClick="Submit_Click"/>
                       
                        </div>
        </div>
    </form>

        </div>
</body>
</html>
