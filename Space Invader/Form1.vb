Public Class Form1
#Region "variaveis"

    Dim aliens(11) As PictureBox
    Dim direction As Integer = -1
    Dim velocidade As Integer = 3
    Dim qualalien, ganhou, dificuldade As Integer
    Dim bala, bala1, bala2, bala3, bala4, bala5 As Boolean
    Dim direita, esquerda As Boolean
    Dim locations(11) As System.Drawing.Point
    Dim Level As Integer = 1
    Dim Score As Integer = 0
    Dim balas As Integer = 50


#End Region

#Region "butões"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Hide()
        PictureBox8.Hide()
        PictureBox2.Hide()
        Button1.Hide()
        Button2.Hide()
        Timer1.Start()
        Panel1.Show()
        Button4.Hide()
        Button6.Hide()
        Label5.Hide()
        Button7.Hide()
        Button5.Hide()
        My.Computer.Audio.Play("spear of justice.wav", AudioPlayMode.Background)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Application.Restart()
    End Sub
#End Region

#Region "quit"
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim resp As Integer
        resp = MsgBox("are you sure you want to quit?", 52)
        If resp = 7 Then
            MsgBox("let's continue")
        Else
            Close()
        End If
    End Sub
#End Region

#Region "movement code"
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.D Then
            direita = True

        End If
        If e.KeyValue = Keys.A Then
            esquerda = True

        End If
        If e.KeyValue = Keys.K Then
            bala = True
        End If
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyValue = Keys.D Then
            direita = False
        End If
        If e.KeyValue = Keys.A Then
            esquerda = False
        End If
        If e.KeyValue = Keys.K Then
            bala = False
        End If
    End Sub
#End Region
    

#Region "aliens"

    Public Sub New()
        InitializeComponent()
        creatarray()
    End Sub

    Private Sub creatarray()
        aliens(0) = alien1
        aliens(1) = alien2
        aliens(2) = alien3
        aliens(3) = alien4
        aliens(4) = alien5
        aliens(5) = alien6
        aliens(6) = alien7
        aliens(7) = alien8
        aliens(8) = alien9
        aliens(9) = alien10
        aliens(10) = alien11
        aliens(11) = alien12
        For i = 0 To 11
            locations(i) = aliens(i).Location 
        Next
    End Sub
    Private Sub movealiens()
        For i = 0 To 11
            aliens(i).Left = aliens(i).Left + velocidade
            If aliens(i).Bounds.IntersectsWith(nave.Bounds) Then
                jogador_perdeu()
            End If
        Next
        If alien6.Left > (Me.Width - alien6.Width) Then
            velocidade = velocidade * -1
            For i = 0 To 11
                aliens(i).Top = aliens(i).Top + 50
            Next
        End If
        If alien1.Left < 0 Then
            velocidade = velocidade * -1
            For i = 0 To 11
                aliens(i).Top = aliens(i).Top + 50
            Next
        End If
    End Sub
    Private Sub checkshot()
        bala = False
        If bala1 = False Then
            bala1 = True
            shot1.Show()
            Exit Sub
        End If
        If bala2 = False Then
            bala2 = True
            shot2.Show()
            Exit Sub
        End If
        If bala3 = False Then
            bala3 = True
            shot3.Show()
            Exit Sub
        End If
        If bala4 = False Then
            bala4 = True
            shot4.Show()
            Exit Sub
        End If
        If bala5 = False Then
            bala5 = True
            shot5.Show()
            Exit Sub
        End If
    End Sub
    Private Sub moveshot()
        
        If bala1 = True Then
            shot1.Top = shot1.Top - 5
            For i = 0 To 11
                If shot1.Bounds.IntersectsWith(aliens(i).Bounds) Then
                    qualalien = i
                    shot1hit()
                End If
            Next
            If shot1.Top < 0 Then
                shot1.Hide()
                bala1 = False
                shot1.Location = restartshot.Location
            End If
        End If
        If bala2 = True Then
            shot2.Top = shot2.Top - 5
            For i = 0 To 11
                If shot2.Bounds.IntersectsWith(aliens(i).Bounds) Then
                    qualalien = i
                    shot2hit()
                End If
            Next
            If shot2.Top < 0 Then
                shot2.Hide()
                bala2 = False
                shot2.Location = restartshot.Location
            End If
        End If
        If bala3 = True Then
            shot3.Top = shot3.Top - 5
            For i = 0 To 11
                If shot3.Bounds.IntersectsWith(aliens(i).Bounds) Then
                    qualalien = i
                    shot3hit()
                End If
            Next
            If shot3.Top < 0 Then
                shot3.Hide()
                bala3 = False
                shot3.Location = restartshot.Location
            End If
        End If
        If bala4 = True Then
            shot4.Top = shot4.Top - 5
            For i = 0 To 11
                If shot4.Bounds.IntersectsWith(aliens(i).Bounds) Then
                    qualalien = i
                    shot4hit()
                End If
            Next
            If shot4.Top < 0 Then
                shot4.Hide()
                bala4 = False
                shot4.Location = restartshot.Location
            End If
        End If
        If bala5 = True Then
            shot5.Top = shot5.Top - 5
            For i = 0 To 11
                If shot5.Bounds.IntersectsWith(aliens(i).Bounds) Then
                    qualalien = i
                    shot5hit()
                End If
            Next
            If shot5.Top < 0 Then
                shot5.Hide()
                bala5 = False
                shot5.Location = restartshot.Location
            End If
        End If

    End Sub
    Private Sub shot1hit()
        bala1 = False
        shot1.Hide()
        shot1.Location = restartshot.Location
        aliens(qualalien).Top = aliens(qualalien).Top + 1000
        ganhou = ganhou + 1
        If ganhou = 12 Then
            ganhou_mesmo()

        End If
        Score = Score + 1
        Label4.Text = "Score: " & Score
    End Sub
    Private Sub shot2hit()
        bala2 = False
        shot2.Hide()
        shot2.Location = restartshot.Location
        aliens(qualalien).Top = aliens(qualalien).Top + 1000
        ganhou = ganhou + 1
        If ganhou = 12 Then
            ganhou_mesmo()

        End If
        Score = Score + 1
        Label4.Text = "Score: " & Score
    End Sub
    Private Sub shot3hit()
        bala3 = False
        shot3.Hide()
        shot3.Location = restartshot.Location
        aliens(qualalien).Top = aliens(qualalien).Top + 1000
        ganhou = ganhou + 1
        If ganhou = 12 Then
            ganhou_mesmo()

        End If
        Score = Score + 1
        Label4.Text = "Score: " & Score
    End Sub
    Private Sub shot4hit()
        bala4 = False
        shot4.Hide()
        shot4.Location = restartshot.Location
        aliens(qualalien).Top = aliens(qualalien).Top + 1000
        ganhou = ganhou + 1
        If ganhou = 12 Then
            ganhou_mesmo()

        End If
        Score = Score + 1
        Label4.Text = "Score: " & Score
    End Sub
    Private Sub shot5hit()
        bala5 = False
        shot5.Hide()
        shot5.Location = restartshot.Location
        aliens(qualalien).Top = aliens(qualalien).Top + 1000
        ganhou = ganhou + 1
        If ganhou = 12 Then
            ganhou_mesmo()

        End If
        Score = Score + 1
        Label4.Text = "Score: " & Score
    End Sub
    Private Sub jogador_perdeu()
        Timer1.Stop()
        nave.Image = My.Resources._370776acb20eed7
        Label2.Show()
        Button6.Show()
        My.Computer.Audio.Play("game over song.wav", AudioPlayMode.Background)
    End Sub
#End Region
#Region "Timers"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If nave.Left > 775 Then
            direita = False
        End If
        If nave.Left < 0 Then
            esquerda = False
        End If
        move_nave()
        movealiens()
        If bala = True Then
            checkshot()
        End If
        moveshot()
        For i = 0 To 11
            If aliens(i).Bounds.IntersectsWith(Label6.Bounds) Then
                jogador_perdeu()
            End If
        Next
    End Sub
#End Region
    Private Sub Form1_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Button5.Show()
        My.Computer.Audio.Play("hotel.wav", AudioPlayMode.BackgroundLoop)
    End Sub


    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim resp As Integer
        resp = MsgBox("are you sure you want to quit?", 52)
        If resp = 7 Then
            MsgBox("let's continue")
        Else
            Close()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Application.Restart()

    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Panel1.Hide()
        Label1.Show()
        PictureBox8.Show()
        PictureBox2.Show()
        Button1.Show()
        Button2.Show()
        Button4.Show()
        Timer1.Stop()
        Button7.Show()
        Button5.Show()
    End Sub
    Private Sub ganhou_mesmo()
        ganhou = 0
        Level = Level + 1
        Label3.Text = "LEVEL" & Level

        For i = 0 To 11
            aliens(i).Location = locations(i)
        Next

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form2.Show()
    End Sub
#Region "mover a nave"
    Private Sub move_nave()
        If direita = True Then
            nave.Left = nave.Left + 3
            restartshot.Left = restartshot.Left + 3

            If bala1 = False Then
                shot1.Left = shot1.Left + 3
            End If
            If bala2 = False Then
                shot2.Left = shot2.Left + 3
            End If
            If bala3 = False Then
                shot3.Left = shot3.Left + 3
            End If
            If bala4 = False Then
                shot4.Left = shot4.Left + 3
            End If
            If bala5 = False Then
                shot5.Left = shot5.Left + 3
            End If
        End If
        If esquerda = True Then
            nave.Left = nave.Left - 3
            restartshot.Left = restartshot.Left - 3

            If bala1 = False Then
                shot1.Left = shot1.Left - 3
            End If
            If bala2 = False Then
                shot2.Left = shot2.Left - 3
            End If
            If bala3 = False Then
                shot3.Left = shot3.Left - 3
            End If
            If bala4 = False Then
                shot4.Left = shot4.Left - 3
            End If
            If bala5 = False Then
                shot5.Left = shot5.Left - 3
            End If
        End If
    End Sub
#End Region



    

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Application.Restart()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Application.Restart()
    End Sub

    
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        dificuldade = Val(InputBox("game difficulty 1-easy 2- medium 3-hard"))
        Select Case dificuldade
            Case 1
                Label5.Text = "Current Difficulty: Easy"
                velocidade = 5
            Case 2
                Label5.Text = "Current Difficulty: Medium"
                velocidade = 7
            Case 3
                Label5.Text = "Current Difficulty: Hard"
                velocidade = 11
            Case Else
                MsgBox("Invalid, try using 1,2 or 3 :)")
        End Select
    End Sub
End Class
