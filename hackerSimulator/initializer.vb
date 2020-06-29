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
        Console.Write("enter name: ")
        Console.ReadLine()

        Dim data As New Object With {
            .money = "test"
        }

        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine(JsonConvert.SerializeObject(data))
        Console.WriteLine(data)
        Console.ResetColor()

        Console.Clear()

        My.Computer.FileSystem.WriteAllText(Environment.CurrentDirectory & "\test.json", JsonConvert.SerializeObject(data), False)


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