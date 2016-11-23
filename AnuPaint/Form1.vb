Public Class mainFrm
    Private clickstodraw As Boolean
    Private FirstLocs, SencondLocs As Point
    Private iMouseOnPanel As Point
    Private ShowBetaGrp, DrawTekst As Boolean
    Private xBmp As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
    Private xPreview As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
    Private ccolor As Color = Color.White
    Private grootte As Integer = 50
    Private stekst As String
    Private sfont As Font
    Private countLines As Integer = 0
    Dim SwatchColor As Color

    Private Sub mainPanel_Click(sender As Object, e As System.EventArgs) Handles mainPanel.Click


    End Sub

    Private Sub mainPanel_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles mainPanel.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ShowBetaGrp = True
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            ShowBetaGrp = False

        End If

    End Sub
    Private Sub mainPanel_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles mainPanel.MouseMove

        iMouseOnPanel = e.Location
        Dim gr As Graphics = Graphics.FromImage(xBmp)
        gr.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        gr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim grnow As Graphics = mainPanel.CreateGraphics
        grnow.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        grnow.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        If ShowBetaGrp = True Then
            Select Case ComboBox2.Text
                Case "Standard"
                    gr.DrawLine(New Pen(ccolor), FirstLocs.X, FirstLocs.Y, e.X, e.Y)
                    grnow.DrawLine(New Pen(ccolor, 1), FirstLocs.X, FirstLocs.Y, e.X, e.Y)
                Case "Horizontal"
                    gr.DrawLine(New Pen(ccolor), e.X, e.Y, e.X + grootte, e.Y)
                    grnow.DrawLine(New Pen(ccolor), e.X, e.Y, e.X + grootte, e.Y)
                Case "Vertically"
                    gr.DrawLine(New Pen(ccolor), e.X, e.Y, e.X, e.Y + grootte)
                    grnow.DrawLine(New Pen(ccolor), e.X, e.Y, e.X, e.Y + grootte)
                Case "3D Space Oblique"
                    gr.DrawLine(New Pen(ccolor), e.Y, e.X, e.X, e.Y)
                    grnow.DrawLine(New Pen(ccolor), e.Y, e.X, e.X, e.Y)
                Case "3D Space Horizontally"
                    gr.DrawLine(New Pen(ccolor), mainPanel.Width - e.X, e.Y, e.X, e.Y)
                    grnow.DrawLine(New Pen(ccolor), mainPanel.Width - e.X, e.Y, e.X, e.Y)
                Case "3D Space Vertically"
                    gr.DrawLine(New Pen(ccolor), e.X, mainPanel.Height - e.Y, e.X, e.Y)
                    grnow.DrawLine(New Pen(ccolor), e.X, mainPanel.Height - e.Y, e.X, e.Y)
                Case "Auto Reverse line"
                    gr.DrawLine(New Pen(ccolor), e.X, e.Y, mainPanel.Width - e.X, mainPanel.Height - e.Y)
                    grnow.DrawLine(New Pen(ccolor), e.X, e.Y, mainPanel.Width - e.X, mainPanel.Height - e.Y)
                Case "3D Random"
                    gr.DrawLine(New Pen(ccolor), FirstLocs.X + (FirstLocs.X - e.X), FirstLocs.Y + (FirstLocs.Y + e.Y), mainPanel.Width - e.X, mainPanel.Height - e.Y)
                    grnow.DrawLine(New Pen(ccolor), FirstLocs.X + (FirstLocs.X - e.X), FirstLocs.Y + (FirstLocs.Y + e.Y), mainPanel.Width - e.X, mainPanel.Height - e.Y)
                Case "3D Pie Manual"
                    gr.DrawEllipse(New Pen(ccolor), e.X, e.Y, grootte, grootte)
                    grnow.DrawEllipse(New Pen(ccolor), e.X, e.Y, grootte, grootte)
                Case "3D Cirkel Auto."
                    gr.DrawEllipse(New Pen(ccolor), e.X, e.Y, e.X \ 2, e.X \ 2)
                    grnow.DrawEllipse(New Pen(ccolor), e.X, e.Y, e.X \ 2, e.X \ 2)
                Case "Eraser"
                    Dim blackbrush = New SolidBrush(mainPanel.BackColor)
                    Dim ellipseRect = New Rectangle(e.X, e.Y, 20, 20)
                    gr.FillEllipse(blackbrush, ellipseRect)
                    grnow.FillEllipse(blackbrush, ellipseRect)
                Case("3D Rectangle")
                    gr.DrawRectangle(New Pen(ccolor), e.X, e.Y, grootte, grootte)
                    grnow.DrawRectangle(New Pen(ccolor), e.X, e.Y, grootte, grootte)
                Case "Dotted Pen"
                    gr.DrawLine(New Pen(ccolor), e.X, e.Y, e.X, e.Y + 1)
                    grnow.DrawLine(New Pen(ccolor), e.X, e.Y, e.X, e.Y + 1)
                Case "Pencil"
                    gr.DrawLine(New Pen(ccolor, 2), e.X, e.Y, e.X, e.Y + 1)
                    grnow.DrawLine(New Pen(ccolor, 2), e.X, e.Y, e.X, e.Y + 1)
                Case "Top Left corner"
                    gr.DrawLine(New Pen(ccolor), 0, 0, e.X, e.Y)
                    grnow.DrawLine(New Pen(ccolor), 0, 0, e.X, e.Y)
                Case "Bottom Left Corner"
                    gr.DrawLine(New Pen(ccolor), mainPanel.Width, 0, e.X, e.Y)
                    grnow.DrawLine(New Pen(ccolor), mainPanel.Width, 0, e.X, e.Y)
                Case "Right corner"
                    gr.DrawLine(New Pen(ccolor), mainPanel.Width, mainPanel.Height, e.X, e.Y)
                    grnow.DrawLine(New Pen(ccolor), mainPanel.Width, mainPanel.Height, e.X, e.Y)
                Case "Bottom Left Corner"
                    gr.DrawLine(New Pen(ccolor), 0, mainPanel.Height, e.X, e.Y)
                    grnow.DrawLine(New Pen(ccolor), 0, mainPanel.Height, e.X, e.Y)
                Case "Mystic"
                    gr.DrawLine(New Pen(ccolor), e.X * 3, e.Y, mainPanel.Width \ 2 - e.X, mainPanel.Height \ 2 - e.Y)
                    grnow.DrawLine(New Pen(ccolor), e.X * 3, e.Y, mainPanel.Width \ 2 - e.X, mainPanel.Height \ 2 - e.Y)
                Case "Half Symmetry"
                    gr.DrawLine(New Pen(ccolor), e.Y, e.Y, e.X, e.Y)
                    grnow.DrawLine(New Pen(ccolor), e.Y, e.Y, e.X, e.Y)
                Case "Conversely Half Symmetry"
                    gr.DrawLine(New Pen(ccolor), e.X, e.X, e.Y, e.X)
                    grnow.DrawLine(New Pen(ccolor), e.X, e.X, e.Y, e.X)
                Case "Mystic 2"
                    gr.DrawLine(New Pen(ccolor), e.X, e.X, (mainPanel.Width - e.X) + 2 \ 3, (mainPanel.Height - e.Y) \ 2)
                    grnow.DrawLine(New Pen(ccolor), e.X, e.X, (mainPanel.Width - e.X) + 5 \ 3, (mainPanel.Height - e.Y) \ 2)
                Case "Curve Wall"
                    gr.DrawLine(New Pen(ccolor), (e.X - e.Y) * 2, (e.Y - e.X) * 2, e.X, e.Y)
                    grnow.DrawLine(New Pen(ccolor), (e.X - e.Y) * 2, (e.Y - e.X) * 2, e.X, e.Y)
                Case "Left Wall"
                    gr.DrawLine(New Pen(ccolor), (e.X - e.Y) * 2, e.X * 2, (e.Y - e.X) * 2, (e.X - e.Y) * 2)
                    grnow.DrawLine(New Pen(ccolor), (e.X - e.Y) * 2, e.X * 2, (e.Y - e.X) * 2, (e.X - e.Y) * 2)
                Case "3D Shape"
                    gr.DrawLine(New Pen(ccolor), e.X \ 3, e.Y \ 3, e.X * 2, e.Y * 2)
                    grnow.DrawLine(New Pen(ccolor), e.X \ 3, e.Y \ 3, e.X * 2, e.Y * 2)
                Case "Test"
                    gr.DrawLine(New Pen(ccolor), Math.Abs(mainPanel.Width - FirstLocs.X), Math.Abs(mainPanel.Height - FirstLocs.Y), e.X * (FirstLocs.X \ 2), e.Y * (FirstLocs.Y \ 2))
                    grnow.DrawLine(New Pen(ccolor), Math.Abs(mainPanel.Width - FirstLocs.X), Math.Abs(mainPanel.Height - FirstLocs.Y), e.X * (FirstLocs.X \ 2), e.Y * (FirstLocs.Y \ 2))
            End Select
            gr.Dispose()
            grnow.Dispose()
            mainPanel.BackgroundImage = xBmp
            mainPanel.Focus()
            countLines += 1
            '  lns.Text = "Lijnen: " & countLines
        End If
    End Sub

    Private Sub mainPanel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles mainPanel.Paint

    End Sub

    Private Sub btnClearAll_Click(sender As System.Object, e As System.EventArgs) Handles btnClearAll.Click
        mainPanel.CreateGraphics().Clear(mainPanel.BackColor)
    End Sub

    Private Sub mainFrm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowBetaGrp = False
        mainPanel.Width = Me.Width - 120
        fillIntroSwatch()
    End Sub

    Private Sub btnPencil_Click(sender As System.Object, e As System.EventArgs) Handles btnPencil.Click
        ComboBox2.Text = "Pencil"
        Me.Cursor = Cursors.Arrow
    End Sub

    
    Private Sub ToolStrip3_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub
    Sub fillSwatch()
        My.Computer.Audio.Play(My.Resources.ink, AudioPlayMode.Background)
        Button1.BackColor = Color.FromArgb(10, SwatchColor)
        Button2.BackColor = Color.FromArgb(20, SwatchColor)
        Button3.BackColor = Color.FromArgb(30, SwatchColor)
        Button4.BackColor = Color.FromArgb(40, SwatchColor)
        Button5.BackColor = Color.FromArgb(50, SwatchColor)
        Button6.BackColor = Color.FromArgb(60, SwatchColor)
        Button7.BackColor = Color.FromArgb(70, SwatchColor)
        Button8.BackColor = Color.FromArgb(80, SwatchColor)
        Button9.BackColor = Color.FromArgb(90, SwatchColor)
        Button10.BackColor = Color.FromArgb(100, SwatchColor)
        Button11.BackColor = Color.FromArgb(110, SwatchColor)
        Button12.BackColor = Color.FromArgb(120, SwatchColor)
        Button13.BackColor = Color.FromArgb(130, SwatchColor)
        Button14.BackColor = Color.FromArgb(140, SwatchColor)
        Button15.BackColor = Color.FromArgb(150, SwatchColor)
        Button16.BackColor = Color.FromArgb(160, SwatchColor)
        Button17.BackColor = Color.FromArgb(170, SwatchColor)
        Button18.BackColor = Color.FromArgb(180, SwatchColor)
        Button10.BackColor = Color.FromArgb(190, SwatchColor)
        Button11.BackColor = Color.FromArgb(200, SwatchColor)
        Button12.BackColor = Color.FromArgb(210, SwatchColor)
        Button13.BackColor = Color.FromArgb(220, SwatchColor)
        Button14.BackColor = Color.FromArgb(230, SwatchColor)
        Button15.BackColor = Color.FromArgb(240, SwatchColor)
        Button16.BackColor = Color.FromArgb(241, SwatchColor)
        Button17.BackColor = Color.FromArgb(242, SwatchColor)
        Button18.BackColor = Color.FromArgb(243, SwatchColor)
        Button19.BackColor = Color.FromArgb(244, SwatchColor)
        Button20.BackColor = Color.FromArgb(245, SwatchColor)
        Button21.BackColor = Color.FromArgb(246, SwatchColor)
        Button22.BackColor = Color.FromArgb(247, SwatchColor)
        Button23.BackColor = Color.FromArgb(248, SwatchColor)
        Button24.BackColor = Color.FromArgb(249, SwatchColor)
        Button25.BackColor = Color.FromArgb(250, SwatchColor)
        Button26.BackColor = Color.FromArgb(251, SwatchColor)
        Button27.BackColor = Color.FromArgb(252, SwatchColor)
        Button28.BackColor = Color.FromArgb(253, SwatchColor)
        Button29.BackColor = Color.FromArgb(252, SwatchColor)
        Button30.BackColor = Color.FromArgb(253, SwatchColor)
        Button31.BackColor = Color.FromArgb(252, SwatchColor)
        Button32.BackColor = Color.FromArgb(253, SwatchColor)
        Button33.BackColor = Color.FromArgb(252, SwatchColor)
        Button34.BackColor = Color.FromArgb(253, SwatchColor)
        Button35.BackColor = Color.FromArgb(252, SwatchColor)
        Button36.BackColor = Color.FromArgb(253, SwatchColor)
        Button37.BackColor = Color.FromArgb(254, SwatchColor)
        Button38.BackColor = Color.FromArgb(255, SwatchColor)
    End Sub
    Sub fillIntroSwatch()
        My.Computer.Audio.Play(My.Resources.ink, AudioPlayMode.Background)
        Button1.BackColor = Color.AliceBlue
        Button2.BackColor = Color.AntiqueWhite
        Button3.BackColor = Color.Aqua
        Button4.BackColor = Color.Beige
        Button5.BackColor = Color.Bisque
        Button6.BackColor = Color.Black
        Button7.BackColor = Color.Blue
        Button8.BackColor = Color.Chartreuse
        Button9.BackColor = Color.DarkCyan
        Button10.BackColor = Color.Fuchsia
        Button11.BackColor = Color.Gainsboro
        Button12.BackColor = Color.HotPink
        Button13.BackColor = Color.Indigo
        Button14.BackColor = Color.Khaki
        Button15.BackColor = Color.Lavender
        Button16.BackColor = Color.Maroon
        Button17.BackColor = Color.MediumPurple
        Button18.BackColor = Color.Navy
        Button10.BackColor = Color.OldLace
        Button11.BackColor = Color.PaleGreen
        Button12.BackColor = Color.Red
        Button13.BackColor = Color.SaddleBrown
        Button14.BackColor = Color.DarkGoldenrod
        Button15.BackColor = Color.Tan
        Button16.BackColor = Color.PaleTurquoise
        Button17.BackColor = Color.Violet
        Button18.BackColor = Color.Wheat
        Button19.BackColor = Color.Yellow
        Button20.BackColor = Color.YellowGreen
        Button21.BackColor = Color.FloralWhite
        Button22.BackColor = Color.Gray
        Button23.BackColor = Color.Honeydew
        Button24.BackColor = Color.Gold
        Button25.BackColor = Color.ForestGreen
        Button26.BackColor = Color.Firebrick
        Button27.BackColor = Color.DarkSalmon
        Button28.BackColor = Color.DarkTurquoise
        Button29.BackColor = Color.DarkSeaGreen
        Button30.BackColor = Color.DarkViolet
        Button31.BackColor = Color.DeepSkyBlue
        Button32.BackColor = Color.DodgerBlue
        Button33.BackColor = Color.DarkOrange
        Button34.BackColor = Color.LemonChiffon
        Button35.BackColor = Color.LightBlue
        Button36.BackColor = Color.LavenderBlush
        Button37.BackColor = Color.LightCyan
        Button38.BackColor = Color.Magenta
    End Sub
    Private Sub Swatch_Click(sender As System.Object, e As System.EventArgs) Handles Swatch.Click
        SwatchDialog.ShowDialog()
        SwatchColor = SwatchDialog.Color
        fillSwatch()

    End Sub

    
    Private Sub ToolStripContainer1_LeftToolStripPanel_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripContainer1.LeftToolStripPanel.Click

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ccolor = Button1.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        ccolor = Button2.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        ccolor = Button3.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        ccolor = Button4.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click
        ccolor = Button5.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        ccolor = Button6.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        ccolor = Button7.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        ccolor = Button8.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        ccolor = Button9.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        ccolor = Button10.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        ccolor = Button11.BackColor
        fillIntroSwatch()

    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        ccolor = Button12.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        ccolor = Button13.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        ccolor = Button14.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        ccolor = Button15.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        ccolor = Button16.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
        ccolor = Button17.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
        ccolor = Button18.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
        ccolor = Button19.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click
        ccolor = Button20.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button21_Click(sender As System.Object, e As System.EventArgs) Handles Button21.Click
        ccolor = Button21.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click
        ccolor = Button22.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles Button23.Click
        ccolor = Button23.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles Button24.Click
        ccolor = Button24.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles Button25.Click
        ccolor = Button25.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button26_Click(sender As System.Object, e As System.EventArgs) Handles Button26.Click
        ccolor = Button26.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button27_Click(sender As System.Object, e As System.EventArgs) Handles Button27.Click
        ccolor = Button27.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button28_Click(sender As System.Object, e As System.EventArgs) Handles Button28.Click
        ccolor = Button28.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button29_Click(sender As System.Object, e As System.EventArgs) Handles Button29.Click
        ccolor = Button29.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button30_Click(sender As System.Object, e As System.EventArgs) Handles Button30.Click
        ccolor = Button30.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button31_Click(sender As System.Object, e As System.EventArgs) Handles Button31.Click
        ccolor = Button31.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button32_Click(sender As System.Object, e As System.EventArgs) Handles Button32.Click
        ccolor = Button32.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button33_Click(sender As System.Object, e As System.EventArgs) Handles Button33.Click
        ccolor = Button33.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button34_Click(sender As System.Object, e As System.EventArgs) Handles Button34.Click
        ccolor = Button34.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button35_Click(sender As System.Object, e As System.EventArgs) Handles Button35.Click
        ccolor = Button35.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button36_Click(sender As System.Object, e As System.EventArgs) Handles Button36.Click
        ccolor = Button36.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button37_Click(sender As System.Object, e As System.EventArgs) Handles Button37.Click
        ccolor = Button37.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub Button38_Click(sender As System.Object, e As System.EventArgs) Handles Button38.Click
        ccolor = Button38.BackColor
        fillIntroSwatch()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

   
    
   
    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dim Screenloc As System.Drawing.Point
        Screenloc = New Point(MousePosition.X, MousePosition.Y)
        Menu3d.Show(Screenloc)
        Me.mainPanel.Cursor = Cursors.Cross
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        mainPanel.CreateGraphics().Clear(mainPanel.BackColor)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        ComboBox2.Text = ToolStripMenuItem1.Text
    End Sub

    Private Sub Menu3d_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Menu3d.ItemClicked

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        ComboBox2.Text = ToolStripMenuItem2.Text
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click
        ComboBox2.Text = ToolStripMenuItem3.Text
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem4.Click
        ComboBox2.Text = ToolStripMenuItem4.Text
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem5.Click
        ComboBox2.Text = ToolStripMenuItem5.Text
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem6.Click
        ComboBox2.Text = ToolStripMenuItem6.Text
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem7.Click
        ComboBox2.Text = ToolStripMenuItem7.Text
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem8.Click
        ComboBox2.Text = ToolStripMenuItem8.Text
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem9.Click
        ComboBox2.Text = ToolStripMenuItem9.Text
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem10.Click
        ComboBox2.Text = ToolStripMenuItem10.Text
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem11.Click
        ComboBox2.Text = ToolStripMenuItem11.Text
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem12.Click
        ComboBox2.Text = ToolStripMenuItem12.Text
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem13.Click
        ComboBox2.Text = ToolStripMenuItem13.Text
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem14.Click
        ComboBox2.Text = ToolStripMenuItem14.Text
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem15.Click
        ComboBox2.Text = ToolStripMenuItem15.Text
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem16.Click
        ComboBox2.Text = ToolStripMenuItem16.Text
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem17.Click
        ComboBox2.Text = ToolStripMenuItem17.Text
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem18.Click
        ComboBox2.Text = ToolStripMenuItem18.Text
    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem19.Click
        ComboBox2.Text = ToolStripMenuItem19.Text
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem20.Click
        ComboBox2.Text = ToolStripMenuItem20.Text
    End Sub

    Private Sub ToolStripMenuItem21_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem21.Click
        ComboBox2.Text = ToolStripMenuItem21.Text
    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem22.Click
        ComboBox2.Text = ToolStripMenuItem22.Text
    End Sub

    Private Sub ToolStripMenuItem23_Click(sender As Object, e As System.EventArgs) Handles ToolStripMenuItem23.Click
        ComboBox2.Text = ToolStripMenuItem23.Text
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        ComboBox2.Text = "Eraser"
    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        SwatchDialog.ShowDialog()
        mainPanel.BackColor = SwatchDialog.Color
    End Sub
End Class
