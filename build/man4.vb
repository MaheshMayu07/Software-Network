Imports System.Data.SqlClient

Public Class man4
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintPreviewDialog1.Show()
        'MsgBox("Your Reports are Downloaded")
    End Sub


    Dim temp As String

    Sub disRecords()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim DS1 As New DataSet
        Dim adp As New SqlDataAdapter("select proid as 'Project Id',intro as 'Introduction',ove as 'Overall Description',sfea as 'System Features',req as 'Requirements',nreq as 'Non Requirements' From projc order by proid", Conn)
        adp.Fill(DS1)
        DataGridView1.DataSource = DS1.Tables(0)
        If Conn.State = ConnectionState.Open Then Conn.Close()
    End Sub

    Private Sub man4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disRecords()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        temp = DataGridView1.CurrentRow.Cells(0).Value

        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand("select * from projc where proid='" & temp & "'", Conn)
        Dim ex As SqlDataReader = cmd.ExecuteReader()
        If ex.HasRows Then
            ex.Read()
            TextBox1.Text = ex(0).ToString
            TextBox2.Text = ex(1).ToString
            RichTextBox1.Text = ex(2).ToString
            RichTextBox2.Text = ex(3).ToString
            RichTextBox3.Text = ex(4).ToString
            RichTextBox4.Text = ex(5).ToString
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        man.Show()

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim XPos, YPos As Long
        YPos = 50
        Dim MyFont As New Font("Arial", 18)
        XPos = 10
        e.Graphics.DrawString("SOFTWARE NETWORK", MyFont, Brushes.Black, XPos, YPos)
        YPos += 100
        XPos = 10
        e.Graphics.DrawString("PROJECT REPORT", MyFont, Brushes.Black, XPos, YPos)
        YPos += 50
        XPos = 10
        MyFont = New Font("Arial", 12)
        e.Graphics.DrawString("Project ID", MyFont, Brushes.Black, XPos, YPos)
        XPos = XPos + 50





        YPos += 25
        For Each r As DataGridViewRow In DataGridView1.Rows
            XPos = 10
            e.Graphics.DrawString(r.Cells(0).Value, MyFont, Brushes.Black, XPos, YPos)
            YPos = YPos + 50
            e.Graphics.DrawString((r.Cells(1).Value), MyFont, Brushes.Black, XPos, YPos)
            YPos = YPos + 70
            e.Graphics.DrawString(r.Cells(2).Value, MyFont, Brushes.Black, XPos, YPos)
            YPos = YPos + 100
            e.Graphics.DrawString(r.Cells(3).Value, MyFont, Brushes.Black, XPos, YPos)
            YPos = YPos + 200
            e.Graphics.DrawString(r.Cells(4).Value, MyFont, Brushes.Black, XPos, YPos)
            YPos = YPos + 220
            e.Graphics.DrawString(r.Cells(5).Value, MyFont, Brushes.Black, XPos, YPos)
            YPos = YPos + 250

            YPos += 25
        Next

    End Sub
End Class