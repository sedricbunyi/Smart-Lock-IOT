<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class User
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabStatus = New System.Windows.Forms.TabPage()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.lblUser_id = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblFullname = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblRfidkey = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabHistory = New System.Windows.Forms.TabPage()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DataGrid1 = New System.Windows.Forms.DataGridView()
        Me.btnViewhistory = New System.Windows.Forms.Button()
        Me.lblFullname1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tabStatus.SuspendLayout()
        Me.tabHistory.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabStatus)
        Me.TabControl1.Controls.Add(Me.tabHistory)
        Me.TabControl1.Location = New System.Drawing.Point(11, 15)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(551, 354)
        Me.TabControl1.TabIndex = 0
        '
        'tabStatus
        '
        Me.tabStatus.Controls.Add(Me.lblStatus)
        Me.tabStatus.Controls.Add(Me.Label7)
        Me.tabStatus.Controls.Add(Me.btnOpen)
        Me.tabStatus.Controls.Add(Me.lblUser_id)
        Me.tabStatus.Controls.Add(Me.Label6)
        Me.tabStatus.Controls.Add(Me.lblFullname)
        Me.tabStatus.Controls.Add(Me.lblAddress)
        Me.tabStatus.Controls.Add(Me.lblGender)
        Me.tabStatus.Controls.Add(Me.lblRfidkey)
        Me.tabStatus.Controls.Add(Me.Label4)
        Me.tabStatus.Controls.Add(Me.Label3)
        Me.tabStatus.Controls.Add(Me.Label2)
        Me.tabStatus.Controls.Add(Me.Label1)
        Me.tabStatus.Location = New System.Drawing.Point(4, 22)
        Me.tabStatus.Name = "tabStatus"
        Me.tabStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tabStatus.Size = New System.Drawing.Size(543, 328)
        Me.tabStatus.TabIndex = 0
        Me.tabStatus.Text = "Status"
        Me.tabStatus.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(304, 180)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 13)
        Me.lblStatus.TabIndex = 14
        Me.lblStatus.Text = "Closed"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(255, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Status:"
        '
        'btnOpen
        '
        Me.btnOpen.BackColor = System.Drawing.Color.NavajoWhite
        Me.btnOpen.Location = New System.Drawing.Point(258, 121)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(85, 47)
        Me.btnOpen.TabIndex = 12
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = False
        '
        'lblUser_id
        '
        Me.lblUser_id.AutoSize = True
        Me.lblUser_id.Location = New System.Drawing.Point(128, 106)
        Me.lblUser_id.Name = "lblUser_id"
        Me.lblUser_id.Size = New System.Drawing.Size(39, 13)
        Me.lblUser_id.TabIndex = 11
        Me.lblUser_id.Text = "Label5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(60, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "User ID:"
        '
        'lblFullname
        '
        Me.lblFullname.AutoSize = True
        Me.lblFullname.Location = New System.Drawing.Point(128, 130)
        Me.lblFullname.Name = "lblFullname"
        Me.lblFullname.Size = New System.Drawing.Size(39, 13)
        Me.lblFullname.TabIndex = 9
        Me.lblFullname.Text = "Label5"
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(128, 205)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(39, 13)
        Me.lblAddress.TabIndex = 8
        Me.lblAddress.Text = "Label7"
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Location = New System.Drawing.Point(128, 180)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(39, 13)
        Me.lblGender.TabIndex = 7
        Me.lblGender.Text = "Label8"
        '
        'lblRfidkey
        '
        Me.lblRfidkey.AutoSize = True
        Me.lblRfidkey.Location = New System.Drawing.Point(128, 155)
        Me.lblRfidkey.Name = "lblRfidkey"
        Me.lblRfidkey.Size = New System.Drawing.Size(39, 13)
        Me.lblRfidkey.TabIndex = 6
        Me.lblRfidkey.Text = "Label9"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(60, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Address:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Gender:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(60, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "RFID key:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Full Name:"
        '
        'tabHistory
        '
        Me.tabHistory.Controls.Add(Me.lblFullname1)
        Me.tabHistory.Controls.Add(Me.btnViewhistory)
        Me.tabHistory.Controls.Add(Me.DataGrid1)
        Me.tabHistory.Location = New System.Drawing.Point(4, 22)
        Me.tabHistory.Name = "tabHistory"
        Me.tabHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tabHistory.Size = New System.Drawing.Size(543, 328)
        Me.tabHistory.TabIndex = 1
        Me.tabHistory.Text = "History"
        Me.tabHistory.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.DtrEnable = True
        Me.SerialPort1.PortName = "COM3"
        Me.SerialPort1.ReadBufferSize = 9600
        Me.SerialPort1.RtsEnable = True
        '
        'Timer1
        '
        '
        'DataGrid1
        '
        Me.DataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid1.Location = New System.Drawing.Point(6, 42)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeadersWidth = 40
        Me.DataGrid1.Size = New System.Drawing.Size(531, 280)
        Me.DataGrid1.TabIndex = 0
        '
        'btnViewhistory
        '
        Me.btnViewhistory.Location = New System.Drawing.Point(16, 10)
        Me.btnViewhistory.Name = "btnViewhistory"
        Me.btnViewhistory.Size = New System.Drawing.Size(91, 26)
        Me.btnViewhistory.TabIndex = 1
        Me.btnViewhistory.Text = "View History"
        Me.btnViewhistory.UseVisualStyleBackColor = True
        '
        'lblFullname1
        '
        Me.lblFullname1.AutoSize = True
        Me.lblFullname1.Location = New System.Drawing.Point(135, 16)
        Me.lblFullname1.Name = "lblFullname1"
        Me.lblFullname1.Size = New System.Drawing.Size(79, 13)
        Me.lblFullname1.TabIndex = 2
        Me.lblFullname1.Text = "User Full Name"
        '
        'User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(574, 381)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "User"
        Me.Text = "User"
        Me.TabControl1.ResumeLayout(False)
        Me.tabStatus.ResumeLayout(False)
        Me.tabStatus.PerformLayout()
        Me.tabHistory.ResumeLayout(False)
        Me.tabHistory.PerformLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabHistory As TabPage
    Friend WithEvents tabStatus As TabPage
    Friend WithEvents lblFullname As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblGender As Label
    Friend WithEvents lblRfidkey As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblUser_id As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnOpen As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents DataGrid1 As DataGridView
    Friend WithEvents lblFullname1 As Label
    Friend WithEvents btnViewhistory As Button
End Class
