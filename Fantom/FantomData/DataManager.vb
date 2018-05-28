Imports System.Data
Imports System.Data.SqlClient
Imports Fantom.Configuration
Imports System.Web
Imports System.Web.Caching

Namespace Data

    Public Class DataManager

        Private m_Connection As SqlConnection
        Private m_Command As SqlCommand
        Private m_Config As FantomConfig

        Public Sub New()
            Dim _configManager As New ConfigurationManager()
            m_Config = _configManager.Configuration
            m_Connection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings(m_Config.ConnectionStringName).ConnectionString)

        End Sub

        Public Function GetKeyValue(ByVal Group As String, ByVal Key As String) As String
            Dim _dt As DataTable
            If HttpContext.Current.Cache(Group) Is Nothing Then
                m_Command = New SqlCommand("Select [" & m_Config.KeyField & "] As FldKey, " & _
                    "[" & m_Config.ValueField & "] As FldValue, [" & m_Config.CultureField & _
                    "] As FldCulture From [" & m_Config.TableName & _
                    "] Where [" & m_Config.GroupField & "] = '" & Group & "'", m_Connection)
                m_Connection.Open()
                _dt = New DataTable()
                _dt.Load(m_Command.ExecuteReader())
                m_Connection.Close()
                HttpContext.Current.Cache.Add(Group, _dt, Nothing, DateTime.Now.AddHours(2), Cache.NoSlidingExpiration, CacheItemPriority.High, Nothing)
            Else
                _dt = HttpContext.Current.Cache(Group)
            End If
            Dim _culture As String = "en-US"
            If HttpContext.Current.Session(m_Config.CultureSessionKey) IsNot Nothing Then
                _culture = HttpContext.Current.Session(m_Config.CultureSessionKey)
            End If
            Dim _drList() As DataRow = _dt.Select("FldCulture = '" & _culture & "' And FldKey = '" & Key & "'")
            If _drList.Length = 0 Then
                Return Nothing
            Else
                Return _drList(0).Item("FldValue")
            End If
        End Function

    End Class

End Namespace