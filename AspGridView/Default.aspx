<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspDataGrid._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .button {
    margin: 0px 5px 5px 0px;
    padding: 4px 12px;
    background-color: #004080;
    color: white;
    border: none;
    border-radius: 4px;
    text-align: center;
    text-decoration: none;
    cursor: pointer;
}
.button:hover {
    margin: 0px 5px 5px 0px;
    padding: 4px 12px;
    background-color: #2874a6;
    color: white;
    border: none;
    border-radius: 4px;
    text-align: center;
    text-decoration: none;
    cursor: pointer;
}
.validatorMsgGrid{
    display:block;
    color:red;
    text-align:left;
    margin-top:1px;
    padding:0px;
    font-size:12px;
    font-family: Tahoma;
}
.approveUserIdSection{
    clear:both;
    float:left;
    margin-right:5px;
}

#ApprovalSection > .approveUserIdSection{
    margin-left:5px;
}
</style>
       <div class="row">
        <div>
            <asp:GridView ID="aspGridView" runat="server" AutoGenerateColumns="false" Width="100%" style="margin-top:20px;" OnRowCommand="aspGridView_RowCommand" OnRowDataBound="aspGridView_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="Order Number" DataField="ORD_NUM" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="Order Amount" DataField="ORD_AMOUNT" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="Order Date" DataField="ORD_DATE" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="Customer Date" DataField="CUST_NAME" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="Order Description" DataField="ORD_DESCRIPTION" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Approve Order">
                        <ItemTemplate>
                            <section id="ApprovalSection" runat="server" style="margin-top: 5px;">
                                <div class="approveUserIdSection">
                                    <asp:TextBox ID="txtApproveId" ClientIDMode="Predictable" 
                                        placeholder="Approver ID" 
                                        runat="server" 
                                        MaxLength="11"></asp:TextBox>
                                    <asp:Label ID="alertMsg" 
                                        ClientIDMode="Predictable" 
                                        runat="server" 
                                        CssClass="validatorMsgGrid"></asp:Label>                                  
                                </div>
                                <div>
                                    <asp:Button ID="btnApproveOrder" ClientIDMode="Predictable" Text="Approve Order" runat="server" CssClass="button" CommandName="ApproveOrder" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" />
                                    <asp:Button ID="btnClear" ClientIDMode="Predictable" Text="Clear" runat="server" CssClass="button" />
                                </div>
                            </section>
                            <asp:Label ID="txtapprovedBy" runat="server" Visible="false" Text='<%# "Approved By " + Eval("APPROVAL_ID") %>' CssClass="approvedByMsg"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <script type="text/javascript">
        
        //Validate the control to see if data is entered
        function ValidateInput(txtcontrolid,lblalertid)
        {
            txtBox = document.getElementById(txtcontrolid);
            lblalert = document.getElementById(lblalertid)
            if (txtBox.value.length<=0)
            {
                lblalert.innerHTML = "Please Enter Approval ID";
                return false;
            }
            return true;
        }

        //Clear the button field
        function ClearInputField(txtInputField)
        {
            txtinput = document.getElementById(txtInputField);
            if (txtinput!=null)
            {
                txtinput.value = "";
            }
            return false;
        }
    </script>
</asp:Content>
