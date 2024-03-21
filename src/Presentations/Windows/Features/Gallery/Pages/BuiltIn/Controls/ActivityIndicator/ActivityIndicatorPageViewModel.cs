﻿using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class ActivityIndicatorPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public ActivityIndicatorPageViewModel(IAppNavigator appNavigator,
                                          IGitHubService gitHubService)
                                                : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ControlIssueModel> controlIssues;

    [ObservableProperty]
    ControlIssueModel selectedControlIssue;

    [ObservableProperty]
    string groupOfActivityIndicators =
    "<HorizontalStackLayout HorizontalOptions=\"Start\" Spacing=\"10\">\r\n" +
    "    <ActivityIndicator IsRunning=\"True\" />\r\n" +
    "\r\n" +
    "    <ActivityIndicator IsRunning=\"True\" Color=\"Green\" />\r\n" +
    "\r\n" +
    "    <ActivityIndicator IsRunning=\"True\" Color=\"Red\" />\r\n" +
    "\r\n" +
    "    <ActivityIndicator IsRunning=\"true\" Color=\"Aqua\" />\r\n" +
    "</HorizontalStackLayout>";


    [ObservableProperty]
    string bindingActivityIndicators =
    "<VerticalStackLayout Spacing=\"5\">\r\n" +
    "    <HorizontalStackLayout Spacing=\"10\">\r\n" +
    "        <Picker\r\n" +
    "            x:Name=\"ActivityIndicatorColorPicker\"\r\n" +
    "            Title=\"Choose Color\"\r\n" +
    "            BackgroundColor=\"#512bd4\"\r\n" +
    "            ItemsSource=\"{x:StaticResource ActivityIndicatorColorResource}\"\r\n" +
    "            VerticalOptions=\"Center\" />\r\n" +
    "        <Switch\r\n" +
    "            x:Name=\"ActivityIndicatorSwitch\"\r\n" +
    "            IsToggled=\"True\"\r\n" +
    "            VerticalOptions=\"End\" />\r\n" +
    "    </HorizontalStackLayout>\r\n" +
    "    <ActivityIndicator\r\n" +
    "        HorizontalOptions=\"Start\"\r\n" +
    "        IsRunning=\"{x:Binding Source={x:Reference ActivityIndicatorSwitch},\r\n" +
    "                              Path=IsToggled}\"\r\n" +
    "        Color=\"{x:Binding Source={x:Reference ActivityIndicatorColorPicker},\r\n" +
    "                          Path=SelectedItem,\r\n" +
    "                          Converter={x:StaticResource StringToColorConverter}}\" />\r\n" +
    "    <core:SourceCodeExpander Code=\"{x:Binding BindingActivityIndicators}\" />\r\n" +
    "</VerticalStackLayout>";

    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        RefreshControlIssues(true)
            .FireAndForget();
    }


    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion

    #region [ Methods ]

    async Task RefreshControlIssues(bool forced)
    {
        if (IsBusy)
            return;

        IsBusy = true;

        var items = await gitHubService.GetGitHubIssuesByLabels("dotnet", "maui", new List<string>() { "control-activityindicator" });

        IsBusy = false;

        if (ControlIssues is null || forced)
            ControlIssues = new(items.Select(x => new ControlIssueModel()
            {
                IssueId = x.Id,
                Title = x.Title,
                IssueLinkUrl = x.HtmlUrl,
                MileStone = x.Milestone is null ? "No mile stone" : x.Milestone.Title,
                OwnerName = x.User.Login,
                AvatarUrl = x.User.AvatarUrl,
                CreatedDate = x.CreatedAt.DateTime,
                LastUpdated = x.UpdatedAt is null ? x.CreatedAt.DateTime : x.UpdatedAt.Value.DateTime
            }));

        //if (CachedItems is null || forced)
        //    CachedItems = new(items);

        //if (Items.Any())
        //    Title = $"Billing statement";
        //else
        //    Title = "All paid up";
    }
    #endregion
}
