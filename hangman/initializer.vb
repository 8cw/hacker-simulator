Imports Newtonsoft.Json

Module initializer
    Public Enum ConsoleEvent
        CTRL_C_EVENT = 0
        CTRL_BREAK_EVENT = 1
        CTRL_CLOSE_EVENT = 2
        CTRL_LOGOFF_EVENT = 5
        CTRL_SHUTDOWN_EVENT = 6
    End Enum

    Public Delegate Function ConsoleEventDelegate(ByVal MyEvent As ConsoleEvent) As Boolean
    Private Declare Function SetConsoleCtrlHandler Lib "kernel32" (ByVal handlerRoutine As ConsoleEventDelegate, ByVal add As Boolean) As Boolean

    Private handler As ConsoleEventDelegate

    Sub startInit()
        Dim oldUserData As IUserData
        Try
            Debug.WriteLine(JsonConvert.DeserializeObject(My.Computer.FileSystem.ReadAllText(Environment.CurrentDirectory & "\data.json")))
            Dim savedData = CType(JsonConvert.DeserializeObject(My.Computer.FileSystem.ReadAllText(Environment.CurrentDirectory & "\data.json"), New JsonSerializerSettings() With {.TypeNameHandling = TypeNameHandling.Auto}), ISerializedUserData)
            oldUserData = New UserData(CInt(savedData.money))
        Catch ex As Exception
            Console.WriteLine(ex)
            oldUserData = New UserData(0)
        End Try
        Console.WriteLine(oldUserData)
        Console.WriteLine(oldUserData.money)
        Console.Write("enter name: ")
        Console.ReadLine()

        Dim data As New Dictionary(Of String, String)
        data.Add("money", "9999")

        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine(JsonConvert.SerializeObject(data))
        Console.WriteLine(data)
        Console.ResetColor()

        Console.Clear()

        My.Computer.FileSystem.WriteAllText(Environment.CurrentDirectory & "\data.json", JsonConvert.SerializeObject(data), False)



        handler = AddressOf HandleShutdown
        If Not SetConsoleCtrlHandler(handler, True) Then
            Console.WriteLine("ERR - failed to set console ctrl handler")
        End If
    End Sub

    Public Function HandleShutdown(ByVal [event] As ConsoleEvent) As Boolean
        Dim cancel As Boolean = False

        Select Case [event]

            Case ConsoleEvent.CTRL_C_EVENT
                Console.WriteLine("CTRL+C received!")
            Case ConsoleEvent.CTRL_BREAK_EVENT
                Console.WriteLine("CTRL+BREAK received!")
            Case ConsoleEvent.CTRL_CLOSE_EVENT
                Console.WriteLine("Program being closed!")
            Case ConsoleEvent.CTRL_LOGOFF_EVENT
                Console.WriteLine("User is logging off!")
            Case ConsoleEvent.CTRL_SHUTDOWN_EVENT
                Console.WriteLine("Windows is shutting down.")
                ' My cleanup code here
        End Select

        Console.ReadKey()

        Return cancel
    End Function
End Module