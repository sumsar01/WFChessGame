using System.Drawing;
using System.Windows.Forms;
using WFChessGame.Models;
using System;
using System.Diagnostics;

namespace WFChessGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DisplayBoard();
            Board.ValueChanged += UpdateSquare;
        }

        private void tableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
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


        public void UpdateSquare(object sender, EventArgs e)
        {
            // Rendering whole board when one move is made is inefficient. Refactor to something smarter.
            DisplayBoard();
        }

        private int _oldLocation = -1;
        private int _pieceHolder;
        private int _newLocation;
        private void label_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            // If no piece is selected select it, if square is empty do nothing
            // else move the piece and reset click
            if (_oldLocation == -1)
            {
                _oldLocation = label.TabIndex;
                _pieceHolder = Board.getSquare(_oldLocation);
                if(_pieceHolder == 0)
                {
                    _oldLocation = -1;
                }
            }
            else
            {
                _newLocation = label.TabIndex;
                Board.setSquare(_newLocation, _pieceHolder);
                Board.setSquare(_oldLocation, 0);
                _oldLocation = -1;
            }
        }
    }
}
