<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="Usercredential.aspx.cs" Inherits="IssueRegister.Usercredential" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 328px;
        }
        .style3
        {
            width: 458px;
            font:10px;
        }
        .style5
        {
            width: 107px;
            text-align: left;
        }
        .style6
        {
            width: 1067px;
            margin-left: auto;
            margin-right: auto;
            text-align: center;
            height: 60px;
        }
        .style7
        {
            width: 107px;
            text-align: left;
            height: 48px;
        }
        .style8
        {
            height: 48px;
        }
        .style9
        {
            width: 107px;
            text-align: left;
        }
    </style>
    <script type="text/javascript" language="javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.0/jquery.min.js"></script>
     <script type="text/javascript" language="javascript" src="  https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.js"> </script>
     <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="height: 65px; width: 100%; background: #227a89; margin-top: 10px;">
            <table>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lbluser" runat="server" Text="USER CREDENTIAL" Font-Bold="True" Font-Size="X-Large"
                            ForeColor="white"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <table class="style1">
            <tr>
                <td class="style9">
                    UserID
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtuserid" runat="server" Width="95px" Height="30px" Style="margin-left: 0px"
                        BackColor="#FFFF66"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    Email
                    <asp:Label ID="lbl_man" runat="server" Text="*" style="color: #FF0000"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtemail" runat="server" Width="357px" Height="30px" Style="margin-left: 0px"></asp:TextBox>
                    <asp:Label ID="lbl_msg1" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    Password
                    <asp:Label ID="lbl_man1" runat="server" Text="*" style="color: #FF0000"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtpassword" runat="server" Width="357px" Height="30px" Style="margin-left: 0px"></asp:TextBox>
                    <asp:Label ID="lbl_msg2" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    User Name
                    <td class="style3">
                        <asp:TextBox ID="TXTUSERNAME" runat="server" Width="357px" Height="30px" Style="margin-left: 0px"></asp:TextBox>
                        <asp:Label ID="lbl_msg3" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td class="style5">
                    Department 
                    <td class="style3">
                        <asp:TextBox ID="txtdepartment" runat="server" Width="357px" Height="30px" Style="margin-left: 0px"></asp:TextBox>
                       
                    </td>
            </tr>
            <tr>
                <td class="style7">
                    Role
                </td>
                <td class="style8">
                    <asp:RadioButton ID="rbtConsultant" runat="server" Text="Consultant" GroupName="Roles"
                        Style="font-weight: bold" oncheckedchanged="RadioButton3_CheckedChanged" AutoPostBack="true"/>
                    <asp:RadioButton ID="rbtDeveloper" runat="server" Text="Developer" GroupName="Roles"
                        Style="font-weight: bold" oncheckedchanged="RadioButton2_CheckedChanged" AutoPostBack="true"/>
                    <asp:RadioButton ID="rbtCustomer" runat="server" Text="Customer" GroupName="Roles"
                        Style="font-weight: bold" oncheckedchanged="RadioButton1_CheckedChanged" AutoPostBack="true"/>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    Mobile Number
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtwhatsppno" runat="server" Width="357px" Height="30px" 
                        Style="margin-left: 0px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                        <asp:Label ID="lbl_msg4" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
               <td class="style5">
                   <asp:Label ID="lbl_cust" runat="server" Text="Customer Name"></asp:Label>
                </td>
                <td class="style3" style="width: 100px;">
                    <asp:DropDownList ID="ddlcustomer" runat="server" Width="160px" Height="30px" AutoPostBack="True" />
                </td>
            </tr>
            <tr>
                <td class="style5">
                    Is Active [Y/N]
                </td>
                <td class="style3">
                    <asp:CheckBox ID="chk_isactive" runat="server" /> 
                </td>
            </tr>
        </table>
        <br />
    </div>
    <p style="height: 56px">
        <asp:Button ID="btnsave" runat="server" Height="42px" Style="color: white; margin-left: 226px;
            font-weight: bold; background-color: #227a89" Text="Save" Width="96px" OnClick="btnsave_Click" />
        <asp:Button ID="btnclear" runat="server" Height="42px" Style="color: white; margin-left: 100px;
            font-weight: bold; background-color: #227a89" Text="Clear" Width="96px" OnClick="btnclear_Click" />
             <asp:Label ID="lbl_save" Text ="Error In Save" style="color: #FF0000" runat="server" visible="false"></asp:Label>
    </p>
     <script type="text/javascript">
         $('#<%=ddlcustomer.ClientID%>').chosen();
     </script>
    <script type="text/javascript" language="javascript">
        function Alert_CodeBehind(alt) {
            document.getElementById('dimmer').style.display = (true ? 'block' : 'none');
            alert(alt);
            document.getElementById('dimmer').style.display = (false ? 'block' : 'none');
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        function Alert(str) {
            document.getElementById('dimmer').style.display = (true ? 'block' : 'none');
            alert(str + "..!");
            document.getElementById('dimmer').style.display = (false ? 'block' : 'none');
            return false;
            return true;
        }
        
    </script>
</asp:Content>
