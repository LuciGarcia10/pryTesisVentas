using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace pryTesisVentas
{
    internal class PanelRedondeado : Panel
    {
        public int RadioBorde { get; set; } = 30;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Usamos un bloque using para liberar recursos de memoria
            using (GraphicsPath path = new GraphicsPath())
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Definimos los arcos de las esquinas
                path.AddArc(0, 0, RadioBorde, RadioBorde, 180, 90);
                path.AddArc(Width - RadioBorde, 0, RadioBorde, RadioBorde, 270, 90);
                path.AddArc(Width - RadioBorde, Height - RadioBorde, RadioBorde, RadioBorde, 0, 90);
                path.AddArc(0, Height - RadioBorde, RadioBorde, RadioBorde, 90, 90);
                path.CloseAllFigures();

                this.Region = new Region(path);
            }
        }

    }
}
