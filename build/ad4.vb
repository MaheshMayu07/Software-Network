Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class ad4

    Dim temp

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand("delete from con where namef='" & temp & "'", Conn)
        cmd.ExecuteNonQuery()
        MsgBox(" Verified successfully ")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        RichTextBox1.Text = ""
        disRecords()
    End Sub



    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        temp = DataGridView1.CurrentRow.Cells(0).Value
        If IsDBNull(temp) Then
            Exit Sub
        End If
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand("select * from con where namef='" & temp & "'", Conn)
        Dim ex As SqlDataReader = cmd.ExecuteReader()
        If ex.HasRows Then
            ex.Read()
            TextBox1.Text = ex(0).ToString
            TextBox5.Text = ex(1).ToString
            TextBox2.Text = ex(2).ToString
            TextBox3.Text = ex(3).ToString
            RichTextBox1.Text = ex(4).ToString
        Else

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox5.Text = ""
            RichTextBox1.Text = ""
            disRecords()
        End If
    End Sub
    Sub disRecords()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("select namef as 'First Name',namel as 'Last Name',email as 'E-mail',subject as 'Subject',message as 'Message' From con order by namef", Conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If Conn.State = ConnectionState.Open Then Conn.Close()
    End Sub

    Private Sub ad4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disRecords()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        disRecords()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        admin.Show()
    End Sub
End Class