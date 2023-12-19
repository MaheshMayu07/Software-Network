Imports System.Data.SqlClient

Public Class tlee2
    Dim temp As String
    Private Sub tlee2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disRecords()

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        temp = DataGridView1.CurrentRow.Cells(0).Value
        If IsDBNull(temp) Then
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand("select * from anb where id='" & temp & "'", Conn)
        Dim ex As SqlDataReader = cmd.ExecuteReader()
        If ex.HasRows Then
            ex.Read()
            TextBox1.Text = ex(0).ToString
            TextBox2.Text = ex(1).ToString
            RichTextBox1.Text = ex(2).ToString
            TextBox4.Text = ex(3).ToString
            TextBox6.Text = ex(5).ToString
            TextBox7.Text = ex(6).ToString
            TextBox5.Text = ex(3).ToString
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        disRecords()
    End Sub
    Sub disRecords()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("select id as 'Traige Id',sum as 'Summary',pro as 'Product',plat as 'Platform',imp as 'Importance',deso as 'Description',date as 'Important Date' from anb order by id", Conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If Conn.State = ConnectionState.Open Then Conn.Close()
        ' disRecords()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '  disRecords()
        Dim q1var, q2var
        If TextBox1.Text = "" Then
            MsgBox("Please Enter The Necessary Details")
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd0 As New SqlCommand("Select id from devs where id='" & (TextBox1.Text) & "'", Conn)
        Dim D1 As SqlDataReader = cmd0.ExecuteReader()
        If D1.HasRows Then
            MsgBox("This Bug Is Already Assigned")
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        q1var = "insert into devs(id,sum,deso,pro,plat,imp,date,developer)"
        q2var = "values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & RichTextBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & ComboBox1.Text & "')"
        Dim cmd1 As New SqlCommand(q1var & q2var, Conn)
        cmd1.ExecuteNonQuery()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        MsgBox("Assigned Successfully")
        TextBox1.Text = ""
        TextBox2.Text = ""
        RichTextBox1.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = "Select Developer"
        disRecords()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        ComboBox1.Items.Clear()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd3 As New SqlCommand("select UserId from dlog where Domain='" & TextBox5.Text & "'", Conn)
        Dim d1 As SqlDataReader = cmd3.ExecuteReader
        If d1.HasRows Then
            While d1.Read
                ComboBox1.Items.Add(d1(0).ToString)
            End While
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        disRecords()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        tle.Show()
    End Sub
End Class