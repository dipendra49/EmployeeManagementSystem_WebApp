<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginWebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css"/>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <style>
        form{
            position: absolute;
            top: 15%;
            left: 40%;
        }
        #login{
            position:absolute;
            top:5%;
            left:44%;
        }

        #passCheckBox{
            cursor:pointer;
        }

        #chkRememberMe{
            cursor:pointer;
        }
    </style>

     <script>
        function myshowp() {
            ckbox = $('#passCheckBox')
            txtBox = $('#passwordTextBoxLogin')

            if (ckbox.is(':checked')) {
                txtBox.attr("Type", "Text");
            }
            else {
                txtBox.attr("Type", "Password");
            }
           
        }
     </script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</head>
<body>
    <asp:Label ID="label1" runat="server"></asp:Label><br>
      <div id="login"><asp:Label ID="labelLogin" runat="server" Text="Login" Font-Bold="True" Font-Size="Larger"></asp:Label><br></div>
     <form id="form1" runat="server">
       
        
    
   <div>

       <asp:Label ID="labelEmailLogin" runat="server" Text="Email"></asp:Label><br>
        <asp:TextBox ID="emailTextBoxLogin" runat="server"></asp:TextBox>

   </div>
    <div>
        
        <asp:Label ID="labelPasswordLogin" runat="server" Text="Password"></asp:Label><br>
        <asp:TextBox ID="passwordTextBoxLogin" runat="server" TextMode="Password"></asp:TextBox>
    </div>
          <asp:CheckBox ID="passCheckBox" runat="server" Text="Show Password" OnClick="myshowp()" /><br/>
    <asp:CheckBox ID="chkRememberMe" runat="server" />
          Remember me:
        
    
       <div>
        <asp:Button ID="signupBtnLogin" runat="server" Text="Create Account" OnClick="signupBtnLogin_Click" />
        <asp:Button ID="clearBtnLogin" runat="server" Text="Clear" OnClick="clearBtnLogin_Click" />
        <asp:Button ID="signinBtnLogin" runat="server" Text="Login" OnClick="signinBtnLogin_Click" />
           </div>
   
    
       
        
   
    
       
            
        
   
    
       
        
   
    
       
    </form>
</body>
</html>
