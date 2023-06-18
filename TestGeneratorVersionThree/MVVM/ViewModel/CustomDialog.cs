using System.Windows;
using System.Windows.Controls;

public class CustomDialog : Window
{
    public string NazwaTestu { get; private set; }

    private TextBox nazwaTestuTextBox;
    private Button okButton;
    private Button cancelButton;

    public CustomDialog(string message)
    {
        Title = "Potwierdzenie usunięcia";
        Width = 300;
        Height = 200;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        ResizeMode = ResizeMode.NoResize;
        WindowStyle = WindowStyle.ToolWindow;
        ShowInTaskbar = false;

        StackPanel mainPanel = new StackPanel();

        Label messageLabel = new Label()
        {
            Content = message,
            Margin = new Thickness(10),
            HorizontalAlignment = HorizontalAlignment.Center
        };
        mainPanel.Children.Add(messageLabel);

        nazwaTestuTextBox = new TextBox()
        {
            Margin = new Thickness(10),
            HorizontalAlignment = HorizontalAlignment.Center,
            MinWidth = 200
        };
        mainPanel.Children.Add(nazwaTestuTextBox);

        StackPanel buttonPanel = new StackPanel()
        {
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Center,
            Margin = new Thickness(10)
        };

        okButton = new Button()
        {
            Content = "OK",
            Width = 75,
            Margin = new Thickness(5),
            IsDefault = true
        };
        okButton.Click += OkButton_Click;
        buttonPanel.Children.Add(okButton);

        cancelButton = new Button()
        {
            Content = "Anuluj",
            Width = 75,
            Margin = new Thickness(5),
            IsCancel = true
        };
        cancelButton.Click += CancelButton_Click;
        buttonPanel.Children.Add(cancelButton);

        mainPanel.Children.Add(buttonPanel);

        Content = mainPanel;
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        NazwaTestu = nazwaTestuTextBox.Text;
        DialogResult = true;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}