
namespace R11546004ACO
{
    partial class Form_Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.propertyGrid_Problem = new System.Windows.Forms.PropertyGrid();
            this.btn_OpenTSPProblem = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl_Graph = new System.Windows.Forms.TabControl();
            this.tabPage_Cities = new System.Windows.Forms.TabPage();
            this.tabPage_Pheromone = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.propertyGrid_Solver = new System.Windows.Forms.PropertyGrid();
            this.tabControl_Solver = new System.Windows.Forms.TabControl();
            this.tabPage_ACO = new System.Windows.Forms.TabPage();
            this.radioButton_AS = new System.Windows.Forms.RadioButton();
            this.radioButton_ACS = new System.Windows.Forms.RadioButton();
            this.btn_CreateACO = new System.Windows.Forms.Button();
            this.tabPage_GA = new System.Windows.Forms.TabPage();
            this.radioButton_TSPGA = new System.Windows.Forms.RadioButton();
            this.radioButton_PermutationGA = new System.Windows.Forms.RadioButton();
            this.button_CreateGASolver = new System.Windows.Forms.Button();
            this.checkBox_ShowProgress = new System.Windows.Forms.CheckBox();
            this.btn_RunToEnd = new System.Windows.Forms.Button();
            this.btn_RunOneIter = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.richTextBox_BestSolution = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_BestObj = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_Pheremone = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Solutions = new System.Windows.Forms.RichTextBox();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.checkBox_ShowPeremone = new System.Windows.Forms.CheckBox();
            this.checkBox_ShowSolutions = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.tabControl_Graph.SuspendLayout();
            this.tabPage_Pheromone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.tabControl_Solver.SuspendLayout();
            this.tabPage_ACO.SuspendLayout();
            this.tabPage_GA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1234, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 813);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1234, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.propertyGrid_Problem);
            this.splitContainer1.Panel1.Controls.Add(this.btn_OpenTSPProblem);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1234, 786);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.TabIndex = 3;
            // 
            // propertyGrid_Problem
            // 
            this.propertyGrid_Problem.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGrid_Problem.Font = new System.Drawing.Font("Arial", 10F);
            this.propertyGrid_Problem.Location = new System.Drawing.Point(0, 81);
            this.propertyGrid_Problem.Name = "propertyGrid_Problem";
            this.propertyGrid_Problem.Size = new System.Drawing.Size(320, 305);
            this.propertyGrid_Problem.TabIndex = 1;
            // 
            // btn_OpenTSPProblem
            // 
            this.btn_OpenTSPProblem.BackColor = System.Drawing.Color.PapayaWhip;
            this.btn_OpenTSPProblem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_OpenTSPProblem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OpenTSPProblem.Location = new System.Drawing.Point(0, 0);
            this.btn_OpenTSPProblem.Name = "btn_OpenTSPProblem";
            this.btn_OpenTSPProblem.Size = new System.Drawing.Size(320, 81);
            this.btn_OpenTSPProblem.TabIndex = 0;
            this.btn_OpenTSPProblem.Text = "Open TSP Problem";
            this.btn_OpenTSPProblem.UseVisualStyleBackColor = false;
            this.btn_OpenTSPProblem.Click += new System.EventHandler(this.btn_OpenTSPProblem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(908, 786);
            this.splitContainer2.SplitterDistance = 504;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.mainChart);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabControl_Graph);
            this.splitContainer3.Size = new System.Drawing.Size(504, 786);
            this.splitContainer3.SplitterDistance = 366;
            this.splitContainer3.TabIndex = 0;
            // 
            // mainChart
            // 
            chartArea4.AxisX.Title = "Iterations";
            chartArea4.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea4);
            this.mainChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Alignment = System.Drawing.StringAlignment.Center;
            legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend4.Name = "Legend1";
            this.mainChart.Legends.Add(legend4);
            this.mainChart.Location = new System.Drawing.Point(0, 0);
            this.mainChart.Name = "mainChart";
            series10.BorderWidth = 3;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Color = System.Drawing.Color.Green;
            series10.Legend = "Legend1";
            series10.LegendText = "Iteration Average";
            series10.MarkerBorderWidth = 3;
            series10.Name = "Series_iterAVG";
            series11.BorderColor = System.Drawing.Color.White;
            series11.BorderWidth = 3;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Color = System.Drawing.Color.Blue;
            series11.Legend = "Legend1";
            series11.LegendText = "Iteration Best";
            series11.Name = "Series_iterBest";
            series12.BorderWidth = 3;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Color = System.Drawing.Color.Red;
            series12.Legend = "Legend1";
            series12.LegendText = "So Far the Best";
            series12.Name = "Series_SoFarTheBest";
            this.mainChart.Series.Add(series10);
            this.mainChart.Series.Add(series11);
            this.mainChart.Series.Add(series12);
            this.mainChart.Size = new System.Drawing.Size(502, 364);
            this.mainChart.TabIndex = 0;
            this.mainChart.Text = "chart1";
            // 
            // tabControl_Graph
            // 
            this.tabControl_Graph.Controls.Add(this.tabPage_Cities);
            this.tabControl_Graph.Controls.Add(this.tabPage_Pheromone);
            this.tabControl_Graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Graph.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Graph.Name = "tabControl_Graph";
            this.tabControl_Graph.SelectedIndex = 0;
            this.tabControl_Graph.Size = new System.Drawing.Size(502, 414);
            this.tabControl_Graph.TabIndex = 0;
            // 
            // tabPage_Cities
            // 
            this.tabPage_Cities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPage_Cities.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Cities.Name = "tabPage_Cities";
            this.tabPage_Cities.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Cities.Size = new System.Drawing.Size(494, 384);
            this.tabPage_Cities.TabIndex = 0;
            this.tabPage_Cities.Text = "Cities & Routes";
            this.tabPage_Cities.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage_Cities_Paint);
            // 
            // tabPage_Pheromone
            // 
            this.tabPage_Pheromone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPage_Pheromone.Controls.Add(this.splitContainer6);
            this.tabPage_Pheromone.Controls.Add(this.splitContainer5);
            this.tabPage_Pheromone.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Pheromone.Name = "tabPage_Pheromone";
            this.tabPage_Pheromone.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Pheromone.Size = new System.Drawing.Size(494, 384);
            this.tabPage_Pheromone.TabIndex = 1;
            this.tabPage_Pheromone.Text = "Pheromone & Solutions";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.splitContainer4.Panel1.Controls.Add(this.propertyGrid_Solver);
            this.splitContainer4.Panel1.Controls.Add(this.tabControl_Solver);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.checkBox_ShowProgress);
            this.splitContainer4.Panel2.Controls.Add(this.btn_RunToEnd);
            this.splitContainer4.Panel2.Controls.Add(this.btn_RunOneIter);
            this.splitContainer4.Panel2.Controls.Add(this.btn_Reset);
            this.splitContainer4.Panel2.Controls.Add(this.richTextBox_BestSolution);
            this.splitContainer4.Panel2.Controls.Add(this.label2);
            this.splitContainer4.Panel2.Controls.Add(this.richTextBox_BestObj);
            this.splitContainer4.Panel2.Controls.Add(this.label1);
            this.splitContainer4.Size = new System.Drawing.Size(398, 784);
            this.splitContainer4.SplitterDistance = 448;
            this.splitContainer4.TabIndex = 0;
            // 
            // propertyGrid_Solver
            // 
            this.propertyGrid_Solver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid_Solver.Location = new System.Drawing.Point(0, 90);
            this.propertyGrid_Solver.Name = "propertyGrid_Solver";
            this.propertyGrid_Solver.Size = new System.Drawing.Size(398, 358);
            this.propertyGrid_Solver.TabIndex = 1;
            this.propertyGrid_Solver.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_Solver_PropertyValueChanged);
            // 
            // tabControl_Solver
            // 
            this.tabControl_Solver.Controls.Add(this.tabPage_ACO);
            this.tabControl_Solver.Controls.Add(this.tabPage_GA);
            this.tabControl_Solver.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl_Solver.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Solver.Name = "tabControl_Solver";
            this.tabControl_Solver.SelectedIndex = 0;
            this.tabControl_Solver.Size = new System.Drawing.Size(398, 90);
            this.tabControl_Solver.TabIndex = 0;
            // 
            // tabPage_ACO
            // 
            this.tabPage_ACO.BackColor = System.Drawing.Color.Beige;
            this.tabPage_ACO.Controls.Add(this.radioButton_AS);
            this.tabPage_ACO.Controls.Add(this.radioButton_ACS);
            this.tabPage_ACO.Controls.Add(this.btn_CreateACO);
            this.tabPage_ACO.Location = new System.Drawing.Point(4, 26);
            this.tabPage_ACO.Name = "tabPage_ACO";
            this.tabPage_ACO.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ACO.Size = new System.Drawing.Size(390, 60);
            this.tabPage_ACO.TabIndex = 0;
            this.tabPage_ACO.Text = "ACO";
            // 
            // radioButton_AS
            // 
            this.radioButton_AS.AutoSize = true;
            this.radioButton_AS.Location = new System.Drawing.Point(7, 34);
            this.radioButton_AS.Name = "radioButton_AS";
            this.radioButton_AS.Size = new System.Drawing.Size(104, 21);
            this.radioButton_AS.TabIndex = 2;
            this.radioButton_AS.Text = "Ant System";
            this.radioButton_AS.UseVisualStyleBackColor = true;
            // 
            // radioButton_ACS
            // 
            this.radioButton_ACS.AutoSize = true;
            this.radioButton_ACS.Checked = true;
            this.radioButton_ACS.Location = new System.Drawing.Point(7, 7);
            this.radioButton_ACS.Name = "radioButton_ACS";
            this.radioButton_ACS.Size = new System.Drawing.Size(153, 21);
            this.radioButton_ACS.TabIndex = 1;
            this.radioButton_ACS.TabStop = true;
            this.radioButton_ACS.Text = "Ant Colony System";
            this.radioButton_ACS.UseVisualStyleBackColor = true;
            // 
            // btn_CreateACO
            // 
            this.btn_CreateACO.BackColor = System.Drawing.Color.Wheat;
            this.btn_CreateACO.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CreateACO.Enabled = false;
            this.btn_CreateACO.Location = new System.Drawing.Point(170, 3);
            this.btn_CreateACO.Name = "btn_CreateACO";
            this.btn_CreateACO.Size = new System.Drawing.Size(217, 54);
            this.btn_CreateACO.TabIndex = 0;
            this.btn_CreateACO.Text = "Create ACO Solver";
            this.btn_CreateACO.UseVisualStyleBackColor = false;
            this.btn_CreateACO.Click += new System.EventHandler(this.btn_CreateACO_Click);
            // 
            // tabPage_GA
            // 
            this.tabPage_GA.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage_GA.Controls.Add(this.radioButton_TSPGA);
            this.tabPage_GA.Controls.Add(this.radioButton_PermutationGA);
            this.tabPage_GA.Controls.Add(this.button_CreateGASolver);
            this.tabPage_GA.Location = new System.Drawing.Point(4, 26);
            this.tabPage_GA.Name = "tabPage_GA";
            this.tabPage_GA.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_GA.Size = new System.Drawing.Size(390, 60);
            this.tabPage_GA.TabIndex = 1;
            this.tabPage_GA.Text = "GA";
            // 
            // radioButton_TSPGA
            // 
            this.radioButton_TSPGA.AutoSize = true;
            this.radioButton_TSPGA.Location = new System.Drawing.Point(7, 35);
            this.radioButton_TSPGA.Name = "radioButton_TSPGA";
            this.radioButton_TSPGA.Size = new System.Drawing.Size(82, 21);
            this.radioButton_TSPGA.TabIndex = 2;
            this.radioButton_TSPGA.Text = "TSP GA";
            this.radioButton_TSPGA.UseVisualStyleBackColor = true;
            // 
            // radioButton_PermutationGA
            // 
            this.radioButton_PermutationGA.AutoSize = true;
            this.radioButton_PermutationGA.Checked = true;
            this.radioButton_PermutationGA.Location = new System.Drawing.Point(7, 7);
            this.radioButton_PermutationGA.Name = "radioButton_PermutationGA";
            this.radioButton_PermutationGA.Size = new System.Drawing.Size(132, 21);
            this.radioButton_PermutationGA.TabIndex = 1;
            this.radioButton_PermutationGA.TabStop = true;
            this.radioButton_PermutationGA.Text = "Permutation GA";
            this.radioButton_PermutationGA.UseVisualStyleBackColor = true;
            // 
            // button_CreateGASolver
            // 
            this.button_CreateGASolver.BackColor = System.Drawing.Color.NavajoWhite;
            this.button_CreateGASolver.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_CreateGASolver.Enabled = false;
            this.button_CreateGASolver.Location = new System.Drawing.Point(180, 3);
            this.button_CreateGASolver.Name = "button_CreateGASolver";
            this.button_CreateGASolver.Size = new System.Drawing.Size(207, 54);
            this.button_CreateGASolver.TabIndex = 0;
            this.button_CreateGASolver.Text = "Create GA Solver";
            this.button_CreateGASolver.UseVisualStyleBackColor = false;
            this.button_CreateGASolver.Click += new System.EventHandler(this.button_CreateGASolver_Click);
            // 
            // checkBox_ShowProgress
            // 
            this.checkBox_ShowProgress.AutoSize = true;
            this.checkBox_ShowProgress.Location = new System.Drawing.Point(27, 205);
            this.checkBox_ShowProgress.Name = "checkBox_ShowProgress";
            this.checkBox_ShowProgress.Size = new System.Drawing.Size(131, 21);
            this.checkBox_ShowProgress.TabIndex = 7;
            this.checkBox_ShowProgress.Text = "Show Progress";
            this.checkBox_ShowProgress.UseVisualStyleBackColor = true;
            // 
            // btn_RunToEnd
            // 
            this.btn_RunToEnd.Enabled = false;
            this.btn_RunToEnd.Font = new System.Drawing.Font("Arial", 10F);
            this.btn_RunToEnd.Location = new System.Drawing.Point(207, 232);
            this.btn_RunToEnd.Name = "btn_RunToEnd";
            this.btn_RunToEnd.Size = new System.Drawing.Size(170, 84);
            this.btn_RunToEnd.TabIndex = 6;
            this.btn_RunToEnd.Text = "Run to End";
            this.btn_RunToEnd.UseVisualStyleBackColor = true;
            this.btn_RunToEnd.Click += new System.EventHandler(this.btn_RunToEnd_Click);
            // 
            // btn_RunOneIter
            // 
            this.btn_RunOneIter.Enabled = false;
            this.btn_RunOneIter.Font = new System.Drawing.Font("Arial", 10F);
            this.btn_RunOneIter.Location = new System.Drawing.Point(27, 277);
            this.btn_RunOneIter.Name = "btn_RunOneIter";
            this.btn_RunOneIter.Size = new System.Drawing.Size(161, 39);
            this.btn_RunOneIter.TabIndex = 5;
            this.btn_RunOneIter.Text = "Run One Iteration";
            this.btn_RunOneIter.UseVisualStyleBackColor = true;
            this.btn_RunOneIter.Click += new System.EventHandler(this.btn_RunOneIter_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Enabled = false;
            this.btn_Reset.Font = new System.Drawing.Font("Arial", 10F);
            this.btn_Reset.Location = new System.Drawing.Point(27, 232);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(161, 39);
            this.btn_Reset.TabIndex = 4;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // richTextBox_BestSolution
            // 
            this.richTextBox_BestSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox_BestSolution.Location = new System.Drawing.Point(0, 70);
            this.richTextBox_BestSolution.Name = "richTextBox_BestSolution";
            this.richTextBox_BestSolution.Size = new System.Drawing.Size(398, 120);
            this.richTextBox_BestSolution.TabIndex = 3;
            this.richTextBox_BestSolution.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.Location = new System.Drawing.Point(0, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Best Solution";
            // 
            // richTextBox_BestObj
            // 
            this.richTextBox_BestObj.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox_BestObj.Location = new System.Drawing.Point(0, 17);
            this.richTextBox_BestObj.Name = "richTextBox_BestObj";
            this.richTextBox_BestObj.Size = new System.Drawing.Size(398, 34);
            this.richTextBox_BestObj.TabIndex = 1;
            this.richTextBox_BestObj.Text = "";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Best Objective Value";
            // 
            // richTextBox_Pheremone
            // 
            this.richTextBox_Pheremone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Pheremone.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_Pheremone.Name = "richTextBox_Pheremone";
            this.richTextBox_Pheremone.ReadOnly = true;
            this.richTextBox_Pheremone.Size = new System.Drawing.Size(236, 345);
            this.richTextBox_Pheremone.TabIndex = 0;
            this.richTextBox_Pheremone.Text = "";
            this.richTextBox_Pheremone.WordWrap = false;
            // 
            // richTextBox_Solutions
            // 
            this.richTextBox_Solutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Solutions.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_Solutions.Name = "richTextBox_Solutions";
            this.richTextBox_Solutions.ReadOnly = true;
            this.richTextBox_Solutions.Size = new System.Drawing.Size(248, 345);
            this.richTextBox_Solutions.TabIndex = 1;
            this.richTextBox_Solutions.Text = "";
            this.richTextBox_Solutions.WordWrap = false;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer5.Location = new System.Drawing.Point(3, 36);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.richTextBox_Pheremone);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.richTextBox_Solutions);
            this.splitContainer5.Size = new System.Drawing.Size(488, 345);
            this.splitContainer5.SplitterDistance = 236;
            this.splitContainer5.TabIndex = 2;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(3, 3);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.checkBox_ShowPeremone);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.checkBox_ShowSolutions);
            this.splitContainer6.Size = new System.Drawing.Size(488, 33);
            this.splitContainer6.SplitterDistance = 236;
            this.splitContainer6.TabIndex = 3;
            // 
            // checkBox_ShowPeremone
            // 
            this.checkBox_ShowPeremone.AutoSize = true;
            this.checkBox_ShowPeremone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_ShowPeremone.Location = new System.Drawing.Point(0, 0);
            this.checkBox_ShowPeremone.Name = "checkBox_ShowPeremone";
            this.checkBox_ShowPeremone.Size = new System.Drawing.Size(236, 33);
            this.checkBox_ShowPeremone.TabIndex = 0;
            this.checkBox_ShowPeremone.Text = "Show Pheremone";
            this.checkBox_ShowPeremone.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowSolutions
            // 
            this.checkBox_ShowSolutions.AutoSize = true;
            this.checkBox_ShowSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_ShowSolutions.Location = new System.Drawing.Point(0, 0);
            this.checkBox_ShowSolutions.Name = "checkBox_ShowSolutions";
            this.checkBox_ShowSolutions.Size = new System.Drawing.Size(248, 33);
            this.checkBox_ShowSolutions.TabIndex = 1;
            this.checkBox_ShowSolutions.Text = "Show Solutions";
            this.checkBox_ShowSolutions.UseVisualStyleBackColor = true;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 835);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TSP Solver";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.tabControl_Graph.ResumeLayout(false);
            this.tabPage_Pheromone.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.tabControl_Solver.ResumeLayout(false);
            this.tabPage_ACO.ResumeLayout(false);
            this.tabPage_ACO.PerformLayout();
            this.tabPage_GA.ResumeLayout(false);
            this.tabPage_GA.PerformLayout();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_OpenTSPProblem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.TabControl tabControl_Graph;
        private System.Windows.Forms.TabPage tabPage_Cities;
        private System.Windows.Forms.TabPage tabPage_Pheromone;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.PropertyGrid propertyGrid_Solver;
        private System.Windows.Forms.TabControl tabControl_Solver;
        private System.Windows.Forms.TabPage tabPage_ACO;
        private System.Windows.Forms.TabPage tabPage_GA;
        private System.Windows.Forms.Button btn_CreateACO;
        private System.Windows.Forms.RadioButton radioButton_TSPGA;
        private System.Windows.Forms.RadioButton radioButton_PermutationGA;
        private System.Windows.Forms.Button button_CreateGASolver;
        private System.Windows.Forms.PropertyGrid propertyGrid_Problem;
        private System.Windows.Forms.Button btn_RunToEnd;
        private System.Windows.Forms.Button btn_RunOneIter;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.RichTextBox richTextBox_BestSolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_BestObj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_ShowProgress;
        private System.Windows.Forms.RadioButton radioButton_AS;
        private System.Windows.Forms.RadioButton radioButton_ACS;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.RichTextBox richTextBox_Pheremone;
        private System.Windows.Forms.RichTextBox richTextBox_Solutions;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.CheckBox checkBox_ShowPeremone;
        private System.Windows.Forms.CheckBox checkBox_ShowSolutions;
    }
}

