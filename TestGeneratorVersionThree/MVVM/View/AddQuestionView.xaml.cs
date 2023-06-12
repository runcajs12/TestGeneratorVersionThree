using System;
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
    /// Interaction logic for AddQuestionView.xaml
    /// </summary>
    public partial class AddQuestionView : Window
    {
        public AddQuestionView()
        {
            InitializeComponent();
            
            DataContext = new AddQuestionViewModel();
            
        }

        public AddQuestionView(int id)
        {
            InitializeComponent();
            DataContext = new AddQuestionViewModel(id);
           
            
        }

        public void xDPozdro() { }
    }
}
