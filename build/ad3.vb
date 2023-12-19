Imports System.Data.SqlClient

Public Class ad3

    Dim pkvar
    Sub disRecords()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("select devname as 'Name',domain as 'Domain',phoneno as 'Phone No',dob as 'DOB',email as 'Email',password as 'Password',sec as 'Security Question',ans as 'Answer'  From reg order by devname", Conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If Conn.State = ConnectionState.Open Then Conn.Close()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

        pkvar = DataGridView1.CurrentRow.Cells(0).Value
        If IsDBNull(pkvar) Then
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim Cmd0 As New SqlCommand("Select * from reg where devname='" & pkvar & "'", Conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()
            TextBox1.Text = D1(0).ToString
            ComboBox1.Text = D1(1).ToString
            TextBox3.Text = D1(2).ToString
            DateTimePicker1.Text = D1(3).ToString
            TextBox5.Text = D1(4).ToString
            TextBox6.Text = D1(5).ToString
            ComboBox2.Text = D1(6).ToString
            TextBox7.Text = D1(7).ToString
        Else
            TextBox1.Text = ""
            ComboBox1.Text = ""
            TextBox3.Text = ""
            ComboBox2.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
        End If
    End Sub

    Private Sub ad3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disRecords()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim q1var, q2var As String
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        q1var = "insert into reg(devname,domain,phoneno,dob,email,password,sec,ans)"
        q2var = "values('" & TextBox1.Text & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & DateTimePicker1.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & ComboBox2.Text & "','" & TextBox7.Text & "')"
        MsgBox(q1var & q2var)
        Dim cmd1 As New SqlCommand(q1var & q2var, Conn)
        cmd1.ExecuteNonQuery()
        MsgBox("Data saved successfully")
        If Conn.State = ConnectionState.Open Then Conn.Close()
        disRecords()
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand("update reg set devname = '" & TextBox1.Text & "' ,domain = '" & ComboBox1.Text & "',phoneno = '" & TextBox3.Text & "',dob = '" & DateTimePicker1.Text & "',email = '" & TextBox5.Text & "',password = '" & TextBox6.Text & "',sec = '" & ComboBox2.Text & "',ans = '" & TextBox7.Text & "' where devname = '" & pkvar & "'", Conn)
        cmd.ExecuteNonQuery()
        MsgBox(“Data modified successfully”)
        disRecords()
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand("delete from reg where devname='" & pkvar & "'", Conn)
        cmd.ExecuteNonQuery()
        MsgBox(pkvar & " deleted successfully ")
        disRecords()
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        admin.Show()
    End Sub
End Class