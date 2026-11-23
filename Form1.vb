'SpecCSVMerger 
'Spectra CSV Merger 
'Copyright(c) 2023, Nikolaos Kourkoumelis, PI of KRGroup (https://myweb.uoi.gr/nkourkou/)
'University of Ioannina, Greece

'Permission Is hereby granted, free of charge, to any person obtaining a copy of this software
'And associated documentation files (the "Software"), to deal in the Software without restriction,
'including without limitation the rights to use, copy, modify, merge, publish, distribute,
'sublicense, And/Or sell copies of the Software, And to permit persons to whom the Software
'Is furnished to do so, subject to the following conditions:

'The above copyright notice And this permission notice shall be included In all copies
'Or substantial portions Of the Software.

'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or IMPLIED,
'INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY, FITNESS For A PARTICULAR
'PURPOSE And NONINFRINGEMENT. In NO Event SHALL THE AUTHORS Or COPYRIGHT HOLDERS BE LIABLE
'For ANY CLAIM, DAMAGES Or OTHER LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or OTHERWISE,
'ARISING FROM, OUT Of Or In CONNECTION With THE SOFTWARE Or THE USE Or OTHER DEALINGS In THE SOFTWARE."


Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports CsvHelper

Public Class Form1
    Dim toolTip As ToolTip = New ToolTip()
    Dim DesktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    Sub PopulateTreeView(node As TreeNode)
        ' Get all subfolders of the current folder
        For Each folder As String In Directory.GetDirectories(node.FullPath)
            ' Create a new TreeNode for the subfolder
            Dim subFolderNode As New TreeNode(Path.GetFileName(folder)) With {
                .Name = folder,
                .Tag = True
            }
            ' Add the subfolder to the TreeView
            node.Nodes.Add(subFolderNode)
            ' Recursively call the function to populate the subfolder
            PopulateTreeView(subFolderNode)
        Next

        For Each file As String In Directory.GetFiles(node.FullPath)
            Dim fileNode As New TreeNode(Path.GetFileName(file))
            Dim extension As String = Path.GetExtension(file)
            If extension.Equals(".csv", StringComparison.OrdinalIgnoreCase) Then

                Dim firstLine As String = Nothing ' or String.Empty

                Using reader As New StreamReader(file)
                    If Not reader.EndOfStream Then firstLine = reader.ReadLine
                    ' Only list ENLIGHTEN files (empty or other CSV files are skipped)
                    If firstLine IsNot Nothing AndAlso firstLine.StartsWith("ENLIGHTEN") Then
                        fileNode.Name = file
                        fileNode.Checked = False
                        fileNode.Tag = False
                        fileNode.StateImageIndex = -1
                        node.Nodes.Add(fileNode)
                    End If
                End Using
            End If
        Next
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Dim apppath As String = ""
        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        dialog.Description = "Select the folder which contains the raman spectra (csv)"

        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            apppath = dialog.SelectedPath
            TreeView1.Nodes.Clear()
            TreeView1.Nodes.Add(apppath)
            TreeView1.CheckBoxes = True
            TreeView1.Nodes.Clear()
            Dim ndParent As TreeNode = TreeView1.Nodes.Add(apppath)
            ndParent.Tag = apppath
            ndParent.Nodes.Add("*root*")
        End If


        Dim OutputPath As String = My.Settings.OutputPath
        If Not Directory.Exists(OutputPath) Then
            ' If the folder does not exist, use the desktop folder as the default location
            OutputPath = DesktopPath
        End If

        TextBox1.Text = OutputPath + "\Spectra_" + DateTime.Now.ToString("yy_MM_dd-HH_mm") + ".csv"
        ListBox1.Items.Clear()
        lblhowmanyfiles.Text = ""
    End Sub
    Private Sub treeview1_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        Try
            e.Node.Nodes.Clear()
            PopulateTreeView(e.Node)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle ' Prevent size grips
        Me.MaximumSize = Me.Size ' Prevent maximize (also by doubleclick of header text)
        Me.MaximizeBox = False
        CenterForm(Me)
        ListBox1.SelectionMode = SelectionMode.MultiExtended
        ListBox1.DisplayMember = "Name"
        '  radioxyyy.Checked = True
        '  radio_relpath.Checked = True

        Select Case My.Settings.SelectedRadioButton_Path
            Case "Path"
                radio_wholepath.Checked = True
            Case "RelPath"
                radio_relpath.Checked = True
            Case "Filename"
                radio_filename.Checked = True
            Case Else
                radio_relpath.Checked = True
        End Select
        Select Case My.Settings.SelectedRadioButton_XY
            Case "XYYY"
                radioxyyy.Checked = True
            Case "XYXY"
                radioxyxy.Checked = True
            Case Else
                radioxyyy.Checked = True
        End Select



    End Sub
    Private Sub check(node As TreeNode)
        If Not node.Checked Then
            ListBox1.Items.Clear()
            lblhowmanyfiles.Text = ""
            Return
        End If

        Dim selectedNode As TreeNode = node
        Dim subfolders As New List(Of String)
        Dim csvCount As New Dictionary(Of String, Integer)
        For Each subNode As TreeNode In selectedNode.Nodes
            If Not isFile(subNode.Text) Then
                subfolders.Add(subNode.Text)
                csvCount.Add(subNode.Text, 0)
                For Each fileNode As TreeNode In subNode.Nodes
                    If fileNode.Text.EndsWith(".csv") Then
                        csvCount(subNode.Text) += 1
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub treeview1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        check(e.Node)
        If e.Node.Nodes.Count > 0 Then
            CheckAllChildNodes(e.Node, e.Node.Checked)
        End If
        If Not e.Node.Checked Then
            e.Node.Collapse()
        End If
    End Sub
    'Private Sub chkShowPath_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPath.CheckedChanged
    '    If chkShowPath.Checked Then
    '        ListBox1.DisplayMember = "FullName"
    '    Else
    '        ListBox1.DisplayMember = "Name"
    '    End If
    'End Sub
    Private Function isFile(path) As Boolean
        Dim extension As String = IO.Path.GetExtension(path)
        If extension = "" Then
            Return False
        End If
        Return True
    End Function
    Private Sub treeview1_BeforeCheck(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeCheck
        'If Not e.Node.Tag Then
        '    Return

        'End If
        'TreeView1.ExpandAll()
        e.Node.Expand()
    End Sub
    Private Sub CheckAllChildNodes(node As TreeNode, nodeChecked As Boolean)
        For Each childNode As TreeNode In node.Nodes
            childNode.Checked = nodeChecked
            CheckAllChildNodes(childNode, nodeChecked)
        Next

    End Sub
    Private Sub CheckParentNode(node As TreeNode)
        Dim parentNode As TreeNode = node.Parent
        If parentNode IsNot Nothing Then
            Dim allChecked As Boolean = True
            For Each childNode As TreeNode In parentNode.Nodes
                If Not childNode.Checked Then
                    allChecked = False
                    Exit For
                End If
            Next
            parentNode.Checked = allChecked
            CheckParentNode(parentNode)
        End If
    End Sub
    Private Function GetCheck(ByVal node As TreeNodeCollection) As List(Of TreeNode)
        Dim lN As New List(Of TreeNode)
        For Each n As TreeNode In node
            If n.Checked Then lN.Add(n)
            lN.AddRange(GetCheck(n.Nodes))
        Next
        Return lN
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        For Each n As TreeNode In GetCheck(TreeView1.Nodes)
            If n.Text.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) Then
                ListBox1.Items.Add(n)
            End If
        Next
        lblhowmanyfiles.Text = "Selected items: " & ListBox1.Items.Count.ToString
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ListBox1.Items.Count = 0 Then
            MsgBox("Please press the 'Assemble selected files >>' button before merging", vbExclamation, "Warning")
            Exit Sub
        End If

        Dim OutputPath As String = Path.GetDirectoryName(TextBox1.Text)
        If Not Directory.Exists(OutputPath) Then
            ' If the folder does not exist, use the desktop folder as the default location
            MsgBox("The output folder does not exist", vbExclamation, "Warning")
            Exit Sub
        End If


        '  ToolStripProgressBar1.Maximum = ListBox1.Items.Count - 1
        ReadMultipleCsv()
        '  ToolStripProgressBar1.Step = 1
        ' ToolStripProgressBar1.PerformStep()
        If radioxyyy.Checked = True Then
            RemoveColumnsfromCSV()
            My.Computer.FileSystem.DeleteFile(TextBox1.Text & "1")
        End If
        '  ToolStripProgressBar1.Value = 0

        My.Settings.OutputPath = (OutputPath)
        My.Settings.Save()

    End Sub
    Public Sub ReadMultipleCsv()
        Dim myList As New List(Of String)
        For Each item As Object In ListBox1.Items
            Dim itemType As Type = item.GetType()
            Dim displayProperty As PropertyInfo = itemType.GetProperty(ListBox1.DisplayMember)
            Dim displayValue As String = displayProperty.GetValue(item).ToString()
            myList.Add(displayValue)
        Next

        ' Define the list of CSV files to read
        Dim fileNames = myList
        Dim fileNameList As New List(Of String)(fileNames.ConvertAll(Function(filePath) Path.GetFileName(filePath)))
        Dim relativePathList As New List(Of String)(fileNames.ConvertAll(Function(filePath) Path.GetFileName(filePath) + " (" + Path.GetFileName(Path.GetDirectoryName(filePath)) + ")"))

        ' Define the output file
        Dim outputFile = TextBox1.Text

        ' Open the output file for writing
        Using writer As New StreamWriter(outputFile)

            Using csvWriter = New CsvWriter(writer, CultureInfo.InvariantCulture)
                Dim readers As New List(Of CsvReader)
                Dim isFirstFile As Boolean = True
                If radioxyyy.Checked = True Then
                    csvWriter.WriteField("Raman Shift")
                    If radio_wholepath.Checked Then
                        csvWriter.WriteField(fileNames)
                    ElseIf radio_relpath.Checked Then
                        csvWriter.WriteField(relativePathList)
                    ElseIf radio_filename.Checked Then
                        csvWriter.WriteField(fileNameList)
                    End If
                    csvWriter.NextRecord()
                End If

                If radioxyxy.Checked = True Then
                    For i As Integer = 0 To (fileNames.Count - 1)
                        csvWriter.WriteField("Raman Shift")
                        If radio_wholepath.Checked Then
                            csvWriter.WriteField(fileNames(i))
                        ElseIf radio_relpath.Checked Then
                            csvWriter.WriteField(relativePathList(i))
                        ElseIf radio_filename.Checked Then
                            csvWriter.WriteField(fileNameList(i))
                        End If
                    Next
                    csvWriter.NextRecord()
                End If

                Try
                    For Each filePath In fileNames
                        Dim reader As New StreamReader(filePath)
                        Dim csvReader = New CsvReader(reader, CultureInfo.InvariantCulture)
                        readers.Add(csvReader)
                        ' Skip the ENLIGHTEN metadata block and the "Pixel,..." column header line
                        Dim lineCount As Integer = CountLinesUntilString(filePath, "Pixel,")
                        For i As Integer = 0 To lineCount - 2
                            csvReader.Read()
                        Next
                    Next
                    While True
                        Dim isEnd = False
                        For Each csvReader In readers
                            If Not csvReader.Read() Then
                                isEnd = True
                                Exit For
                            End If
                            ' Columns: 0 Pixel, 1 Wavelength, 2 Wavenumber, 3 Processed
                            If isFirstFile Then
                                csvWriter.WriteField(csvReader.GetField(Of String)(2))
                                csvWriter.WriteField(csvReader.GetField(Of String)(3))
                            Else
                                csvWriter.WriteField(csvReader.GetField(Of String)(3))
                            End If
                        Next
                        If isEnd Then
                            Exit While
                        End If
                        csvWriter.NextRecord()
                    End While
                Finally
                    ' Close all input files so they are not left locked after merging
                    For Each csvReader In readers
                        csvReader.Dispose()
                    Next
                End Try
            End Using
        End Using
    End Sub

    Private Sub RemoveColumnsfromCSV()
        ' Define the path of the input file
        My.Computer.FileSystem.CopyFile(TextBox1.Text, TextBox1.Text & "1", Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)

        Dim inputFilePath As String = TextBox1.Text & "1"

        ' Define the path of the output file
        Dim outputFilePath As String = TextBox1.Text

        ' Open the input file for reading
        Using reader As New StreamReader(inputFilePath)
            ' Open the output file for writing
            Using writer As New StreamWriter(outputFilePath)
                writer.WriteLine(reader.ReadLine())

                Dim line As String
                While Not reader.EndOfStream
                    line = reader.ReadLine()
                    Dim fields() As String = line.Split(","c)
                    For i As Integer = 0 To fields.Count - 1
                        If i Mod 2 <> 0 Or i = 0 Then
                            If i < fields.Count - 1 Then
                                writer.Write(fields(i) & ",")
                            Else
                                writer.Write(fields(i))
                            End If
                        End If
                    Next
                    writer.WriteLine()
                End While
            End Using
        End Using


    End Sub
    Public Function CountLinesUntilString(fileName As String, searchString As String) As Integer
        ' Create a counter variable
        Dim counter As Integer = 0

        ' Open the input file for reading
        Using reader As New StreamReader(fileName)
            Dim line As String
            While Not reader.EndOfStream
                line = reader.ReadLine()
                counter += 1
                If line.Contains(searchString) Then
                    ' The line contains the search string, exit the loop
                    Exit While
                Else
                    ' The line does not contain the search string, continue reading
                End If
            End While
        End Using
        Return counter
    End Function

    Public Shared Sub CenterForm(ByVal frm As Form, Optional ByVal parent As Form = Nothing)
        '' Note: call this from frm's Load event!
        Dim r As Rectangle
        If parent IsNot Nothing Then
            r = parent.RectangleToScreen(parent.ClientRectangle)
        Else
            r = Screen.FromPoint(frm.Location).WorkingArea
        End If

        Dim x = r.Left + (r.Width - frm.Width) \ 2
        Dim y = r.Top + (r.Height - frm.Height) \ 2
        frm.Location = New Point(x, y)
    End Sub

    Private Sub listbox1_MouseMove(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseMove
        Dim index As Integer = ListBox1.IndexFromPoint(e.Location)


        If (index <> -1 AndAlso index < ListBox1.Items.Count) Then
            If (toolTip.GetToolTip(ListBox1) <> ListBox1.Items(index).ToString()) Then
                toolTip.SetToolTip(ListBox1, ListBox1.Items(index).ToString())
            End If
        End If
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub radio_wholepath_CheckedChanged(sender As Object, e As EventArgs) Handles radio_wholepath.CheckedChanged
        If radio_wholepath.Checked Then
            My.Settings.SelectedRadioButton_Path = "Path"
        End If
        My.Settings.Save()
    End Sub

    Private Sub radio_relpath_CheckedChanged(sender As Object, e As EventArgs) Handles radio_relpath.CheckedChanged
        If radio_relpath.Checked Then
            My.Settings.SelectedRadioButton_Path = "RelPath"
        End If
        My.Settings.Save()
    End Sub

    Private Sub radio_filename_CheckedChanged(sender As Object, e As EventArgs) Handles radio_filename.CheckedChanged
        If radio_filename.Checked Then
            My.Settings.SelectedRadioButton_Path = "Filename"
        End If
        My.Settings.Save()
    End Sub

    Private Sub radioxyyy_CheckedChanged(sender As Object, e As EventArgs) Handles radioxyyy.CheckedChanged
        If radioxyyy.Checked Then
            My.Settings.SelectedRadioButton_XY = "XYYY"
        End If
        My.Settings.Save()
    End Sub

    Private Sub radioxyxy_CheckedChanged(sender As Object, e As EventArgs) Handles radioxyxy.CheckedChanged
        If radioxyxy.Checked Then
            My.Settings.SelectedRadioButton_XY = "XYXY"
        End If
        My.Settings.Save()
    End Sub



    Private Sub TextBox1_DoubleClick(sender As Object, e As EventArgs) Handles TextBox1.DoubleClick
        TextBox1.Text = DesktopPath + "\Spectra_" + DateTime.Now.ToString("yy_MM_dd-HH_mm") + ".csv"
    End Sub


    Private Sub textbox1_MouseHover(sender As Object, e As EventArgs) Handles TextBox1.MouseHover
        ' Assume that the second label is at index 1
        StatusStrip1.Items(0).Text = "Double click to use the desktop as the output folder"
    End Sub

    Private Sub textbox1_MouseLeave(sender As Object, e As EventArgs) Handles TextBox1.MouseLeave
        ' Assume that the second label is at index 1
        StatusStrip1.Items(0).Text = "NK (c) 2023"
    End Sub

End Class
