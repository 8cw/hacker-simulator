Imports hackerSimulator

Public Class UserData
    Implements IUserData

    Public Property money As Integer Implements IUserData.money

    Public Sub New(_money As Integer)
        money = _money
    End Sub

End Class
