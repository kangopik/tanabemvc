@If Model = TANABE_MVC.HeaderViewRenderMode.Title Then
    @<div class="templateTitle">
        @Html.ActionLink("PT. Tanabe Indonesia", "Index", "Home") 
    </div>
Else
    If Model = TANABE_MVC.HeaderViewRenderMode.Full Then
        @<div class="headerTop">
            <div class="templateTitle">
                <img src="~/Content/Images/logo.png"/>              
            </div>
            <div class="loginControl">
                @Html.Partial("LogOnPartialView")
            </div>
        </div>
    End If

    @<div class="headerMenu"> 
    @code
        Dim user_name As String = TryCast(Session("username"), [String])
        Dim rep_position As String = Trim(TryCast(Session("rep_position"), [String]))
    End Code
        
        @If user_name <> "" Then
                
        @If Model = TANABE_MVC.HeaderViewRenderMode.Menu Then
               
                Html.DevExpress().Menu(
                    Sub(settings)
                        settings.Name = "HeaderMenuExpanded"
                        settings.AllowSelectItem = True
                        settings.EnableHotTrack = True
                        settings.EnableAnimation = True
                        settings.Orientation = Orientation.Vertical
                        settings.AppearAfter = 300
                        settings.ItemAutoWidth = False
                        settings.DisappearAfter = 500
                        settings.MaximumDisplayLevels = 0
                        settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                        settings.Styles.Style.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(0)
                        settings.ShowPopOutImages = DefaultBoolean.[True]
                        settings.Items.Add(Sub(item)
                                               item.Text = "Dashboard"
                                           End Sub)
                                       
                        settings.Items.Add(
                            Sub(item)
                                item.Text = "Task"
                                                                  
                                If rep_position <> "RM" Then
                                    item.Items.Add(
                                        Sub(subItem)
                                            subItem.Text = "Visit"
                                            subItem.Image.Url = "~/Content/Images/check.png"
                                            subItem.Items.Add("Visit Plan", "visitplan", "~/Content/Images/check.png")
                                            subItem.Items.Add("Visit Realization", "visitrealization", "~/Content/Images/check.png")
                                            subItem.Items.Add("Visit Actual", "visitactual", "~/Content/Images/check.png")
                                            subItem.Items.Add("Visit History", "visithistory", "~/Content/Images/check.png")
                                            subItem.Items(0).NavigateUrl = "/Visit/Plan"
                                            subItem.Items(1).NavigateUrl = "/Visit/Realization"
                                            subItem.Items(2).NavigateUrl = "/Visit/Actual"
                                            subItem.Items(3).NavigateUrl = "/Visit/History"
                                                                                 
                                        End Sub)
                                End If
                                
                                If rep_position <> "RM" And rep_position <> "AM" Then
                                    item.Items.Add(
                                        Sub(subItem)
                                            subItem.Text = "Sales"
                                            subItem.Image.Url = "~/Content/Images/check.png"
                                            subItem.Items.Add("Sales Plan", "SalesPlan", "~/Content/Images/check.png")
                                            subItem.Items.Add("Sales Realization", "SalesRealization", "~/Content/Images/check.png")
                                            subItem.Items.Add("Sales Actual", "SalesActual", "~/Content/Images/check.png")
                                            subItem.Items.Add("Sales History", "SalesHistory", "~/Content/Images/check.png")
                                            subItem.Items(0).NavigateUrl = "/SalesPlan"
                                            subItem.Items(1).NavigateUrl = "/SalesRealization"
                                            subItem.Items(2).NavigateUrl = "/SalesActual"
                                            subItem.Items(3).NavigateUrl = "/SalesHistory"
                                        End Sub)
                                End If
                            End Sub)
                                           
                        If rep_position = "RM" Or rep_position = "AM" Then
                            settings.Items.Add(
                                Sub(item)
                                    item.Text = "Verification"
                                    item.Items.Add(
                                        Sub(subItem)
                                            subItem.Text = "Visit"
                                            subItem.Image.Url = "~/Content/Images/check.png"
                                            subItem.Items.Add("Visit Plan", "vervisitplan", "~/Content/Images/check.png")
                                            subItem.Items.Add("Visit Realization", "vervisitrealization", "~/Content/Images/check.png")
                                            subItem.Items.Add("Visit Plan History", "vervisitplanhistory", "~/Content/Images/check.png")
                                            subItem.Items.Add("Visit Realization History", "verrealhistory", "~/Content/Images/check.png")
                                            subItem.Items(0).NavigateUrl = "/Verification/Visit/Plan"
                                            subItem.Items(1).NavigateUrl = "/Verification/Visit/Realization"
                                            subItem.Items(2).NavigateUrl = "/Verification/Visit/PlanVerificationHistory"
                                            subItem.Items(3).NavigateUrl = "/Verification/Visit/RealVerificationHistory"
                                                                                 
                                        End Sub)
                                                              
                                    item.Items.Add(
                                        Sub(subItem)
                                            subItem.Text = "Sales"
                                            subItem.Image.Url = "~/Content/Images/check.png"
                                            subItem.Items.Add("Verification Sales Plan", "SalesPlanVerification", "~/Content/Images/check.png")
                                            subItem.Items.Add("Verification Sales Realization", "SalesRealVerification", "~/Content/Images/check.png")
                                            subItem.Items.Add("Verification Sales Plan History", "SalesPlanHistoryVerification", "~/Content/Images/check.png")
                                            subItem.Items.Add("Verification Sales Realization History", "SalesRealHistoryVerification", "~/Content/Images/check.png")
                                            subItem.Items(0).NavigateUrl = "/SalesPlanVerification"
                                            subItem.Items(1).NavigateUrl = "/SalesRealVerification"
                                            subItem.Items(2).NavigateUrl = "/SalesPlanHistoryVerification"
                                            subItem.Items(3).NavigateUrl = "/SalesRealHistoryVerification"
                                                                                 
                                        End Sub)
                                                           
                                End Sub)
                                       
                        End If
                                           
                        settings.Items.Add(
                            Sub(item)
                                item.Text = "Report"
                                item.Items.Add("Visit Only Pivot", "rptvisitpivot", "~/Content/Images/check.png")
                                item.Items.Add("Visit With Product Pivot", "rptvisitproduct", "~/Content/Images/check.png")
                                item.Items.Add("Sales Pivot", "rptsalespivot", "~/Content/Images/check.png")
                                item.Items.Add("Coverage Pivot", "rptcovpivot", "~/Content/Images/check.png")
                                item.Items.Add("Doctors", "rptdoctor", "~/Content/Images/check.png")
                                item.Items.Add("Doctors Pivot", "rptdoctorpivot", "~/Content/Images/check.png")
                                item.Items(0).NavigateUrl = "/rptvisitpivot"
                                item.Items(1).NavigateUrl = "/rptvisitproduct"
                                item.Items(2).NavigateUrl = "/rptsalespivot"
                                item.Items(3).NavigateUrl = "/rptcovpivot"
                                item.Items(4).NavigateUrl = "/rptdoctor"
                                item.Items(5).NavigateUrl = "/rptdoctorpivot"

                            End Sub)
                                       
                        settings.Items.Add(
                            Sub(item)
                                item.Text = "Admin"
                                item.Items.Add(Sub(i)
                                                   i.Items.Add("Monthly Visit", "MonthlyVisit", "~/Content/Images/check.png")
                                                   i.Items(0).NavigateUrl = "/AuditVisitMonthly"
                                               End Sub)
                                item.Items.Add("Master Representative", "MasterRepresentative", "~/Content/Images/check.png")
                                item.Items.Add("Master Doctors", "MasterDoctor", "~/Content/Images/check.png")
                                item.Items.Add("Master SBO", "MasterSbo", "~/Content/Images/check.png")
                                item.Items.Add("Master BO", "MasterBo", "~/Content/Images/check.png")
                                item.Items.Add("Master Regional", "MasterRegional", "~/Content/Images/check.png")
                                item.Items.Add("Master Product", "MasterProduct", "~/Content/Images/check.png")
                                item.Items.Add("Master Visit", "MasterVisit", "~/Content/Images/check.png")
                                item.Items.Add("Master Customers", "mcustomer", "~/Content/Images/check.png")
                                item.Items.Add("Master Products Aso", "mproduct", "~/Content/Images/check.png")
                                item.Items.Add("Master Target", "mtarget", "~/Content/Images/check.png")
                                                              
                                item.Items(0).Text = "Audit"
                                item.Items(1).NavigateUrl = "/MasterRepresentative"
                                item.Items(2).NavigateUrl = "/MasterDoctor"
                                item.Items(3).NavigateUrl = "/MasterSbo"
                                item.Items(4).NavigateUrl = "/MasterBo"
                                item.Items(5).NavigateUrl = "/MasterRegional"
                                item.Items(6).NavigateUrl = "/MasterProduct"
                                item.Items(7).NavigateUrl = "/MasterVisit"
                                item.Items(8).NavigateUrl = "/mcustomer"
                                item.Items(9).NavigateUrl = "/mproduct"
                                item.Items(10).NavigateUrl = "/mtarget"

                            End Sub)

                    End Sub).GetHtml()
            
            Else
            
                Html.DevExpress().Menu(
                    Sub(settings)
                        settings.Name = "HeaderMenu"
                        settings.AllowSelectItem = True
                        settings.EnableHotTrack = True
                        settings.EnableAnimation = True
                        settings.AppearAfter = 300
                        settings.ItemAutoWidth = False
                        settings.DisappearAfter = 500
                        settings.MaximumDisplayLevels = 0
                        settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                        settings.Styles.Style.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(0)
                        settings.ShowPopOutImages = DefaultBoolean.[True]
                        settings.Items.Add(Sub(item)
                                               item.Text = "Dashboard"
                                           End Sub)
                                       
                        settings.Items.Add(
                            Sub(item)
                                item.Text = "Task"
                                                                  
                                If rep_position <> "RM" Then
                                    item.Items.Add(
                                        Sub(subItem)
                                            subItem.Text = "Visit"
                                            subItem.Image.Url = "~/Content/Images/check.png"
                                            subItem.Items.Add("Visit Plan", "visitplan", "~/Content/Images/check.png")
                                            subItem.Items.Add("Visit Realization", "visitrealization", "~/Content/Images/check.png")
                                            subItem.Items.Add("Visit Actual", "visitactual", "~/Content/Images/check.png")
                                            subItem.Items.Add("Visit History", "visithistory", "~/Content/Images/check.png")
                                            subItem.Items(0).NavigateUrl = "/Visit/Plan"
                                            subItem.Items(1).NavigateUrl = "/Visit/Realization"
                                            subItem.Items(2).NavigateUrl = "/Visit/Actual"
                                            subItem.Items(3).NavigateUrl = "/Visit/History"
                                                                                 
                                        End Sub)
                                End If
                                If rep_position <> "RM" And rep_position <> "AM" Then
                                    item.Items.Add(
                                        Sub(subItem)
                                            subItem.Text = "Sales"
                                            subItem.Image.Url = "~/Content/Images/check.png"
                                            subItem.Items.Add("Sales Plan", "SalesPlan", "~/Content/Images/check.png")
                                            subItem.Items.Add("Sales Realization", "SalesRealization", "~/Content/Images/check.png")
                                            subItem.Items.Add("Sales Actual", "SalesActual", "~/Content/Images/check.png")
                                            subItem.Items.Add("Sales History", "SalesHistory", "~/Content/Images/check.png")
                                            subItem.Items(0).NavigateUrl = "/SalesPlan"
                                            subItem.Items(1).NavigateUrl = "/SalesRealization"
                                            subItem.Items(2).NavigateUrl = "/SalesActual"
                                            subItem.Items(3).NavigateUrl = "/SalesHistory"
                                        End Sub)
                                End If
                            End Sub)
                                           
                        If rep_position = "RM" Or rep_position = "AM" Then
                            settings.Items.Add(
                                Sub(item)
                                    item.Text = "Verification"
                                                                 
                                    item.Items.Add(
                                        Sub(subItem)
                                            subItem.Text = "Visit"
                                            subItem.Image.Url = "~/Content/Images/check.png"
                                            subItem.Items.Add("Visit Plan", "vervisitplan", "~/Content/Images/check.png")
                                            subItem.Items.Add("Visit Realization", "vervisitrealization", "~/Content/Images/check.png")
                                            subItem.Items.Add("Visit Plan History", "vervisitplanhistory", "~/Content/Images/check.png")
                                            subItem.Items.Add("Visit Realization History", "verrealhistory", "~/Content/Images/check.png")
                                            subItem.Items(0).NavigateUrl = "/Verification/Visit/Plan"
                                            subItem.Items(1).NavigateUrl = "/Verification/Visit/Realization"
                                            subItem.Items(2).NavigateUrl = "/Verification/Visit/PlanVerificationHistory"
                                            subItem.Items(3).NavigateUrl = "/Verification/Visit/RealVerificationHistory"
                                                                                 
                                        End Sub)
                                                              
                                    item.Items.Add(
                                        Sub(subItem)
                                            subItem.Text = "Sales"
                                            subItem.Image.Url = "~/Content/Images/check.png"
                                            subItem.Items.Add("Verification Sales Plan", "SalesPlanVerification", "~/Content/Images/check.png")
                                            subItem.Items.Add("Verification Sales Realization", "SalesRealVerification", "~/Content/Images/check.png")
                                            subItem.Items.Add("Verification Sales Plan History", "SalesPlanHistoryVerification", "~/Content/Images/check.png")
                                            subItem.Items.Add("Verification Sales Realization History", "SalesRealHistoryVerification", "~/Content/Images/check.png")
                                            subItem.Items(0).NavigateUrl = "/SalesPlanVerification"
                                            subItem.Items(1).NavigateUrl = "/SalesRealVerification"
                                            subItem.Items(2).NavigateUrl = "/SalesPlanHistoryVerification"
                                            subItem.Items(3).NavigateUrl = "/SalesRealHistoryVerification"
                                                                                 
                                        End Sub)
                                                           
                                End Sub)
                                       
                        End If
                                           
                        settings.Items.Add(
                            Sub(item)
                                item.Text = "Report"
                                item.Items.Add("Visit Only Pivot", "rptvisitpivot", "~/Content/Images/check.png")
                                item.Items.Add("Visit With Product Pivot", "rptvisitproduct", "~/Content/Images/check.png")
                                item.Items.Add("Sales Pivot", "rptsalespivot", "~/Content/Images/check.png")
                                item.Items.Add("Coverage Pivot", "rptcovpivot", "~/Content/Images/check.png")
                                item.Items.Add("Doctors", "rptdoctor", "~/Content/Images/check.png")
                                item.Items.Add("Doctors Pivot", "rptdoctorpivot", "~/Content/Images/check.png")
                                item.Items(0).NavigateUrl = "/Report/Rep/VisitOnly"
                                item.Items(1).NavigateUrl = "/Report/Rep/VisitProduct"
                                item.Items(2).NavigateUrl = "/Report/Rep/SalesUser"
                                item.Items(3).NavigateUrl = "/rptcovpivot"
                                item.Items(4).NavigateUrl = "/rptdoctor"
                                item.Items(5).NavigateUrl = "/rptdoctorpivot"

                            End Sub)
                                       
                        settings.Items.Add(
                            Sub(item)
                                item.Text = "Admin"
                                item.Items.Add(Sub(i)
                                                   i.Items.Add("Monthly Visit", "MonthlyVisit", "~/Content/Images/check.png")
                                                   i.Items(0).NavigateUrl = "/AuditVisitMonthly"
                                               End Sub)
                                item.Items.Add("Master Representative", "MasterRepresentative", "~/Content/Images/check.png")
                                item.Items.Add("Master Doctors", "MasterDoctor", "~/Content/Images/check.png")
                                item.Items.Add("Master SBO", "MasterSbo", "~/Content/Images/check.png")
                                item.Items.Add("Master BO", "MasterBo", "~/Content/Images/check.png")
                                item.Items.Add("Master Regional", "MasterRegional", "~/Content/Images/check.png")
                                item.Items.Add("Master Product", "MasterProduct", "~/Content/Images/check.png")
                                item.Items.Add("Master Visit", "MasterVisit", "~/Content/Images/check.png")
                                item.Items.Add("Master Customers", "mcustomer", "~/Content/Images/check.png")
                                item.Items.Add("Master Products Aso", "mproduct", "~/Content/Images/check.png")
                                item.Items.Add("Master Target", "mtarget", "~/Content/Images/check.png")
                                                              
                                item.Items(0).Text = "Audit"
                                item.Items(1).NavigateUrl = "/MasterRepresentative"
                                item.Items(2).NavigateUrl = "/MasterDoctor"
                                item.Items(3).NavigateUrl = "/MasterSbo"
                                item.Items(4).NavigateUrl = "/MasterBo"
                                item.Items(5).NavigateUrl = "/MasterRegional"
                                item.Items(6).NavigateUrl = "/MasterProduct"
                                item.Items(7).NavigateUrl = "/MasterVisit"
                                item.Items(8).NavigateUrl = "/mcustomer"
                                item.Items(9).NavigateUrl = "/mproduct"
                                item.Items(10).NavigateUrl = "/mtarget"

                            End Sub)

                    End Sub).GetHtml()
            
        End If
        End If
    </div>
End If