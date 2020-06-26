Module Project
    Function myCustomCompareFunction(a As Integer, b As Integer) As Integer
        Return a * b
    End Function

    Sub Main()
        initializer.startInit()
        test.compare(AddressOf myCustomCompareFunction)
        Console.ReadKey()

        While (Not (Console.ReadKey(True).Key = ConsoleKey.S))
            Console.WriteLine("press s")
        End While
    End Sub
End Module
