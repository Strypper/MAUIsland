﻿using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class EntryPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public EntryPageViewModel(IAppNavigator appNavigator,
                              IGitHubService gitHubService)
                                : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ControlIssueModel> controlIssues;

    [ObservableProperty]
    ControlIssueModel selectedControlIssue;

    [ObservableProperty]
    ObservableCollection<ChatMessageModel> messages;

    [ObservableProperty]
    string standardEntryXamlCode = "<Entry x:Name=\"Entry\"\r\n                               Placeholder=\"Enter text here\"\r\n                               PlaceholderColor=\"LightSlateGray\"\r\n                               HorizontalTextAlignment=\"Start\"\r\n                               VerticalTextAlignment=\"Center\"/> ";

    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

        Messages = new();
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await RefreshAsync();
    }

    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    Task SendMessage(string message)
    {
        Messages.Add(new ChatMessageModel()
        {
            AuthorName = "MAUIsland",
            AuthorImage = "dotnet_bot.png",
            ChatMessageContent = message,
            SentTime = DateTime.Now
        });

        return Task.CompletedTask;
    }

    [RelayCommand]
    async Task RefreshAsync()
    {
        await RefreshControlIssues(true);
    }
    #endregion

    #region [ Methods ]

    async Task RefreshControlIssues(bool forced)
    {
        if (IsBusy)
            return;

        IsBusy = true;

        var items = await gitHubService.GetGitHubIssuesByLabels(ControlInformation.GitHubAuthorIssueName,
                                                                ControlInformation.GitHubRepositoryIssueName,
                                                                ControlInformation.GitHubIssueLabels);


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
    }
    #endregion
}
