<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlay
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        TextBox1 = New TextBox()
        Label3 = New Label()
        NumericUpDown1 = New NumericUpDown()
        numDealerPos = New NumericUpDown()
        TreeView1 = New TreeView()
        StatusStrip1 = New StatusStrip()
        ToolStripStatusLabel1 = New ToolStripStatusLabel()
        ToolStripStatusLabel2 = New ToolStripStatusLabel()
        Button1 = New Button()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        CType(numDealerPos, ComponentModel.ISupportInitialize).BeginInit()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(13, 15)
        Label1.Name = "Label1"
        Label1.Size = New Size(105, 15)
        Label1.TabIndex = 1
        Label1.Text = "Number of Players"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(32, 44)
        Label2.Name = "Label2"
        Label2.Size = New Size(86, 15)
        Label2.TabIndex = 2
        Label2.Text = "Dealer Position"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(124, 245)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(100, 23)
        TextBox1.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(11, 248)
        Label3.Name = "Label3"
        Label3.Size = New Size(107, 15)
        Label3.TabIndex = 5
        Label3.Text = "Deal a playing card"
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.Location = New Point(124, 12)
        NumericUpDown1.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        NumericUpDown1.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.Size = New Size(100, 23)
        NumericUpDown1.TabIndex = 6
        NumericUpDown1.Value = New Decimal(New Integer() {4, 0, 0, 0})
        ' 
        ' numDealerPos
        ' 
        numDealerPos.Location = New Point(124, 41)
        numDealerPos.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        numDealerPos.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numDealerPos.Name = "numDealerPos"
        numDealerPos.Size = New Size(100, 23)
        numDealerPos.TabIndex = 7
        numDealerPos.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' TreeView1
        ' 
        TreeView1.Location = New Point(243, 4)
        TreeView1.Name = "TreeView1"
        TreeView1.Size = New Size(390, 421)
        TreeView1.TabIndex = 8
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {ToolStripStatusLabel1, ToolStripStatusLabel2})
        StatusStrip1.Location = New Point(0, 426)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(660, 24)
        StatusStrip1.TabIndex = 9
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' ToolStripStatusLabel1
        ' 
        ToolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Right
        ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        ToolStripStatusLabel1.Size = New Size(31, 19)
        ToolStripStatusLabel1.Text = "one"
        ' 
        ' ToolStripStatusLabel2
        ' 
        ToolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.Right
        ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        ToolStripStatusLabel2.Size = New Size(31, 19)
        ToolStripStatusLabel2.Text = "two"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(11, 390)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 10
        Button1.Text = "Clear"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' frmPlay
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(660, 450)
        Controls.Add(Button1)
        Controls.Add(StatusStrip1)
        Controls.Add(TreeView1)
        Controls.Add(numDealerPos)
        Controls.Add(NumericUpDown1)
        Controls.Add(Label3)
        Controls.Add(TextBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "frmPlay"
        Text = "frmPlay"
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        CType(numDealerPos, ComponentModel.ISupportInitialize).EndInit()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents numDealerPos As NumericUpDown
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents Button1 As Button
End Class
