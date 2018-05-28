Imports System.Configuration

Namespace Configuration

    Public Class ConfigurationManager

        Private m_FantomConfig As FantomConfig

        Public Sub New()
            m_FantomConfig = CType(System.Configuration.ConfigurationManager.GetSection("FantomConfig"), FantomConfig)

        End Sub

        Public ReadOnly Property Configuration As FantomConfig
            Get
                Return m_FantomConfig
            End Get
        End Property

    End Class

End Namespace