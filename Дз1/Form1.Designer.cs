namespace Дз1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonReadU = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxk = new System.Windows.Forms.TextBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxT = new System.Windows.Forms.TextBox();
            this.buttonReadI = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 707);
            this.panel1.TabIndex = 0;
            // 
            // buttonReadU
            // 
            this.buttonReadU.Location = new System.Drawing.Point(995, 15);
            this.buttonReadU.Name = "buttonReadU";
            this.buttonReadU.Size = new System.Drawing.Size(215, 42);
            this.buttonReadU.TabIndex = 1;
            this.buttonReadU.Text = "Считать данные напряжения";
            this.buttonReadU.UseVisualStyleBackColor = true;
            this.buttonReadU.Click += new System.EventHandler(this.buttonReadU_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(954, 63);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(528, 187);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(954, 351);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(145, 20);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "сигналы uk(t) и ik(t)";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(954, 387);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(322, 20);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "спектр сигнала для одного цикла измерений";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(954, 423);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(455, 20);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "график мгновенных мощностей p(t) (для одного цикла измерений)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(1081, 579);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(199, 43);
            this.buttonDraw.TabIndex = 6;
            this.buttonDraw.Text = "Построить";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(951, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(531, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "Введите номер цикла измерений, котрый будет использоваться для построений (от 0 д" +
    "о k)";
            // 
            // textBoxk
            // 
            this.textBoxk.Location = new System.Drawing.Point(954, 310);
            this.textBoxk.Name = "textBoxk";
            this.textBoxk.Size = new System.Drawing.Size(121, 22);
            this.textBoxk.TabIndex = 8;
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(954, 461);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(480, 40);
            this.radioButton4.TabIndex = 9;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "кривые изменения активной мощности P(t), реактивной мощности Q(t) и полной мощнос" +
    "ти S(t) в заданном временном диапазоне";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(951, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(513, 36);
            this.label2.TabIndex = 10;
            this.label2.Text = "Для последних 2 пунктов необходимо ввести временной диапазон в секундах в формате" +
    " t1;t2";
            // 
            // textBoxT
            // 
            this.textBoxT.Location = new System.Drawing.Point(954, 552);
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.Size = new System.Drawing.Size(121, 22);
            this.textBoxT.TabIndex = 12;
            // 
            // buttonReadI
            // 
            this.buttonReadI.Location = new System.Drawing.Point(1219, 15);
            this.buttonReadI.Name = "buttonReadI";
            this.buttonReadI.Size = new System.Drawing.Size(215, 42);
            this.buttonReadI.TabIndex = 13;
            this.buttonReadI.Text = "Считать данные силы тока";
            this.buttonReadI.UseVisualStyleBackColor = true;
            this.buttonReadI.Click += new System.EventHandler(this.buttonReadI_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 720);
            this.Controls.Add(this.buttonReadI);
            this.Controls.Add(this.textBoxT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.textBoxk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonReadU);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "ДЗ1 Кравченко Дарьи БИСТ-21-2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonReadU;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxk;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxT;
        private System.Windows.Forms.Button buttonReadI;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

