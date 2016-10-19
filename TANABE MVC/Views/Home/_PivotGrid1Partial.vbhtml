@Html.DevExpress().PivotGrid(Sub(settings)
    settings.Name = "PivotGrid1"
	settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "PivotGrid1Partial"}

		settings.Fields.Add(Sub(field)
        field.Area = PivotArea.FilterArea
        field.FieldName = "PLAN"
        field.Caption = "PLAN"
    End Sub)
		settings.Fields.Add(Sub(field)
        field.Area = PivotArea.FilterArea
        field.FieldName = "MONTH"
        field.Caption = "MONTH"
    End Sub)
		settings.Fields.Add(Sub(field)
        field.Area = PivotArea.FilterArea
        field.FieldName = "DATE"
        field.Caption = "DATE"
    End Sub)
		settings.Fields.Add(Sub(field)
        field.Area = PivotArea.FilterArea
        field.FieldName = "REMICADE"
        field.Caption = "REMICADE"
    End Sub)
	End Sub).Bind(Model).GetHtml()