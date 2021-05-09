namespace GraphDiplom
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelNodeDesc = new System.Windows.Forms.Label();
            this.butMakeNodeFinish = new System.Windows.Forms.Button();
            this.butMakeNodeStart = new System.Windows.Forms.Button();
            this.labelDesc = new System.Windows.Forms.Label();
            this.Canvas = new System.Windows.Forms.Panel();
            this.textAnalyseInfo = new System.Windows.Forms.TextBox();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.panelNodeControl = new System.Windows.Forms.Panel();
            this.butNodeSaveAbso = new System.Windows.Forms.Button();
            this.textNodeAbsoValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPathFFValue2 = new System.Windows.Forms.TextBox();
            this.butSetupRandomFFValue = new System.Windows.Forms.Button();
            this.labelSelectedPath = new System.Windows.Forms.Label();
            this.butSetupPathFF = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textPathFFValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboNodePaths = new System.Windows.Forms.ComboBox();
            this.butClearCanvas = new System.Windows.Forms.Button();
            this.butAnalyseInfo = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labelEx3Result = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.butEx3CalcFordFalk = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelEx2Result = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.butEx2CalcFordFalk = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.labelEx1Result = new System.Windows.Forms.Label();
            this.butEx1CalcFordFalk = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Canvas.SuspendLayout();
            this.panelNodeControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelHeader.Location = new System.Drawing.Point(37, 11);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(263, 48);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Алгоритмы и методы \r\nрасчёта потоков в сетях";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNodeDesc
            // 
            this.labelNodeDesc.AutoSize = true;
            this.labelNodeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNodeDesc.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelNodeDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelNodeDesc.Location = new System.Drawing.Point(12, 11);
            this.labelNodeDesc.Name = "labelNodeDesc";
            this.labelNodeDesc.Size = new System.Drawing.Size(166, 24);
            this.labelNodeDesc.TabIndex = 4;
            this.labelNodeDesc.Text = "Узел не выбран";
            this.labelNodeDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butMakeNodeFinish
            // 
            this.butMakeNodeFinish.BackColor = System.Drawing.Color.MediumVioletRed;
            this.butMakeNodeFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMakeNodeFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butMakeNodeFinish.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.butMakeNodeFinish.Location = new System.Drawing.Point(141, 38);
            this.butMakeNodeFinish.Name = "butMakeNodeFinish";
            this.butMakeNodeFinish.Size = new System.Drawing.Size(122, 56);
            this.butMakeNodeFinish.TabIndex = 3;
            this.butMakeNodeFinish.Text = "Сделать Стоком";
            this.butMakeNodeFinish.UseVisualStyleBackColor = false;
            this.butMakeNodeFinish.Click += new System.EventHandler(this.butMakeNodeFinish_Click);
            // 
            // butMakeNodeStart
            // 
            this.butMakeNodeStart.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.butMakeNodeStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMakeNodeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butMakeNodeStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.butMakeNodeStart.Location = new System.Drawing.Point(14, 38);
            this.butMakeNodeStart.Name = "butMakeNodeStart";
            this.butMakeNodeStart.Size = new System.Drawing.Size(121, 56);
            this.butMakeNodeStart.TabIndex = 2;
            this.butMakeNodeStart.Text = "Сделать Истоком";
            this.butMakeNodeStart.UseVisualStyleBackColor = false;
            this.butMakeNodeStart.Click += new System.EventHandler(this.butMakeNodeStart_Click);
            // 
            // labelDesc
            // 
            this.labelDesc.AutoSize = true;
            this.labelDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDesc.Location = new System.Drawing.Point(369, 21);
            this.labelDesc.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(239, 32);
            this.labelDesc.TabIndex = 1;
            this.labelDesc.Text = "ЛКМ - выбрать узел \r\nПКМ - добавить узел к выбранному";
            this.labelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Canvas
            // 
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.Controls.Add(this.textAnalyseInfo);
            this.Canvas.Controls.Add(this.labelWelcome);
            this.Canvas.Location = new System.Drawing.Point(22, 63);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(586, 385);
            this.Canvas.TabIndex = 4;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseClick);
            // 
            // textAnalyseInfo
            // 
            this.textAnalyseInfo.AcceptsReturn = true;
            this.textAnalyseInfo.AcceptsTab = true;
            this.textAnalyseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textAnalyseInfo.Location = new System.Drawing.Point(-1, 127);
            this.textAnalyseInfo.Multiline = true;
            this.textAnalyseInfo.Name = "textAnalyseInfo";
            this.textAnalyseInfo.ReadOnly = true;
            this.textAnalyseInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textAnalyseInfo.Size = new System.Drawing.Size(586, 258);
            this.textAnalyseInfo.TabIndex = 3;
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelWelcome.Location = new System.Drawing.Point(14, 9);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(256, 80);
            this.labelWelcome.TabIndex = 2;
            this.labelWelcome.Text = "Добро пожаловать!\r\n\r\nДобавьте первый узел \r\nкликом правой кнопки мыши.";
            // 
            // panelNodeControl
            // 
            this.panelNodeControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelNodeControl.Controls.Add(this.butNodeSaveAbso);
            this.panelNodeControl.Controls.Add(this.textNodeAbsoValue);
            this.panelNodeControl.Controls.Add(this.label2);
            this.panelNodeControl.Controls.Add(this.textPathFFValue2);
            this.panelNodeControl.Controls.Add(this.butSetupRandomFFValue);
            this.panelNodeControl.Controls.Add(this.labelSelectedPath);
            this.panelNodeControl.Controls.Add(this.butSetupPathFF);
            this.panelNodeControl.Controls.Add(this.label3);
            this.panelNodeControl.Controls.Add(this.textPathFFValue);
            this.panelNodeControl.Controls.Add(this.label1);
            this.panelNodeControl.Controls.Add(this.comboNodePaths);
            this.panelNodeControl.Controls.Add(this.labelNodeDesc);
            this.panelNodeControl.Controls.Add(this.butMakeNodeStart);
            this.panelNodeControl.Controls.Add(this.butMakeNodeFinish);
            this.panelNodeControl.Enabled = false;
            this.panelNodeControl.Location = new System.Drawing.Point(618, 178);
            this.panelNodeControl.Name = "panelNodeControl";
            this.panelNodeControl.Size = new System.Drawing.Size(281, 305);
            this.panelNodeControl.TabIndex = 5;
            // 
            // butNodeSaveAbso
            // 
            this.butNodeSaveAbso.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.butNodeSaveAbso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNodeSaveAbso.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butNodeSaveAbso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butNodeSaveAbso.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butNodeSaveAbso.Location = new System.Drawing.Point(183, 100);
            this.butNodeSaveAbso.Name = "butNodeSaveAbso";
            this.butNodeSaveAbso.Size = new System.Drawing.Size(80, 27);
            this.butNodeSaveAbso.TabIndex = 17;
            this.butNodeSaveAbso.Text = "сохранить";
            this.butNodeSaveAbso.UseVisualStyleBackColor = false;
            this.butNodeSaveAbso.Click += new System.EventHandler(this.butNodeSaveAbso_Click);
            // 
            // textNodeAbsoValue
            // 
            this.textNodeAbsoValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textNodeAbsoValue.Location = new System.Drawing.Point(116, 102);
            this.textNodeAbsoValue.Name = "textNodeAbsoValue";
            this.textNodeAbsoValue.Size = new System.Drawing.Size(59, 21);
            this.textNodeAbsoValue.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(14, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Поглощение:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textPathFFValue2
            // 
            this.textPathFFValue2.Enabled = false;
            this.textPathFFValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPathFFValue2.Location = new System.Drawing.Point(79, 216);
            this.textPathFFValue2.Name = "textPathFFValue2";
            this.textPathFFValue2.Size = new System.Drawing.Size(56, 21);
            this.textPathFFValue2.TabIndex = 14;
            // 
            // butSetupRandomFFValue
            // 
            this.butSetupRandomFFValue.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.butSetupRandomFFValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSetupRandomFFValue.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSetupRandomFFValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butSetupRandomFFValue.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butSetupRandomFFValue.Location = new System.Drawing.Point(141, 216);
            this.butSetupRandomFFValue.Name = "butSetupRandomFFValue";
            this.butSetupRandomFFValue.Size = new System.Drawing.Size(122, 74);
            this.butSetupRandomFFValue.TabIndex = 13;
            this.butSetupRandomFFValue.Text = "Расставить пропускные способности случайно";
            this.butSetupRandomFFValue.UseVisualStyleBackColor = false;
            this.butSetupRandomFFValue.Click += new System.EventHandler(this.butSetupRandomFFValue_Click);
            // 
            // labelSelectedPath
            // 
            this.labelSelectedPath.AutoSize = true;
            this.labelSelectedPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedPath.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelSelectedPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSelectedPath.Location = new System.Drawing.Point(12, 125);
            this.labelSelectedPath.Name = "labelSelectedPath";
            this.labelSelectedPath.Size = new System.Drawing.Size(192, 24);
            this.labelSelectedPath.TabIndex = 12;
            this.labelSelectedPath.Text = "Ребро не выбрано";
            this.labelSelectedPath.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // butSetupPathFF
            // 
            this.butSetupPathFF.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.butSetupPathFF.Enabled = false;
            this.butSetupPathFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSetupPathFF.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSetupPathFF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butSetupPathFF.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butSetupPathFF.Location = new System.Drawing.Point(16, 242);
            this.butSetupPathFF.Name = "butSetupPathFF";
            this.butSetupPathFF.Size = new System.Drawing.Size(119, 47);
            this.butSetupPathFF.TabIndex = 11;
            this.butSetupPathFF.Text = "Задать";
            this.butSetupPathFF.UseVisualStyleBackColor = false;
            this.butSetupPathFF.Click += new System.EventHandler(this.butSetupPathFF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(13, 195);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Пропускная способность";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textPathFFValue
            // 
            this.textPathFFValue.Enabled = false;
            this.textPathFFValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPathFFValue.Location = new System.Drawing.Point(15, 216);
            this.textPathFFValue.Name = "textPathFFValue";
            this.textPathFFValue.Size = new System.Drawing.Size(60, 21);
            this.textPathFFValue.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(13, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выбор ребра";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboNodePaths
            // 
            this.comboNodePaths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNodePaths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboNodePaths.FormattingEnabled = true;
            this.comboNodePaths.Location = new System.Drawing.Point(15, 168);
            this.comboNodePaths.Name = "comboNodePaths";
            this.comboNodePaths.Size = new System.Drawing.Size(248, 24);
            this.comboNodePaths.TabIndex = 7;
            this.comboNodePaths.SelectedIndexChanged += new System.EventHandler(this.comboNodePaths_SelectedIndexChanged);
            // 
            // butClearCanvas
            // 
            this.butClearCanvas.BackColor = System.Drawing.Color.LightSkyBlue;
            this.butClearCanvas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butClearCanvas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butClearCanvas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.butClearCanvas.Location = new System.Drawing.Point(498, 452);
            this.butClearCanvas.Name = "butClearCanvas";
            this.butClearCanvas.Size = new System.Drawing.Size(110, 35);
            this.butClearCanvas.TabIndex = 6;
            this.butClearCanvas.Text = "Очистить";
            this.butClearCanvas.UseVisualStyleBackColor = false;
            this.butClearCanvas.Click += new System.EventHandler(this.butClearCanvas_Click);
            // 
            // butAnalyseInfo
            // 
            this.butAnalyseInfo.BackColor = System.Drawing.Color.SlateGray;
            this.butAnalyseInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAnalyseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butAnalyseInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.butAnalyseInfo.Location = new System.Drawing.Point(310, 452);
            this.butAnalyseInfo.Name = "butAnalyseInfo";
            this.butAnalyseInfo.Size = new System.Drawing.Size(182, 35);
            this.butAnalyseInfo.TabIndex = 7;
            this.butAnalyseInfo.Text = "Расчёты";
            this.butAnalyseInfo.UseVisualStyleBackColor = false;
            this.butAnalyseInfo.Click += new System.EventHandler(this.butAnalyseInfo_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labelEx3Result);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.butEx3CalcFordFalk);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(277, 125);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Задание 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // labelEx3Result
            // 
            this.labelEx3Result.AutoSize = true;
            this.labelEx3Result.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEx3Result.Location = new System.Drawing.Point(153, 89);
            this.labelEx3Result.Name = "labelEx3Result";
            this.labelEx3Result.Size = new System.Drawing.Size(24, 21);
            this.labelEx3Result.TabIndex = 5;
            this.labelEx3Result.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 32);
            this.label6.TabIndex = 4;
            this.label6.Text = "Максимальный\r\nпоток равен";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butEx3CalcFordFalk
            // 
            this.butEx3CalcFordFalk.BackColor = System.Drawing.Color.Salmon;
            this.butEx3CalcFordFalk.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEx3CalcFordFalk.ForeColor = System.Drawing.SystemColors.Window;
            this.butEx3CalcFordFalk.Location = new System.Drawing.Point(3, 3);
            this.butEx3CalcFordFalk.Name = "butEx3CalcFordFalk";
            this.butEx3CalcFordFalk.Size = new System.Drawing.Size(264, 63);
            this.butEx3CalcFordFalk.TabIndex = 2;
            this.butEx3CalcFordFalk.Text = "Рассчитать м.п. учитывая поглощение узлов\r\n";
            this.butEx3CalcFordFalk.UseVisualStyleBackColor = false;
            this.butEx3CalcFordFalk.Click += new System.EventHandler(this.butEx3CalcFordFalk_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelEx2Result);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.butEx2CalcFordFalk);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(277, 125);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Задание 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelEx2Result
            // 
            this.labelEx2Result.AutoSize = true;
            this.labelEx2Result.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEx2Result.Location = new System.Drawing.Point(153, 89);
            this.labelEx2Result.Name = "labelEx2Result";
            this.labelEx2Result.Size = new System.Drawing.Size(24, 21);
            this.labelEx2Result.TabIndex = 4;
            this.labelEx2Result.Text = "?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 32);
            this.label5.TabIndex = 3;
            this.label5.Text = "Максимальный\r\nпоток равен";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butEx2CalcFordFalk
            // 
            this.butEx2CalcFordFalk.BackColor = System.Drawing.Color.Salmon;
            this.butEx2CalcFordFalk.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEx2CalcFordFalk.ForeColor = System.Drawing.SystemColors.Window;
            this.butEx2CalcFordFalk.Location = new System.Drawing.Point(3, 3);
            this.butEx2CalcFordFalk.Name = "butEx2CalcFordFalk";
            this.butEx2CalcFordFalk.Size = new System.Drawing.Size(264, 63);
            this.butEx2CalcFordFalk.TabIndex = 1;
            this.butEx2CalcFordFalk.Text = "Рассчитать м.п. учитывая интервалы п.с. дуг\r\n";
            this.butEx2CalcFordFalk.UseVisualStyleBackColor = false;
            this.butEx2CalcFordFalk.Click += new System.EventHandler(this.butEx2CalcFordFalk_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.labelEx1Result);
            this.tabPage1.Controls.Add(this.butEx1CalcFordFalk);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(277, 125);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Задание 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "Максимальный\r\nпоток равен";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEx1Result
            // 
            this.labelEx1Result.AutoSize = true;
            this.labelEx1Result.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEx1Result.Location = new System.Drawing.Point(153, 89);
            this.labelEx1Result.Name = "labelEx1Result";
            this.labelEx1Result.Size = new System.Drawing.Size(24, 21);
            this.labelEx1Result.TabIndex = 1;
            this.labelEx1Result.Text = "?";
            // 
            // butEx1CalcFordFalk
            // 
            this.butEx1CalcFordFalk.BackColor = System.Drawing.Color.Salmon;
            this.butEx1CalcFordFalk.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEx1CalcFordFalk.ForeColor = System.Drawing.SystemColors.Window;
            this.butEx1CalcFordFalk.Location = new System.Drawing.Point(3, 3);
            this.butEx1CalcFordFalk.Name = "butEx1CalcFordFalk";
            this.butEx1CalcFordFalk.Size = new System.Drawing.Size(264, 63);
            this.butEx1CalcFordFalk.TabIndex = 0;
            this.butEx1CalcFordFalk.Text = "Рассчитать максимальный поток в сети";
            this.butEx1CalcFordFalk.UseVisualStyleBackColor = false;
            this.butEx1CalcFordFalk.Click += new System.EventHandler(this.butEx1CalcFordFalk_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(614, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(285, 151);
            this.tabControl1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(911, 495);
            this.Controls.Add(this.butAnalyseInfo);
            this.Controls.Add(this.butClearCanvas);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.panelNodeControl);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Визуализация и решение задач с графами";
            this.Canvas.ResumeLayout(false);
            this.Canvas.PerformLayout();
            this.panelNodeControl.ResumeLayout(false);
            this.panelNodeControl.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Button butMakeNodeFinish;
        private System.Windows.Forms.Button butMakeNodeStart;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.Label labelNodeDesc;
        private System.Windows.Forms.Panel panelNodeControl;
        private System.Windows.Forms.Button butClearCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboNodePaths;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelSelectedPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPathFFValue;
        private System.Windows.Forms.Button butSetupRandomFFValue;
        private System.Windows.Forms.Button butSetupPathFF;
        private System.Windows.Forms.TextBox textPathFFValue2;
        private System.Windows.Forms.TextBox textAnalyseInfo;
        private System.Windows.Forms.Button butAnalyseInfo;
        private System.Windows.Forms.TextBox textNodeAbsoValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butNodeSaveAbso;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label labelEx3Result;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butEx3CalcFordFalk;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelEx2Result;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button butEx2CalcFordFalk;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelEx1Result;
        private System.Windows.Forms.Button butEx1CalcFordFalk;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

