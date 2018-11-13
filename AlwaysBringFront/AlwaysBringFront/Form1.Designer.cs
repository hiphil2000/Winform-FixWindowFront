namespace AlwaysBringFront
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.Combo_ProcessList = new System.Windows.Forms.ComboBox();
            this.Button_Toggle = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bring some window front";
            // 
            // Combo_ProcessList
            // 
            this.Combo_ProcessList.FormattingEnabled = true;
            this.Combo_ProcessList.Location = new System.Drawing.Point(12, 24);
            this.Combo_ProcessList.Name = "Combo_ProcessList";
            this.Combo_ProcessList.Size = new System.Drawing.Size(249, 20);
            this.Combo_ProcessList.TabIndex = 1;
            this.Combo_ProcessList.DropDown += new System.EventHandler(this.Combo_ProcessList_DropDown);
            // 
            // Button_Toggle
            // 
            this.Button_Toggle.Location = new System.Drawing.Point(186, 50);
            this.Button_Toggle.Name = "Button_Toggle";
            this.Button_Toggle.Size = new System.Drawing.Size(75, 23);
            this.Button_Toggle.TabIndex = 2;
            this.Button_Toggle.Text = "FIX!";
            this.Button_Toggle.UseVisualStyleBackColor = true;
            this.Button_Toggle.Click += new System.EventHandler(this.Button_Toggle_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 84);
            this.Controls.Add(this.Button_Toggle);
            this.Controls.Add(this.Combo_ProcessList);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(289, 123);
            this.MinimumSize = new System.Drawing.Size(289, 123);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlwaysFront";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Combo_ProcessList;
        private System.Windows.Forms.Button Button_Toggle;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

