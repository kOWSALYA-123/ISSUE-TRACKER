<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Email.aspx.cs" Inherits="IssueRegister.Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
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
            width: 187px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="overflow: hidden; height: 1000px; margin-bottom: 80px;">
        <div style="height: 65px; width: 100%; background: #227a89; margin-top: 10px;">
            <table>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lbluser" runat="server" Text="Email" Font-Bold="True" Font-Size="X-Large"
                            ForeColor="white"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td class="style7">
                        Email
                    </td>
                    <td class="style45">
                        <asp:TextBox ID="txtemail" runat="server" Width="341px" Height="30px" MaxLength="50"
                            Style="margin-left: 0px"></asp:TextBox>
                        <asp:Label ID="lbl_msg4" Text="Required" Style="color: #FF0000" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Subject
                    </td>
                    <td class="style20">
                        <asp:TextBox ID="txtsubject" runat="server" Width="341px" Height="30px" MaxLength="50"
                            Style="margin-left: 0px"></asp:TextBox>
                        <asp:Label ID="lbl_msg5" Text="Required" Style="color: #FF0000" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Content
                    </td>
                    <td class="style20">
                        <asp:TextBox ID="txtcontent" TextMode="multiline" resize="none" Columns="50" Rows="5"
                            runat="server" Width="871px" Height="140px" Style="margin-left: 1px" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnsend" runat="server" Height="40px" Style="color: white; font-weight: bold;
                            background-color: #227a89; margin-left: 194px;" Text="Send" Width="96px" OnClick="btnsend_Click" />
                        <asp:Label ID="lbl_msg" Text="Mail send successfully" Style="color: green" runat="server"
                            Visible="false"></asp:Label>
                        <asp:Label ID="lbl_save" Text="Error In Save" Style="color: #FF0000" runat="server"
                            Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnexport" runat="server" Height="40px" Style="color: white; font-weight: bold;
                            background-color: #227a89; margin-left: 194px;" Text="Export" Width="96px" 
                            onclick="btnexport_Click"  />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
