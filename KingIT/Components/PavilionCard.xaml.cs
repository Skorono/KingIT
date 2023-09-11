﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KingIT.Interfaces;

namespace KingIT.Components
{
    /// <summary>
    /// Логика взаимодействия для PavilionCard.xaml
    /// </summary>
    public partial class PavilionCard : UserControl
    {
        public int FloorNumber { get; set; }
        public string Number { get; set; } = null!;
        public float Square { get; set; }
        public float AddedCoefficient { get; set; }
        public int Cost { get; set; }

        public PavilionCard()
        {
            InitializeComponent();
        }

        void SetProperty(string property)
        {
            
        }
    }
}
