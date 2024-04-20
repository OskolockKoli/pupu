#If DEBUG Then
'----------------------------------------------------------------------------------------
Imports System
Imports System.Globalization
Imports Microsoft.VisualStudio.TestTools.UnitTesting 'Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll (with "Copy Local = False")

<TestClass()> _
<Acknowledgment(Author:="Christoph Hafner", SourceUrl:="https://www.nuget.org/packages/SingleFile.VB.ExtInt32.ToEnglishOrdinal/1.0.25", License:=GetType(MitLicense), Comment:="Leave this acknowledgment 'as-is' and you are legally licensed.")> _
Public Class Test_ExtInt32_ToEnglishOrdinal

    <TestMethod()> _
    <TestCategory("Extension Methods")> _
    Public Sub ExtInt32_ToEnglishOrdinal()
        Dim myInput As Int32 = 0
        Dim myFormat As String = Nothing
        Dim myFormatProvider As IFormatProvider = Nothing
        Dim myResult As String = Nothing
        Try
            'Check 1st
            myInput = 1
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("1st", myResult)
            'Check 2nd
            myInput = 2
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("2nd", myResult)
            'Check 3rd
            myInput = 3
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("3rd", myResult)
            'Check 4th
            myInput = 4
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("4th", myResult)
            'Check 5th
            myInput = 5
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("5th", myResult)
            'Check 6th
            myInput = 6
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("6th", myResult)
            'Check 7th
            myInput = 7
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("7th", myResult)
            'Check 8th
            myInput = 8
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("8th", myResult)
            'Check 9th
            myInput = 9
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("9th", myResult)
            'Check 10th
            myInput = 10
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("10th", myResult)
            'Check 11th
            myInput = 11
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("11th", myResult)
            'Check 12th
            myInput = 12
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("12th", myResult)
            'Check 13th
            myInput = 13
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("13th", myResult)
            'Check 14th
            myInput = 14
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("14th", myResult)
            'Check 21st
            myInput = 21
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("21st", myResult)
            'Check 22nd
            myInput = 22
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("22nd", myResult)
            'Check 23rd
            myInput = 23
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("23rd", myResult)
            'Check 24th
            myInput = 24
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("24th", myResult)
            'Check 123rd
            myInput = 123
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("123rd", myResult)
            'Check 12345th
            myInput = 12345
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("12345th", myResult)
            'Check 2147483647th
            myInput = Int32.MaxValue
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("2147483647th", myResult)

            'Check 0th
            myInput = 0
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("0th", myResult)

            'Check -1st
            myInput = -1
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-1st", myResult)
            'Check -2nd
            myInput = -2
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-2nd", myResult)
            'Check -3rd
            myInput = -3
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-3rd", myResult)
            'Check 4th
            myInput = -4
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-4th", myResult)
            'Check 5th
            myInput = -5
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-5th", myResult)
            'Check 6th
            myInput = -6
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-6th", myResult)
            'Check -7th
            myInput = -7
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-7th", myResult)
            'Check -8th
            myInput = -8
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-8th", myResult)
            'Check -9th
            myInput = -9
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-9th", myResult)
            'Check -10th
            myInput = -10
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-10th", myResult)
            'Check -11th
            myInput = -11
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-11th", myResult)
            'Check -12th
            myInput = -12
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-12th", myResult)
            'Check -13th
            myInput = -13
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-13th", myResult)
            'Check -14th
            myInput = -14
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-14th", myResult)
            'Check -21st
            myInput = -21
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-21st", myResult)
            'Check -22nd
            myInput = -22
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-22nd", myResult)
            'Check -23rd
            myInput = -23
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-23rd", myResult)
            'Check -24th
            myInput = -24
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-24th", myResult)
            'Check -123rd
            myInput = -123
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-123rd", myResult)
            'Check -12345th
            myInput = -12345
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-12345th", myResult)
            'Check -2147483648th
            myInput = Int32.MinValue
            myResult = myInput.ToEnglishOrdinal()
            Assert.AreEqual("-2147483648th", myResult)

            'Check format overrides

            myInput = 12345
            myFormat = "#,##0"
            myResult = myInput.ToEnglishOrdinal(myFormat)
            Assert.AreEqual("12,345th", myResult)

            myInput = 12345
            myFormat = "#,##0"
            myFormatProvider = New CultureInfo("fr-FR", False)
            myResult = myInput.ToEnglishOrdinal(myFormat, myFormatProvider)
            Assert.AreEqual("12�345th", myResult)
        Catch ex As Exception When (Not TypeOf ex Is AssertFailedException) And (Not TypeOf ex Is AssertInconclusiveException) 'VB 10 support
            Assert.Fail("An exception of type " & ex.GetType().FullName & " occurred, but no exception should have been thrown!")
        End Try
    End Sub

End Class
'----------------------------------------------------------------------------------------
#End If
