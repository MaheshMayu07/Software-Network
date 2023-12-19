Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class dev1

    Dim pkvar As String
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Sub disRecords()
        Dim name = ""
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd2 As New SqlCommand("select * from dlog where email = '" & devuser & "'", Conn)
        Dim d1 As SqlDataReader = cmd2.ExecuteReader
        If d1.HasRows Then
            d1.Read()
            name = d1(0).ToString
        End If

        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("select id as 'Traige ID',sum as 'Summary',deso as 'Description',plat as 'Platform',pro as 'Product',imp as 'Critical',Status,developer From devs where developer = '" & name & "'", Conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If Conn.State = ConnectionState.Open Then Conn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For Each r As DataGridViewRow In DataGridView1.Rows
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()
            Dim cmd2 As New SqlCommand("Update devs set status ='" & ComboBox1.SelectedItem & "' where id='" & TextBox1.Text & "'", Conn)
            cmd2.ExecuteNonQuery()
            If Conn.State = ConnectionState.Open Then Conn.Close()

            'If r.Cells(0).Value = "" Then Exit For
            'q1var = "insert into devs(id,sum,deso,pro,plat,imp,date,Status,developer)"
            'q2var = "values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & ComboBox1.Text & "','" & r.Cells(7).Value & "')"

            'If Conn.State = ConnectionState.Open Then Conn.Close()
            'Conn.Open()
            ''MsgBox(q1Var & q2Var)
            'Dim cmd1 As New SqlCommand(q1var & q2var, Conn)
            'cmd1.ExecuteNonQuery()
            'If Conn.State = ConnectionState.Open Then Conn.Close()
            disRecords()

        Next
        MsgBox("Updated Successfully")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = "Select Status"
    End Sub

    Private Sub dev1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disRecords()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        pkvar = DataGridView1.CurrentRow.Cells(0).Value
        If IsDBNull(pkvar) Then
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim Cmd0 As New SqlCommand("Select * from devs where id='" & pkvar & "'", Conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()
            TextBox1.Text = D1(0).ToString
            TextBox2.Text = D1(1).ToString
            TextBox3.Text = D1(2).ToString
            TextBox4.Text = D1(3).ToString
            TextBox5.Text = D1(4).ToString
            TextBox6.Text = D1(5).ToString
            TextBox7.Text = D1(6).ToString

        Else
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        dev.Show()
    End Sub
End Class