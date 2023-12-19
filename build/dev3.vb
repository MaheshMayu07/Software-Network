Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class dev3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim q1var, q2var
        If RichTextBox1.Text = "" Then
            MsgBox("Please Enter The Message")
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        q1var = "insert into mesg(tlmess)"
        q2var = "values('" & RichTextBox1.Text & "')"
        Dim cmd1 As New SqlCommand(q1var & q2var, Conn)
        cmd1.ExecuteNonQuery()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        MsgBox("Message sent Successfully")
        RichTextBox1.Text = ""
    End Sub

    Private Sub dev3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = ""
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd3 As New SqlCommand("select name from tllog ", Conn)
        Dim d1 As SqlDataReader = cmd3.ExecuteReader
        If d1.HasRows Then
            While d1.Read
                ComboBox1.Items.Add(d1(0).ToString)
            End While
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        disRecords()
        Panel2.Hide()
        Panel1.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Show()
        'Panel2.Show()
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
        Dim adp As New SqlDataAdapter("select dvmess as 'Developer Message',tlmess as 'TeamLeader Message'From mesg order by dvmess", Conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If Conn.State = ConnectionState.Open Then Conn.Close()
    End Sub
    Dim pkvar As String
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        pkvar = DataGridView1.CurrentRow.Cells(0).Value
        If IsDBNull(pkvar) Then
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim Cmd0 As New SqlCommand("Select * from mesg where devmess='" & pkvar & "'", Conn)
        Dim D1 As SqlDataReader = Cmd0.ExecuteReader()
        If D1.HasRows Then
            D1.Read()
            RichTextBox2.Text = D1(1).ToString
            RichTextBox1.Text = D1(0).ToString
        Else
            RichTextBox2.Text = ""
            RichTextBox2.Text = ""
        End If
        disRecords()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand("update mesg set tlmess = '" & RichTextBox2.Text & "'where tlmess = '" & pkvar & "'", Conn)
        cmd.ExecuteNonQuery()
        MsgBox(“Message Sent successfully”)
        disRecords()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        dev.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class