Public Class abstract



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        home.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Label2.Text = "Software companies spend over 45 percent of cost in dealing with software Errors. An inevitable step of fixing errors is error triage, which aims to correctly assign a developer to a new bug.To decrease the time cost in manual work,text classification techniques are applied to conduct automatic error triage.In this paper, we address the problem of data reduction for error triage, i.e., how to reduce the scale and improve the quality of error data. We combine instance selection with feature selection to simultaneously reduce data scale on the problem dimension and the word dimension.The results show that our data reduction can effectively reduce the data scale and improve the accuracy of error triage. Our work provides an approach to leveraging techniques on data processing to form reduced and high-quality data in software development and maintenance."
    End Sub
End Class