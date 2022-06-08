<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="LoginWebApp.CRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

    <style>
        form{
            position: absolute;
            top: 15%;
            left: 20%;
        }

        #details{
            position: absolute;
            top: 5%;
            left: 25%;
        }
       
    </style>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
        var obj = { status: false, element: null };
        function DltConfirm(ev) {
            if (obj.status) {
                return true;
            };
            swal({
                title: "Are you sure?",
                text: "Your will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: true
            },
                function () {
                    obj.status = true;
                    obj.element = ev;
                    obj.element.click();
                });
            return false;
        };
    </script>
</head>
<body>
     <div id="details"><asp:Label ID="labelEmpDetails" runat="server" Text="Manage Employee" Font-Bold="True" Font-Size="Larger"></asp:Label></div>
     <form id="form1" runat="server">
        
    
   <div>

       <asp:Label ID="labelEmployeeID" runat="server" Text="Employee ID" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="employeeIDTextBox" runat="server" ></asp:TextBox>

   </div><br>
    <div>
        
        <asp:Label ID="labelEmployeeName" runat="server" Text="Employee Name"></asp:Label>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="empNameTextBox" runat="server"></asp:TextBox>
    </div><br>
         <div>
        
        <asp:Label ID="labelDesignation" runat="server" Text="Designation"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             &nbsp;&nbsp;
        <asp:TextBox ID="designationTextBox" runat="server"></asp:TextBox>
    </div><br>
          <div>
        
        <asp:Label ID="labelAddress" runat="server" Text="Address"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox>
    </div><br>
          <div>
        
        <asp:Label ID="labelSalary" runat="server" Text="Salary"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="salaryTextBox" runat="server"></asp:TextBox>
    </div><br>
   
    
       <div>
       
           <asp:Button ID="addBtn" runat="server" Text="ADD" OnClick="addBtn_Click" />
          
           <asp:Button ID="clrBtn" runat="server" Text="Clear" OnClick="clrBtn_Click" />
       
           <asp:Button ID="logoutBtn" runat="server" Text="Log out" OnClick="logoutBtn_Click" />
       
           </div><br>
          <div id="grid">
          <asp:GridView ID="empGridView" runat="server" OnRowEditing="empGridView_RowEditing"
              OnRowCancelingEdit="empGridView_RowCancelingEdit" OnRowUpdating="empGridView_RowUpdating" OnRowDeleting="empGridView_RowDeleting"
              DataKeyNames="EmployeeID" CssClass="table" AutoGenerateColumns="false">
              <Columns>
                 <asp:BoundField HeaderText="ID" DataField="EmployeeID"/>
                  <asp:TemplateField HeaderText="Name">
                      <ItemTemplate>
                          <asp:Label runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Designation">
                      <ItemTemplate>
                          <asp:Label runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtDesignation" runat="server" Text='<%# Bind("Designation") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Address">
                      <ItemTemplate>
                          <asp:Label runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Salary">
                      <ItemTemplate>
                          <asp:Label runat="server" Text='<%# Eval("Salary") %>'></asp:Label>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtSalary" runat="server" Text='<%# Bind("Salary") %>'></asp:TextBox>
                      </EditItemTemplate>
                  </asp:TemplateField>

                  <asp:CommandField ShowDeleteButton="true" HeaderText="Action" />
                  <%--<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure?');"  ></asp:LinkButton>--%>
                  <asp:CommandField ShowEditButton="true" HeaderText="Action"/>
              </Columns>
         </asp:GridView>
    </div>
   
         </form>
    
   
        

       
</body>
</html>
