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

        ComboBox1.Items.AddRange(File.ReadAllLines(".\gamelist.cfg"))
        ComboBox4.Items.AddRange(File.ReadAllLines(".\gamelist.cfg"))
        ComboBox7.Items.AddRange(File.ReadAllLines(".\gamelist.cfg"))
        ComboBox2.Items.Add("Player 1")
        ComboBox2.Items.Add("Player 2")
        ComboBox3.Items.Add("Player 1")
        ComboBox3.Items.Add("Player 2")
        ComboBox6.Items.Add("Player 1")
        ComboBox6.Items.Add("Player 2")
        ComboBox1.SelectedIndex = 0
        ComboBox4.SelectedIndex = 0
        ComboBox7.SelectedIndex = 0
        ComboBox6.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        ComboBox5.Items.Add("Select Cpu values")
        ComboBox5.Items.Add("Default(100%)")
        ComboBox5.Items.Add("Overclock 150%")
        ComboBox5.Items.Add("Overclock 200%")
        ComboBox5.Items.Add("Overclock 250%")
        ComboBox5.Items.Add("Overclock 300%")
        ComboBox5.Items.Add("Overclock 400%")
        ComboBox5.Items.Add("Overclock 500%")
        ComboBox5.SelectedIndex = 1

        ComboBox1.Text = GetiniValue("GGPOFBA", "Game", Application.StartupPath & "\setting.ini")
        TextBox18.Text = GetiniValue("GGPOFBA", "ip1", Application.StartupPath & "\setting.ini")
        TextBox17.Text = GetiniValue("GGPOFBA", "ip2", Application.StartupPath & "\setting.ini")
        TextBox16.Text = GetiniValue("GGPOFBA", "ip3", Application.StartupPath & "\setting.ini")
        TextBox1.Text = GetiniValue("GGPOFBA", "ip4", Application.StartupPath & "\setting.ini")
        TextBox21.Text = GetiniValue("GGPOFBA", "My Port", Application.StartupPath & "\setting.ini")
        TextBox20.Text = GetiniValue("GGPOFBA", "Partner Port", Application.StartupPath & "\setting.ini")

        ComboBox4.Text = GetiniValue("FC2", "Game", Application.StartupPath & "\setting.ini")
        TextBox15.Text = GetiniValue("FC2", "ip1", Application.StartupPath & "\setting.ini")
        TextBox14.Text = GetiniValue("FC2", "ip2", Application.StartupPath & "\setting.ini")
        TextBox13.Text = GetiniValue("FC2", "ip3", Application.StartupPath & "\setting.ini")
        TextBox12.Text = GetiniValue("FC2", "ip4", Application.StartupPath & "\setting.ini")
        TextBox2.Text = GetiniValue("FC2", "My Port", Application.StartupPath & "\setting.ini")
        TextBox3.Text = GetiniValue("FC2", "Partner Port", Application.StartupPath & "\setting.ini")
        TextBox4.Text = GetiniValue("FC2", "Delay", Application.StartupPath & "\setting.ini")

        ComboBox7.Text = GetiniValue("Overclock", "Game", Application.StartupPath & "\setting.ini")
        TextBox8.Text = GetiniValue("Overclock", "ip1", Application.StartupPath & "\setting.ini")
        TextBox9.Text = GetiniValue("Overclock", "ip2", Application.StartupPath & "\setting.ini")
        TextBox10.Text = GetiniValue("Overclock", "ip3", Application.StartupPath & "\setting.ini")
        TextBox11.Text = GetiniValue("Overclock", "ip4", Application.StartupPath & "\setting.ini")
        TextBox7.Text = GetiniValue("Overclock", "My Port", Application.StartupPath & "\setting.ini")
        TextBox6.Text = GetiniValue("Overclock", "Partner Port", Application.StartupPath & "\setting.ini")
        TextBox5.Text = GetiniValue("Overclock", "Delay", Application.StartupPath & "\setting.ini")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click   '구버전 ggpofba p2p
        Dim strCmdText As String = "/c %cd%\emulator\ggpofba\ggpofba-ng.exe quark:direct,"      '/c : 실행 후 cmd 창 제거, /k : 실행 후 cmd 창 유지
        Dim game As String
        Dim address1 As Int32
        Dim address2 As Int32
        Dim address3 As Int32
        Dim address4 As Int32
        Dim port1 As Int32
        Dim port2 As Int32
        Dim position As Int32
        Dim direct As String
        Dim window As String
        Dim directwindows As String
        game = ComboBox7.SelectedItem.ToString()
        address1 = TextBox15.Text
        address2 = TextBox14.Text
        address3 = TextBox13.Text
        address4 = TextBox12.Text
        port1 = TextBox2.Text
        port2 = TextBox3.Text
        position = ComboBox2.SelectedIndex
        window = "-w"

        direct = strCmdText & game & "," & port1 & "," & address1 & "." & address2 & "." & address3 & "." & address4 & "," & port2 & "," & position
        directwindows = strCmdText & game & "," & port1 & "," & address1 & "." & address2 & "." & address3 & "." & address4 & "," & port2 & "," & position & " " & window

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
        Dim address1 As Int32
        Dim address2 As Int32
        Dim address3 As Int32
        Dim address4 As Int32
        Dim port1 As Int32
        Dim port2 As Int32
        Dim position As Int32
        Dim delay As Int32
        Dim direct As String
        Dim window As String
        Dim directwindows As String
        game = ComboBox1.SelectedItem.ToString()
        address1 = TextBox15.Text
        address2 = TextBox14.Text
        address3 = TextBox13.Text
        address4 = TextBox12.Text
        port1 = TextBox2.Text
        port2 = TextBox3.Text
        position = ComboBox2.SelectedIndex
        delay = TextBox4.Text
        window = "-w"

        direct = strCmdText & game & "," & port1 & "," & address1 & "." & address2 & "." & address3 & "." & address4 & "," & port2 & "," & position & "," & delay
        directwindows = strCmdText & game & "," & port1 & "," & address1 & "." & address2 & "." & address3 & "." & address4 & "," & port2 & "," & position & "," & delay & "," & " " & window

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
            Dim address1 As Int32
            Dim address2 As Int32
            Dim address3 As Int32
            Dim address4 As Int32
            Dim port1 As Int32
            Dim port2 As Int32
            Dim position As Int32
            Dim delay As Int32
            Dim overclock As Int32
            Dim unity As String
            Dim unitywindow As String
        Dim window As String

        game = ComboBox4.Text.ToString()
        address1 = TextBox8.Text
            address2 = TextBox9.Text
            address3 = TextBox10.Text
            address4 = TextBox11.Text
            port1 = TextBox7.Text
            port2 = TextBox6.Text
            position = ComboBox3.SelectedIndex
            delay = TextBox5.Text
            overclock = ComboBox5.SelectedIndex
        window = "-w"

        unity = strCmdText & game & "," & port1 & "," & address1 & "." & address2 & "." & address3 & "." & address4 & "," & port2 & "," & position & "," & overclock & "," & delay
        unitywindow = strCmdText & game & "," & port1 & "," & address1 & "." & address2 & "." & address3 & "." & address4 & "," & port2 & "," & position & "," & overclock & "," & delay & " " & window

        If Me.CheckBox2.Checked = True Then
                System.Diagnostics.Process.Start("CMD.exe", unitywindow)
            End If
            If Me.CheckBox2.Checked = False Then
                System.Diagnostics.Process.Start("CMD.exe", unity)
            End If
        End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click   'fc1
        WritePrivateProfileString("GGPOFBA", "Game", ComboBox1.SelectedItem, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("GGPOFBA", "ip1", TextBox18.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("GGPOFBA", "ip2", TextBox17.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("GGPOFBA", "ip3", TextBox16.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("GGPOFBA", "ip4", TextBox1.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("GGPOFBA", "My Port", TextBox21.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("GGPOFBA", "Partner Port", TextBox20.Text, Application.StartupPath & "\setting.ini")
        MessageBox.Show("Setting saved")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles setting2.Click  'fc2
        WritePrivateProfileString("FC2", "Game", ComboBox4.SelectedItem, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("FC2", "ip1", TextBox15.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("FC2", "ip2", TextBox14.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("FC2", "ip3", TextBox13.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("FC2", "ip4", TextBox12.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("FC2", "My Port", TextBox2.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("FC2", "Partner Port", TextBox3.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("FC2", "delay", TextBox4.Text, Application.StartupPath & "\setting.ini")
        MessageBox.Show("Setting saved")
    End Sub

    Private Sub setting3_Click(sender As Object, e As EventArgs) Handles setting3.Click    'overclock
        WritePrivateProfileString("Overclock", "Game", ComboBox7.SelectedItem, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Overclock", "ip1", TextBox8.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Overclock", "ip2", TextBox9.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Overclock", "ip3", TextBox10.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Overclock", "ip4", TextBox11.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Overclock", "My Port", TextBox7.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Overclock", "Partner Port", TextBox6.Text, Application.StartupPath & "\setting.ini")
        WritePrivateProfileString("Overclock", "delay", TextBox5.Text, Application.StartupPath & "\setting.ini")
        MessageBox.Show("Setting saved")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("MicrosoftEdge.exe", "https://chamcham425.blogspot.com/2020/09/blog-post.html")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("MicrosoftEdge.exe", "https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=jicdoo&logNo=220822978434")
    End Sub
End Class
