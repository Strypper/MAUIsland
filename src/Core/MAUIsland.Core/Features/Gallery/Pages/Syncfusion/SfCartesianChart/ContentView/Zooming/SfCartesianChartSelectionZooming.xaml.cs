namespace MAUIsland.Core;

public partial class SfCartesianChartSelectionZooming : ContentView
{
    #region [ CTor ]
    public SfCartesianChartSelectionZooming()
    {
        InitializeComponent();
        Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty FirstScatterComponentDataProperty = BindableProperty.Create(
        nameof(FirstScatterComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartSelectionZooming),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty SecondScatterComponentDataProperty = BindableProperty.Create(
        nameof(SecondScatterComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartSelectionZooming),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty CodeDescriptionProperty = BindableProperty.Create(
        nameof(CodeDescription),
        typeof(string),
        typeof(SfCartesianChartSelectionZooming),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> FirstScatterComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(FirstScatterComponentDataProperty);
        set => SetValue(FirstScatterComponentDataProperty, value);
    }

    public ObservableCollection<SfCartesianChartModel> SecondScatterComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(SecondScatterComponentDataProperty);
        set => SetValue(SecondScatterComponentDataProperty, value);
    }

    public string CodeDescription
    {
        get => (string)GetValue(CodeDescriptionProperty);
        set => SetValue(CodeDescriptionProperty, value);
    }
    #endregion

    #region [ Events ]
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var selectionRectangleProperties = (string[])Resources["SelectionRectangleProperties"];
        SelectionRectangleCollectionView.ItemsSource = selectionRectangleProperties;

        var trackballAxisLabelProperties = (string[])Resources["TrackballAxisLabelProperties"];
        TrackballAxisCollectionView.ItemsSource = trackballAxisLabelProperties;
    }

    private async void OnGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (ArrowImage.Rotation == 0)
        {
            await ArrowImage.RotateTo(90);
            Info.IsVisible = true;
        }
        else
        {
            await ArrowImage.RotateTo(0);
            Info.IsVisible = false;
        }
    }
    #endregion
}