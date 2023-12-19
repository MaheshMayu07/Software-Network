Imports System.Data.SqlClient

Public Class forgotm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand("select * from manlog where userid='" & TextBox1.Text & "'", Conn)
        Dim ex As SqlDataReader = cmd.ExecuteReader()
        If ex.HasRows Then
            Panel2.Show()
        Else
            MsgBox("INVALID LOGIN")
        End If
    End Sub

    Private Sub forgotm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Hide()
    End Sub
    Dim pkvar, ps As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        pkvar = "select password from manlog where userid='" & TextBox1.Text & "'"
        Dim cmd As New SqlCommand("select * from manlog where sec='" & ComboBox1.SelectedItem & "'and ans='" & TextBox2.Text & "'", Conn)
        Dim ex As SqlDataReader = cmd.ExecuteReader()
        If ex.HasRows Then
            ex.Read()
            ps = ex(2).ToString
            MsgBox("Your Password is " & ps)

        Else
            MsgBox("INVALID QUESTION OR ANSWER")
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        manlog.Show()
    End Sub
End Class