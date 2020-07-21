Module Project
    Function myCustomCompareFunction(a As Integer, b As Integer) As Integer
        Dim testVar As String = "test"
        Return a * b
    End Function

    Sub Main()
        initializer.startInit()
        test.compare(AddressOf myCustomCompareFunction)
        Dim testVar As String = "blah"
        Console.WriteLine(testVar)

        Console.ReadKey()

        While (Not (Console.ReadKey(True).Key = ConsoleKey.S))
            Console.WriteLine("press s")
        End While

        Console.WriteLine("PROGRAM DONE.")
        Console.ReadKey()
    End Sub
End Module
