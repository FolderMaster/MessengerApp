using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Model;
using Model.Connections;
using System.Collections.Generic;

using View.Views;

using ViewModel.ViewModels;
using ViewModel.ViewModels.Pages;

namespace View;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var connection = new InternalConnection();
        var chat = new ChatManager(connection);
        var user = new User(connection);
        var pages = new List<PageViewModel>()
        {
            new UserViewModel(new PageMetadata("User", GetResource("PersonIcon")), user),
            new ContactsViewModel(new PageMetadata("Chat", GetResource("ConnectionIcon")), user, chat)
        };
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(pages)
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel(pages)
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private object? GetResource(object key)
    {
        TryGetResource(key, ActualThemeVariant, out var result);
        return result;
    }
}
