using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TestGeneratorVersionThree.Core;
using TestGeneratorVersionThree.MVVM.Model;
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
            var addQuestionViewModel = new AddQuestionViewModel();

            addQuestionViewModel.QuestionAdded += CloseAddQuestionView;

            DataContext = addQuestionViewModel;

            //DataContext = new AddQuestionViewModel();  
        }
        private void CloseAddQuestionView(object sender, EventArgs e)
        {
            // Zamknij okno
            this.Close();
        }
   
        public AddQuestionView(int id)
        {
            InitializeComponent();
            DataContext = new AddQuestionViewModel(id);
            
        }

    }
}
