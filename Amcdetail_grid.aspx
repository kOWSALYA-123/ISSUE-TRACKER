<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Amcdetail_grid.aspx.cs" Inherits="IssueRegister.Amcdetail_grid" %>

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
            width: 806px;
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
                        <asp:Label ID="lbluser" runat="server" Text="AMC DETAIL LIST" Font-Bold="True" Font-Size="X-Large"
                            ForeColor="white"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button class="btn" ID="btn_new" runat="server" OnClick="redirect" Text="New"
                        Style="color: white; margin: 0 225px 0 1038px; background-color: #227a89;" Width="89px"
                        Height="55px" />
                </td>
            </tr>
        </table>
        <div>
            <table>
                <tr>
                    <td colspan="6" style="padding-top: 13px;" class="style7">
                        <div id="DivRoot1" style="width: 150%; min-height: 0px; max-height: 240px; height: 199px;">
                            <div style="overflow: hidden;" id="DivHeaderRow1">
                            </div>
                            <div style="overflow: hidden; width: 99%;" onscroll="OnScrollDiv1(this)" id="DivMainContent1">
                                <asp:GridView ID="dg_amcgrid" runat="server" DataKeyNames="CustomerID" ShowHeaderWhenEmpty="true"
                                    ShowHeader="true" AutoGenerateColumns="False" Font-Bold="True" Height="65px"
                                    CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                                    RowStyle-CssClass="rows" AllowPaging="True" OnPageIndexChanging="dg_amcdetails_PageIndexChanging"
                                    Width="95%" OnSelectedIndexChanged="dg_amcdetails_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName"
                                            ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                        <asp:BoundField DataField="AMC_StartDate" HeaderText="AMC StartDate" SortExpression="AMC_StartDate"
                                            ItemStyle-CssClass="column" HeaderStyle-CssClass="column" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="AMC_EndDate" HeaderText="AMC EndDate" SortExpression="AMC_EndDate"
                                            ItemStyle-CssClass="column" HeaderStyle-CssClass="column" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="ISPAID" HeaderText="Paid" SortExpression="ISPAID" />
                                        <asp:ButtonField HeaderStyle-Width="10px" CommandName="select" ImageUrl="~/Login1/edit_btn_overlay.png"
                                            ItemStyle-HorizontalAlign="Center" ControlStyle-BorderColor="SkyBlue" ButtonType="Image"
                                            HeaderText="" ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div id="DivFooterRow1" style="overflow: hidden">
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
