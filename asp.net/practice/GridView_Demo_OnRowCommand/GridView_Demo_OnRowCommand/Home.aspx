<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GridView_Demo_OnRowCommand.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <div style="margin-left: auto; margin-right: auto; padding-top: 20px;">
        <h1 style="text-align: center">Add Employee</h1>
        <form id="form1" runat="server">
            <table style="margin-left: auto; margin-right: auto; padding-top: 20px;">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" PlaceHolder="Enter Name"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is Required"
                            Text="*" ForeColor="Red" ControlToValidate="txtName" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" PlaceHolder="Enter Email"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rvfEmail" runat="server" ErrorMessage="Email is Required"
                            Text="*" ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rgEmail" runat="server" ErrorMessage="Invalid Email"
                            Text="*" ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic" Font-Bold="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="FormValidation"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSalary" runat="server" Text="Salary"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtSalary" runat="server" PlaceHolder="Enter Salary"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rvfSalary" runat="server" ErrorMessage="Salary is Required"
                            Text="*" ForeColor="Red" ControlToValidate="txtSalary" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RequiredFieldValidator>
                        <%--<asp:RangeValidator ID="rgSalary" runat="server" ErrorMessage="Salary between 1k-1L" MinimumValue="1000" MaximumValue="100000"
                            Type="Integer" Text="*" ForeColor="Red" ControlToValidate="txtSalary" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RangeValidator>--%>
                    </td>
                </tr>
                <br />
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" OnClick="btnAddEditEmployee_Click" ValidationGroup="FormValidation" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <br />
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:ValidationSummary ID="ValidationSummary1" ShowValidationErrors="true" ShowMessageBox="true" ShowSummary="true" ForeColor="Red" Font-Bold="true" runat="server" />
                    </td>
                </tr>
            </table>
            <table style="margin-left: auto; margin-right: auto; padding-top: 20px;">
                <tr>
                    <td>
                        <%-- <asp:GridView ID="grData" runat="server" AutoGenerateColumns="False" OnRowCommand="grData_RowCommand">
                            <Columns>
                                <asp:TemplateField Visible="false" HeaderText="Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdItem" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdEdit" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Employee Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNameItem" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtNameEdit" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmailItem" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmailEdit" runat="server" Text='<%#Eval("Email") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Salary">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSlaryItem" runat="server" Text='<%#Eval("Salary") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSalaryEdit" runat="server" Text='<%#Eval("Salary") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="updateEmployee" CommandArgument='<%#Eval("Id")%>' />
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="deleteEmployee" CommandArgument='<%#Eval("Id")%>' /> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>--%>

                        <asp:GridView ID="grData" runat="server" AutoGenerateColumns="False" OnRowCommand="grData_RowCommand">
                            <Columns>
                                <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                                <asp:BoundField HeaderText="Name" DataField="Name" />
                                <asp:BoundField HeaderText="Email Id" DataField="Email" />
                                <asp:BoundField HeaderText="Salary" DataField="Salary" />

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="updateEmployee" CommandArgument='<%#Eval("Id")%>' />
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="deleteEmployee" CommandArgument='<%#Eval("Id")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGridMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
