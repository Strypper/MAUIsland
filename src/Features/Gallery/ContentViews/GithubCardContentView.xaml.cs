using System.ComponentModel;
using System.Runtime.CompilerServices;
using Octokit;

namespace MAUIsland;

public partial class GithubCardContentView : ContentView
{
    #region [ Fields ]
    private string  repositoryUrl;
    private string  authorAvatar;
    private int     stars;
    private int     forks;
    //private int     issues;
    private string  license;
    private List<PlatformInfo> supportedPlatformsInfo;
    #endregion

    #region [ CTor ]
    public GithubCardContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Delegates ]
    public delegate void DetailEventHandler(IGithubGalleryCardInfo control);

    public delegate void DetailInNewWindowEventHandler(IGithubGalleryCardInfo control);
    #endregion

    #region [ Events ]
    public event DetailEventHandler DetailClicked;

    public event DetailInNewWindowEventHandler DetailInNewWindowClicked;

    public event PropertyChangedEventHandler GithubCardPropertyChanged;
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(IGithubGalleryCardInfo),
        typeof(GithubCardContentView),
        default(IGithubGalleryCardInfo)
    );

    public static readonly BindableProperty IssuesProperty = BindableProperty.Create(
        nameof(Issues),
        typeof(int),
        typeof(GithubCardContentView),
        default(int)
    );

    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    #endregion

    #region [ Properties ]
    public IGithubGalleryCardInfo ComponentData
    {
        get => (IGithubGalleryCardInfo)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public string RepositoryUrl
    {
        get => repositoryUrl;
        set => GithubCardSetProperty(ref repositoryUrl, value);
    }

    public string AuthorAvatar
    {
        get => authorAvatar;
        set => GithubCardSetProperty(ref authorAvatar, value);
    }

    public int Stars
    {
        get => stars;
        set => GithubCardPropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Stars"));
    }

    public int Forks
    {
        get => forks;
        set => GithubCardSetProperty(ref forks, value);
    }

    public int Issues
    {
        get => (int)GetValue(IssuesProperty);
        set => SetValue(IssuesProperty, value);
    }

    public string License
    {
        get => license;
        set => GithubCardSetProperty(ref license, value);
    }

    public List<PlatformInfo> SupportedPlatformsInfo
    {
        get => supportedPlatformsInfo;
        set => GithubCardSetProperty(ref supportedPlatformsInfo, value);
    }
    #endregion

    #region [ Event Handlers ]
    private void Detail_Clicked(object sender, EventArgs e)
        => DetailClicked?.Invoke(ComponentData);

    private void DetailInNewWindow_Clicked(object sender, EventArgs e)
        => DetailInNewWindowClicked?.Invoke(ComponentData);

    private void RaiseGithubCardPropertyChanged(string propertyName)
        => GithubCardPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private void root_Loaded(object sender, EventArgs e)
        => SyncRepoAsync().FireAndForget();
    #endregion

    #region [ Generic Methods ]
    protected bool GithubCardSetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(property, value))
        {
            return false;
        }

        property = value;
        RaiseGithubCardPropertyChanged(propertyName);
        return true;
    }
    #endregion

    #region [ Methods ]
    public async Task SyncRepoAsync()
    {
        var github = new GitHubClient(new ProductHeaderValue(ComponentData.RepositoryName));
        var repository = await github.Repository.Get(ComponentData.AuthorName, ComponentData.RepositoryName);

        this.RepositoryUrl = repository.Url;
        this.Stars = repository.StargazersCount;
        this.Forks = repository.ForksCount;
        this.Issues = repository.OpenIssuesCount;
        //this.License = repository.License.ToString();
    }
    #endregion
}