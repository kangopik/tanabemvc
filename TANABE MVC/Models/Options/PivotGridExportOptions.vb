Public Class PivotGridExportOptions

    Public Enum PivotGridExportFormats
        ExcelDataAware
        Pdf
        Excel
        Mht
        Rtf
        Text
        Html
    End Enum

    Public Class PivotGridExportDemoOptions
        Public Sub New()
            WYSIWYG = New PivotGridExportWYSIWYGDemoOptions()
            DataAware = New PivotGridDataAwareDemoExportOptions()
        End Sub

        Public Property ExportType() As PivotGridExportFormats
            Get
                Return m_ExportType
            End Get
            Set(value As PivotGridExportFormats)
                m_ExportType = Value
            End Set
        End Property
        Private m_ExportType As PivotGridExportFormats
        Public Property WYSIWYG() As PivotGridExportWYSIWYGDemoOptions
            Get
                Return m_WYSIWYG
            End Get
            Set(value As PivotGridExportWYSIWYGDemoOptions)
                m_WYSIWYG = Value
            End Set
        End Property
        Private m_WYSIWYG As PivotGridExportWYSIWYGDemoOptions
        Public Property DataAware() As PivotGridDataAwareDemoExportOptions
            Get
                Return m_DataAware
            End Get
            Set(value As PivotGridDataAwareDemoExportOptions)
                m_DataAware = Value
            End Set
        End Property
        Private m_DataAware As PivotGridDataAwareDemoExportOptions
    End Class
    Public Class PivotGridExportWYSIWYGDemoOptions
        Public Sub New()
            PrintFilterHeaders = True
            PrintColumnHeaders = True
            PrintRowHeaders = True
            PrintDataHeaders = True
        End Sub

        Public Property PrintHeadersOnEveryPage() As Boolean
            Get
                Return m_PrintHeadersOnEveryPage
            End Get
            Set(value As Boolean)
                m_PrintHeadersOnEveryPage = Value
            End Set
        End Property
        Private m_PrintHeadersOnEveryPage As Boolean
        Public Property PrintFilterHeaders() As Boolean
            Get
                Return m_PrintFilterHeaders
            End Get
            Set(value As Boolean)
                m_PrintFilterHeaders = Value
            End Set
        End Property
        Private m_PrintFilterHeaders As Boolean
        Public Property PrintColumnHeaders() As Boolean
            Get
                Return m_PrintColumnHeaders
            End Get
            Set(value As Boolean)
                m_PrintColumnHeaders = Value
            End Set
        End Property
        Private m_PrintColumnHeaders As Boolean
        Public Property PrintRowHeaders() As Boolean
            Get
                Return m_PrintRowHeaders
            End Get
            Set(value As Boolean)
                m_PrintRowHeaders = Value
            End Set
        End Property
        Private m_PrintRowHeaders As Boolean
        Public Property PrintDataHeaders() As Boolean
            Get
                Return m_PrintDataHeaders
            End Get
            Set(value As Boolean)
                m_PrintDataHeaders = Value
            End Set
        End Property
        Private m_PrintDataHeaders As Boolean
    End Class

    Public Class PivotGridDataAwareDemoExportOptions
        Public Sub New()
            AllowGrouping = True
            AllowFixedColumnAndRowArea = True
        End Sub

        Public Property AllowGrouping() As Boolean
            Get
                Return m_AllowGrouping
            End Get
            Set(value As Boolean)
                m_AllowGrouping = Value
            End Set
        End Property
        Private m_AllowGrouping As Boolean
        Public Property AllowFixedColumnAndRowArea() As Boolean
            Get
                Return m_AllowFixedColumnAndRowArea
            End Get
            Set(value As Boolean)
                m_AllowFixedColumnAndRowArea = Value
            End Set
        End Property
        Private m_AllowFixedColumnAndRowArea As Boolean
        Public Property ExportDisplayText() As Boolean
            Get
                Return m_ExportDisplayText
            End Get
            Set(value As Boolean)
                m_ExportDisplayText = Value
            End Set
        End Property
        Private m_ExportDisplayText As Boolean
        Public Property ExportRawData() As Boolean
            Get
                Return m_ExportRawData
            End Get
            Set(value As Boolean)
                m_ExportRawData = Value
            End Set
        End Property
        Private m_ExportRawData As Boolean
    End Class

End Class
