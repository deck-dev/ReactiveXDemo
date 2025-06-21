namespace WinFormsApp1;

partial class FormMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        btnToggle = new System.Windows.Forms.Button();
        btnStart = new System.Windows.Forms.Button();
        btnStop = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // btnToggle
        // 
        btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnToggle.Location = new System.Drawing.Point(12, 12);
        btnToggle.Name = "btnToggle";
        btnToggle.Size = new System.Drawing.Size(75, 48);
        btnToggle.TabIndex = 0;
        btnToggle.Text = "TOGGLE";
        btnToggle.UseVisualStyleBackColor = true;
        // 
        // btnStart
        // 
        btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnStart.Location = new System.Drawing.Point(12, 66);
        btnStart.Name = "btnStart";
        btnStart.Size = new System.Drawing.Size(75, 48);
        btnStart.TabIndex = 1;
        btnStart.Text = "START";
        btnStart.UseVisualStyleBackColor = true;
        // 
        // btnStop
        // 
        btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnStop.Location = new System.Drawing.Point(93, 66);
        btnStop.Name = "btnStop";
        btnStop.Size = new System.Drawing.Size(75, 48);
        btnStop.TabIndex = 2;
        btnStop.Text = "STOP";
        btnStop.UseVisualStyleBackColor = true;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(331, 379);
        Controls.Add(btnStop);
        Controls.Add(btnStart);
        Controls.Add(btnToggle);
        Text = "Reactive Demo";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnStop;

    private System.Windows.Forms.Button btnToggle;

    #endregion
}