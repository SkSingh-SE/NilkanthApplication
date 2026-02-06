
namespace NilkanthApplication
{
    partial class ReportTrip
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnCancel = new System.Windows.Forms.Button();
            this.TripReportData_Select3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TripReportData_Select3TableAdapter = new NilkanthApplication.TripDataSet3TableAdapters.TripReportData_Select3TableAdapter();
            this.tripDataSet31 = new NilkanthApplication.TripDataSet3();
            ((System.ComponentModel.ISupportInitialize)(this.TripReportData_Select3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tripDataSet31)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoScroll = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NilkanthApplication.MultipalTrip.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1431, 1055);
            this.reportViewer1.TabIndex = 0;
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
            // TripReportData_Select3TableAdapter
            // 
            this.TripReportData_Select3TableAdapter.ClearBeforeFill = true;
            // 
            // tripDataSet31
            // 
            this.tripDataSet31.DataSetName = "TripDataSet3";
            this.tripDataSet31.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportTrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1432, 1055);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReportTrip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportTrip";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportTrip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TripReportData_Select3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tripDataSet31)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
       
        private System.Windows.Forms.BindingSource TripReportData_Select3BindingSource;
       
        private TripDataSet3TableAdapters.TripReportData_Select3TableAdapter TripReportData_Select3TableAdapter;
        private System.Windows.Forms.Button btnCancel;
        private TripDataSet3 tripDataSet31;
    }
}