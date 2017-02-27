<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMutualFunds.aspx.cs" Inherits="MutualFund.ViewMutualFunds" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title></title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <script src="js/angular.min.js"></script>
    
</head>
<body ng-app>
    <form id="form1" runat="server">
    <div class="text-center">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
        <asp:TextBox ID="TextBox1" runat="server" AutoCompleteType="Company"></asp:TextBox>
        
        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="0" ServiceMethod="GetCompanyNames" TargetControlID="TextBox1"></ajaxToolkit:AutoCompleteExtender>
        
        <asp:Button ID="Search_Button" runat="server" OnClick="Search_Click" Text="Seach" />
        <br />

    
        <asp:Button ID="Add_Field_Button" runat="server" OnClick="Add_Field_Button_Click" Text="Add Field" />


    
        <asp:Button ID="Clear_All_Button" runat="server" Text="Clear All" OnClick="Clear_All_Button_Click" />
        <br />
        <asp:GridView ID="GridView1" runat="server">
            
        </asp:GridView>
        <br />
    </div> 
    </form>
    
</body>
</html>
