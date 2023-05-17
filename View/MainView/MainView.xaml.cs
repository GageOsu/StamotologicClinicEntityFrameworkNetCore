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
using System.Windows.Shapes;

namespace StamotologicClinic.View.MainView
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>

    
    public partial class MainView : Window
    {
        public static ListView AllMedicalPersonnelsView;
        public MainView()
        {
            InitializeComponent();

            AllMedicalPersonnelsView = ViewAllMedicalPersonnels;
        }
    }
}