namespace Aide_Dilicom3.Forms
{
    partial class DilicomForm
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
            this.OrdersListDS = new System.Data.DataSet();
            this.commande = new System.Data.DataTable();
            this.destinataire = new System.Data.DataColumn();
            this.date_envoi = new System.Data.DataColumn();
            this.date_remise = new System.Data.DataColumn();
            this.reference = new System.Data.DataColumn();
            this.lignes = new System.Data.DataColumn();
            this.exemplaires = new System.Data.DataColumn();
            this.url_ref = new System.Data.DataColumn();
            this.isSelected = new System.Data.DataColumn();
            this.MainTabs = new System.Windows.Forms.TabControl();
            this.RapidInfoTab = new System.Windows.Forms.TabPage();
            this.EanAdditionalColumnsGridView = new System.Windows.Forms.DataGridView();
            this.colNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EanAdditionalFieldsDS = new System.Data.DataSet();
            this.AdditionalColumnsTable = new System.Data.DataTable();
            this.ColName = new System.Data.DataColumn();
            this.ColFormula = new System.Data.DataColumn();
            this.ColEnabled = new System.Data.DataColumn();
            this.deleteEanButton = new System.Windows.Forms.Button();
            this.EanExportProgressBar = new System.Windows.Forms.ProgressBar();
            this.EanExportCSVButton = new System.Windows.Forms.Button();
            this.AddingPanelLabel = new System.Windows.Forms.Label();
            this.importEanButton = new System.Windows.Forms.Button();
            this.EanListGridView = new System.Windows.Forms.DataGridView();
            this.eanCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isEanSelectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EanListDS = new System.Data.DataSet();
            this.EanList = new System.Data.DataTable();
            this.EanCode = new System.Data.DataColumn();
            this.isEanSelected = new System.Data.DataColumn();
            this.CommandesTab = new System.Windows.Forms.TabPage();
            this.ExportCsvButton = new System.Windows.Forms.Button();
            this.OrdersExportProgressBar = new System.Windows.Forms.ProgressBar();
            this.CommandsCount = new System.Windows.Forms.NumericUpDown();
            this.OrdersGridView = new System.Windows.Forms.DataGridView();
            this.destinataireCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_remiseCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_envoiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lignesCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exemplairesCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url_refCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isSelectedCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.destinataireDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateenvoiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateremiseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lignesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exemplairesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlrefDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isSelectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.RefreshCommandsButton = new System.Windows.Forms.Button();
            this.ConfigTab = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.timeoutSelector = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.textCsvReplacement = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textCsvSeparator = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textWebBaseUrl = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveCsvFile = new System.Windows.Forms.SaveFileDialog();
            this.openEanFile = new System.Windows.Forms.OpenFileDialog();
            this.NavigoTab = new System.Windows.Forms.TabPage();
            this.MyWebBrowser = new System.Windows.Forms.WebBrowser();
            this.GoButton = new System.Windows.Forms.Button();
            this.UrlText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersListDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commande)).BeginInit();
            this.MainTabs.SuspendLayout();
            this.RapidInfoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EanAdditionalColumnsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EanAdditionalFieldsDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdditionalColumnsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EanListGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EanListDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EanList)).BeginInit();
            this.CommandesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CommandsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.ConfigTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutSelector)).BeginInit();
            this.NavigoTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrdersListDS
            // 
            this.OrdersListDS.CaseSensitive = true;
            this.OrdersListDS.DataSetName = "OffersListDS";
            this.OrdersListDS.EnforceConstraints = false;
            this.OrdersListDS.Tables.AddRange(new System.Data.DataTable[] {
            this.commande});
            // 
            // commande
            // 
            this.commande.CaseSensitive = false;
            this.commande.Columns.AddRange(new System.Data.DataColumn[] {
            this.destinataire,
            this.date_envoi,
            this.date_remise,
            this.reference,
            this.lignes,
            this.exemplaires,
            this.url_ref,
            this.isSelected});
            this.commande.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "reference"}, true)});
            this.commande.PrimaryKey = new System.Data.DataColumn[] {
        this.reference};
            this.commande.TableName = "commande";
            // 
            // destinataire
            // 
            this.destinataire.ColumnName = "destinataire";
            this.destinataire.DefaultValue = "\"\"";
            // 
            // date_envoi
            // 
            this.date_envoi.Caption = "Envoy?le";
            this.date_envoi.ColumnName = "date_envoi";
            // 
            // date_remise
            // 
            this.date_remise.Caption = "Remis le";
            this.date_remise.ColumnName = "date_remise";
            // 
            // reference
            // 
            this.reference.AllowDBNull = false;
            this.reference.Caption = "Référence";
            this.reference.ColumnName = "reference";
            // 
            // lignes
            // 
            this.lignes.Caption = "Lignes";
            this.lignes.ColumnName = "lignes";
            this.lignes.DataType = typeof(short);
            // 
            // exemplaires
            // 
            this.exemplaires.Caption = "Exemplaires";
            this.exemplaires.ColumnName = "exemplaires";
            this.exemplaires.DataType = typeof(short);
            // 
            // url_ref
            // 
            this.url_ref.Caption = "Référence URL";
            this.url_ref.ColumnName = "url_ref";
            // 
            // isSelected
            // 
            this.isSelected.AllowDBNull = false;
            this.isSelected.Caption = "Oui";
            this.isSelected.ColumnName = "isSelected";
            this.isSelected.DataType = typeof(bool);
            this.isSelected.DefaultValue = false;
            // 
            // MainTabs
            // 
            this.MainTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabs.Controls.Add(this.RapidInfoTab);
            this.MainTabs.Controls.Add(this.CommandesTab);
            this.MainTabs.Controls.Add(this.ConfigTab);
            this.MainTabs.Controls.Add(this.NavigoTab);
            this.MainTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTabs.Location = new System.Drawing.Point(0, 0);
            this.MainTabs.Margin = new System.Windows.Forms.Padding(0);
            this.MainTabs.Name = "MainTabs";
            this.MainTabs.SelectedIndex = 0;
            this.MainTabs.Size = new System.Drawing.Size(976, 728);
            this.MainTabs.TabIndex = 0;
            // 
            // RapidInfoTab
            // 
            this.RapidInfoTab.Controls.Add(this.EanAdditionalColumnsGridView);
            this.RapidInfoTab.Controls.Add(this.deleteEanButton);
            this.RapidInfoTab.Controls.Add(this.EanExportProgressBar);
            this.RapidInfoTab.Controls.Add(this.EanExportCSVButton);
            this.RapidInfoTab.Controls.Add(this.AddingPanelLabel);
            this.RapidInfoTab.Controls.Add(this.importEanButton);
            this.RapidInfoTab.Controls.Add(this.EanListGridView);
            this.RapidInfoTab.Location = new System.Drawing.Point(4, 33);
            this.RapidInfoTab.Name = "RapidInfoTab";
            this.RapidInfoTab.Size = new System.Drawing.Size(968, 691);
            this.RapidInfoTab.TabIndex = 6;
            this.RapidInfoTab.Text = "Rapid\'Info";
            this.RapidInfoTab.UseVisualStyleBackColor = true;
            // 
            // EanAdditionalColumnsGridView
            // 
            this.EanAdditionalColumnsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EanAdditionalColumnsGridView.AutoGenerateColumns = false;
            this.EanAdditionalColumnsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EanAdditionalColumnsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNameDataGridViewTextBoxColumn,
            this.colFormulaDataGridViewTextBoxColumn,
            this.colEnabledDataGridViewCheckBoxColumn});
            this.EanAdditionalColumnsGridView.DataMember = "AdditionalColumns";
            this.EanAdditionalColumnsGridView.DataSource = this.EanAdditionalFieldsDS;
            this.EanAdditionalColumnsGridView.Location = new System.Drawing.Point(292, 122);
            this.EanAdditionalColumnsGridView.Name = "EanAdditionalColumnsGridView";
            this.EanAdditionalColumnsGridView.Size = new System.Drawing.Size(652, 297);
            this.EanAdditionalColumnsGridView.TabIndex = 10;
            this.EanAdditionalColumnsGridView.Validated += new System.EventHandler(this.dataGridView1_Validated);
            // 
            // colNameDataGridViewTextBoxColumn
            // 
            this.colNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNameDataGridViewTextBoxColumn.DataPropertyName = "ColName";
            this.colNameDataGridViewTextBoxColumn.HeaderText = "Nom";
            this.colNameDataGridViewTextBoxColumn.Name = "colNameDataGridViewTextBoxColumn";
            this.colNameDataGridViewTextBoxColumn.Width = 76;
            // 
            // colFormulaDataGridViewTextBoxColumn
            // 
            this.colFormulaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFormulaDataGridViewTextBoxColumn.DataPropertyName = "ColFormula";
            this.colFormulaDataGridViewTextBoxColumn.HeaderText = "Formule";
            this.colFormulaDataGridViewTextBoxColumn.Name = "colFormulaDataGridViewTextBoxColumn";
            this.colFormulaDataGridViewTextBoxColumn.Width = 106;
            // 
            // colEnabledDataGridViewCheckBoxColumn
            // 
            this.colEnabledDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEnabledDataGridViewCheckBoxColumn.DataPropertyName = "ColEnabled";
            this.colEnabledDataGridViewCheckBoxColumn.HeaderText = "Inclure";
            this.colEnabledDataGridViewCheckBoxColumn.Name = "colEnabledDataGridViewCheckBoxColumn";
            this.colEnabledDataGridViewCheckBoxColumn.Width = 73;
            // 
            // EanAdditionalFieldsDS
            // 
            this.EanAdditionalFieldsDS.DataSetName = "EanAdditionalFieldsDS";
            this.EanAdditionalFieldsDS.Locale = new System.Globalization.CultureInfo("en-US");
            this.EanAdditionalFieldsDS.Tables.AddRange(new System.Data.DataTable[] {
            this.AdditionalColumnsTable});
            // 
            // AdditionalColumnsTable
            // 
            this.AdditionalColumnsTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.ColName,
            this.ColFormula,
            this.ColEnabled});
            this.AdditionalColumnsTable.TableName = "AdditionalColumns";
            // 
            // ColName
            // 
            this.ColName.AllowDBNull = false;
            this.ColName.Caption = "Nom";
            this.ColName.ColumnName = "ColName";
            // 
            // ColFormula
            // 
            this.ColFormula.Caption = "Formule";
            this.ColFormula.ColumnName = "ColFormula";
            // 
            // ColEnabled
            // 
            this.ColEnabled.Caption = "Inclure";
            this.ColEnabled.ColumnName = "ColEnabled";
            this.ColEnabled.DataType = typeof(bool);
            // 
            // deleteEanButton
            // 
            this.deleteEanButton.Location = new System.Drawing.Point(17, 45);
            this.deleteEanButton.Name = "deleteEanButton";
            this.deleteEanButton.Size = new System.Drawing.Size(248, 32);
            this.deleteEanButton.TabIndex = 9;
            this.deleteEanButton.Text = "Effacer tous les codes EAN";
            this.deleteEanButton.UseVisualStyleBackColor = true;
            this.deleteEanButton.Click += new System.EventHandler(this.deleteEanButton_Click);
            // 
            // EanExportProgressBar
            // 
            this.EanExportProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EanExportProgressBar.Location = new System.Drawing.Point(476, 45);
            this.EanExportProgressBar.Name = "EanExportProgressBar";
            this.EanExportProgressBar.Size = new System.Drawing.Size(469, 23);
            this.EanExportProgressBar.TabIndex = 8;
            // 
            // EanExportCSVButton
            // 
            this.EanExportCSVButton.Location = new System.Drawing.Point(562, 5);
            this.EanExportCSVButton.Name = "EanExportCSVButton";
            this.EanExportCSVButton.Size = new System.Drawing.Size(199, 34);
            this.EanExportCSVButton.TabIndex = 7;
            this.EanExportCSVButton.Text = "Exporter en CSV";
            this.EanExportCSVButton.UseVisualStyleBackColor = true;
            this.EanExportCSVButton.Click += new System.EventHandler(this.EanExportCSVButton_Click);
            // 
            // AddingPanelLabel
            // 
            this.AddingPanelLabel.AutoSize = true;
            this.AddingPanelLabel.Location = new System.Drawing.Point(288, 89);
            this.AddingPanelLabel.Name = "AddingPanelLabel";
            this.AddingPanelLabel.Size = new System.Drawing.Size(345, 24);
            this.AddingPanelLabel.TabIndex = 4;
            this.AddingPanelLabel.Text = "Colonnes suppl¨¦mentaires pour l\'export";
            // 
            // importEanButton
            // 
            this.importEanButton.Location = new System.Drawing.Point(17, 4);
            this.importEanButton.Name = "importEanButton";
            this.importEanButton.Size = new System.Drawing.Size(248, 35);
            this.importEanButton.TabIndex = 1;
            this.importEanButton.Text = "Importer Fichiers EAN";
            this.importEanButton.UseVisualStyleBackColor = true;
            this.importEanButton.Click += new System.EventHandler(this.importEanButton_Click);
            // 
            // EanListGridView
            // 
            this.EanListGridView.AllowUserToOrderColumns = true;
            this.EanListGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.EanListGridView.AutoGenerateColumns = false;
            this.EanListGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.EanListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EanListGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eanCodeDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewCheckBoxColumn1,
            this.isEanSelectedDataGridViewCheckBoxColumn});
            this.EanListGridView.DataMember = "EanList";
            this.EanListGridView.DataSource = this.EanListDS;
            this.EanListGridView.Location = new System.Drawing.Point(17, 83);
            this.EanListGridView.Name = "EanListGridView";
            this.EanListGridView.Size = new System.Drawing.Size(248, 447);
            this.EanListGridView.TabIndex = 0;
            this.EanListGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.EanListGridView_RowValidating);
            this.EanListGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // eanCodeDataGridViewTextBoxColumn
            // 
            this.eanCodeDataGridViewTextBoxColumn.DataPropertyName = "EanCode";
            this.eanCodeDataGridViewTextBoxColumn.HeaderText = "EanCode";
            this.eanCodeDataGridViewTextBoxColumn.Name = "eanCodeDataGridViewTextBoxColumn";
            this.eanCodeDataGridViewTextBoxColumn.Visible = false;
            this.eanCodeDataGridViewTextBoxColumn.Width = 115;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "EanCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Code EAN";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 13;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 126;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "isEanSelected";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Oui";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 46;
            // 
            // isEanSelectedDataGridViewCheckBoxColumn
            // 
            this.isEanSelectedDataGridViewCheckBoxColumn.DataPropertyName = "isEanSelected";
            this.isEanSelectedDataGridViewCheckBoxColumn.HeaderText = "isEanSelected";
            this.isEanSelectedDataGridViewCheckBoxColumn.Name = "isEanSelectedDataGridViewCheckBoxColumn";
            this.isEanSelectedDataGridViewCheckBoxColumn.Visible = false;
            this.isEanSelectedDataGridViewCheckBoxColumn.Width = 137;
            // 
            // EanListDS
            // 
            this.EanListDS.DataSetName = "EanListDS";
            this.EanListDS.Tables.AddRange(new System.Data.DataTable[] {
            this.EanList});
            // 
            // EanList
            // 
            this.EanList.Columns.AddRange(new System.Data.DataColumn[] {
            this.EanCode,
            this.isEanSelected});
            this.EanList.TableName = "EanList";
            // 
            // EanCode
            // 
            this.EanCode.AllowDBNull = false;
            this.EanCode.Caption = "Code EAN";
            this.EanCode.ColumnName = "EanCode";
            this.EanCode.DefaultValue = "";
            this.EanCode.MaxLength = 13;
            // 
            // isEanSelected
            // 
            this.isEanSelected.Caption = "Oui";
            this.isEanSelected.ColumnName = "isEanSelected";
            this.isEanSelected.DataType = typeof(bool);
            this.isEanSelected.DefaultValue = true;
            // 
            // CommandesTab
            // 
            this.CommandesTab.AutoScroll = true;
            this.CommandesTab.Controls.Add(this.ExportCsvButton);
            this.CommandesTab.Controls.Add(this.OrdersExportProgressBar);
            this.CommandesTab.Controls.Add(this.CommandsCount);
            this.CommandesTab.Controls.Add(this.OrdersGridView);
            this.CommandesTab.Controls.Add(this.panel1);
            this.CommandesTab.Location = new System.Drawing.Point(4, 33);
            this.CommandesTab.Name = "CommandesTab";
            this.CommandesTab.Padding = new System.Windows.Forms.Padding(3);
            this.CommandesTab.Size = new System.Drawing.Size(968, 691);
            this.CommandesTab.TabIndex = 2;
            this.CommandesTab.Text = "Commandes";
            this.CommandesTab.UseVisualStyleBackColor = true;
            // 
            // ExportCsvButton
            // 
            this.ExportCsvButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportCsvButton.Location = new System.Drawing.Point(833, 0);
            this.ExportCsvButton.Name = "ExportCsvButton";
            this.ExportCsvButton.Size = new System.Drawing.Size(120, 29);
            this.ExportCsvButton.TabIndex = 7;
            this.ExportCsvButton.Text = "Export CSV";
            this.ExportCsvButton.UseVisualStyleBackColor = true;
            this.ExportCsvButton.Click += new System.EventHandler(this.ExportCsvButton_Click);
            // 
            // OrdersExportProgressBar
            // 
            this.OrdersExportProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OrdersExportProgressBar.Location = new System.Drawing.Point(683, 31);
            this.OrdersExportProgressBar.Name = "OrdersExportProgressBar";
            this.OrdersExportProgressBar.Size = new System.Drawing.Size(270, 23);
            this.OrdersExportProgressBar.TabIndex = 6;
            // 
            // CommandsCount
            // 
            this.CommandsCount.Location = new System.Drawing.Point(342, 15);
            this.CommandsCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.CommandsCount.Name = "CommandsCount";
            this.CommandsCount.Size = new System.Drawing.Size(68, 29);
            this.CommandsCount.TabIndex = 3;
            this.CommandsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CommandsCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.CommandsCount.Leave += new System.EventHandler(this.CommandsCount_Leave);
            // 
            // OrdersGridView
            // 
            this.OrdersGridView.AllowUserToAddRows = false;
            this.OrdersGridView.AllowUserToDeleteRows = false;
            this.OrdersGridView.AllowUserToOrderColumns = true;
            this.OrdersGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OrdersGridView.AutoGenerateColumns = false;
            this.OrdersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.OrdersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.destinataireCol,
            this.date_remiseCol,
            this.date_envoiCol,
            this.referenceCol,
            this.lignesCol,
            this.exemplairesCol,
            this.url_refCol,
            this.isSelectedCol,
            this.destinataireDataGridViewTextBoxColumn,
            this.dateenvoiDataGridViewTextBoxColumn,
            this.dateremiseDataGridViewTextBoxColumn,
            this.referenceDataGridViewTextBoxColumn,
            this.lignesDataGridViewTextBoxColumn,
            this.exemplairesDataGridViewTextBoxColumn,
            this.urlrefDataGridViewTextBoxColumn,
            this.isSelectedDataGridViewCheckBoxColumn});
            this.OrdersGridView.DataMember = "commande";
            this.OrdersGridView.DataSource = this.OrdersListDS;
            this.OrdersGridView.Location = new System.Drawing.Point(16, 56);
            this.OrdersGridView.Name = "OrdersGridView";
            this.OrdersGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.OrdersGridView.Size = new System.Drawing.Size(937, 474);
            this.OrdersGridView.TabIndex = 1;
            // 
            // destinataireCol
            // 
            this.destinataireCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.destinataireCol.DataPropertyName = "destinataire";
            this.destinataireCol.HeaderText = "Destinataire";
            this.destinataireCol.Name = "destinataireCol";
            this.destinataireCol.Width = 132;
            // 
            // date_remiseCol
            // 
            this.date_remiseCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.date_remiseCol.DataPropertyName = "date_remise";
            this.date_remiseCol.HeaderText = "Remis le";
            this.date_remiseCol.Name = "date_remiseCol";
            this.date_remiseCol.Width = 108;
            // 
            // date_envoiCol
            // 
            this.date_envoiCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.date_envoiCol.DataPropertyName = "date_envoi";
            this.date_envoiCol.HeaderText = "Envoy¨¦ le";
            this.date_envoiCol.Name = "date_envoiCol";
            this.date_envoiCol.Width = 119;
            // 
            // referenceCol
            // 
            this.referenceCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.referenceCol.DataPropertyName = "reference";
            this.referenceCol.HeaderText = "R¨¦f.";
            this.referenceCol.Name = "referenceCol";
            this.referenceCol.Width = 68;
            // 
            // lignesCol
            // 
            this.lignesCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.lignesCol.DataPropertyName = "lignes";
            this.lignesCol.HeaderText = "Lignes";
            this.lignesCol.Name = "lignesCol";
            this.lignesCol.Width = 91;
            // 
            // exemplairesCol
            // 
            this.exemplairesCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.exemplairesCol.DataPropertyName = "exemplaires";
            this.exemplairesCol.HeaderText = "Ex.";
            this.exemplairesCol.Name = "exemplairesCol";
            this.exemplairesCol.Width = 63;
            // 
            // url_refCol
            // 
            this.url_refCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.url_refCol.DataPropertyName = "url_ref";
            this.url_refCol.HeaderText = "url_ref";
            this.url_refCol.Name = "url_refCol";
            this.url_refCol.Visible = false;
            // 
            // isSelectedCol
            // 
            this.isSelectedCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.isSelectedCol.DataPropertyName = "isSelected";
            this.isSelectedCol.FalseValue = "false";
            this.isSelectedCol.HeaderText = "Oui";
            this.isSelectedCol.IndeterminateValue = "false";
            this.isSelectedCol.Name = "isSelectedCol";
            this.isSelectedCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isSelectedCol.TrueValue = "true";
            this.isSelectedCol.Width = 65;
            // 
            // destinataireDataGridViewTextBoxColumn
            // 
            this.destinataireDataGridViewTextBoxColumn.DataPropertyName = "destinataire";
            this.destinataireDataGridViewTextBoxColumn.HeaderText = "destinataire";
            this.destinataireDataGridViewTextBoxColumn.Name = "destinataireDataGridViewTextBoxColumn";
            this.destinataireDataGridViewTextBoxColumn.Visible = false;
            this.destinataireDataGridViewTextBoxColumn.Width = 130;
            // 
            // dateenvoiDataGridViewTextBoxColumn
            // 
            this.dateenvoiDataGridViewTextBoxColumn.DataPropertyName = "date_envoi";
            this.dateenvoiDataGridViewTextBoxColumn.HeaderText = "date_envoi";
            this.dateenvoiDataGridViewTextBoxColumn.Name = "dateenvoiDataGridViewTextBoxColumn";
            this.dateenvoiDataGridViewTextBoxColumn.Visible = false;
            this.dateenvoiDataGridViewTextBoxColumn.Width = 127;
            // 
            // dateremiseDataGridViewTextBoxColumn
            // 
            this.dateremiseDataGridViewTextBoxColumn.DataPropertyName = "date_remise";
            this.dateremiseDataGridViewTextBoxColumn.HeaderText = "date_remise";
            this.dateremiseDataGridViewTextBoxColumn.Name = "dateremiseDataGridViewTextBoxColumn";
            this.dateremiseDataGridViewTextBoxColumn.Visible = false;
            this.dateremiseDataGridViewTextBoxColumn.Width = 138;
            // 
            // referenceDataGridViewTextBoxColumn
            // 
            this.referenceDataGridViewTextBoxColumn.DataPropertyName = "reference";
            this.referenceDataGridViewTextBoxColumn.HeaderText = "reference";
            this.referenceDataGridViewTextBoxColumn.Name = "referenceDataGridViewTextBoxColumn";
            this.referenceDataGridViewTextBoxColumn.Visible = false;
            this.referenceDataGridViewTextBoxColumn.Width = 116;
            // 
            // lignesDataGridViewTextBoxColumn
            // 
            this.lignesDataGridViewTextBoxColumn.DataPropertyName = "lignes";
            this.lignesDataGridViewTextBoxColumn.HeaderText = "lignes";
            this.lignesDataGridViewTextBoxColumn.Name = "lignesDataGridViewTextBoxColumn";
            this.lignesDataGridViewTextBoxColumn.Visible = false;
            this.lignesDataGridViewTextBoxColumn.Width = 85;
            // 
            // exemplairesDataGridViewTextBoxColumn
            // 
            this.exemplairesDataGridViewTextBoxColumn.DataPropertyName = "exemplaires";
            this.exemplairesDataGridViewTextBoxColumn.HeaderText = "exemplaires";
            this.exemplairesDataGridViewTextBoxColumn.Name = "exemplairesDataGridViewTextBoxColumn";
            this.exemplairesDataGridViewTextBoxColumn.Visible = false;
            this.exemplairesDataGridViewTextBoxColumn.Width = 138;
            // 
            // urlrefDataGridViewTextBoxColumn
            // 
            this.urlrefDataGridViewTextBoxColumn.DataPropertyName = "url_ref";
            this.urlrefDataGridViewTextBoxColumn.HeaderText = "url_ref";
            this.urlrefDataGridViewTextBoxColumn.Name = "urlrefDataGridViewTextBoxColumn";
            this.urlrefDataGridViewTextBoxColumn.Visible = false;
            this.urlrefDataGridViewTextBoxColumn.Width = 87;
            // 
            // isSelectedDataGridViewCheckBoxColumn
            // 
            this.isSelectedDataGridViewCheckBoxColumn.DataPropertyName = "isSelected";
            this.isSelectedDataGridViewCheckBoxColumn.HeaderText = "isSelected";
            this.isSelectedDataGridViewCheckBoxColumn.Name = "isSelectedDataGridViewCheckBoxColumn";
            this.isSelectedDataGridViewCheckBoxColumn.Visible = false;
            this.isSelectedDataGridViewCheckBoxColumn.Width = 103;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.RefreshCommandsButton);
            this.panel1.Location = new System.Drawing.Point(16, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 41);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "com.";
            // 
            // RefreshCommandsButton
            // 
            this.RefreshCommandsButton.Location = new System.Drawing.Point(8, 5);
            this.RefreshCommandsButton.Name = "RefreshCommandsButton";
            this.RefreshCommandsButton.Size = new System.Drawing.Size(311, 29);
            this.RefreshCommandsButton.TabIndex = 0;
            this.RefreshCommandsButton.Text = "Rafraichir la Liste des Commandes";
            this.RefreshCommandsButton.UseVisualStyleBackColor = true;
            this.RefreshCommandsButton.Click += new System.EventHandler(this.RefreshCommandsButton_Click);
            // 
            // ConfigTab
            // 
            this.ConfigTab.Controls.Add(this.label8);
            this.ConfigTab.Controls.Add(this.timeoutSelector);
            this.ConfigTab.Controls.Add(this.label7);
            this.ConfigTab.Controls.Add(this.textCsvReplacement);
            this.ConfigTab.Controls.Add(this.label6);
            this.ConfigTab.Controls.Add(this.textCsvSeparator);
            this.ConfigTab.Controls.Add(this.label5);
            this.ConfigTab.Controls.Add(this.textWebBaseUrl);
            this.ConfigTab.Controls.Add(this.textPassword);
            this.ConfigTab.Controls.Add(this.textLogin);
            this.ConfigTab.Controls.Add(this.label4);
            this.ConfigTab.Controls.Add(this.label3);
            this.ConfigTab.Controls.Add(this.label1);
            this.ConfigTab.Location = new System.Drawing.Point(4, 33);
            this.ConfigTab.Name = "ConfigTab";
            this.ConfigTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigTab.Size = new System.Drawing.Size(968, 691);
            this.ConfigTab.TabIndex = 5;
            this.ConfigTab.Text = "Config";
            this.ConfigTab.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(492, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "secondes";
            // 
            // timeoutSelector
            // 
            this.timeoutSelector.Location = new System.Drawing.Point(440, 186);
            this.timeoutSelector.Name = "timeoutSelector";
            this.timeoutSelector.Size = new System.Drawing.Size(55, 29);
            this.timeoutSelector.TabIndex = 7;
            this.timeoutSelector.Leave += new System.EventHandler(this.saveSettings);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(408, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "D¨¦lai avant de retenter une connexion inactive :";
            // 
            // textCsvReplacement
            // 
            this.textCsvReplacement.Location = new System.Drawing.Point(352, 140);
            this.textCsvReplacement.Name = "textCsvReplacement";
            this.textCsvReplacement.Size = new System.Drawing.Size(30, 29);
            this.textCsvReplacement.TabIndex = 5;
            this.textCsvReplacement.Leave += new System.EventHandler(this.saveSettings);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Remplacer par:";
            // 
            // textCsvSeparator
            // 
            this.textCsvSeparator.Location = new System.Drawing.Point(182, 140);
            this.textCsvSeparator.Name = "textCsvSeparator";
            this.textCsvSeparator.Size = new System.Drawing.Size(30, 29);
            this.textCsvSeparator.TabIndex = 5;
            this.textCsvSeparator.Leave += new System.EventHandler(this.saveSettings);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "S¨¦parateur CSV:";
            // 
            // textWebBaseUrl
            // 
            this.textWebBaseUrl.Location = new System.Drawing.Point(224, 93);
            this.textWebBaseUrl.Name = "textWebBaseUrl";
            this.textWebBaseUrl.Size = new System.Drawing.Size(383, 29);
            this.textWebBaseUrl.TabIndex = 3;
            this.textWebBaseUrl.Leave += new System.EventHandler(this.saveSettings);
            this.textWebBaseUrl.Validating += new System.ComponentModel.CancelEventHandler(this.textWebBaseUrl_Validating);
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(164, 55);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(189, 29);
            this.textPassword.TabIndex = 3;
            this.textPassword.UseSystemPasswordChar = true;
            this.textPassword.Leave += new System.EventHandler(this.saveSettings);
            // 
            // textLogin
            // 
            this.textLogin.Location = new System.Drawing.Point(164, 14);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(189, 29);
            this.textLogin.TabIndex = 2;
            this.textLogin.Leave += new System.EventHandler(this.saveSettings);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Adresse site Dilicom :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mot de passe :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code d\'acc¨¨s :";
            // 
            // saveCsvFile
            // 
            this.saveCsvFile.FileName = "commandes.csv";
            this.saveCsvFile.InitialDirectory = ".\\export";
            // 
            // openEanFile
            // 
            this.openEanFile.FileName = "*.*";
            this.openEanFile.InitialDirectory = ".";
            this.openEanFile.Multiselect = true;
            // 
            // NavigoTab
            // 
            this.NavigoTab.Controls.Add(this.UrlText);
            this.NavigoTab.Controls.Add(this.GoButton);
            this.NavigoTab.Controls.Add(this.MyWebBrowser);
            this.NavigoTab.Location = new System.Drawing.Point(4, 33);
            this.NavigoTab.Name = "NavigoTab";
            this.NavigoTab.Size = new System.Drawing.Size(968, 691);
            this.NavigoTab.TabIndex = 7;
            this.NavigoTab.Text = "Navigo";
            this.NavigoTab.UseVisualStyleBackColor = true;
            // 
            // MyWebBrowser
            // 
            this.MyWebBrowser.Location = new System.Drawing.Point(0, 39);
            this.MyWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.MyWebBrowser.Name = "MyWebBrowser";
            this.MyWebBrowser.Size = new System.Drawing.Size(968, 491);
            this.MyWebBrowser.TabIndex = 0;
            this.MyWebBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.MyWebBrowser_Navigating);
            this.MyWebBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.MyWebBrowser_Navigated);
            // 
            // GoButton
            // 
            this.GoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GoButton.Location = new System.Drawing.Point(863, 4);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(75, 29);
            this.GoButton.TabIndex = 1;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // UrlText
            // 
            this.UrlText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UrlText.Location = new System.Drawing.Point(4, 4);
            this.UrlText.Name = "UrlText";
            this.UrlText.Size = new System.Drawing.Size(853, 29);
            this.UrlText.TabIndex = 2;
            // 
            // DilicomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 566);
            this.Controls.Add(this.MainTabs);
            this.Name = "DilicomForm";
            this.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.Text = "Aide Dilicom";
            this.Load += new System.EventHandler(this.ApplicationLoad);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ApplicationClosed);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersListDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commande)).EndInit();
            this.MainTabs.ResumeLayout(false);
            this.RapidInfoTab.ResumeLayout(false);
            this.RapidInfoTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EanAdditionalColumnsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EanAdditionalFieldsDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdditionalColumnsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EanListGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EanListDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EanList)).EndInit();
            this.CommandesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CommandsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ConfigTab.ResumeLayout(false);
            this.ConfigTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutSelector)).EndInit();
            this.NavigoTab.ResumeLayout(false);
            this.NavigoTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabs;
        private System.Windows.Forms.TabPage CommandesTab;
        private System.Windows.Forms.TabPage ConfigTab;
        private System.Windows.Forms.Button RefreshCommandsButton;
        private System.Data.DataTable commande;
        private System.Data.DataColumn destinataire;
        private System.Data.DataColumn date_envoi;
        private System.Data.DataColumn date_remise;
        private System.Data.DataColumn reference;
        private System.Data.DataColumn lignes;
        private System.Data.DataColumn exemplaires;
        private System.Data.DataColumn url_ref;
        private System.Windows.Forms.NumericUpDown CommandsCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Data.DataSet OrdersListDS;
        private System.Windows.Forms.DataGridView OrdersGridView;
        private System.Data.DataColumn isSelected;
        private System.Windows.Forms.ProgressBar OrdersExportProgressBar;
        private System.Windows.Forms.Button ExportCsvButton;
        private System.Windows.Forms.SaveFileDialog saveCsvFile;
        private System.Windows.Forms.TabPage RapidInfoTab;
        private System.Data.DataSet EanListDS;
        private System.Data.DataTable EanList;
        private System.Data.DataColumn EanCode;
        private System.Data.DataColumn isEanSelected;
        private System.Windows.Forms.DataGridView EanListGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn eanCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEanSelectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button importEanButton;
        private System.Windows.Forms.OpenFileDialog openEanFile;
        private System.Windows.Forms.Label AddingPanelLabel;
        private System.Windows.Forms.Button EanExportCSVButton;
        private System.Windows.Forms.ProgressBar EanExportProgressBar;
        private System.Windows.Forms.Button deleteEanButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinataireCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_remiseCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_envoiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn lignesCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn exemplairesCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn url_refCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelectedCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinataireDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateenvoiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateremiseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lignesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exemplairesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlrefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textWebBaseUrl;
        private System.Windows.Forms.Label label4;
        private System.Data.DataSet EanAdditionalFieldsDS;
        private System.Data.DataTable AdditionalColumnsTable;
        private System.Data.DataColumn ColName;
        private System.Data.DataColumn ColFormula;
        private System.Data.DataColumn ColEnabled;
        private System.Windows.Forms.DataGridView EanAdditionalColumnsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.TextBox textCsvReplacement;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textCsvSeparator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown timeoutSelector;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage NavigoTab;
        private System.Windows.Forms.WebBrowser MyWebBrowser;
        private System.Windows.Forms.TextBox UrlText;
        private System.Windows.Forms.Button GoButton;
    }
}

