Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmPlay

    ' This will track which player should receive the next card.
    ' It should be set to the player immediately after the dealer when the TreeView is populated.
    Private currentPlayerIndex As Integer = 0

    ' Declare a variable to track how many table cards have been dealt
    Dim tableCardsDealt As Integer = 0

    ' Create a dictionary to map card suits to Unicode symbols
    Dim suitSymbols As New Dictionary(Of String, String) From {
        {" of Hearts", "♥"},
        {" of Diamonds", "♦"},
        {" of Clubs", "♣"},
        {" of Spades", "♠"}
    }

    ' Dictionary to replace face card names with their abbreviations
    Dim faceCardSymbols As New Dictionary(Of String, String) From {
        {"Ace", "A"},
        {"Jack", "J"},
        {"Queen", "Q"},
        {"King", "K"}
    }

    'declare a list of Dealt cards
    Private dealtCards As New List(Of String)

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then ' Check if Enter key is pressed
            e.Handled = True ' Prevent the beep sound

            dealCard()

        End If
    End Sub

    Public Sub dealCard()
        ' Get the scanned card from the TextBox.
        Dim scannedCard As String = TextBox1.Text.Trim()

        ' Look up the card name using the dictionary from Form1.
        Dim cardName As String = ""
        If Form1.cardIDs.ContainsValue(scannedCard) Then

            Dim cardValue As String = Form1.cardIDs.FirstOrDefault(Function(x) x.Value = scannedCard).Key
            cardName = cardValue
        Else
            cardName = "Unknown Card"
            MsgBox("The scanned card is not recognised.", vbOKOnly + vbExclamation, cardName)
            ' Clear the TextBox for the next card.
            TextBox1.Clear()
            Exit Sub
        End If

        ' Check if the card has already been dealt.
        If dealtCards.Contains(cardName) Then
            MessageBox.Show("The card '" & cardName & "' has already been dealt.",
                                "Duplicate Card", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            ' Determine the card color based on suit (Hearts or Diamonds = Red)
            Dim cardColor As Color = Color.Black ' Default color
            If cardName.Contains("Heart") OrElse cardName.Contains("Diamond") Then
                cardColor = Color.Red
            End If

            ' Replace face card names first
            For Each faceCard In faceCardSymbols.Keys
                If cardName.StartsWith(faceCard) Then
                    cardName = cardName.Replace(faceCard, faceCardSymbols(faceCard))
                    Exit For ' No need to continue once replaced
                End If
            Next

            ' Replace the suit in cardName with the corresponding Unicode symbol
            For Each suit In suitSymbols.Keys
                If cardName.EndsWith(suit) Then
                    cardName = cardName.Replace(suit, suitSymbols(suit))
                    Exit For ' No need to continue once we find and replace the suit
                End If
            Next

            ' Add the scanned card as a child node to the current player's TreeView node.
            ' Note: TreeView nodes are zero-indexed.
            Dim numberOfPlayers As Integer = CInt(NumericUpDown1.Value)

            ' Check if all players already have 2 cards (prevent infinite loop)
            Dim allPlayersFull As Boolean = True
            For i As Integer = 0 To numberOfPlayers - 1
                If TreeView1.Nodes(i).Nodes.Count < 2 Then
                    allPlayersFull = False
                    Exit For ' Stop checking once we find a player who still needs a card
                End If
            Next

            ' If all players have 2 cards, stop dealing
            If allPlayersFull Then
                ' Check if we've already dealt 3 community cards
                If tableCardsDealt >= 3 Then
                    MessageBox.Show("The first 3 table cards have already been dealt.",
                                    "Community Cards Dealt", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                ' Ensure the "Table" node exists
                Dim tableNode As TreeNode = TreeView1.Nodes.Cast(Of TreeNode)().FirstOrDefault(Function(n) n.Text = "Table")
                If tableNode Is Nothing Then
                    tableNode = New TreeNode("Table")
                    TreeView1.Nodes.Add(tableNode)
                End If

                ' Add the card to the table
                Dim newTableNode As New TreeNode(cardName) With {
                    .ForeColor = cardColor
                }
                tableNode.Nodes.Add(newTableNode)
                tableNode.Expand()

                ' Increase the count of table cards dealt
                tableCardsDealt += 1

                'get the name of the current player.
                updateStatusBar(cardName, tableNode.Text)

                ' Show confirmation message
                'MessageBox.Show("Card '" & scannedCard & " - " & cardName & "' has been added to the Table.",
                '                "Table Card Added", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear the TextBox for the next card
                TextBox1.Clear()
                Return
            End If

            Dim currentNode As TreeNode = TreeView1.Nodes(currentPlayerIndex - 1)

            If currentNode.Nodes.Count >= 2 Then
                MessageBox.Show("Player " & currentPlayerIndex & " already has 2 cards.",
                            "Max Cards Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                ' Skip to the next player who needs a card
                Do
                    currentPlayerIndex += 1
                    If currentPlayerIndex > numberOfPlayers Then
                        currentPlayerIndex = 1
                    End If
                Loop While TreeView1.Nodes(currentPlayerIndex - 1).Nodes.Count >= 2

                Return ' Exit since the current player already has 2 cards
            End If

            ' Add the card to the list of dealt cards.
            dealtCards.Add(cardName)

            'get the name of the current player.
            Dim currentPlayerName As String = currentNode.Text

            updateStatusBar(cardName, currentPlayerName)

            Dim newNode As New TreeNode(cardName) With {
                .ForeColor = cardColor ' Set text color based on card suit
            }

            currentNode.Nodes.Add(newNode)
            currentNode.Expand() ' Expand to show the newly added card

            ' Clear the TextBox for the next card.
            TextBox1.Clear()

            ' Advance to the next player.
            currentPlayerIndex += 1
            If currentPlayerIndex > numberOfPlayers Then
                currentPlayerIndex = 1
            End If
        End If
    End Sub

    Private Sub updateStatusBar(card, player)
        ToolStripStatusLabel1.Text = "Dealt Cards: " & dealtCards.Count + tableCardsDealt
        ToolStripStatusLabel2.Text = "Last Dealt: " & card & " to " & player
    End Sub

    Private Sub frmPlay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the List of dealt cards (if needed)
        dealtCards.Clear()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        'ensure the dealer position cannot go out of range
        numDealerPos.Maximum = NumericUpDown1.Value
        If numDealerPos.Value > NumericUpDown1.Value Then
            numDealerPos.Value = NumericUpDown1.Value
        End If

        PopulateTreeView()

    End Sub

    Private Sub PopulateTreeView()
        ' Clear existing nodes
        TreeView1.Nodes.Clear()

        Dim numberOfPlayers As Integer = CInt(NumericUpDown1.Value)
        Dim dealerPos As Integer = CInt(numDealerPos.Value)

        ' Add player nodes and mark the dealer
        For i As Integer = 1 To numberOfPlayers
            Dim nodeText As String = "Player " & i
            If i = dealerPos Then
                nodeText &= " - Dealer"
            End If
            TreeView1.Nodes.Add(nodeText)
        Next

        ' Set currentPlayerIndex to the player immediately after the dealer.
        ' If the dealer is the last player, start with the first player.
        If dealerPos >= numberOfPlayers Then
            currentPlayerIndex = 1
        Else
            currentPlayerIndex = dealerPos + 1
        End If
    End Sub

    Private Sub numDealerPos_ValueChanged(sender As Object, e As EventArgs) Handles numDealerPos.ValueChanged
        PopulateTreeView()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'reset game
        dealtCards.Clear()
        tableCardsDealt = 0
        TextBox1.Clear()
        ToolStripStatusLabel1.Text = "Dealt Cards: 0"
        ToolStripStatusLabel2.Text = "Last Dealt: None"
        PopulateTreeView()

    End Sub

End Class