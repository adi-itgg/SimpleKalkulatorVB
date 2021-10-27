Public Class Form1




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each control As Control In Controls
            Dim b As Button = TryCast(control, Button)
            If b Is Nothing Then Continue For
            AddHandler b.Click, AddressOf btnClick
        Next
    End Sub


    Sub btnClick(sender As Object, e As EventArgs)
        Dim b As Button = CType(sender, Button)
        Dim btxt As String = b.Text
        With TextBox1
            If btxt.Length = 2 Then
                .Clear()
                Return
            End If

            If btxt = "=" Then
                Dim hasil As Integer = 0
                Dim tempOp As String = String.Empty
                For Each val As String In Split(.Text, " ")
                    If val.Length < 1 Then Continue For
                    If Not Char.IsDigit(val) Then
                        tempOp = val
                        Continue For
                    End If

                    If tempOp = String.Empty Then
                        hasil += val
                        Continue For
                    End If

                    Select Case tempOp
                        Case "+"
                            hasil += val
                        Case "-"
                            hasil -= val
                        Case "/"
                            hasil /= val
                        Case "*"
                            hasil *= val
                    End Select
                    tempOp = String.Empty
                Next
                .Text = hasil
                Return
            End If

            If btxt = "C" Then
                If .Text.Length < 1 Then Return
                .Text = .Text.Substring(0, .Text.Length - 1)
                Return
            End If

            If Not Char.IsDigit(btxt) Then .AppendText(" ")
            .AppendText(btxt)
            If Not Char.IsDigit(btxt) Then .AppendText(" ")
        End With
    End Sub
End Class
