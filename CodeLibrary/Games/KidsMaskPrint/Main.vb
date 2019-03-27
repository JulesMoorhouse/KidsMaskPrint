Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Drawing.Drawing2D
Imports System.Security.Cryptography

Friend Module Main
    <DoNotObfuscateAttribute()> Friend gstrDecryptProbTrace As String = "" 'JM 06/07/2005
    Friend mintVersion As Integer 'JM 15/08/2004
    Friend lstrTempFiles(0) As String 'JM 15/08/2004

    '--- 'JM 16/08/2004 ---
    Private Const mstrTitle As String = "Take a minute to understand what Kids Mask Print can do for you!"
    Private Const mstrBullet1 As String = "       Keeps your kids happy and occupied"
    Private Const mstrBullet2 As String = "       Easy to use, step-by-step help included!"
    Private Const mstrBullet3 As String = "       Caters for creativity and future change"
    Private Const mstrBullet4 As String = "       Free email support"
    '--- 'JM 16/08/2004 ---

    Friend fpDir As String = Path.GetDirectoryName( _
        System.Reflection.Assembly.GetExecutingAssembly().Location) & "\FaceParts\" 'JM 20/08/2004

    Friend Sub Main()
        'added 'JM 16/08/2004        

        'Dim lstrEssentialFiles() As String = {"AppBasic.dll", "AxInterop.SHDocVw.dll", _
        '    "Beside02.exe", "Beside03.exe", "KidsMaskPrint.exe", "MCLCore.dll", "SharpZipLib.dll", "SHDocVw.dll", _
        '    "WinOnly.dll"}

        Dim lstrEssentialFiles() As String = {"AppBasic.dll", "Beside02.exe", "Beside03.exe", "KidsMaskPrint.exe", _
            "KidsMaskPrint.exe.Manifest", "MCLCore.dll", "ProbHand.dll", "SharpZipLib.dll", _
            "UIStyle.dll", "WinOnly.dll", "FaceParts\Basic.dat"}

        Dim lstrPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location.ToString())

        If EssentialFileCheck(lstrEssentialFiles, lstrPath) = False Then
            MessageBox.Show("Some essential program files are missing, please re-install the program!", "Kids Mask Print", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        MainStart()
    End Sub
    Friend Function ResizeImage(ByVal pstrSourceFile As String, ByVal maxSize As Integer) As Image

        Dim inp As New IntPtr()
        Dim imgHeight, imgWidth As Double

        Dim image As System.Drawing.Image = System.Drawing.Image.FromFile(pstrSourceFile)

        Dim bm As Bitmap = New Bitmap(image)

        imgHeight = bm.Height
        imgWidth = bm.Width


        If (imgWidth > maxSize Or imgHeight > maxSize) Then
            Dim deltaWidth As Double = imgWidth - maxSize
            Dim deltaHeight As Double = imgHeight - maxSize
            Dim scaleFactor As Double

            If deltaHeight > deltaWidth Then
                'Scale by the height
                scaleFactor = maxSize / imgHeight
            Else
                'Scale by the Width
                scaleFactor = maxSize / imgWidth
            End If

            imgWidth *= scaleFactor
            imgHeight *= scaleFactor
        End If
        Try
            Dim w As Integer = Convert.ToInt32(imgWidth)
            Dim h As Integer = Convert.ToInt32(imgHeight)
            Dim bmp As System.Drawing.Image = bm.GetThumbnailImage(w, h, Nothing, inp)

            bm = New Bitmap(bmp)

            ''Try : System.IO.File.Delete(pstrDestFile) : Catch : End Try
            'bm.Save(pstrDestFile, System.Drawing.Imaging.ImageFormat.Png)
            ''bm.Save(pstrDestFile, System.Drawing.Imaging.ImageFormat.Jpeg)            

            Return bm

            image.Dispose()
            bm.Dispose()
            bmp.Dispose()
            image = Nothing 'JM 13/01/2004
            bmp = Nothing 'JM 13/01/2004
            bm = Nothing 'JM 13/01/2004
        Catch ex As Exception

        End Try



    End Function
    Friend Function ResizeImageObj(ByVal SoureImage As Image, ByVal maxSize As Integer) As Image

        Dim inp As New IntPtr()
        Dim imgHeight, imgWidth As Double

        Dim image As System.Drawing.Image = SoureImage 'System.Drawing.Image.FromFile(pstrSourceFile)

        Dim bm As Bitmap = New Bitmap(image)

        imgHeight = bm.Height
        imgWidth = bm.Width

        'Console.WriteLine("maxSize=" & maxSize)
        'Console.WriteLine("   imgHeight=" & imgHeight & " imgWidth=" & imgWidth)


        If (imgWidth > maxSize Or imgHeight > maxSize) Then
            Dim deltaWidth As Double = imgWidth - maxSize
            Dim deltaHeight As Double = imgHeight - maxSize
            Dim scaleFactor As Double

            If deltaHeight > deltaWidth Then
                'Scale by the height
                scaleFactor = maxSize / imgHeight
                If scaleFactor > 1 Then 'JM 23/09/2004
                    scaleFactor = imgHeight / maxSize 'JM 23/09/2004
                End If
            Else
                'Scale by the Width
                scaleFactor = maxSize / imgWidth
                If scaleFactor > 1 Then 'JM 23/09/2004
                    scaleFactor = imgWidth / maxSize 'JM 23/09/2004
                End If
            End If

            imgWidth *= scaleFactor
            imgHeight *= scaleFactor
            'Console.WriteLine("AF imgHeight=" & imgHeight & " imgWidth=" & imgWidth)

        End If
        Try
            Dim w As Integer = Convert.ToInt32(imgWidth)
            Dim h As Integer = Convert.ToInt32(imgHeight)
            Dim bmp As System.Drawing.Image = bm.GetThumbnailImage(w, h, Nothing, inp)

            bm = New Bitmap(bmp)

            ''Try : System.IO.File.Delete(pstrDestFile) : Catch : End Try
            'bm.Save(pstrDestFile, System.Drawing.Imaging.ImageFormat.Png)
            ''bm.Save(pstrDestFile, System.Drawing.Imaging.ImageFormat.Jpeg)            
            'Console.WriteLine("   imgHeight=" & h & " bm.Width=" & w)
            'Console.WriteLine("RE imgHeight=" & bm.Height & " bm.Width=" & imgWidth)
            'Console.WriteLine("")

            Return bm

            image.Dispose()
            '''bm.Dispose()
            bmp.Dispose()
            image = Nothing 'JM 13/01/2004
            bmp = Nothing 'JM 13/01/2004
            '''bm = Nothing 'JM 13/01/2004
        Catch ex As Exception

        End Try
    End Function


    Friend Function NameMe(ByVal pstrCaption As String) As String


        Dim lstrVersion As String
        If mintVersion = 32 Then
            lstrVersion = "KidsMaskPrint " & gYear 'JM 07/01/2005 2004"
        Else
            lstrVersion = "KidsMaskPrint Trial Version"

        End If

        If pstrCaption <> "" Then
            If (pstrCaption).ToUpper = "MIDSMASKPRINT" Then
                NameMe = lstrVersion
            Else
                NameMe = lstrVersion & " - " & pstrCaption
            End If
        Else
            NameMe = lstrVersion
        End If

    End Function

    Friend Function GetDataPreviewImage(ByVal pFile As String, ByVal Item As Integer, ByRef RetPart As Part, ByRef pPieceName As String, _
         ByRef pLeftImage As Image, Optional ByRef pBothImage As Image = Nothing, Optional ByRef pRightImage As Image = Nothing)

        Dim FPs As FacePartStuctureDataFile = UnlockFacePartsPack(fpDir & pFile) 'JM 23/09/2004

        Dim ThisPart As New KidsMaskPrint.Part()
        pPieceName = ThisPart.FaceMaster 'JM 19/09/2004
        RetPart = FPs.Parts(Item)
        pLeftImage = RetPart.FullImage '.Clone 'JM 23/09/2004

        If RetPart.BothParts = True Then

            '--- 'JM 23/09/2004 ---
            Dim imgWidth As Single = RetPart.FullImage.Width
            Dim imgHeight As Integer = RetPart.FullImage.Height + 20

            Dim LeftPoint As Point = RetPart.LeftPart
            Dim RightPoint As Point = RetPart.RightPart

            Dim CanvasWidth As Integer = 0 + imgWidth + (RightPoint.X - LeftPoint.X) + imgWidth + LeftPoint.X

            Dim NewBitmap As Bitmap = New Bitmap(CanvasWidth, imgHeight)
            Dim g As Graphics = Graphics.FromImage(NewBitmap)

            g.FillRectangle(Brushes.White, 0, 0, CanvasWidth, imgHeight)
            g.DrawImage(RetPart.FullImage, New Point(0, 0))

            Dim RightImage As Image = RetPart.FullImage.Clone

            RightImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
            pRightImage = RightImage

            g.DrawImage(RightImage, New Point(RightPoint.X - LeftPoint.X, 0))
            'g.DrawRectangle(Pens.Red, 0, 0, CanvasWidth - 1, imgHeight - 1)

            pBothImage = NewBitmap
            '--- 'JM 23/09/2004 ---
        End If

    End Function
    Friend Function x(ByVal pstrString As String) As String
        Dim lintArrInc As Integer
        Dim lstrChar As String

        For lintArrInc = 0 To pstrString.Length - 1
            lstrChar = Microsoft.VisualBasic.Mid(pstrString, lintArrInc + 1, 1)
            If Microsoft.VisualBasic.Asc(lstrChar) >= 48 And Microsoft.VisualBasic.Asc(lstrChar) <= 57 Then
                x &= lstrChar
            End If
        Next lintArrInc
    End Function
    Friend Function AcceptLicense(ByVal pform As Form) As Boolean
        'added 'JM 15/08/2004
        Dim dlgResult As DialogResult
        Dim lAcceptReg As New AcceptReg()
        With lAcceptReg

            AcceptLicense = False
            .Caption = NameMe("")
            .Owner = pform 'JM 09/09/2004
            .ProdName = "KidsMaskPrint " & gYear 'JM 07/01/2005 2004"
            dlgResult = .ShowDialog()

            If dlgResult = DialogResult.OK Then
                'create temp license file
                Dim lstrTemp As String
                Dim clsEnc As New MyCrypto()

                If x(.LicenseCode) = "" Then
                    MessageBox.Show("Your license code was not accepted!", NameMe(""), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Function
                End If

                lstrTemp = clsEnc.Encrypt(x(.LicenseCode), "bUnn1es#j*mp@thr")
                clsEnc = Nothing

                Dim lstrEncFile As String = System.IO.Path.GetDirectoryName( _
                    System.Reflection.Assembly.GetEntryAssembly.Location.ToString()) & "\Temp-" & _
                    Date.Now.ToString("dddd-dd-MMM-yyyy-HH-mm-ss") & ".tmp"

                ReDim Preserve lstrTempFiles(lstrTempFiles.GetUpperBound(0) + 1)
                lstrTempFiles(lstrTempFiles.GetUpperBound(0)) = lstrEncFile

                Dim lintFreeFile As Integer = Microsoft.VisualBasic.FreeFile()
                Microsoft.VisualBasic.FileOpen(lintFreeFile, lstrEncFile, Microsoft.VisualBasic.OpenMode.Output)
                Microsoft.VisualBasic.Print(lintFreeFile, lstrTemp)
                Microsoft.VisualBasic.FileClose(lintFreeFile)

                'check license
                Dim lintCheck As Integer = 16
                Try
                    lintCheck = Unlock(lstrEncFile, Nothing, "", "") 'added ,"" 'JM 08/09/2004
                Catch

                End Try

                If lintCheck <> 245 + 12 Then
                    MessageBox.Show("Your license code was not accepted!", NameMe(""), MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    Try
                        System.IO.File.Delete(lstrEncFile)
                    Catch
                    End Try
                Else

                    Try
                        System.IO.File.Delete(System.IO.Path.GetDirectoryName( _
                        System.Reflection.Assembly.GetExecutingAssembly.Location.ToString()) & "\keyfile.mcl")
                    Catch
                    End Try

                    System.IO.File.Copy(lstrEncFile, System.IO.Path.GetDirectoryName( _
                        System.Reflection.Assembly.GetExecutingAssembly.Location.ToString()) & "\keyfile.mcl")

                    MessageBox.Show("Your license code was accepted!" & CR() & "The program must now be restarted.", NameMe(""), MessageBoxButtons.OK, MessageBoxIcon.Information)

                    AcceptLicense = True
                    mintVersion = 32
                End If
            End If
        End With
    End Function
    Friend Sub StandardUpgradeTidy()
        'added 'JM 15/08/2004
        If InStrGet((NameMe("")).ToUpper, "TRIAL") = 0 Then

            Dim lstrDemoBuyPage As String = _
            System.Environment.GetFolderPath(Environment.SpecialFolder.StartMenu.Programs) & _
                "KidsMaskPrint\How to Buy KidsMaskPrint.url"

            Dim lbooSucess As Boolean = False
            If System.IO.File.Exists(lstrDemoBuyPage) = True Then
                Try
                    System.IO.File.Delete(lstrDemoBuyPage)
                    lbooSucess = True
                Catch ex As Exception
                    '
                End Try
            End If


            If lbooSucess = False Then
                lstrDemoBuyPage = _
               System.Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) & _
                   "\Programs\KidsMaskPrint\How to Buy KidsMaskPrint.url"
                If System.IO.File.Exists(lstrDemoBuyPage) = True Then
                    Try
                        System.IO.File.Delete(lstrDemoBuyPage)
                        lbooSucess = True
                    Catch ex As Exception
                        '
                    End Try
                End If
            End If
        End If



        'Dim lstrFileStr As String
        'Dim lstrPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location.ToString()) & "\Help\Welcome.html"

        'Dim OpenFile As FileStream = New FileStream(lstrPath, FileMode.Open, FileAccess.Read, FileShare.Read)             'JM 21/08/2003

        'Dim StreamReader As StreamReader = New StreamReader(OpenFile)
        'lstrFileStr = StreamReader.ReadToEnd '.Read 'Line()
        'StreamReader.Close()
        'OpenFile.Close()

        'Dim RepStr As String = "Please remember you only have a 30 day evaluation. After this time you will be unable to use the program. <a href='http://www.mindwarp-consultancy-software.com/buy-products.html' target='_blank'>Click here to Buy!</a><BR><BR>"
        'lstrFileStr = lstrFileStr.Replace(RepStr, "")

        'Dim lintFreeFile As Integer = Microsoft.VisualBasic.FreeFile()
        'Microsoft.VisualBasic.FileOpen(lintFreeFile, lstrPath, Microsoft.VisualBasic.OpenMode.Output)
        'Microsoft.VisualBasic.Print(lintFreeFile, lstrFileStr)
        'Microsoft.VisualBasic.FileClose(lintFreeFile)

    End Sub
    Friend Sub BlackKeys(ByRef lstrKeys() As String)
        ReDim lstrKeys(0)
        lstrKeys(0) = "xxxx"
    End Sub
    Friend Function DataFileProductIdent(ByVal pstrProductNumber As String) As String
        'added 'JM 10/09/2004
        Select Case pstrProductNumber
            Case "223018"
                Return "AEE"
            Case "223019"
                Return "F00"
            Case "223020"
                Return "C12"
            Case "223021"
                Return "0EF"
        End Select

    End Function
    Friend Function GetHelpFile() As String
        'JM 23/09/2003 - Internationalized
        Dim lstrHelpFile As String
        Dim lstrLang2Char As String = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName
        Select Case lstrLang2Char
            Case "de"
                lstrHelpFile = Application.StartupPath & "\de\" & gProgName & ".de.chm"
            Case Else
                lstrHelpFile = Application.StartupPath & "\" & gProgName & ".chm"
        End Select

        Return lstrHelpFile

    End Function
    Friend Enum HelpTopicEnum
        SignIn
        Slots
        MainScreen
        Printing
        ParentOptions
        FacePartSelect
        quickstart
        support
        welcome
        buy
    End Enum
    Friend Function GetHelpTopic(ByVal HelpTopic As HelpTopicEnum) As String

        Select Case HelpTopic
            Case HelpTopicEnum.SignIn
                Return "signin.html"
            Case HelpTopicEnum.Slots
                Return "slots.html"
            Case HelpTopicEnum.MainScreen
                Return "mainscreen.html"
            Case HelpTopicEnum.Printing
                Return "printing.html"
            Case HelpTopicEnum.ParentOptions
                Return "parentoptions.html"
            Case HelpTopicEnum.FacePartSelect
                Return "facepartselect.html"
            Case HelpTopic.support
                Return "support.html"
            Case HelpTopic.welcome
                Return "welcome.html"
            Case HelpTopic.buy
                Return "buy.html"          
            Case HelpTopic.quickstart
                Return "quickstart.html"
        End Select

    End Function
    Private Sub MainStart()

        gstrMRPs = "0011"

        'added 'JM 16/08/2004
        Dim lintThreads As Integer = 259
        Dim lflaDBResult As Long

        Dim eh1 As CustomExceptionHandler = New CustomExceptionHandler()
        gstrMRPs = "0013"
        Try
            gstrMRPs = "0015"
            'AddDebugComment("KidsMaskPrint.mainStart - Topmost")
            gstrProbComtStack = " Topmost" 'JM 01/05/2005

            gdatSystemStart = Date.Now

            '--- 'JM 24/08/2005 ---
            Dim NoDupe As KillIt
            If Not Microsoft.VisualBasic.IsNothing(NoDupe.PrevInstance) Then
                NoDupe.PrevInstance.Kill()
            End If
            '--- 'JM 24/08/2005 ---

            With gstrManifestSite(0)
                .strSitePath = "http://www.kidsmaskprint.com"
                .strManifestDir = "updates/"
                .strManifestFile = "kmp.xml"
            End With
            gstrMRPs = "0020"
            If System.IO.File.Exists(System.Reflection.Assembly.GetEntryAssembly.Location.ToString() & ".dat") = False Then
                Try 'JM 04/09/2005
                    GetSetting("CFU Code", "10", InitalXMLConfig.XmlConfigType.AppSettings, "")
                Catch 'JM 04/09/2005
                    '--- 'JM 04/09/2005 ---
                    gstrMRPs = "0021"
                    MessageBox.Show("The program has been unable to write settings, please ensure you" & Environment.NewLine & _
                        "have Administrator privileges and try again!" _
                        , NameMe(""), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End
                    GoTo Exhaust
                    '--- 'JM 04/09/2005 ---
                End Try 'JM 04/09/2005
            End If
            gstrMRPs = "0025"

            'AddDebugComment("KidsMaskPrint.mainStart - 1")
            gstrProbComtStack &= " #MS1" 'JM 01/05/2005

            If flamenow() Then
                Dim lstrDetails2(2) As String
                Dim lstrDetails1(1) As String
                Dim lstrRetVal As String
                Dim lstrRetVal1 As String

                lstrDetails2(0) = "33IHGPFEDPIHGPFEDP"
                lstrDetails2(1) = "ZRYKGLS<FZS?KFZ<ULK;ESR;ZGAKGFU;MZH?UGK;EHW;UGZ<FKZ<HEL;ZJHKKJU;HNA;Lm"
                lstrDetails2(2) = "pPmK"

                lstrRetVal = Decrypt("", "", flame.Encops.EncryptString, lstrDetails2)

                lstrDetails1(0) = "33IHGPFEDPIHGPFEDP"
                lstrDetails1(1) = "jNU;YGU;ZWNKKGU;ZGKKMUZ<KTZ<AKE;HZK?FRU;HZJ?HKS;HYM;GZY?LVZ<HUF;HAY<mK"

                lstrRetVal1 = Decrypt("", "", flame.Encops.EncryptString, lstrDetails1)

                MessageBox.Show(NameMe("") & lstrRetVal & Environment.NewLine & Environment.NewLine & lstrRetVal1, NameMe(""), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Console.WriteLine(lstrRetVal)
                Console.WriteLine(lstrRetVal1)
                lstrRetVal1 = ""
                lstrRetVal = ""
                Try : SaveSetting("MRP", gstrMRPs, InitalXMLConfig.XmlConfigType.AppSettings, "") : Catch : End Try 'JM 30/07/2005
                End
                GoTo Exhaust
            End If

            gstrMRPs = "0035"
            'AddDebugComment("KidsMaskPrint.mainStart - 2")
            gstrProbComtStack &= " #MS2" 'JM 01/05/2005

            '--- 'JM 10/09/2004 ---
            Dim Dets As strat1.UnlockDetails
            TakeCare(lintThreads, Dets)
            Dets = Nothing
            '--- 'JM 10/09/2004 ---

            Dim IRes As Integer
            'MessageBox.Show("Put EXE CRC CHeck back in Jules!") : IRes = 1 'JM 02/02/2005
            IRes = GetWrittenCRC(AppExe)

            Dim lstrDetails(2) As String
            Dim lstrRetVal3 As String

            lstrDetails(0) = "33IHGPFEDPIHGPFEDP"
            lstrDetails(1) = "wKJ;AHQ;SRF;ZHJPJGZPmQL;VCY;HJZ<wKL;GEN;FYL;WAZ<nFV;LmpPyNN;ZHQKSRF;GZ"
            lstrDetails(2) = "H?UGU;HDU;VLm@pmO"

            lstrRetVal3 = Decrypt("", "", flame.Encops.EncryptString, lstrDetails)

            'MessageBox.Show("Put Code back in jules!")
            gstrMRPs = "0050"

#If Not Debug Then

            If IRes = 1 Then
                '
            ElseIf IRes = -1 Then
                MessageBox.Show(NameMe("") & Environment.NewLine & Environment.NewLine & lstrRetVal3, NameMe("") & "   ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Try : SaveSetting("MRP", gstrMRPs, InitalXMLConfig.XmlConfigType.AppSettings, "") : Catch : End Try 'JM 30/07/2005
                End
                GoTo Exhaust
            Else
                MessageBox.Show(NameMe("") & Environment.NewLine & Environment.NewLine & lstrRetVal3, NameMe("") & "   ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Try : SaveSetting("MRP", gstrMRPs, InitalXMLConfig.XmlConfigType.AppSettings, "") : Catch : End Try 'JM 30/07/2005
                End
                GoTo Exhaust
            End If
#End If
            'AddDebugComment("KidsMaskPrint.mainStart - 3")
            gstrProbComtStack &= " #MS3" 'JM 01/05/2005

            Try
                Dim MaskDir As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) & "\" & "\Masks\"
                If IO.Directory.Exists(MaskDir) = False Then
                    IO.Directory.CreateDirectory(MaskDir)
                End If
            Catch
                '
            End Try
            gstrMRPs = "0065"

            'AddDebugComment("KidsMaskPrint.mainStart - 4")
            gstrProbComtStack &= " #MS4" 'JM 01/05/2005

            lflaDBResult = GetWindowsDir(gstrDBFlamer, gstrProbComtStack)

            'Catch ex As Exception
            'AddDebugComment("KidsMaskPrint.mainStart - Basic Checks done")
            gstrProbComtStack &= " #MSBasic Checks done" : AddDebugComment(gstrProbComtStack) : gstrProbComtStack = "" 'JM 01/05/2005

        Catch ex As Exception
            AddDebugComment("<Font color=Red>MSG:" & ex.ToString & "</font>")
            eh1.OnThreadException(Nothing, Nothing)

        End Try

        gstrMRPs = "0070"

        '--- 'JM 10/11/2004 ---

        Dim lstrPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location.ToString())
        If File.Exists(lstrPath & "\CD.dat") = True Then

            Dim FileStream As Stream = File.Open(lstrPath & "\CD.dat", FileMode.Open)
            Dim FileFormatter As New BinaryFormatter()
            Dim ThisCD As New CDDataIncluded()
            ThisCD = DirectCast(FileFormatter.Deserialize(FileStream), CDDataIncluded)

            With ThisCD
                Select Case .NumofPacks
                    Case 1
                        If IntroduceCDPack(.Pack1) = True Then
                            Try : File.Delete(lstrPath & "\CD.dat") : Catch : End Try
                        End If
                    Case 2
                        If IntroduceCDPack(.Pack1) = True And IntroduceCDPack(.Pack2) = True Then
                            Try : File.Delete(lstrPath & "\CD.dat") : Catch : End Try
                        End If
                    Case 3
                        If IntroduceCDPack(.Pack1) = True And IntroduceCDPack(.Pack2) = True And IntroduceCDPack(.Pack3) = True Then
                            Try : File.Delete(lstrPath & "\CD.dat") : Catch : End Try
                        End If
                End Select
                gstrMRPs = "0090"
            End With
        End If
        '--- 'JM 10/11/2004 ---


        If lflaDBResult = 2 Then
#If Not Debug Then


            '---- LIVE CODE ----
            Try
                Dim mdbsMain As New frmMain()
                Dim eh As CustomExceptionHandler = New CustomExceptionHandler()
                AddHandler Application.ThreadException, AddressOf eh.OnThreadException
                'MessageBox.Show("Put handler back in jules!")
                'mdbsMain.ShowDialog()
                'If gbooDebug = True Then MessageBox.Show("Debug position = 18A", "KidsMaskPrint") 'JM 31/07/2004
                gstrMRPs = "0100"
                Application.Run(mdbsMain)
            Catch

            End Try
            '---- LIVE CODE ----
#Else
            '----- TESTING CODE ----
            Dim mdbsMain As New frmMain()
            'MessageBox.Show("Put handler back in jules!")
            mdbsMain.ShowDialog()
            '----- TESTING CODE ----
#End If

            AddDebugComment("KidsMaskPrint.mainStart - Ending")

            lflaDBResult = GetWindowsDir(gstrDBFlamer, gstrProbComtStack)
            gstrProbComtStack &= " #MSEnd" : AddDebugComment(gstrProbComtStack) : gstrProbComtStack = "" 'JM 01/05/2005

            ProcessAnyCFU()

        Else
            Dim eh2 As CustomExceptionHandler = New CustomExceptionHandler() 'JM 16/08/2004

            Try 'JM 16/08/2004

                'if checkdates have been failed OR 
                Dim BetaSplash As New strat3welcome()
                BetaSplash.ShowInTaskbar = True
                '--- 'JM 16/08/2004 ---
                BetaSplash.Title = mstrTitle
                BetaSplash.Bullet1 = mstrBullet1
                BetaSplash.Bullet2 = mstrBullet2
                BetaSplash.Bullet3 = mstrBullet3
                BetaSplash.Bullet4 = mstrBullet4
                '--- 'JM 16/08/2004 ---
                BetaSplash.Expired = True
                BetaSplash.Icon = New System.Drawing.Icon( _
                                System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("KidsMaskPrint.kmp.ico"))
                BetaSplash.ShowDialog()

                '--- 'JM 16/08/2004 ---
            Catch ex As Exception
                AddDebugComment("<Font color=Red>MSG:" & ex.ToString & "</font>")
                eh2.OnThreadException(Nothing, Nothing)

            End Try
            '--- 'JM 16/08/2004 ---
        End If

Exhaust:
        Try : SaveSetting("MRP", gstrMRPs, InitalXMLConfig.XmlConfigType.AppSettings, "") : Catch : End Try 'JM 30/07/2005

    End Sub
    Private Function IntroduceCDPack(ByVal PackName As String) As Boolean

        IntroduceCDPack = False
Start:
        'Get CD location
        Dim fb As New DirBrowser()

        fb.Description = "Please select your CD drive with your '" & PackName & "' inserted!"
        fb.ShowDialog()
        Dim lstrPackFile As String = fb.ReturnPath & "Pack.dat"

        If File.Exists(lstrPackFile) = True Then
            'check CD key for pack string
            Dim FileStream As Stream = File.Open(lstrPackFile, FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim FileFormatter As New BinaryFormatter()
            Dim ThisPack As New CDPack()
            ThisPack = DirectCast(FileFormatter.Deserialize(FileStream), CDPack)

            Dim lstrPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location.ToString())
            Try
                File.Copy(fb.ReturnPath & ThisPack.KeyFileName, lstrPath & "\FaceParts\" & ThisPack.KeyFileName)
            Catch
                IntroduceCDPack = False
            End Try
            'return sucess etc
            IntroduceCDPack = True
            Try : FileStream.Close() : Catch : End Try 'JM 06/12/2004
            Try : ThisPack = Nothing : Catch : End Try 'JM 06/12/2004

            'JM 29/01/2005
            MessageBox.Show("Your '" & PackName & "' was installed OK!", NameMe(""), MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Your '" & PackName & "' wasn't found, would you like to try and find it again?", NameMe(""), MessageBoxButtons.YesNo)
            If dlgRes = DialogResult.Yes Then
                GoTo Start
            End If
        End If

    End Function
    Friend Function GetWindowsDir(ByVal pstrResource As flamer, ByRef pstrProbComtStack As String) As Long
        'added 'JM 16/08/2004
        If InStrGet((NameMe("")).ToUpper, "TRIAL") = 0 Then
            Return 2
        Else
            Return CheckDates(pstrResource, 4, pstrProbComtStack)
        End If

    End Function
    Friend Sub DeleteTempFiles()
        'added 'JM 16/08/2004
        Dim lintArrInc As Integer

        Try
            For lintArrInc = 0 To lstrTempFiles.GetUpperBound(0)
                If lstrTempFiles(lintArrInc) <> "" Then
                    If RightGet(lstrTempFiles(lintArrInc), 1) = "\" Then
                        Try
                            Directory.Delete(lstrTempFiles(lintArrInc), True)
                        Catch
                        End Try
                    Else
                        Try
                            File.Delete(lstrTempFiles(lintArrInc))
                        Catch
                        End Try
                    End If
                End If
            Next lintArrInc
        Catch ex As Exception
        End Try
    End Sub

    Friend Sub Welcome(ByRef pbooSplashShown As Boolean, ByVal powner As Form)
        'added 'JM 16/08/2004


        If pbooSplashShown = False Then
            pbooSplashShown = True
            Dim BetaSplash As New strat3welcome()
            BetaSplash.Title = mstrTitle
            BetaSplash.Bullet1 = mstrBullet1
            BetaSplash.Bullet2 = mstrBullet2
            BetaSplash.Bullet3 = mstrBullet3
            BetaSplash.Bullet4 = mstrBullet4
            BetaSplash.BuyNowURL = "http://www.KidsMaskPrint.com/buy.php" 'JM 16/10/2004
            BetaSplash.Owner = powner
            BetaSplash.ShowInTaskbar = True 'JM 19/08/2004
            BetaSplash.Icon = New System.Drawing.Icon( _
                System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("KidsMaskPrint.kmp.ico")) 'JM 07/09/2004

            BetaSplash.ShowDialog()
        End If

        powner.Activate()

    End Sub
    Friend Function LoadMask(ByVal FileName As String, ByRef pPieces As ArrayList, _
        ByRef RetPicThumbnail As Image, ByVal pbooJustPreview As Boolean, ByRef pMousePath() As GraphicsPath, _
        ByRef pReverseMousePath() As GraphicsPath, ByRef pMousePB() As PaintBrush, _
        ByRef pReverseMousePB() As PaintBrush, ByVal pLicensedFaceParts As ArrayList, _
        ByRef pUserPieces As FacePartStuctureDataFile, ByRef pSortOrderForData As SortOrderForData)

        AddDebugComment("Main.LoadMask - 1") 'JM 26/09/2004

        Dim hash As SortedList = Nothing

        Try 'JM 13/10/2004
            Dim FileStream As Stream = File.Open(FileName, FileMode.Open)
            Dim FileFormatter As New BinaryFormatter()
            hash = DirectCast(FileFormatter.Deserialize(FileStream), SortedList) '1

            AddDebugComment("Main.LoadMask - 2") 'JM 12/10/2004

            Dim ThumbImg As Image = DirectCast(FileFormatter.Deserialize(FileStream), Image) '2 ThumbNail Image

            AddDebugComment("Main.LoadMask - 3") 'JM 12/10/2004

            '############### TESTING #############
            Try
                Dim UserFacePartDatsStrutest As New FacePartStuctureDataFile()
                UserFacePartDatsStrutest = DirectCast(FileFormatter.Deserialize(FileStream), FacePartStuctureDataFile)
                pUserPieces = UserFacePartDatsStrutest

                ''MessageBox.Show("Testing")
                ''Dim ThisPart As New KidsMaskPrint.Part()
                ''ThisPart = UserFacePartDatsStrutest.Parts(0)
                ''ThumbImg = ThisPart.ThumbImage

                'JM 14/10/2004
                pSortOrderForData = DirectCast(FileFormatter.Deserialize(FileStream), SortOrderForData)
            Catch
                AddDebugComment("Main.LoadMask - Catch") 'JM 12/10/2004

                ' this will provide compatibility with older mask files
            End Try
            '############### TESTING #############

            AddDebugComment("Main.LoadMask - 4") 'JM 12/10/2004

            RetPicThumbnail = ThumbImg

            If pbooJustPreview = True Then
                FileStream.Close()
                AddDebugComment("Main.LoadMask - 5") 'JM 26/09/2004

                Exit Function
            Else
                FileStream.Close()
            End If
        Catch 'JM 13/10/2004
            Dim NAPic As Image = Image.FromStream( _
                        System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("KidsMaskPrint.NotAvail.png"))
            RetPicThumbnail = NAPic
            MessageBox.Show("There was a problem opening a mask file!" & CR() & CR() & FileName, NameMe("")) 'JM 13/10/2004
            Exit Function
        End Try

        AddDebugComment("Main.LoadMask - 6") 'JM 26/09/2004

        pPieces.Clear()

        '--- 'JM 29/08/2004 ---
        Dim MousePath() As GPArr  'JM 29/08/2004
        Dim ReverseMousePath() As GPArr  'JM 29/08/2004

        ''Dim MousePointArray() As PointF
        ''Dim MouseTypeArray() As Byte
        Dim MousePaintBrush() As PaintBrush 'JM 28/08/2004
        ''Dim ReverseMousePointArray() As PointF
        ''Dim ReverseMouseTypeArray() As Byte
        Dim ReverseMousePaintBrush() As PaintBrush 'JM 28/08/2004
        '--- 'JM 29/08/2004 ---
        Dim lstrVersion As String
        Dim de As DictionaryEntry


        Dim MPPCounter As Integer 'JM 28/08/2004
        Dim MPTCounter As Integer 'JM 28/08/2004
        Dim MPB1Counter As Integer 'JM 28/08/2004
        Dim MPB2Counter As Integer 'JM 28/08/2004

        Dim RPPCounter As Integer 'JM 28/08/2004
        Dim RPTCounter As Integer 'JM 28/08/2004
        Dim RPB1Counter As Integer 'JM 28/08/2004
        Dim RPB2Counter As Integer 'JM 28/08/2004

        Dim lintArrInc As Integer

        Try 'JM 26/09/2004
            For Each de In hash
                'Console.WriteLine(de.Key.ToString)
                '--- 'JM 28/08/2004 ---
                Select Case LeftGet(de.Key.ToString & "    ", 4)
                    Case "AVER"
                        'If de.Key = -1 Then
                        lstrVersion = de.Value
                    Case "BCNT" '
                        Dim MPCount As Integer = AppBasic.ReturnNthStr(de.Value, 1, "#")
                        'ReDim MousePointArray(MPCount)
                        'ReDim MouseTypeArray(MPCount)
                        ReDim MousePaintBrush(MPCount)
                        ReDim MousePath(MPCount)

                        For lintArrInc = 0 To MousePath.GetUpperBound(0)
                            MousePath(lintArrInc) = New GPArr()
                        Next lintArrInc
                        Dim RMPCount As Integer = AppBasic.ReturnNthStr(de.Value, 2, "#")
                        'ReDim ReverseMousePointArray(RMPCount)
                        'ReDim ReverseMouseTypeArray(RMPCount)
                        ReDim ReverseMousePaintBrush(RMPCount)
                        ReDim ReverseMousePath(RMPCount)

                        For lintArrInc = 0 To ReverseMousePath.GetUpperBound(0)
                            ReverseMousePath(lintArrInc) = New GPArr()
                        Next lintArrInc

                    Case "CMPP" '0"
                        If Not de.Value Is Nothing Then
                            'MousePointArray(MPPCounter) = de.Value
                            ''MousePath(MPPCounter) = New GPArr() 'JM 29/08/2004
                            MousePath(MPPCounter).PointArray = de.Value 'JM 29/08/2004
                            MPPCounter += 1
                        Else 'JM 18/10/2004
                            MPPCounter += 1 'JM 18/10/2004
                        End If
                    Case "DMPT" '0"
                        If Not de.Value Is Nothing Then
                            'MouseTypeArray(MPTCounter) = de.Value
                            MousePath(MPTCounter).TypeArray = de.Value 'JM 29/08/2004
                            MPTCounter += 1
                        Else 'JM 18/10/2004
                            MPTCounter += 1 'JM 18/10/2004
                        End If
                    Case "EMBC"
                        If Not de.Value Is Nothing Then
                            MousePaintBrush(MPB1Counter) = New PaintBrush() 'JM 29/08/2004
                            MousePaintBrush(MPB1Counter).BrushColour = de.Value
                            'Console.WriteLine(CType(de.Value, Color).ToKnownColor.ToString)
                            MPB1Counter += 1
                        Else
                            'MessageBox.Show("here")
                        End If
                    Case "FMBW"
                        If Not de.Value Is Nothing Then
                            MousePaintBrush(MPB2Counter).BrushWidth = de.Value
                            MPB2Counter += 1
                        Else
                            'MessageBox.Show("here")
                        End If
                    Case "GRPP"
                        If Not de.Value Is Nothing Then
                            'ReverseMousePointArray(RPPCounter) = de.Value
                            ''ReverseMousePath(RPPCounter) = New GPArr() 'JM 29/08/2004
                            ReverseMousePath(RPPCounter).PointArray = de.Value 'JM 29/08/2004
                            RPPCounter += 1
                        Else 'JM 18/10/2004
                            RPPCounter += 1 'JM 18/10/2004
                        End If
                    Case "HRPT"
                        If Not de.Value Is Nothing Then
                            'ReverseMouseTypeArray(RPTCounter) = de.Value
                            ReverseMousePath(RPTCounter).TypeArray = de.Value 'JM 29/08/2004
                            RPTCounter += 1
                        Else 'JM 18/10/2004
                            RPTCounter += 1 'JM 18/10/2004
                        End If
                    Case "IRBC"
                        If Not de.Value Is Nothing Then
                            ReverseMousePaintBrush(RPB1Counter) = New PaintBrush()
                            ReverseMousePaintBrush(RPB1Counter).BrushColour = de.Value
                            'Console.WriteLine(CType(de.Value, Color).ToKnownColor.ToString)
                            RPB1Counter += 1
                        Else
                            'MessageBox.Show("here")
                        End If
                    Case "JRBW"
                        If Not de.Value Is Nothing Then
                            ReverseMousePaintBrush(RPB2Counter).BrushWidth = de.Value
                            RPB2Counter += 1
                        Else
                            'MessageBox.Show("here")
                        End If
                    Case "ZZZZ" 'Else
                        '--- 'JM 28/08/2004 ---

                        'Else

                        Dim ThisPiece As New Piece() ' ("D:\desktopnt\scraps\flag.png")
                        ThisPiece.SourceDataFileName = AppBasic.ReturnNthStr(de.Value, 1, "|") 'JM 19/08/2004
                        ThisPiece.DataFileItemNum = CInt(AppBasic.ReturnNthStr(de.Value, 2, "|")) 'JM 19/08/2004
                        ThisPiece.VertFlip = (CBool(AppBasic.ReturnNthStr(de.Value, 5, "|")))
                        ThisPiece.HorizFlip = (CBool(AppBasic.ReturnNthStr(de.Value, 6, "|")))
                        ''ThisPiece.Bitmapname = AppBasic.ReturnNthStr(de.Value, 3, "|") 'JM 17/07/2004
                        ThisPiece.PieceName = AppBasic.ReturnNthStr(de.Value, 7, "|") 'JM 19/09/2004

                        'this next line checks to insure loaded pieces are licensed.
                        'this stops friends exchanging mask files when they don't own the packs.
                        Dim lbooLicensedPieceFound As Boolean = False

                        If pLicensedFaceParts.Count > 0 Then 'JM 26/09/2004 - to cater for error caused by no face packs loaded
                            For lintArrInc = 0 To pLicensedFaceParts.Count - 1 'added -1 'JM 26/09/2004
                                If pLicensedFaceParts(lintArrInc) = ThisPiece.PieceName Then
                                    lbooLicensedPieceFound = True
                                    Exit For
                                End If
                            Next
                        End If 'JM 26/09/2004
                        If lbooLicensedPieceFound = True Then 'JM 22/09/2004  If pLicensedFaceParts Is ThisPiece.PieceName Then 'JM 19/09/2004
                            '--- 'JM 19/08/2004 ---
                            Dim TempPart As New KidsMaskPrint.Part()
                            'GetDataFileImageItem(ThisPiece.SourceDataFileName, ThisPiece.DataFileItemNum, TempPart, Nothing)
                            'GetDataFileImageItem(ThisPiece.SourceDataFileName, ThisPiece.DataFileItemNum, TempPart, Nothing)
                            GetDataPreviewImage(ThisPiece.SourceDataFileName, ThisPiece.DataFileItemNum, TempPart, Nothing, Nothing) 'JM 23/09/2004
                            ThisPiece.SetImageObj(TempPart.FullImage)
                            '--- 'JM 19/08/2004 ---

                            ''ThisPiece.SetImage(mDir & AppBasic.ReturnNthStr(de.Value, 3, "|"))
                            Dim loc As New Point(CSng(AppBasic.ReturnNthStr(de.Value, 3, "|")), CSng(AppBasic.ReturnNthStr(de.Value, 4, "|")))


                            ThisPiece.Location = loc

                            pPieces.Add(ThisPiece)
                        End If
                End Select
                '--- 'JM 27/08/2004 ---
            Next de
        Catch ex As Exception 'JM 26/09/2004
            Throw New Exception(de.Key.ToString & " " & ex.ToString) 'JM 26/09/2004
        End Try 'JM 26/09/2004

        '''--- 'JM 27/08/2004 ---
        '''If Not MousePointArray Is Nothing And Not MouseTypeArray Is Nothing Then
        '''    pMousePath(0) = New GraphicsPath(MousePointArray(0), MouseTypeArray(0))
        '''End If

        ''If Not MousePointArray1 Is Nothing And Not MouseTypeArray1 Is Nothing Then
        ''    pMousePath(1) = New GraphicsPath(MousePointArray1, MouseTypeArray1)
        ''End If

        ''If Not ReverseMousePointArray0 Is Nothing And Not ReverseMouseTypeArray0 Is Nothing Then
        ''    pReverseMousePath(0) = New GraphicsPath(ReverseMousePointArray0, ReverseMouseTypeArray0)
        ''End If

        ''If Not ReverseMousePointArray1 Is Nothing And Not ReverseMouseTypeArray1 Is Nothing Then
        ''    pReverseMousePath(1) = New GraphicsPath(ReverseMousePointArray1, ReverseMouseTypeArray1)
        ''End If
        '''--- 'JM 27/08/2004 ---

        '--- 'JM 29/08/2004 ---

        AddDebugComment("Main.LoadMask - 7") 'JM 26/09/2004

        If Not MousePath Is Nothing Then
            ReDim pMousePath(MousePath.GetUpperBound(0))
            ReDim pMousePB(MousePath.GetUpperBound(0))
            For lintArrInc = 0 To MousePath.GetUpperBound(0)
                Try
                    pMousePath(lintArrInc) = New GraphicsPath(MousePath(lintArrInc).PointArray, MousePath(lintArrInc).TypeArray)
                Catch
                End Try
            Next lintArrInc

            'pMousePB = MousePaintBrush
        End If

        If Not MousePaintBrush Is Nothing Then 'JM 18/10/2004
            pMousePB = MousePaintBrush 'JM 18/10/2004
        End If

        AddDebugComment("Main.LoadMask - 8") 'JM 26/09/2004
        If Not ReverseMousePath Is Nothing Then
            ReDim pReverseMousePath(ReverseMousePath.GetUpperBound(0))
            ReDim pReverseMousePB(ReverseMousePath.GetUpperBound(0))
            For lintArrInc = 0 To ReverseMousePath.GetUpperBound(0) 'JM 24/09/2004
                Try
                    pReverseMousePath(lintArrInc) = New GraphicsPath(ReverseMousePath(lintArrInc).PointArray, ReverseMousePath(lintArrInc).TypeArray)
                Catch
                End Try
            Next lintArrInc
            'pReverseMousePB = ReverseMousePaintBrush
        End If

        If Not ReverseMousePaintBrush Is Nothing Then 'JM 18/10/2004
            pReverseMousePB = ReverseMousePaintBrush 'JM 18/10/2004
        End If

        '--- 'JM 29/08/2004 ---
        AddDebugComment("Main.LoadMask - end") 'JM 26/09/2004
        'DebugFile(pMousePath, pReverseMousePath, MousePaintBrush, ReverseMousePaintBrush)
        'produce debug report of all loaded values

    End Function
    'Public Function DebugFile(ByRef pMousePath() As GraphicsPath, _
    'ByRef pReverseMousePath() As GraphicsPath, ByRef pMousePB() As PaintBrush, _
    'ByRef pReverseMousePB() As PaintBrush)
    '    Dim lintArrInc As Integer

    '    Dim str As String

    '    For lintArrInc = 0 To pMousePath.GetUpperBound(0)
    '        Try : str &= "CMPP" & lintArrInc & " " & pMousePath(lintArrInc).PathPoints.ToString & CR() : Catch : End Try
    '    Next lintArrInc


    '    For lintArrInc = 0 To pMousePath.GetUpperBound(0)
    '        Try : str &= "DMPT" & lintArrInc & " " & pMousePath(lintArrInc).PathTypes.ToString & CR() : Catch : End Try
    '    Next lintArrInc

    '    For lintArrInc = 0 To pMousePB.GetUpperBound(0)
    '        Try : str &= "EMBC" & lintArrInc & " " & pMousePB(lintArrInc).BrushColour.ToString & CR() : Catch : End Try
    '    Next lintArrInc

    '    For lintArrInc = 0 To pMousePB.GetUpperBound(0)
    '        Try : str &= "FMBW" & lintArrInc & " " & pMousePB(lintArrInc).BrushWidth.ToString & CR() : Catch : End Try
    '    Next lintArrInc

    '    For lintArrInc = 0 To pReverseMousePath.GetUpperBound(0)
    '        Try : str &= "GRPP" & lintArrInc & " " & pReverseMousePath(lintArrInc).PathPoints.ToString & CR() : Catch : End Try
    '    Next lintArrInc

    '    For lintArrInc = 0 To pReverseMousePath.GetUpperBound(0)
    '        Try : str &= "HRPT" & lintArrInc & " " & pReverseMousePath(lintArrInc).PathTypes.ToString & CR() : Catch : End Try
    '    Next lintArrInc

    '    For lintArrInc = 0 To pReverseMousePB.GetUpperBound(0)
    '        Try : str &= "IRBC" & lintArrInc & " " & pReverseMousePB(lintArrInc).BrushColour.ToString & CR() : Catch : End Try
    '    Next lintArrInc

    '    For lintArrInc = 0 To pReverseMousePB.GetUpperBound(0)
    '        Try : str &= "JRBW" & lintArrInc & " " & pReverseMousePB(lintArrInc).BrushWidth.ToString & CR() : Catch : End Try
    '    Next lintArrInc

    '    Console.WriteLine(str)

    'End Function
    Friend Sub SaveUserMask(ByVal pstrFileName As String, ByVal pHash As SortedList, ByVal pThumbNailFullImage As Image, _
        ByVal pUserPieces As FacePartStuctureDataFile, ByVal pSortOrderForData As SortOrderForData)

        AddDebugComment("KidsMaskPrint.SaveUserMask - 1") 'JM 22/09/2004

        Try : File.Delete(pstrFileName) : Catch : End Try

        Dim FileStream As Stream = File.Open(pstrFileName, FileMode.Create)
        Dim FileFormatter As New BinaryFormatter()

        AddDebugComment("KidsMaskPrint.SaveUserMask - 2") 'JM 22/09/2004
        FileFormatter.Serialize(FileStream, pHash)

        AddDebugComment("KidsMaskPrint.SaveUserMask - 3") 'JM 13/10/2004
        FileFormatter.Serialize(FileStream, ResizeImageObj(pThumbNailFullImage, 75)) 'JM 17/07/2004  

        AddDebugComment("KidsMaskPrint.SaveUserMask - 4") 'JM 12/10/2004
        '''############### TESTING #############
        ''Dim UserFacePartDatsStrutest As New FacePartStuctureDataFile()
        ''Dim WitchFace As New Part()
        ''With WitchFace
        ''    .PartType = FacePartEnums.ePartType.Outline
        ''    .FullImage = Image.FromFile("D:\CodeLibrary\Games\KMPDataFiles\bin\PackHalloween2004\Witch face.png")
        ''    .ThumbImage = Image.FromFile("D:\CodeLibrary\Games\KMPDataFiles\bin\PackHalloween2004\Witch face.bmp")
        ''    .FaceMaster = "Witch"
        ''    .LeftPart = New Point(112, 156)
        ''    .BothParts = False
        ''End With
        ''UserFacePartDatsStrutest.Parts.Add(WitchFace)

        '''############### TESTING #############

        FileFormatter.Serialize(FileStream, pUserPieces) 'JM 13/10/2004

        FileFormatter.Serialize(FileStream, pSortOrderForData) 'JM 14/10/2004

        FileStream.Close()

        AddDebugComment("KidsMaskPrint.SaveUserMask - 5") 'JM 22/09/2004

    End Sub
    Friend Function UnlockFacePartsPack(ByVal pFileName As String) As FacePartStuctureDataFile
        'added 'JM 23/09/2004
        Dim rijndael As New RijndaelManaged()
        'The RijndaelManaged.GenerateKey & GenerateIV creates a random key & 
        'initialization vector, good for testing, not good for production...

        'rijndael.GenerateKey() ' create random key
        'rijndael.GenerateIV() ' create random initialization vector  

        Dim key As Byte() = {89, 128, 147, 49, 7, 196, 76, 194, 33, 225, 176, 205, 207, 127, 137, 108, 200, 32, 234, 189, 212, 82, 152, 112, 25, 150, 91, 95, 10, 117, 248, 209}
        Dim iv As Byte() = {228, 63, 134, 217, 160, 206, 233, 198, 194, 17, 158, 98, 122, 16, 193, 216}

        Dim decryptor As ICryptoTransform = rijndael.CreateDecryptor(key, iv)

        Dim formatter As New BinaryFormatter()
        Dim input As Stream = File.Open(pFileName, FileMode.Open)
        Dim cryptoInput As New CryptoStream(input, decryptor, CryptoStreamMode.Read)
        Dim FPs As FacePartStuctureDataFile = DirectCast(formatter.Deserialize(cryptoInput), FacePartStuctureDataFile)
        cryptoInput.Close()
        input.Close()

        Return FPs

    End Function
    Function RBDecypt(ByVal pstrInputFile As String) As String
        'not in use in KMP 'JM 13/05/2005
    End Function
    Friend Sub DebugDBComment()
        'added 'JM 01/05/2005

        If gstrProbComtStack <> "" Then
            AddDebugComment(gstrProbComtStack)
        End If

        AddDebugComment("DrawDets: " & gstrProbDrawComtStack) 'JM 04/09/2005

    End Sub

End Module
Friend Class CustomExceptionHandler 'added 'JM 16/08/2004
    Friend Sub OnThreadException(ByVal sender As Object, ByVal t As System.Threading.ThreadExceptionEventArgs)

        Dim lstrErrMsg As String = "Unknown Error"
        Try : SaveSetting("MRP", gstrMRPs, InitalXMLConfig.XmlConfigType.AppSettings, "") : Catch : End Try 'JM 30/07/2005

        Try
            If Not t Is Nothing Then
                If InStrGet(t.Exception.ToString, "System.Runtime.InteropServices.COMException") > 0 Then
                    lstrErrMsg = t.Exception.Message
                    lstrErrMsg = lstrErrMsg.Replace("IPUser", "ADMIN")
                Else
                    lstrErrMsg = t.Exception.Message & Environment.NewLine
                End If
            End If

            Try
                If lstrErrMsg <> "" Then

                    MessageBox.Show(lstrErrMsg & "[CR2]Please use the 'Check for Updates' feature, which will be shown after this message.[CR]A newer version of the program should have fixed any problems in older versions.[CR]If you have tried the 'Check for Updates' feature and already have the latest version[CR]of the program please refer to the help file for support details.".Replace("[CR2]", _
                        Environment.NewLine & Environment.NewLine).Replace("[CR]", _
                        Environment.NewLine) & Environment.NewLine & Environment.NewLine & _
                        "Pos: " & gstrMRPs, NameMe(""), MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Dim NewCFU As New frmCFU(True)
                    With NewCFU
                        .Caption = NameMe("")
                        .FormIcon = New System.Drawing.Icon( _
                            System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("KidsMaskPrint.kmp.ico"))

                        .strManifestSite(gstrManifestSite)

                        Application.DoEvents()
                        .ShowDialog()
                    End With

                    DebugDBComment()

                    Dim lstrError As String = ""
                    If Not t Is Nothing Then
                        lstrError = "<Font color=Red>MSG:" & t.ToString & "<BR>{" & lstrErrMsg.Replace(Environment.NewLine, "") & "}</font>"
                    End If

                    If lstrError <> "" Then
                        AddDebugComment(lstrError)
                    End If


                    If gbooNeedToRestartProgAfterCFU = True And gstrCFUTempDir <> "" Then
                        Dim lstrReportNames() As String
                        LoadReportsNames(lstrReportNames)
                        DumpThisErrorLog(NameMe(""), lstrReportNames, gdatSystemStart)
                    Else
                        Dim ErrRep As New ProbHand.BugReport(True)
                        With ErrRep
                            .SysStartTime = gdatSystemStart
                            .Caption = NameMe("")
                            .FormIcon = New System.Drawing.Icon( _
                                System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("KidsMaskPrint.kmp.ico"))

                            Application.DoEvents()

                            .ShowDialog()
                        End With
                    End If

                    ProcessAnyCFU()

                End If
            Catch
                '
            End Try
        Finally
            Environment.Exit(0)
        End Try

    End Sub

End Class
<DoNotObfuscateAttribute()> Friend Module Base
    <DoNotObfuscateAttribute()> Friend gstrManifestSite(0) As ManifestInfo
    <DoNotObfuscateAttribute()> Friend gdatSystemStart As Date

    <DoNotObfuscateAttribute()> Friend m_PageSettings As New System.Drawing.Printing.PageSettings()
    <DoNotObfuscateAttribute()> Friend gProgName As String = "KidsMaskPrint"
    <DoNotObfuscateAttribute()> Friend gYear As String = "2005" 'JM 07/01/2005
    <DoNotObfuscateAttribute()> Friend gstrProbComtStack As String = "" 'JM 01/05/2005
    <DoNotObfuscateAttribute()> Friend gstrProbDrawComtStack As String = "" 'JM 04/09/2005
    <DoNotObfuscateAttribute()> Friend gstrMRPs As String = "" 'JM 30/07/2005

End Module
<System.AttributeUsage(AttributeTargets.Class Or AttributeTargets.Field _
Or AttributeTargets.Method Or AttributeTargets.Parameter Or AttributeTargets.Enum)> _
Friend Class ObfuscateAttribute
    Inherits System.Attribute
End Class 'ObfuscateAttribute

<System.AttributeUsage(AttributeTargets.Class Or AttributeTargets.Field _
Or AttributeTargets.Method Or AttributeTargets.Parameter Or AttributeTargets.Enum)> _
Friend Class DoNotObfuscateAttribute
    Inherits System.Attribute
End Class 'DoNotObfuscateAttribute

<System.AttributeUsage(AttributeTargets.Assembly, allowmultiple:=True)> _
Friend Class ObfuscateBlockAttribute
    Inherits System.Attribute
    Private BlockString As String
    Public Sub New(ByVal BlockString As String)
        MyClass.BlockString = BlockString
    End Sub
End Class