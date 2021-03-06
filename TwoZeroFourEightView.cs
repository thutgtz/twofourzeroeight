﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;


        public TwoZeroFourEightView()
        {

            InitializeComponent();
            TextBox tb = new TextBox();
            this.Controls.Add(tb); // keyboard controll
            tb.KeyDown += new KeyEventHandler(Form1_KeyDown);
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        public void Notify(Model m)
        {
            label1.Text = Convert.ToString(((TwoZeroFourEightModel)m).score);
            label5.Text = UpdateBoardscore(((TwoZeroFourEightModel)m).GetBoard());
            UpdateBoard(((TwoZeroFourEightModel)m).GetBoard());
            label6.Hide();

            if (!((TwoZeroFourEightModel)m).isnotFull())
            {
                if (((TwoZeroFourEightModel)m).isOver())
                {
                    label6.Show();
                    label6.Text = "                GAME OVER !! \n  Press SPACE to continue.. \n        Your SCORE is "+label1.Text;  
                }
            }
        }

        private void UpdateTile(Label l, int i)
        {
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
            }
            else
            {
                l.Text = "";
            }
            switch (i)
            {
                case 0:
                    l.BackColor = Color.DimGray;
                    break;
                case 2:
                    l.BackColor = Color.Gray;
                    break;
                case 4:
                    l.BackColor = Color.DarkGray;
                    break;
                case 8:
                    l.BackColor = Color.Yellow;
                    break;
                case 16:
                    l.BackColor = Color.Orange;
                    break;
                case 32:
                    l.BackColor = Color.DarkOrange;
                    break;
                case 64:
                    l.BackColor = Color.OrangeRed;
                    break;
                case 128:
                    l.BackColor = Color.Red;
                    break;
                case 256:
                    l.BackColor = Color.DarkRed;
                    break;
                case 512:
                    l.BackColor = Color.GreenYellow;
                    break;
                case 1024:
                    l.BackColor = Color.Green;
                    break;
                default:
                    l.BackColor = Color.ForestGreen;
                    break;
            }
        }
        private void UpdateBoard(int[,] board)
        {
            UpdateTile(lbl00, board[0, 0]);
            UpdateTile(lbl01, board[0, 1]);
            UpdateTile(lbl02, board[0, 2]);
            UpdateTile(lbl03, board[0, 3]);
            UpdateTile(lbl10, board[1, 0]);
            UpdateTile(lbl11, board[1, 1]);
            UpdateTile(lbl12, board[1, 2]);
            UpdateTile(lbl13, board[1, 3]);
            UpdateTile(lbl20, board[2, 0]);
            UpdateTile(lbl21, board[2, 1]);
            UpdateTile(lbl22, board[2, 2]);
            UpdateTile(lbl23, board[2, 3]);
            UpdateTile(lbl30, board[3, 0]);
            UpdateTile(lbl31, board[3, 1]);
            UpdateTile(lbl32, board[3, 2]);
            UpdateTile(lbl33, board[3, 3]);

        }

        private string UpdateBoardscore(int[,] board)
        {
            int score = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    score += board[i, j];
                }
            }
            return score.ToString();


        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.UP);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.DOWN);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // F key
        {

            if (e.KeyCode == Keys.Right) controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
            if (e.KeyCode == Keys.Left) controller.ActionPerformed(TwoZeroFourEightController.LEFT);
            if (e.KeyCode == Keys.Up) controller.ActionPerformed(TwoZeroFourEightController.UP);
            if (e.KeyCode == Keys.Down) controller.ActionPerformed(TwoZeroFourEightController.DOWN);
            if (!((TwoZeroFourEightModel)model).isnotFull())
            {
                if (((TwoZeroFourEightModel)model).isOver())
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        resetALL();
                    }

                }
            }

        }

        private void resetALL()
        {
            label6.Hide();
            ((TwoZeroFourEightModel)model).resetAll();
            UpdateBoard(((TwoZeroFourEightModel)model).GetBoard());
            label1.Text = Convert.ToString(((TwoZeroFourEightModel)model).score);
            label5.Text = UpdateBoardscore(((TwoZeroFourEightModel)model).GetBoard());
        }



        private void button1_Click(object sender, EventArgs e)
        {
            resetALL();
        }

        
    }
}
