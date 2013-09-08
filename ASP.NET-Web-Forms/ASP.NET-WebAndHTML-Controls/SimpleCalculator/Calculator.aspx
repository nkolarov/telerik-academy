<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="SimpleCalculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Just Calulate</title>
    <link href="Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0">
                <tr>
                    <td colspan="4">
                        <asp:TextBox runat="server" Width="190" ReadOnly="true" ID="TextBoxDisplay" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button Text="1" ID="Button1" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="2" ID="Button2" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="3" ID="Button3" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="+" ID="ButtonPlus" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button Text="4" ID="Button4" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="5" ID="Button5" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="6" ID="Button6" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="-" ID="ButtonMinus" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button Text="7" ID="Button7" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="8" ID="Button8" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="9" ID="Button9" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="x" ID="ButtonMultiply" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button Text="Clear" ID="ButtonClear" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="0" ID="Button0" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="√" ID="ButtonSqrt" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="/" ID="ButtonDivide" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="equals">
                        <asp:Button Text="=" ID="ButtonEquals" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
