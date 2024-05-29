Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text

Public Class Form1
        Dim SW As StreamWriter
        '빌드되는 폴더 경로 가져오기...
        Dim strCheckFolder As String = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\"))

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function GetPrivateProfileString(Section As [String], key As [String], def As [String], retVal As StringBuilder, size As Integer, filepath As [String]) As Integer
    End Function

    'setinivalue를 위한 모듈
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function WritePrivateProfileString(section As [String], key As [String], Val As [String], filepath As [String]) As Long
    End Function


    Private Function GetiniValue(section As [String], key As [String], inipath As [String]) As [String]
        Dim temp As StringBuilder = New StringBuilder(255)
        Dim i As Integer = GetPrivateProfileString(section, key, "", temp, 255, inipath)
        Return temp.ToString()
    End Function


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBox1.Items.AddRange(File.ReadAllLines(".\gamelist_arcade.cfg"))
        ComboBox4.Items.AddRange(File.ReadAllLines(".\gamelist_arcade.cfg"))
        ComboBox7.Items.AddRange(File.ReadAllLines(".\gamelist_arcade.cfg"))
        ComboBox9.Items.AddRange(File.ReadAllLines(".\gamelist_snes9x.cfg"))

        ComboBox2.Items.Add("Player 1")
        ComboBox2.Items.Add("Player 2")
        ComboBox3.Items.Add("Player 1")
        ComboBox3.Items.Add("Player 2")
        ComboBox6.Items.Add("Player 1")
        ComboBox6.Items.Add("Player 2")
        ComboBox8.Items.Add("Player 1")
        ComboBox8.Items.Add("Player 2")
        '   ComboBox7.SelectedIndex = 0
        '  ComboBox1.SelectedIndex = 0
        '   ComboBox4.SelectedIndex = 0
        '   ComboBox2.SelectedIndex = 0
        '  ComboBox3.SelectedIndex = 0
        '  ComboBox6.SelectedIndex = 0
        ComboBox5.Items.Add("Select Cpu values")
        ComboBox5.Items.Add("Default(100%)")
        ComboBox5.Items.Add("Overclock 150%")
        ComboBox5.Items.Add("Overclock 200%")
        ComboBox5.Items.Add("Overclock 250%")
        ComboBox5.Items.Add("Overclock 300%")
        ComboBox5.Items.Add("Overclock 400%")
        ComboBox5.Items.Add("Overclock 500%")
        ComboBox5.Items.Add("Overclock 533%%")
        ComboBox5.SelectedIndex = 1

        ComboBox1.Text = GetiniValue("GGPOFBA", "Game", Application.StartupPath & "\setting.ini")
        TextBox1.Text = GetiniValue("GGPOFBA", "ip", Application.StartupPath & "\setting.ini")
        TextBox21.Text = GetiniValue("GGPOFBA", "My Port", Application.StartupPath & "\setting.ini")
        TextBox20.Text = GetiniValue("GGPOFBA", "Partner Port", Application.StartupPath & "\setting.ini")

        ComboBox4.Text = GetiniValue("FC2", "Game", Application.StartupPath & "\setting.ini")
        TextBox8.Text = GetiniValue("FC2", "ip", Application.StartupPath & "\setting.ini")
        TextBox2.Text = GetiniValue("FC2", "My Port", Application.StartupPath & "\setting.ini")
        TextBox3.Text = GetiniValue("FC2", "Partner Port", Application.StartupPath & "\setting.ini")
        TextBox4.Text = GetiniValue("FC2", "Delay", Application.StartupPath & "\setting.ini")

        ComboBox7.Text = GetiniValue("Overclock", "Game", Application.StartupPath & "\setting.ini")
        TextBox19.Text = GetiniValue("Overclock", "ip", Application.StartupPath & "\setting.ini")
        TextBox7.Text = GetiniValue("Overclock", "My Port", Application.StartupPath & "\setting.ini")
        TextBox6.Text = GetiniValue("Overclock", "Partner Port", Application.StartupPath & "\setting.ini")
        TextBox5.Text = GetiniValue("Overclock", "Delay", Application.StartupPath & "\setting.ini")

        ComboBox9.Text = GetiniValue("Snes9x", "Game", Application.StartupPath & "\setting.ini")
        TextBox9.Text = GetiniValue("Snes9x", "ip", Application.StartupPath & "\setting.ini")
        TextBox12.Text = GetiniValue("Snes9x", "My Port", Application.StartupPath & "\setting.ini")
        TextBox11.Text = GetiniValue("Snes9x", "Partner Port", Application.StartupPath & "\setting.ini")
        TextBox10.Text = GetiniValue("Snes9x", "Delay", Application.StartupPath & "\setting.ini")

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click   '구버전 ggpofba p2p
        Dim strCmdText As String = "/c %cd%\emulator\ggpofba\ggpofba-ng.exe quark:direct,"      '/c : 실행 후 cmd 창 제거, /k : 실행 후 cmd 창 유지
        Dim game As String
        Dim address As String
        Dim port1 As Int32
        Dim port2 As Int32
        Dim position As Int32
        Dim direct As String
        Dim window As String
        Dim directwindows As String

        If ComboBox7.Text = "" Then
            MessageBox.Show("No Games Selected!", "Notification")
            Return
        End If

        If TextBox1.Text = "" Then
            MessageBox.Show("IP address blanked!", "Notification")
            Return
        End If

        If TextBox21.Text = "" Then
            MessageBox.Show("please input your port!", "Notification")
            Return
        End If

        If TextBox20.Text = "" Then
            MessageBox.Show("please input your partner's port!", "Notification")
            Return
        End If

        game = ComboBox7.Text.ToString()
        address = TextBox1.Text.ToString()
        port1 = TextBox21.Text
        port2 = TextBox20.Text
        position = ComboBox6.SelectedIndex
        window = "-w"

        direct = strCmdText & game & "," & port1 & "," & address & "," & port2 & "," & position
        directwindows = strCmdText & game & "," & port1 & "," & address & "," & port2 & "," & position & " " & window

        If Me.CheckBox2.Checked = True Then
            System.Diagnostics.Process.Start("CMD.exe", directwindows)
        End If
        If Me.CheckBox2.Checked = False Then
            System.Diagnostics.Process.Start("CMD.exe", direct)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click  '공식 파이트케이드
        Dim strCmdText As String = "/c %cd%\emulator\fbneo\fcadefbneo.exe quark:direct,"      '/c : 실행 후 cmd 창 제거, /k : 실행 후 cmd 창 유지
        Dim game As String
        Dim address As String
        Dim port1 As Int32
        Dim port2 As Int32
        Dim position As Int32
        Dim delay As Int32
        Dim direct As String
        Dim window As String
        Dim directwindows As String

        If ComboBox1.Text = "" Then
            MessageBox.Show("No Games Selected!", "Notification")
            Return
        End If

        If TextBox8.Text = "" Then
            MessageBox.Show("IP address blanked!", "Notification")
            Return
        End If

        If TextBox2.Text = "" Then
            MessageBox.Show("please input your port!", "Notification")
            Return
        End If

        If TextBox3.Text = "" Then
            MessageBox.Show("please input your partner's port!", "Notification")
            Return
        End If

        If TextBox4.Text = "" Then
            delay = 0
        End If

        game = ComboBox1.Text.ToString()
        address = TextBox8.Text.ToString()
        port1 = TextBox2.Text
        port2 = TextBox3.Text
        position = ComboBox2.SelectedIndex
        delay = TextBox4.Text
        window = "-w"

        direct = strCmdText & game & "," & port1 & "," & address & "," & port2 & "," & position & "," & delay
        directwindows = strCmdText & game & "," & port1 & "," & address & "," & port2 & "," & position & "," & delay & " " & window

        If Me.CheckBox2.Checked = True Then
            System.Diagnostics.Process.Start("CMD.exe", directwindows)
        End If
        If Me.CheckBox2.Checked = False Then
            System.Diagnostics.Process.Start("CMD.exe", direct)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click  '오버클럭 p2p 런처
        Dim strCmdText As String = "/c %cd%\emulator\fbneo\fcadeoverclock.exe quark:unity,"      '/c : 실행 후 cmd 창 제거, /k : 실행 후 cmd 창 유지
        Dim game As String
        Dim address As String
        Dim port1 As Int32
            Dim port2 As Int32
            Dim position As Int32
            Dim delay As Int32
            Dim overclock As Int32
            Dim unity As String
        Dim unitywindow As String
        Dim window As String

        If ComboBox4.Text = "" Then
            MessageBox.Show("No Games Selected!", "Notification")
            Return
        End If

        If TextBox19.Text = "" Then
            MessageBox.Show("IP address blanked!", "Notification")
            Return
        End If

        If TextBox7.Text = "" Then
            MessageBox.Show("please input your port!", "Notification")
            Return
        End If

        If TextBox6.Text = "" Then
            MessageBox.Show("please input your partner's port!", "Notification")
            Return
        End If

        If TextBox5.Text = "" Then
            delay = 0
        End If

        game = ComboBox4.Text.ToString()
        address = TextBox19.Text.ToString()
        port1 = TextBox7.Text
        port2 = TextBox6.Text
        position = ComboBox3.SelectedIndex
        delay = TextBox5.Text
        overclock = ComboBox5.SelectedIndex
        window = "-w"

        unity = strCmdText & game & "," & port1 & "," & address & "," & port2 & "," & position & "," & overclock & "," & delay
        unitywindow = strCmdText & game & "," & port1 & "," & address & "," & port2 & "," & position & "," & overclock & "," & delay & " " & window

        If Me.CheckBox2.Checked = True Then
                System.Diagnostics.Process.Start("CMD.exe", unitywindow)
            End If
            If Me.CheckBox2.Checked = False Then
            System.Diagnostics.Process.Start("CMD.exe", unity)
        End If
        End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click   'snes9x start
        Dim strCmdText As String = "/c %cd%\emulator\snes9x\fcadesnes9x.exe quark:direct,"      '/c : 실행 후 cmd 창 제거, /k : 실행 후 cmd 창 유지
        Dim game As String
        Dim address As String
        Dim port1 As Int32
        Dim port2 As Int32
        Dim position As Int32
        Dim delay As Int32
        Dim direct As String
        Dim window As String
        Dim directwindows As String

        If ComboBox9.Text = "" Then
            MessageBox.Show("No Games Selected!", "Notification")
            Return
        End If

        If TextBox9.Text = "" Then
            MessageBox.Show("IP address blanked!", "Notification")
            Return
        End If

        If TextBox12.Text = "" Then
            MessageBox.Show("please input your port!", "Notification")
            Return
        End If

        If TextBox11.Text = "" Then
            MessageBox.Show("please input your partner's port!", "Notification")
            Return
        End If

        If TextBox10.Text = "" Then
            delay = 0
        End If

        game = ComboBox9.Text.ToString()
        address = TextBox9.Text.ToString()
        port1 = TextBox12.Text
        port2 = TextBox11.Text
        position = ComboBox8.SelectedIndex
        delay = TextBox10.Text
        window = "-w"

        direct = strCmdText & game & "," & port1 & "," & address & "," & port2 & "," & position & "," & delay
        directwindows = strCmdText & game & "," & port1 & "," & address & "," & port2 & "," & position & "," & delay & " " & window

        If Me.CheckBox2.Checked = True Then
            System.Diagnostics.Process.Start("CMD.exe", directwindows)
        End If
        If Me.CheckBox2.Checked = False Then
            System.Diagnostics.Process.Start("CMD.exe", direct)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click   'fc1
        WritePrivateProfileString("GGPOFBA", "Game", ComboBox1.SelectedItem, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("GGPOFBA", "ip", TextBox1.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("GGPOFBA", "My Port", TextBox21.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("GGPOFBA", "Partner Port", TextBox20.Text, Application.StartupPath & "\setting.ini")
        MessageBox.Show("Setting saved")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles setting2.Click  'fc2
        WritePrivateProfileString("FC2", "Game", ComboBox4.SelectedItem, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("FC2", "ip", TextBox8.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("FC2", "My Port", TextBox2.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("FC2", "Partner Port", TextBox3.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("FC2", "delay", TextBox4.Text, Application.StartupPath & "\setting.ini")
        MessageBox.Show("Setting saved")
    End Sub

    Private Sub setting3_Click(sender As Object, e As EventArgs) Handles setting3.Click    'overclock
        WritePrivateProfileString("Overclock", "Game", ComboBox7.SelectedItem, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Overclock", "ip", TextBox19.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Overclock", "My Port", TextBox7.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Overclock", "Partner Port", TextBox6.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Overclock", "delay", TextBox5.Text, Application.StartupPath & "\setting.ini")
        MessageBox.Show("Setting saved")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click     'snes9x setting save
        WritePrivateProfileString("Snes9x", "Game", ComboBox9.SelectedItem, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Snes9x", "ip", TextBox9.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Snes9x", "My Port", TextBox12.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Snes9x", "Partner Port", TextBox11.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Snes9x", "delay", TextBox10.Text, Application.StartupPath & "\setting.ini")
        MessageBox.Show("Setting saved")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("MicrosoftEdge.exe", "https://chamcham425.blogspot.com/2020/09/blog-post.html")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("MicrosoftEdge.exe", "https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=jicdoo&logNo=220822978434")
    End Sub

End Class