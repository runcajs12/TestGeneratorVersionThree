using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestGeneratorVersionThree.Core;

public class ObservableObject : INotifyPropertyChanged  
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}