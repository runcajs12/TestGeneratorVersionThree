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
    /// Interaction logic for EditQuestionView.xaml
    /// </summary>
    public partial class EditQuestionView : Window
    {
        public EditQuestionView()
        {
            InitializeComponent();
            DataContext = new EditQuestionViewModel();
        }

        public EditQuestionView(int _id)
        {
            InitializeComponent();
            DataContext = new EditQuestionViewModel(_id);

        }
    }
}
