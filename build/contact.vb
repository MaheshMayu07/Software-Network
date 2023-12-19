Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class contact


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text.Contains("@") And TextBox2.Text.Contains(".") Then
            Dim q1var, q2var
            If TextBox1.Text = "" Then
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                RichTextBox1.Text = ""
                MsgBox("Please Enter The Necessary Details")
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        q1var = "insert into con(namef,namel,email,subject,message)"
        q2var = "values('" & TextBox1.Text & "','" & TextBox4.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & RichTextBox1.Text & "')"
        Dim cmd1 As New SqlCommand(q1var & q2var, Conn)
        cmd1.ExecuteNonQuery()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        MsgBox("Your Feedback is Successfully Submitted Thank You!!")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
            RichTextBox1.Text = ""
        Else
            MsgBox("enter a vaild email")
        End If

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        home.Show()
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
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

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedchars As String = "abcdefghijklmnopqrstuvwxyz"
            If Not allowedchars.Contains(e.KeyChar.ToString.ToLower) Then
                MessageBox.Show("Please enter a character")
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedchars As String = "abcdefghijklmnopqrstuvwxyz"
            If Not allowedchars.Contains(e.KeyChar.ToString.ToLower) Then
                MessageBox.Show("Please enter a character")
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub contact_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class