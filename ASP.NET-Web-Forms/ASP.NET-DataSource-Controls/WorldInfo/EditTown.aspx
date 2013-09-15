<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditTown.aspx.cs" Inherits="WorldInfo.EditTown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formEditTown" runat="server">
        <section id="sectionEditTown" runat="server">
            <h3>Edit town info:</h3>
            <asp:Label ID="LabelCountries" Text="Country" runat="server" AssociatedControlID="ListBoxCountries"/>
            <asp:DropDownList ID="ListBoxCountries" runat="server" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
            <br />
            <asp:Label ID="LabelTownName" Text="Name" runat="server" AssociatedControlID="TextBoxTownName"/>
            <asp:TextBox ID="TextBoxTownName" runat="server" />
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorTownName"
                runat="server"
                ErrorMessage="Town Name is Required!"
                ControlToValidate="TextBoxTownName" />
            <asp:CustomValidator
                ID="CustomValidatorTownName"
                runat="server"
                ErrorMessage="The Name is too long! Max 50 symbols allowed!"
                ControlToValidate="TextBoxTownName"
                OnServerValidate="CustomValidatorTownName_ServerValidate" />
            <br />
            <asp:Label ID="LabelPopulation" Text="Population" runat="server" AssociatedControlID="TextBoxPopulation"/>
            <asp:TextBox ID="TextBoxPopulation" runat="server" TextMode="Number"/>
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
            <asp:LinkButton ID="LinkButtonSaveTown" runat="server"
                Text="Save" OnClick="LinkButtonSaveTown_Click" />
            <br />
            <a href="ManageTowns.aspx">Cancel</a>
            <asp:Literal Id="LiteralErrorMessage" runat="server" Visible="false"/>
        </section>
    </form>
</body>
</html>
