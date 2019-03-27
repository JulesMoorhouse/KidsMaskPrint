Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Friend Class FacePartDiag
    Inherits System.Windows.Forms.Form
#Region "Friend Properties"
    Dim mRetPart As Part 'JM 11/08/2004
    Friend Property RetPart() As Part
        Get
            Return mRetPart
        End Get
        Set(ByVal Value As Part)
            mRetPart = Value
        End Set
    End Property
    Dim m_PartType As FacePartEnums.ePartType 'JM 21/09/2004
    Friend Property PartType() As FacePartEnums.ePartType 'JM 21/09/2004
        Get
            Return m_PartType
        End Get
        Set(ByVal Value As FacePartEnums.ePartType)
            m_PartType = Value
        End Set
    End Property
    Dim mPositionSelection As FacePartEnums.ePositionSelection
    Friend Property RetPosSel() As FacePartEnums.ePositionSelection
        Get
            Return mPositionSelection
        End Get
        Set(ByVal Value As FacePartEnums.ePositionSelection)
            mPositionSelection = Value
        End Set
    End Property
    Dim m_SourceDataFileName As String
    Friend Property SourceDataFileName() As String
        Get
            Return m_SourceDataFileName
        End Get
        Set(ByVal Value As String)
            m_SourceDataFileName = Value
        End Set
    End Property
    Dim m_DataFileItemNum As Integer
    Friend Property DataFileItemNum() As Integer
        Get
            Return m_DataFileItemNum
        End Get
        Set(ByVal Value As Integer)
            m_DataFileItemNum = Value
        End Set
    End Property
    Dim m_PieceName As String
    Friend Property PieceName() As String
        Get
            Return m_PieceName
        End Get
        Set(ByVal Value As String)
            m_PieceName = Value
        End Set
    End Property
    '--- 'JM 31/08/2005 ---
    Dim mm_Pieces As New ArrayList()
    Friend Property mPieces() As ArrayList
        Get
            Return mm_Pieces
        End Get
        Set(ByVal Value As ArrayList)
            mm_Pieces = Value
        End Set
    End Property
    Dim mm_Drawings As Drawings
    Friend Property mDrawings() As Drawings
        Get
            Return mm_Drawings
        End Get
        Set(ByVal Value As Drawings)
            mm_Drawings = Value
        End Set
    End Property
    Dim mm_UserPieces As FacePartStuctureDataFile
    Friend Property mUserPieces() As FacePartStuctureDataFile
        Get
            Return mm_UserPieces
        End Get
        Set(ByVal Value As FacePartStuctureDataFile)
            mm_UserPieces = Value
        End Set
    End Property
    Dim mm_SortOrderForData As SortOrderForData
    Friend Property mSortOrderForData() As SortOrderForData
        Get
            Return mm_SortOrderForData
        End Get
        Set(ByVal Value As SortOrderForData)
            mm_SortOrderForData = Value
        End Set
    End Property
    '--- 'JM 31/08/2005 ---
#End Region

#Region " Windows Form Designer generated code "

    Friend Sub New()
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
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.btnClose = New WinOnly.BevelButton()
        Me.btnSelect = New WinOnly.BevelButton()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.rdoLeft = New System.Windows.Forms.RadioButton()
        Me.rdoBoth = New System.Windows.Forms.RadioButton()
        Me.rdoRight = New System.Windows.Forms.RadioButton()
        Me.btnHelp = New WinOnly.BevelButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
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
        Me.btnClose.TabIndex = 2
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
        Me.btnSelect.TabIndex = 1
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
        Me.rdoLeft.TabIndex = 4
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
        Me.rdoBoth.TabIndex = 5
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
        Me.rdoRight.TabIndex = 6
        Me.rdoRight.Text = "Right"
        Me.rdoRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnHelp.BackColor = System.Drawing.Color.Red
        Me.btnHelp.FlatStyle = WinOnly.BevelButton.FlatStyleEx.Bevel
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.ForeColor = System.Drawing.Color.Gold
        Me.btnHelp.Location = New System.Drawing.Point(16, 352)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(88, 40)
        Me.btnHelp.TabIndex = 3
        Me.btnHelp.Text = "&Help"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'FacePartDiag
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(430, 406)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnHelp, Me.rdoRight, Me.rdoBoth, Me.rdoLeft, Me.picPreview, Me.btnSelect, Me.btnClose, Me.ListView1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.Name = "FacePartDiag"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FaceParts"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim Dir As String = Path.GetDirectoryName( _
        System.Reflection.Assembly.GetExecutingAssembly().Location) & "\FaceParts\"
    Private Structure ThreeImages 'JM 23/09/2004
        Dim LeftImg As Image
        Dim BothImg As Image
        Dim RightImg As Image
        Dim KMPPart As Part
        Dim PieceName As String
    End Structure
    Dim mTempImages() As ThreeImages 'JM 23/09/2004
    Dim DoActivatedCodeOnce As Boolean = True 'JM 31/07/2005
    Private Sub FaceParts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddDebugComment("FacePartDiag.FaceParts_Load - start") 'JM 07/09/2004

        Busy(Me, True) 'JM 19/10/2004

        '--- 'JM 21/09/2004 ---
        Dim Caption As String
        Select Case m_PartType
            Case FacePartEnums.ePartType.Ear : Caption = "Ear"
            Case FacePartEnums.ePartType.Eye : Caption = "Eye"
            Case FacePartEnums.ePartType.Misc : Caption = "Other"
            Case FacePartEnums.ePartType.Outline : Caption = "Head"
            Case FacePartEnums.ePartType.Mouth : Caption = "Mouth"
            Case FacePartEnums.ePartType.Nose : Caption = "Nose"
        End Select

        Me.Text = NameMe(Caption & " Parts")
        '--- 'JM 21/09/2004 ---

        SetBackcolors() 'JM 06/09/2004

        ImageList1.ImageSize = New Size(32, 32)
        'ImageList1.ColorDepth = ColorDepth.Depth32Bit 'JM 21/09/2004


        ListView1.HideSelection = False 'JM 21/09/2004
        ListView1.LargeImageList = ImageList1
        ListView1.Items.Clear()

        LoadFaceParts() 'JM 21/09/2004

        '--- 'JM 23/09/2004 ---
        If ListView1.Items.Count > 0 Then
            ReDim mTempImages(ListView1.Items.Count) 'JM 23/09/2004
            ListView1.Items(0).Selected = True
            ListView1_Click(Nothing, Nothing)
        End If
        '--- 'JM 23/09/2004 ---

        Busy(Me, False) 'JM 19/10/2004


        AddDebugComment("FacePartDiag.FaceParts_Load - end") 'JM 07/09/2004

    End Sub
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click

        AddDebugComment("FacePartDiag.btnClose_Click - start") 'JM 07/09/2004

        mRetPart = Nothing
        m_PieceName = "" 'JM 19/09/2004

        Me.Close()

        AddDebugComment("FacePartDiag.btnClose_Click - end") 'JM 07/09/2004

    End Sub
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        AddDebugComment("FacePartDiag.btnSelect_Click - start") 'JM 07/09/2004

        If ListView1.SelectedItems.Count <> 1 Then
            Exit Sub
        End If

        Me.Close()

        AddDebugComment("FacePartDiag.btnSelect_Click - end") 'JM 07/09/2004

    End Sub
    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click

        AddDebugComment("FacePartDiag.ListView1_Click - start") 'JM 07/09/2004

        Busy(Me, True) 'JM 19/10/2004

        DisplayPreview()

        'don't see why this is needed as it is done in display preview 'JM 21/09/2004
        'GetDataPreviewImage(ReturnNthStr( _
        '    ListView1.SelectedItems(0).Tag, 1, "#"), ReturnNthStr(ListView1.SelectedItems(0).Tag, 2, "#"), mRetPart, m_PieceName, Nothing)

        ''If rdoLeft.Checked = True Then
        ''    mPositionSelection = FacePartEnums.ePositionSelection.Left
        ''ElseIf rdoRight.Checked = True Then
        ''    mPositionSelection = FacePartEnums.ePositionSelection.Right
        ''Else
        ''    mPositionSelection = FacePartEnums.ePositionSelection.Both
        ''End If

        m_SourceDataFileName = ReturnNthStr(ListView1.SelectedItems(0).Tag, 1, "#")
        m_DataFileItemNum = ReturnNthStr(ListView1.SelectedItems(0).Tag, 2, "#")

        Busy(Me, False) 'JM 19/10/2004

        AddDebugComment("FacePartDiag.ListView1_Click - end") 'JM 07/09/2004

    End Sub
    Private Sub DisplayPreview(Optional ByVal RadioUse As Boolean = False)

        AddDebugComment("FacePartDiag.DisplayPreview - start") 'JM 07/09/2004

        Dim lImage As System.Drawing.Image

        '--- 'JM 29/04/2005 ---
        Try
            With mTempImages(ListView1.SelectedItems(0).Index)

            End With
        Catch
            rdoLeft.Visible = False
            rdoBoth.Visible = False
            rdoRight.Visible = False
            Exit Sub
        End Try
        '--- 'JM 29/04/2005 ---

        With mTempImages(ListView1.SelectedItems(0).Index) 'JM 23/09/2004
            If mTempImages(ListView1.SelectedItems(0).Index).LeftImg Is Nothing Then 'JM 23/09/2004
                'JM 11/08/2004
                GetDataPreviewImage(ReturnNthStr( _
                    ListView1.SelectedItems(0).Tag, 1, "#"), ReturnNthStr(ListView1.SelectedItems(0).Tag, 2, "#"), mRetPart, m_PieceName, _
                    .LeftImg, .BothImg, .RightImg)
                'JM 11/08/2004
                AddDebugComment("FacePartDiag.DisplayPreview - 1") 'JM 29/04/2005
                .KMPPart = mRetPart
                .PieceName = m_PieceName
            End If 'JM 23/09/2004

            m_PieceName = .PieceName 'JM 23/09/2004
            mRetPart = .KMPPart 'JM 23/09/2004

            'lImage = PreviewImage 'mRetPart.FullImage

            If RadioUse = False Then 'JM 23/09/2004
                If .KMPPart.BothParts = False Then
                    rdoLeft.Visible = False
                    rdoBoth.Visible = False
                    rdoRight.Visible = False
                    rdoLeft.Checked = True
                Else
                    rdoLeft.Visible = True
                    rdoBoth.Visible = True
                    rdoRight.Visible = True
                    rdoBoth.Checked = True
                    mPositionSelection = FacePartEnums.ePositionSelection.Both
                End If
            Else
                rdoLeft.Visible = True
                rdoBoth.Visible = True
                rdoRight.Visible = True
            End If

            If rdoRight.Checked = True Then
                lImage = .RightImg 'JM 23/09/2004
                'lImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
            End If
            If rdoBoth.Checked = True Then
                lImage = .BothImg 'JM 23/09/2004
            End If

            If lImage Is Nothing Then 'JM 23/09/2004
                lImage = .LeftImg 'JM 23/09/2004
            End If
            AddDebugComment("FacePartDiag.DisplayPreview - 2") 'JM 29/04/2005
            lImage = ResizeImageObj(lImage, picPreview.Height - 10)

        End With 'JM 23/09/2004

        picPreview.Image = lImage

        AddDebugComment("FacePartDiag.DisplayPreview - end") 'JM 07/09/2004

    End Sub

    Private Sub rdoPos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoLeft.Click, rdoBoth.Click, rdoRight.Click

        AddDebugComment("FacePartDiag.rdoPos_Click - start") 'JM 07/09/2004

        Busy(Me, True) 'JM 19/10/2004

        ''If rdoLeft.Checked = True Then
        ''    mPositionSelection = FacePartEnums.ePositionSelection.Left
        ''ElseIf rdoRight.Checked = True Then
        ''    mPositionSelection = FacePartEnums.ePositionSelection.Right
        ''Else
        ''    mPositionSelection = FacePartEnums.ePositionSelection.Both
        ''End If

        DisplayPreview(True) 'JM 23/09/2004

        Busy(Me, False) 'JM 19/10/2004

        AddDebugComment("FacePartDiag.rdoPos_Click - end " & mPositionSelection) 'JM 07/09/2004

    End Sub
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick

        AddDebugComment("FacePartDiag.ListView1_DoubleClick") 'JM 07/09/2004

        btnSelect_Click(Nothing, Nothing)

    End Sub
    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)

        'added 'JM 15/08/2004
        Dim PaintBack As New UIStyle.Painting()
        PaintBack.PaintBackground(pevent, Me)
        'Me.Update()

    End Sub
    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click

        AddDebugComment("FacePartDiag.btnHelp_Click") 'JM 07/09/2004

        'JM 25/08/2004
        Help.ShowHelp(Me, GetHelpFile, GetHelpTopic(Main.HelpTopicEnum.FacePartSelect))

    End Sub
    Private Sub SetBackcolors()

        AddDebugComment("FacePartDiag.SetBackcolors") 'JM 07/09/2004

        'Added 'JM 06/09/2004
        rdoLeft.BackColor = Color.FromArgb(0, rdoLeft.BackColor)
        rdoBoth.BackColor = Color.FromArgb(0, rdoBoth.BackColor)
        rdoRight.BackColor = Color.FromArgb(0, rdoRight.BackColor)

    End Sub
    Private Sub LoadFaceParts()

        AddDebugComment("FacePartDiag.LoadFaceParts - start") 'JM 07/09/2004

        Busy(Me, True) 'JM 21/09/2004

        '-------------- Check License if available -------------
        Dim Dets2 As strat1.UnlockDetails
        Dim Info As New System.IO.FileInfo(System.IO.Path.GetDirectoryName( _
            System.Reflection.Assembly.GetExecutingAssembly.Location.ToString()) & "\keyfile.mcl")

        If Info.Exists Then
            Try
                Unlock(System.IO.Path.GetDirectoryName( _
                    System.Reflection.Assembly.GetExecutingAssembly.Location.ToString()) & "\keyfile.mcl", Dets2, "", "")
            Catch

            End Try
        End If

        '-------------- Check License if available -------------

        Dim source As DirectoryInfo = New DirectoryInfo(Path.GetDirectoryName( _
            System.Reflection.Assembly.GetExecutingAssembly().Location) & "\FaceParts\")

        'iterate data file directory
        Dim files() As FileInfo = source.GetFiles("*.dat")
        Dim pfile As FileInfo

        For Each pfile In files
            Try ' this will cater for old data files

                ''Dim FPs As New KidsMaskPrint.FacePartStuctureDataFile()

                ''Dim FileStream As Stream = File.Open(pfile.FullName, FileMode.Open)
                ''Dim FileFormatter As New BinaryFormatter()

                '''Dim Ver As String = FileFormatter.Deserialize(FileStream)
                ''FPs = DirectCast(FileFormatter.Deserialize(FileStream), KidsMaskPrint.FacePartStuctureDataFile)

                ''FileStream.Close()

                Dim FPs As FacePartStuctureDataFile = UnlockFacePartsPack(pfile.FullName) 'JM 23/09/2004

                '--- this block checks for a valid key file and doesn't all it to be used if it isn't ---
                If pfile.Name.ToLower <> "basic.dat" Then 'JM 22/09/2004
                    Dim keyFile As String = pfile.FullName.ToLower.Replace(".dat", ".key")
                    If File.Exists(keyFile) = True Then
                        Dim Dets As strat1.UnlockDetails
                        Dim lintResult As Integer

                        Try
                            lintResult = Unlock(keyFile, Dets, FPs.ProductNumber, Dets2.strSerialBlock)
                        Catch
                            lintResult = 3
                        End Try

                        If lintResult <> 257 Then
                            Throw New Exception(" ")
                        End If
                    Else
                        Throw New Exception(" ")
                    End If
                End If 'JM 22/09/2004

                Dim lintArrInc As Integer
                For lintArrInc = 0 To FPs.Parts.Count  '0 To FPs.Parts.Count - 1
                    Dim ThisPart As New KidsMaskPrint.Part()
                    ThisPart = FPs.Parts(lintArrInc)

                    Dim lAdd As Boolean = False

                    'If ThisPart.PartType = FacePartEnums.ePartType.Outline And m_PartType = FacePartEnums.ePartType.Misc Then
                    '    lAdd = True
                    'End If

                    If ThisPart.PartType = m_PartType Then
                        lAdd = True
                    End If

                    If lAdd = True Then

                        'Dim Bmp As Bitmap
                        'Bmp = CType(ThisPart.ThumbImage, Bitmap)
                        'ImageList1.Images.Add(Icon.FromHandle(Bmp.GetHicon()))

                        'Dim lImage As System.Drawing.Image
                        'lImage = ThisPart.FullImage
                        'lImage = ResizeImageObj(lImage, 32)
                        'ImageList1.Images.Add(lImage)

                        'ImageList1.Images.Add(ThisPart.ThumbImage, Color.White)
                        'ImageList1.Images.Add(ThisPart.FullImage, Color.White)

                        'ImageList1.Images.Add(ThisPart.ThumbImage)

                        'Dim ThisImageTest As String = ""

                        'ThisImageTest = "D:\CodeLibrary\Games\KMPDataFiles\bin\PackBasic\" & ThisPart.FaceMaster & ".bmp"
                        'If File.Exists(ThisImageTest) = False Then
                        '    ThisImageTest = "D:\CodeLibrary\Games\KMPDataFiles\bin\PackHalloween2004\" & ThisPart.FaceMaster & ".bmp"
                        '    If File.Exists(ThisImageTest) = False Then
                        '        ThisImageTest = ""
                        '    End If
                        'End If

                        'If ThisImageTest = "" Then
                        ImageList1.Images.Add(ThisPart.ThumbImage)
                        'Else
                        '    'ImageList1.Images.Add(ResizeImageObj(Image.FromFile(ThisImageTest), 32))
                        '    ImageList1.Images.Add(Image.FromFile(ThisImageTest))
                        'End If


                        Dim NewLVItem As New ListViewItem()
                        NewLVItem.Tag = pfile.Name & "# " & lintArrInc & "#"
                        NewLVItem.Text = ThisPart.FaceMaster
                        NewLVItem.ImageIndex = ImageList1.Images.Count - 1

                        ListView1.Items.Add(NewLVItem)
                        NewLVItem = Nothing

                    End If
                Next lintArrInc
            Catch ex As Exception
                'MessageBox.Show(ex.ToString)
            End Try
        Next pfile

        Busy(Me, False) 'JM 21/09/2004

        AddDebugComment("FacePartDiag.LoadFaceParts - end") 'JM 07/09/2004

    End Sub
    Private Sub FacePartDiag_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate() 'JM 21/09/2004
    End Sub
    Private Sub rdo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoLeft.CheckedChanged, rdoBoth.CheckedChanged, rdoRight.CheckedChanged
        'added 'JM 23/09/2004
        If rdoLeft.Checked = True Then
            mPositionSelection = FacePartEnums.ePositionSelection.Left
        ElseIf rdoRight.Checked = True Then
            mPositionSelection = FacePartEnums.ePositionSelection.Right
        Else
            mPositionSelection = FacePartEnums.ePositionSelection.Both
        End If

    End Sub

    Private Sub FacePartDiag_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'JM 24/09/2004
        If e.KeyCode = Keys.Escape Then
            btnClose_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub FacePartDiag_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        '--- 'JM 31/07/2005 ---
        If DoActivatedCodeOnce = True Then
            DoActivatedCodeOnce = False
            Dim ShowBuyMore As Boolean = CBool(GetSetting("BuyMore", "True", InitalXMLConfig.XmlConfigType.AppSettings, ""))

            If ShowBuyMore = True Then
                Dim BM As New CanBuyPacks()
                BM.Owner = Me
                BM.ShowDialog()

            End If
        End If
        '--- 'JM 31/07/2005 ---



    End Sub

    Private Sub AddSelectedFacePart(ByVal pFP As Part, ByVal pSel As FacePartEnums.ePositionSelection, _
        ByVal SourceDatFileName As String, ByVal DataFileItemNum As Integer, ByVal pobjForm As frmMain)

        AddDebugComment("FacePartDiag.AddSelectedFacePart - start") 'JM 07/09/2004

        Busy(pobjForm, True) 'JM 19/10/2004

        If Not pFP Is Nothing Then

            Select Case pSel
                Case FacePartEnums.ePositionSelection.Left
                    Dim ThisPiece As New Piece()
                    ThisPiece.SetImageObj(pFP.FullImage)
                    ThisPiece.Location = pFP.LeftPart
                    ''ThisPiece.Bitmapname = pFP.FaceMaster '& " Left"
                    ThisPiece.PieceName = pFP.FaceMaster 'JM 19/09/2004
                    ThisPiece.SourceDataFileName = SourceDatFileName 'JM 19/08/2004
                    ThisPiece.DataFileItemNum = DataFileItemNum 'JM 19/08/2004
                    mm_Pieces.Add(ThisPiece)
                Case FacePartEnums.ePositionSelection.Both

                    Dim ThisPiece As New Piece()
                    ThisPiece.HorizFlip = False
                    thispiece.VertFlip = False
                    ThisPiece.SetImageObj(pFP.FullImage.Clone) 'added clone 'JM 12/08/2004
                    ThisPiece.Location = pFP.LeftPart
                    ThisPiece.PieceName = pFP.FaceMaster 'JM 19/09/2004
                    ''ThisPiece.Bitmapname = pFP.FaceMaster '& " Left"
                    ThisPiece.SourceDataFileName = SourceDatFileName 'JM 19/08/2004
                    ThisPiece.DataFileItemNum = DataFileItemNum 'JM 19/08/2004
                    mm_Pieces.Add(ThisPiece)

                    Dim ThisPiece2 As New Piece()
                    ThisPiece2.HorizFlip = True
                    ThisPiece2.VertFlip = False
                    ThisPiece2.SetImageObj(pFP.FullImage)
                    ThisPiece2.Location = pFP.RightPart
                    ThisPiece2.PieceName = pFP.FaceMaster 'JM 19/09/2004
                    ''ThisPiece2.Bitmapname = pFP.FaceMaster ' & " Right"
                    ThisPiece2.SourceDataFileName = SourceDatFileName 'JM 19/08/2004
                    ThisPiece2.DataFileItemNum = DataFileItemNum 'JM 19/08/2004
                    mm_Pieces.Add(ThisPiece2)

                Case FacePartEnums.ePositionSelection.Right
                    Dim ThisPiece As New Piece()
                    ThisPiece.HorizFlip = True
                    ThisPiece.SetImageObj(pFP.FullImage)
                    ThisPiece.Location = pFP.RightPart
                    ThisPiece.PieceName = pFP.FaceMaster 'JM 19/09/2004
                    ''ThisPiece.Bitmapname = pFP.FaceMaster '& " Right"
                    ThisPiece.SourceDataFileName = SourceDatFileName 'JM 19/08/2004
                    ThisPiece.DataFileItemNum = DataFileItemNum 'JM 19/08/2004

                    mm_Pieces.Add(ThisPiece)
            End Select

            mm_SortOrderForData.Add(mm_Pieces, mm_Drawings.mousePath, _
                mm_Drawings.ReversemousePath, mm_UserPieces, mm_SortOrderForData, "AddSelectedFacePart")   'JM 14/10/2004
            pobjForm.ChangeUndoRedoStatus() 'JM 17/10/2004
        End If

        Busy(pobjForm, False) 'JM 19/10/2004

        pobjForm.Update() 'JM 12/08/2004

        pobjForm.PictureBox1.Invalidate() 'JM 25/09/2004

        AddDebugComment("FacePartDiag.AddSelectedFacePart - end") 'JM 07/09/2004

    End Sub

    Private Sub FacePartDiag_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        'JM 31/08/2005
        AddSelectedFacePart(mRetPart, mPositionSelection, m_SourceDataFileName, m_DataFileItemNum, Me.Owner)

    End Sub
End Class