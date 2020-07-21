Module test
    Delegate Function CompareNumbers(ByVal num1 As Integer, ByVal num2 As Integer) As Integer

    Sub compare(ByVal compareFunc As CompareNumbers)
        Console.WriteLine("comparing...")
        Dim result = compareFunc(5, 6)

        Console.WriteLine(result)

    End Sub
End Module