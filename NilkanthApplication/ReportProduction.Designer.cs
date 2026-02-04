
namespace NilkanthApplication
{
    partial class ReportProduction
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ProductReportData_SelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProductionDataSet = new NilkanthApplication.ProductionDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ProductReportData_SelectTableAdapter = new NilkanthApplication.ProductionDataSetTableAdapters.ProductReportData_SelectTableAdapter();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProductReportData_SelectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductionDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductReportData_SelectBindingSource
            // 
            this.ProductReportData_SelectBindingSource.DataMember = "ProductReportData_Select";
            this.ProductReportData_SelectBindingSource.DataSource = this.ProductionDataSet;
            // 
            // ProductionDataSet
            // 
            this.ProductionDataSet.DataSetName = "ProductionDataSet";
            this.ProductionDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "ProductionDS";
            reportDataSource3.Value = this.ProductReportData_SelectBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NilkanthApplication.Production.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1432, 1053);
            this.reportViewer1.TabIndex = 0;
            // 
            // ProductReportData_SelectTableAdapter
            // 
            this.ProductReportData_SelectTableAdapter.ClearBeforeFill = true;
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1320, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 34);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ReportProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1432, 1055);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportProduction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportProduction";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportProduction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductReportData_SelectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductionDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProductReportData_SelectBindingSource;
        private ProductionDataSet ProductionDataSet;
        private ProductionDataSetTableAdapters.ProductReportData_SelectTableAdapter ProductReportData_SelectTableAdapter;
        private System.Windows.Forms.Button btnCancel;
    }
}