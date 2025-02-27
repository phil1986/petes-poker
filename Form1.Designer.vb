<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        ListBox1 = New ListBox()
        TextBox1 = New TextBox()
        Label1 = New Label()
        Button1 = New Button()
        GroupBox1 = New GroupBox()
        Button4 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        WebView22 = New Microsoft.Web.WebView2.WinForms.WebView2()
        TextBox2 = New TextBox()
        GroupBox2 = New GroupBox()
        Label2 = New Label()
        TextBox3 = New TextBox()
        WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Button5 = New Button()
        GroupBox1.SuspendLayout()
        CType(WebView22, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        CType(WebView21, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 15
        ListBox1.Location = New Point(167, 31)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(170, 304)
        ListBox1.TabIndex = 0
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(42, 49)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(119, 23)
        TextBox1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(28, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(102, 15)
        Label1.TabIndex = 2
        Label1.Text = "Scan Playing Card"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(6, 90)
        Button1.Name = "Button1"
        Button1.Size = New Size(155, 39)
        Button1.TabIndex = 3
        Button1.Text = "Show Card IDs"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Button4)
        GroupBox1.Controls.Add(Button3)
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(WebView22)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(ListBox1)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(343, 373)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        GroupBox1.Text = "Setup"
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(111, 332)
        Button4.Name = "Button4"
        Button4.Size = New Size(51, 23)
        Button4.TabIndex = 8
        Button4.Text = "Clear"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(59, 332)
        Button3.Name = "Button3"
        Button3.Size = New Size(50, 23)
        Button3.TabIndex = 7
        Button3.Text = "Load"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(7, 332)
        Button2.Name = "Button2"
        Button2.Size = New Size(50, 23)
        Button2.TabIndex = 6
        Button2.Text = "Save"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' WebView22
        ' 
        WebView22.AllowExternalDrop = True
        WebView22.CreationProperties = Nothing
        WebView22.DefaultBackgroundColor = Color.Transparent
        WebView22.Location = New Point(42, 182)
        WebView22.Name = "WebView22"
        WebView22.Size = New Size(71, 115)
        WebView22.TabIndex = 5
        WebView22.ZoomFactor = 0.3R
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(7, 303)
        TextBox2.Name = "TextBox2"
        TextBox2.ReadOnly = True
        TextBox2.Size = New Size(155, 23)
        TextBox2.TabIndex = 4
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(TextBox3)
        GroupBox2.Controls.Add(WebView21)
        GroupBox2.Location = New Point(361, 12)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(373, 373)
        GroupBox2.TabIndex = 5
        GroupBox2.TabStop = False
        GroupBox2.Text = "Read"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 29)
        Label2.Name = "Label2"
        Label2.Size = New Size(102, 15)
        Label2.TabIndex = 2
        Label2.Text = "Scan Playing Card"
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(26, 49)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(100, 23)
        TextBox3.TabIndex = 1
        ' 
        ' WebView21
        ' 
        WebView21.AllowExternalDrop = True
        WebView21.CreationProperties = Nothing
        WebView21.DefaultBackgroundColor = Color.Transparent
        WebView21.Location = New Point(132, 22)
        WebView21.Name = "WebView21"
        WebView21.Size = New Size(235, 345)
        WebView21.TabIndex = 0
        WebView21.ZoomFactor = 1R
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(639, 391)
        Button5.Name = "Button5"
        Button5.Size = New Size(98, 30)
        Button5.TabIndex = 6
        Button5.Text = "Play..."
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(749, 429)
        Controls.Add(Button5)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Name = "Form1"
        Text = "Form1"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(WebView22, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(WebView21, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents WebView22 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button

End Class
