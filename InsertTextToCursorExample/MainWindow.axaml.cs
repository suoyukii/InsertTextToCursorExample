using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;

namespace InsertTextToCursorExample;

public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    private async void StartInsert(object sender, TappedEventArgs e)
    {
        text2.Focus();
        await Task.Delay(5000);
        Win32Api.SendUnicode(text1.Text);
    }
}