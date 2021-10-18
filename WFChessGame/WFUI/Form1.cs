using System.Drawing;
using System.Windows.Forms;
using WFChessGame.Models;

namespace WFChessGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DisplayBoard();

        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if ((e.Column + e.Row) % 2 == 1)
                e.Graphics.FillRectangle(Brushes.Peru, e.CellBounds);
            else
                e.Graphics.FillRectangle(Brushes.Moccasin, e.CellBounds);
        }

        private void DisplayBoard()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    Image i = Image.FromFile(Board.GetPieceImg(iconLabel.TabIndex));
                    i = (Image)(new Bitmap(i, new Size(64, 64)));
                    iconLabel.Image = i;
                    iconLabel.BackColor = System.Drawing.Color.Transparent;

                }
            }
        }

        private void label1_DragEnter(object sender, DragEventArgs e)
        {
            // As we are interested in Image data only
            // we will check this as follows
            if (e.Data.GetDataPresent(typeof(int)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            //we will pass the data that user wants to drag
            //DoDragDrop method is used for holding data
            //DoDragDrop accepts two paramete first paramter 
            //is data(image,file,text etc) and second paramter 
            //specify either user wants to copy the data or move data

            Label source = (Label)sender;
            DoDragDrop(Board.Square[source.TabIndex],
                       DragDropEffects.Copy);
        }

        private void label1_DragDrop(object sender, DragEventArgs e)
        {
            //target control will accept data here 
            Label destination = (Label)sender;
            Board.Square[destination.TabIndex] = (int)e.Data.GetData(typeof(int));
        }
    }
}
