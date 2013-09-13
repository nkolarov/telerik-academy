<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesManagement.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="employeesDetails" runat="server">
        <asp:GridView ID="GridViewEmployees" runat="server">
            <Columns>
                <asp:HyperLinkField 
                    AccessibleHeaderText="Details" 
                    DataNavigateUrlFormatString="EmployeeDetails.aspx?id={0}"
                    HeaderText="Details" 
                    Text="Details" 
                    DataNavigateUrlFields="EmployeeId" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
