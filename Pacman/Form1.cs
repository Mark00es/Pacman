﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GameBoard gameboard = new GameBoard();
            gameboard.CreateBoardImage(this, 1);

            Pacman pacman = new Pacman();
            pacman.CreatePacmanImage(this);


        }
    }
}
