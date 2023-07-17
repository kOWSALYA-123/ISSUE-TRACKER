<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verification.aspx.cs" Inherits="AMC.Verification" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p>
      </p>
      
        <asp:TextBox ID="txt_email" runat="server" Height="25px" 
            style="margin-left: 451px" Width="233px" placeholder="Enter EmailId"></asp:TextBox>
            <br />
            <br />

     <asp:Button ID="btn_Login" Text="Send" class="button" runat="server" 
        OnClick="btn_login_Click" style="margin-left: 625px" Width="54px" />
        <br />
          <br />
         <asp:TextBox ID="txt_code" runat="server" Height="25px" 
            style="margin-left: 451px" Width="233px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btn_ok" Text="Verify Code" class="button" runat="server" 
             OnClick="btn_login_Click" style="margin-left: 625px" Width="53px" />
    </form>
</body>
</html>
