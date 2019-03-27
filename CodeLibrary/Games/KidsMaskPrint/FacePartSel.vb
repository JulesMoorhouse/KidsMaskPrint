Imports System.IO

Public Class FacePartSel
    Inherits System.Windows.Forms.Form
    Dim mRetPart As Part 'JM 11/08/2004
    Public Property RetPart() As Part
        Get
            Return mRetPart
        End Get
        Set(ByVal Value As Part)
            mRetPart = Value
        End Set
    End Property
    Dim mPositionSelection As FacePartEnums.ePositionSelection
    Public Property RetPosSel() As FacePartEnums.ePositionSelection
        Get
            Return mPositionSelection
        End Get
        Set(ByVal Value As FacePartEnums.ePositionSelection)
            mPositionSelection = Value
        End Set
    End Property
    '--- 'JM 19/08/2004 ---
    Public m_SourceDataFileName As String
    Public Property SourceDataFileName() As String
        Get
            Return m_SourceDataFileName
        End Get
        Set(ByVal Value As String)
            m_SourceDataFileName = Value
        End Set
    End Property
    Public m_DataFileItemNum As Integer
    Public Property DataFileItemNum() As Integer
        Get
            Return m_DataFileItemNum
        End Get
        Set(ByVal Value As Integer)
            m_DataFileItemNum = Value
        End Set
    End Property
    '--- 'JM 19/08/2004 ---

    ''Dim mRetImage As Image
    ''Public Property RetImage() As Image
    ''    Get
    ''        Return mRetImage
    ''    End Get
    ''    Set(ByVal Value As Image)
    ''        mRetImage = Value
    ''    End Set
    ''End Property
    Dim m_PieceName As String 'JM 19/09/2004
    Public Property PieceName() As String
        Get
            Return m_PieceName
        End Get
        Set(ByVal Value As String)
            m_PieceName = Value
        End Set
    End Property
    ''Public ReadOnly Property VertFlip() As Boolean
    ''    Get
    ''        Return chkVert.CheckState
    ''    End Get
    ''End Property
    ''Public ReadOnly Property HorizFlip() As Boolean
    ''    Get
    ''        Return chkHoriz.CheckState
    ''    End Get
    ''End Property
    Dim mFacePartListView As New ListView()
    Public Property FacePartListView() As ListView
        Get
            Return mFacePartListView
        End Get
        Set(ByVal Value As ListView)
            mFacePartListView = Value
        End Set
    End Property
    Dim mFacePartImageList As New ImageList()
    Public Property FacePartImageList() As ImageList
        Get
            Return mFacePartImageList
        End Get
        Set(ByVal Value As ImageList)
            'mFacePartImageList.ImageSize = New System.Drawing.Size(32, 32)
            mFacePartImageList = Value
            mFacePartImageList.ImageSize = New System.Drawing.Size(32, 32)
        End Set
    End Property
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnClose As WinOnly.BevelButton
    Friend WithEvents btnSelect As WinOnly.BevelButton
    Friend WithEvents picPreview As System.Windows.Forms.PictureBox
    Friend WithEvents rdoLeft As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBoth As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRight As System.Windows.Forms.RadioButton
    Friend WithEvents btnHelp As WinOnly.BevelButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.btnClose = New WinOnly.BevelButton()
        Me.btnSelect = New WinOnly.BevelButton()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.rdoLeft = New System.Windows.Forms.RadioButton()
        Me.rdoBoth = New System.Windows.Forms.RadioButton()
        Me.rdoRight = New System.Windows.Forms.RadioButton()
        Me.btnHelp = New WinOnly.BevelButton()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.ListView1.Location = New System.Drawing.Point(16, 16)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(400, 224)
        Me.ListView1.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnClose.BackColor = System.Drawing.Color.Red
        Me.btnClose.FlatStyle = WinOnly.BevelButton.FlatStyleEx.Bevel
        Me.btnClose.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Gold
        Me.btnClose.Location = New System.Drawing.Point(326, 352)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(88, 40)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "&Close"
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnSelect.BackColor = System.Drawing.Color.Red
        Me.btnSelect.FlatStyle = WinOnly.BevelButton.FlatStyleEx.Bevel
        Me.btnSelect.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.ForeColor = System.Drawing.Color.Gold
        Me.btnSelect.Location = New System.Drawing.Point(230, 352)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(88, 40)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "&Select"
        '
        'picPreview
        '
        Me.picPreview.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.picPreview.BackColor = System.Drawing.SystemColors.Window
        Me.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPreview.Location = New System.Drawing.Point(16, 256)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(176, 88)
        Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picPreview.TabIndex = 3
        Me.picPreview.TabStop = False
        '
        'rdoLeft
        '
        Me.rdoLeft.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.rdoLeft.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoLeft.Location = New System.Drawing.Point(230, 256)
        Me.rdoLeft.Name = "rdoLeft"
        Me.rdoLeft.Size = New System.Drawing.Size(56, 32)
        Me.rdoLeft.TabIndex = 6
        Me.rdoLeft.Text = "Left"
        Me.rdoLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdoBoth
        '
        Me.rdoBoth.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.rdoBoth.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoBoth.Checked = True
        Me.rdoBoth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoBoth.Location = New System.Drawing.Point(294, 256)
        Me.rdoBoth.Name = "rdoBoth"
        Me.rdoBoth.Size = New System.Drawing.Size(56, 32)
        Me.rdoBoth.TabIndex = 7
        Me.rdoBoth.TabStop = True
        Me.rdoBoth.Text = "Both"
        Me.rdoBoth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdoRight
        '
        Me.rdoRight.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.rdoRight.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoRight.Location = New System.Drawing.Point(358, 256)
        Me.rdoRight.Name = "rdoRight"
        Me.rdoRight.Size = New System.Drawing.Size(56, 32)
        Me.rdoRight.TabIndex = 8
        Me.rdoRight.Text = "Right"
        Me.rdoRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnHelp.BackColor = System.Drawing.Color.Red
        Me.btnHelp.FlatStyle = WinOnly.BevelButton.FlatStyleEx.Bevel
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.ForeColor = System.Drawing.Color.Gold
        Me.btnHelp.Location = New System.Drawing.Point(46, 352)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(88, 40)
        Me.btnHelp.TabIndex = 37
        Me.btnHelp.Text = "&Help"
        '
        'FacePartSel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(430, 406)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnHelp, Me.rdoRight, Me.rdoBoth, Me.rdoLeft, Me.picPreview, Me.btnSelect, Me.btnClose, Me.ListView1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FacePartSel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FaceParts"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim Dir As String = Path.GetDirectoryName( _
        System.Reflection.Assembly.GetExecutingAssembly().Location) & "\FaceParts\"

    Private Sub FaceParts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddDebugComment("FacePartsSel.FaceParts_Load - start") 'JM 07/09/2004

        SetBackcolors() 'JM 06/09/2004
        'Dim ImgList As New ImageList()


        ListView1.LargeImageList = mFacePartImageList


        'ListView1 = mFacePartListView
        ListView1.Items.Clear()

        Dim lvi As New ListViewItem()
        For Each lvi In mFacePartListView.Items
            Dim NewLVItem As New ListViewItem()
            NewLVItem.Tag = lvi.Tag
            NewLVItem.Text = lvi.Text
            NewLVItem.ImageIndex = lvi.ImageIndex
            ListView1.Items.Add(NewLVItem)
            'Console.WriteLine(lvi.Text)

        Next

        'ListView1 = mFacePartListView

        'Dim source As DirectoryInfo = New DirectoryInfo(Dir)
        'Dim files() As FileInfo = source.GetFiles("*.png")
        'Dim pfile As FileInfo

        'Dim Ctr As Integer

        'For Each pfile In files
        '    With pfile
        '        Dim NiceName As String = .Name.Replace(.Extension, "")
        '        Dim image As System.Drawing.Image = System.Drawing.Image.FromFile(Dir & pfile.Name)
        '        ImgList.Images.Add(image)
        '        Dim item As New ListViewItem()
        '        item.ImageIndex = Ctr
        '        item.Text = NiceName
        '        item.Tag = pfile.Name
        '        ListView1.Items.Add(item) 'NiceName, Ctr)
        '        Ctr += 1
        '    End With
        'Next pfile

        'If Ctr > 0 Then
        '    ListView1.Items(0).Selected = True
        '    ListView1_Click(Nothing, Nothing)
        'End If

        AddDebugComment("FacePartsSel.FaceParts_Load - end") 'JM 07/09/2004

    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click

        AddDebugComment("FacePartsSel.btnClose_Click - start") 'JM 07/09/2004

        'mRetImage = Nothing
        mRetPart = Nothing
        m_PieceName = "" 'JM 19/09/2004

        Me.Close()

        AddDebugComment("FacePartsSel.btnClose_Click - end") 'JM 07/09/2004

    End Sub
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        AddDebugComment("FacePartsSel.btnSelect_Click - start") 'JM 07/09/2004

        If ListView1.SelectedItems.Count > 1 Then
            ListView1_Click(Nothing, Nothing)
        End If

        Me.Close()

        AddDebugComment("FacePartsSel.btnSelect_Click - end") 'JM 07/09/2004

    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click

        AddDebugComment("FacePartsSel.ListView1_Click - start") 'JM 07/09/2004

        DisplayPreview()

        'GetDataFileImageItem(ReturnNthStr( _
        '   ListView1.SelectedItems(0).Tag, 1, "#"), ReturnNthStr(ListView1.SelectedItems(0).Tag, 2, "#"), _
        '   mRetImage, mImageName)

        GetDataFileImageItem(ReturnNthStr( _
            ListView1.SelectedItems(0).Tag, 1, "#"), ReturnNthStr(ListView1.SelectedItems(0).Tag, 2, "#"), mRetPart, m_PieceName)


        If rdoLeft.Checked = True Then
            mPositionSelection = FacePartEnums.ePositionSelection.Left
        ElseIf rdoRight.Checked = True Then
            mPositionSelection = FacePartEnums.ePositionSelection.Right
        Else
            mPositionSelection = FacePartEnums.ePositionSelection.Both
        End If

        '--- 'JM 19/08/2004 ---
        m_SourceDataFileName = ReturnNthStr(ListView1.SelectedItems(0).Tag, 1, "#")
        m_DataFileItemNum = ReturnNthStr(ListView1.SelectedItems(0).Tag, 2, "#")
        '--- 'JM 19/08/2004 ---

        AddDebugComment("FacePartsSel.ListView1_Click - end") 'JM 07/09/2004

    End Sub
    Private Sub DisplayPreview()

        AddDebugComment("FacePartsSel.DisplayPreview - start") 'JM 07/09/2004

        'Dim image As System.Drawing.Image = System.Drawing.Image.FromFile(Dir & ListView1.SelectedItems(0).Tag)
        'picPreview.Image = ResizeImage(Dir & ListView1.SelectedItems(0).Tag, picPreview.Height - 10)

        Dim lImage As System.Drawing.Image
        'image = ResizeImage(Dir & ListView1.SelectedItems(0).Tag, picPreview.Height - 10)

        'GetDataFileImageItem(ReturnNthStr( _
        '    ListView1.SelectedItems(0).Tag, 1, "#"), ReturnNthStr(ListView1.SelectedItems(0).Tag, 2, "#"), lImage, Nothing)
        'JM 11/08/2004
        GetDataFileImageItem(ReturnNthStr( _
            ListView1.SelectedItems(0).Tag, 1, "#"), ReturnNthStr(ListView1.SelectedItems(0).Tag, 2, "#"), mRetPart, m_PieceName)
        'JM 11/08/2004
        lImage = mRetPart.FullImage

        lImage = ResizeImageObj(lImage, picPreview.Height - 10)

        If mRetPart.BothParts = False Then
            rdoLeft.Visible = False
            rdoBoth.Visible = False
            rdoRight.Visible = False
            rdoLeft.Checked = True
        Else
            rdoLeft.Visible = True
            rdoBoth.Visible = True
            rdoRight.Visible = True
            rdoBoth.Checked = True
        End If
        'If chkVert.CheckState = CheckState.Checked Then
        '    lImage.RotateFlip(RotateFlipType.RotateNoneFlipY)
        'End If

        If rdoRight.Checked = True Then
            lImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
        End If
        If rdoBoth.Checked = True Then
            'TODO: Draw both pieces on select BOTH
        End If
        picPreview.Image = lImage

        AddDebugComment("FacePartsSel.DisplayPreview - end") 'JM 07/09/2004

    End Sub

    Private Sub rdoPos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoLeft.Click, rdoBoth.Click, rdoRight.Click

        AddDebugComment("FacePartsSel.rdoPos_Click - start") 'JM 07/09/2004

        If rdoLeft.Checked = True Then
            mPositionSelection = FacePartEnums.ePositionSelection.Left
        ElseIf rdoRight.Checked = True Then
            mPositionSelection = FacePartEnums.ePositionSelection.Right
        Else
            mPositionSelection = FacePartEnums.ePositionSelection.Both
        End If

        AddDebugComment("FacePartsSel.rdoPos_Click - end " & mPositionSelection) 'JM 07/09/2004

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick

        AddDebugComment("FacePartsSel.ListView1_DoubleClick") 'JM 07/09/2004

        btnSelect_Click(Nothing, Nothing)

    End Sub
    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)

        'added 'JM 15/08/2004
        Dim PaintBack As New UIStyle.Painting()
        PaintBack.PaintBackground(pevent, Me)
        'Me.Update()

    End Sub

    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click

        AddDebugComment("FacePartsSel.btnHelp_Click") 'JM 07/09/2004

        'JM 25/08/2004
        Help.ShowHelp(Me, GetHelpFile, GetHelpTopic(Main.HelpTopicEnum.FacePartSelect))

    End Sub
    Private Sub SetBackcolors()

        AddDebugComment("FacePartsSel.SetBackcolors") 'JM 07/09/2004

        'Added 'JM 06/09/2004
        rdoLeft.BackColor = Color.FromArgb(0, rdoLeft.BackColor)
        rdoBoth.BackColor = Color.FromArgb(0, rdoBoth.BackColor)
        rdoRight.BackColor = Color.FromArgb(0, rdoRight.BackColor)

    End Sub
End Class