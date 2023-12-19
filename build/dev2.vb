Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class dev2
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        dev.Show()
    End Sub

    Private Sub dev2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        displayrecords()
    End Sub
    Dim pkvar
    Private Sub DataGridView1_CellMouselick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        pkvar = DataGridView1.CurrentRow.Cells(1).Value
        If IsDBNull(pkvar) Then
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim Cmd0 As New SqlCommand("Select * from devs ", Conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()
        Else
        End If
        displayrecords()
    End Sub

    Sub displayrecords()
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
        Dim ds As New DataSet
        Dim adp As New SqlDataAdapter("select * from devs where developer ='" & name & "'", Conn)
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        If Conn.State = ConnectionState.Open Then Conn.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        dev.Show()
    End Sub
End Class