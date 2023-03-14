Public Class Form1
    Dim total, before, after As Double
    Dim op As String
    Dim sop, newthing As Boolean

    ' equal functions
    Sub equal_s(ops)
        If ops = "+" Then
            total = before + after
        ElseIf ops = "-" Then
            total = before - after
        ElseIf ops = "x" Then
            total = before * after
        ElseIf ops = "÷" Then
            total = before / after
        Else
            total = CDbl(display.Text)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ' number input, more efficient to have one sub
    Private Sub number_Input(sender As Object, e As EventArgs) Handles zero.Click, one.Click, two.Click, three.Click, four.Click, five.Click, six.Click, seven.Click, eight.Click, nine.Click
        If display.Text = "0" Or newthing Then
            display.Text = sender.Text
            newthing = False
        Else
            display.Text += sender.Text
        End If
    End Sub

    ' decimal points
    Private Sub dec_Click(sender As Object, e As EventArgs) Handles dec.Click
        If Not display.Text.Contains(".") Then
            display.Text += "."
        End If
    End Sub

    ' operations
    Private Sub operator_Click(sender As Object, e As EventArgs) Handles plus.Click, minus.Click, multiply.Click, divide.Click
        If sop Then
            after = CDbl(display.Text)
            equal_s(op)
            op = sender.Text
            before = total
            mem.Text = CStr(total) + " " + op
        ElseIf Not sop Then
            op = sender.Text
            mem.Text = display.Text + " " + op
            before = CDbl(display.Text)
            mem.Text = display.Text + " " + op
            sop = True
        End If
        display.Text = ""
    End Sub

    ' equals
    Private Sub eq_Click(sender As Object, e As EventArgs) Handles eq.Click
        If Not display.Text = "" Then
            after = CDbl(display.Text)
            equal_s(op)
        End If
        op = ""
        mem.Text = CStr(total) + " ="
        display.Text = CStr(total)
        after = 0
        before = 0
        total = 0
        sop = False
        newthing = True
    End Sub

    ' clear and delete
    Private Sub clear_Click(sender As Object, e As EventArgs) Handles clear.Click, delete.Click
        If sender.Text = "AC" Then
            op = ""
            mem.Text = "AC"
            display.Text = "0"
            after = 0
            before = 0
            total = 0
            sop = False
            newthing = False
        ElseIf sender.Text = "DEL" Then
            display.Text = display.Text.Substring(0, display.Text.Length - 1)
            If display.Text = "" Then
                display.Text = "0"
            End If
            mem.Text = "DEL"
        End If
    End Sub

    ' pi easter egg!
    Private Sub pi_Click(sender As Object, e As EventArgs) Handles pi.Click
        EasterEgg.Show()
    End Sub
End Class
