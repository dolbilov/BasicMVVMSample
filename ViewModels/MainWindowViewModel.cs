using System;
using ReactiveUI;

namespace BasicMVVMSample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    #region Fields

    private string? _name;

    #endregion
    
    
    public MainWindowViewModel()
    {
        this.WhenAnyValue(vm => vm.Name)
            .Subscribe(_ => this.RaisePropertyChanged(nameof(Greeting)));
    }

    
    #region Properties

    public string? Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string Greeting => $"Hello, {(string.IsNullOrEmpty(Name) ? "anonymous" : Name)}";

    #endregion
}