﻿Imports System.Data.SqlClient
Imports System.DirectoryServices.ActiveDirectory
Imports Microsoft.VisualBasic.Logging

Public Class devlog

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Contains("@") And TextBox1.Text.Contains(".") Then
        Else
            MsgBox("enter a vaild email")
        End If
        ad = TextBox1.Text
        If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()
            Dim cmd0 As New SqlCommand("select * from dlog where email='" & TextBox1.Text & "' and password='" & TextBox2.Text & "' and domain='" & ComboBox1.Text & "' ", Conn)
            Dim D1 As SqlDataReader = cmd0.ExecuteReader()
            If D1.HasRows Then
                devuser = TextBox1.Text
                MsgBox("Login Succesfull")
                dev.Show()
            Me.Hide()
            TextBox1.Text = ""
            TextBox2.Text = ""
            ComboBox1.Text = ""
            TextBox2.Text = ""

            If Conn.State = ConnectionState.Open Then Conn.Close()
            Else
                MsgBox("Username or password or domain is not corret please Check!!!")
            End If

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Hide()
        forgotd.Show()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True

        End If
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



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        login.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Me.Hide()
        register.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub devlog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class