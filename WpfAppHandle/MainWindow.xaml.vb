Imports System.Text
Imports System.Windows.Interop

Class MainWindow
    Private Declare Function GetTopWindow Lib "user32" Alias "GetTopWindow" (ByVal hwnd As Int32) As Int32
    Private Declare Function GetWindow Lib "user32" Alias "GetWindow" (ByVal hwnd As Int32, ByVal wCmd As Int32) As Int32
    Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Int32, ByVal lpString As StringBuilder, ByVal cch As Int32) As Int32
    Declare Function GetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As Int32) As Int32
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim h = New WindowInteropHelper(Me).Handle
        For i = 1 To 15
            Console.WriteLine(getwintext(h))
            h = GetWindow(h, 2)
        Next
    End Sub
    Private Function getwintext(hwnd As Int32) As String
        Dim length As Int32 = GetWindowTextLength(hwnd)
        Dim windowName As StringBuilder = New StringBuilder(length + 1)
        GetWindowText(hwnd, windowName, windowName.Capacity)
        Return windowName.ToString
    End Function
End Class
