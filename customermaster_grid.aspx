<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="customermaster_grid.aspx.cs" Inherits="IssueRegister.customermaster_grid" %>

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
        .grdhdr5
        {
            width: 13%;
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
                        <asp:Label ID="lbluser" runat="server" Text="CUSTOMER MASTER LIST" Font-Bold="True"
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
                        Style="color: white; margin: 0 225px 0 1058px; background-color: #227a89;" Width="89px"
                        Height="55px" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td colspan="6" style="padding-top: 13px;">
                    <div id="Div1" style="width: 147%; min-height: 0px; max-height: 240px; height: 199px;">
                        <div style="overflow: hidden;" id="Div2">
                        </div>
                        <div style="overflow: hidden; width: 85%" onscroll="OnScrollDiv1(this)" id="Div3">
                            <asp:GridView ID="dg_CustomerMaster" runat="server" DataKeyNames="CustomerCode,CustomerName"
                                ShowHeaderWhenEmpty="true" ShowHeader="true" AlternatingRowStyle-CssClass="alt"
                                AutoGenerateColumns="False" Font-Bold="True" Height="50px" Width="1140px" CssClass="mydatagrid"
                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                AllowPaging="True" OnSelectedIndexChanged="dg_CustomerMaster_SelectedIndexChanged"
                                OnPageIndexChanging="dg_CustomerMaster_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="customerid" HeaderText="CustomerID" SortExpression="customerid"
                                        ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                    <asp:BoundField DataField="CustomerCode" HeaderText="Customer Code" SortExpression="CustomerCode"
                                        ItemStyle-CssClass="column" HeaderStyle-CssClass="column" Visible="false" />
                                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName"
                                        ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                    <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address"
                                        ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                    <asp:BoundField DataField="country" HeaderText="Country" SortExpression="country"
                                        ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                    <asp:BoundField DataField="Phone" HeaderText="Phone no" SortExpression="Phone" ItemStyle-CssClass="column"
                                        HeaderStyle-CssClass="column" />
                                    <asp:BoundField DataField="Email" HeaderText="Email address" SortExpression="Email"
                                        ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                    <asp:ButtonField HeaderStyle-Width="10px" CommandName="select" ImageUrl="~/Login1/edit_btn_overlay.png"
                                        ItemStyle-HorizontalAlign="Center" ControlStyle-BorderColor="SkyBlue" ButtonType="Image"
                                        HeaderText="" ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div id="Div4" style="overflow: hidden">
                        </div>
                        </ContentTemplate>
                    </div>
                </td>
            </tr>
        </table>
        </asp:GridView>
    </div>
    <div id="DivFooterRow1" style="overflow: hidden">
    </div>
    </div> </td> </tr> </table> </div>
</asp:Content>
