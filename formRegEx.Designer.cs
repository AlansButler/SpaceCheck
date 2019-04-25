namespace SpaceCheck
{
  partial class formRegEx
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
      this.lblStartPhrase = new System.Windows.Forms.Label();
      this.lblEndPhrase = new System.Windows.Forms.Label();
      this.lblMaxDiff = new System.Windows.Forms.Label();
      this.textBoxStartPhrase = new System.Windows.Forms.TextBox();
      this.textBoxEndPhrase = new System.Windows.Forms.TextBox();
      this.numericUpDownMaxDiff = new System.Windows.Forms.NumericUpDown();
      this.btnClose = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxDiff)).BeginInit();
      this.SuspendLayout();
      // 
      // lblStartPhrase
      // 
      this.lblStartPhrase.AutoSize = true;
      this.lblStartPhrase.Location = new System.Drawing.Point(39, 22);
      this.lblStartPhrase.Name = "lblStartPhrase";
      this.lblStartPhrase.Size = new System.Drawing.Size(65, 13);
      this.lblStartPhrase.TabIndex = 0;
      this.lblStartPhrase.Text = "Start Phrase";
      // 
      // lblEndPhrase
      // 
      this.lblEndPhrase.AutoSize = true;
      this.lblEndPhrase.Location = new System.Drawing.Point(39, 60);
      this.lblEndPhrase.Name = "lblEndPhrase";
      this.lblEndPhrase.Size = new System.Drawing.Size(62, 13);
      this.lblEndPhrase.TabIndex = 1;
      this.lblEndPhrase.Text = "End Phrase";
      // 
      // lblMaxDiff
      // 
      this.lblMaxDiff.AutoSize = true;
      this.lblMaxDiff.Location = new System.Drawing.Point(38, 115);
      this.lblMaxDiff.Name = "lblMaxDiff";
      this.lblMaxDiff.Size = new System.Drawing.Size(46, 13);
      this.lblMaxDiff.TabIndex = 2;
      this.lblMaxDiff.Text = "Max Diff";
      // 
      // textBoxStartPhrase
      // 
      this.textBoxStartPhrase.Location = new System.Drawing.Point(111, 14);
      this.textBoxStartPhrase.Name = "textBoxStartPhrase";
      this.textBoxStartPhrase.Size = new System.Drawing.Size(143, 20);
      this.textBoxStartPhrase.TabIndex = 3;
      // 
      // textBoxEndPhrase
      // 
      this.textBoxEndPhrase.Location = new System.Drawing.Point(111, 57);
      this.textBoxEndPhrase.Name = "textBoxEndPhrase";
      this.textBoxEndPhrase.Size = new System.Drawing.Size(143, 20);
      this.textBoxEndPhrase.TabIndex = 4;
      // 
      // numericUpDownMaxDiff
      // 
      this.numericUpDownMaxDiff.Location = new System.Drawing.Point(119, 118);
      this.numericUpDownMaxDiff.Name = "numericUpDownMaxDiff";
      this.numericUpDownMaxDiff.Size = new System.Drawing.Size(120, 20);
      this.numericUpDownMaxDiff.TabIndex = 5;
      this.numericUpDownMaxDiff.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // btnClose
      // 
      this.btnClose.Location = new System.Drawing.Point(110, 214);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 6;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // formRegEx
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 273);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.numericUpDownMaxDiff);
      this.Controls.Add(this.textBoxEndPhrase);
      this.Controls.Add(this.textBoxStartPhrase);
      this.Controls.Add(this.lblMaxDiff);
      this.Controls.Add(this.lblEndPhrase);
      this.Controls.Add(this.lblStartPhrase);
      this.Name = "formRegEx";
      this.Text = "formRegEx";
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxDiff)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblStartPhrase;
    private System.Windows.Forms.Label lblEndPhrase;
    private System.Windows.Forms.Label lblMaxDiff;
    private System.Windows.Forms.TextBox textBoxStartPhrase;
    private System.Windows.Forms.TextBox textBoxEndPhrase;
    private System.Windows.Forms.NumericUpDown numericUpDownMaxDiff;
    private System.Windows.Forms.Button btnClose;

  }
}