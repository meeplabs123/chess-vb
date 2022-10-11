Module Module1



    Sub Main()



        'Create the array 

        Dim myArray(7, 7)

        Dim owns(7, 7)

        Dim pawns(7, 7)

        Dim to_continue As Boolean = True

        Dim asking_row As String = ""

        Dim asking_column As String = ""

        Dim going_row As String = ""

        Dim going_column As String = ""

        Dim player_turn As Integer = 1



        'Set values 

        For n = 0 To 7

            For m = 0 To 7

                owns(n, m) = 0

                If n = 0 Or n = 1 Then

                    owns(n, m) = 1

                End If

                If n = 7 Or n = 6 Then

                    owns(n, m) = 2

                End If

                If n > 1 Then

                    If n < 6 Then

                        myArray(n, m) = 0

                    Else

                        myArray(n, m) = 1

                    End If

                Else

                    myArray(n, m) = 1

                End If



                If myArray(n, m) = 1 Then
                    pawns(n, m) = 1

                    If n = 0 Or n = 7 Then

                        If m = 0 Then

                            myArray(n, m) = 2

                        ElseIf m = 1 Then

                            myArray(n, m) = 3

                        ElseIf m = 2 Then

                            myArray(n, m) = 4

                        ElseIf m = 3 Then

                            myArray(n, m) = 5

                        ElseIf m = 4 Then

                            myArray(n, m) = 6

                        ElseIf m = 5 Then

                            myArray(n, m) = 4

                        ElseIf m = 6 Then

                            myArray(n, m) = 3

                        ElseIf m = 7 Then

                            myArray(n, m) = 2

                        End If

                    End If

                Else
                    pawns(n, m) = 0
                End If

            Next m

        Next n

        While to_continue

            Console.Clear()

            Draw(myArray, pawns, owns, player_turn)

            If player_turn = 1 Then

                Console.ForegroundColor = ConsoleColor.DarkCyan

            ElseIf player_turn = 2 Then

                Console.ForegroundColor = ConsoleColor.Magenta

            End If

            Console.WriteLine("")

            Console.WriteLine("P" + player_turn.ToString() + " - Select a piece to move:")

            Console.Write("x: ")

            asking_column = Console.ReadLine()

            Console.Write("y: ")

            asking_row = 9 - Console.ReadLine()

            Console.WriteLine("")

            Console.WriteLine("P" + player_turn.ToString() + " - Select a target space:")

            Console.Write("x: ")

            going_column = Console.ReadLine()

            Console.Write("y: ")

            going_row = 9 - Console.ReadLine()



            Try

                If asking_row = going_row Then

                    If asking_column = going_column Then

                        Throw New System.Exception("Cannot Move To Same Place!")

                    End If

                End If

                'EXTENSION WORK
                'If Not checkMove(myArray(asking_row - 1, asking_column - 1), asking_column - 1, asking_row - 1, going_column - 1, going_row - 1, pawns, myArray, player_turn) Then
                'Throw New System.Exception("Invalid Movement")
                'End If

                If owns(asking_row - 1, asking_column - 1) = player_turn Then

                    myArray(going_row - 1, going_column - 1) = myArray(asking_row - 1, asking_column - 1)
                    myArray(asking_row - 1, asking_column - 1) = 0

                    owns(going_row - 1, going_column - 1) = owns(asking_row - 1, asking_column - 1)
                    owns(asking_row - 1, asking_column - 1) = 0

                Else

                    Throw New System.Exception("Not Your Piece!")

                End If

            Catch ex As Exception

                Console.ForegroundColor = ConsoleColor.DarkRed

                Console.WriteLine("")

                Console.WriteLine("Error in an input value: ")

                Console.WriteLine(Split(Split(ex.ToString(), vbCrLf)(0), ": ")(1))

                Console.ReadKey()



                If player_turn = 1 Then

                    player_turn = 2

                ElseIf player_turn = 2 Then

                    player_turn = 1

                End If

            End Try



            If player_turn = 1 Then

                player_turn = 2

            ElseIf player_turn = 2 Then

                player_turn = 1

            End If

        End While



    End Sub



    Function Draw(myArray, pawns, owns, player_turn) As Boolean

        Console.Title = "Chessboard 5000"
        Console.ForegroundColor = ConsoleColor.Red

        Console.WriteLine("[ NO MOVEMENT CHECKS ]")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("[0] No Piece   [1] Pawn   [2] Castle   [3] Knight   [4] Bishop   [5] Queen   [6] King")

        Console.WriteLine("")

        Console.Write("---------Peices---------   ")
        If player_turn = 1 Then
            Console.ForegroundColor = ConsoleColor.White
        Else
            Console.ForegroundColor = ConsoleColor.Black
        End If
        Console.Write("[P1]")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("   ---------Ownage---------")



        For n = 0 To 7

            For m = 0 To 7

                If myArray(n, m) = 0 Then

                    Console.ForegroundColor = ConsoleColor.DarkRed

                ElseIf myArray(n, m) = 1 Then

                    Console.ForegroundColor = ConsoleColor.DarkGray

                ElseIf myArray(n, m) = 2 Then

                    Console.ForegroundColor = ConsoleColor.Blue

                ElseIf myArray(n, m) = 3 Then

                    Console.ForegroundColor = ConsoleColor.Blue

                ElseIf myArray(n, m) = 4 Then

                    Console.ForegroundColor = ConsoleColor.Blue

                ElseIf myArray(n, m) = 5 Then

                    Console.ForegroundColor = ConsoleColor.Gray

                ElseIf myArray(n, m) = 6 Then

                    Console.ForegroundColor = ConsoleColor.White

                End If


                Console.Write("[" + myArray(n, m).ToString() + "]")

                Console.ForegroundColor = ConsoleColor.White

            Next m

            Console.Write("          ")

            For m = 0 To 7

                If owns(n, m) = 0 Then

                    Console.ForegroundColor = ConsoleColor.DarkRed

                ElseIf owns(n, m) = 1 Then

                    Console.ForegroundColor = ConsoleColor.DarkGray

                ElseIf owns(n, m) = 2 Then

                    Console.ForegroundColor = ConsoleColor.White

                End If

                Console.Write("[" + myArray(n, m).ToString() + "]")

                Console.ForegroundColor = ConsoleColor.White

            Next m

            Console.WriteLine("")

        Next n


        Console.Write("------------------------   ")
        If player_turn = 2 Then
            Console.ForegroundColor = ConsoleColor.White
        Else
            Console.ForegroundColor = ConsoleColor.Black
        End If
        Console.Write("[P2]")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("   ------------------------")



        Return True

    End Function

    'EXTENSION: MAKE CHESSBOARD WORK
    Function checkMove(piece, from_x, from_y, to_x, to_y, pawns, myArray, player_turn) As Boolean
        '[0] No Piece   [1] Pawn   [2] Castle   [3] Knight   [4] Bishop   [5] Queen   [6] King

        Console.Write(checkJumping(from_x, from_y, to_x, to_y, myArray))
        Console.ReadKey()

        Select Case piece
            Case 0
                Return False
            Case 1
                If Not to_x = from_x Then
                    Return False
                End If
                If player_turn = 1 Then

                    If pawns(from_x, from_y) = 1 Then
                        If to_y - from_y > 0 And to_y - from_y < 3 Then
                            Return True
                        End If
                    Else
                        If to_y - from_y > 0 And to_y - from_y < 2 Then
                            Return True
                        End If
                    End If

                ElseIf player_turn = 2 Then

                    Return True

                End If
                Return False
            Case 2
                Return True
            Case 3
                Return True
            Case 4
                Return True
            Case 5
                Return True
            Case 6
                Return True
        End Select
        Return False
    End Function
    Function checkJumping(from_x, from_y, to_x, to_y, myArray) As Boolean
        'Bresenham's Line Algorithm
        Return Bresenham(from_x, from_y, to_x, to_y, New PlotFunction(AddressOf plot), myArray)
    End Function

    Function plot(ByVal x As Long, ByVal y As Long, myArray As Array, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer) As Boolean
        Console.Write(x.ToString() + " " + y.ToString())
        If (x + 1 = x1 And y - 1 = y1) Then
            'first value
            Console.WriteLine("  -  FIRST")
            Return False
        End If
        If (x + 3 = x2 And y - 3 = y2) Then
            'last value
            Console.WriteLine("  -  LAST")
            Return False
        End If
        Console.WriteLine()
        If Not myArray(x, y) = 0 Then
            Return False
        End If
        Return True
    End Function

    '|==========================================================================================================|
    '|    https://jacemorley.wordpress.com/2010/11/18/generic-bresenhams-line-algorithm-in-visual-basic-net/    |
    '|==========================================================================================================|

    Sub Swap(ByRef X As Long, ByRef Y As Long)
        Dim t As Long = X
        X = Y
        Y = t
    End Sub

    ' If the plot function returns true, the bresenham's line algorithm continues.
    ' if the plot function returns false, the algorithm stops
    Delegate Function PlotFunction(ByVal x As Long, ByVal y As Long, myArray As Array, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer) As Boolean

    Function Bresenham(ByVal x1 As Long, ByVal y1 As Long, ByVal x2 As Long, ByVal y2 As Long, ByVal plot As PlotFunction, myArray As Array)
        Dim steep As Boolean = (Math.Abs(y2 - y1) > Math.Abs(x2 - x1))
        If (steep) Then
            Swap(x1, y1)
            Swap(x2, y2)
        End If

        If (x1 > x2) Then
            Swap(x1, x2)
            Swap(y1, y2)
        End If

        Dim deltaX As Long = x2 - x1
        Dim deltaY As Long = y2 - y1
        Dim err As Long = deltaX / 2
        Dim ystep As Long
        Dim y As Long = y1

        If (y1 < y2) Then
            ystep = 1
        Else
            ystep = -1
        End If

        For x As Long = x1 To x2
            Dim result As Boolean
            If (steep) Then result = plot(y, x, myArray, x1, y1, x2, y2) Else result = plot(x, y, myArray, x1, y1, x2, y2)
            If (result) Then Return True
            err = err - deltaY
            If (err < 0) Then
                y = y + ystep
                err = err + deltaX
            End If
        Next
        Return False
    End Function

End Module
