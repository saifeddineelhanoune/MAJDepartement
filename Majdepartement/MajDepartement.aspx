<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MajDepartement.aspx.cs" Inherits="Majdepartement.MajDepartement" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>



</head>
<body>
<form id="form1" runat="server">
<div>

<div class="form-group">
<label class="control-label col-sm-2">Numéro Département: </label><asp:TextBox ID="txtNoDepartmenet" min="1" class="form-control" width="20%" runat="server" TextMode="Number" ></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoDepartmenet" EnableClientScript="False" ErrorMessage="Veuillez Saisir Numéro De Département"></asp:RequiredFieldValidator>
</div>

<div class="form-group">
<label class="control-label col-sm-2">Nom Département: </label><asp:TextBox ID="txtNomDept" min="1" class="form-control" width="20%" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNomDept" EnableClientScript="False" ErrorMessage="Veuillez Saisir Le Nom Du Département"></asp:RequiredFieldValidator>
</div>
<div class="form-group">
<label class="control-label col-sm-2">Location Département: </label><asp:TextBox ID="txtLocation" min="1" class="form-control" width="20%" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLocation" EnableClientScript="False" ErrorMessage="Veuillez Saisir La localité Du Département"></asp:RequiredFieldValidator>
</div>

<div class="form-group" style="text-align: center; width: 100%">
<asp:Button class="btn btn-primary" Width="19%" ID="btnFirst" runat="server" Text="|<" OnClick="btnFirst_Click" />



<asp:Button class="btn btn-primary" Width="19%" ID="btnPrevous" runat="server" Text="<" OnClick="btnPrevous_Click" />



<asp:Button class="btn btn-primary" Width="19%" ID="btnNext" runat="server" Text=">" OnClick="btnNext_Click" />



<asp:Button class="btn btn-primary" Width="19%" ID="btnLast" runat="server" Text=">|" OnClick="btnLast_Click" />



</div>

<div style="text-align: center; width: 100%">





<asp:Button Width="22%" class="btn btn-success" ID="btnAdd" runat="server" Text="Ajouter" OnClick="btnAdd_Click" />





<asp:Button Width="22%" class="btn btn-success" ID="btnModifier" runat="server" Text="Modifier" OnClick="btnModifier_Click" />





<asp:Button Width="22%" class="btn btn-success" ID="btnSupprimer" runat="server" Text="Supprimer" OnClick="btnSupprimer_Click" />





<asp:Button Width="22%" class="btn btn-success" ID="btnEnregistrer" runat="server" Text="Enregistrer" OnClick="btnEnregistrer_Click" />






</div>
<asp:GridView ID="gridDepartement" style="margin: 15px;" runat="server" class="table table-striped" AllowPaging="True" AllowSorting="True" PageSize="3" OnSorting="gridDepartement_Sorting" OnPageIndexChanging="gridDepartement_PageIndexChanging" OnSelectedIndexChanged="gridDepartement_SelectedIndexChanged" >
<Columns>
<asp:CommandField ShowSelectButton="True" />
</Columns>
</asp:GridView>




</div>
</form>

</body>
</html>