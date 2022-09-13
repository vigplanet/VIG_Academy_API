using GrapeCity.ActiveReports.Design;
using System;
using GrapeCity.ActiveReports.Export.Pdf.Page;
using GrapeCity.ActiveReports.Rendering.IO;
using GrapeCity.ActiveReports;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveXTestEndUser
{
    public partial class Form1 : Form
    {
        Stack<Func<object>> undoStack = new Stack<Func<object>>();
        Stack<Func<object>> redoStack = new Stack<Func<object>>();
        public Form1()
        {
            InitializeComponent();
            designer1.Toolbox = toolbox;
            designer1.ActiveTabChanged += designer_ActiveTabChanged;
            //designer1.ReportExplorer = reportExplorer1;
            //designer1.LayerList = layerList1;
        }
        void designer_ActiveTabChanged(object sender, EventArgs e)
        {
            exportToolStripMenuItem.Enabled = designer1.ActiveTab == DesignerTab.Preview && designer1.ReportType != DesignerReportType.Section;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                designer1.LoadReport(new System.IO.FileInfo(openFileDialog.FileName));
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = GetSaveFilter();
            var dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                designer1.SaveReport(new System.IO.FileInfo(saveFileDialog.FileName));
            }
        }
        private string GetSaveFilter()
        {
            switch (designer1.ReportType)
            {
                case DesignerReportType.Section:
                    return "Section Report Files (*.cs)|*.cs";
                case DesignerReportType.Page:
                    return "Page Report Files (*.rdlx)|*.rdlx";
                case DesignerReportType.Rdl:
                    return "RDL Report Files (*.rdlx)|*.rdlx";
                default:
                    return "RDL Report Files (*.rdlx)|*.rdlx";
            }
        }

        private void sectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            designer1.NewReport(DesignerReportType.Section);
        }

        private void pageReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            designer1.NewReport(DesignerReportType.Page);
        }

        private void rdlReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            designer1.NewReport(DesignerReportType.Rdl);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pdf (*.pdf)|*.pdf";
            var dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                var pdfRe = new PdfRenderingExtension();
                var msp = new MemoryStreamProvider();
                (designer1.Report as PageReport).Document.Render(pdfRe, msp);
                using (var stream = msp.GetPrimaryStream().OpenStream())
                using (var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }
                MessageBox.Show("Export is done");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            //System.IO.Stream st = asm.GetManifestResourceStream(Application.StartupPath+"\\SectionReport2.rpx");
            //System.IO.Stream st1=Application.StartupPath
            designer1.LoadReport(new System.IO.FileInfo(@"C:\Users\main\Desktop\CRCustomised\ACCOUNTS\Default Formats\Credit Note Voucher\Credit Note Voucher.rpx"));
            //designer1.LoadReport(new System.IO.FileInfo(@"C:\Users\main\source\repos\ActiveXTestEndUser\ActiveXTestEndUser\SectionReport2.rpx"));
            //System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(st);
            //designer1.LoadReport(reader, DesignerReportType.Section);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.U && ModifierKeys == Keys.Control)
            {
                if (undoStack.Count > 0)
                {
                    //StackPush(sender, redoStack);
                    undoStack.Pop()();
                }
            }
            else if (e.KeyCode == Keys.R && ModifierKeys == Keys.Control)
            {
                if (redoStack.Count > 0)
                {
                    //StackPush(sender, undoStack);
                    redoStack.Pop()();
                }
            }
        }
    }
}
