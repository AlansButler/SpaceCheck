using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpaceCheck
{
  public partial class formRegEx : Form
  {
    public String startPhrase = String.Empty;
    public String endPhrase = String.Empty;
    public int maxDiff = 0;

    public formRegEx(string aStartPhrase, string aEndPhrase, int aMaxDiff)
    {
      InitializeComponent();
      this.textBoxStartPhrase.Text = aStartPhrase;
      this.textBoxEndPhrase.Text = aEndPhrase;
      this.numericUpDownMaxDiff.Value = aMaxDiff;
      
    }

    private void lblStartPhrase_Click(object sender, EventArgs e)
    {



  
    }

    private void lblEndPhrase_Click(object sender, EventArgs e)
    {

    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      startPhrase = textBoxStartPhrase.Text;
      endPhrase = textBoxEndPhrase.Text;
      maxDiff = Convert.ToInt32(numericUpDownMaxDiff.Value);
      this.Close();
    }
  }
}