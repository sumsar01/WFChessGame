using System;
using System.Drawing;
using System.Windows.Forms;
using WFChessGame.Engine.Models;
using System.Collections.Generic;

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
                Label label = control as Label;
                if (label != null)
                {
                    Image i = Image.FromFile(Board.GetPieceImg(label.TabIndex));
                    i = (Image)(new Bitmap(i, new Size(64, 64)));
                    label.Image = i;
                    label.BackColor = System.Drawing.Color.Transparent;

                }
            }
        }

        private void ShowPossibleMoves(int location)
        {
            int piece = Board.GetSquare(location);
            List<int> moves = Turn.GetLegalMoves(piece, location);

            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label label = control as Label;
                if(label != null)
                {
                    if(moves.Contains(label.TabIndex))
                    {
                        label.BackColor = Color.FromArgb(128, 204, 0, 0);
                    }
                    if (location == label.TabIndex)
                    {
                        label.BackColor = Color.FromArgb(200, 255, 128, 0);
                    }
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
            List<int> moves = Turn.GetLegalMoves(_pieceHolder, _oldLocation);
            // If no piece is selected select it, if square is empty do nothing
            // else move the piece and reset click
            if (_oldLocation == -1)
            {
                _oldLocation = label.TabIndex;
                _pieceHolder = Board.GetSquare(_oldLocation);
                bool isTurn = BooleanChecks.CheckTurn(_pieceHolder);

                if (isTurn == false)
                {
                    _oldLocation = -1;
                    return;
                }

                ShowPossibleMoves(_oldLocation);
                if (_pieceHolder == 0)
                {
                    _oldLocation = -1;
                    DisplayBoard();
                }
            }
            else if(moves.Contains(label.TabIndex))
            {
                _newLocation = label.TabIndex;
                Turn.MakeMove(_newLocation, _oldLocation);
                _oldLocation = -1;
            }
            else
            {
                _oldLocation = -1;
                DisplayBoard();
            }
        }
    }
}
