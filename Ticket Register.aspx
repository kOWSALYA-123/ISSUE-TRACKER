<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ticket Register.aspx.cs" Inherits="AMC.Ticket_Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 335px;
        }
        .style2
        {
            width: 853px;
            text-align: right;
        }
        .style3
        {
            width: 981px;
        }
    </style>
</head>
<body style="height: 243px">
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td class="style2">
                Customer Code</td>
            <td class="style3">
                <asp:TextBox ID="TextBox1" runat="server" Width="337px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Customer Name</td>
            <td class="style3">
                <asp:TextBox ID="TextBox2" runat="server" Width="337px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Module</td>
            <td class="style3">
                <asp:TextBox ID="TextBox3" runat="server" Width="337px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Issue</td>
            <td class="style3">
                <asp:TextBox ID="TextBox4" runat="server" Width="337px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Register Date</td>
            <td class="style3">
                <asp:TextBox ID="TextBox5" runat="server" Width="337px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Consultant</td>
            <td class="style3">
                <asp:TextBox ID="TextBox6" runat="server" Width="337px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Fixed By</td>
            <td class="style3">
                <asp:TextBox ID="TextBox7" runat="server" Width="337px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Fixed On
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox8" runat="server" Width="337px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Issue Status</td>
            <td class="style3">
                <asp:RadioButton ID="rbtpending" runat="server" Text="Pending" />
                <asp:RadioButton ID="rbtcompleted" runat="server" Text="Completed" />
                <asp:RadioButton ID="rbthold" runat="server" Text="Hold" />
                <asp:RadioButton ID="rbtnotcompleted" runat="server" Text="Not Completed" />
            </td>
        </tr>
    </table>
    <asp:Button ID="btnsave" runat="server" Height="39px" 
        style="margin-left: 470px" Text="Save" Width="83px" />
    <asp:Button ID="btnclear" runat="server" Height="42px" 
        style="margin-left: 70px" Text="Clear" Width="85px" />
    </form>
</body>
</html>
