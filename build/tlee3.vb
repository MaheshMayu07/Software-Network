Imports System.Data.SqlClient

Public Class tlee3
    Public Sub FilterData(ByVal valueToSearch As String)
        Dim searchQuery As String = "select * From devs WHERE developer like '%" & valueToSearch & "%'"
        Dim command As New SqlCommand(searchQuery, Conn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FilterData(TextBox1.Text)
    End Sub
    Dim temp As String
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        temp = DataGridView1.CurrentRow.Cells(0).Value
        If IsDBNull(temp) Then
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand("select * from devs where id='" & temp & "'", Conn)
        Dim ex As SqlDataReader = cmd.ExecuteReader()
    End Sub
    Sub disRecords()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("select id as 'Traige Id',sum as 'Summary',plat as 'Platform',imp as 'Importance',date as 'Date',Status,developer From devs order by id", Conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If Conn.State = ConnectionState.Open Then Conn.Close()

    End Sub

    Private Sub tlee3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disRecords()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        tle.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        FilterData(TextBox1.Text)
    End Sub
End Class