using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Pierogi
{
    public class PierogiForm : Form
    {
        public PierogiForm()
        {
            this.Width = 300;
            this.Height = 300;

            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;

            // POSICIÓN ALEATORIA
            Random rnd = new Random();

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int x = rnd.Next(0, screenWidth - this.Width);
            int y = rnd.Next(0, screenHeight - this.Height);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);

            // PictureBox
            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // Cargar GIF embebido
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Pierogi.pierogi.gif";

            Stream stream = assembly.GetManifestResourceStream(resourceName);

            MemoryStream ms = new MemoryStream();
            stream.CopyTo(ms);
            ms.Position = 0;

            pictureBox.Image = Image.FromStream(ms);

            this.Controls.Add(pictureBox);
        }
    }
}
