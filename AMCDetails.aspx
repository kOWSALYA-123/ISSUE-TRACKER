<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AMCDetails.aspx.cs" Inherits="IssueRegister.AMCDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 328px;
        }
        .style6
        {
            width: 1067px;
            margin-left: auto;
            margin-right: auto;
            text-align: center;
            height: 60px;
        }
        .style12
        {
            font-weight: normal;
        }
        .style9
        {
            width: 150px;
        }
    </style>
    <script type="text/javascript" language="javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.0/jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="  https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.js"> </script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="height: 65px; width: 100%; background: #227a89; margin-top: 13px;">
            <table>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lbluser" runat="server" Text="AMC DETAIL" Font-Bold="True" Font-Size="X-Large"
                            ForeColor="white"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table class="style1">
            <tr>
                <td class="style9">
                    Customer ID
                    <asp:Label ID="lbl_man1" runat="server" Text="*" Style="color: #FF0000"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtcustomerid" runat="server" Width="115px" Height="30px" MaxLength="50"
                        BackColor="#FFFF66"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    Customer Name
                </td>
                <td class="style3" style="width: 100px;">
                    <asp:DropDownList ID="ddlcustomer" runat="server" Width="160px" Height="30px" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlcustomer_SelectedIndexChanged" />
                         <asp:Label ID="lbl_msg1" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                </td>
                <td class="" style="width: 123px; visibility: hidden;">
                    Customer Name
                </td>
                <td class="style3">
                    <asp:Label ID="lbl_Name" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    AMC Start Date
                </td>
                <td>
                    <asp:TextBox ID="txtvalidateupto" runat="server" Width="194px" Height="30px" 
                        onkeypress="return isNumberKey(event)" MaxLength="10" 
                        ontextchanged="txtvalidateupto_TextChanged" AutoPostBack="true"></asp:TextBox>
                   
                    <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy" TargetControlID="txtvalidateupto"
                        PopupButtonID="txt_reqdate" PopupPosition="Right">
                    </asp:CalendarExtender>
                     <asp:Label ID="lbl_msg2" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                     <asp:Label ID="lbl_date" Text ="select greaterthan Todaydate" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                </td>
               
            </tr>
            <tr>
                <td class="style3">
                    AMC End Date
                </td>
                <td>
                    <asp:TextBox ID="txtenddate" runat="server" Width="194px" Height="30px" 
                        onkeypress="return isNumberKey(event)" MaxLength="10" 
                        ontextchanged="txtenddate_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtenddate"
                        PopupButtonID="txt_reqdate" PopupPosition="Right">
                    </asp:CalendarExtender>
                     <asp:Label ID="lbl_msg3" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                      <asp:Label ID="lb_date" Text ="select greaterthan Todaydate" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    <span class="style12">Payment Status</span>
                </td>
                <td class="style3">
                    <asp:CheckBox ID="chkpayment" runat="server" Text="Paid" />
                </td>
            </tr>
            <tr>
                <td class="style16">
                    Is Active [Y/N]
                </td>
                <td class="style18">
                    <asp:CheckBox ID="chk_isactive" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Button ID="btnsave" runat="server" Height="40px" Style="color: white; margin-left: 155px;
            margin-right: 0px; font-weight: bold; background-color: #227a89" Text="Save"
            Width="119px" OnClick="btnsave_Click" />
        <asp:Button ID="btnclear" runat="server" Height="40px" Style="color: white; margin-left: 48px;
            font-weight: bold; background-color: #227a89" Text="Clear" Width="102px" OnClick="btnclear_Click" />
        <asp:Label ID="lbl_save" Text="Error In Save" Style="color: #FF0000" runat="server"
            Visible="false"></asp:Label>
    </div>
    <script type="text/javascript">
        $('#<%=ddlcustomer.ClientID%>').chosen();
    </script>
    <script type="text/javascript" language="javascript">
        

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
