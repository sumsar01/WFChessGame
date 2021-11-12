using System;
using System.Drawing;
using System.Windows.Forms;
using WFChessGame.Engine.Models;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;

namespace WFChessGame
{
    public partial class Form1 : Form
    {
        GameSession gameSession;
        public Form1(GameSession gameSession)
        {
            InitializeComponent();
            DisplayBoard(gameSession);
            gameSession.board.ValueChanged += UpdateSquare;
        }

        private void tableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if ((e.Column + e.Row) % 2 == 1)
                e.Graphics.FillRectangle(Brushes.Peru, e.CellBounds);
            else
                e.Graphics.FillRectangle(Brushes.Moccasin, e.CellBounds);
        }

        private void DisplayBoard(GameSession gameSession)
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label label = control as Label;
                if (label != null)
                {
                    Image i = Image.FromFile(gameSession.board.GetPieceImg(label.TabIndex));
                    i = (Image)(new Bitmap(i, new Size(64, 64)));
                    label.Image = i;
                    label.BackColor = System.Drawing.Color.Transparent;

                }
            }
        }

        private void ShowPossibleMoves(int location, Board board)
        {
            int piece = board.GetSquare(location);
            List<int> moves = Engine.Models.Moves.GetLegalMoves(piece, location, board);

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
            // Rendering whole board when one move is inefficient. Refactor to something smarter.
            DisplayBoard(gameSession);
        }

        private int _oldLocation = -1;
        private int _pieceHolder;
        private int _newLocation;
        private void label_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            List<int> moves = Engine.Models.Moves.GetLegalMoves(_pieceHolder, _oldLocation, gameSession.board);
            // If no piece is selected select it, if square is empty do nothing
            // else move the piece and reset click
            if (_oldLocation == -1)
            {
                _oldLocation = label.TabIndex;
                _pieceHolder = gameSession.board.GetSquare(_oldLocation);
                bool isTurn = BooleanChecks.CheckTurn(_pieceHolder, gameSession.board);

                if (isTurn == false)
                {
                    _oldLocation = -1;
                    return;
                }

                ShowPossibleMoves(_oldLocation, gameSession.board);
                if (_pieceHolder == 0)
                {
                    _oldLocation = -1;
                    DisplayBoard(gameSession);
                }
            }
            else if(moves.Contains(label.TabIndex))
            {
                _newLocation = label.TabIndex;
                Engine.Models.Moves.MakeMove(_newLocation, _oldLocation, gameSession.board);
                _oldLocation = -1;
            }
            else
            {
                _oldLocation = -1;
                DisplayBoard(gameSession);
            }
        }
    }
}
