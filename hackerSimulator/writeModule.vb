Module writeModule
    Private origHeight As Integer
    Private newHeight As Integer

    Private continueWrite As Boolean = True

    Private Sub writeBottom()
        If origHeight > 8000 Then
            Console.Clear()
            origHeight = -Console.WindowHeight
        End If

        Console.CursorVisible = False

        origHeight = Console.WindowTop
        newHeight = origHeight + Console.WindowHeight
        Console.SetCursorPosition(0, newHeight)

        Console.WriteLine("origHeight:{1}{0}newHeight:{2}{0}", Environment.NewLine, origHeight, newHeight)

        Console.SetCursorPosition(0, newHeight + Console.WindowHeight - 2)
        Console.WriteLine("hello")
        Console.WriteLine("yeet")

        Console.SetCursorPosition(0, newHeight)
        Console.CursorVisible = True
    End Sub

    Public Sub stopRunning()
        continueWrite = False
    End Sub

    Public Sub startRunning()
        continueWrite = True
        While continueWrite
            writeBottom()
            Console.ReadKey(True)
        End While


    End Sub
End Module
