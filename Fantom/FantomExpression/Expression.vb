Imports System
Imports System.CodeDom
Imports System.Web.UI
Imports System.ComponentModel
Imports System.Web.Compilation

<ExpressionPrefix("Fantom"), ExpressionEditor("FantomEditor")> _
Public Class Expression
    Inherits ExpressionBuilder


    Public Shared Function GetEvalData(ByVal expression As String, ByVal target As Type, ByVal entry As String) As Object

        Dim _fantomData As New Fantom.Data.DataManager()
        Dim _expressionData() As String = expression.Split(":")
        Return _fantomData.GetKeyValue(_expressionData(0), _expressionData(1))

    End Function

    Public Overrides Function EvaluateExpression(ByVal target As Object, ByVal entry As BoundPropertyEntry, ByVal parsedData As Object, _
       ByVal context As ExpressionBuilderContext) As Object

        Return GetEvalData(entry.Expression, target.GetType(), entry.Name)

    End Function

    Public Overrides Function GetCodeExpression(entry As BoundPropertyEntry, parsedData As Object, context As ExpressionBuilderContext) As CodeExpression
        Dim _type As Type = entry.DeclaringType
        Dim _descriptor As PropertyDescriptor = TypeDescriptor.GetProperties(_type)(entry.PropertyInfo.Name)
        Dim _expressionArray(2) As CodeExpression
        _expressionArray(0) = New CodePrimitiveExpression(entry.Expression.Trim())
        _expressionArray(1) = New CodeTypeOfExpression(_type)
        _expressionArray(2) = New CodePrimitiveExpression(entry.Name)
        Return New CodeCastExpression(_descriptor.PropertyType, _
           New CodeMethodInvokeExpression(New CodeTypeReferenceExpression(MyBase.GetType()), "GetEvalData", _expressionArray))
    End Function


End Class
