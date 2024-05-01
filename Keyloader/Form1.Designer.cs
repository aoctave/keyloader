namespace Keyloader
{
    partial class Form1
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            textBox2 = new TextBox();
            label1 = new Label();
            button6 = new Button();
            checkBox1 = new CheckBox();
            textBox3 = new TextBox();
            label2 = new Label();
            button7 = new Button();
            textBox4 = new TextBox();
            label3 = new Label();
            button8 = new Button();
            textBox5 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(77, 51);
            button1.Name = "button1";
            button1.Size = new Size(278, 39);
            button1.TabIndex = 0;
            button1.Text = "Get Yubikey";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(57, 463);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(1001, 243);
            textBox1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(77, 112);
            button2.Name = "button2";
            button2.Size = new Size(278, 39);
            button2.TabIndex = 2;
            button2.Text = "Connect PIV Session";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(389, 112);
            button3.Name = "button3";
            button3.Size = new Size(278, 39);
            button3.TabIndex = 3;
            button3.Text = "Get Serial";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 8F);
            button4.Location = new Point(739, 64);
            button4.Name = "button4";
            button4.Size = new Size(217, 37);
            button4.TabIndex = 4;
            button4.Text = "Benchmark (about 1 min)";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(77, 237);
            button5.Name = "button5";
            button5.Size = new Size(278, 39);
            button5.TabIndex = 5;
            button5.Text = "Load 9E";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9F);
            textBox2.Location = new Point(389, 241);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(669, 31);
            textBox2.TabIndex = 6;
            textBox2.Text = "010203040506070801020304050607080102030405060708010203040506070801020304050607080102030405060708";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(389, 276);
            label1.Name = "label1";
            label1.Size = new Size(90, 21);
            label1.TabIndex = 7;
            label1.Text = "9E: ECC key";
            // 
            // button6
            // 
            button6.Enabled = false;
            button6.Location = new Point(77, 172);
            button6.Name = "button6";
            button6.Size = new Size(278, 39);
            button6.TabIndex = 8;
            button6.Text = "Authenticate";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Font = new Font("Segoe UI", 7F);
            checkBox1.Location = new Point(752, 35);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(173, 23);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "see benchmark button";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 9F);
            textBox3.Location = new Point(389, 176);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(669, 31);
            textBox3.TabIndex = 10;
            textBox3.Text = "010203040506070801020304050607080102030405060708";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F);
            label2.Location = new Point(389, 210);
            label2.Name = "label2";
            label2.Size = new Size(204, 21);
            label2.TabIndex = 11;
            label2.Text = "Management Key (24 bytes)";
            // 
            // button7
            // 
            button7.Enabled = false;
            button7.Location = new Point(77, 305);
            button7.Name = "button7";
            button7.Size = new Size(278, 39);
            button7.TabIndex = 12;
            button7.Text = "Authenticate PIN";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(389, 309);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(435, 31);
            textBox4.TabIndex = 13;
            textBox4.Text = "313233343536";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F);
            label3.Location = new Point(389, 343);
            label3.Name = "label3";
            label3.Size = new Size(137, 21);
            label3.TabIndex = 14;
            label3.Text = "PIN (Hexadecimal)";
            // 
            // button8
            // 
            button8.Enabled = false;
            button8.Location = new Point(77, 373);
            button8.Name = "button8";
            button8.Size = new Size(278, 39);
            button8.TabIndex = 15;
            button8.Text = "Sign with 9E";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(389, 377);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(669, 31);
            textBox5.TabIndex = 17;
            textBox5.Text = "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F);
            label4.Location = new Point(389, 411);
            label4.Name = "label4";
            label4.Size = new Size(105, 21);
            label4.TabIndex = 18;
            label4.Text = "Digest to sign";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 7F);
            label5.Location = new Point(777, 275);
            label5.Name = "label5";
            label5.Size = new Size(281, 19);
            label5.TabIndex = 19;
            label5.Text = "Touch Required: Never   PIN Required: Never";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 756);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox5);
            Controls.Add(button8);
            Controls.Add(label3);
            Controls.Add(textBox4);
            Controls.Add(button7);
            Controls.Add(label2);
            Controls.Add(textBox3);
            Controls.Add(checkBox1);
            Controls.Add(button6);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Keyloader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private TextBox textBox2;
        private Label label1;
        private Button button6;
        private CheckBox checkBox1;
        private TextBox textBox3;
        private Label label2;
        private Button button7;
        private TextBox textBox4;
        private Label label3;
        private Button button8;
        private TextBox textBox5;
        private Label label4;
        private Label label5;
    }
}
