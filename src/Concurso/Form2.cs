using Models;
using System;
using System.Windows.Forms;

namespace Concurso
{
    public partial class Form2 : Form
    {
        readonly Afiliados Ganador;
        readonly Form1 Form;
        readonly Timer timer = new Timer();
        int seconds = 0;
        const int maxTime = 10;

        public Form2(Afiliados ganador, Form1 frm)
        {
            InitializeComponent();
            Ganador = ganador;
            Form = frm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            WindowState = FormWindowState.Maximized;
            timer.Interval = 1000;
            timer.Tick += (timer_tick);
            timer.Start();
        }

        void timer_tick(object sender, EventArgs args)
        {
            seconds++;
            if (seconds == maxTime)
            {
                timer.Stop();
                labelGanador.Font = new System.Drawing.Font("Calibri", 24, System.Drawing.FontStyle.Bold);
                labelGanador.Text = Ganador.ToString();
                label1.Text = "Felicitaciones!";
                label1.Font = new System.Drawing.Font("Calibri", 32, System.Drawing.FontStyle.Italic);
                pictureBox1.Visible = false;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form.Show();
            Close();
        }
    }
}
