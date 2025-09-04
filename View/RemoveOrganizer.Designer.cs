namespace EventManagmentSystem.View
{
    partial class RemoveOrganizer
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
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1RO = new System.Windows.Forms.CheckBox();
            this.checkBox2RO = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRO = new System.Windows.Forms.ComboBox();
            this.comboBox1RA = new System.Windows.Forms.ComboBox();
            this.label2RA = new System.Windows.Forms.Label();
            this.button2RA = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.button1.Location = new System.Drawing.Point(547, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1RO
            // 
            this.checkBox1RO.AutoSize = true;
            this.checkBox1RO.Font = new System.Drawing.Font("Lucida Bright", 7.875F);
            this.checkBox1RO.Location = new System.Drawing.Point(67, 270);
            this.checkBox1RO.Name = "checkBox1RO";
            this.checkBox1RO.Size = new System.Drawing.Size(230, 27);
            this.checkBox1RO.TabIndex = 1;
            this.checkBox1RO.Text = "Remove Organizer";
            this.checkBox1RO.UseVisualStyleBackColor = true;
            this.checkBox1RO.CheckedChanged += new System.EventHandler(this.checkBox1RO_CheckedChanged);
            // 
            // checkBox2RO
            // 
            this.checkBox2RO.AutoSize = true;
            this.checkBox2RO.Font = new System.Drawing.Font("Lucida Bright", 7.875F);
            this.checkBox2RO.Location = new System.Drawing.Point(67, 221);
            this.checkBox2RO.Name = "checkBox2RO";
            this.checkBox2RO.Size = new System.Drawing.Size(196, 27);
            this.checkBox2RO.TabIndex = 2;
            this.checkBox2RO.Text = "Remove Events";
            this.checkBox2RO.UseVisualStyleBackColor = true;
            this.checkBox2RO.CheckedChanged += new System.EventHandler(this.checkBox2RO_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.label1.Location = new System.Drawing.Point(61, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Organizer";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxRO
            // 
            this.comboBoxRO.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.comboBoxRO.FormattingEnabled = true;
            this.comboBoxRO.Location = new System.Drawing.Point(67, 143);
            this.comboBoxRO.Name = "comboBoxRO";
            this.comboBoxRO.Size = new System.Drawing.Size(355, 44);
            this.comboBoxRO.TabIndex = 4;
            this.comboBoxRO.SelectedIndexChanged += new System.EventHandler(this.comboBoxRO_SelectedIndexChanged);
            // 
            // comboBox1RA
            // 
            this.comboBox1RA.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.comboBox1RA.FormattingEnabled = true;
            this.comboBox1RA.Location = new System.Drawing.Point(67, 533);
            this.comboBox1RA.Name = "comboBox1RA";
            this.comboBox1RA.Size = new System.Drawing.Size(355, 44);
            this.comboBox1RA.TabIndex = 9;
            this.comboBox1RA.SelectedIndexChanged += new System.EventHandler(this.comboBox1RA_SelectedIndexChanged);
            // 
            // label2RA
            // 
            this.label2RA.AutoSize = true;
            this.label2RA.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.label2RA.Location = new System.Drawing.Point(61, 475);
            this.label2RA.Name = "label2RA";
            this.label2RA.Size = new System.Drawing.Size(159, 36);
            this.label2RA.TabIndex = 8;
            this.label2RA.Text = "Attendee";
            this.label2RA.Click += new System.EventHandler(this.label2RA_Click);
            // 
            // button2RA
            // 
            this.button2RA.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.button2RA.Location = new System.Drawing.Point(547, 528);
            this.button2RA.Name = "button2RA";
            this.button2RA.Size = new System.Drawing.Size(182, 53);
            this.button2RA.TabIndex = 5;
            this.button2RA.Text = "Remove";
            this.button2RA.UseVisualStyleBackColor = true;
            this.button2RA.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(824, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "-----------------------------------";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label3.Location = new System.Drawing.Point(46, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(641, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "! Deleting an organizer also removes all their events, tickets, and purchases.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label4.Location = new System.Drawing.Point(46, 602);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(595, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "! Deleting an attendee also removes all their purchases and payments.";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // RemoveOrganizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 739);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1RA);
            this.Controls.Add(this.label2RA);
            this.Controls.Add(this.button2RA);
            this.Controls.Add(this.comboBoxRO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox2RO);
            this.Controls.Add(this.checkBox1RO);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RemoveOrganizer";
            this.Text = "RemoveOrganizer";
            this.Load += new System.EventHandler(this.RemoveOrganizer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1RO;
        private System.Windows.Forms.CheckBox checkBox2RO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRO;
        private System.Windows.Forms.ComboBox comboBox1RA;
        private System.Windows.Forms.Label label2RA;
        private System.Windows.Forms.Button button2RA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}