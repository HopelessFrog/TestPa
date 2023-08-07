namespace Task.Services.Interfaces
{
    public interface IDialogService
    {
        System.Threading.Tasks.Task ShowAlertAsync(string message, string title);
    }
}