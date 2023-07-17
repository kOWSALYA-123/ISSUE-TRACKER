<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="CustomerMaster.aspx.cs" Inherits="IssueRegister.CustomerMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style10
        {
            width: 1067px;
            margin-left: auto;
            margin-right: auto;
            text-align: center;
            height: 60px;
        }
        .style15
        {
            width: 143px;
            text-align: left;
            height: 41px;
            font-family: Calibri;
            font-size: larger;
        }
        .style16
        {
            width: 143px;
        }
        .style17
        {
            height: 54px;
            padding-bottom: 10px;
        }
        .style19
        {
            width: 178px;
            height: 3px;
            font-size: MEDIUM;
            padding-bottom: 10px;
        }
        .style21
        {
            width: 178px;
            height: 5px;
            font-size: MEDIUM;
            padding-bottom: 10px;
        }
        .style27
        {
            height: 24px;
            padding-bottom: 10px;
        }
        .style28
        {
            width: 143px;
            text-align: left;
            height: 24px;
            font-family: Calibri;
            font-size: larger;
        }
        .style34
        {
            height: 9px;
        }
        .style35
        {
            width: 143px;
            text-align: left;
            height: 9px;
            font-family: Calibri;
            font-size: larger;
        }
        .style36
        {
            width: 151px;
            text-align: left;
            height: 9px;
            font-family: Calibri;
            font-size: larger;
        }
        .style37
        {
            width: 143px;
            text-align: left;
            height: 15px;
            font-family: Calibri;
            font-size: larger;
        }
        .style38
        {
            height: 15px;
            padding-bottom: 10px;
        }
        .style40
        {
            width: 337px;
            height: 15px;
            font-size: MEDIUM;
            padding-bottom: 10px;
        }
        .style41
        {
            width: 151px;
            text-align: left;
            height: 15px;
            font-family: Calibri;
            font-size: larger;
        }
        .style43
        {
            height: 25px;
            padding-bottom: 10px;
        }
        .style44
        {
            width: 151px;
            text-align: left;
            height: 25px;
            font-family: Calibri;
            font-size: larger;
        }
        .style45
        {
            width: 337px;
            height: 25px;
            font-size: MEDIUM;
            padding-bottom: 10px;
        }
        .style46
        {
            width: 143px;
            text-align: left;
            height: 25px;
            font-family: Calibri;
            font-size: larger;
        }
        .style47
        {
            width: 143px;
            text-align: left;
            height: 14px;
            font-family: Calibri;
            font-size: larger;
        }
        .style48
        {
            height: 14px;
            padding-bottom: 10px;
        }
        .style50
        {
            width: 337px;
            height: 14px;
            font-size: MEDIUM;
            padding-bottom: 10px;
        }
        .style51
        {
            width: 151px;
            text-align: left;
            height: 14px;
            font-family: Calibri;
            font-size: larger;
        }
        .style52
        {
            width: 142px;
            text-align: left;
            height: 5px;
            font-family: Calibri;
            font-size: larger;
        }
        .style54
        {
            width: 337px;
            height: 3px;
            font-size: MEDIUM;
            padding-bottom: 10px;
        }
        .style55
        {
            width: 151px;
            text-align: left;
            height: 3px;
            font-family: Calibri;
            font-size: larger;
        }
        .style57
        {
            height: 3px;
            padding-bottom: 10px;
        }
        .style58
        {
            width: 143px;
            text-align: left;
            height: 3px;
            font-family: Calibri;
            font-size: larger;
        }
        .uppercase
        {
            text-transform: uppercase;
        }
    .style59
    {
        width: 142px;
        text-align: left;
        height: 3px;
        font-family: Calibri;
        font-size: larger;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="overflow: hidden; height: 1000px; margin-bottom: 80px; margin-bottom: -8PX;">
        <div style="height: 65px; width: 100%; background: #227a89; margin-top: 10px;">
            <table>
                <tr>
                    <td class="style10">
                        <asp:Label ID="lbluser" runat="server" Text="CUSTOMER MASTER" Font-Bold="True" Font-Size="X-Large"
                            ForeColor="white"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table>
            <tr>
                <td class="style52">
                    CustomerID
                </td>
                <td class="style21">
                    <asp:TextBox ID="txtcustomerid" runat="server" Width="95px" Height="30px" Style="margin-left: 12px"
                        BackColor="#FFFF66"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td class="style59">
                    CustomerName
                </td>
                <td class="style54">
                    <asp:TextBox ID="txtcustomername" runat="server" Width="366px" Height="30px" 
                        Style="margin-left: 10px" ontextchanged="txtcustomername_TextChanged" 
                        AutoPostBack="true"></asp:TextBox>
                    <asp:Label ID="lbl_message1" Text="Required" Style="color: #FF0000" runat="server"
                        Visible="false"></asp:Label>
                </td>
               <%-- <td class="style55">
                    CustomerCode
                </td>--%>
                <td class="style19">
                    <asp:TextBox ID="txtcustomercode" runat="server" Width="128px" Height="30px" Style="margin-left: 0px"
                        CssClass="uppercase" OnTextChanged="txtcustomercode_TextChanged" AutoPostBack="true" Visible="false"></asp:TextBox>
                    <asp:Label ID="lbl_message" Text="Required" Style="color: #FF0000" runat="server"
                        Visible="false"></asp:Label>
                </td>
                
            </tr>
        </table>
        <table>
            <tr>
                <td class="style41">
                    Address
                </td>
                <td class="style40">
                    <asp:TextBox ID="txtaddress1" TextMode="multiline" resize="none" Columns="50" Rows="5"
                        runat="server" Width="477px" Height="77px" Style="margin-left: 0px" />
                    <asp:Label ID="lbl_message2" Text="Required" Style="color: #FF0000" runat="server"
                        Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td class="style28">
                    Country
                </td>
                <td class="style27">
                    <asp:DropDownList ID="ddlcountry" runat="server" Width="302px" Height="30px" AutoPostBack="True"
                        Style="margin-left: 6px" />
                </td>
            </tr>
            <tr>
                <td class="style58">
                    Phone
                </td>
                <td class="style57">
                    <asp:TextBox ID="txtphone" runat="server" Width="283px" Height="30px" Style="margin-left: 5px"
                        onkeypress="return isNumberKey(event)"></asp:TextBox>
                    <asp:Label ID="lbl_message3" Text="Required" Style="color: #FF0000" runat="server"
                        Visible="false"></asp:Label>
                </td>
                <td class="style55">
                    Email
                </td>
                <td class="style54">
                    <asp:TextBox ID="txtemail" runat="server" Width="366px" Height="30px" Style="margin-left: 11px"></asp:TextBox>
                    <asp:Label ID="Label3" Text="Required" Style="color: #FF0000" runat="server" Visible="false"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style35">
                    <strong>Contact 1</strong>
                </td>
                <td class="style34">
                </td>
                <td class="style36">
                    <strong>Contact 2 </strong>
                </td>
            </tr>
            <tr>
                <td class="style37">
                    Name
                </td>
                <td class="style38">
                    <asp:TextBox ID="txtcontact1name" runat="server" Width="277px" Height="30px" Style="margin-left: 5px"></asp:TextBox>
                </td>
                <td class="style41">
                    Name
                </td>
                <td class="style40">
                    <asp:TextBox ID="txtcontact2name" runat="server" Width="277px" Height="30px" Style="margin-left: 11px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style46">
                    Phone No
                </td>
                <td class="style43">
                    <asp:TextBox ID="txtcontact1phoneno" runat="server" Width="277px" Height="30px" Style="margin-left: 6px"
                        onkeypress="return isNumberKey(event)"></asp:TextBox>
                </td>
                <td class="style44">
                    Phone No
                </td>
                <td class="style45">
                    <asp:TextBox ID="txtcontact2phoneno" runat="server" Width="277px" Height="30px" Style="margin-left: 11px"
                        onkeypress="return isNumberKey(event)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style47">
                    Email
                </td>
                <td class="style48">
                    <asp:TextBox ID="txtcontact1email" runat="server" Width="277px" Height="30px" Style="margin-left: 6px"></asp:TextBox>
                </td>
                <td class="style51">
                    Email
                </td>
                <td class="style50">
                    <asp:TextBox ID="txtcontact2email" runat="server" Width="277px" Height="30px" Style="margin-left: 11px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    Remarks
                </td>
                <td class="style17">
                    <asp:TextBox ID="txtremarks" TextMode="multiline" runat="server" Width="477px" Height="87px"
                        Style="margin-left: 3px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style16">
                    Is Active [Y/N]
                </td>
                <td>
                    <asp:CheckBox ID="chk_isactive" runat="server" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnsave" runat="server" Height="42px" Style="color: white; margin-left: 152px;
            font-weight: bold; background-color: #227a89; margin-top: 0px;" Text="Save" Width="126px"
            OnClick="btnsave_Click" ForeColor="Black" />
        <asp:Button ID="btnclear" runat="server" Height="42px" Style="color: white; margin-left: 53px;
            font-weight: bold; background-color: #227a89" Text="Clear" Width="126px" OnClick="btnclear_Click" />
        <asp:Label ID="lbl_save" Text="Error In Save" Style="color: #FF0000" runat="server"
            Visible="false"></asp:Label>
    </div>
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
        
   
    </script>
</asp:Content>
