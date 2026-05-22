namespace EventAccountingSystemUI;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
        Application.Run(new MainForm());
    }
}