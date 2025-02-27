Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Public cardIDs As New Dictionary(Of String, String) ' Declare a Dictionary to store card IDs
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Add all 52 playing cards to the ListBox
        Dim suits() As String = {"Diamonds", "Clubs", "Hearts", "Spades"}
        Dim ranks() As String = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"}

        For Each suit As String In suits
            For Each rank As String In ranks
                ListBox1.Items.Add(rank & " of " & suit)
            Next
        Next

        ' Select the first item in the ListBox
        If ListBox1.Items.Count > 0 Then
            ListBox1.SelectedIndex = 0
        End If

        ' Load card IDs from file (if it exists)
        If System.IO.File.Exists("CardIDs.txt") Then
            Using reader As New System.IO.StreamReader("CardIDs.txt")
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim parts() As String = line.Split(New String() {" : "}, StringSplitOptions.None)
                    If parts.Length = 2 Then
                        cardIDs(parts(0)) = parts(1)
                    End If
                End While
            End Using
        End If

        ' Enable owner drawing for the ListBox
        ListBox1.DrawMode = DrawMode.OwnerDrawFixed
    End Sub

    Private Sub ListBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ListBox1.DrawItem
        ' Ensure the item is valid
        If e.Index < 0 Then Return

        ' Get the text of the item
        Dim cardText As String = Replace(ListBox1.Items(e.Index).ToString(), " ✔", "")

        ' Determine the text color based on the suit
        Dim textColor As Color = Color.Black ' Default color
        If cardText.Contains("Diamond") Or cardText.Contains("Heart") Then
            textColor = Color.Red
        End If

        ' Check if the card has an ID in the Dictionary
        If cardIDs.ContainsKey(cardText) Then
            ' Prepend a tick mark to the text
            Dim v As String = cardText & " ✔"
            cardText = v
        End If

        ' Draw the background
        e.DrawBackground()

        ' Draw the text with the appropriate color
        Using brush As New SolidBrush(textColor)
            e.Graphics.DrawString(cardText, e.Font, brush, e.Bounds)
        End Using

        ' Draw the focus rectangle if the item is selected
        e.DrawFocusRectangle()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then ' Check if Enter key is pressed
            e.Handled = True ' Prevent the beep sound

            ' Assign the ID to the currently selected card
            If ListBox1.SelectedIndex >= 0 Then
                Dim currentCard As String = ListBox1.SelectedItem.ToString()
                Dim cardID As String = TextBox1.Text.Trim()

                ' Check if the ID is already assigned to another card
                If cardIDs.ContainsValue(cardID) Then
                    ' Find the card that already has this ID
                    Dim existingCard As String = cardIDs.FirstOrDefault(Function(x) x.Value = cardID).Key
                    MessageBox.Show("The ID '" & cardID & "' is already assigned to: " & existingCard)
                    Return ' Exit the subroutine without assigning the ID
                End If

                ' Store the ID in the Dictionary
                If Not cardIDs.TryAdd(currentCard, cardID) Then
                    ' Update the ID if the card already exists in the Dictionary
                    cardIDs(currentCard) = cardID
                End If

                ' Update the ListBox item to show a tick mark
                ListBox1.Items(ListBox1.SelectedIndex) = currentCard & " ✔"

                'MessageBox.Show("Assigned ID '" & cardID & "' to " & currentCard)

                ' Clear the TextBox
                TextBox1.Clear()

                ' Move to the next item in the ListBox
                If ListBox1.SelectedIndex < ListBox1.Items.Count - 1 Then
                    ListBox1.SelectedIndex += 1
                Else
                    MessageBox.Show("All cards have been assigned IDs!")
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Check if any IDs have been assigned
        If cardIDs.Count = 0 Then
            MessageBox.Show("No IDs have been assigned yet.")
            Return
        End If

        ' Build a string to display all card IDs
        Dim result As New System.Text.StringBuilder()
        For Each kvp As KeyValuePair(Of String, String) In cardIDs
            result.AppendLine(kvp.Key & " : " & kvp.Value)
        Next

        ' Show the result in a MessageBox
        MessageBox.Show(result.ToString(), "Assigned Card IDs")
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        ' Check if an item is selected
        If ListBox1.SelectedIndex >= 0 Then
            Dim selectedCard As String = Replace(ListBox1.SelectedItem.ToString(), " ✔", "")
            Dim rank As String = selectedCard.Split(" ")(0).ToLower()
            Dim suit As String = selectedCard.Split(" ")(2).ToLower()
            Dim url As New Uri("https://tekeye.uk/playing_cards/images/svg_playing_cards/fronts/" + suit + "_" + rank + ".svg")

            WebView22.Source = url

            Dim value As String = Nothing
            ' Check if the selected card has an ID in the Dictionary
            If cardIDs.TryGetValue(selectedCard, value) Then
                ' Display the ID in TextBox2
                TextBox2.Text = value
            Else
                ' Clear TextBox2 if no ID is assigned
                TextBox2.Text = ""
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then ' Check if Enter key is pressed
            e.Handled = True ' Prevent the beep sound

            ' Get the ID entered in TextBox3
            Dim searchID As String = TextBox3.Text.Trim()

            ' Check if the ID exists in the Dictionary
            If cardIDs.ContainsValue(searchID) Then
                ' Find the card that has this ID
                Dim cardWithID As String = cardIDs.FirstOrDefault(Function(x) x.Value = searchID).Key
                'MessageBox.Show("The ID '" & searchID & "' is assigned to: " & cardWithID)


                Dim rank As String = cardWithID.Split(" ")(0).ToLower()
                Dim suit As String = cardWithID.Split(" ")(2).ToLower()
                Dim url As New Uri("https://tekeye.uk/playing_cards/images/svg_playing_cards/fronts/" + suit + "_" + rank + ".svg")
                WebView21.Show()
                WebView21.Source = url

            Else
                WebView21.Hide()
                ' Show a message if the ID is not found
                'MessageBox.Show("The ID '" & searchID & "' is not assigned to any card.")
            End If

            ' Clear TextBox3
            TextBox3.Clear()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Check if any IDs have been assigned
        If cardIDs.Count = 0 Then
            MessageBox.Show("No IDs have been assigned yet.")
            Return
        End If

        ' Save the Dictionary to a file
        Using writer As New System.IO.StreamWriter("CardIDs.txt")
            For Each kvp As KeyValuePair(Of String, String) In cardIDs
                writer.WriteLine(kvp.Key & " : " & kvp.Value)
            Next
        End Using

        MessageBox.Show("Card IDs saved to CardIDs.txt")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Load card IDs from file (if it exists)
        If System.IO.File.Exists("CardIDs.txt") Then
            Using reader As New System.IO.StreamReader("CardIDs.txt")
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim parts() As String = line.Split(New String() {" : "}, StringSplitOptions.None)
                    If parts.Length = 2 Then
                        cardIDs(parts(0)) = parts(1)
                    End If
                End While
            End Using

        Else
            MsgBox("No save file found.")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If cardIDs.Count > 0 Then
            MsgBox("Are you sure you want to clear IDs for all cards?", MsgBoxStyle.YesNo, "Clear Card IDs?")
            If MsgBoxResult.Yes Then
                cardIDs.Clear()
                For i As Integer = 0 To ListBox1.Items.Count - 1
                    ListBox1.Items(i) = Replace(ListBox1.Items(i).ToString(), " ✔", "")
                Next
                MsgBox("All card IDs have been cleared.")
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmPlay.Show()
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        If frmPlay.Visible = True Then
            'get the id of the card selected and assign it to the textbox in frmPlay
            Dim selectedCard As String = Replace(ListBox1.SelectedItem.ToString(), " ✔", "")
            Dim value As String = Nothing
            If cardIDs.TryGetValue(selectedCard, value) Then
                frmPlay.TextBox1.Text = value
                'run the event that happens when enter is pressed in frmplay.textbox1
                frmPlay.dealCard()

            End If
        End If

    End Sub
End Class