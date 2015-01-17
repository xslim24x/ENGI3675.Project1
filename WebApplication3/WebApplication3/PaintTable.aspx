<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaintTable.aspx.cs" Inherits="WebApplication3.PaintTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tblPaints" runat="server" BorderWidth="1">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ColumnSpan="2">
                    Paints
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell BackColor="#94D4E9">
                    Paint Name
                </asp:TableCell>
                <asp:TableCell BackColor="#94D4E9">
                    Litres
                </asp:TableCell>
            </asp:TableRow>   
        </asp:Table> 
    </div>
    </form>
</body>
</html>
