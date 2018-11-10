<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mars.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Rover su Marte</h1>
            <label>Ostacoli:</label><br />
            <asp:TextBox ID="txtOstacoli"  runat="server" ReadOnly="true" TextMode="MultiLine" Rows="5" Columns="100"></asp:TextBox><br /><br />
            <label>Messaggi:</label><br />
            <asp:TextBox ID="txtMsg" runat="server" ReadOnly="true" TextMode="MultiLine" Rows="20" Columns="100"></asp:TextBox><br /><br />
            <label>Sposta il rover avanti(f), dietro(b), sinistra(l),destra(r), puoi indicare più comandi contemporaneamente:</label><br />
            <asp:TextBox ID="txtComandi" runat="server" TextMode="MultiLine" Rows="5" Columns="100"></asp:TextBox><br />
            <asp:Button ID="btnInviaComandi" runat="server" OnClick="btnInviaComandi_Click" Text="Invia comandi" />
             <asp:Button ID="btnPulisciComandi" runat="server" OnClick="btnPulisciComandi_Click" Text="Pulisci comandi" />
        </div>
    </form>
</body>
</html>
