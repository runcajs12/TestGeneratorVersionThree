using System.ComponentModel;
using System.Linq;
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
    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        var propertyDescriptor = e.PropertyDescriptor as PropertyDescriptor;
        if (propertyDescriptor != null)
        {
            var displayNameAttribute = propertyDescriptor.Attributes.OfType<DisplayNameAttribute>().FirstOrDefault();
            if (displayNameAttribute != null)
            {
                e.Column.Header = displayNameAttribute.DisplayName;
            }
        }
    }

}