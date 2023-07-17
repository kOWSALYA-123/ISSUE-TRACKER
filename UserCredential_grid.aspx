<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserCredential_grid.aspx.cs" Inherits="IssueRegister.UserCredential_grid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .style6
        {
            width: 1067px;
            margin-left: auto;
            margin-right: auto;
            text-align: center;
            height: 60px;
        }
        .column
        {
            border: 1px solid #000;
        }
        .mydatagrid
        {
        }
    </style>
    <link href="Styles/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="height: 65px; width: 100%; background: #227a89; margin-top: 10px;">
            <table>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lbluser" runat="server" Text="USER CREDENTIAL LIST" Font-Bold="True"
                            Font-Size="X-Large" ForeColor="white"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button class="btn" ID="btn_new" runat="server" OnClick="redirect" Text="New"
                        Style="color: white; margin: 0 225px 0 1046px; background-color: #227a89;" Width="89px"
                        Height="55px" Visible="false" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td colspan="6" style="padding-top: 13px;">
                    <div id="Div1" style="width: 101%; min-height: 0px; max-height: 260px; height: 159px;
                        margin-bottom: 0px;">
                        <div style="overflow: hidden;" id="Div2">
                        </div>
                        <div style="overflow: hidden; width: 99%;" onscroll="OnScrollDiv1(this)" id="Div3">
                            <asp:GridView ID="dg_usercredential" runat="server" DataKeyNames="username,userid" ShowHeaderWhenEmpty="true"
                                ShowHeader="true" AutoGenerateColumns="False" Width="1150px" Height="65px" Font-Bold="True"
                                OnSelectedIndexChanged="dg_usercredential_SelectedIndexChanged" CssClass="mydatagrid"
                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                OnPageIndexChanging="dg_usercredential_PageIndexChanging" AllowPaging="True">
                                <Columns>
                                    <asp:BoundField DataField="userID" HeaderText="User ID" SortExpression="userID" ItemStyle-CssClass="column"
                                        HeaderStyle-CssClass="column" />
                                    <asp:BoundField DataField="username" HeaderText="User Name" SortExpression="username"
                                        ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                    <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password"
                                        ItemStyle-CssClass="column" HeaderStyle-CssClass="column" DataFormatString="****"/>
                                    <asp:BoundField DataField="email" HeaderText="Email address" SortExpression="email"
                                        ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                    <asp:BoundField DataField="Mobile" HeaderText="Phone No" SortExpression="Mobile"
                                        ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                    <asp:ButtonField HeaderStyle-Width="10px" CommandName="select" ImageUrl="~/Login1/edit_btn_overlay.png"
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="column" ControlStyle-BorderColor="SkyBlue"
                                        ButtonType="Image" HeaderText="" HeaderStyle-CssClass="column" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div id="Div4" style="overflow: hidden">
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <headerstyle forecolor="#317B82" />
    </div>
    <div id="DivFooterRow1" style="overflow: hidden">
    </div>
    <script type="text/javascript" language="javascript">
        function Alert(str) {
            document.getElementById('dimmer').style.display = (true ? 'block' : 'none');
            alert(str + "..!");
            document.getElementById('dimmer').style.display = (false ? 'block' : 'none');
            return false;
            return true;
        }
    </script>
</asp:Content>
