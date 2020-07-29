Module Util
    Enum ConsoleLogType
        Info
        GameError
        Question
        RequestAction
    End Enum

    ''' <summary>
    ''' Spaces a message out by inserting a space between each character
    ''' </summary>
    ''' <param name="message">The message to space out</param>
    ''' <returns></returns>
    Function spaceMessageOut(message As String) As String
        Dim newMessage = ""

        ' Space the message out
        For Each c In message
            newMessage += c + " "
        Next

        ' Trim the last space
        Return newMessage.Substring(0, newMessage.Length - 1)
    End Function
End Module
