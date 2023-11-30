<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="Employee_Management_Systum.department" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
     <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/style.css") %>" />
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css" />
     <style>
        body{
            height:100vh;
            width:100vw;
            background:linear-gradient(to right,mediumpurple,purple);
            overflow-x:hidden;
        }
        .img{
            width:30px;
            height:40px;
            object-fit:contain;
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
                    <li><a href="home.aspx">Home</a></li>
                    <li><a href="employee.aspx" >Employee Record</a></li>
                    <li><a href="#" class="active">Department List</a></li>
                    <li><a href="#">About</a></li>
                   
                </ul>
            </nav>
        <div class="emp">
            <div class="tbl-head bg-dark mb-3">
                <button class="btn btn-success"  type="button" ><a href="add_dept.aspx">Add New Record</a></button>
                <span>
                    <button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal1" type="button">Update</button>
                    <button class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#exampleModal2" type="button">Delete</button>
                </span>
            </div>
            <asp:GridView ID="Emptbl" runat="server" AutoGenerateColumns="False" CssClass="table table-borderd"  BorderColor="#2A2A2A" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="White" GridLines="Vertical" DataKeyNames="dept_id" OnRowCommand="Emptbl_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Department ID" DataField="dept_id" />
                    <asp:BoundField HeaderText="Department Name" DataField="dept_name" />
                    <asp:BoundField HeaderText="Department Location" DataField="location" />
                     <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="Update_link" NavigateUrl='<%# "~/deptupdate.aspx?id=" + Eval("dept_id") %>' CssClass="btn btn-primary"> <i class="fa-solid fa-pen-to-square"></i></asp:HyperLink>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                         <ItemTemplate>
                            <asp:LinkButton runat="server" ID="Delete_row"  CommandArgument='<%# Eval("dept_id") %>' CssClass="btn btn-danger icon-delete "   > <i class="fa-solid fa-trash"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="#3a3a3a" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2a2a2a" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#2a2a2a" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
               
            </asp:GridView>
        </div>
   


    <%--modal for update--%>
    <div class="modal fade" id="exampleModal2" tabindex="-1" aria-labelledby="exampleModalLabel2" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabe2">Delete Department</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Department Id</label>
                            <asp:TextBox ID="Deptid" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <asp:Label runat="server" ID="err1" Visible="false" ForeColor="Red"></asp:Label>
                        </div>
                       

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <asp:Button runat="server"  ID="Delete" CssClass="btn btn-danger" Text="Delete Department"   OnClick="Delete_Click" />
                    </div>
                </div>
            </div>
        </div>

         <div class="modal fade" id="exampleModal1" tabindex="-1" aria-labelledby="exampleModalLabel1" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Update Deprtment</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Deprtment Id</label>
                            <asp:TextBox ID="Deptid1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <asp:Label runat="server" ID="Label1" Visible="false" ForeColor="Red"></asp:Label>
                        </div>
                       

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <asp:Button runat="server"  ID="Update" CssClass="btn btn-primary" Text="Update Employee"   OnClick="Update_Click" />
                    </div>
                </div>
            </div>
        </div>

        </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <script src="logic.js"></script>
</body>
</html>
