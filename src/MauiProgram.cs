﻿using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Refit;
using Syncfusion.Maui.Core.Hosting;
using System.Reflection;

namespace MAUIsland;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("FluentSystemIcons-Regular.ttf", FontNames.FluentSystemIconsRegular);
            })
            .ConfigureEssentials(essentials =>
            {
                essentials.UseVersionTracking();
            })
            .RegisterServices()
            .RegisterPages()
            .RegisterControlInfos()
            .RegisterPopups()
            .RegisterRefitApi();


        builder.ConfigureSyncfusionCore();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

#if __ANDROID__
    public static void PrependToMappingImageSource(IImageHandler handler, Microsoft.Maui.IImage image)
    {
        //handler.PlatformView?.Clear();
    }
#endif

    static MauiAppBuilder RegisterPopups(this MauiAppBuilder builder)
    {
        builder.Services.AddPopup<AuthenticatePopup, AuthenticatePopupViewModel>(AppRoutes.SignUp);
        return builder;
    }

    static MauiAppBuilder RegisterRefitApi(this MauiAppBuilder builder)
    {
        builder.Services.AddRefitClient<ITotechsIdentityAuthentication>()
                        .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://totechsidentityprovider.azurewebsites.net/api"));
        return builder;
    }

    static MauiAppBuilder RegisterControlInfos(this MauiAppBuilder builder)
    {
        var assemblies = new Assembly[] { typeof(IControlInfo).Assembly };
        var controlInfoTypes = assemblies
            .SelectMany(
                a => a
                    .GetTypes()
                    .Where(a => !a.IsAbstract && !a.IsInterface && a.IsAssignableTo(typeof(IControlInfo))));

        foreach (var controlInfoType in controlInfoTypes)
        {
            builder.Services.AddSingleton(typeof(IControlInfo), controlInfoType);
        }
        return builder;
    }

    static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IFilePicker, FilePicker>();
        builder.Services.AddSingleton<IHomeService, HomeService>();
        builder.Services.AddSingleton<IAppNavigator, AppNavigator>();
        builder.Services.AddSingleton<IUserServices, BogusUserServices>();
        builder.Services.AddSingleton<IControlsService, ControlsService>();
        builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();
        builder.Services.AddSingleton<IAuthenticationServices, BogusAuthenticationService>();

        builder.Services.AddSingleton<IAppInfo>(AppInfo.Current);
        builder.Services.AddSingleton<IFolderPicker>(FolderPicker.Default);
        return builder;
    }

    static MauiAppBuilder RegisterPages(this MauiAppBuilder builder, string pattern = "Page")
    {
        var assemblies = new Assembly[] { typeof(MauiProgram).Assembly };
        var pageTypes = assemblies.SelectMany(a => a.GetTypes().Where(a => a.Name.EndsWith(pattern) && !a.IsAbstract && !a.IsInterface));
        foreach (var pageType in pageTypes)
        {
            var viewModelFullName = $"{pageType.FullName}ViewModel";
            var viewModelType = Type.GetType(viewModelFullName);

            builder.Services.AddTransient(pageType);

            if (viewModelType != null)
                builder.Services.AddTransient(viewModelType);

            if (pageType.IsAssignableTo(typeof(IControlPage)))
            {
                Routing.RegisterRoute(pageType.FullName, pageType);
            }
        }

        return builder;
    }

    static IServiceCollection AddPopup<TPopup, TViewModel>(this IServiceCollection services, string name)
    where TPopup : BasePopup where TViewModel : BaseViewModel
    {
        Routing.RegisterRoute(name, typeof(TPopup));
        services.AddTransient<TPopup>();
        services.AddTransient<TViewModel>();
        return services;
    }
}
