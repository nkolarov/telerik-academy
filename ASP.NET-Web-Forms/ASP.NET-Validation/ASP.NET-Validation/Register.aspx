<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ASP.NET_Validation.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation Demo</title>
    <script type="text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%= CheckBoxIAgree.ClientID  %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>
</head>
<body>
    <form id="formRegister" runat="server">
        <asp:Panel ID="PanelLoginData" runat="server"
            GroupingText="LoginData">
            <asp:Label ID="LabelUserName" runat="server" Text="UserName"></asp:Label>
            <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" ValidationGroup="ValidationGroupLogin" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="User name is required!" ControlToValidate="TextBoxUserName"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegExpUserName" runat="server" ValidationGroup="ValidationGroupLogin" ForeColor="Red" Display="Dynamic"
                ErrorMessage="UserName length must be between 6 to 20 characters"
                ControlToValidate="TextBoxUserName"
                ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,20}$" />
            <br />
            <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" ValidationGroup="ValidationGroupLogin" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Password is required!" ControlToValidate="TextBoxPassword"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPassword" runat="server" ValidationGroup="ValidationGroupLogin" ForeColor="Red" Display="Dynamic"
                ErrorMessage="Password length must be between 6 to 50 characters"
                ControlToValidate="TextBoxPassword"
                ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,50}$" />
            <br />
            <asp:Label ID="LabelRepeatPassword" runat="server" Text="Repeat Password"></asp:Label>
            <asp:TextBox ID="TextBoxRepeatPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRepeatPassword" ForeColor="Red" ValidationGroup="ValidationGroupLogin" Display="Dynamic" runat="server" ErrorMessage="Repeat Password is required!" ControlToValidate="TextBoxRepeatPassword"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                ControlToCompare="TextBoxPassword"
                ControlToValidate="TextBoxRepeatPassword" Display="Dynamic"
                ErrorMessage="Password doesn't match!" ForeColor="Red" EnableClientScript="False"></asp:CompareValidator>
            <br />
            <asp:Button ID="ButtonSubmitLoginData" Text="Submit" runat="server" CausesValidation="true" ValidationGroup="ValidationGroupLogin"/>
        </asp:Panel>
        <asp:Panel ID="PanelPersonalInfo" runat="server"
            GroupingText="PersonalInfo">
            <asp:Label ID="LabelFirstName" runat="server" Text="FirstName"></asp:Label>
            <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" ValidationGroup="ValidationGroupPersonalInfo" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="First Name is required!" ControlToValidate="TextBoxFirstName"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorFirstName" ValidationGroup="ValidationGroupPersonalInfo" runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="FirstName length must be between 2 to 30 characters and must contain only characters"
                ControlToValidate="TextBoxFirstName"
                ValidationExpression="^[a-zA-Z]{2,30}$" />
            <br />
            <asp:Label ID="LabelLastName" runat="server" Text="LastName"></asp:Label>
            <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" ValidationGroup="ValidationGroupPersonalInfo" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Last Name is required!" ControlToValidate="TextBoxLastName"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLastName" runat="server" ValidationGroup="ValidationGroupPersonalInfo" ForeColor="Red" Display="Dynamic"
                ErrorMessage="LastName length must be between 2 to 30 characters and must contain only characters"
                ControlToValidate="TextBoxLastName"
                ValidationExpression="^[a-zA-Z]{2,30}$" />
            <br />
            <asp:Label ID="LabelAge" runat="server" Text="Age"></asp:Label>
            <asp:TextBox ID="TextBoxAge" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidationGroupPersonalInfo" runat="server" ErrorMessage="Age is required!" ControlToValidate="TextBoxAge"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidatorAge" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidationGroupPersonalInfo" ErrorMessage="Age must be between 18 and 81." MinimumValue="18" MaximumValue="81" ControlToValidate="TextBoxAge"></asp:RangeValidator>
            <br />
            <asp:Button ID="ButtonSubmitPersonalInfo" Text="Submit" runat="server" CausesValidation="true" ValidationGroup="ValidationGroupPersonalInfo" />
        </asp:Panel>
        <asp:Panel ID="PanelAddressInfo" runat="server"
            GroupingText="AddressInfo">
            <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" ValidationGroup="ValidationGroupAddressInfo" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Email is required!" ControlToValidate="TextBoxEmail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"  ValidationGroup="ValidationGroupAddressInfo" ForeColor="Red" Display="Dynamic"
                ErrorMessage="Email is invalid!"
                ControlToValidate="TextBoxEmail"
                ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" />
            <br />
            <asp:Label ID="LabelLocalAddress" runat="server" Text="LocalAddress"></asp:Label>
            <asp:TextBox ID="TextBoxLocalAddress" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocalAddress" ValidationGroup="ValidationGroupAddressInfo" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Local Address is required!" ControlToValidate="TextBoxLocalAddress"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLocalAddress" runat="server" ValidationGroup="ValidationGroupAddressInfo" ForeColor="Red" Display="Dynamic"
                ErrorMessage="LocalAddress length must be between 2 to 30 characters"
                ControlToValidate="TextBoxLocalAddress"
                ValidationExpression="^[a-zA-Z0-9\s]{2,30}$" />
            <br />
            <asp:Label ID="LabelPhone" runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" ForeColor="Red" Display="Dynamic" ValidationGroup="ValidationGroupAddressInfo" runat="server" ErrorMessage="Phone is required!" ControlToValidate="TextBoxPhone"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" runat="server" ValidationGroup="ValidationGroupAddressInfo" ForeColor="Red" Display="Dynamic"
                ErrorMessage="Phone is invalid!"
                ControlToValidate="TextBoxPhone"
                ValidationExpression="^([0-9\(\)\/\+ \-]*)$" />
            <br />
            <asp:Label ID="LabelIAgree" runat="server" Text="I agree" AssociatedControlID="CheckBoxIAgree"></asp:Label>
            <asp:CheckBox ID="CheckBoxIAgree" runat="server" />
            <asp:CustomValidator ID="CustomValidatorIAgree" runat="server" ForeColor="Red" ValidationGroup="ValidationGroupAddressInfo" Display="Dynamic" ErrorMessage="You must agree our terms!" ClientValidationFunction="ValidateCheckBox"></asp:CustomValidator>
            <br />
            <asp:Button ID="ButtonSubmitForm" Text="Submit" runat="server"  CausesValidation="true" ValidationGroup="ValidationGroupAddressInfo" />
        </asp:Panel>
    </form>
</body>
</html>
