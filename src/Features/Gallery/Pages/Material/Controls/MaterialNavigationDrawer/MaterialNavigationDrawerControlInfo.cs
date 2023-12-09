using IconPacks.Material;
using Material.Components.Maui;

namespace MAUIsland;
class MaterialNavigationDrawerControlInfo : IMaterialUIGalleryCardInfo
{
    public string ControlName => nameof(NavigationDrawer);
    public string ControlRoute => typeof(MaterialNavigationDrawerPage).FullName;
    public IconKind MaterialIcon => IconKind.Menu;
    public List<PlatformInfo> SupportedPlatformsInfo => new() { new() { Id = "1", Name = "Android", Logo = "androidlogo.png" },
                                                                new() { Id = "2", Name = "IOS", Logo = "ioslogo.png" },
                                                                new() { Id = "3", Name = "Windows", Logo = "windowslogo.png"} };
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_navigation_24_regular
    };
    public string ControlDetail => "Navigation drawers provide ergonomic access to destinations in an app.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Material/MaterialNavigationDrawer";
    public string DocumentUrl => $"https://mdc-maui.github.io/navigation-drawer";
    public string GroupName => ControlGroupInfo.MaterialComponent;

    public GalleryCardType CardType => GalleryCardType.Control;

    public GalleryCardStatus CardStatus => throw new NotImplementedException();

    public DateTime LastUpdate => throw new NotImplementedException();

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}