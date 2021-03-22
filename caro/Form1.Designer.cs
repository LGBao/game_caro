
namespace caro
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pal_chessboard = new System.Windows.Forms.Panel();
            this.pal_top = new System.Windows.Forms.Panel();
            this.pc_1 = new System.Windows.Forms.PictureBox();
            this.pal_bot = new System.Windows.Forms.Panel();
            this.lb_lawPlay = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txt_IPserver = new System.Windows.Forms.TextBox();
            this.pc_avtplayer = new System.Windows.Forms.PictureBox();
            this.probar_timeDown = new System.Windows.Forms.ProgressBar();
            this.txt_namePlayer = new System.Windows.Forms.TextBox();
            this.tr_timeDown = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pal_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_1)).BeginInit();
            this.pal_bot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_avtplayer)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pal_chessboard
            // 
            this.pal_chessboard.Location = new System.Drawing.Point(12, 31);
            this.pal_chessboard.Name = "pal_chessboard";
            this.pal_chessboard.Size = new System.Drawing.Size(663, 575);
            this.pal_chessboard.TabIndex = 0;
            // 
            // pal_top
            // 
            this.pal_top.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pal_top.Controls.Add(this.pc_1);
            this.pal_top.Location = new System.Drawing.Point(687, 35);
            this.pal_top.Name = "pal_top";
            this.pal_top.Size = new System.Drawing.Size(304, 243);
            this.pal_top.TabIndex = 1;
            // 
            // pc_1
            // 
            this.pc_1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pc_1.BackgroundImage")));
            this.pc_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pc_1.Location = new System.Drawing.Point(3, 3);
            this.pc_1.Name = "pc_1";
            this.pc_1.Size = new System.Drawing.Size(299, 239);
            this.pc_1.TabIndex = 0;
            this.pc_1.TabStop = false;
            // 
            // pal_bot
            // 
            this.pal_bot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pal_bot.Controls.Add(this.lb_lawPlay);
            this.pal_bot.Controls.Add(this.btn_connect);
            this.pal_bot.Controls.Add(this.txt_IPserver);
            this.pal_bot.Controls.Add(this.pc_avtplayer);
            this.pal_bot.Controls.Add(this.probar_timeDown);
            this.pal_bot.Controls.Add(this.txt_namePlayer);
            this.pal_bot.Location = new System.Drawing.Point(687, 303);
            this.pal_bot.Name = "pal_bot";
            this.pal_bot.Size = new System.Drawing.Size(304, 304);
            this.pal_bot.TabIndex = 2;
            // 
            // lb_lawPlay
            // 
            this.lb_lawPlay.AutoSize = true;
            this.lb_lawPlay.Font = new System.Drawing.Font("Garamond", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_lawPlay.Location = new System.Drawing.Point(24, 218);
            this.lb_lawPlay.Name = "lb_lawPlay";
            this.lb_lawPlay.Size = new System.Drawing.Size(243, 37);
            this.lb_lawPlay.TabIndex = 5;
            this.lb_lawPlay.Text = "5 in a line to win";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(14, 143);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(153, 58);
            this.btn_connect.TabIndex = 4;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_IPserver
            // 
            this.txt_IPserver.Location = new System.Drawing.Point(13, 106);
            this.txt_IPserver.Name = "txt_IPserver";
            this.txt_IPserver.Size = new System.Drawing.Size(154, 22);
            this.txt_IPserver.TabIndex = 3;
            // 
            // pc_avtplayer
            // 
            this.pc_avtplayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pc_avtplayer.Location = new System.Drawing.Point(182, 17);
            this.pc_avtplayer.Name = "pc_avtplayer";
            this.pc_avtplayer.Size = new System.Drawing.Size(110, 120);
            this.pc_avtplayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pc_avtplayer.TabIndex = 2;
            this.pc_avtplayer.TabStop = false;
            // 
            // probar_timeDown
            // 
            this.probar_timeDown.Location = new System.Drawing.Point(13, 47);
            this.probar_timeDown.Name = "probar_timeDown";
            this.probar_timeDown.Size = new System.Drawing.Size(154, 37);
            this.probar_timeDown.TabIndex = 1;
            // 
            // txt_namePlayer
            // 
            this.txt_namePlayer.Location = new System.Drawing.Point(14, 11);
            this.txt_namePlayer.Name = "txt_namePlayer";
            this.txt_namePlayer.ReadOnly = true;
            this.txt_namePlayer.Size = new System.Drawing.Size(153, 22);
            this.txt_namePlayer.TabIndex = 0;
            // 
            // tr_timeDown
            // 
            this.tr_timeDown.Tick += new System.EventHandler(this.tr_timeDown_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1015, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.newGameToolStripMenuItem.Text = "New game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 617);
            this.Controls.Add(this.pal_bot);
            this.Controls.Add(this.pal_top);
            this.Controls.Add(this.pal_chessboard);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Game Caro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.pal_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pc_1)).EndInit();
            this.pal_bot.ResumeLayout(false);
            this.pal_bot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_avtplayer)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pal_chessboard;
        private System.Windows.Forms.Panel pal_top;
        private System.Windows.Forms.PictureBox pc_1;
        private System.Windows.Forms.Panel pal_bot;
        private System.Windows.Forms.TextBox txt_namePlayer;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txt_IPserver;
        private System.Windows.Forms.PictureBox pc_avtplayer;
        private System.Windows.Forms.ProgressBar probar_timeDown;
        private System.Windows.Forms.Label lb_lawPlay;
        private System.Windows.Forms.Timer tr_timeDown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    }
}

