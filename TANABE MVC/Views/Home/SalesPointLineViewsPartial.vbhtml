@code
    'Dim options As ChartShowLabelsDemoOptions = DirectCast(ViewData(ChartDemoHelper.OptionsKey), ChartShowLabelsDemoOptions)
    Dim settings As New ChartControlSettings()
    settings.Name = "saleschart"
    settings.BorderOptions.Visibility = DefaultBoolean.[False]
    settings.Height = 350
    settings.Width = 510
    'settings.CrosshairEnabled = If(options.ShowLabels, DefaultBoolean.[False], DefaultBoolean.[True])

    Dim titleText As String
    'If options.View = DevExpress.XtraCharts.ViewType.StepLine OrElse options.View = DevExpress.XtraCharts.ViewType.StepLine3D Then
    '    titleText = "Corporations with highest market value in 2004"
    '    settings.SeriesTemplate.DataFilters.Add(New DataFilter("Year", "System.String", DataFilterCondition.Equal, "2004"))
    'Else
    'titleText = "Corporations with highest market value"
    'End If
    'settings.Titles.Add(New ChartTitle() With {	Key .Font = New Font("Tahoma", 18), Key .Text = titleText })
    'settings.Titles.Add(New ChartTitle() With { _
    '	Key .Alignment = StringAlignment.Far, _
    '	Key .Dock = ChartTitleDockStyle.Bottom, _
    '	Key .Font = New Font("Tahoma", 8), _
    '	Key .TextColor = Color.Gray, _
    '	Key .Text = "From www.bea.gov" _
    '})

    'settings.SeriesTemplate.ChangeView(options.View)
    'settings.SeriesTemplate.ArgumentDataMember = "Corporation"
    'settings.SeriesTemplate.ValueDataMembers(0) = "MarketValue"
    'settings.SeriesTemplate.LabelsVisibility = If(options.ShowLabels, DefaultBoolean.[True], DefaultBoolean.[False])
    'If options.View = DevExpress.XtraCharts.ViewType.Point Then
    '    DirectCast(settings.SeriesTemplate.View, PointSeriesView).PointMarkerOptions.Size = 20
    'End If
    'If options.View = DevExpress.XtraCharts.ViewType.StepLine Then
    '    Dim view As StepLineSeriesView = DirectCast(settings.SeriesTemplate.View, StepLineSeriesView)
    '    view.ColorEach = True
    '    view.LineMarkerOptions.Kind = MarkerKind.Square
    '    view.LineMarkerOptions.Size = 20
    'End If
    settings.SeriesTemplate.Label.ResolveOverlappingMode = ResolveOverlappingMode.[Default]
    settings.SeriesDataMember = "Year"
    settings.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right

    If TypeOf settings.Diagram Is XYDiagram Then
        Dim diagram As XYDiagram = DirectCast(settings.Diagram, XYDiagram)
        diagram.AxisY.Interlaced = True
        'diagram.AxisY.Title.Text = "Market value (billion US$)"
        diagram.AxisY.Title.Visibility = DefaultBoolean.[True]
        diagram.AxisY.WholeRange.SetMinMaxValues(120, 390)
    Else
        Dim diagram As XYDiagram3D = DirectCast(settings.Diagram, XYDiagram3D)
        diagram.AxisX.Label.MaxWidth = 70
        diagram.AxisY.Interlaced = True
        diagram.RotationType = RotationType.UseAngles
        diagram.RotationOrder = RotationOrder.XYZ
        diagram.ZoomPercent = 140
        diagram.VerticalScrollPercent = 10
        diagram.AxisY.WholeRange.SetMinMaxValues(120, 390)
    End If
end code

@Html.DevExpress().Chart(settings).Bind(Model).GetHtml()