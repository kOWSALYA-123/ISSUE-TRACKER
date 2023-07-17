<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="TicketRegisters.aspx.cs" Inherits="IssueRegister.TicketRegisters" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
        
        .mydatagrid
        {
        }
        .header
        {
            background-color: #227a89;
            font-family: Arial;
            color: White;
            height: 25px;
            font-size: 16px;
            border: solid 2px black;
        }
        image
        {
            width: 10px;
            height: 10px;
        }
        .style20
        {
            width: 917px;
        }
        .style22
        {
            width: 222px;
        }
        .style24
        {
            width: 443px;
            text-align: left;
            font-family: Calibri;
            font-size: larger;
        }
        .style25
        {
            width: 179px;
            text-align: left;
            font-family: Calibri;
            font-size: larger;
        }
        .style26
        {
            width: 819px;
            text-align: left;
            font-family: Calibri;
            font-size: larger;
        }
        .style29
        {
            width: 1787px;
            text-align: left;
            font-family: Calibri;
            font-size: larger;
        }
        .style37
        {
            width: 8px;
            text-align: center;
        }
        .style38
        {
            width: 164px;
            visibility: hidden;
        }
        .style40
        {
            width: 826px;
        }
        .style42
        {
            width: 440px;
        }
        .style43
        {
            width: 420px;
            text-align: left;
            font-family: Calibri;
            font-size: larger;
        }
        .style44
        {
            width: 8px;
        }
        .style45
        {
            width: 683px;
        }
        .style46
        {
            width: 819px;
            text-align: left;
            font-family: Calibri;
            font-size: larger;
            visibility: hidden;
        }
        .style47
        {
            width: 819px;
        }
        </style>
    <script type="text/javascript" language="javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.0/jquery.min.js"></script>
     <script type="text/javascript" language="javascript" src="  https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.js"> </script>
     <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="overflow: hidden; height: 1000px; margin-bottom: 80px;">
        <div style="height: 65px; width: 100%; background: #227a89; margin-top: 10px;">
            <table>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lbluser" runat="server" Text="TICKET REGISTER" Font-Bold="True" Font-Size="X-Large"
                            ForeColor="white"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="font-weight: bold">
            <div>
            </div>
        </div>
        <div style="width: 91%; height: 1472px; float: left;">
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="style29">
                                    Register Date
                                </td>
                                <td class="style40">
                                    <asp:TextBox ID="txtregisterdate" runat="server" Width="187px" Height="32px" 
                                        Style="margin-left: 3px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtregisterdate"
                                        PopupButtonID="txt_reqdate" PopupPosition="Right">
                                    </asp:CalendarExtender>
                                </td>
                                <td class="style47">
                                  Register Time
                                </td>
                                <td>
                                <asp:TextBox ID="txtTime" runat="server" CssClass="timepicker"></asp:TextBox>
                                </td>
                                <td class="style45">
                                    <asp:TextBox ID="txtticket" runat="server" Width="5px" Height="30px" Visible="false"
                                        Style="margin-left: 0px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style29">
                                    Customer Name
                                </td>
                                <td class="style40">
                                    <asp:DropDownList ID="ddlcustomer" runat="server" Width="142px" Height="30px" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlcustomer_SelectedIndexChanged" 
                                        Style="margin-left: 63px;; margin-bottom: 0px;" />
                                      
                                       </td>
                                <td class="style46">
                                  
                                </td>
                                
                                 
                                <td class="style45">
                                 <asp:Label ID="lbl_msg4" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                                 <asp:Label ID="lbl_msg" Text ="Customer Not in AMC" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                                    
                                </td>
                            </tr>
                <tr>
                    <td class="style29">
                        Product Code
                    </td>
                    <td class="style40">
                       
                        <asp:DropDownList ID="ddlproductid" runat="server" Width="142px" Height="28px" 
                            Style="margin-left: 1px" />
                            <asp:Label ID="lbl_msg3" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                    </td>
                    <td class="style26">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Module
                    </td>
                    <td class="style45">
                        <asp:TextBox ID="txtmodule" runat="server" Width="511px" Height="30px" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                </table>
                <table>
                    <tr>
                        <td class="style24">
                            Issue
                            <asp:Label ID="lbl_man" runat="server" Text="*" Style="color: #FF0000"></asp:Label>
                        </td>
                        <td class="style20">
                           
                            <asp:TextBox ID="txtissue" TextMode="multiline" resize="none" Columns="50" Rows="5"
                                runat="server" Width="871px" Height="140px" Style="margin-left: 1px" />
                        </td>
                    </tr >
                     </table>
                     <%--<table>
                    <tr>
                    <td class="style52">
                        priority

                    </td>
                    <td class="style50">
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="142px" Height="30px" 
                                Style="margin-left: 27px">
                                <asp:ListItem>High</asp:ListItem>
                                <asp:ListItem>Medium</asp:ListItem>
                                <asp:ListItem>Low</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                         <td class="style43">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Estimate Days
                          
                        </td>
                        <td class="style22">
                            <asp:TextBox ID="txtestimate" runat="server" Width="207px" Height="30px" 
                                onkeypress="return isDecimal(event)" 
                                style="text-align: right; margin-left: 139px;"></asp:TextBox>
                              <asp:Label ID="Label2" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                        </td>

                    </tr>
                    </table>--%>
               
                <table>
                    <tr>
                        <td class="style25">
                            Issue Status
                        </td>
                        <td class="style37">
                            <asp:DropDownList ID="ddlstatus" runat="server" Width="142px" Height="30px" Style="margin-left: -110px">
                                <asp:ListItem>Open</asp:ListItem>
                                <asp:ListItem>Closed</asp:ListItem>
                                <asp:ListItem>Hold</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style43">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Closed Date
                        </td>
                        <td class="style22">
                            <asp:TextBox ID="txtclosedon" runat="server" Width="205px" Height="30px" 
                                onkeypress="return isNumberKey(event)" 
                                ontextchanged="txtclosedon_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtclosedon"
                                        PopupButtonID="txt_reqdate" PopupPosition="Right" >
                                    </asp:CalendarExtender>
                                     <asp:Label ID="lbl_msg1" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                                     <br />
                                       <asp:Label ID="lbl_date" Text ="should select greaterthan registerdate" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style25">
                            Select Image File
                        </td>
                        <td class="style44">
                            <asp:FileUpload ID="btnfileupload" runat="server" multiple="multiple" />
                        </td>
                        <td class="style42">
                            <asp:Button ID="btnadd" runat="server" Text="ADD IMAGE" OnClick="btnaddimage_Click" />
                        </td>
                        <td class="style22">
                            <asp:GridView ID="dg_image" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="header"
                                OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                                Width="200px" Style="margin-left: 0px">
                                <Columns>
                                    <asp:BoundField DataField="FileName" HeaderText="File Name" SortExpression="FileName"
                                        ItemStyle-CssClass="column" HeaderStyle-CssClass="column" />
                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="10px">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtndelete" Height="20px" align="right" ImageUrl="~/images/delete.png"
                                                ToolTip="click this to delete the row" Width="20px" OnClientClick="return confirm('Are you sure you want to delete?');"
                                                runat="server" OnClick="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                             <asp:Label ID="lbl_image" Text ="Upload image of upto 2mb size only" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style25">
                            Consultant Name
                        </td>
                        <td class="style44">
                            <asp:TextBox ID="txtconsultant" runat="server" Width="142px" Height="30px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style25">
                            <asp:Label ID="lbl_cust1" runat="server" Text="Assigned To"></asp:Label>
                           
                        </td>
                        <td class="style44">
                            <asp:DropDownList ID="ddlassigned" runat="server" Width="142px" Height="30px" />
                            <asp:Label ID="lbl_msg5" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                        </td>
                        <%--<td class="style43">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:Label ID="lbl_cust2" runat="server" Text="Start Date Time "></asp:Label>
                        </td>
                        <td class="style22">
                            <asp:TextBox ID="txtstartdate" runat="server" Width="207px" Height="30px" 
                                onkeypress="return isDecimal(event)" style="text-align: right"></asp:TextBox>
                              <asp:Label ID="lbl_message3" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                               <asp:Label ID="lbl_12" Text ="should select greaterthan registerdate" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                        </td>--%>
                        <td class="style43">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Estimate Days
                           <%-- <asp:Label ID="Label1" runat="server" Text="Estimate Days "></asp:Label>--%>
                        </td>
                        <td class="style22">
                            <asp:TextBox ID="txtestimate" runat="server" Width="207px" Height="30px" 
                                onkeypress="return isDecimal(event)" 
                                style="text-align: right; margin-left: 0px;"></asp:TextBox>
                              <asp:Label ID="lbl_message3" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style25">
                           
                            <asp:Label ID="lbl_cust3" runat="server" Text=" Fixed By Name"></asp:Label>
                        </td>
                        <td class="style44">
                            <asp:DropDownList ID="ddldeveloper" runat="server" Width="142px" Height="30px" />
                        </td>
                        <td class="style43">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:Label ID="lbl_cust4" runat="server" Text="   End Date Time"></asp:Label>
                          
                        </td>
                        <td class="style22">
                            <asp:TextBox ID="txtfixedbydate" runat="server" Width="205px" Height="30px" 
                                onkeypress="return isNumberKey(event)" 
                                ontextchanged="txtfixedbydate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtfixedbydate"
                                        PopupButtonID="txt_reqdate" PopupPosition="Right">
                                    </asp:CalendarExtender>
                                     <asp:Label ID="lbl_msg2" Text ="Required" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                                      <asp:Label ID="lb_date" Text ="should select greaterthan registerdate" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                        </td>
                    </tr>
                    
                </table>
                <table>
                 <tr>
                <%--<td class="style51">
                    Remarks
                </td>
                <td class="style17">
                    <asp:TextBox ID="txtremarks" TextMode="multiline" runat="server" Width="477px" Height="87px"
                        Style="margin-left: 0px"></asp:TextBox>
                </td>--%>
                <tr>
                        <td class="style38" ;>
                            Is Active [Y/N]
                        </td>
                        <td class="style44">
                            <asp:CheckBox ID="chk_isactive" runat="server"  Visible="false"/>
                        </td>
                         
                    </tr>
            </tr>
                </table>
                <br />
                <asp:Button ID="btnsave" runat="server" Height="40px" Style="color: white; font-weight: bold;
                    background-color: #227a89; margin-left: 165px;" Text="Save" Width="96px" 
                            OnClick="btnsave_Click" />
                <asp:Button ID="btnclear" runat="server" Height="40px" Style="color: white; font-weight: bold;
                    background-color: #227a89" Text="Clear" Width="88px" OnClick="btnclear_Click" />
                     <asp:Label ID="lbl_save" Text ="Error In Save" style="color: #FF0000" runat="server" visible="false"></asp:Label>
                </td> </tr>
            </table>
            <script type="text/javascript">
                $('#<%=ddlcustomer.ClientID%>').chosen();
           </script>
            <script type="text/javascript" language="javascript">


                function isDecimal(evt) {
                    var charCode = (evt.which) ? evt.which : event.keyCode
                    var parts = evt.srcElement.value.split('.');
                    if (parts.length > 1 && charCode == 46)
                        return false;
                    else {
                        if (charCode == 46 || (charCode >= 48 && charCode <= 57))
                            return true;
                        return false;
                    }
                }
                function isNumberKey(evt) {
                    var charCode = (evt.which) ? evt.which : evt.keyCode;
                    if (charCode > 31 && (charCode < 48 || charCode > 57))
                        return false;
                    return true;
                }
                

                
            </script>

        </div>
</asp:Content>
