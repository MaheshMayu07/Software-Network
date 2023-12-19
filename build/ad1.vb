Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class ad1

    Dim pkvar

    Sub disRecords()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("select name as 'NAME',userid as 'EMAIL',password as 'PASSWORD',sec as 'SECURITY QUESTION',ans as 'ANSWER' From manlog order by userid", Conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If Conn.State = ConnectionState.Open Then Conn.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand("delete from manlog where userid='" & pkvar & "'", Conn)
        cmd.ExecuteNonQuery()
        MsgBox(pkvar & " Deleted successfully ")
        disRecords()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox2.Text = ""
        disRecords()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim q1var, q2var As String
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        q1var = "insert into manlog(name,userid,password,sec,ans)"
        q2var = "values('" & TextBox3.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox2.Text & "','" & TextBox4.Text & "')"
        MsgBox(q1var & q2var)
        Dim cmd1 As New SqlCommand(q1var & q2var, Conn)
        cmd1.ExecuteNonQuery()
        MsgBox("Data saved successfully")
        If Conn.State = ConnectionState.Open Then Conn.Close()
        disRecords()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox2.Text = ""
        disRecords()
    End Sub

    Private Sub ad1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disRecords()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand("update manlog set name = '" & TextBox3.Text & "',userid = '" & TextBox1.Text & "' ,password = '" & TextBox2.Text & "',sec = '" & ComboBox2.Text & "',ans = '" & TextBox4.Text & "'where userid = '" & pkvar & "'", Conn)
        cmd.ExecuteNonQuery()
        MsgBox(“Data modified successfully”)
        disRecords()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox2.Text = ""
        disRecords()

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

        pkvar = DataGridView1.CurrentRow.Cells(1).Value
        If IsDBNull(pkvar) Then
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim Cmd0 As New SqlCommand("Select * from manlog where userid='" & pkvar & "'", Conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()
            TextBox1.Text = D1(1).ToString
            TextBox2.Text = D1(2).ToString
            TextBox3.Text = D1(0).ToString
            ComboBox2.Text = D1(3).ToString
            TextBox4.Text = D1(4).ToString
        Else
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            ComboBox2.Text = ""
            TextBox4.Text = ""
        End If
        disRecords()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        admin.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox2.Text = ""
    End Sub


End Class