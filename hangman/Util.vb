Imports System.Text.RegularExpressions

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
    ''' <returns>The spaced out message</returns>
    Function spaceMessageOut(message As String) As String
        Dim newMessage = ""

        ' Space the message out
        For Each c In message
            newMessage += c + " "
        Next

        ' Trim the last space
        Return newMessage.Substring(0, newMessage.Length - 1)
    End Function

    ''' <summary>
    ''' The same as spaceMessageOut, but separates each item by spaces rather than each character.
    ''' </summary>
    ''' <param name="message">The message to space out</param>
    ''' <returns>The spaced out message</returns>
    Function spaceMessageOutBySpace(message As String) As String
        Dim newMessage = ""

        ' Space the message out
        For Each c In Regex.Matches(message, "\S+")
            newMessage += c.ToString() + " "
        Next

        Return newMessage.Substring(0, newMessage.Length - 1)
    End Function
End Module
