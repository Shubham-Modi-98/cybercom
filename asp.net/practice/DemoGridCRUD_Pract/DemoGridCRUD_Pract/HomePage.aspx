<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="DemoGridCRUD_Pract.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="margin-left: auto; margin-right: auto; padding-top: 20px;">
        <h1 style="text-align: center">Add Student</h1>
        <form id="form1" runat="server">
            <table style="margin-left: auto; margin-right: auto; padding-top: 20px;">
                <tr>
                    <td>
                        <asp:Label ID="lblUniqueNo" runat="server" Text="Unique Number"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUniqueNo" runat="server" PlaceHolder="Enter Unique No"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rvfNo" runat="server" ErrorMessage="Unique number is required"
                            Text="*" ForeColor="Red" ControlToValidate="txtUniqueNo" Display="Dynamic" Font-Bold="true" ValidationGroup="ValidateForm"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" PlaceHolder="Enter Name"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is Required"
                            Text="*" ForeColor="Red" ControlToValidate="txtName" Display="Dynamic" Font-Bold="true" ValidationGroup="ValidateForm"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCourse" runat="server" Text="Select Course"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpCourse" runat="server" AutoPostBack="true"></asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPhp" runat="server" Text="Php Score"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhpScore" runat="server" PlaceHolder="Enter Php Score"></asp:TextBox>


                        <asp:RequiredFieldValidator ID="rfvPhp" runat="server" ErrorMessage="Score is Required"
                            Text="*" ForeColor="Red" ControlToValidate="txtPhpScore" Display="Dynamic" Font-Bold="true" ValidationGroup="ValidateForm"></asp:RequiredFieldValidator>

                        <asp:RangeValidator ID="rgPhp" runat="server" ErrorMessage="Score must between 0-100" MinimumValue="0" MaximumValue="100"
                            Type="Integer" Text="*" Font-Bold="true" ForeColor="Red" ControlToValidate="txtPhpScore" Display="Dynamic" ValidationGroup="ValidateForm"></asp:RangeValidator>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAsp" runat="server" Text="Asp.Net Score"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAspScore" runat="server" PlaceHolder="Enter Asp.Net Score"></asp:TextBox>


                        <asp:RequiredFieldValidator ID="rfvAsp" runat="server" ErrorMessage="Score is Required"
                            Text="*" ForeColor="Red" ControlToValidate="txtAspScore" Display="Dynamic" Font-Bold="true" ValidationGroup="ValidateForm"></asp:RequiredFieldValidator>

                        <asp:RangeValidator ID="rgAsp" runat="server" ErrorMessage="Score must between 0-100" MinimumValue="0" MaximumValue="100"
                            Type="Integer" Text="*" Font-Bold="true" ForeColor="Red" ControlToValidate="txtAspScore" Display="Dynamic" ValidationGroup="ValidateForm"></asp:RangeValidator>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJs" runat="server" Text="JavaScript Score"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtJsScore" runat="server" PlaceHolder="Enter JavaSctipt Score"></asp:TextBox>


                        <asp:RequiredFieldValidator ID="rvfJs" runat="server" ErrorMessage="Score is Required"
                            Text="*" ForeColor="Red" ControlToValidate="txtJsScore" Display="Dynamic" Font-Bold="true" ValidationGroup="ValidateForm"></asp:RequiredFieldValidator>

                        <asp:RangeValidator ID="rgJs" runat="server" ErrorMessage="Score must between 0-100" MinimumValue="0" MaximumValue="100"
                            Type="Integer" Text="*" Font-Bold="true" ForeColor="Red" ControlToValidate="txtJsScore" Display="Dynamic" ValidationGroup="ValidateForm"></asp:RangeValidator>

                    </td>
                </tr>
                <tr>
                    <br />
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" OnClick="btnAddStudent_Click" ValidationGroup="ValidateForm" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <br />
                    <td colspan="2" style="text-align: center">

                        <asp:ValidationSummary ID="ValidationSummary1" ShowValidationErrors="true"
                            ShowSummary="true" ForeColor="Red" Font-Bold="true" runat="server" ValidationGroup="ValidateForm" />

                    </td>
                </tr>
            </table>
            <div style="margin-left: auto; margin-right: auto; padding-top: 20px;">
                <table style="margin-left: auto; margin-right: auto; padding-top: 20px;">
                    <tr>
                        <td>
                            <asp:GridView ID="grStudentData" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowEditing="grStudentData_RowEditing" OnRowCancelingEdit="grStudentData_RowCancelingEdit" OnRowDeleting="grStudentData_RowDeleting" OnRowUpdating="grStudentData_RowUpdating" OnRowDataBound="grStudentData_RowDataBound" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AllowPaging="True">

                                <Columns>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblNumberHeader" runat="server" Text="Unique Number"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNumberItem" runat="server" Text='<%#Eval("RollNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblNumberEdit" runat="server" Text='<%#Eval("RollNo") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblNameHeader" runat="server" Text="Name"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNameItem" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtNameEdit" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblCourseHeader" runat="server" Text="Course"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCourseItem" runat="server" Text='<%#Eval("Course") %>'></asp:Label>
                                            <%--<asp:DropDownList ID="drpCourseItem" runat="server"></asp:DropDownList>--%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <%--<asp:Label ID="lblCourseEdit" runat="server" Text='<%#Eval("Course") %>'></asp:Label>--%>
                                            <asp:DropDownList ID="drpCourseEdit" runat="server"></asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPhpHeade" runat="server" Text="Php Score"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhpItem" runat="server" Text='<%#Eval("Php") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPhpEdit" runat="server" Text='<%#Eval("Php") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblAspHeader" runat="server" Text="Asp.Net Score"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAspItem" runat="server" Text='<%#Eval("Asp") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtAspEdit" runat="server" Text='<%#Eval("Asp") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblJsHeader" runat="server" Text="JavaScript Score"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblJsItem" runat="server" Text='<%#Eval("Js") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtJsEdit" runat="server" Text='<%#Eval("Js") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                </Columns>

                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                <PagerSettings PageButtonCount="5" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                <SortedDescendingHeaderStyle BackColor="#93451F" />

                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </div>
</body>
</html>
