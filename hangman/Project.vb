Imports System.Text
Imports System.Text.RegularExpressions

Module Project
    ' Make global items
    ' Make constants
    ''' <summary>
    ''' The minimum requirement for the length of the words for the game
    ''' </summary>
    Public Const MIN_WORD_COUNT = 3
    ''' <summary>
    ''' The maximum requirement for the length of the words for the game
    ''' </summary>
    Public Const MAX_WORD_COUNT = 10
    ''' <summary>
    ''' An interval in miliseconds between each character
    ''' </summary>
    Public Const WORD_TYPE_INTERVAL = 15
    ''' <summary>
    ''' An interval in milliseconds between each line
    ''' </summary>
    Public Const WORD_LINE_INTERVAL = 100
    ''' <summary>
    ''' An integer that represents the amount of lives someone gets before they die
    ''' </summary>
    Public Const MAX_LIVES = 6

    ' Make public Items
    ''' <summary>
    ''' A dictionary that has key/value pairs for the amount of wrong answers and the hangman object
    ''' </summary>
    Public HANGMAN_OBJ As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)

    ''' <summary>
    ''' Arrays holding all the possible words for each difficulty setting
    ''' </summary>
    Public PossibleWords As Dictionary(Of Integer, String()) = New Dictionary(Of Integer, String())

    ' Make private items
    ''' <summary>
    ''' The splash screen to show to the user when they first start the program
    ''' </summary>
    Private Const SPLASH_SCREEN = "  _                                             
 | |                                            
 | |__   __ _ _ __   __ _ _ __ ___   __ _ _ __  
 | '_ \ / _` | '_ \ / _` | '_ ` _ \ / _` | '_ \ 
 | | | | (_| | | | | (_| | | | | | | (_| | | | |
 |_| |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_|
                     __/ |                      
                    |___/                       "
    ''' <summary>
    ''' An integer describing the amount of lives the user has remaining for the game
    ''' </summary>
    Private livesRemaining As Integer = MAX_LIVES
    ''' <summary>
    ''' The word the user has to guess
    ''' </summary>
    Private selectedWord As String
    ''' <summary>
    ''' The word the user has guessed so far
    ''' </summary>
    Private userEnteredWord As String
    ''' <summary>
    ''' The random object to use to calculate random things
    ''' </summary>
    Private randomObj As New Random

    ''' <summary>
    ''' Asks the user for a difficulty between <c>MIN_WORD_COUNT</c> and <c>MAX_WORD_COUNT</c> repeatedly until they give a valid response.
    ''' </summary>
    ''' <returns>An integer describing what difficulty the user would like between the range of MIN_WORD_COUNT and MAX_WORD_COUNT</returns>
    Public Function GetUserDifficulty() As Integer
        Debug.WriteLine("[PROJECT] Getting user difficulty level")
        Dim difficulty? As Integer
        While Not difficulty.HasValue Or difficulty < MIN_WORD_COUNT Or difficulty > MAX_WORD_COUNT
            difficulty = Nothing

            SlowType.slowType(String.Format("Please enter how many characters the word should be (between {0}-{1}): ", MIN_WORD_COUNT, MAX_WORD_COUNT), WORD_TYPE_INTERVAL, ConsoleLogType.Question)
            Try
                difficulty = CInt(Console.ReadLine())
            Catch ex As Exception
                If ex.GetType().ToString() = "System.InvalidCastException" Then
                    slowTypeNewLine("Please only enter numbers.", WORD_TYPE_INTERVAL, ConsoleLogType.GameError)
                ElseIf ex.GetType().ToString() = "System.OutOfMemoryException" Then
                    slowTypeNewLine("Please install more RAM.", WORD_TYPE_INTERVAL, ConsoleLogType.GameError)
                End If
            End Try

            ' Customize error message if out of bounds
            Console.ForegroundColor = ConsoleColor.Red
            If difficulty > MAX_WORD_COUNT And difficulty.HasValue Then
                Console.WriteLine(String.Format("Please enter a number smaller than {0}.", MAX_WORD_COUNT + 1))
            ElseIf difficulty < MIN_WORD_COUNT And difficulty.HasValue Then
                Console.WriteLine(String.Format("Please enter a number that is bigger than {0}.", MIN_WORD_COUNT - 1))
            End If
            Console.ForegroundColor = ConsoleColor.White
        End While

        Debug.WriteLine(String.Format("[PROJECT] Got user difficulty of {0}", difficulty))

        Return CInt(difficulty)
    End Function

    Public Sub Main()
        Debug.WriteLine("[PROJECT] Starting program")
        ' Run initializer
        Initializer.Main()

        Debug.WriteLine("[PROJECT] Getting user name")
        ' get user name and clear console
        SlowType.slowType("Please enter your name: ", WORD_TYPE_INTERVAL, ConsoleLogType.Question)
        Dim userName = Console.ReadLine()
        Console.Clear()

        Debug.WriteLine("[PROJECT] Display splash screen")
        ' Write the splash screen
        slowTypeNewLine(String.Format("Welcome, {0} to", userName), WORD_TYPE_INTERVAL, ConsoleLogType.Info)
        slowTypeLineNewLine(SPLASH_SCREEN, WORD_LINE_INTERVAL, ConsoleLogType.Info)

        ' Wait small time for user to feel the vibe, then allow them to start game
        Threading.Thread.Sleep(750)
        SlowType.slowType("Press any key to start game.", WORD_TYPE_INTERVAL, ConsoleLogType.RequestAction)
        ' Wait until user presses key
        Console.ReadKey(True)
        Console.Clear()

        Dim difficulty = GetUserDifficulty()

        ' Tell the user their difficulty and then wait for them to ackowledge it
        slowTypeNewLine(String.Format("{0}, you have selected {1} as your difficulty.", userName, difficulty), WORD_TYPE_INTERVAL, ConsoleLogType.Info)
        Threading.Thread.Sleep(100)
        slowTypeNewLine("Please press any key to continue", WORD_TYPE_INTERVAL, ConsoleLogType.RequestAction)
        Console.ReadKey(True)

        ' Start game
        Debug.WriteLine("[PROJECT] Starting game")

        ' Pick word
        If Not PossibleWords.ContainsKey(difficulty) Then
            slowTypeNewLine(String.Format("ERROR. Unable to find words for {0} difficulty.", difficulty), WORD_TYPE_INTERVAL, ConsoleLogType.GameError)
        End If
        Dim availableWords = PossibleWords.Item(difficulty)

        selectedWord = availableWords(randomObj.Next(0, availableWords.Length - 1)).ToLower()
        userEnteredWord = Regex.Replace(selectedWord, ".", "_")
        Debug.WriteLine(String.Format("[PROJECT] Generated random word {0}", selectedWord))

        While (Not userEnteredWord = selectedWord) And (livesRemaining > 0)
            Debug.WriteLine(String.Format("[PROJECT] Current user guessed word is {0}", userEnteredWord))
            ' Redraw hangman state
            Console.Clear()
            Console.Write(HANGMAN_OBJ.Item(MAX_LIVES - livesRemaining))
            ' Drop 2 lines
            Console.Write(Environment.NewLine & Environment.NewLine)

            ' Ask user for their letter
            SlowType.slowType("Please enter your letter guess: ", WORD_TYPE_INTERVAL, ConsoleLogType.Question)
            Dim userGuess = CChar(Console.ReadKey().Key.ToString().ToLower())

            Debug.WriteLine(String.Format("[PROJECT] User guessed {0}", userGuess))

            If (selectedWord.Contains(userGuess)) Then
                ' Find all occurances in selectedWord
                Dim newUserEnteredWord = New StringBuilder(userEnteredWord)
                For letterIndex = 0 To selectedWord.Length
                    Dim letter = selectedWord(letterIndex)

                    If letter = userGuess Then
                        newUserEnteredWord(letterIndex) = userGuess
                    End If
                Next
                userEnteredWord = newUserEnteredWord
            Else
                ' User guessed wrong
                livesRemaining = livesRemaining - 1
            End If
        End While

        Console.ReadKey(True)
    End Sub
End Module
