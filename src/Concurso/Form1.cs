using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concurso
{
    public partial class Form1 : Form
    {
        List<AfiliadosGoogle> GSheetList = new List<AfiliadosGoogle>();
        List<Afiliados> DataModelList = new List<Afiliados>();
        List<AfiliadosGoogle> validatedList = new List<AfiliadosGoogle>();

        public Form1()
        {
            InitializeComponent();
        }

        private void safeInvoke(Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }

        private void setLabelTextSafe(Label lbl, string txt)
        {
            if (lbl.InvokeRequired)
                lbl.Invoke(new Action(() => lbl.Text = txt));
            else
                lbl.Text = txt;
        }

        private void setEnableButton(Button btn, bool value)
        {
            if (btn.InvokeRequired)
                btn.Invoke(new Action(() => btn.Enabled = value));
            else
                btn.Enabled = value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ExcelController excel = new ExcelController(System.IO.Directory.GetCurrentDirectory() + "\\DataModel\\AFILIADOS TITULARES AL 21-07-2021.xlsx");
            //string result = JsonController.SerializeObjectToJson(excel.GetList());

            var gSheets = new GSheetsController();
            var task = Task.Run(() =>
            {
                GSheetList = gSheets.getAllAfiliados().Result;
                safeInvoke(gSheetLabel, new Action(() => gSheetLabel.Text = $"{GSheetList.Count}"));
                safeInvoke(validateButton, new Action(() => validateButton.Enabled = true));
            });
            DataModelList = JsonController.Deserialize(System.IO.Directory.GetCurrentDirectory() + "\\DataModel\\DataModel.json");
            safeInvoke(excelDataModelLabel, new Action(() => excelDataModelLabel.Text = $"{DataModelList.Count}"));
        }

        private void gSheetLabel_TextChanged(object sender, EventArgs e)
        {
            setColorToLabel(gSheetLabel);
        }

        void setColorToLabel(Label lbl)
        {
            if (lbl.Text.Contains("Afiliado") || lbl.Text.Count(i => char.IsDigit(i)) == lbl.Text.Length)
                lbl.ForeColor = Color.LimeGreen;
            else if (lbl.Text.Contains("Error"))
                lbl.ForeColor = Color.Red;
            else
                lbl.ForeColor = Color.Black;
        }

        private void excelDataModelLabel_TextChanged(object sender, EventArgs e)
        {
            setColorToLabel(excelDataModelLabel);
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            var validator = new Validator(DataModelList, GSheetList);
            validatedList = Task.Run(() =>
            {
                var result = validator.ValidateAll();
                MessageBox.Show($"Validación completada con {result.Result.Count} participantes");
                return result;
            }).Result;
            setColorToLabel(labelParticipantes);
            safeInvoke(labelParticipantes, new Action(() => labelParticipantes.Text = validatedList.Count.ToString()));
            randomButton.Enabled = true;
            validateButton.Enabled = false;
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            if (validatedList.Count > 0)
            {
                Random ran = new Random();
                int index = ran.Next(0, validatedList.Count - 1);
                Form2 frm = new Form2(validatedList[index], this);
                validatedList.RemoveAt(index);
                safeInvoke(labelParticipantes, new Action(() => labelParticipantes.Text = validatedList.Count.ToString()));
                frm.Show();
                Hide();
            }
            else
                MessageBox.Show("No hay participantes para elegir");
        }
    }
}
