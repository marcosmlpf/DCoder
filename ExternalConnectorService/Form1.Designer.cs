namespace HtmlParser
{
    partial class Form1
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
            this.btnGetHtmlLoveMondays = new System.Windows.Forms.Button();
            this.btnParseLoveMondays = new System.Windows.Forms.Button();
            this.btnParseGlassDoor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetHtmlLoveMondays
            // 
            this.btnGetHtmlLoveMondays.Location = new System.Drawing.Point(55, 62);
            this.btnGetHtmlLoveMondays.Name = "btnGetHtmlLoveMondays";
            this.btnGetHtmlLoveMondays.Size = new System.Drawing.Size(132, 23);
            this.btnGetHtmlLoveMondays.TabIndex = 0;
            this.btnGetHtmlLoveMondays.Text = "Get Html : Love Mondays";
            this.btnGetHtmlLoveMondays.UseVisualStyleBackColor = true;
            this.btnGetHtmlLoveMondays.Click += new System.EventHandler(this.btnGetHtmlLoveMondays_Click);
            // 
            // btnParseLoveMondays
            // 
            this.btnParseLoveMondays.Location = new System.Drawing.Point(55, 92);
            this.btnParseLoveMondays.Name = "btnParseLoveMondays";
            this.btnParseLoveMondays.Size = new System.Drawing.Size(132, 23);
            this.btnParseLoveMondays.TabIndex = 1;
            this.btnParseLoveMondays.Text = "Parse Love Mondays";
            this.btnParseLoveMondays.UseVisualStyleBackColor = true;
            this.btnParseLoveMondays.Click += new System.EventHandler(this.btnParseLoveMondays_Click);
            // 
            // btnParseGlassDoor
            // 
            this.btnParseGlassDoor.Location = new System.Drawing.Point(55, 121);
            this.btnParseGlassDoor.Name = "btnParseGlassDoor";
            this.btnParseGlassDoor.Size = new System.Drawing.Size(132, 23);
            this.btnParseGlassDoor.TabIndex = 2;
            this.btnParseGlassDoor.Text = "Parse GlassDoor";
            this.btnParseGlassDoor.UseVisualStyleBackColor = true;
            this.btnParseGlassDoor.Click += new System.EventHandler(this.btnParseGlassDoor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnParseGlassDoor);
            this.Controls.Add(this.btnParseLoveMondays);
            this.Controls.Add(this.btnGetHtmlLoveMondays);
            this.Name = "Form1";
            this.Text = "Call Connector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetHtmlLoveMondays;
        private System.Windows.Forms.Button btnParseLoveMondays;
        private System.Windows.Forms.Button btnParseGlassDoor;
    }
}

