namespace Shabbat
{
    partial class HostForm
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
            label1 = new Label();
            textBox_Category = new TextBox();
            button_Enter = new Button();
            listView_Categories = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(157, 51);
            label1.Name = "label1";
            label1.Size = new Size(190, 25);
            label1.TabIndex = 0;
            label1.Text = "מארח - הכנס קטגוריות";
            // 
            // textBox_Category
            // 
            textBox_Category.Location = new Point(173, 116);
            textBox_Category.Name = "textBox_Category";
            textBox_Category.Size = new Size(150, 31);
            textBox_Category.TabIndex = 1;
            // 
            // button_Enter
            // 
            button_Enter.Location = new Point(195, 186);
            button_Enter.Name = "button_Enter";
            button_Enter.Size = new Size(112, 34);
            button_Enter.TabIndex = 2;
            button_Enter.Text = "הכנס";
            button_Enter.UseVisualStyleBackColor = true;
            button_Enter.Click += button_Enter_Click;
            // 
            // listView_Categories
            // 
            ColumnHeader col = new ColumnHeader();
            col.Text = "קטגוריות";
            col.Width = 250;
            listView_Categories.Location = new Point(157, 251);
            listView_Categories.Name = "listView_Categories";
            listView_Categories.Size = new Size(182, 146);
            listView_Categories.TabIndex = 3;
            listView_Categories.UseCompatibleStateImageBehavior = false;
            listView_Categories.Columns.AddRange(new ColumnHeader[] { col});
            // 
            // HostForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 450);
            Controls.Add(listView_Categories);
            Controls.Add(button_Enter);
            Controls.Add(textBox_Category);
            Controls.Add(label1);
            Name = "HostForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "HostForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_Category;
        private Button button_Enter;
        private ListView listView_Categories;
    }
}