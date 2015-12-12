Imports System.IO
Imports System.Drawing
Imports Microsoft.Win32
Imports Microsoft.VisualBasic.Compatibility


Public Class FrmMain
    Dim mapshow As Boolean = False
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Settings.Title.ToString

    End Sub
    Private Sub FrmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If My.Settings.Firstrun = True Then
            Tab.Visible = False
            System.Diagnostics.Process.Start(Application.StartupPath & "\Update20151212.mht")
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
                    Tab.Visible = True
                    Exit Do

                Else
                    MessageBox.Show("请选择您的 Ballance 安装目录！", "Ballamap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Else
                TxtPath.Text = My.Settings.BallancePath.ToString
                Exit Do
            End If
        Loop
        If My.Settings.AutoUpdate = True Then
            chkAutoUpdate.Checked = True
        Else
            chkAutoUpdate.Checked = False
        End If
        'TabMapManage_Enter()

    End Sub
    '地图管理天空背景
    Private Sub TabMapManage_Enter() Handles TabMapManage.Enter
        picSky1.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_L_Front.BMP")
        picSky2.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_E_Down.BMP")
        picSky3.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_A_Down.BMP")
        picSky4.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_F_Down.BMP")
        picSky5.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_C_Down.BMP")
        picSky6.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_H_Down.BMP")
        picSky7.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_D_Down.BMP")
        picSky8.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_G_Down.BMP")
        picSky9.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_K_Down.BMP")
        picSky10.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_B_Down.BMP")
        picSky11.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_J_Down.BMP")
        picSky12.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_I_Down.BMP")
        picSky13.BackgroundImage = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_F_Down.BMP")
        mapshow = True

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

    Private LengthData() As Integer = {0, 1388965, 1118747, 1284250, 1029039, 1504482, 1023463, 1278593, 1286704, 1373342, 1499175, 1767814, 1901424, 1305382}
    Private Sub CheckLevelOriginal(ByVal LevelIndex As String, ByVal LevelLabel As Label)
        Dim Leveln As New System.IO.FileInfo(My.Settings.BallancePath.ToString & "\3D Entities\Level\Level_" + LevelIndex + ".NMO")
        If Leveln.Length = LengthData(Convert.ToInt32(LevelIndex)) Then
            LevelLabel.Text = "Level " + LevelIndex + "：官方关卡        （官方文件长度：" & LengthData(Convert.ToInt32(LevelIndex)) & "；目标文件长度：" & Leveln.Length & "）"
            LevelLabel.ForeColor = Color.Green
        Else
            LevelLabel.Text = "Level " + LevelIndex + "：非官方关卡     （官方文件长度：" & LengthData(Convert.ToInt32(LevelIndex)) & "；目标文件长度：" & Leveln.Length & "）"
            LevelLabel.ForeColor = Color.Red
            My.Settings.LastChecked = My.Settings.LastChecked & "， Level " & LevelIndex & " 非官方；"
        End If
        ProgressBar.Value = Convert.ToInt32(LevelIndex)
    End Sub

    Private Sub BtnRefreshState_Click(sender As Object, e As EventArgs) Handles BtnRefreshState.Click
        labStatus.Text = "正在检测..."
        My.Settings.LastChecked = Format(Now, "yyyy.MM.dd hh.mm.ss")
        Me.Cursor = Cursors.WaitCursor
        ProgressBar.Value = 0
        ProgressBar.Maximum = 13
        CheckLevelOriginal("01", LabState1)
        CheckLevelOriginal("02", LabState2)
        CheckLevelOriginal("03", LabState3)
        CheckLevelOriginal("04", LabState4)
        CheckLevelOriginal("05", LabState5)
        CheckLevelOriginal("06", LabState6)
        CheckLevelOriginal("07", LabState7)
        CheckLevelOriginal("08", LabState8)
        CheckLevelOriginal("09", LabState9)
        CheckLevelOriginal("10", LabState10)
        CheckLevelOriginal("11", LabState11)
        CheckLevelOriginal("12", LabState12)
        CheckLevelOriginal("13", LabState13)
        labLast.Text = "上次检查：" & My.Settings.LastChecked
        Me.Cursor = Cursors.Default
        TimerResetRapid.Enabled = True
    End Sub
    Private Sub ReloadLevels()
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
        Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
        Dim filename As String
        For i As Integer = 0 To FileNames.Length - 1
            filename = Path.GetFileName(FileNames(i))
            ListBox1.Items.Add(filename)
            ListBox2.Items.Add(filename)
            ListBox3.Items.Add(filename)
            ListBox4.Items.Add(filename)
            ListBox5.Items.Add(filename)
            ListBox6.Items.Add(filename)
            ListBox7.Items.Add(filename)
            ListBox8.Items.Add(filename)
            ListBox9.Items.Add(filename)
            ListBox10.Items.Add(filename)
            ListBox11.Items.Add(filename)
            ListBox12.Items.Add(filename)
            ListBox13.Items.Add(filename)
        Next
    End Sub
    Private Sub Tab_Click(sender As Object, e As EventArgs) Handles Tab.Click
        ReloadLevels()
        ProgressBar.Value = 0
        ProgressBar.Maximum = 13
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

        'backup
        lstBackup.Items.Clear()
        Dim BackupFiles() As String = Directory.GetFiles(Application.StartupPath & "\Backup")
        If BackupFiles.Length = 0 Then
        Else
            For i As Integer = 0 To BackupFiles.Length - 1
                lstBackup.Items.Add(Path.GetFileName(BackupFiles(i)))
            Next
        End If
        labStatus.Text = "就绪"
    End Sub
    Private Sub ResetLevel(ByVal LevelIndex As String)
        ProgressBar.Maximum = 1

        If LevelIndex <> "" Then
            labStatus.Text = "正在重置 Level " & LevelIndex & "..."
            If MsgBox("确认重置 Level " + LevelIndex + " ？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(Application.StartupPath & "\Data\Level\Level_" + LevelIndex + ".NMO", My.Settings.BallancePath.ToString & "\3D Entities\Level\Level_" + LevelIndex + ".NMO")
                ProgressBar.Value = 1
                MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Else
            labStatus.Text = "正在重置所有关卡..."
            If MsgBox("确认将所有关卡重置？该操作将不可恢复", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                My.Computer.FileSystem.CopyDirectory(Application.StartupPath & "\Data\Level", My.Settings.BallancePath.ToString & "\3D Entities\Level", True)
                ProgressBar.Value = 1
                MessageBox.Show("重置完成！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        End If
        TimerResetRapid.Enabled = True
    End Sub
    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        ResetLevel("")
    End Sub
    Private Sub BtnReset1_Click(sender As Object, e As EventArgs) Handles BtnReset1.Click
        ResetLevel("01")
    End Sub
    Private Sub BtnReset2_Click(sender As Object, e As EventArgs) Handles BtnReset2.Click
        ResetLevel("02")
    End Sub
    Private Sub BtnReset3_Click(sender As Object, e As EventArgs) Handles BtnReset3.Click
        ResetLevel("03")
    End Sub
    Private Sub BtnReset4_Click(sender As Object, e As EventArgs) Handles BtnReset4.Click
        ResetLevel("04")
    End Sub
    Private Sub BtnReset5_Click(sender As Object, e As EventArgs) Handles BtnReset5.Click
        ResetLevel("05")
    End Sub
    Private Sub BtnReset6_Click(sender As Object, e As EventArgs) Handles BtnReset6.Click
        ResetLevel("06")
    End Sub
    Private Sub BtnReset7_Click(sender As Object, e As EventArgs) Handles BtnReset7.Click
        ResetLevel("07")
    End Sub
    Private Sub BtnReset8_Click(sender As Object, e As EventArgs) Handles BtnReset8.Click
        ResetLevel("08")
    End Sub
    Private Sub BtnReset9_Click(sender As Object, e As EventArgs) Handles BtnReset9.Click
        ResetLevel("09")
    End Sub
    Private Sub BtnReset10_Click(sender As Object, e As EventArgs) Handles BtnReset10.Click
        ResetLevel("10")
    End Sub
    Private Sub BtnReset11_Click(sender As Object, e As EventArgs) Handles BtnReset11.Click
        ResetLevel("11")
    End Sub
    Private Sub BtnReset12_Click(sender As Object, e As EventArgs) Handles BtnReset12.Click
        ResetLevel("12")
    End Sub
    Private Sub BtnReset13_Click(sender As Object, e As EventArgs) Handles BtnReset13.Click
        ResetLevel("13")
    End Sub
    Private Sub TabMaps_Click(sender As Object, e As EventArgs) Handles TabMaps.Click
        ProgressBar.Value = 0
        ReloadLevels()
        labStatus.Text = "就绪"
    End Sub
    '===================================================lv1======================================================
    Private Sub InstallLevel(ByVal LevelIndex As String, ByVal listbox As ListBox)
        labStatus.Text = "正在将所选文件安装到 Level " & LevelIndex & "..."
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & listbox.SelectedItem.ToString & "安装到 Level " + LevelIndex + " 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Maps\" & listbox.SelectedItem, My.Settings.BallancePath.ToString & "\3D Entities\Level\Level_" + LevelIndex + ".NMO")
            ProgressBar.Value = 1
            MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
        TimerResetRapid.Enabled = True
    End Sub
    Private Sub BrowseInstall(ByVal LevelIndex As String)
        ProgressBar.Value = 0
        ProgressBar.Maximum = 1
        labStatus.Text = "正在将所选文件安装到 Level " & LevelIndex & "..."
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If MsgBox("确认将所选文件安装到 Level " + LevelIndex + " 吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
                FileCopy(OpenFileDialog1.FileName, My.Settings.BallancePath.ToString & "\3D Entities\Level\Level_" + LevelIndex + ".NMO")
                MessageBox.Show("安装成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If
        End If
        TimerResetRapid.Enabled = True
    End Sub
    Private Sub DeleteLevel(ByVal listbox As ListBox, ByVal delcheck As PictureBox)
        labStatus.Text = "正在删除所选文件..."
        If MsgBox("确认要删除" & listbox.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Maps\" & listbox.SelectedItem)
            listbox.Items.Clear()
            delcheck.Visible = False
            Dim FileNames() As String = Directory.GetFiles(Application.StartupPath & "\Maps")
            For i As Integer = 0 To FileNames.Length - 1
                listbox.Items.Add(Path.GetFileName(FileNames(i)))
            Next
        End If
        TimerResetRapid.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnInstall1.Click
        InstallLevel("01", ListBox1)
    End Sub
    Private Sub btnBrowse1_Click(sender As Object, e As EventArgs) Handles btnBrowse1.Click
        BrowseInstall("01")
    End Sub
    Private Sub delete1_Click(sender As Object, e As EventArgs) Handles delete1.Click
        DeleteLevel(ListBox1, delete1)
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        btnInstall1.Enabled = True
        delete1.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox1.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    '===================================================lv2======================================================
    Private Sub btnInstall2_Click(sender As Object, e As EventArgs) Handles btnInstall2.Click
        InstallLevel("02", ListBox2)
    End Sub
    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        btnInstall2.Enabled = True
        delete2.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox2.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    Private Sub btnBrowse2_Click(sender As Object, e As EventArgs) Handles btnBrowse2.Click
        BrowseInstall("02")
    End Sub
    Private Sub delete2_Click(sender As Object, e As EventArgs) Handles delete2.Click
        DeleteLevel(ListBox2, delete2)
    End Sub
    '===================================================lv3======================================================
    Private Sub btnInstall3_Click(sender As Object, e As EventArgs) Handles btnInstall3.Click
        InstallLevel("03", ListBox3)
    End Sub
    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        btnInstall3.Enabled = True
        delete3.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox3.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    Private Sub btnBrowse3_Click(sender As Object, e As EventArgs) Handles btnBrowse3.Click
        BrowseInstall("03")
    End Sub
    Private Sub delete3_Click(sender As Object, e As EventArgs) Handles delete3.Click
        DeleteLevel(ListBox3, delete3)
    End Sub
    '===================================================lv4======================================================
    Private Sub btnInstall4_Click(sender As Object, e As EventArgs) Handles btnInstall4.Click
        InstallLevel("04", ListBox4)
    End Sub
    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged
        btnInstall4.Enabled = True
        delete4.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox4.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    Private Sub btnBrowse4_Click(sender As Object, e As EventArgs) Handles btnBrowse4.Click
        BrowseInstall("04")
    End Sub
    Private Sub delete4_Click(sender As Object, e As EventArgs) Handles delete4.Click
        DeleteLevel(ListBox4, delete4)
    End Sub
    '===================================================lv5======================================================
    Private Sub btnInstall5_Click(sender As Object, e As EventArgs) Handles btnInstall5.Click
        InstallLevel("05", ListBox5)
    End Sub
    Private Sub ListBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox5.SelectedIndexChanged
        btnInstall5.Enabled = True
        delete5.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox5.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    Private Sub btnBrowse5_Click(sender As Object, e As EventArgs) Handles btnBrowse5.Click
        BrowseInstall("05")
    End Sub
    Private Sub delete5_Click(sender As Object, e As EventArgs) Handles delete5.Click
        DeleteLevel(ListBox5, delete5)
    End Sub
    '===================================================lv6======================================================
    Private Sub btnInstall6_Click(sender As Object, e As EventArgs) Handles btnInstall6.Click
        InstallLevel("06", ListBox6)
    End Sub
    Private Sub ListBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox6.SelectedIndexChanged
        btnInstall6.Enabled = True
        delete6.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox6.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    Private Sub btnBrowse6_Click(sender As Object, e As EventArgs) Handles btnBrowse6.Click
        BrowseInstall("06")
    End Sub
    Private Sub delete6_Click(sender As Object, e As EventArgs) Handles delete6.Click
        DeleteLevel(ListBox6, delete6)
    End Sub
    '===================================================lv7======================================================
    Private Sub btnInstall7_Click(sender As Object, e As EventArgs) Handles btnInstall7.Click
        InstallLevel("07", ListBox7)
    End Sub
    Private Sub ListBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox7.SelectedIndexChanged
        btnInstall7.Enabled = True
        delete7.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox7.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    Private Sub btnBrowse7_Click(sender As Object, e As EventArgs) Handles btnBrowse7.Click
        BrowseInstall("07")
    End Sub
    Private Sub delete7_Click(sender As Object, e As EventArgs) Handles delete7.Click
        DeleteLevel(ListBox7, delete7)
    End Sub
    '===================================================lv8======================================================
    Private Sub btnInstall8_Click(sender As Object, e As EventArgs) Handles btnInstall8.Click
        InstallLevel("08", ListBox8)
    End Sub
    Private Sub ListBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox8.SelectedIndexChanged
        btnInstall8.Enabled = True
        delete8.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox8.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    Private Sub btnBrowse8_Click(sender As Object, e As EventArgs) Handles btnBrowse8.Click
        BrowseInstall("08")
    End Sub
    Private Sub delete8_Click(sender As Object, e As EventArgs) Handles delete8.Click
        DeleteLevel(ListBox8, delete8)
    End Sub
    '===================================================lv9======================================================
    Private Sub btnInstall9_Click(sender As Object, e As EventArgs) Handles btnInstall9.Click
        InstallLevel("09", ListBox9)
    End Sub
    Private Sub ListBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox9.SelectedIndexChanged
        btnInstall9.Enabled = True
        delete9.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox9.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    Private Sub btnBrowse9_Click(sender As Object, e As EventArgs) Handles btnBrowse9.Click
        BrowseInstall("09")
    End Sub
    Private Sub delete9_Click(sender As Object, e As EventArgs) Handles delete9.Click
        DeleteLevel(ListBox9, delete9)
    End Sub
    '===================================================lv10======================================================
    Private Sub btnInstall10_Click(sender As Object, e As EventArgs) Handles btnInstall10.Click
        InstallLevel("10", ListBox10)
    End Sub
    Private Sub ListBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox10.SelectedIndexChanged
        btnInstall10.Enabled = True
        delete10.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox10.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    Private Sub btnBrowse10_Click(sender As Object, e As EventArgs) Handles btnBrowse10.Click
        BrowseInstall("10")
    End Sub
    Private Sub delete10_Click(sender As Object, e As EventArgs) Handles delete10.Click
        DeleteLevel(ListBox10, delete10)
    End Sub
    '===================================================lv11======================================================
    Private Sub btnInstall11_Click(sender As Object, e As EventArgs) Handles btnInstall11.Click
        InstallLevel("11", ListBox11)
    End Sub
    Private Sub ListBox11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox11.SelectedIndexChanged
        btnInstall11.Enabled = True
        delete11.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox11.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    Private Sub btnBrowse11_Click(sender As Object, e As EventArgs) Handles btnBrowse11.Click
        BrowseInstall("11")
    End Sub
    Private Sub delete11_Click(sender As Object, e As EventArgs) Handles delete11.Click
        DeleteLevel(ListBox11, delete11)
    End Sub
    '===================================================lv12======================================================
    Private Sub btnInstall12_Click(sender As Object, e As EventArgs) Handles btnInstall12.Click
        InstallLevel("12", ListBox12)
    End Sub
    Private Sub ListBox12_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox12.SelectedIndexChanged
        btnInstall12.Enabled = True
        delete12.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox12.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    Private Sub btnBrowse12_Click(sender As Object, e As EventArgs) Handles btnBrowse12.Click
        BrowseInstall("12")
    End Sub
    Private Sub delete12_Click(sender As Object, e As EventArgs) Handles delete12.Click
        DeleteLevel(ListBox12, delete12)
    End Sub
    '===================================================lv13======================================================
    Private Sub btnInstall13_Click(sender As Object, e As EventArgs) Handles btnInstall13.Click
        InstallLevel("13", ListBox13)
    End Sub
    Private Sub ListBox13_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox13.SelectedIndexChanged
        btnInstall13.Enabled = True
        Delete13.Visible = True
        Dim SelectedNMOPath As New System.IO.FileInfo(Application.StartupPath & "\Maps\" & ListBox13.SelectedItem)
        labStatus.Text = " 修改时间：" & SelectedNMOPath.LastWriteTime & "，文件长度：" & SelectedNMOPath.Length
    End Sub
    Private Sub btnBrowse13_Click(sender As Object, e As EventArgs) Handles btnBrowse13.Click
        BrowseInstall("13")
    End Sub
    Private Sub delete13_Click(sender As Object, e As EventArgs) Handles Delete13.Click
        DeleteLevel(ListBox13, Delete13)
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        labStatus.Text = "备份排行榜中..."
        FileCopy(My.Settings.BallancePath.ToString & "\Database.tdb", Application.StartupPath & "\Backup\" & Format(Now, "yyyy年MM月dd日 hh时mm分ss秒") & "的备份.bak")
        MessageBox.Show("排行榜备份成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        lstBackup.Items.Clear()
        Dim BackupFiles() As String = Directory.GetFiles(Application.StartupPath & "\Backup")
        If BackupFiles.Length = 0 Then
        Else
            For i As Integer = 0 To BackupFiles.Length - 1
                lstBackup.Items.Add(Path.GetFileName(BackupFiles(i)))
            Next
        End If
        TimerResetRapid.Enabled = True
        ProgressBar.Value = 1
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        labStatus.Text = "恢复排行榜中..."
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If MsgBox("确认将" & lstBackup.SelectedItem.ToString & "还原至 Ballance 目录吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            FileCopy(Application.StartupPath & "\Backup\" & lstBackup.SelectedItem, My.Settings.BallancePath.ToString & "\Database.tdb")
            ProgressBar.Value = 1
            MessageBox.Show("备份还原成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
        TimerResetRapid.Enabled = True
    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles PictureBox17.Click
        labStatus.Text = "删除排行榜中..."
        If MsgBox("确认要删除" & lstBackup.SelectedItem & "吗？", MsgBoxStyle.YesNo, "Ballamap") = MsgBoxResult.Yes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Backup\" & lstBackup.SelectedItem)
            PictureBox17.Visible = False
            lstBackup.Items.Clear()
            Dim BackupFiles() As String = Directory.GetFiles(Application.StartupPath & "\Backup")
            If BackupFiles.Length = 0 Then
            Else
                For i As Integer = 0 To BackupFiles.Length - 1
                    lstBackup.Items.Add(Path.GetFileName(BackupFiles(i)))
                Next
            End If
        End If
        TimerResetRapid.Enabled = True
    End Sub

    Private Sub lstBackup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBackup.SelectedIndexChanged
        PictureBox17.Visible = True
        btnRestore.Enabled = True
    End Sub


    Private Sub btnUpdate_Click() Handles btnUpdate.Click
        ProgressBar.Maximum = 5
        If File.Exists(Application.StartupPath & "\Data\BuildCache") Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Data\BuildCache")
            ProgressBar.Value = 1
            My.Computer.Network.DownloadFile("http://miraclest.sinaapp.com/support/Ballamap/newestversion.txt", Application.StartupPath & "\Data\BuildCache")
        Else
            My.Computer.Network.DownloadFile("http://miraclest.sinaapp.com/support/Ballamap/newestversion.txt", Application.StartupPath & "\Data\BuildCache")
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
        newestbuild = newestbuildcache
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
                            & "您可以在 http://eaglelions.ys168.com 下载该更新，现在是否帮您打开该网页？", "Ballamap 更新可用", MessageBoxButtons.YesNo,
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
        System.Diagnostics.Process.Start("https://github.com/Miraclest/Ballamap")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        System.Diagnostics.Process.Start("http://tieba.baidu.com/f?kw=ballance")
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        System.Diagnostics.Process.Start(Application.StartupPath & "\Update20151212.mht")
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        System.Diagnostics.Process.Start("http://www.miraclest.cn")
    End Sub

    Private Sub TabSky_Enter(sender As Object, e As EventArgs) Handles TabSky.Enter
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Data\Sky") = True Then
            grpSky.Visible = True
            btnLeading.Visible = False
        Else
            grpSky.Visible = False
            btnLeading.Visible = True
        End If
    End Sub

    Private Sub btnLeading_Click(sender As Object, e As EventArgs) Handles btnLeading.Click
        labStatus.Text = "正在从程序目录导入原版 Sky 资源，硬盘读写速度不同可能需要几秒到几十秒..."
        ProgressBar.Maximum = 100
        My.Computer.FileSystem.CopyDirectory(My.Settings.BallancePath.ToString & "\Textures\Sky", Application.StartupPath & "\Data\Sky")
        For i = 1 To 60
            ProgressBar.Value = i / 60 * ProgressBar.Maximum
        Next i
        Application.DoEvents()
        grpSky.Visible = True
        btnLeading.Visible = False
        MessageBox.Show("重要事项：" & vbCrLf & "注意！为了方便查看效果，天空图片在这里是经过旋转的！Sky_*_Front 和 Sky_*_Down 没有经过旋转，而 Sky_*_Left 逆时针旋转了 90° ， Sky_*_Right 顺时针旋转了 90°，Sky_*_Bakc 旋转了 180°。这不会影响到文件本身，所以：" & vbCrLf & "1、你是从其他地方下载的背景：您的文件应该是正常角度的，您无需担心，在这里只是经过了旋转。" & vbCrLf & "2、您是背景制作者：您应该有充足的经验判断您的图片角度是否正常，若您的图片角度是正常的，到这里经过旋转看起来 5 张图片将会是天衣无缝的，如果在这里经过旋转看起来图片角度除了差错，这通常是您的图片问题。" & vbCrLf & vbCrLf & "您以后可以单击右上角的感叹号再次查看该信息。", "重要事项", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        TimerResetRapid.Enabled = True
    End Sub
    Private Sub DisposePicuture()


        picSkyFront.BackgroundImage.Dispose()
        picSkyDown.BackgroundImage.Dispose()
        picSkyLeft.BackgroundImage.Dispose()
        picSkyRight.BackgroundImage.Dispose()
        picSkyBack.BackgroundImage.Dispose()
        If mapshow = True Then
            picSky1.BackgroundImage.Dispose()
            picSky2.BackgroundImage.Dispose()
            picSky3.BackgroundImage.Dispose()
            picSky4.BackgroundImage.Dispose()
            picSky5.BackgroundImage.Dispose()
            picSky6.BackgroundImage.Dispose()
            picSky7.BackgroundImage.Dispose()
            picSky8.BackgroundImage.Dispose()
            picSky9.BackgroundImage.Dispose()
            picSky10.BackgroundImage.Dispose()
            picSky11.BackgroundImage.Dispose()
            picSky12.BackgroundImage.Dispose()
            picSky13.BackgroundImage.Dispose()
            mapshow = False
        End If
    End Sub
    Private Sub SkyLoading(ByVal Sky As String)
        If Sky <> "" And radSky <> "Null" Then
            Dim skyfront As Image = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_" & Sky & "_Front.BMP")
            picSkyFront.BackgroundImage = skyfront
            Dim skyDown As Image = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_" & Sky & "_Down.BMP")
            picSkyDown.BackgroundImage = skyDown
            Dim skyleft As Image = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_" & Sky & "_Left.BMP")
            skyleft.RotateFlip(RotateFlipType.Rotate270FlipNone)
            picSkyLeft.BackgroundImage = skyleft
            Dim skyright As Image = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_" & Sky & "_Right.BMP")
            skyright.RotateFlip(RotateFlipType.Rotate90FlipNone)
            picSkyRight.BackgroundImage = skyright
            Dim skyback As Image = Image.FromFile(My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_" & Sky & "_Back.BMP")
            skyback.RotateFlip(RotateFlipType.Rotate180FlipNone)
            picSkyBack.BackgroundImage = skyback
        Else
            DisposePicuture()
        End If
    End Sub
    Dim radSky As String = "Null"
    Private Sub Skyrestore(ByVal Sky As String)
        SkyLoading("")
        If radSky <> "Null" Then
            FileCopy(Application.StartupPath & "\Data\Sky\Sky_" & Sky & ".BMP", TxtPath.Text & "\Textures\Sky\Sky_" & Sky & ".BMP")
            SkyLoading(radSky)
        End If
    End Sub

    Private Sub radSkyA_CheckedChanged(sender As Object, e As EventArgs) Handles radSkyA.CheckedChanged
        radSky = "A"
        DisposePicuture()
        SkyLoading("A")
    End Sub

    Private Sub radSkyB_CheckedChanged(sender As Object, e As EventArgs) Handles radSkyB.CheckedChanged
        radSky = "B"
        DisposePicuture()
        SkyLoading("B")

    End Sub

    Private Sub radSkyC_CheckedChanged(sender As Object, e As EventArgs) Handles radSkyC.CheckedChanged
        radSky = "C"
        DisposePicuture()
        SkyLoading("C")
    End Sub

    Private Sub radSkyE_CheckedChanged(sender As Object, e As EventArgs) Handles radSkyE.CheckedChanged
        radSky = "E"
        DisposePicuture()
        SkyLoading("E")
    End Sub
    Private Sub radSkyD_CheckedChanged(sender As Object, e As EventArgs) Handles radSkyD.CheckedChanged
        radSky = "D"
        DisposePicuture()
        SkyLoading("D")
    End Sub
    Private Sub radSkyF_CheckedChanged(sender As Object, e As EventArgs) Handles radSkyF.CheckedChanged
        radSky = "F"
        DisposePicuture()
        SkyLoading("F")
    End Sub

    Private Sub radSkyG_CheckedChanged(sender As Object, e As EventArgs) Handles radSkyG.CheckedChanged
        radSky = "G"
        DisposePicuture()
        SkyLoading("G")
    End Sub

    Private Sub radSkyH_CheckedChanged(sender As Object, e As EventArgs) Handles radSkyH.CheckedChanged
        radSky = "H"
        DisposePicuture()
        SkyLoading("H")
    End Sub

    Private Sub radSkyI_CheckedChanged(sender As Object, e As EventArgs) Handles radSkyI.CheckedChanged
        radSky = "I"
        DisposePicuture()
        SkyLoading("I")
    End Sub

    Private Sub radSkyJ_CheckedChanged(sender As Object, e As EventArgs) Handles radSkyJ.CheckedChanged
        radSky = "J"
        DisposePicuture()
        SkyLoading("J")
    End Sub

    Private Sub radSkyK_CheckedChanged(sender As Object, e As EventArgs) Handles radSkyK.CheckedChanged
        radSky = "K"
        DisposePicuture()
        SkyLoading("K")
    End Sub

    Private Sub radSkyL_CheckedChanged(sender As Object, e As EventArgs) Handles radSkyL.CheckedChanged
        radSky = "L"
        DisposePicuture()
        SkyLoading("L")
    End Sub


    Private Sub chkAutoUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoUpdate.CheckedChanged
        My.Settings.AutoUpdate = chkAutoUpdate.Checked
    End Sub
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        MessageBox.Show("重要事项：" & vbCrLf & "注意！为了方便查看效果，天空图片在这里是经过旋转的！Sky_*_Front 和 Sky_*_Down 没有经过旋转，而 Sky_*_Left 逆时针旋转了 90° ， Sky_*_Right 顺时针旋转了 90°，Sky_*_Bakc 旋转了 180°。这不会影响到文件本身，所以：" & vbCrLf & "1、你是从其他地方下载的背景：您的文件应该是正常角度的，您无需担心，在这里只是经过了旋转。" & vbCrLf & "2、您是背景制作者：您应该有充足的经验判断您的图片角度是否正常，若您的图片角度是正常的，到这里经过旋转看起来 5 张图片将会是天衣无缝的，如果在这里经过旋转看起来图片角度除了差错，这通常是您的图片问题。" & vbCrLf & vbCrLf & "您以后可以单击右上角的感叹号再次查看该信息。", "重要事项", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    End Sub

    Private Sub picRestoreFront_Click(sender As Object, e As EventArgs) Handles picRestoreFront.Click

        Skyrestore(radSky & "_Front")
    End Sub
    Private Sub picRestoreDown_Click(sender As Object, e As EventArgs) Handles picRestoreDown.Click
        Skyrestore(radSky & "_Down")
    End Sub

    Private Sub picRestoreLeft_Click(sender As Object, e As EventArgs) Handles picRestoreLeft.Click
        Skyrestore(radSky & "_Left")
    End Sub

    Private Sub picRestoreRight_Click(sender As Object, e As EventArgs) Handles picRestoreRight.Click
        Skyrestore(radSky & "_Right")
    End Sub

    Private Sub picRestoreBack_Click(sender As Object, e As EventArgs) Handles picRestoreBack.Click
        Skyrestore(radSky & "_Back")
    End Sub

    Private Sub btnRestoreTheme_Click(sender As Object, e As EventArgs) Handles btnRestoreTheme.Click
        labStatus.Text = "正在还原选定主题..."
        If MessageBox.Show("确认要还原该主题至官方主题吗？该操作将不可恢复！", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            DisposePicuture()

            ProgressBar.Maximum = 5
            ProgressBar.Value = 0
            FileCopy(Application.StartupPath & "\Data\Sky\Sky_" & radSky & "_Front.BMP", My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_" & radSky & "_Front.BMP")
            ProgressBar.Value = 1
            FileCopy(Application.StartupPath & "\Data\Sky\Sky_" & radSky & "_Down.BMP", My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_" & radSky & "_Down.BMP")
            ProgressBar.Value = 2
            FileCopy(Application.StartupPath & "\Data\Sky\Sky_" & radSky & "_Left.BMP", My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_" & radSky & "_Left.BMP")
            ProgressBar.Value = 3
            FileCopy(Application.StartupPath & "\Data\Sky\Sky_" & radSky & "_Right.BMP", My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_" & radSky & "_Right.BMP")
            ProgressBar.Value = 4
            FileCopy(Application.StartupPath & "\Data\Sky\Sky_" & radSky & "_Back.BMP", My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_" & radSky & "_Back.BMP")
            ProgressBar.Value = 5
            MessageBox.Show("该主题已经还原成功！", "Ballamap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            SkyLoading(radSky)
        End If
        TimerResetRapid.Enabled = True
    End Sub

    Private Sub btnRestoreAll_Click(sender As Object, e As EventArgs) Handles btnRestoreAll.Click
        labStatus.Text = "正在还原所有主题..."
        If MessageBox.Show("确定要将 所有主题 都还原为官方主题吗？该操作将不可恢复！", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes _
            And MessageBox.Show("再次确认：确定要将 所有主题 都还原为官方主题吗？该操作真的不可恢复！！！！", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            DisposePicuture()
            ProgressBar.Maximum = 100
            My.Computer.FileSystem.DeleteDirectory(My.Settings.BallancePath.ToString & "\Textures\Sky", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            My.Computer.FileSystem.CopyDirectory(Application.StartupPath & "\Data\Sky", My.Settings.BallancePath.ToString & "\Textures\Sky")
            For i = 1 To 60
                ProgressBar.Value = i / 60 * ProgressBar.Maximum
            Next i
            Application.DoEvents()
        End If
        MessageBox.Show("还原成功！", "Ballamap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        SkyLoading(radSky)
        TimerResetRapid.Enabled = True
    End Sub
    Private Sub EditSky(ByVal Sky As String)
        labStatus.Text = "正在编辑主题..."
        ProgressBar.Maximum = 1
        ProgressBar.Value = 0
        If OpenFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            If MessageBox.Show("确认将您选择的文件替换至 Sky_" & Sky & ".BMP 吗？", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                DisposePicuture()
                FileCopy(OpenFileDialog2.FileName, My.Settings.BallancePath.ToString & "\Textures\Sky\Sky_" & Sky & ".BMP")
                MessageBox.Show("替换成功！", "Ballamnap", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ProgressBar.Value = 1
            End If
        End If
        OpenFileDialog2.Dispose()
        SkyLoading(radSky)
        TimerResetRapid.Enabled = True
    End Sub

    Private Sub picEditFront_Click(sender As Object, e As EventArgs) Handles picEditFront.Click
        labStatus.Text = "正在编辑 Sky_" & radSky & "_Front.BMP"
        If radSky <> "Null" Then
            OpenFileDialog2.Title = "请选择您的文件，将替换至 Sky_" & radSky & "_Front.BMP"
            EditSky(radSky & "_Front")
        End If
        TimerResetRapid.Enabled = True
    End Sub

    Private Sub picEditLeft_Click(sender As Object, e As EventArgs) Handles picEditLeft.Click
        labStatus.Text = "正在编辑 Sky_" & radSky & "_Left.BMP"
        If radSky <> "Null" Then
            OpenFileDialog2.Title = "请选择您的文件，将替换至 Sky_" & radSky & "_Left.BMP"
            EditSky(radSky & "_Left")
        End If
        TimerResetRapid.Enabled = True
    End Sub

    Private Sub PicEditDown_Click(sender As Object, e As EventArgs) Handles PicEditDown.Click
        labStatus.Text = "正在编辑 Sky_" & radSky & "_Down.BMP"
        If radSky <> "Null" Then
            OpenFileDialog2.Title = "请选择您的文件，将替换至 Sky_" & radSky & "_Down.BMP"
            EditSky(radSky & "_Down")
        End If
        TimerResetRapid.Enabled = True
    End Sub

    Private Sub picEditRight_Click(sender As Object, e As EventArgs) Handles picEditRight.Click
        labStatus.Text = "正在编辑 Sky_" & radSky & "_Right.BMP"
        If radSky <> "Null" Then
            OpenFileDialog2.Title = "请选择您的文件，将替换至 Sky_" & radSky & "_Right.BMP"
            EditSky(radSky & "_Right")
        End If
        TimerResetRapid.Enabled = True
    End Sub

    Private Sub PicEditBack_Click(sender As Object, e As EventArgs)
        labStatus.Text = "正在编辑 Sky_" & radSky & "_Back.BMP"
        If radSky <> "Null" Then
            OpenFileDialog2.Title = "请选择您的文件，将替换至 Sky_" & radSky & "_Back.BMP"
            EditSky(radSky & "_Back")
        End If
        TimerResetRapid.Enabled = True
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click, Label29.Click, Label30.Click

    End Sub

    Private Sub OpenFileDialog2_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk

    End Sub



    Private Sub btnFix_x86_Click(sender As Object, e As EventArgs) Handles btnFix_x86.Click
        If Environment.Is64BitOperatingSystem = True Then
            Me.Cursor = Cursors.AppStarting
            ProgressBar.Value = ３
            Me.labStatus.Text = "正在修复 Ballance 注册表项..."
            File.Copy(Application.StartupPath & "\Data\Tools\Fix32.reg", Application.StartupPath & "\Data\Tools\Fix32+.reg", True)
            If MessageBox.Show("您确定要进行修复程序吗？", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes _
            And MessageBox.Show("请再次确认您的系统为 64 位。确认后将开始修复注册表项，请在接下来弹出的授权框中选择是。", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Dim fix64 As System.IO.StreamWriter = New System.IO.StreamWriter(Application.StartupPath & "\Data\Tools\Fix32+.reg", True, System.Text.Encoding.Unicode)
                Dim PathReg As String = txtPath.Text.Replace("\", "\\")
                ProgressBar.Value = 9
                fix64.WriteLine(Chr(34) & "TargetDir" & Chr(34) & "=" & Chr(34) & PathReg & Chr(34))
                fix64.Close()
                System.Threading.Thread.Sleep(1000)
                System.Diagnostics.Process.Start(Application.StartupPath & "\Data\Tools\Fix32+.reg")
            End If
            System.Threading.Thread.Sleep(3000)
            ProgressBar.Value = 13
            Me.Cursor = Cursors.Default
            TimerResetRapid.Enabled = True
        Else
            Me.Cursor = Cursors.AppStarting
            ProgressBar.Value = ３
            Me.labStatus.Text = "正在修复 Ballance 注册表项..."
            File.Copy(Application.StartupPath & "\Data\Tools\Fix64.reg", Application.StartupPath & "\Data\Tools\Fix64+.reg", True)
            If MessageBox.Show("您确定要进行修复程序吗？", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes _
                And MessageBox.Show("请再次确认您的系统为 64 位。确认后将开始修复注册表项，请在接下来弹出的授权框中选择是。", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Dim fix64 As System.IO.StreamWriter = New System.IO.StreamWriter(Application.StartupPath & "\Data\Tools\Fix64+.reg", True, System.Text.Encoding.Unicode)
                Dim PathReg As String = txtPath.Text.Replace("\", "\\")
                ProgressBar.Value = 9
                fix64.WriteLine(Chr(34) & "TargetDir" & Chr(34) & "=" & Chr(34) & PathReg & Chr(34))
                fix64.Close()
                System.Threading.Thread.Sleep(1000)
                System.Diagnostics.Process.Start(Application.StartupPath & "\Data\Tools\Fix64+.reg")
            End If
            System.Threading.Thread.Sleep(3000)
            ProgressBar.Value = 13
            Me.Cursor = Cursors.Default
            TimerResetRapid.Enabled = True
        End If

    End Sub



    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click
        Label27.Text = "双十二快乐！"
    End Sub

    Private Sub TabAbout_Enter(sender As Object, e As EventArgs) Handles TabAbout.Enter
        Label27.Text = "（Build 1300）"
    End Sub

    Private Sub btnTitleApply_Click(sender As Object, e As EventArgs) Handles btnTitleApply.Click
        My.Settings.Title = txtTitle.Text.ToString
        Me.Text = txtTitle.Text.ToString
    End Sub

    Private Sub btnTitleRestore_Click(sender As Object, e As EventArgs) Handles btnTitleRestore.Click
        My.Settings.Title = "Ballamap （Ballance 地图管理器）"
        Me.Text = "Ballamap （Ballance 地图管理器）"
        txtTitle.Text = "Ballamap （Ballance 地图管理器）"
    End Sub

    Private Sub Tab_Enter(sender As Object, e As EventArgs) Handles Tab.Enter

    End Sub

    Private Sub TabTool_Enter(sender As Object, e As EventArgs) Handles TabTool.Enter
        txtTitle.Text = Me.Text
    End Sub

    Private Sub btnFullscreen_Click(sender As Object, e As EventArgs) Handles btnFullscreen.Click
        labStatus.Text = "正在将程序设置为全屏模式..."
        If Environment.Is64BitOperatingSystem = True Then
            If MessageBox.Show("您确定要将 Ballance 设置为全屏模式吗？", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ProgressBar.Value = 9
                System.Threading.Thread.Sleep(500)
                System.Diagnostics.Process.Start(Application.StartupPath & "\Data\Tools\Fullscreen64.reg")
                ProgressBar.Value = 13
            End If

        Else
            If MessageBox.Show("您确定要将 Ballance 设置为全屏模式吗？", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ProgressBar.Value = 9
                System.Threading.Thread.Sleep(500)
                System.Diagnostics.Process.Start(Application.StartupPath & "\Data\Tools\Fullscreen32.reg")
                ProgressBar.Value = 13
            End If

        End If
        TimerResetRapid.Enabled = True
    End Sub

    Private Sub btnWindow_Click(sender As Object, e As EventArgs) Handles btnWindow.Click
        labStatus.Text = "正在将程序设置为窗口化运行模式..."
        If Environment.Is64BitOperatingSystem = True Then
            If MessageBox.Show("您确定要将 Ballance 设置为窗口模式吗？", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ProgressBar.Value = 9
                System.Threading.Thread.Sleep(500)
                System.Diagnostics.Process.Start(Application.StartupPath & "\Data\Tools\Window64.reg")
                ProgressBar.Value = 13
            End If

        Else
            If MessageBox.Show("您确定要将 Ballance 设置为窗口模式吗？", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ProgressBar.Value = 9
                System.Threading.Thread.Sleep(500)
                System.Diagnostics.Process.Start(Application.StartupPath & "\Data\Tools\Window32.reg")
                ProgressBar.Value = 13
            End If

        End If
        TimerResetRapid.Enabled = True
    End Sub

    Private Sub TabMapDownload_Enter(sender As Object, e As EventArgs) Handles TabMapDownload.Enter
        Dim url As New Uri("http://www.1807472016.ys168.com/")
        WebBrowser1.Url = url
    End Sub
    Private Sub AutoUpdateCheking()
        If My.Settings.AutoUpdate = True Then
            If File.Exists(Application.StartupPath & "\Data\BuildCache") Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Data\BuildCache")

                My.Computer.Network.DownloadFile("http://miraclest.sinaapp.com/support/Ballamap/newestversion.txt", Application.StartupPath & "\Data\BuildCache")
            Else
                My.Computer.Network.DownloadFile("http://miraclest.sinaapp.com/support/Ballamap/newestversion.txt", Application.StartupPath & "\Data\BuildCache")
            End If

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

            newestbuild = newestbuildcache
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

            If newestbuild > buildnow Then
                If MessageBox.Show("新版本可用！" & vbCrLf & "最新版本：Build " & newestbuild & vbCrLf & "当前版本：Build " & buildnow & vbCrLf _
                                & "您可以在 http://eaglelions.ys168.com 下载该更新，现在是否帮您打开该网页？", "Ballamap 更新可用", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    System.Diagnostics.Process.Start("http://eaglelions.ys168.com")

                End If

            Else
                labStatus.Text = "当前的 Build " & buildnow & " 已是最新版本！"


            End If
        End If
        TimerUpdate.Enabled = False

    End Sub
    Private Sub TimerUpdate_Tick(sender As Object, e As EventArgs) Handles TimerUpdate.Tick
        labStatus.Text = "正在检查更新..."

        Dim auc As Threading.Thread
        auc = New Threading.Thread(AddressOf AutoUpdateCheking)
        auc.Start()
        TimerUpdate.Enabled = False
    End Sub

    Private Sub ToolStripbtnRun_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripbtnRun.ButtonClick
        Shell(My.Settings.BallancePath.ToString & "\Startup.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub ToolStripMenuBtnRun_Click(sender As Object, e As EventArgs) Handles ToolStripMenuBtnRun.Click
        Shell(My.Settings.BallancePath.ToString & "\Startup.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuRed.Click
        TabWelcome.Text = "Hi,There!"
        Label1.Text = "Hello, This's Bill Chen!:)"
        Label1.Font = New System.Drawing.Font("微软雅黑", 36, FontStyle.Italic)
        Label1.ForeColor = Color.Tomato
        Label2.ForeColor = Color.Tomato
        Label2.Text = "Long time no see, " & Environment.GetEnvironmentVariable("USERNAME") & "!"
        Label3.Text = "Greeted From Panzhihua, Sichauan, China By EagleLions."
        Label3.ForeColor = Color.Tomato
    End Sub

    Private Sub TimerReset_Tick(sender As Object, e As EventArgs) Handles TimerReset.Tick

        labStatus.Text = "就绪"

    End Sub

    Dim SettingState As Boolean = False
    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        If SettingState = False Then
            Me.Width = "970"
            SettingState = True
            btnSetting.Text = "返回 <<"
        Else
            Me.Width = "720"
            SettingState = False
            btnSetting.Text = "设置 >>"
        End If
        labStatus.Text = "就绪"
        If My.Settings.Theme = "Bright" Then
            radBright.Checked = True
        Else
            radDark.Checked = True
        End If
    End Sub




    Private Sub btnRestoreB_Click(sender As Object, e As EventArgs) Handles btnRestoreB.Click
        If MessageBox.Show("确定要重置程序吗？您的 Ballamap 程序个人设置（如目录等）将会恢复为默认状态。", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes _
        And MessageBox.Show("操作不可恢复，您的背景管理数据也将被清除。以后您可能需要重新导入。您的自定义地图和备份的排行榜将不会丢失。", "Ballamap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Directory.Exists(Application.StartupPath & "\Data\Sky") = True Then
                Directory.Delete(Application.StartupPath & "\Data\Sky", True)
            End If
            Me.Visible = False
            My.Settings.AutoUpdate = True
            My.Settings.BallancePath = "None"
            My.Settings.Firstrun = True
            My.Settings.Title = "Ballamap （Ballance 地图管理器）"

            Shell(Application.StartupPath & "\Ballamap.exe", vbNormalFocus)
            End

        End If
    End Sub

    Private Sub txtPath_Click(sender As Object, e As EventArgs) Handles txtPath.Click
        labStatus.Text = "您的 Ballance 目录为：" & txtPath.Text & "需要更改请返回后选择浏览。"

    End Sub

    Private Sub btnUpdateSetting_Click(sender As Object, e As EventArgs) Handles btnUpdateSetting.Click
        TimerUpdate.Enabled = True
    End Sub

    Private Sub TimerResetRapid_Tick(sender As Object, e As EventArgs) Handles TimerResetRapid.Tick
        labStatus.Text = "就绪"
        TimerResetRapid.Enabled = False
    End Sub

    Private Sub 程序设置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 程序设置ToolStripMenuItem.Click
        btnSetting_Click(sender, e)
    End Sub

    Private Sub labNMOinf_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabMapDownload_Click(sender As Object, e As EventArgs) Handles TabMapDownload.Click

    End Sub

    Private Sub TabLevelState_Enter(sender As Object, e As EventArgs) Handles TabLevelState.Enter
        labLast.Text = "上次检查：" & My.Settings.LastChecked
    End Sub

End Class
