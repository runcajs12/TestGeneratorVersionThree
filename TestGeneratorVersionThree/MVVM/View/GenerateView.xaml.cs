﻿using System.Windows.Controls;
using TestGeneratorVersionThree.MVVM.ViewModel;

namespace TestGeneratorVersionThree.MVVM.View;

public partial class GenerateView 
{
    public GenerateView()
    {
        InitializeComponent();
        DataContext = new GenerateViewModel();
    }
}