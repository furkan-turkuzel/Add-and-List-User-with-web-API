<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Save.aspx.cs" Inherits="PCIS.UI.Pages.Save" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.0.0.min.js"></script>

    <script>
        $(document).ready(function () {
            
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group">
            Kullanıcı Adı:
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            Parola:
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
            
            <asp:Button ID="btnSave" runat="server" Text="Kaydet" CssClass="btn btn-success" OnClick="btnSave_Click"/>
            <asp:Label ID="lblBilgi" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
