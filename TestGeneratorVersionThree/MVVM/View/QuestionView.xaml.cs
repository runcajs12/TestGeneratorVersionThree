using System.Windows.Controls;
using TestGeneratorVersionThree.MVVM.ViewModel;

namespace TestGeneratorVersionThree.MVVM.View;

public partial class QuestionView : UserControl
{
    public QuestionView()
    {
        InitializeComponent();
        DataContext = new QuestionViewModel();
    }
}