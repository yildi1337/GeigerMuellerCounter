/*  
 *  This is the GUI software for visualizing the counts read from the
 *  Geiger-Mueller Counter via the USB interface program.
 *  
 *  Date: 2014-05-19
 *  Author: Phillip Durdaut
 */
namespace GeigerMuellerCounter
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_ZedGraphControlCounts = new ZedGraph.ZedGraphControl();
            this.m_ButtonStartStop = new System.Windows.Forms.Button();
            this.m_Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // m_ZedGraphControlCounts
            // 
            this.m_ZedGraphControlCounts.Location = new System.Drawing.Point(12, 12);
            this.m_ZedGraphControlCounts.Name = "m_ZedGraphControlCounts";
            this.m_ZedGraphControlCounts.ScrollGrace = 0D;
            this.m_ZedGraphControlCounts.ScrollMaxX = 0D;
            this.m_ZedGraphControlCounts.ScrollMaxY = 0D;
            this.m_ZedGraphControlCounts.ScrollMaxY2 = 0D;
            this.m_ZedGraphControlCounts.ScrollMinX = 0D;
            this.m_ZedGraphControlCounts.ScrollMinY = 0D;
            this.m_ZedGraphControlCounts.ScrollMinY2 = 0D;
            this.m_ZedGraphControlCounts.Size = new System.Drawing.Size(700, 400);
            this.m_ZedGraphControlCounts.TabIndex = 1;
            // 
            // m_ButtonStartStop
            // 
            this.m_ButtonStartStop.Location = new System.Drawing.Point(718, 12);
            this.m_ButtonStartStop.Name = "m_ButtonStartStop";
            this.m_ButtonStartStop.Size = new System.Drawing.Size(164, 61);
            this.m_ButtonStartStop.TabIndex = 2;
            this.m_ButtonStartStop.Text = "Start";
            this.m_ButtonStartStop.UseVisualStyleBackColor = true;
            this.m_ButtonStartStop.Click += new System.EventHandler(this.m_ButtonStartStop_Click);
            // 
            // m_Timer
            // 
            this.m_Timer.Interval = 1000;
            this.m_Timer.Tick += new System.EventHandler(this.m_Timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 428);
            this.Controls.Add(this.m_ButtonStartStop);
            this.Controls.Add(this.m_ZedGraphControlCounts);
            this.Name = "Form1";
            this.Text = "Geiger-Zaehler, Phillip Durdaut 2014";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl m_ZedGraphControlCounts;
        private System.Windows.Forms.Button m_ButtonStartStop;
        private System.Windows.Forms.Timer m_Timer;



    }
}

