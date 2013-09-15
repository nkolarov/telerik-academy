<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCountry.aspx.cs" Inherits="WorldInfo.EditCountry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Country</title>
</head>
<body>
    <form id="formEditCountry" runat="server">
        <section id="sectionEditCountry" runat="server">
            <h3>Edit country info:</h3>
            <asp:Label ID="LabelContinents" Text="Continent" runat="server" AssociatedControlID="ListBoxContinents" />
            <asp:DropDownList ID="ListBoxContinents" runat="server" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
            <asp:Label ID="LabelCountryName" Text="Name" runat="server" AssociatedControlID="TextBoxCountryName" />
            <asp:TextBox ID="TextBoxCountryName" runat="server" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorCountryName"
                runat="server"
                ErrorMessage="Country Name is Required!"
                ControlToValidate="TextBoxCountryName" />
            <asp:CustomValidator
                ID="CustomValidatorCountryName"
                runat="server"
                ErrorMessage="The Name is too long! Max 50 symbols allowed!"
                ControlToValidate="TextBoxCountryName"
                OnServerValidate="CustomValidatorCountryName_ServerValidate" />
            <br />
            <asp:Label ID="LabelLanguage" Text="Language" runat="server" AssociatedControlID="TextBoxLanguage" />
            <asp:TextBox ID="TextBoxLanguage" runat="server" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorLanguage"
                runat="server"
                ErrorMessage="Country Name is Required!"
                ControlToValidate="TextBoxLanguage" />
            <asp:CustomValidator
                ID="CustomValidatorLanguage"
                runat="server"
                ErrorMessage="The Language is too long! Max 50 symbols allowed!"
                ControlToValidate="TextBoxLanguage"
                OnServerValidate="CustomValidatorCountryName_ServerValidate" />
            <br />
            <asp:Label ID="LabelPopulation" Text="Population" runat="server" AssociatedControlID="TextBoxPopulation" />
            <asp:TextBox ID="TextBoxPopulation" runat="server" TextMode="Number" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorPopulation"
                runat="server"
                ErrorMessage="Population is Required!"
                ControlToValidate="TextBoxPopulation" />
            <asp:CustomValidator
                ID="CustomValidatorPopulation"
                runat="server"
                ErrorMessage="The Population is too long! Max 18 symbols allowed!"
                ControlToValidate="TextBoxPopulation"
                OnServerValidate="CustomValidatorPopulation_ServerValidate" />
            <br />
            <asp:Label ID="LabelFlag" Text="New Flag" runat="server" AssociatedControlID="FileUploadFlag" />
            <asp:FileUpload ID="FileUploadFlag" runat="server" />
            <br />
            <asp:CheckBox ID="CheckRemoveFlag" Text="RemoveFlag" runat="server" />
            <br />
            <asp:LinkButton ID="LinkButtonSaveCountry" runat="server"
                Text="Save" OnClick="LinkButtonSaveCountry_Click" />
            <br />
            <a href="ManageCountries.aspx">Cancel</a>
            <asp:Literal ID="LiteralErrorMessage" runat="server" Visible="false" />
        </section>
    </form>
</body>
</html>
