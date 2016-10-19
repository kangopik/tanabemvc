<div class="leftPanel">
       @*@code
           Dim rep_position As String = Trim(TryCast(Session("rep_position"), [String]))
       End Code
    @Html.DevExpress().NavBar(Sub(settings)
                                  settings.Name = "MyNavBar"
                                  settings.Groups.Add("Dashboard", "dashboard", "~/Content/Images/home.png")
                                  settings.Groups(0).NavigateUrl = "/home/index"
                                  settings.Width = 170
                                  settings.ShowExpandButtons = False
                                  settings.ExpandButtonPosition = ExpandButtonPosition.Left
                                  settings.AutoCollapse = True
                                  settings.Styles.GroupHeader.Border.BorderStyle = System.Web.UI.WebControls.BorderStyle.None
                                  settings.Styles.GroupHeader.BackColor = System.Drawing.Color.Transparent
                                  settings.Images.Collapse.Url = "~/Content/Images/visit.png"
                                  settings.Images.Expand.Url = "~/Content/Images/sales.png"
                                                                  
                                                          
                                  If rep_position <> "RM" Then
                                      settings.Groups.Add(Sub(group)
                                                              group.Text = "Visit"
                                                              group.ShowExpandButton = DefaultBoolean.False
                                                              group.HeaderImage.Url = "~/Content/Images/visit.png"
                                                              group.Items.Add("Plan", "visitplan", "~/Content/Images/check.png")
                                                              group.Items(0).NavigateUrl = "/visitplan"
                                                          
                                                              group.Items.Add("Realization", "visitrealization", "~/Content/Images/check.png")
                                                              group.Items(1).NavigateUrl = "/visitrealization"
                                                          
                                                              group.Items.Add("Actual", "visitactual", "~/Content/Images/check.png")
                                                              group.Items(2).NavigateUrl = "/visitactual"
                                                          
                                                              group.Items.Add("History", "visithistory", "~/Content/Images/check.png")
                                                              group.Items(3).NavigateUrl = "/visithistory"
                                                          
                                                          End Sub)
                                  End If
                                  If rep_position <> "RM" And rep_position <> "AM" Then
                                      settings.Groups.Add(Sub(group)
                                                              group.Text = "Sales"
                                                              group.ShowExpandButton = DefaultBoolean.False
                                                              group.HeaderImage.Url = "~/Content/Images/sales.png"
                                                              group.Items.Add("Plan", "salesplan", "~/Content/Images/check.png")
                                                              group.Items(0).NavigateUrl = "/salesplan"
                                                              
                                                              group.Items.Add("Realization", "salesrealization", "~/Content/Images/check.png")
                                                              group.Items(1).NavigateUrl = "/salesrealization"
                                                              
                                                              group.Items.Add("Actual", "salesactual", "~/Content/Images/check.png")
                                                              group.Items(2).NavigateUrl = "/salesactual"
                                                              
                                                              group.Items.Add("History", "saleshistory", "~/Content/Images/check.png")
                                                              group.Items(3).NavigateUrl = "/saleshistory"
                                                          End Sub)
                                       
                                      settings.Groups.FindByText("Visit").Expanded = False
                                      settings.Groups.FindByText("Sales").Expanded = False
                                                              
                                  End If
                                       
                                   
                                  If rep_position = "RM" Or rep_position = "AM" Then
                                      settings.Groups.Add(Sub(group)
                                                              group.Text = "Verification"
                                                              group.ShowExpandButton = DefaultBoolean.False
                                                              group.HeaderImage.Url = "~/Content/Images/verification.png"
                                                              group.Items.Add("Visit Plan", "vervisitplan", "~/Content/Images/check.png")
                                                              group.Items(0).NavigateUrl = "/vervisitplan"
                                                              
                                                              group.Items.Add("Visit Realization", "vervisitrealization", "~/Content/Images/check.png")
                                                              group.Items(1).NavigateUrl = "/vervisitrealization"
                                                              
                                                              group.Items.Add("Visit Plan History", "vervisitplanhistory", "~/Content/Images/check.png")
                                                              group.Items(2).NavigateUrl = "/vervisitctual"
                                                              
                                                              group.Items.Add("Visit Realization History", "verrealhistory", "~/Content/Images/check.png")
                                                              group.Items(3).NavigateUrl = "/verrealhistory"
                                                              '=====================END ==========================================================================
                                                              
                                                              group.Items.Add("Sales Plan", "versalesplan", "~/Content/Images/check.png")
                                                              group.Items(4).NavigateUrl = "/versalesplan"
                                                              
                                                              group.Items.Add("Sales Realization", "versalesrealization", "~/Content/Images/check.png")
                                                              group.Items(5).NavigateUrl = "/versalesrealization"
                                                              
                                                              group.Items.Add("Sales Plan History", "versalesplanhistory", "~/Content/Images/check.png")
                                                              group.Items(6).NavigateUrl = "/versalesactual"
                                                              
                                                              group.Items.Add("Sales Realization History", "versalesrealhistory", "~/Content/Images/check.png")
                                                              group.Items(7).NavigateUrl = "/versaleshistory"
                                                              
                                                              
                                                          End Sub)
                                      settings.Groups.FindByText("Verification").Expanded = False
                                  End If
                                 
                                   
                                  settings.Groups.Add(Sub(group)
                                                          group.Text = "Report"
                                                          group.ShowExpandButton = DefaultBoolean.False
                                                          group.HeaderImage.Url = "~/Content/Images/report.png"
                                                          group.Items.Add("Visit Only Pivot", "rptvisitpivot", "~/Content/Images/check.png")
                                                          group.Items(0).NavigateUrl = "/rptvisitpivot"
                                                          
                                                          group.Items.Add("Visit With Product Pivot", "rptvisitproduct", "~/Content/Images/check.png")
                                                          group.Items(1).NavigateUrl = "/rptvisitproduct"
                                                          
                                                          group.Items.Add("Sales Pivot", "rptsalespivot", "~/Content/Images/check.png")
                                                          group.Items(2).NavigateUrl = "/rptsalespivot"
                                                          
                                                          group.Items.Add("Coverage Pivot", "rptcovpivot", "~/Content/Images/check.png")
                                                          group.Items(3).NavigateUrl = "/rptcovpivot"
                                                          
                                                          group.Items.Add("Doctors", "rptdoctor", "~/Content/Images/check.png")
                                                          group.Items(4).NavigateUrl = "/rptdoctor"
                                                          
                                                          group.Items.Add("Doctors Pivot", "rptdoctorpivot", "~/Content/Images/check.png")
                                                          group.Items(5).NavigateUrl = "/rptdoctorpivot"
                                                          
                                                      End Sub)
                                  
                                  settings.Groups.Add(Sub(group)
                                                          group.Text = "Admin"
                                                          group.ShowExpandButton = DefaultBoolean.False
                                                          group.HeaderImage.Url = "~/Content/Images/admin.png"
                                                          
                                                          'group.Items.Add("Import ASO", "adminaso", "~/Content/Images/check.png")
                                                          'group.Items(0).NavigateUrl = "/aso"
                                                          
                                                          'group.Items.Add("Allocation ASO", "addminallocation", "~/Content/Images/check.png")
                                                          'group.Items(1).NavigateUrl = "/allocation"
                                                          
                                                          group.Items.Add("Master Product ASO", "product", "~/Content/Images/check.png")
                                                          group.Items(0).NavigateUrl = "/product"
                                                          
                                                          group.Items.Add("Master Target ASO", "admintarget", "~/Content/Images/check.png")
                                                          group.Items(1).NavigateUrl = "/target"
                                                          
                                                          group.Items.Add("Master Customer ASO", "admincustomer", "~/Content/Images/check.png")
                                                          group.Items(2).NavigateUrl = "/customer"
                                                          
                                                      End Sub)
                                   
                                 
                                 
                                  settings.Groups.FindByText("Report").Expanded = False
                                  settings.Groups.FindByText("Admin").Expanded = False
                                   
                                   
                              End Sub).GetHtml()*@




</div>