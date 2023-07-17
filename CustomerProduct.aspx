<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CustomerProduct.aspx.cs" Inherits="IssueRegister.CustomerProduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 100px;
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
            width: 0px;
        }
        .div.dd_chk_select
        {
            border-color: #CCCCCC;
            border-style: solid;
            border-width: 1px;
            height: 18px;
            padding: 0px 0px 0px 0px;
            text-align: left;
            vertical-align: middle;
            font-size: 12px;
            text-decoration: none;
            overflow: visible;
            color: Black;
            background-color: white;
            background-image: url(WebResource.axd?d=m6io2_PcjtvK5V-S4BAgfxuJzwnZlCt7GDlBQzK1AAyHY8sesDKUUsGehIMqofgfIwD04NWRMvDplxReeUGafE45QG9rbveSPoCbIfJbd-uz7zTy0wjSYrsq4WUo1AmFuCuuiryIeBjA0j6w_QCkRTim0n9EipcwUo9NVvcxJdc1&t=635071748400000000);
            background-position: right center;
            background-repeat: no-repeat;
        }
    </style>
    <script type="text/javascript" language="javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.0/jquery.min.js"> </script>
    <script type="text/javascript" language="javascript" src="  https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.js"> </script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://jquery.min.js">
    </script>
    <script type="text/javascript" src="https://jquery.multiselect.css" rel="stylesheet">
    </script>
    <script type="text/javascript" src="https://jquery.multiselect.js">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="height: 65px; width: 100%; background: #227a89; margin-top: 13px;">
            <table>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lbluser" runat="server" Text="CUSTOMER PRODUCT" Font-Bold="True" Font-Size="X-Large"
                            ForeColor="white"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table class="style1">
            <tr>
                <td class="style9">
                    Customer Name
                    <asp:Label ID="lbl_man1" runat="server" Text="*" Style="color: #FF0000"></asp:Label>
                </td>
                <td class="style3" style="width: 100px; padding-bottom: 18PX;">
                    <asp:DropDownList ID="ddlcustomer" runat="server" Width="300px" Height="33px" AutoPostBack="True" />
                </td>
            </tr>
            <tr>
                <td class="style9">
                    Product Name
                </td>
                <td>
                    <asp:Panel ID="panelproduct" runat="server" Height="328px" Width="270px" BorderStyle="solid"
                        BorderWidth="1px" Direction="LefttoRight" scrollbar="auto" Style="display: block;
                        background: white; left: 483px; margin-top: 23px;" 
                        CssClass="multiselect-checkbox">
                        <asp:CheckBoxList ID="chkboxlistproduct" runat="server" CssClass="custom-checkbox checkbox"
                            AutoPostBack="true" OnSelectedIndexChanged="chkboxlistproduct_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lbl_msg" Text="Product Already Exit" Style="color: #FF0000" runat="server"
                        Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style16">
                    <asp:Label ID="lbl_cust" runat="server" Text=" Is Active [Y/N]"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chk_isactive" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:Button ID="btnsave" runat="server" Height="40px" Style="color: white; margin-left: 199px;
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
</asp:Content>
