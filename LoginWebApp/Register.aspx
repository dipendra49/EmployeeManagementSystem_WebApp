<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LoginWebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
    <style>
        form{
            position: absolute;
            top:15%;
            left:40%;
        }

        #register{
            position:absolute;
            top:5%;
            left:41%;

        }

        #passCheckBox{
            cursor:pointer;
        }
    </style>
     <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <script>
        function Validation() {
            alert("Please fill appropriate value!!");
        }
    </script>

    <script>
        function myshowp() {
            ckbox = $('#passCheckBox')
            txtBox1 = $('#passwordTextBox')
            txtBox2 = $('#conPassTextBox')

            if (ckbox.is(':checked')) {
                txtBox1.attr("Type", "Text");
                txtBox2.attr("Type", "Text");
            }
            else {
                txtBox1.attr("Type", "Password");
                txtBox2.attr("Type", "Password");
            }
           
        }
    </script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    
</head>
<body>
    <div id="register"><asp:Label ID="labelMessage" runat="server" Text="Create Account" Font-Bold="True" Font-Size="Larger"></asp:Label></div>
    <form id="form1" runat="server">
        
    
   <div>

       <asp:Label ID="labelEmail" runat="server" Text="Email"></asp:Label><br/>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>

   </div>
    <div>
        
        <asp:Label ID="labelPassword" runat="server" Text="Password"></asp:Label><br/>
        <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
    </div>
         <div>
        
        <asp:Label ID="labelConPass" runat="server" Text="Confirm Password"></asp:Label><br/>
            
        <asp:TextBox ID="conPassTextBox" runat="server" TextMode="Password"></asp:TextBox>
    </div>
         <asp:CheckBox ID="passCheckBox" runat="server" Text="Show Password" OnClick="myshowp()" CssClass="checkbox"/><br/>
   
    
       <div>
        <asp:Button ID="signupBtn" runat="server" Text="Sign Up" OnClick="signupBtn_Click1" />
        <asp:Button ID="clearBtn" runat="server" Text="Clear" OnClick="clearBtn_Click" />
        <asp:Button ID="signinBtn" runat="server" Text="Sign In" OnClick="signinBtn_Click" />
           </div>
   
    
       
        
   
    
       
            
        
   
    
       
        
   
    
       
    </form>
    
   
    
</body>
</html>
