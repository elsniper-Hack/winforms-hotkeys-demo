using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Pierogi
{
    public class MainForm : Form
    {
        private PictureBox pictureBox;
        private Random rand = new Random();

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        private const int WM_HOTKEY = 0x0312;

        public MainForm()
        {
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0;

            pictureBox = new PictureBox();
            pictureBox.Image = Image.FromStream(
                System.Reflection.Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("Pierogi.pierogi.gif")
            );

            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            this.Controls.Add(pictureBox);

            // Registrar hotkeys
            RegisterHotKey(this.Handle, 1, 0, (uint)Keys.A);
            RegisterHotKey(this.Handle, 2, 0, (uint)Keys.F);
            RegisterHotKey(this.Handle, 3, 0, (uint)Keys.S);
            RegisterHotKey(this.Handle, 4, 0, (uint)Keys.J);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                ShowGifRandom();
            }

            base.WndProc(ref m);
        }

        private void ShowGifRandom()
        {
            Form gifForm = new Form();

            gifForm.FormBorderStyle = FormBorderStyle.None;
            gifForm.StartPosition = FormStartPosition.Manual;
            gifForm.ShowInTaskbar = false;
            gifForm.TopMost = true;
            gifForm.BackColor = Color.Magenta;
            gifForm.TransparencyKey = Color.Magenta;

            PictureBox pb = new PictureBox();
            pb.Image = pictureBox.Image;
            pb.SizeMode = PictureBoxSizeMode.AutoSize;

            gifForm.Controls.Add(pb);

            int x = rand.Next(Screen.PrimaryScreen.Bounds.Width - pb.Width);
            int y = rand.Next(Screen.PrimaryScreen.Bounds.Height - pb.Height);

            gifForm.Location = new Point(x, y);
            gifForm.ClientSize = pb.Size;

            gifForm.Show();

            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += (s, e) =>
            {
                gifForm.Close();
                timer.Stop();
            };

            timer.Start();
        }
    }
}
