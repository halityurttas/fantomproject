imports System.Configuration

Namespace Configuration

    Public Class FantomConfig
        Inherits ConfigurationSection

        <ConfigurationProperty("CultureSessionKey", DefaultValue:="SiteCulture")> _
        Public Property CultureSessionKey As String
            Get
                Return Me("CultureSessionKey")
            End Get
            Set(value As String)
                Me("CultureSessionKey") = value
            End Set
        End Property

        <ConfigurationProperty("ConnectionStringName", IsRequired:=True)> _
        Public Property ConnectionStringName As String
            Get
                Return Me("ConnectionStringName")
            End Get
            Set(value As String)
                Me("ConnectionStringName") = value
            End Set
        End Property

        <ConfigurationProperty("TableName", DefaultValue:="FantomDictionary")> _
        Public Property TableName As String
            Get
                Return Me("TableName")
            End Get
            Set(value As String)
                Me("TableName") = value
            End Set
        End Property

        <ConfigurationProperty("GroupField", DefaultValue:="Group")> _
        Public Property GroupField As String
            Get
                Return Me("GroupField")
            End Get
            Set(value As String)
                Me("GroupField") = value
            End Set
        End Property

        <ConfigurationProperty("KeyField", DefaultValue:="Key")> _
        Public Property KeyField As String
            Get
                Return Me("KeyField")
            End Get
            Set(value As String)
                Me("KeyField") = value
            End Set
        End Property

        <ConfigurationProperty("CultureField", DefaultValue:="Culture")> _
        Public Property CultureField As String
            Get
                Return Me("CultureField")
            End Get
            Set(value As String)
                Me("CultureField") = value
            End Set
        End Property

        <ConfigurationProperty("ValueField", DefaultValue:="Value")> _
        Public Property ValueField As String
            Get
                Return Me("ValueField")
            End Get
            Set(value As String)
                Me("ValueField") = value
            End Set
        End Property

    End Class


End Namespace