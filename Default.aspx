<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Css/StyleSheet.css">
    <title></title>
    <style type="text/css">
        
     
        
        .SqlOrXml {
            width: 348px;
            margin-left: 909px;
        }
        
     
        
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="The description of my page" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="User">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblmail" runat="server" Text="Mail" />
            </td>
             <td>
                 <asp:TextBox ID="txtMail" runat="server" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblBirthday" runat="server" Text="Birthday" />
            </td>
             <td>
                 <asp:TextBox ID="txtBirthday" runat="server" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblFName" runat="server" Text="First name" />
            </td>
             <td>
                 <asp:TextBox ID="txtFName" runat="server" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblLName" runat="server" Text="Last Name" />
            </td>
             <td>
                 <asp:TextBox ID="txtLName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPhone" runat="server" Text="Phone" />
            </td>
             <td>
                 <asp:TextBox ID="txtPhone" runat="server" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblGender" runat="server" Text="Gender" />
            </td>
             <td>
                 <asp:DropDownList ID="drpGender" runat="server">
                     <asp:ListItem Text="Male" id="lMale"/>
                      <asp:ListItem Text="Female" id="lFemale"/>
                 </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl" runat="server" Text="Add user" />
            </td>
             <td>
                 <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"  />
                   
            </td>
        </tr>
        <tr>
            <td> <asp:CheckBox ID="ChSql" AutoPostBack="true " runat="server" Checked="true" Text="SQl" ForeColor="brown" BackColor="Yellow" OnCheckedChanged="ChSql_CheckedChanged" /></td>
             <td> <asp:CheckBox ID="ChXML" AutoPostBack="true" runat="server" Checked="false" Text="XML" ForeColor="brown" OnCheckedChanged="ChXML_CheckedChanged"/></td>           
   </tr>
        <tr><td><asp:Label ID="lblM" Content="Fill all columns!!!"  ForeColor="Red" BorderWidth="5px" runat="server" /></td></tr>
       
    </table>  
    </div>
        <div class="UserList">
            <asp:DataList ID="dlsUsers" runat="server"  CellSpacing="2" CellPadding="2">
    <FooterTemplate>
    </FooterTemplate>
    <HeaderTemplate  >
        <asp:Label ID="lblMail" runat="server" Text='<%# Mail %>' />
         <asp:Label ID="lblBirthday" runat="server" Text='<%#Birthday %>' />
        <asp:Label ID="lblFname" runat="server" Text='<%# Fname %>' />
        <asp:Label ID="lblLname" runat="server" Text='<%# Lname %>' />
        <asp:Label ID="lblPhone" runat="server" Text='<%# Phone %>' />
        <asp:Label ID="lblGender" runat="server" Text='<%# Gender %>' />
    </HeaderTemplate>
    <ItemTemplate>
        <%# DataBinder.Eval(Container.DataItem,"Mail") %>
        <%# DataBinder.Eval(Container.DataItem,"Birthday")%>
        <%# DataBinder.Eval(Container.DataItem,"Fname")%>
        <%# DataBinder.Eval(Container.DataItem,"Lname")%>
       <%# DataBinder.Eval(Container.DataItem,"Phone")%>
       <%# DataBinder.Eval(Container.DataItem,"Gender")%>
    </ItemTemplate>
</asp:DataList>
              
        </div>
        <div class="SqlOrXml">
            <asp:Label ID="lblSqlOrXml" Text="Sql or Xml" runat="server" CssClass="lblSqlOrXml" />
            <br />
            <br />
          
        </div>
    </form>
</body>
</html>
