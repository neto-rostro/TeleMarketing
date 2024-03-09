Public Class frmSaveBenta
    Private pbCancel As Boolean
    Private pnStatus As String

    ReadOnly Property Cancelled As Boolean
        Get
            Return pbCancel
        End Get
    End Property

    ReadOnly Property Status As Integer
        Get
            Return pnStatus
        End Get
    End Property

    Private Sub frmSaveBenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnStatus = 0
        RadioButton1.Select()
        pbCancel = True
    End Sub

    Private Sub Button00_Click(sender As Object, e As EventArgs) Handles Button00.Click
        pbCancel = True
        Me.Hide()
    End Sub

    Private Sub Button01_Click(sender As Object, e As EventArgs) Handles Button01.Click
        If RadioButton1.Checked = True Then
            pnStatus = 0
        ElseIf RadioButton2.Checked = True Then
            pnStatus = 1
        ElseIf RadioButton3.Checked = True Then
            pnStatus = 2
        End If

        pbCancel = False
        Me.Hide()
    End Sub
End Class