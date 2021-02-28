namespace ArduPilotLogConverter
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.infilePathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileSelectButton = new System.Windows.Forms.Button();
            this.fileLoad = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadTargetTreeView = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linerEasing = new System.Windows.Forms.CheckBox();
            this.throttleConvert = new System.Windows.Forms.CheckBox();
            this.outputFile = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.outfilePathBox = new System.Windows.Forms.TextBox();
            this.saveFileSelectButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // infilePathBox
            // 
            this.infilePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infilePathBox.Location = new System.Drawing.Point(51, 18);
            this.infilePathBox.Name = "infilePathBox";
            this.infilePathBox.Size = new System.Drawing.Size(659, 19);
            this.infilePathBox.TabIndex = 0;
            this.infilePathBox.Text = "C:\\Users\\surigoma\\Downloads\\roll_pitch.log";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ファイル";
            // 
            // fileSelectButton
            // 
            this.fileSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileSelectButton.Location = new System.Drawing.Point(716, 16);
            this.fileSelectButton.Name = "fileSelectButton";
            this.fileSelectButton.Size = new System.Drawing.Size(78, 23);
            this.fileSelectButton.TabIndex = 2;
            this.fileSelectButton.Text = "参照";
            this.fileSelectButton.UseVisualStyleBackColor = true;
            this.fileSelectButton.Click += new System.EventHandler(this.fileSelectButton_Click);
            // 
            // fileLoad
            // 
            this.fileLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileLoad.Location = new System.Drawing.Point(6, 43);
            this.fileLoad.Name = "fileLoad";
            this.fileLoad.Size = new System.Drawing.Size(788, 23);
            this.fileLoad.TabIndex = 2;
            this.fileLoad.Text = "読み込み";
            this.fileLoad.UseVisualStyleBackColor = true;
            this.fileLoad.Click += new System.EventHandler(this.fileLoad_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.infilePathBox);
            this.groupBox1.Controls.Add(this.fileLoad);
            this.groupBox1.Controls.Add(this.fileSelectButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入力ファイル指定";
            // 
            // loadTargetTreeView
            // 
            this.loadTargetTreeView.CheckBoxes = true;
            this.loadTargetTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadTargetTreeView.Location = new System.Drawing.Point(3, 15);
            this.loadTargetTreeView.Name = "loadTargetTreeView";
            this.loadTargetTreeView.Size = new System.Drawing.Size(794, 301);
            this.loadTargetTreeView.TabIndex = 4;
            this.loadTargetTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.loadTargetTreeView_AfterCheck);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.loadTargetTreeView);
            this.groupBox2.Location = new System.Drawing.Point(12, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 319);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "吐き出し対象選択";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.flowLayoutPanel1);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(12, 417);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(800, 60);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "吐き出しオプション";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.linerEasing);
            this.flowLayoutPanel1.Controls.Add(this.throttleConvert);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 15);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(794, 42);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // linerEasing
            // 
            this.linerEasing.AutoSize = true;
            this.linerEasing.Checked = true;
            this.linerEasing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.linerEasing.Location = new System.Drawing.Point(3, 3);
            this.linerEasing.Name = "linerEasing";
            this.linerEasing.Size = new System.Drawing.Size(257, 16);
            this.linerEasing.TabIndex = 0;
            this.linerEasing.Text = "サンプルにデータが無かった場合に線形補間を行う";
            this.linerEasing.UseVisualStyleBackColor = true;
            // 
            // throttleConvert
            // 
            this.throttleConvert.AutoSize = true;
            this.throttleConvert.Checked = true;
            this.throttleConvert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.throttleConvert.Location = new System.Drawing.Point(266, 3);
            this.throttleConvert.Name = "throttleConvert";
            this.throttleConvert.Size = new System.Drawing.Size(170, 16);
            this.throttleConvert.TabIndex = 1;
            this.throttleConvert.Text = "スロットル出力を0-1に変換する";
            this.throttleConvert.UseVisualStyleBackColor = true;
            // 
            // outputFile
            // 
            this.outputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFile.Location = new System.Drawing.Point(6, 43);
            this.outputFile.Name = "outputFile";
            this.outputFile.Size = new System.Drawing.Size(788, 23);
            this.outputFile.TabIndex = 2;
            this.outputFile.Text = "CSV吐き出し";
            this.outputFile.UseVisualStyleBackColor = true;
            this.outputFile.Click += new System.EventHandler(this.outputFile_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.outfilePathBox);
            this.groupBox4.Controls.Add(this.outputFile);
            this.groupBox4.Controls.Add(this.saveFileSelectButton);
            this.groupBox4.Location = new System.Drawing.Point(12, 483);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(800, 75);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "出力ファイル指定";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "ファイル";
            // 
            // outfilePathBox
            // 
            this.outfilePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outfilePathBox.Location = new System.Drawing.Point(51, 18);
            this.outfilePathBox.Name = "outfilePathBox";
            this.outfilePathBox.Size = new System.Drawing.Size(659, 19);
            this.outfilePathBox.TabIndex = 0;
            this.outfilePathBox.Text = "C:\\Users\\surigoma\\Desktop\\testout.csv";
            // 
            // saveFileSelectButton
            // 
            this.saveFileSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFileSelectButton.Location = new System.Drawing.Point(716, 16);
            this.saveFileSelectButton.Name = "saveFileSelectButton";
            this.saveFileSelectButton.Size = new System.Drawing.Size(78, 23);
            this.saveFileSelectButton.TabIndex = 2;
            this.saveFileSelectButton.Text = "参照";
            this.saveFileSelectButton.UseVisualStyleBackColor = true;
            this.saveFileSelectButton.Click += new System.EventHandler(this.saveFileSelectButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 570);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "ArduPilotLogConverter -Version. Alpha-";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox infilePathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button fileSelectButton;
        private System.Windows.Forms.Button fileLoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView loadTargetTreeView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox linerEasing;
        private System.Windows.Forms.Button outputFile;
        private System.Windows.Forms.CheckBox throttleConvert;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outfilePathBox;
        private System.Windows.Forms.Button saveFileSelectButton;
    }
}

