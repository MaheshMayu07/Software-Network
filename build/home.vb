Imports snp.My.Resources

Public Class home

    Dim count As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        count = count + 1
        If count > 13 Then count = 1

        Select Case count
            Case 1

                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s1.png")
            Case 2

                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s7.png")
            Case 3

                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s3.png")
            Case 4

                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s4.png")
            Case 5
                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s5.jpeg")
            Case 6

                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s6.jpg")
            Case 7

                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s7.png")
            Case 8

                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s8.png")
            Case 9

                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s6.jpg")
            Case 10

                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s10.jpg")
            Case 11

                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s11.png")
            Case 12

                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s12.png")
            Case 13

                PictureBox2.Image = Image.FromFile("D:\photos\Pic\s13.jpeg")

        End Select
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Hide()
        Me.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Hide()
        abstract.Show()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Hide()
        contact.Show()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        If MessageBox.Show("Are You Sure You Want To Quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            End
        Else
            Me.Show()
        End If
    End Sub

    Dim cou As Integer

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        cou = cou + 1
        If cou > 5 Then cou = 1
        Select Case count
            Case 1
                Label3.Text = "Project Intitation"
                Label4.Text = "It the first step in starting a new project. During the project initiation phase, you establish why you’re doing the project and what business value it will delivered."

            Case 2
                Label3.Text = "Quality control"
                Label4.Text = "QC is a procedure or set of procedures intended to ensure that a manufactured product or performed service adheres to a defined set of quality criteria or meets the requirements of the client or customer."

            Case 3
                Label3.Text = "Project Planning"
                Label4.Text = "The project planning phase of project management is where a project manager builds the project roadmap, including the project plan, project scope, project schedule, project constraints, work breakdown structure, and risk analysis."

            Case 4
                Label3.Text = "Performance Testing"
                Label4.Text = "Performance Testing is usually the last resort to catch application defects. It is labor intensive and usually only catches coding defects."

            Case 5
                Label3.Text = "Project Execution"
                Label4.Text = "The project execution phase is often the longest and most complex stage in the project life cycle. If you’re not careful, your team might get off track, run into communication problems,or stop following your carefully outlined procedures."
            Case 6
                Label3.Text = "Configuration"
                Label4.Text = "Configuration management involves knowing the state of all artifacts that make up your system or project, managing the state of those artifacts, and releasing distinct versions of a system."
            Case 7
                Label3.Text = "Project Perforamnace"
                Label4.Text = "It is an ongoing review of the efficiency and importance of a given project. This important concept is used throughout the business and professional world as a means of understanding and improving company, department, and personnel performance."
            Case 8
                Label3.Text = "Project Closure"
                Label4.Text = "Project closure is the critical last phase in the project management lifecycle. During project closure, the team reviews the deliverables, then compares and tests its quality to the intended project outcome. Then they share the deliverables with the project's client.
"
                '   Timer1.Enabled = False
        End Select
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Me.Hide()
        register.Show()
    End Sub

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        Timer1.Enabled = False
        Timer2.Enabled = False

    End Sub

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub PictureBox2_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox2.MouseEnter
        Timer1.Enabled = False
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        Timer1.Enabled = True
    End Sub
End Class


