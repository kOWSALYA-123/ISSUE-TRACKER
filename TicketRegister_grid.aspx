<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="TicketRegister_grid.aspx.cs" Inherits="IssueRegister.TicketRegister_grid" %>

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
    </style>
    <link href="Styles/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="height: 65px; width: 100%; background: #227a89; margin-top: 10px;">
            <table>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lbluser" runat="server" Text="TICKET REGISTER LIST" Font-Bold="True"
                            Font-Size="X-Large" ForeColor="white"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtsearch" runat="server" Height="34px" Width="219px"></asp:TextBox>
                        <asp:Button ID="btnsearch" runat="server" Text="Search" 
                            style="height:38px;width:93px;" onclick="btnsearch_Click" />
                            <asp:Label ID="lbl_message3" text="Not Found" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                        <asp:Button class="btn" ID="btn_new" runat="server" OnClick="redirect" Text="New"
                            Style="color: white; margin: 0 225px 0 1061px; background-color: #227a89;" Width="89px"
                            Height="55px" />
                       
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td colspan="6" style="padding-top: 13px;">
                        <div id="DivRoot1" style="width: 123%; min-height: 0px; max-height: 240px; height: 199px;
                            margin-bottom: 0px;">
                            <div style="overflow: scroll;" id="DivHeaderRow1">
                            </div>
                            <div style="overflow: scroll; height: 472px; width: 99%;" id="DivMainContent1">
                                <asp:GridView ID="dg_ticketregister" runat="server" DataKeyNames="TICKETID" ShowHeaderWhenEmpty="true"
                                    ShowHeader="true" AutoGenerateColumns="False" Height="65px" Font-Bold="True"
                                    CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                                    OnPageIndexChanging="dg_ticketregister_PageIndexChanging" RowStyle-CssClass="rows"
                                    AllowPaging="True" Width="1150px" OnSelectedIndexChanged="dg_ticketregister_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="TICKETID" HeaderText="Ticket ID" SortExpression="TICKETID"
                                            ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                        <asp:BoundField DataField="REGISTERDATE" HeaderText="Register Date" SortExpression="REGISTERDATE"
                                            ItemStyle-CssClass="column" HeaderStyle-CssClass="column" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="CUSTOMERCODE" HeaderText="Customer Code" SortExpression="CUSTOMERCODE"
                                            ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                        <asp:BoundField DataField="PRODUCTNAME" HeaderText="PRODUCT NAME" SortExpression="PRODUCTNAME"
                                            ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                        <asp:BoundField DataField="ISSUE" HeaderText="Issue" SortExpression="ISSUE" ItemStyle-CssClass="column"
                                            HeaderStyle-CssClass="column" />
                                        <asp:BoundField DataField="Status" HeaderText="Issue Status" SortExpression="Status"
                                            ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                        <asp:ButtonField HeaderStyle-Width="10px" CommandName="select" ImageUrl="~/Login1/edit_btn_overlay.png"
                                            ItemStyle-HorizontalAlign="Center" ControlStyle-BorderColor="SkyBlue" ButtonType="Image"
                                            HeaderText="" ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <headerstyle forecolor="#317B82" />
                            <div id="DivFooterRow1" style="overflow: hidden">
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
