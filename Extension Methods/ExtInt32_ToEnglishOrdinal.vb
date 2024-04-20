Imports System
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Threading 'referenced in documentation comment

''' <summary>Module that defines an extension method to translate an Int32 value into an English ordinal.</summary>
<Acknowledgment(Author:="Christoph Hafner", SourceUrl:="https://www.nuget.org/packages/SingleFile.VB.ExtInt32.ToEnglishOrdinal/1.0.25", License:=GetType(MitLicense), Comment:="Leave this acknowledgment 'as-is' and you are legally licensed.")> _
Friend Module ExtInt32_ToEnglishOrdinal

    'Private Fields
    Private ReadOnly _enUS As CultureInfo = New CultureInfo("en-US", False)

    'Public Methods

    ''' <summary>Converts the given number to an English ordinal number (e.g "1st", "2nd", "3rd", "11th", "21th", "12,321st", 
    ''' -2nd" etc.). Because this method is used in an English language context, the format provider defaults to "en-US" if 
    ''' not explicitly specified and not to <see cref="Thread.CurrentCulture">Thread.CurrentThread.CurrentCulture</see>.</summary>
    ''' <param name="number">The number to be translated into an English ordinal.</param>
    ''' <param name="format">The format to be used (e.g. "#,##0") to group digits or null to keep the default (no grouping).</param>
    ''' <param name="formatProvider">The format provider to be used or null to use "en-US" (without overrides).</param>
    ''' <returns>System.String.</returns>
    <Extension()> _
    Public Function ToEnglishOrdinal(number As Int32, Optional format As String = Nothing, Optional formatProvider As IFormatProvider = Nothing) As String
        'Check format provider
        If (formatProvider Is Nothing) Then
            formatProvider = _enUS
        End If
        'Initialize result
        Dim myNumber As String = number.ToString(format, formatProvider)
        'Get last two digits of number
        Dim myValue As Int32 = (number Mod 100)
        Select Case myValue
            Case 1, 21, 31, 41, 51, 61, 71, 81, 91, -1, -21, -31, -41, -51, -61, -71, -81, -91
                Return myNumber & "st"
            Case 2, 22, 32, 42, 52, 62, 72, 82, 92, -2, -22, -32, -42, -52, -62, -72, -82, -92
                Return myNumber & "nd"
            Case 3, 23, 33, 43, 53, 63, 73, 83, 93, -3, -23, -33, -43, -53, -63, -73, -83, -93
                Return myNumber & "rd"
            Case Else 'including 0th, 11th, 12th, 13th etc.
                Return myNumber & "th"
        End Select
    End Function

End Module
