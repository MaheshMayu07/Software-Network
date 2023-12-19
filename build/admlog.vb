Imports System.Data.SqlClient

Public Class admlog
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Contains("@") And TextBox1.Text.Contains(".") Then
        Else
            MsgBox("Enter a vaild email")
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()
            Dim cmd0 As New SqlCommand("select * from admin where admin='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'", Conn)
            Dim D1 As SqlDataReader = cmd0.ExecuteReader()
        If D1.HasRows Then
            MsgBox("Login Succesfull")
            admin.Show()
            Me.Hide()
            TextBox1.Text = ""
            TextBox2.Text = ""
            If Conn.State = ConnectionState.Open Then Conn.Close()
        Else
            MsgBox("Username or Password is not corret please Check!!!")
        End If

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedchars As String = "abcdefghijklmnopqrstuvwxyz"
            Dim allowednos As String = "1234567890"
            Dim allowedsymbols As String = "@."
            If Not allowedchars.Contains(e.KeyChar.ToString.ToLower) And allowednos.Contains(e.KeyChar.ToString) And allowedsymbols.Contains(e.KeyChar.ToString) Then
                MessageBox.Show("Please enter a vaild email")
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub admlog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class