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
using TestGeneratorVersionThree.MVVM.ViewModel;

namespace TestGeneratorVersionThree.MVVM.View
{
    /// <summary>
    /// Interaction logic for AddCategoryView.xaml
    /// </summary>
    public partial class AddCategoryView : Window
    {
        public AddCategoryView()
        {
            InitializeComponent();
            DataContext = new AddCategoryViewModel();
        }
    }
}
