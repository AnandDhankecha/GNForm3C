<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="ACC_IncomeAddEditMany.aspx.cs" Inherits="AdminPanel_Account_ACC_Income_ACC_IncomeAddEditMany" %>

<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Income " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>


<asp:Content ID="cntBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <asp:HyperLink ID="hlIncome" runat="server" NavigateUrl="~/AdminPanel/Income/ACC_Income/ACC_IncomeList.aspx" Text="Income List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Income Add/Edit"></asp:Label>
    </li>
</asp:Content>


<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">

    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="upIncome" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>

        <ContentTemplate>

            <asp:UpdatePanel ID="upIncome2" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">

                <ContentTemplate>

                    <div class="row">
                        <div class="col-md-12">
                            <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                            <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                        </div>
                    </div>

                    <div class="portlet light">

                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                                <span class="caption-subject font-green-sharp bold uppercase">
                                    <asp:Label ID="lblFormHeader" runat="server" Text=""></asp:Label>
                                </span>
                            </div>
                        </div>

                        <div class="portlet-body form">

                            <div class="form-horizontal" role="form">

                                <div class="form-body">

                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                    </div>

                                    <div class="form-group">

                                        <label class="col-md-3 control-label">
                                            <span class="required">*</span>
                                            <asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Hospital"></asp:Label>
                                        </label>

                                        <div class="col-md-5">
                                            <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-4">
                                            <asp:Button ID="btnShow" runat="server" SkinID="btnShow" OnClick="btnShow_Click" />
                                            <asp:HyperLink ID="hlCancel1" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Income/ACC_Income/ACC_IncomeList.aspx"></asp:HyperLink>
                                        </div>

                                    </div>

                                </div>

                            </div>

                        </div>

                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>

            <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                </Triggers>

                <ContentTemplate>

                    <div class="row">
                        <div class="col-md-12">
                            <ucMessage:ShowMessage ID="ShowMessage1" runat="server" ViewStateMode="Disabled" />
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-12">

                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light" runat="server" id="Div_ShowResult" visible="false">

                                <div class="portlet-title">

                                    <div class="caption">
                                        <asp:Label SkinID="lblSearchResultHeaderIcon" runat="server"></asp:Label>
                                        <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                                        <label class="control-label">&nbsp;</label>
                                    </div>

                                </div>

                                <div class="portlet-body">

                                    <div class="row" runat="server">

                                        <div class="col-md-12">

                                            <div id="TableContent">

                                                <table class="table table-border    ed table-advanced table-striped table-hover" id="sample_1">

                                                    <%-- Table Header --%>
                                                    <thead>

                                                        <tr class="TRDark">

                                                            <th class="text-center" style="width: 20px;">
                                                                <asp:Label ID="lblIsSelected" runat="server" Text="IsSelected"></asp:Label>
                                                            </th>

                                                            <th class="text-center" style="width: 20px;">
                                                                <asp:Label ID="lbhSerialNo" runat="server" Text="Sr."></asp:Label>
                                                            </th>

                                                            <th>
                                                                <asp:Label ID="lbhFinYear" runat="server" Text="Fin Year"></asp:Label>
                                                            </th>

                                                            <th>
                                                                <asp:Label ID="lbhIncomeType" runat="server" Text="Income Type"></asp:Label>
                                                            </th>

                                                            <th>
                                                                <asp:Label ID="lbhIncomeDate" runat="server" Text="Income Date"></asp:Label>
                                                            </th>

                                                            <th>
                                                                <asp:Label ID="lbhAmount" runat="server" Text="Amount"></asp:Label>
                                                            </th>

                                                            <th>
                                                                <asp:Label ID="lbhNote" runat="server" Text="Note"></asp:Label>
                                                            </th>

                                                        </tr>

                                                    </thead>
                                                    <%-- END Table Header --%>

                                                    <tbody>

                                                        <asp:Repeater ID="rpData" runat="server" OnItemDataBound="rpData_ItemDataBound" >

                                                            <ItemTemplate>

                                                                <%-- Table Rows --%>
                                                                <tr class="odd gradeX">
                                                                 
                                                                    <td class="text-center">
                                                                        <asp:CheckBox runat="server" ID="chkIsSelected" Checked='<%#Eval("IncomeID").ToString().Trim() == String.Empty ? false : true %>' />
                                                                            <asp:HiddenField ID="hdIncomeID" runat="server" Value='<%#Eval("IncomeID") %>' />
                                                                    </td>

                                                                    <td class="text-center">
                                                                        <%#Container.ItemIndex+1 %>
                                                                    </td>

                                                                    <td>
                                                                        <asp:DropDownList ID="ddlFinYearID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                                                      </td>

                                                                    <%-- <td>
                                                                        <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server" SelectedValue='<%#Eval("HospitalID") %>'></asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>
                                                                    </td>--%>

                                                                    <td>

                                                                        <asp:DropDownList ID="ddlIncomeTypeID" CssClass="form-control select2me" runat="server" ></asp:DropDownList>
                                                                     </td>
                                                                    
                                                                    <td>
                                                                        <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                                                            <asp:TextBox ID="dtpIncomeDate" CssClass="form-control" runat="server" placeholder="Income Date" Text='<%#Eval("IncomeDate", "{0:yyyy-MM-dd}") %>'></asp:TextBox>
                                                                            <span class="input-group-btn">
                                                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                                                            </span>
                                                                        </div>
                                                                     </td>

                                                                    <td>
                                                                        <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Amount" Text='<%#Eval("Amount") %>'></asp:TextBox>
                                                                        <asp:CompareValidator ID="cvAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="Enter Valid Amount" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                                                     </td>

                                                                    <td>
                                                                        <asp:TextBox ID="txtNote" CssClass="form-control" runat="server" TextMode="MultiLine" PlaceHolder="Enter Note" Text='<%#Eval("Note") %>'></asp:TextBox>
                                                                    </td>

                                                                    <%--Demo Field--%>
                                                                    <%--                                                                    <td>
                                                                        <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" Text='<%#Eval("Remarks") %>' PlaceHolder="Enter Remarks"></asp:TextBox>
                                                                    </td>--%>
                                                                </tr>
                                                                <%-- END Table Rows --%>
                                                            </ItemTemplate>

                                                        </asp:Repeater>

                                                    </tbody>

                                                </table>

                                            </div>

                                        </div>

                                        <div class="form-actions" runat="server">

                                            <div class="row">

                                                <div class="col-md-offset-1 col-md-9">
                                                    <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" SkinID="lbtnAddRow" Visible="true">
                                                    </asp:LinkButton>
                                                    <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                                    <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Income/ACC_Income/ACC_IncomeList.aspx"></asp:HyperLink>
                                                </div>

                                            </div>

                                        </div>

                                    </div>
                                </div>

                            </div>

                        </div>

                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>

        </ContentTemplate>

    </asp:UpdatePanel>



    <%-- Loading  --%>
    <asp:UpdateProgress ID="upr" runat="server">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server" Text="Please wait... " />
                <asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- END Loading  --%>


</asp:Content>