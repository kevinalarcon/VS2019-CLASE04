﻿namespace App.UI.Desktop
{
    partial class MDIPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeTracksConEFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeTracksConRepositorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteDeTracksConEFToolStripMenuItem,
            this.toolStripSeparator1,
            this.reporteDeTracksConRepositorioToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reporteDeTracksConEFToolStripMenuItem
            // 
            this.reporteDeTracksConEFToolStripMenuItem.Name = "reporteDeTracksConEFToolStripMenuItem";
            this.reporteDeTracksConEFToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.reporteDeTracksConEFToolStripMenuItem.Text = "Reporte de Tracks con EF";
            this.reporteDeTracksConEFToolStripMenuItem.Click += new System.EventHandler(this.reporteDeTracksConEFToolStripMenuItem_Click);
            // 
            // reporteDeTracksConRepositorioToolStripMenuItem
            // 
            this.reporteDeTracksConRepositorioToolStripMenuItem.Name = "reporteDeTracksConRepositorioToolStripMenuItem";
            this.reporteDeTracksConRepositorioToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.reporteDeTracksConRepositorioToolStripMenuItem.Text = "Reporte de Tracks con Repositorio";
            this.reporteDeTracksConRepositorioToolStripMenuItem.Click += new System.EventHandler(this.reporteDeTracksConRepositorioToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(250, 6);
            // 
            // MDIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDIPrincipal";
            this.Text = "MDIPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeTracksConEFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem reporteDeTracksConRepositorioToolStripMenuItem;
    }
}