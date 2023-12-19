Imports System.Buffers
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class register

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox5.Text.Contains("@") And TextBox5.Text.Contains(".") Then
            Dim q1var, q2var
            If TextBox1.Text = "" Then
                MsgBox("Please Enter The Necessary Details")
                Exit Sub
            End If
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()
            Dim cmd0 As New SqlCommand("Select devname from reg where devname='" & (TextBox1.Text) & "'", Conn)
            Dim D1 As SqlDataReader = cmd0.ExecuteReader()
            If D1.HasRows Then
                MsgBox("You have already been registered")
                If Conn.State = ConnectionState.Open Then Conn.Close()
                Exit Sub
            End If
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()
            q1var = "insert into reg(devname,domain,phoneno,dob,email,password,sec,ans)"
            q2var = "values('" & TextBox1.Text & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & DateTimePicker1.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & ComboBox2.Text & "','" & TextBox2.Text & "')"

            Dim cmd1 As New SqlCommand(q1var & q2var, Conn)
            cmd1.ExecuteNonQuery()
            If Conn.State = ConnectionState.Open Then Conn.Close()
            MsgBox("Registered Successfully. Your Account Will Be Activated Within 24 Hrs")
            TextBox1.Text = ""
            TextBox3.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox2.Text = ""
            DateTimePicker1.Text = ""
            ComboBox1.Text = ""
            ComboBox2.Text = ""
        Else
            MsgBox("enter a vaild email")
        End If

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedchars As String = "1234567890"
            If Not allowedchars.Contains(e.KeyChar.ToString) Then
                MessageBox.Show("Please enter a number")
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub
    Dim LL, II, PP As Integer
    Dim TXT As String
    Private Sub register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TXT = "REGISTER"
        LL = Len(TXT)
        II = 1
        PP = 1
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        home.Show()
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox2.Text = ""
        DateTimePicker1.Text = ""

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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Label1.Text + Mid(TXT, II, 1)
        If II > LL Then
            II = 0
            Label1.Text = ""
        End If
        II = II + 1
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker1.Visible = True
        DateTimePicker1.CustomFormat = ""
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
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

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Me.Hide()
        login.Show()
    End Sub
End Class