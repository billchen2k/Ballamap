Imports System.IO
Public Class FrmMain

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Firstrun = True Then
            MessageBox.Show("更新日志：" & vbCrLf & "1、【优化】在界面最下方可以直接运行游戏（+0.0.1）" & vbCrLf & "2、【新增】软件更新检测功能（+0.1）" & vbCrLf _
                       & "3、【改进】地图管理模块中，右侧的天空背景资源变成链接本地资源，取消了嵌入进应用资源，大幅减小应用体积（+0.0.1）" & vbCrLf _
                       & "4、【优化】关于界面的链接可以点击（+0.0.0.1）" & vbCrLf & "（0.9.1 >> 1.0.2.1）" & vbCrLf & "编译时间：2014.8.20", "Ballamap 更新日志", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            My.Settings.Firstrun = False
        End If
        Do
            If My.Settings.BallancePath = "None" Then
                MessageBox.Show("您好，欢迎首次运行 Ballamap ，请设置您的 Ballance 安装目录。", "Ballamap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Dim folder As DialogResult
                folder = Me.FolderBrowserDialog1.ShowDialog()
                If folder = DialogResult.OK Then
                    TxtPath.Text = FolderBrowserDialog1.SelectedPath
                    My.Settings.BallancePath = TxtPath.Text
                    Me.Show()
                    Exit Do

                Else
                    MessageBox.Show("请选择您的 Ballance 安装目录！", "Ballamap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Else
                TxtPath.Text = My.Settings.BallancePath.ToString
                Exit Do
            End If
        Loop



    End Sub

    '地图管理天空背景
    Private Sub TabMapManage_Enter(sender As Object, e As EventArgs) Handles TabMapManage.Enter
        picSky1.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_L_Front.BMP", IO.FileMode.Open, FileAccess.Read))
        picSky2.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_E_Down.BMP", IO.FileMode.Open, FileAccess.Read))
        picSky3.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_A_Down.BMP", IO.FileMode.Open, FileAccess.Read))
        picSky4.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_F_Down.BMP", IO.FileMode.Open, FileAccess.Read))
        picSky5.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_C_Down.BMP", IO.FileMode.Open, FileAccess.Read))
        picSky6.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_H_Down.BMP", IO.FileMode.Open, FileAccess.Read))
        picSky7.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_D_Down.BMP", IO.FileMode.Open, FileAccess.Read))
        picSky8.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_G_Down.BMP", IO.FileMode.Open, FileAccess.Read))
        picSky9.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_K_Down.BMP", IO.FileMode.Open, FileAccess.Read))
        picSky10.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_B_Down.BMP", IO.FileMode.Open, FileAccess.Read))
        picSky11.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_J_Down.BMP", IO.FileMode.Open, FileAccess.Read))
        picSky12.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_I_Down.BMP", IO.FileMode.Open, FileAccess.Read))
        picSky13.BackgroundImage = Drawing.Image.FromStream(New IO.FileStream(TxtPath.Text & "\Textures\Sky\Sky_F_Down.BMP", IO.FileMode.Open, FileAccess.Read))
    End Sub
    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Dim folder As DialogResult

        folder = Me.FolderBrowserDialog1.ShowDialog()

        If folder = DialogResult.OK Then

            TxtPath.Text = FolderBrowserDialog1.SelectedPath
            My.Settings.BallancePath = TxtPath.Text

        Else
            MessageBox.Show("请选择您的 Ballance 安装目录！", "Ballamap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If


    End Sub



    Private Sub BtnRefreshState_Click(sender As Object, e As EventArgs) Handles BtnRefreshState.Click
        Me.Cursor = Cursors.WaitCursor
        ProgressBar.Value = 0
        ProgressBar.Maximum = 13
        Dim Level1 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_01.NMO")
        Dim Level2 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_02.NMO")
        Dim Level3 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_03.NMO")
        Dim Level4 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_04.NMO")
        Dim Level5 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_05.NMO")
        Dim Level6 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_06.NMO")
        Dim Level7 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_07.NMO")
        Dim Level8 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_08.NMO")
        Dim Level9 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_09.NMO")
        Dim Level10 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_10.NMO")
        Dim Level11 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_11.NMO")
        Dim Level12 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_12.NMO")
        Dim Level13 As New System.IO.FileInfo(TxtPath.Text & "\3D Entities\Level\Level_13.NMO")
        If Level1.Length = 1388965 Then
            LabState1.Text = "Level 1：官方关卡"
            LabState1.ForeColor = Color.Green
            ProgressBar.Value = 1
        Else
            LabState1.Text = "Level 1：非官方关卡"
            LabState1.ForeColor = Color.Red
            ProgressBar.Value = 1
        End If
        If Level2.Length = 1118747 Then
            LabState2.Text = "Level 2：官方关卡"
            LabState2.ForeColor = Color.Green
            ProgressBar.Value = 2
        Else
            LabState2.Text = "Level 2：非官方关卡"
            LabState2.ForeColor = Color.Red
            ProgressBar.Value = 2
        End If
        If Level3.Length = 1284250 Then
            LabState3.Text = "Level 3：官方关卡"
            LabState3.ForeColor = Color.Green
            ProgressBar.Value = 3
        Else
            LabState3.Text = "Level 3：非官方关卡"
            LabState3.ForeColor = Color.Red
            ProgressBar.Value = 3
        End If
        If Level4.Length = 1029039 Then
            LabState4.Text = "Level 4：官方关卡"
            LabState4.ForeColor = Color.Green
            ProgressBar.Value = 4
        Else
            LabState4.Text = "Level 4：非官方关卡"
            LabState4.ForeColor = Color.Red
            ProgressBar.Value = 4
        End If
        If Level5.Length = 1504482 Then
            LabState5.Text = "Level 5：官方关卡"
            LabState5.ForeColor = Color.Green
            ProgressBar.Value = 5
        Else
            LabState5.Text = "Level 5：非官方关卡"
            LabState5.ForeColor = Color.Red
            ProgressBar.Value = 5
        End If
        If Level6.Length = 1023463 Then
            LabState6.Text = "Level 6：官方关卡"
            LabState6.ForeColor = Color.Green
            ProgressBar.Value = 6
        Else
            LabState6.Text = "Level 6：非官方关卡"
            LabState6.ForeColor = Color.Red
            ProgressBar.Value = 6
        End If
        If Level7.Length = 1278593 Then
            LabState7.Text = "Level 7：官方关卡"
            LabState7.ForeColor = Color.Green
            ProgressBar.Value = 7
        Else
            LabState7.Text = "Level 7：非官方关卡"
            LabState7.ForeColor = Color.Red
            ProgressBar.Value = 7
        End If
        If Level8.Length = 1286704 Then
            LabState8.Text = "Level 8：官方关卡"
            LabState8.ForeColor = Color.Green
            ProgressBar.Value = 8
        Else
            LabState8.Text = "Level 8：非官方关卡"
            LabState8.ForeColor = Color.Red
            ProgressBar.Value = 8
        End If
        If Level9.Length = 1373342 Then
            LabState9.Text = "Level 9：官方关卡"
            LabState9.ForeColor = Color.Green
            ProgressBar.Value = 9
        Else
            LabState9.Text = "Level 9：非官方关卡"
            LabState9.ForeColor = Color.Red
            ProgressBar.Value = 9
        End If
        If Level10.Length = 1499175 Then
            LabState10.Text = "Level 10：官方关卡"
            LabState10.ForeColor = Color.Green
            ProgressBar.Value = 10
        Else
            LabState10.Text = "Level 10：非官方关卡"
            LabState10.ForeColor = Color.Red
            ProgressBar.Value = 10
        End If
        If Level11.Length = 1767814 Then
            LabState11.Text = "Level 11：官方关卡"
            LabState11.ForeColor = Color.Green
            ProgressBar.Value = 11
        Else
            LabState11.Text = "Level 11：非官方关卡"
            LabState11.ForeColor = Color.Red
            ProgressBar.Value = 11
        End If
        If Level12.Length = 1901424 Then
            LabState12.Text = "Level 12：官方关卡"
            LabState12.ForeColor = Color.Green
            ProgressBar.Value = 12
        Else
            LabState12.Text = "Level 12：非官方关卡"
            LabState12.ForeColor = Color.Red
            ProgressBar.Value = 12
        End If
        If Level13.Length = 1305382 Then
            LabState13.Text = "Level 13：官方关卡"
            LabState13.ForeColor = Color.Green
            ProgressBar.Value = 13
        Else
            LabState13.Text = "Level 13：非官方关卡"
            LabState13.ForeColor = Color.Red
            ProgressBar.Value = 13
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Tab_Click(sender As Object, e As EventArgs) Handles Tab.Click
        ProgressBar.Value = 0
        btnInstall1.Enabled = False
        btnInstall2.Enabled = False
        btnInstall3.Enabled = False
        btnInstall4.Enabled = False
        btnInstall5.Enabled = False
        btnInstall6.Enabled = False
        btnInstall7.Enabled = False
        btnInstall8.Enabled = False
        btnInstall9.Enabled = False
        btnInstall10.Enabled = False
        btnInstall11.Enabled = False
        btnInstall12.Enabled = False
        btnInstall13.Enabled = False
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()
        ListBox7.Items.Clear()
        ListBox8.Items.Clear()
        ListBox9.Items.Clear()
        ListBox10.Items.Clear()
        ListBox11.Items.Clear()
        ListBox12.Items.Clear()
        ListBox13.Items.Clear()
        delete1.Visible = False
        delete2.Visible = False
        delete3.Visible = False
        delete4.Visible = False
        delete5.Visible = False
        delete6.Visible = False
        delete7.Visible = False
        delete8.Visible = False
        delete9.Visible = False
        delete10.Visible = False
        delete11.Visible = False
        delete12.Visible = False
        Delete13.Visible = False
        Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
        For i As Integer = 0 To FileNames.Length - 1
            ListBox1.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox2.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox3.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox4.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox5.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox6.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox7.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox8.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox9.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox10.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox11.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox12.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox13.Items.Add(Path.GetFileName(FileNames(i)))
        Next

        'backup
        lstBackup.Items.Clear()
        Dim BackupFiles() As String = Directory.GetFiles(Application.StartupPath & "\Backup")
        If BackupFiles.Length = 0 Then
        Else
            For i As Integer = 0 To BackupFiles.Length - 1
                lstBackup.Items.Add(Path.GetFileName(BackupFiles(i)))
            Next
        End If

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认将所有关卡重置？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.CopyDirectory(Application.StartupPath & "\Data\Level", TxtPath.Text & "\3D Entities\Level", True)
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub


    Private Sub BtnReset1_Click(sender As Object, e As EventArgs) Handles BtnReset1.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 1？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_01.NMO", TxtPath.Text & "\3D Entities\Level\Level_01.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnReset2_Click(sender As Object, e As EventArgs) Handles BtnReset2.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 2？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_02.NMO", TxtPath.Text & "\3D Entities\Level\Level_02.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnReset3_Click(sender As Object, e As EventArgs) Handles BtnReset3.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 3？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_03.NMO", TxtPath.Text & "\3D Entities\Level\Level_03.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnReset4_Click(sender As Object, e As EventArgs) Handles BtnReset4.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 4？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_04.NMO", TxtPath.Text & "\3D Entities\Level\Level_04.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnReset5_Click(sender As Object, e As EventArgs) Handles BtnReset5.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 5？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_05.NMO", TxtPath.Text & "\3D Entities\Level\Level_05.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnReset6_Click(sender As Object, e As EventArgs) Handles BtnReset6.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 6？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_06.NMO", TxtPath.Text & "\3D Entities\Level\Level_06.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnReset7_Click(sender As Object, e As EventArgs) Handles BtnReset7.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 7？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_07.NMO", TxtPath.Text & "\3D Entities\Level\Level_07.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnReset8_Click(sender As Object, e As EventArgs) Handles BtnReset8.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 8？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_08.NMO", TxtPath.Text & "\3D Entities\Level\Level_08.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnReset9_Click(sender As Object, e As EventArgs) Handles BtnReset9.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 9？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_09.NMO", TxtPath.Text & "\3D Entities\Level\Level_09.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnReset10_Click(sender As Object, e As EventArgs) Handles BtnReset10.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 10？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_10.NMO", TxtPath.Text & "\3D Entities\Level\Level_10.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnReset11_Click(sender As Object, e As EventArgs) Handles BtnReset11.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 11？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_11.NMO", TxtPath.Text & "\3D Entities\Level\Level_11.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnReset12_Click(sender As Object, e As EventArgs) Handles BtnReset12.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 12？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_12.NMO", TxtPath.Text & "\3D Entities\Level\Level_12.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub BtnReset13_Click(sender As Object, e As EventArgs) Handles BtnReset13.Click
        ProgressBar.Maximum = 1
        If MsgBox("确认重置 Level 13？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Data\Level\Level_13.NMO", TxtPath.Text & "\3D Entities\Level\Level_13.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub TabMaps_Click(sender As Object, e As EventArgs) Handles TabMaps.Click
        ProgressBar.Value = 0
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()
        ListBox7.Items.Clear()
        ListBox9.Items.Clear()
        ListBox10.Items.Clear()
        ListBox11.Items.Clear()
        ListBox12.Items.Clear()
        ListBox13.Items.Clear()
        Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
        For i As Integer = 0 To FileNames.Length - 1
            ListBox1.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox2.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox3.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox4.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox5.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox6.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox7.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox8.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox9.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox10.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox11.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox12.Items.Add(Path.GetFileName(FileNames(i)))
        Next
        For i As Integer = 0 To FileNames.Length - 1
            ListBox13.Items.Add(Path.GetFileName(FileNames(i)))
        Next
    End Sub
    '===================================================lv1======================================================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnInstall1.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox1.SelectedItem.ToString & "安装到 Level 1 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox1.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_01.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        btnInstall1.Enabled = True
        delete1.Visible = True
    End Sub

    Private Sub btnBrowse1_Click(sender As Object, e As EventArgs) Handles btnBrowse1.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 1 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_01.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete1_Click(sender As Object, e As EventArgs) Handles delete1.Click
        If MsgBox("确认要删除" & ListBox1.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox1.SelectedItem)
            ListBox1.Items.Clear()
            delete1.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox1.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub

    '===================================================lv2======================================================

    Private Sub btnInstall2_Click(sender As Object, e As EventArgs) Handles btnInstall2.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox2.SelectedItem.ToString & "安装到 Level 2 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox2.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_02.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        btnInstall2.Enabled = True
        delete2.Visible = True
    End Sub

    Private Sub btnBrowse2_Click(sender As Object, e As EventArgs) Handles btnBrowse2.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 2 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_02.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete2_Click(sender As Object, e As EventArgs) Handles delete2.Click
        If MsgBox("确认要删除" & ListBox2.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox2.SelectedItem)
            ListBox2.Items.Clear()
            delete2.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox2.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub


    '===================================================lv3======================================================

    Private Sub btnInstall3_Click(sender As Object, e As EventArgs) Handles btnInstall3.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox3.SelectedItem.ToString & "安装到 Level 3 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox3.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_03.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        btnInstall3.Enabled = True
        delete3.Visible = True
    End Sub

    Private Sub btnBrowse3_Click(sender As Object, e As EventArgs) Handles btnBrowse3.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 3 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_03.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete3_Click(sender As Object, e As EventArgs) Handles delete3.Click
        If MsgBox("确认要删除" & ListBox3.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox3.SelectedItem)
            ListBox3.Items.Clear()
            delete3.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox3.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub

    '===================================================lv4======================================================

    Private Sub btnInstall4_Click(sender As Object, e As EventArgs) Handles btnInstall4.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox4.SelectedItem.ToString & "安装到 Level 4 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox4.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_04.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged
        btnInstall4.Enabled = True
        delete4.Visible = True
    End Sub

    Private Sub btnBrowse4_Click(sender As Object, e As EventArgs) Handles btnBrowse4.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 4 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_04.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete4_Click(sender As Object, e As EventArgs) Handles delete4.Click
        If MsgBox("确认要删除" & ListBox4.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox4.SelectedItem)
            ListBox4.Items.Clear()
            delete4.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox4.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub

    '===================================================lv5======================================================

    Private Sub btnInstall5_Click(sender As Object, e As EventArgs) Handles btnInstall5.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox5.SelectedItem.ToString & "安装到 Level 5 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox5.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_05.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox5.SelectedIndexChanged
        btnInstall5.Enabled = True
        delete5.Visible = True
    End Sub

    Private Sub btnBrowse5_Click(sender As Object, e As EventArgs) Handles btnBrowse5.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 5 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_05.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete5_Click(sender As Object, e As EventArgs) Handles delete5.Click
        If MsgBox("确认要删除" & ListBox5.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox5.SelectedItem)
            ListBox5.Items.Clear()
            delete5.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox5.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub

    '===================================================lv6======================================================

    Private Sub btnInstall6_Click(sender As Object, e As EventArgs) Handles btnInstall6.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox6.SelectedItem.ToString & "安装到 Level 6 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox6.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_06.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox6.SelectedIndexChanged
        btnInstall6.Enabled = True
        delete6.Visible = True
    End Sub

    Private Sub btnBrowse6_Click(sender As Object, e As EventArgs) Handles btnBrowse6.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 6 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_06.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete6_Click(sender As Object, e As EventArgs) Handles delete6.Click
        If MsgBox("确认要删除" & ListBox6.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox6.SelectedItem)
            ListBox6.Items.Clear()
            delete6.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox6.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub

    '===================================================lv7======================================================

    Private Sub btnInstall7_Click(sender As Object, e As EventArgs) Handles btnInstall7.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox7.SelectedItem.ToString & "安装到 Level 7 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox7.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_07.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox7.SelectedIndexChanged
        btnInstall7.Enabled = True
        delete7.Visible = True
    End Sub

    Private Sub btnBrowse7_Click(sender As Object, e As EventArgs) Handles btnBrowse7.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 7 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_07.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete7_Click(sender As Object, e As EventArgs) Handles delete7.Click
        If MsgBox("确认要删除" & ListBox7.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox7.SelectedItem)
            ListBox7.Items.Clear()
            delete7.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox7.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub

    '===================================================lv8======================================================

    Private Sub btnInstall8_Click(sender As Object, e As EventArgs) Handles btnInstall8.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox8.SelectedItem.ToString & "安装到 Level 8 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox8.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_08.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox8.SelectedIndexChanged
        btnInstall8.Enabled = True
        delete8.Visible = True
    End Sub

    Private Sub btnBrowse8_Click(sender As Object, e As EventArgs) Handles btnBrowse8.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 8 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_08.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete8_Click(sender As Object, e As EventArgs) Handles delete8.Click
        If MsgBox("确认要删除" & ListBox8.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox8.SelectedItem)
            ListBox8.Items.Clear()
            delete8.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox8.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub


    '===================================================lv9======================================================

    Private Sub btnInstall9_Click(sender As Object, e As EventArgs) Handles btnInstall9.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox9.SelectedItem.ToString & "安装到 Level 9 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox9.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_09.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox9.SelectedIndexChanged
        btnInstall9.Enabled = True
        delete9.Visible = True
    End Sub

    Private Sub btnBrowse9_Click(sender As Object, e As EventArgs) Handles btnBrowse9.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 9 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_09.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete9_Click(sender As Object, e As EventArgs) Handles delete9.Click
        If MsgBox("确认要删除" & ListBox9.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox9.SelectedItem)
            ListBox9.Items.Clear()
            delete9.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox9.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub

    '===================================================lv10======================================================

    Private Sub btnInstall10_Click(sender As Object, e As EventArgs) Handles btnInstall10.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox10.SelectedItem.ToString & "安装到 Level 10 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox10.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_10.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox10.SelectedIndexChanged
        btnInstall10.Enabled = True
        delete10.Visible = True
    End Sub

    Private Sub btnBrowse10_Click(sender As Object, e As EventArgs) Handles btnBrowse10.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 10 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_=10.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete10_Click(sender As Object, e As EventArgs) Handles delete10.Click
        If MsgBox("确认要删除" & ListBox10.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox10.SelectedItem)
            ListBox10.Items.Clear()
            delete10.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox10.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub

    '===================================================lv11======================================================

    Private Sub btnInstall11_Click(sender As Object, e As EventArgs) Handles btnInstall11.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox11.SelectedItem.ToString & "安装到 Level 11 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox11.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_11.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox11.SelectedIndexChanged
        btnInstall11.Enabled = True
        delete11.Visible = True
    End Sub

    Private Sub btnBrowse11_Click(sender As Object, e As EventArgs) Handles btnBrowse11.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 11 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_11.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete11_Click(sender As Object, e As EventArgs) Handles delete11.Click
        If MsgBox("确认要删除" & ListBox11.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox11.SelectedItem)
            ListBox11.Items.Clear()
            delete11.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox11.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub

    '===================================================lv12======================================================

    Private Sub btnInstall12_Click(sender As Object, e As EventArgs) Handles btnInstall12.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox12.SelectedItem.ToString & "安装到 Level 12 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox12.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_12.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox12_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox12.SelectedIndexChanged
        btnInstall12.Enabled = True
        delete12.Visible = True
    End Sub

    Private Sub btnBrowse12_Click(sender As Object, e As EventArgs) Handles btnBrowse12.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 12 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_12.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete12_Click(sender As Object, e As EventArgs) Handles delete12.Click
        If MsgBox("确认要删除" & ListBox12.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox12.SelectedItem)
            ListBox12.Items.Clear()
            delete12.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox12.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub

    '===================================================lv13======================================================

    Private Sub btnInstall13_Click(sender As Object, e As EventArgs) Handles btnInstall13.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & ListBox13.SelectedItem.ToString & "安装到 Level 13 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & ListBox13.SelectedItem, TxtPath.Text & "\3d Entities\Level\Level_13.NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Sub ListBox13_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox13.SelectedIndexChanged
        btnInstall13.Enabled = True
        Delete13.Visible = True
    End Sub

    Private Sub btnBrowse13_Click(sender As Object, e As EventArgs) Handles btnBrowse13.Click
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            If MsgBox("确认将所选文件安装到 Level 13 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, TxtPath.Text & "\3d Entities\Level\Level_13.NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If

        End If


    End Sub
    Private Sub delete13_Click(sender As Object, e As EventArgs) Handles Delete13.Click
        If MsgBox("确认要删除" & ListBox13.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & ListBox13.SelectedItem)
            ListBox13.Items.Clear()
            Delete13.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                ListBox13.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
    End Sub



    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click, Label26.Click

    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        FileCopy(TxtPath.Text & "\Database.tdb", Application.StartupPath & "\Backup\" & Format(Now, "yyyy年mm月dd日 hh时mm分ss秒") & "的备份.bak")
        MessageBox.Show("排行榜备份成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        lstBackup.Items.Clear()
        Dim BackupFiles() As String = Directory.GetFiles(Application.StartupPath & "\Backup")
        If BackupFiles.Length = 0 Then
        Else
            For i As Integer = 0 To BackupFiles.Length - 1
                lstBackup.Items.Add(Path.GetFileName(BackupFiles(i)))
            Next
        End If
        ProgressBar.Value = 1
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & lstBackup.SelectedItem.ToString & "还原至 Ballance 目录吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Backup\" & lstBackup.SelectedItem, TxtPath.Text & "\Database.tdb")
            ProgressBar.Value = 1
            MessageBox.Show("备份还原成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles PictureBox17.Click
        If MsgBox("确认要删除" & lstBackup.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Backup\" & lstBackup.SelectedItem)
            lstBackup.Items.Clear()
            PictureBox17.Visible = False
            Dim Backupfiles() As String = Directory.GetFiles(Application.StartupPath & "\Backup")
            For i As Integer = 0 To Backupfiles.Length - 1
                ListBox13.Items.Add(Path.GetFileName(Backupfiles(i)))
            Next
        End If
    End Sub

    Private Sub lstBackup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBackup.SelectedIndexChanged
        PictureBox17.Visible = True
        btnRestore.Enabled = True
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        Shell(TxtPath.Text & "\Startup.exe", AppWinStyle.NormalFocus)
    End Sub



    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ProgressBar.Maximum = 5
        If File.Exists(Application.StartupPath & "\Data\BuildCache") Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Data\BuildCache")
            ProgressBar.Value = 1
            My.Computer.Network.DownloadFile("http://miraclest.hostwl.com/softwares/ballamap/newestbuild.txt", Application.StartupPath & "\Data\BuildCache")
        Else
            My.Computer.Network.DownloadFile("http://miraclest.hostwl.com/softwares/ballamap/newestbuild.txt", Application.StartupPath & "\Data\BuildCache")
        End If
        ProgressBar.Value = 2
        Dim writer As StreamReader
        Dim txt As String
        Dim newestbuildcache As String
        Dim newestbuild As String
        txt = Application.StartupPath & "\Data\BuildCache"
        writer = File.OpenText(txt)
        txt = writer.ReadLine()
        newestbuildcache = writer.ReadLine()
        Do Until IsNothing(txt)
            If IsNothing(txt) Then Exit Do
            newestbuildcache = txt
            txt = writer.ReadLine()
        Loop
        writer.Close()
        ProgressBar.Value = 3
        newestbuild = newestbuildcache.Remove(4)
        Dim writernow As StreamReader
        Dim txtnow As String
        Dim buildnow As String
        txtnow = Application.StartupPath & "\Data\Build"
        writernow = File.OpenText(txtnow)
        txtnow = writernow.ReadLine()
        buildnow = writernow.ReadLine()
        Do Until IsNothing(txtnow)
            If IsNothing(txtnow) Then Exit Do
            buildnow = txtnow
            txtnow = writernow.ReadLine()
        Loop
        ProgressBar.Value = 4
        If newestbuild > buildnow Then
            If MessageBox.Show("新版本可用！" & vbCrLf & "最新版本：Build " & newestbuild & vbCrLf & "当前版本：Build " & buildnow & vbCrLf _
                            & "您可以在 http://eaglelions.ys168.com 下载该更新，现在是否帮您打开该网页？", "Ballamap 更新可用", MessageBoxButtons.YesNo, _
                            MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                System.Diagnostics.Process.Start("http://eaglelions.ys168.com")
            End If
            ProgressBar.Value = 5
        Else
            MessageBox.Show("当前的 Build " & buildnow & " 已是最新版本！", "Ballamap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ProgressBar.Value = 5
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As EventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://eaglelions.ys168.com")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start("http://eaglelions.ys168.com")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        System.Diagnostics.Process.Start("http://tieba.baidu.com/f?kw=ballance")
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        MessageBox.Show("更新日志：" & vbCrLf & "1、【优化】在界面最下方可以直接运行游戏（+0.0.1）" & vbCrLf & "2、【新增】软件更新检测功能（+0.1）" & vbCrLf _
                        & "3、【改进】地图管理模块中，右侧的天空背景资源变成链接本地资源，取消了嵌入进应用资源，大幅减小应用体积（+0.0.1）" & vbCrLf _
                        & "4、【优化】关于界面的链接可以点击（+0.0.0.1）" & vbCrLf & "（0.9.1 >> 1.0.2.1）" & vbCrLf & "编译时间：2014.8.20", "Ballamap 更新日志", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        System.Diagnostics.Process.Start("http://miraclest.hostwl.com")
    End Sub
End Class
