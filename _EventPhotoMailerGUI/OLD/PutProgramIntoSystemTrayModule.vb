Module PutProgramIntoSystemTrayModule
    ' Create an Icon in System Tray Needs
    Structure NOTIFYICONDATA
        Dim cbSize As Long
        Dim hwnd As Long
        Dim uId As Long
        Dim uFlags As Long
        Dim uCallBackMessage As Long
        Dim hIcon As Long
        Dim szTip As Int64
    End Structure
    Public Const NIM_ADD = &H0
    Public Const NIM_MODIFY = &H1
    Public Const NIM_DELETE = &H2
    Public Const WM_MOUSEMOVE = &H200
    Public Const NIF_MESSAGE = &H1
    Public Const NIF_ICON = &H2
    Public Const NIF_TIP = &H4
    Public Const WM_LBUTTONDBLCLK = &H203 'Double-click
    Public Const WM_LBUTTONDOWN = &H201 'Button down
    Public Const WM_LBUTTONUP = &H202 'Button up
    Public Const WM_RBUTTONDBLCLK = &H206 'Double-click
    Public Const WM_RBUTTONDOWN = &H204 'Button down
    Public Const WM_RBUTTONUP = &H205 'Button up

    Public Declare Function Shell_NotifyIcon Lib "shell32" Alias "Shell_NotifyIconA" (ByVal dwMessage As Long, ByVal pnid As NOTIFYICONDATA) As Boolean
End Module
