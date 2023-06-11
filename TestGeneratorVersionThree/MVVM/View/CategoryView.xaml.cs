using System.Windows.Controls;
using TestGeneratorVersionThree.MVVM.ViewModel;

namespace TestGeneratorVersionThree.MVVM.View
{

    public partial class CategoryView : UserControl
    {
        public CategoryView()
        {
            InitializeComponent();
            DataContext = new CategoryViewModel();
        }
    }
}
