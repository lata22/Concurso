namespace Concurso
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
            this.label1 = new System.Windows.Forms.Label();
            this.gSheetLabel = new System.Windows.Forms.Label();
            this.excelDataModelLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.validateButton = new System.Windows.Forms.Button();
            this.randomButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelParticipantes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Participantes Inscriptos:";
            // 
            // gSheetLabel
            // 
            this.gSheetLabel.AutoSize = true;
            this.gSheetLabel.Location = new System.Drawing.Point(168, 31);
            this.gSheetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gSheetLabel.Name = "gSheetLabel";
            this.gSheetLabel.Size = new System.Drawing.Size(82, 22);
            this.gSheetLabel.TabIndex = 1;
            this.gSheetLabel.Text = "Loading...";
            this.gSheetLabel.TextChanged += new System.EventHandler(this.gSheetLabel_TextChanged);
            // 
            // excelDataModelLabel
            // 
            this.excelDataModelLabel.AutoSize = true;
            this.excelDataModelLabel.Location = new System.Drawing.Point(161, 75);
            this.excelDataModelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.excelDataModelLabel.Name = "excelDataModelLabel";
            this.excelDataModelLabel.Size = new System.Drawing.Size(82, 22);
            this.excelDataModelLabel.TabIndex = 3;
            this.excelDataModelLabel.Text = "Loading...";
            this.excelDataModelLabel.TextChanged += new System.EventHandler(this.excelDataModelLabel_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Participantes en la BD:";
            // 
            // validateButton
            // 
            this.validateButton.Enabled = false;
            this.validateButton.Location = new System.Drawing.Point(125, 166);
            this.validateButton.Margin = new System.Windows.Forms.Padding(4);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(108, 48);
            this.validateButton.TabIndex = 6;
            this.validateButton.Text = "Validar";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.Click += new System.EventHandler(this.validateButton_Click);
            // 
            // randomButton
            // 
            this.randomButton.Enabled = false;
            this.randomButton.Location = new System.Drawing.Point(244, 166);
            this.randomButton.Margin = new System.Windows.Forms.Padding(4);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(212, 48);
            this.randomButton.TabIndex = 7;
            this.randomButton.Text = "Seleccionar Ganador";
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Participantes Validados:";
            // 
            // labelParticipantes
            // 
            this.labelParticipantes.AutoSize = true;
            this.labelParticipantes.Location = new System.Drawing.Point(168, 117);
            this.labelParticipantes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelParticipantes.Name = "labelParticipantes";
            this.labelParticipantes.Size = new System.Drawing.Size(19, 22);
            this.labelParticipantes.TabIndex = 9;
            this.labelParticipantes.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 227);
            this.Controls.Add(this.labelParticipantes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.randomButton);
            this.Controls.Add(this.validateButton);
            this.Controls.Add(this.excelDataModelLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gSheetLabel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 283);
            this.MinimumSize = new System.Drawing.Size(590, 283);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Concurso";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label gSheetLabel;
        private System.Windows.Forms.Label excelDataModelLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.Button randomButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelParticipantes;
    }
}

