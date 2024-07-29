<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MasterDashboard.aspx.cs" Inherits="AdminPanel_MasterDashboard" %>


<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Master DashBoard " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
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
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="upMasterDashboard" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlHospitalID"  />

        </Triggers>
        <ContentTemplate>
            <asp:UpdatePanel ID="upMasterDashboard2" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
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
                                    <asp:Label ID="lblFormHeader" runat="server" Text="Master DashBoard"></asp:Label>
                                </span>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <div class="form-horizontal" role="form">
                                <div class="form-body">
                                    <div class="row">
                                        <div class="col-md-5">
                                            <div class="form-group">
                                                <label class="col-md-2 control-label"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    <span class="required">*</span>
                                                    <asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Hospital"></asp:Label>
                                                </label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server" AutoPostBack="true" ></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label class="col-md-2 control-label"></label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnShow" runat="server" SkinID="btnShow" OnClick="btnShow_Click" Text="Show" />
                                                <asp:HyperLink ID="hlCancel1" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/MasterDashboard.aspx" Text="Cancel"></asp:HyperLink>
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

    <asp:UpdatePanel ID="upCount" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="pnlCount" runat="server" Visible="false">
                <div class="portlet light">
                    <div class="portlet-title">
                        <div class="caption font-green">
                            <i class="fa fa-line-chart font-green"></i>
                            <span class="caption-subject bold uppercase">Total Overview</span>
                        </div>
                        <div class="tools"></div>
                    </div>
                    <div class="portlet-body form">
                        <div class="form-horizontal" role="form">
                            <div class="form-body">
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                        <a class="dashboard-stat dashboard-stat-v2 green" href="Account/ACC_Income/ACC_IncomeList.aspx">
                                            <div class="visual">
                                                <i class="fa fa-comments"></i>
                                            </div>
                                            <div class="details">
                                                <div class="number">
                                                    <asp:Label runat="server" ID="lblIncomeTotal"></asp:Label>
                                                </div>
                                                <div class="desc">Total Incomes</div>
                                            </div>
                                        </a>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                        <a class="dashboard-stat dashboard-stat-v2 red" href="Account/ACC_Expense/ACC_ExpenseList.aspx">
                                            <div class="visual">
                                                <i class="fa fa-list"></i>
                                            </div>
                                            <div class="details">
                                                <div class="number">
                                                    <asp:Label runat="server" ID="lblExpenseTotal"></asp:Label>
                                                </div>
                                                <div class="desc">Total Expenses</div>
                                            </div>
                                        </a>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                        <a class="dashboard-stat dashboard-stat-v2 blue" href="Account/ACC_Transaction/ACC_TransactionList.aspx">
                                            <div class="visual">
                                                <i class="fa fa-globe"></i>
                                            </div>
                                            <div class="details">
                                                <div class="number">
                                                    <asp:Label runat="server" ID="lblPatientTotal"></asp:Label>
                                                </div>
                                                <div class="desc">Total Patients</div>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <!-- BEGIN RESULTS TABLE -->
                <div class="portlet box green">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-bullhorn"></i>Day Wise Monthly Income</span>
                       
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                        </div>

                    </div>
                    <div class="portlet-body">
                        <asp:Label ID="lblNoIncomeRecords" runat="server" Text="No Income Records Found" Visible="false" CssClass="text-danger" />

                        <asp:GridView ID="IncomeList" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" ShowFooter="True" DataKeyNames="Date" OnRowDataBound="IncomeList_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">Date</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">January</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblJan" runat="server" Text='<%# Eval("Jan", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">February</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFeb" runat="server" Text='<%# Eval("Feb", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">March</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMar" runat="server" Text='<%# Eval("Mar", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">April</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblApr" runat="server" Text='<%# Eval("Apr", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">May</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMay" runat="server" Text='<%# Eval("May", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">June</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblJun" runat="server" Text='<%# Eval("Jun", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">July</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblJul" runat="server" Text='<%# Eval("Jul", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">August</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAug" runat="server" Text='<%# Eval("Aug", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">September</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSep" runat="server" Text='<%# Eval("Sep", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">October</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblOct" runat="server" Text='<%# Eval("Oct", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">November</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNov" runat="server" Text='<%# Eval("Nov", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">December</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDec" runat="server" Text='<%# Eval("Dec", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="LightGray" Font-Bold="True" />
                        </asp:GridView>
                    </div>
                </div>
                <!-- END RESULTS TABLE -->
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdatePanel ID="UpdatePanel2" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <!-- BEGIN RESULTS TABLE -->
                <div class="portlet  box red">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-bullhorn"></i>Day Wise Monthly Expense</span>
                       
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <asp:Label ID="lblNoExpenseRecords" runat="server" Text="No Expense Records Found" Visible="false" CssClass="text-danger" />
                        <asp:GridView ID="ExpenseList" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" ShowFooter="True" DataKeyNames="Date" OnRowDataBound="ExpenseList_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">Date</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">January</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Jan", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">February</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Feb", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">March</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Mar", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">April</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Apr", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">May</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("May", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">June</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Jun", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">July</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Jul", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">August</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("Aug", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">September</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("Sep", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">October</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("Oct", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">November</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("Nov", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div class="TRDark" style="text-align: center; font-weight: bold;">December</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("Dec", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="LightGray" Font-Bold="True" />
                        </asp:GridView>
                    </div>

                </div>
                <!-- END RESULTS TABLE -->
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdatePanel ID="UpdatePanel3" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <!-- BEGIN RESULTS TABLE -->
                <div class="portlet  box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-line-chart"></i></i> Treatment Wise Summary</span>
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <asp:Label ID="lblNoPatientsRecords" runat="server" Text="No Treatment Summary Records Found" Visible="false" CssClass="text-danger" />
                        <asp:GridView ID="TreatmentWiseSummary" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" ShowFooter="false">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div style="text-align: center; font-weight: bold;">Sr.</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div style="text-align: center; font-weight: bold;">Treatment Type</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTreatmentType" runat="server" Text='<%# Eval("TreatmentType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div style="text-align: center; font-weight: bold;">Patients Count</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatientsCount" runat="server" Text='<%# Eval("PatientsCount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="TRDark" />
                                    <HeaderTemplate>
                                        <div style="text-align: right; font-weight: bold;">Income Amount</div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIncomesAmount" runat="server" Text='<%# Eval("IncomesAmount", "{0:C}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <!-- END RESULTS TABLE -->
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>
