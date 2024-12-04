using Syncfusion.Maui.Data;

namespace MAUIsland.Core;
public partial class SfCartesianChartPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public SfCartesianChartPageViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation = default!;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> persons;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> annotation;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> area;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> rangeArea;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> stackingArea;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> bar;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> rangeBar;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> stackingBar;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> column;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> rangeColumn;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> stackingColumn;

    [ObservableProperty]
    ObservableCollection<string> areaChartOptions;

    [ObservableProperty]
    ObservableCollection<string> barChartOptions;

    [ObservableProperty]
    ObservableCollection<string> columnChartOptions;

    [ObservableProperty]
    string areaSelectedOption;

    [ObservableProperty]
    string columnBarSelectedOption;

    [ObservableProperty]
    ControlGroupInfo controlGroup;

    [ObservableProperty]
    List<Brush> palletBrushes;

    [ObservableProperty]
    bool isBusy;

    #region [ String Properties ]
    [ObservableProperty]
    string basicSfCartesianChartXamlCode =
        "<toolkit:SfCartesianChart>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis>\r\n" +
        "            <toolkit:CategoryAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Name\" TextColor=\"{x:AppThemeBinding Dark={x:StaticResource White}, Light={x:StaticResource Black}}\" />\r\n" +
        "            </toolkit:CategoryAxis.Title>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis>\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                 <toolkit:ChartAxisTitle Text=\"Exp\" TextColor=\"{x:AppThemeBinding Dark={x:StaticResource White}, Light={x:StaticResource Black}}\" />\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:ColumnSeries EnableAnimation=\"True\"\r\n" +
        "                          ItemsSource=\"{x:Binding Persons}\"\r\n" +
        "                          PaletteBrushes=\"{x:Binding PalletBrushes, Mode=OneWay}\"\r\n" +
        "                          SelectionBehavior=\"{x:StaticResource SfCartesianChartSelectionBrush}\"\r\n" +
        "                          XBindingPath=\"Name\"\r\n" +
        "                          YBindingPath=\"Exp\" />\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianAnnotationXamlCode =
        "<toolkit:SfCartesianChart VerticalOptions=\"FillAndExpand\" Margin=\"0,0,5,0\" x:Name=\"Chart\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Annotations Demo\" Margin=\"0,2,0,10\"\r\n" +
        "               HorizontalOptions=\"Center\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"CenterAndExpand\"\r\n" +
        "               FontSize=\"16\" LineBreakMode=\"WordWrap\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"4\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"20\" Maximum=\"70\" Interval=\"10\"/>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Annotations>\r\n" +
        "        <toolkit:VerticalLineAnnotation X1=\"2\" LineCap=\"Arrow\" Text=\"Vertical Line\" Stroke=\"Orange\">\r\n" +
        "            <toolkit:VerticalLineAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle VerticalTextAlignment=\"Start\" HorizontalTextAlignment=\"Start\" FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"Orange\"/>\r\n" +
        "            </toolkit:VerticalLineAnnotation.LabelStyle>\r\n" +
        "        </toolkit:VerticalLineAnnotation>\r\n\r\n" +
        "        <toolkit:HorizontalLineAnnotation Y1=\"45\" LineCap=\"Arrow\" Text=\"Horizontal Line\" Stroke=\"Orange\">\r\n" +
        "            <toolkit:HorizontalLineAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle VerticalTextAlignment=\"Start\" HorizontalTextAlignment=\"End\" FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"Orange\"/>\r\n" +
        "            </toolkit:HorizontalLineAnnotation.LabelStyle>\r\n" +
        "        </toolkit:HorizontalLineAnnotation>\r\n\r\n" +
        "        <toolkit:LineAnnotation X1=\"2.5\" X2=\"3.5\" Y1=\"52\" Y2=\"63\" LineCap=\"Arrow\" Text=\"Random Line\" Stroke=\"Orange\">\r\n" +
        "            <toolkit:LineAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"Orange\"/>\r\n" +
        "            </toolkit:LineAnnotation.LabelStyle>\r\n" +
        "        </toolkit:LineAnnotation>\r\n\r\n" +
        "        <toolkit:RectangleAnnotation X1=\"0.5\" X2=\"1.5\" Y1=\"25\" Y2=\"35\" Text=\"Rectangle\" Stroke=\"Orange\">\r\n" +
        "            <toolkit:RectangleAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"Orange\"/>\r\n" +
        "            </toolkit:RectangleAnnotation.LabelStyle>\r\n" +
        "        </toolkit:RectangleAnnotation>\r\n\r\n" +
        "        <toolkit:EllipseAnnotation X1=\"2.5\" X2=\"3.5\" Y1=\"25\" Y2=\"35\" Text=\"Ellipse\" HorizontalAlignment=\"End\" VerticalAlignment=\"End\" Stroke=\"Orange\">\r\n" +
        "            <toolkit:EllipseAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"Orange\"/>\r\n" +
        "            </toolkit:EllipseAnnotation.LabelStyle>\r\n" +
        "        </toolkit:EllipseAnnotation>\r\n\r\n" +
        "        <toolkit:TextAnnotation X1=\"1\" Y1=\"57.5\" Text=\"Text Annotation\">\r\n" +
        "            <toolkit:TextAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"Orange\"/>\r\n" +
        "            </toolkit:TextAnnotation.LabelStyle>\r\n" +
        "        </toolkit:TextAnnotation>\r\n\r\n" +
        "        <toolkit:ViewAnnotation X1=\"2.15\" Y1=\"35\">\r\n" +
        "            <toolkit:ViewAnnotation.View>\r\n" +
        "                <Image>\r\n" +
        "                    <Image.Source>\r\n" +
        "                        <FontImageSource Glyph=\"{x:Static core:FluentUIIcon.Ic_fluent_data_histogram_24_regular}\" \r\n" +
        "                                            FontFamily=\"{x:Static core:FontNames.FluentSystemIconsRegular}\" \r\n" +
        "                                            Size =\"50\"\r\n" +
        "                                            Color=\"Orange\"/>\r\n" +
        "                    </Image.Source>\r\n" +
        "                </Image>\r\n" +
        "            </toolkit:ViewAnnotation.View>\r\n" +
        "        </toolkit:ViewAnnotation>\r\n" +
        "    </toolkit:SfCartesianChart.Annotations>\r\n\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianAnnotationForDateTimeChartXamlCode =
        "<toolkit:SfCartesianChart VerticalOptions=\"FillAndExpand\" Margin=\"0,0,5,0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Annotations Demo for DateTime Chart\" Margin=\"0,2,0,10\"\r\n" +
        "                HorizontalOptions=\"Center\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"CenterAndExpand\"\r\n" +
        "                FontSize=\"16\" LineBreakMode=\"WordWrap\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:DateTimeAxis Interval=\"2\" IntervalType=\"Months\" EdgeLabelsVisibilityMode=\"AlwaysVisible\">\r\n" +
        "            <toolkit:DateTimeAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"MMM\"/>\r\n" +
        "            </toolkit:DateTimeAxis.LabelStyle>\r\n" +
        "        </toolkit:DateTimeAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Interval=\"1000\" CrossesAt=\"{Static x:Double.MaxValue}\"/>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:AreaSeries ItemsSource=\"{Binding Persons}\"\r\n" +
        "                        XBindingPath=\"Date\"\r\n" +
        "                        YBindingPath=\"Size\"\r\n" +
        "                        Fill=\"#66116DF9\"\r\n" +
        "                        Stroke=\"#116DF9\"\r\n" +
        "                        StrokeWidth=\"3\"/>\r\n\r\n" +
        "    <toolkit:AreaSeries ItemsSource=\"{Binding Persons}\"\r\n" +
        "                        XBindingPath=\"Date\"\r\n" +
        "                        YBindingPath=\"Value\"\r\n" +
        "                        Fill=\"#66CAC4D0\"\r\n" +
        "                        Stroke=\"#49454F\"\r\n" +
        "                        StrokeWidth=\"3\"/>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Annotations>\r\n" +
        "        <toolkit:ChartAnnotationCollection>\r\n" +
        "            <toolkit:TextAnnotation X1=\"2020-3-9\" Y1=\"300\" Text=\"6,360 km\">\r\n" +
        "                <toolkit:TextAnnotation.LabelStyle>\r\n" +
        "                    <toolkit:ChartAnnotationLabelStyle FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"{AppThemeBinding Light=#116DF9, Dark=White}\"/>\r\n" +
        "                </toolkit:TextAnnotation.LabelStyle>\r\n" +
        "            </toolkit:TextAnnotation>\r\n" +
        "            <toolkit:TextAnnotation X1=\"2020-3-9\" Y1=\"250\" Text=\"March 1 - 9\">\r\n" +
        "                <toolkit:TextAnnotation.LabelStyle>\r\n" +
        "                    <toolkit:ChartAnnotationLabelStyle TextColor=\"{AppThemeBinding Light=#116DF9, Dark=White}\"/>\r\n" +
        "                </toolkit:TextAnnotation.LabelStyle>\r\n" +
        "            </toolkit:TextAnnotation>\r\n\r\n" +
        "            <toolkit:TextAnnotation X1=\"2020-3-20\" Y1=\"300\" Text=\"22,630 Km\">\r\n" +
        "                <toolkit:TextAnnotation.LabelStyle>\r\n" +
        "                    <toolkit:ChartAnnotationLabelStyle FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"{AppThemeBinding Light=#116DF9, Dark=White}\"/>\r\n" +
        "                </toolkit:TextAnnotation.LabelStyle>\r\n" +
        "            </toolkit:TextAnnotation>\r\n" +
        "            <toolkit:TextAnnotation X1=\"2020-3-20\" Y1=\"250\" Text=\"March 9 - 20\">\r\n" +
        "                <toolkit:TextAnnotation.LabelStyle>\r\n" +
        "                    <toolkit:ChartAnnotationLabelStyle TextColor=\"{AppThemeBinding Light=#116DF9, Dark=White}\"/>\r\n" +
        "                </toolkit:TextAnnotation.LabelStyle>\r\n" +
        "            </toolkit:TextAnnotation>\r\n\r\n" +
        "        </toolkit:ChartAnnotationCollection>\r\n" +
        "    </toolkit:SfCartesianChart.Annotations>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianAreaChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Value Comparison\" FontSize=\"16\" \r\n" +
        "               HorizontalTextAlignment=\"Center\" HorizontalOptions=\"Fill\"  VerticalOptions=\"Center\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis EdgeLabelsDrawingMode=\"Shift\" Interval=\"1\" ShowMajorGridLines=\"false\">\r\n" +
        "            <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"5\"/>\r\n" +
        "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"6\" Interval=\"1\">\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Value in Millions\" />\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'M\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"1\"/>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:AreaSeries Label=\"Product A\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                            Stroke=\"{AppThemeBinding Light={StaticResource series4Light}, Dark={StaticResource series4Dark}}\" \r\n" +
        "                            Fill=\"{AppThemeBinding Light={StaticResource series4Light30}, Dark={StaticResource series4Dark30}}\" StrokeWidth=\"1\" \r\n" +
        "                            ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"High\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:AreaSeries Label=\"Product B\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                            Stroke=\"{AppThemeBinding Light={StaticResource series3Light}, Dark={StaticResource series3Dark}}\" \r\n" +
        "                            Fill=\"{AppThemeBinding Light={StaticResource series3Light30}, Dark={StaticResource series3Dark30}}\" StrokeWidth=\"1\" \r\n" +
        "                            ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"Low\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:AreaSeries Label=\"Product C\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                            Stroke=\"{AppThemeBinding Light={StaticResource series2Light}, Dark={StaticResource series2Dark}}\" \r\n" +
        "                            Fill=\"{AppThemeBinding Light={StaticResource series2Light30}, Dark={StaticResource series2Dark30}}\" StrokeWidth=\"1\" \r\n" +
        "                            ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"Value\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:AreaSeries Label=\"Product D\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                            Stroke=\"{AppThemeBinding Light={StaticResource series1Light}, Dark={StaticResource series1Dark}}\" \r\n" +
        "                            Fill=\"{AppThemeBinding Light={StaticResource series1Light30}, Dark={StaticResource series1Dark30}}\" StrokeWidth=\"1\" \r\n" +
        "                            ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"Size\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianSplineAreaChartXamlCode =

        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Value Comparison\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis EdgeLabelsDrawingMode=\"Shift\" Interval=\"1\" ShowMajorGridLines=\"false\">\r\n" +
        "           <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"5\"/>\r\n" +
        "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"6\" Interval=\"1\">\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Value in Millions\" />\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'M\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"1\"/>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:SplineAreaSeries Label=\"Product A\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                                  Stroke=\"{AppThemeBinding Light={StaticResource series4Light}, Dark={StaticResource series4Dark}}\" \r\n" +
        "                                  Fill=\"{AppThemeBinding Light={StaticResource series4Light30}, Dark={StaticResource series4Dark30}}\" StrokeWidth=\"1\" \r\n" +
        "                                 ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"High\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:SplineAreaSeries Label=\"Product B\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                                  Stroke=\"{AppThemeBinding Light={StaticResource series3Light}, Dark={StaticResource series3Dark}}\" \r\n" +
        "                                  Fill=\"{AppThemeBinding Light={StaticResource series3Light30}, Dark={StaticResource series3Dark30}}\" StrokeWidth=\"1\" \r\n" +
        "                                  ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"Low\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:SplineAreaSeries Label=\"Product C\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                                  Stroke=\"{AppThemeBinding Light={StaticResource series2Light}, Dark={StaticResource series2Dark}}\" \r\n" +
        "                                  Fill=\"{AppThemeBinding Light={StaticResource series2Light30}, Dark={StaticResource series2Dark30}}\" StrokeWidth=\"1\" \r\n" +
        "                                      ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"Value\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:SplineAreaSeries Label=\"Product D\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                                  Stroke=\"{AppThemeBinding Light={StaticResource series1Light}, Dark={StaticResource series1Dark}}\" \r\n" +
        "                                  Fill=\"{AppThemeBinding Light={StaticResource series1Light30}, Dark={StaticResource series1Dark30}}\" StrokeWidth=\"1\" \r\n" +
        "                                  ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"Size\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStepAreaChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Step Area Chart\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis EdgeLabelsDrawingMode=\"Shift\" Interval=\"1\" ShowMajorGridLines=\"false\">\r\n" +
        "            <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"5\"/>\r\n" +
        "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"6\" Interval=\"1\">\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Value in Millions\" />\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'M\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"1\"/>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:StepAreaSeries  Label=\"Product A\" EnableAnimation=\"True\" EnableTooltip=\"True\"\r\n" +
        "                                Stroke=\"{AppThemeBinding Light={StaticResource series4Light}, Dark={StaticResource series4Dark}}\" \r\n" +
        "                                Fill=\"{AppThemeBinding Light={StaticResource series4Light30}, Dark={StaticResource series4Dark30}}\" StrokeWidth=\"1\" \r\n" +
        "                                ItemsSource=\"{Binding ComponentData, Source={x:Reference root}}\" XBindingPath=\"Name\" YBindingPath=\"High\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:StepAreaSeries  Label=\"Product B\" EnableAnimation=\"True\" EnableTooltip=\"True\"\r\n" +
        "                                Stroke=\"{AppThemeBinding Light={StaticResource series3Light}, Dark={StaticResource series3Dark}}\" \r\n" +
        "                                Fill=\"{AppThemeBinding Light={StaticResource series3Light30}, Dark={StaticResource series3Dark30}}\" StrokeWidth=\"1\" \r\n" +
        "                                ItemsSource=\"{Binding ComponentData, Source={x:Reference root}}\" XBindingPath=\"Name\" YBindingPath=\"Low\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:StepAreaSeries  Label=\"Product C\" EnableAnimation=\"True\" EnableTooltip=\"True\"\r\n" +
        "                                Stroke=\"{AppThemeBinding Light={StaticResource series2Light}, Dark={StaticResource series2Dark}}\" \r\n" +
        "                                Fill=\"{AppThemeBinding Light={StaticResource series2Light30}, Dark={StaticResource series2Dark30}}\" StrokeWidth=\"1\" \r\n" +
        "                                ItemsSource=\"{Binding ComponentData, Source={x:Reference root}}\" XBindingPath=\"Name\" YBindingPath=\"Value\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:StepAreaSeries  Label=\"Product D\" EnableAnimation=\"True\" EnableTooltip=\"True\"\r\n" +
        "                                Stroke=\"{AppThemeBinding Light={StaticResource series1Light}, Dark={StaticResource series1Dark}}\" \r\n" +
        "                                Fill=\"{AppThemeBinding Light={StaticResource series1Light30}, Dark={StaticResource series1Dark30}}\" StrokeWidth=\"1\" \r\n" +
        "                                ItemsSource=\"{Binding ComponentData, Source={x:Reference root}}\" XBindingPath=\"Name\" YBindingPath=\"Size\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianRangeAreaChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior EnablePinchZooming=\"False\" EnableDoubleTap=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Range Area Chart\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:DateTimeAxis Interval=\"5\" ShowMajorGridLines=\"false\" AutoScrollingMode=\"Start\" AutoScrollingDeltaType=\"Days\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\" Minimum=\"0\" Maximum=\"50\" Interval=\"10\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat= \"0.#&#186;C\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:RangeAreaSeries ItemsSource=\"{Binding ComponentData, Source={x:Reference root}}\" \r\n" +
        "                                 XBindingPath=\"Date\" High=\"High\" Low=\"Low\" LegendIcon=\"SeriesType\"\r\n" +
        "                                 Stroke=\"{AppThemeBinding Light={StaticResource series4Light}, Dark={StaticResource series4Dark}}\" \r\n" +
        "                                 Fill=\"{AppThemeBinding Light={StaticResource series4Light30}, Dark={StaticResource series4Dark30}}\"\r\n" +
        "                                 EnableAnimation=\"True\" EnableTooltip=\"True\" StrokeWidth=\"1\" />\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>" + "";

    [ObservableProperty]
    string cartesianSplineRangeAreaChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior EnablePinchZooming=\"False\" EnableDoubleTap=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Spline Range Area Chart\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:DateTimeAxis Interval=\"5\" ShowMajorGridLines=\"false\" AutoScrollingMode=\"Start\" AutoScrollingDeltaType=\"Days\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\" Minimum=\"0\" Maximum=\"50\" Interval=\"10\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat= \"0.#&#186;c\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SplineRangeAreaSeries ItemsSource=\"{x:Binding ComponentData, Source={x:Reference root}}\" \r\n" +
        "                                   XBindingPath=\"Date\" High=\"High\" Low=\"Low\" LegendIcon=\"SeriesType\"\r\n" +
        "                                   Fill=\"{AppThemeBinding Light={StaticResource series1Light}, Dark={StaticResource series1Dark}}\" \r\n" +
        "                                   Stroke=\"{AppThemeBinding Light={StaticResource series1Dark}, Dark={StaticResource series1Dark}}\" \r\n" +
        "                                   EnableAnimation=\"True\" EnableTooltip=\"True\" ShowTrackballLabel=\"True\" StrokeWidth=\"1\" />\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingAreaChartXamlCode = 
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Stacking Area Chart\" LineBreakMode=\"WordWrap\" Margin=\"2,0,2,0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis IsVisible=\"True\" ShowMajorGridLines=\"False\" Interval=\"2\" EdgeLabelsDrawingMode=\"Shift\" PlotOffsetEnd=\"5\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"7\" Interval=\"1\" ShowMajorGridLines=\"True\" ShowMinorGridLines=\"false\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'B\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\">\r\n" +
        "                </toolkit:ChartLineStyle>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:StackingAreaSeries ItemsSource=\"{x:Binding StackingArea}\"\r\n" +
        "                                XBindingPath=\"Year\" YBindingPath=\"High\"\r\n" +
        "                                Label=\"Organic\" LegendIcon=\"SeriesType\" EnableAnimation=\"True\"\r\n" +
        "                                EnableTooltip=\"True\" />\r\n" +
        "    <toolkit:StackingAreaSeries ItemsSource=\"{x:Binding StackingArea}\"\r\n" +
        "                                XBindingPath=\"Year\" YBindingPath=\"Low\"\r\n" +
        "                                Label=\"Fairtrade\" LegendIcon=\"SeriesType\" EnableAnimation=\"True\"\r\n" +
        "                                EnableTooltip=\"True\" />\r\n" +
        "    <toolkit:StackingAreaSeries ItemsSource=\"{x:Binding StackingArea}\" \r\n" +
        "                                XBindingPath=\"Year\" YBindingPath=\"Value\"\r\n" +
        "                                Label=\"Veg Alternatives\" LegendIcon=\"SeriesType\" EnableAnimation=\"True\"\r\n" +
        "                                EnableTooltip=\"True\" />\r\n" +
        "    <toolkit:StackingAreaSeries ItemsSource=\"{x:Binding StackingArea}\"\r\n" +
        "                                XBindingPath=\"Year\" YBindingPath=\"Size\"\r\n" +
        "                                Label=\"Others\" LegendIcon=\"SeriesType\" EnableAnimation=\"True\"\r\n" +
        "                                EnableTooltip=\"True\" />\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingArea100ChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" \r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"StackingArea100 Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis IsVisible=\"True\" ShowMajorGridLines=\"False\" Interval=\"2\" EdgeLabelsDrawingMode=\"Shift\">\r\n" +
        "            <toolkit:CategoryAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle/>\r\n" +
        "            </toolkit:CategoryAxis.AxisLineStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"100\" Interval=\"20\" ShowMajorGridLines=\"True\" ShowMinorGridLines=\"False\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\">\r\n" +
        "                </toolkit:ChartLineStyle>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:StackingArea100Series ItemsSource=\"{x:Binding StackingArea}\" \r\n" +
        "                                    XBindingPath=\"Year\" YBindingPath=\"High\"\r\n" +
        "                                    Label=\"Product 1\" LegendIcon=\"SeriesType\"\r\n" +
        "                                    EnableAnimation=\"True\" EnableTooltip=\"True\"/>\r\n" +
        "    <toolkit:StackingArea100Series ItemsSource=\"{x:Binding StackingArea}\" \r\n" +
        "                                    XBindingPath=\"Year\" YBindingPath=\"Low\" \r\n" +
        "                                    Label=\"Product 2\" LegendIcon=\"SeriesType\"\r\n" +
        "                                    EnableAnimation=\"True\" EnableTooltip=\"True\"/>\r\n" +
        "    <toolkit:StackingArea100Series ItemsSource=\"{x:Binding StackingArea}\" \r\n" +
        "                                    XBindingPath=\"Year\" YBindingPath=\"Value\" \r\n" +
        "                                    Label=\"Product 3\" LegendIcon=\"SeriesType\"\r\n" +
        "                                    EnableAnimation=\"True\" EnableTooltip=\"True\"/>\r\n" +
        "    <toolkit:StackingArea100Series ItemsSource=\"{x:Binding StackingArea}\" \r\n" +
        "                                    XBindingPath=\"Year\" YBindingPath=\"Size\" \r\n" +
        "                                    Label=\"Product 4\" LegendIcon=\"SeriesType\"\r\n" +
        "                                    EnableAnimation=\"True\" EnableTooltip=\"True\"/>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianBarChartXamlCode =
        "<toolkit:SfCartesianChart IsTransposed=\"True\" HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" \r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Bar Chart\" LineBreakMode=\"WordWrap\" Margin=\"2,0,2,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis EdgeLabelsDrawingMode=\"Shift\" LabelPlacement=\"BetweenTicks\" ShowMajorGridLines=\"false\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Interval=\"10\" IsVisible=\"False\" EdgeLabelsDrawingMode=\"Shift\" ShowMajorGridLines=\"false\" ShowMinorGridLines=\"false\">\r\n" +
        "            <toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"8\">\r\n" +
        "                </toolkit:ChartAxisTickStyle>\r\n" +
        "            </toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries EnableAnimation=\"True\" ShowDataLabels=\"True\" ItemsSource=\"{x:Binding ComponentData, Source={x:Reference root}}\" XBindingPath=\"Name\" YBindingPath=\"Exp\">\r\n" +
        "            <toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "                <toolkit:CartesianDataLabelSettings LabelPlacement=\"Inner\">\r\n" +
        "                    <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                        <toolkit:ChartDataLabelStyle LabelFormat=\"0.## Exp\"/>\r\n" +
        "                    </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                </toolkit:CartesianDataLabelSettings>\r\n" +
        "            </toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "        </toolkit:ColumnSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianCustomBarChartCSharpCode = 
        "using Syncfusion.Maui.Toolkit.Charts;\r\n\r\n" +
        "public class CustomBarChart : ColumnSeries\r\n" +
        "{\r\n" +
        "    protected override ChartSegment CreateSegment()\r\n" +
        "    {\r\n" +
        "        return new BarSegment();\r\n" +
        "    }\r\n\r\n" +
        "    public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(\r\n" +
        "        nameof(TrackColor), \r\n" +
        "        typeof(SolidColorBrush), \r\n" +
        "        typeof(ColumnSeries), \r\n" +
        "        new SolidColorBrush(Color.FromArgb(\"#E7E0EC\"))\r\n" +
        "    );\r\n\r\n" +
        "    public SolidColorBrush TrackColor\r\n" +
        "    {\r\n" +
        "        get { return (SolidColorBrush)GetValue(TrackColorProperty); }\r\n" +
        "        set { SetValue(TrackColorProperty, value); }\r\n" +
        "    }\r\n" +
        "}\r\n\r\n" +
        "public class BarSegment : ColumnSegment\r\n" +
        "{\r\n" +
        "    RectF trackRect = RectF.Zero;\r\n\r\n" +
        "    protected override void OnLayout()\r\n" +
        "    {\r\n" +
        "        base.OnLayout();\r\n" +
        "        if (Series is CartesianSeries series && series.ActualYAxis is NumericalAxis yAxis)\r\n" +
        "        {\r\n" +
        "            var top = yAxis.ValueToPoint(Convert.ToDouble(yAxis.Maximum ?? double.NaN));\r\n" +
        "            trackRect = new RectF() { Left = Left, Top = Top, Right = top, Bottom = Bottom };\r\n" +
        "        }\r\n" +
        "    }\r\n\r\n" +
        "    protected override void Draw(ICanvas canvas)\r\n" +
        "    {\r\n" +
        "        if (Series is not CustomBarChart series) return;\r\n\r\n" +
        "        canvas.SetFillPaint(series.TrackColor, trackRect);\r\n" +
        "        canvas.FillRoundedRectangle(trackRect, 25);\r\n\r\n" +
        "        base.Draw(canvas);\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string cartesianCustomBarChartXamlCode =
        "<toolkit:SfCartesianChart IsTransposed=\"True\" HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Custom Bar Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" ShowMajorGridLines=\"false\">\r\n" +
        "            <toolkit:CategoryAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\"/>\r\n" +
        "            </toolkit:CategoryAxis.AxisLineStyle>\r\n" +
        "            <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle StrokeWidth=\"0\"/>\r\n" +
        "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Maximum=\"100\" ShowMajorGridLines=\"False\" IsVisible=\"False\" EdgeLabelsDrawingMode=\"Shift\" ShowMinorGridLines=\"false\">\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <core:CustomBarChart ShowDataLabels=\"True\" Width=\"0.5\" \r\n" +
        "                                EnableAnimation=\"True\" CornerRadius=\"25\"  \r\n" +
        "                                ItemsSource=\"{x:Binding Bar}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Exp\">\r\n" +
        "            <core:CustomBarChart.DataLabelSettings>\r\n" +
        "                <toolkit:CartesianDataLabelSettings UseSeriesPalette=\"True\" LabelPlacement=\"Inner\">\r\n" +
        "                    <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                        <toolkit:ChartDataLabelStyle LabelFormat=\"#.##\" />\r\n" +
        "                    </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                </toolkit:CartesianDataLabelSettings>\r\n" +
        "            </core:CustomBarChart.DataLabelSettings>\r\n" +
        "        </core:CustomBarChart>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianDoubleBarChartXamlCode = 
        "<toolkit:SfCartesianChart IsTransposed=\"True\" HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Double Bar Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis EdgeLabelsDrawingMode=\"Shift\" ShowMajorGridLines=\"false\">\r\n" +
        "            <toolkit:CategoryAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Food\" />\r\n" +
        "            </toolkit:CategoryAxis.Title>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis IsVisible=\"false\" EdgeLabelsDrawingMode=\"Shift\" ShowMajorGridLines=\"false\" ShowMinorGridLines=\"false\">\r\n" +
        "            <toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"8\">\r\n" +
        "                </toolkit:ChartAxisTickStyle>\r\n" +
        "            </toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries Label=\"Imports\" Width=\"0.8\" EnableTooltip=\"True\" Spacing=\"0.1\" \r\n" +
        "                              ItemsSource=\"{x:Binding Bar}\" \r\n" +
        "                              XBindingPath=\"Name\" YBindingPath=\"Exp\" EnableAnimation=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:ColumnSeries Label=\"Exports\" Width=\"0.8\" EnableTooltip=\"True\" Spacing=\"0.1\" \r\n" +
        "                              ItemsSource=\"{x:Binding Bar}\" \r\n" +
        "                              XBindingPath=\"Name\" YBindingPath=\"Exp\" EnableAnimation=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianRangeBarChartXamlCode =
        "<toolkit:SfCartesianChart IsTransposed=\"True\" HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\" HeightRequest=\"500\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Range Bar Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior EnableDoubleTap=\"False\" EnablePinchZooming=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis Interval=\"1\" EdgeLabelsDrawingMode=\"Shift\" LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"False\" AutoScrollingMode=\"End\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" EdgeLabelsDrawingMode=\"Shift\" ShowMajorGridLines=\"false\" ShowMinorGridLines=\"false\" Interval=\"5\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat= \"0.#&#186;C\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:RangeColumnSeries EnableAnimation=\"True\" ShowDataLabels=\"True\"\r\n" +
        "                                Fill=\"{x:AppThemeBinding Light={x:StaticResource series1Light}, Dark={x:StaticResource series1Dark}}\"\r\n" +
        "                                ItemsSource=\"{x:Binding RangeBar}\"\r\n" +
        "                                XBindingPath=\"Name\" High=\"High\" Low=\"Low\">\r\n" +
        "        <toolkit:RangeColumnSeries.DataLabelSettings>\r\n" +
        "            <toolkit:CartesianDataLabelSettings UseSeriesPalette=\"False\">\r\n" +
        "                <toolkit:CartesianDataLabelSettings.LabelStyle >\r\n" +
        "                    <toolkit:ChartDataLabelStyle TextColor=\"White\" LabelFormat= \"0.#&#186;C\" />\r\n" +
        "                </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "            </toolkit:CartesianDataLabelSettings>\r\n" +
        "        </toolkit:RangeColumnSeries.DataLabelSettings>\r\n" +
        "    </toolkit:RangeColumnSeries>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingBarChartXamlCode =
        "<toolkit:SfCartesianChart IsTransposed=\"True\" HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Stacking Bar Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"false\" >\r\n" +
        "            <toolkit:CategoryAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Product\"/>\r\n" +
        "            </toolkit:CategoryAxis.Title>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"-20\" Maximum=\"48\" Interval=\"10\" ShowMajorGridLines=\"True\" ShowMinorGridLines=\"false\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle  LabelFormat=\"$###,##0.##K\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:StackingColumnSeries XBindingPath=\"Name\" YBindingPath=\"High\"\r\n" +
        "                                Label=\"Zone 1\" EnableTooltip=\"True\" LegendIcon=\"SeriesType\"\r\n" +
        "                                ItemsSource=\"{x:Binding StackingBar}\" />\r\n" +
        "    <toolkit:StackingColumnSeries XBindingPath=\"Name\" YBindingPath=\"Low\" \r\n" +
        "                                Label=\"Zone 2\" EnableTooltip=\"True\" LegendIcon=\"SeriesType\"\r\n" +
        "                                ItemsSource=\"{x:Binding StackingBar}\" />\r\n" +
        "    <toolkit:StackingColumnSeries XBindingPath=\"Name\" YBindingPath=\"Value\"\r\n" +
        "                                Label=\"Zone 3\" EnableTooltip=\"True\" LegendIcon=\"SeriesType\"\r\n" +
        "                                ItemsSource=\"{x:Binding StackingBar}\" />\r\n" +
        "    <toolkit:StackingColumnSeries XBindingPath=\"Name\" YBindingPath=\"Size\"\r\n" +
        "                                Label=\"Zone 4\" EnableTooltip=\"True\" LegendIcon=\"SeriesType\"\r\n" +
        "                                ItemsSource=\"{x:Binding StackingBar}\"/>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingBar100ChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" IsTransposed=\"True\" \r\n" +
        "                        Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Stacking Bar 100 Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" ShowMajorGridLines=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Interval=\"20\" ShowMajorGridLines=\"True\" ShowMinorGridLines=\"True\" RangePadding=\"None\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 1\" LegendIcon=\"Rectangle\"\r\n" +
        "                                        ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                        XBindingPath=\"Name\" YBindingPath=\"High\" \r\n" +
        "                                        EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 2\" LegendIcon=\"Rectangle\"\r\n" +
        "                                        ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                        XBindingPath=\"Name\" YBindingPath=\"Low\" \r\n" +
        "                                        EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 3\" LegendIcon=\"Rectangle\"\r\n" +
        "                                        ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                        XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                                        EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 4\" LegendIcon=\"Rectangle\"\r\n" +
        "                                        ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                        XBindingPath=\"Name\" YBindingPath=\"Size\" \r\n" +
        "                                        EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianColumnChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Column Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"false\" >\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"True\" ShowMinorGridLines=\"false\" Interval=\"20\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0 Exp\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.MinorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle Stroke=\"Transparent\" StrokeWidth=\"0\"/>\r\n" +
        "            </toolkit:NumericalAxis.MinorTickStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\" />\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries Label=\"Countries\" EnableAnimation=\"True\" ShowDataLabels=\"True\"  \r\n" +
        "                                ItemsSource=\"{x:Binding ComponentData,Source={x:Reference root}}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Exp\">\r\n" +
        "            <toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "                <toolkit:CartesianDataLabelSettings >\r\n" +
        "                    <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                        <toolkit:ChartDataLabelStyle FontSize=\"12\" LabelFormat='0 Exp'/>\r\n" +
        "                    </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                </toolkit:CartesianDataLabelSettings>\r\n" +
        "            </toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "        </toolkit:ColumnSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianTripleColumnChartXamlCode =
        "<toolkit:SfCartesianChart x:Name=\"Chart2\" PaletteBrushes=\"{Binding OlympicColorModel}\" HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\" />\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Column Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"False\" LabelPlacement=\"BetweenTicks\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"True\" Minimum=\"0\">\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries Label=\"Aqua\" EnableTooltip=\"True\" EnableAnimation=\"True\" Width=\"0.8\" Spacing=\"0.2\" \r\n" +
        "                                ItemsSource=\"{x:Binding Column}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Exp\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:ColumnSeries Label=\"Gray\" EnableTooltip=\"True\" EnableAnimation=\"True\" Width=\"0.8\" Spacing=\"0.2\" \r\n" +
        "                                ItemsSource=\"{x:Binding Column}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Value\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:ColumnSeries Label=\"Blue\" EnableTooltip=\"True\" EnableAnimation=\"True\" Width=\"0.8\" Spacing=\"0.2\" \r\n" +
        "                                ItemsSource=\"{x:Binding Column}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Size\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianRoundedColumnChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                            Margin=\"20, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Column Chart with Rounded Conner\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"false\" />\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis IsVisible=\"False\" Minimum=\"0\" Maximum=\"120\" Interval=\"20\" ShowMajorGridLines=\"True\" >\r\n" +
        "            <toolkit:NumericalAxis.MinorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"10\" StrokeWidth=\"0\"/>\r\n" +
        "            </toolkit:NumericalAxis.MinorTickStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries EnableAnimation=\"True\" EnableTooltip=\"True\" CornerRadius=\"10\" \r\n" +
        "                                ItemsSource=\"{x:Binding Column}\" XBindingPath=\"Name\" YBindingPath=\"Exp\">\r\n" +
        "        </toolkit:ColumnSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "    <toolkit:SfCartesianChart.Annotations>\r\n" +
        "        <toolkit:HorizontalLineAnnotation Y1=\"90\" Stroke=\"#E75A6E\" StrokeWidth=\"2\" StrokeDashArray=\"15, 6, 5, 3\" Text=\"Overflow\">\r\n" +
        "            <toolkit:HorizontalLineAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle TextColor=\"#E75A6E\" HorizontalTextAlignment=\"Start\" VerticalTextAlignment=\"Start\" FontSize=\"15\"/>\r\n" +
        "            </toolkit:HorizontalLineAnnotation.LabelStyle>\r\n" +
        "        </toolkit:HorizontalLineAnnotation>\r\n" +
        "    </toolkit:SfCartesianChart.Annotations>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianCustomColumnChartCSharpCode =
        "public class CustomColumnSeries : ColumnSeries\r\n" +
        "{\r\n" +
        "    protected override ChartSegment CreateSegment()\r\n" +
        "    {\r\n" +
        "        return new CustomColumnSegment();\r\n" +
        "    }\r\n\r\n" +
        "    public static readonly BindableProperty TrackColorProperty =BindableProperty.Create(\r\n" +
        "        nameof(TrackColor), \r\n" +
        "        typeof(SolidColorBrush), \r\n" +
        "        typeof(CustomColumnSeries), \r\n" +
        "        new SolidColorBrush(Color.FromArgb(\"#E7E0EC\"))\r\n" +
        "    );\r\n\r\n" +
        "    public SolidColorBrush TrackColor\r\n" +
        "    {\r\n" +
        "        get { return (SolidColorBrush)GetValue(TrackColorProperty); }\r\n" +
        "        set { SetValue(TrackColorProperty, value); }\r\n" +
        "    }\r\n\r\n" +
        "    protected override void DrawDataLabel(ICanvas canvas, Brush? fillcolor, string label, PointF point, int index)\r\n" +
        "    {\r\n" +
        "        var items = ItemsSource as ObservableCollection<SfCartesianChartModel>;\r\n" +
        "        if (items != null)\r\n" +
        "        {\r\n" +
        "            var text = items[index].Name ?? \"\";\r\n" +
        "            base.DrawDataLabel(canvas, new SolidColorBrush(Colors.Transparent), label, point, index);\r\n" +
        "            base.DrawDataLabel(canvas, new SolidColorBrush(Colors.Transparent), text, new PointF(point.X, point.Y - 30), index);\r\n" +
        "        }\r\n" +
        "    }\r\n}\r\n\r\n" +
        "public class CustomColumnSegment : ColumnSegment\r\n" +
        "{\r\n" +
        "    float curveHeight;\r\n" +
        "    float curveXGape = 30;\r\n" +
        "    float curveYGape = 20;\r\n\r\n" +
        "    protected override void Draw(ICanvas canvas)\r\n" +
        "    {\r\n" +
        "        base.Draw(canvas);\r\n\r\n" +
        "        if (Series is CartesianSeries series && series.ActualYAxis is NumericalAxis yAxis)\r\n" +
        "        {\r\n" +
        "            var top = yAxis.ValueToPoint(Convert.ToDouble(yAxis.Maximum ?? double.NaN));\r\n\r\n" +
        "            var trackRect = new RectF() { Left = Left, Top = top, Right = Right, Bottom = Bottom };\r\n" +
        "            curveHeight = trackRect.Height / curveYGape;\r\n" +
        "            var width = trackRect.Width + (float)Math.Sqrt((trackRect.Width * trackRect.Width) + (trackRect.Height * trackRect.Height));\r\n" +
        "            var waveLeft = trackRect.Left;\r\n" +
        "            var waveRight = waveLeft + width;\r\n" +
        "            var waveTop = trackRect.Bottom;\r\n" +
        "            var waveBottom = trackRect.Bottom + trackRect.Height;\r\n\r\n" +
        "            var waveRect = new Rect() { Left = waveLeft, Top = waveTop, Right = waveRight, Bottom = waveBottom };\r\n\r\n" +
        "            float freq = trackRect.Bottom - Top;\r\n\r\n" +
        "            canvas.CanvasSaveState();\r\n\r\n" +
        "            DrawTrackPath(canvas, trackRect);\r\n\r\n" +
        "            var color = (Fill is SolidColorBrush brush) ? brush.Color : Colors.Transparent;\r\n\r\n" +
        "            canvas.SetFillPaint(new SolidColorBrush(color.MultiplyAlpha(0.6f)), waveRect);\r\n" +
        "            DrawWave(canvas, new Rect(new Point(waveLeft - curveXGape - freq, waveTop - freq), waveRect.Size));\r\n\r\n" +
        "            canvas.SetFillPaint(Fill, waveRect);\r\n" +
        "            DrawWave(canvas, new Rect(new Point(waveLeft - freq, waveTop - freq), waveRect.Size));\r\n\r\n" +
        "            canvas.CanvasRestoreState();\r\n" +
        "        }\r\n" +
        "    }\r\n\r\n" +
        "    private void DrawTrackPath(ICanvas canvas, RectF trackRect)\r\n" +
        "    {\r\n" +
        "        if (Series is not CustomColumnSeries series) return;\r\n" +
        "        PathF path = new();\r\n" +
        "        path.MoveTo(trackRect.Left, trackRect.Bottom);\r\n" +
        "        path.LineTo(trackRect.Left, trackRect.Top);\r\n" +
        "        path.LineTo(trackRect.Right, trackRect.Top);\r\n" +
        "        path.LineTo(trackRect.Right, trackRect.Bottom);\r\n\r\n" +
        "        path.Close();\r\n" +
        "        canvas.ClipPath(path);\r\n\r\n" +
        "        canvas.SetFillPaint(series.TrackColor, trackRect);\r\n" +
        "        canvas.FillPath(path);\r\n" +
        "    }\r\n\r\n" +
        "    private void DrawWave(ICanvas canvas, RectF rectangle)\r\n" +
        "    {\r\n" +
        "        PathF path = new();\r\n\r\n" +
        "        path.MoveTo(rectangle.Left, rectangle.Bottom);\r\n" +
        "        path.LineTo(rectangle.Left, rectangle.Top);\r\n\r\n" +
        "        var top = rectangle.Top;\r\n" +
        "        var start = rectangle.Left;\r\n" +
        "        var split = rectangle.Width / 5;\r\n" +
        "        do\r\n" +
        "        {\r\n" +
        "            var next = start + split;\r\n\r\n" +
        "            var crX = start + (split / 2);\r\n" +
        "            var crY = top - curveHeight;\r\n" +
        "            var crY2 = top + curveHeight;\r\n\r\n" +
        "            path.CurveTo(crX, crY, crX, crY2, next, top);\r\n\r\n" +
        "            start = next;\r\n" +
        "        } while (start <= rectangle.Right);\r\n\r\n" +
        "        path.LineTo(rectangle.Right, rectangle.Bottom);\r\n" +
        "        path.Close();\r\n" +
        "        canvas.FillPath(path);\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string cartesianCustomColumnChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Custom Column Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis IsVisible=\"False\" />\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\" IsVisible=\"False\" Maximum=\"150\" Minimum=\"0\"/>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <core:CustomColumnSeries EnableAnimation=\"True\" ShowDataLabels=\"True\"\r\n" +
        "                                        ItemsSource=\"{x:Binding Column}\" \r\n" +
        "                                        TrackColor=\"{x:AppThemeBinding Light={x:StaticResource TrackColorLight}, Dark={x:StaticResource TrackColorDark}}\"\r\n" +
        "                                        XBindingPath=\"Name\" YBindingPath=\"Exp\">\r\n" +
        "            <core:CustomColumnSeries.DataLabelSettings>\r\n" +
        "                <toolkit:CartesianDataLabelSettings UseSeriesPalette=\"False\" LabelPlacement=\"Outer\">\r\n" +
        "                    <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                        <toolkit:ChartDataLabelStyle TextColor=\"{x:AppThemeBinding Default={x:StaticResource ContentForeground}}\" FontSize=\"16\" LabelFormat=\"0.00'M\"/>\r\n" +
        "                    </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                </toolkit:CartesianDataLabelSettings>\r\n" +
        "            </core:CustomColumnSeries.DataLabelSettings>\r\n" +
        "        </core:CustomColumnSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianRangeColumnChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                            Margin=\"0, 0, 20, 0\" HeightRequest=\"500\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Range Column Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior EnableDoubleTap=\"False\" EnablePinchZooming=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" Interval=\"1\" ShowMajorGridLines=\"false\" AutoScrollingMode=\"Start\" />\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"True\" Interval=\"5\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat= \"0.#&#186;C\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:RangeColumnSeries EnableAnimation=\"True\" ShowDataLabels=\"True\"\r\n" +
        "                               Fill=\"{x:AppThemeBinding Light={x:StaticResource series1Light}, Dark={x:StaticResource series1Dark}}\"\r\n" +
        "                               ItemsSource=\"{x:Binding RangeColumn}\"\r\n" +
        "                               XBindingPath=\"Name\" High=\"High\" Low=\"Low\">\r\n" +
        "        <toolkit:RangeColumnSeries.DataLabelSettings>\r\n" +
        "            <toolkit:CartesianDataLabelSettings UseSeriesPalette=\"False\">\r\n" +
        "                <toolkit:CartesianDataLabelSettings.LabelStyle >\r\n" +
        "                    <toolkit:ChartDataLabelStyle TextColor=\"White\" LabelFormat= \"0.#&#186;C\"/>\r\n" +
        "                </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "            </toolkit:CartesianDataLabelSettings>\r\n" +
        "        </toolkit:RangeColumnSeries.DataLabelSettings>\r\n" +
        "    </toolkit:RangeColumnSeries>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingColumnChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" \r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Stacking Column Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"false\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"True\" ShowMinorGridLines=\"false\" Minimum=\"0\" Maximum=\"60\" Interval=\"10\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n\r\n" +
        "    <toolkit:StackingColumnSeries Label=\"Zone 1\" XBindingPath=\"Name\" YBindingPath=\"Value\"\r\n" +
        "                                    ItemsSource=\"{x:Binding StackingColumn}\"\r\n" +
        "                                    EnableAnimation=\"True\" ShowDataLabels=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    <toolkit:StackingColumnSeries Label=\"Zone 2\" XBindingPath=\"Name\" YBindingPath=\"High\"\r\n" +
        "                                    ItemsSource=\"{x:Binding StackingColumn}\"\r\n" +
        "                                    EnableAnimation=\"True\" ShowDataLabels=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    <toolkit:StackingColumnSeries Label=\"Zone 3\" XBindingPath=\"Name\" YBindingPath=\"Low\"\r\n" +
        "                                    ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                    EnableAnimation=\"True\" ShowDataLabels=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingColumn100ChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" IsTransposed=\"True\" \r\n" +
        "                        Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Stacking Column 100 Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" ShowMajorGridLines=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Interval=\"20\" ShowMajorGridLines=\"True\" ShowMinorGridLines=\"True\" RangePadding=\"None\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 1\" LegendIcon=\"Rectangle\"\r\n" +
        "                                            ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                            XBindingPath=\"Name\" YBindingPath=\"High\" \r\n" +
        "                                            EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 2\" LegendIcon=\"Rectangle\"\r\n" +
        "                                            ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                            XBindingPath=\"Name\" YBindingPath=\"Low\" \r\n" +
        "                                            EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 3\" LegendIcon=\"Rectangle\"\r\n" +
        "                                            ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                            XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                                            EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 4\" LegendIcon=\"Rectangle\"\r\n" +
        "                                            ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                            XBindingPath=\"Name\" YBindingPath=\"Size\" \r\n" +
        "                                            EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";
    #endregion
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlGroup = query.GetData<ControlGroupInfo>();

        LoadDataAsync(true).FireAndForget();
    }
    #endregion

    #region [ Methods ]
    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;

        var persons = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "Strypper", Exp = 100 },
            new SfCartesianChartModel() { Name = "Tan", Exp = 50 },
            new SfCartesianChartModel() { Name = "Hung", Exp = 40 },
            new SfCartesianChartModel() { Name = "Long", Exp = 20 },
            new SfCartesianChartModel() { Name = "Dat", Exp = 30 }
        };

        var annotation = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Date = new DateTime(2020, 03, 02), Size = 350, Value = 100 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 03, 09), Size = 470, Value = 200 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 03, 16), Size = 500, Value = 400 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 03, 23), Size = 530, Value = 600 }
        };

        var area = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "Strypper", High = 4.17, Low = 0.72, Size = 2.48, Value = 1.23 },
            new SfCartesianChartModel() { Name = "Tan", High = 3.51, Low = 1.64, Size = 2.43, Value = 4.17 },
            new SfCartesianChartModel() { Name = "Hung", High = 2.01, Low = 2.71, Size = 3.47, Value = 3.17 },
            new SfCartesianChartModel() { Name = "Long", High = 1.95, Low = 3.63, Size = 2.41, Value = 3.20 },
            new SfCartesianChartModel() { Name = "Dat", High = 3.95, Low = 2.63, Size = 0.41, Value = 1.20 }
        };

        var rangeArea = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 01).Date, High = 36, Low = 13, Value = 24.5},
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 02).Date, High = 33, Low = 16, Value = 24.5 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 03).Date, High = 33, Low = 15, Value = 24 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 04).Date, High = 32, Low = 12, Value = 24.5 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 05).Date, High = 38, Low = 11, Value = 24.5 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 06).Date, High = 37, Low = 11, Value = 24 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 07).Date, High = 36, Low = 13, Value = 24.5 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 08).Date, High = 35, Low = 14, Value = 24.5 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 09).Date, High = 39, Low = 14, Value = 26.5 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 10).Date, High = 37, Low = 15, Value = 26 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 11).Date, High = 36, Low = 16, Value = 26 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 12).Date, High = 35, Low = 17, Value = 26 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 13).Date, High = 35, Low = 13, Value = 24 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 14).Date, High = 36, Low = 12, Value = 24 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 15).Date, High = 37, Low = 11, Value = 24 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 16).Date, High = 31, Low = 15, Value = 23 }
        };

        var stackingArea = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { High = 0.61, Low = 0.03, Value = 0.48, Size = 0.23, Year = "2001"},
            new SfCartesianChartModel() { High = 0.81, Low = 0.05, Value = 0.53, Size = 0.17, Year = "2002" },
            new SfCartesianChartModel() { High = 0.91, Low = 0.06, Value = 0.57, Size = 0.17, Year = "2003" },
            new SfCartesianChartModel() { High = 1.00, Low = 0.09, Value = 0.61, Size = 0.20, Year = "2004" },
            new SfCartesianChartModel() { High = 1.19, Low = 0.14, Value = 0.63, Size = 0.23, Year = "2005" },
            new SfCartesianChartModel() { High = 1.47, Low = 0.20, Value = 0.64, Size = 0.36, Year = "2006" },
            new SfCartesianChartModel() { High = 1.74, Low = 0.29, Value = 0.66, Size = 0.43, Year = "2007" },
            new SfCartesianChartModel() { High = 1.98, Low = 0.46, Value = 0.76, Size = 0.52, Year = "2008" },
            new SfCartesianChartModel() { High = 1.99, Low = 0.64, Value = 0.77, Size = 0.72, Year = "2009" },
            new SfCartesianChartModel() { High = 1.70, Low = 0.75, Value = 0.55, Size = 1.29, Year = "2010" },
            new SfCartesianChartModel() { High = 1.48, Low = 1.06, Value = 0.54, Size = 1.38, Year = "2011" },
            new SfCartesianChartModel() { High = 1.38, Low = 1.25, Value = 0.57, Size = 1.82, Year = "2012" }
        };

        var bar = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "Strypper", Exp = 100 },
            new SfCartesianChartModel() { Name = "Tan", Exp = 50 },
            new SfCartesianChartModel() { Name = "Hung", Exp = 40 },
            new SfCartesianChartModel() { Name = "Long", Exp = 20 },
            new SfCartesianChartModel() { Name = "Dat", Exp = 30 }
        };

        var rangeBar = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "January", High = 7, Low = 3 },
            new SfCartesianChartModel() { Name = "February", High = 8, Low = 3 },
            new SfCartesianChartModel() { Name = "March", High = 12, Low = 5 },
            new SfCartesianChartModel() { Name = "April", High = 16, Low = 7 },
            new SfCartesianChartModel() { Name = "May", High = 20, Low = 11 },
            new SfCartesianChartModel() { Name = "June", High = 23, Low = 14 },
            new SfCartesianChartModel() { Name = "July", High = 25, Low = 16 },
            new SfCartesianChartModel() { Name = "August", High = 25, Low = 16 },
            new SfCartesianChartModel() { Name = "September", High = 21, Low = 13 },
            new SfCartesianChartModel() { Name = "October", High = 16, Low = 10 },
            new SfCartesianChartModel() { Name = "November", High = 11, Low = 6 },
            new SfCartesianChartModel() { Name = "December", High = 8, Low = 3 }
        };

        var stackingBar = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "Product 1", High = 3.932, Low = -3.987, Value = -5.067, Size = 13.012 },
            new SfCartesianChartModel() { Name = "Product 2", High = -5.432, Low = 3.417, Value = 15.067, Size = 12.321 },
            new SfCartesianChartModel() { Name = "Product 3", High = -4.229, Low = -4.376, Value = -3.504, Size = 12.814 },
            new SfCartesianChartModel() { Name = "Product 4", High = -9.256, Low = 4.376, Value = 9.054, Size = 8.814},
            new SfCartesianChartModel() { Name = "Product 5", High = 5.221, Low = -3.574, Value = -7.004, Size = 11.624}
        };

        var column = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "Strypper", Exp = 100, Value = 80, Size = 60 },
            new SfCartesianChartModel() { Name = "Tan", Exp = 50, Value = 70, Size = 90 },
            new SfCartesianChartModel() { Name = "Hung", Exp = 40, Value = 80, Size = 60 },
            new SfCartesianChartModel() { Name = "Long", Exp = 20, Value = 40, Size = 80},
            new SfCartesianChartModel() { Name = "Dat", Exp = 30, Value = 60, Size = 90}
        };

        var rangeColumn = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "January", High = 7, Low = 3 },
            new SfCartesianChartModel() { Name = "February", High = 8, Low = 3 },
            new SfCartesianChartModel() { Name = "March", High = 12, Low = 5 },
            new SfCartesianChartModel() { Name = "April", High = 16, Low = 7 },
            new SfCartesianChartModel() { Name = "May", High = 20, Low = 11 },
            new SfCartesianChartModel() { Name = "June", High = 23, Low = 14 },
            new SfCartesianChartModel() { Name = "July", High = 25, Low = 16 },
            new SfCartesianChartModel() { Name = "August", High = 25, Low = 16 },
            new SfCartesianChartModel() { Name = "September", High = 21, Low = 13 },
            new SfCartesianChartModel() { Name = "October", High = 16, Low = 10 },
            new SfCartesianChartModel() { Name = "November", High = 11, Low = 6 },
            new SfCartesianChartModel() { Name = "December", High = 8, Low = 3 }
        };

        var stackingColumn = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "Product 1", High = 15.767, Low = 9.726, Value = 24.769 },
            new SfCartesianChartModel() { Name = "Product 2", High = 17.471, Low = 10.206, Value = 24.790 },
            new SfCartesianChartModel() { Name = "Product 3", High = 18.097, Low = 11.057, Value = 26.170 },
            new SfCartesianChartModel() { Name = "Product 4", High = 20.056, Low = 10.946, Value = 24.795 },
            new SfCartesianChartModel() { Name = "Product 5", High = 19.739, Low = 11.164, Value = 23.533 }
        };

        var gradients = new List<Brush>(createGradientPalletBrushes());

        IsBusy = false;

        Area = new(area);
        RangeArea = new(rangeArea);
        StackingArea = new(stackingArea);
        Bar = new(bar);
        RangeBar = new(rangeBar);
        StackingBar = new(stackingBar);
        Column = new(column);
        RangeColumn = new(rangeColumn);
        StackingColumn = new(stackingColumn);
        Annotation = new(annotation);
        Persons = new(persons);
        PalletBrushes = new(gradients);

        AreaChartOptions = new ObservableCollection<string>
        {
            "Area", "Spline Area", "Step Area", "Range Area", "Spline Range Area", "Stacking Area", "100% Stacking Area"
        };

        BarChartOptions = new ObservableCollection<string>
        {
            "Bar", "Range Bar", "Stacking Bar", "Stacking Bar 100"
        };

        ColumnChartOptions = new ObservableCollection<string>
        {
            "Column", "Range Column", "Stacking Column", "Stacking Column 100"
        };

        if (forced)
        {
            Area.Clear();
            RangeArea.Clear();
            StackingArea.Clear();
            Bar.Clear();
            RangeBar.Clear();
            StackingBar.Clear();
            Column.Clear();
            RangeColumn.Clear();
            StackingColumn.Clear();
            Annotation.Clear();
            Persons.Clear();
            PalletBrushes.Clear();
        }

        area.ForEach(item => Area.Add(item));
        rangeArea.ForEach(item => RangeArea.Add(item));
        stackingArea.ForEach(item => StackingArea.Add(item));
        bar.ForEach(item => Bar.Add(item));
        rangeBar.ForEach(item => RangeBar.Add(item));
        stackingBar.ForEach(item => StackingBar.Add(item));
        column.ForEach(item => Column.Add(item));
        rangeColumn.ForEach(item => RangeColumn.Add(item));
        stackingColumn.ForEach(item => StackingColumn.Add(item));
        annotation.ForEach(item => Annotation.Add(item));
        persons.ForEach(item => Persons.Add(item));
        gradients.ForEach(item => PalletBrushes.Add(item));
    }

    List<Brush> createGradientPalletBrushes()
    {
        LinearGradientBrush gradientColor1 = new();
        gradientColor1.GradientStops = new()
            {
                new GradientStop() { Offset = 1, Color = Color.FromRgb(255, 231, 199) },
                new GradientStop() { Offset = 0, Color = Color.FromRgb(252, 182, 159) }
            };

        LinearGradientBrush gradientColor2 = new();
        gradientColor2.GradientStops = new()
            {
                new GradientStop() { Offset = 1, Color = Color.FromRgb(250, 221, 125) },
                new GradientStop() { Offset = 0, Color = Color.FromRgb(252, 204, 45) }
            };

        LinearGradientBrush gradientColor3 = new();
        gradientColor3.GradientStops = new()
            {
                new GradientStop() { Offset = 1, Color = Color.FromRgb(255, 231, 199) },
                new GradientStop() { Offset = 0, Color = Color.FromRgb(252, 182, 159) }
            };

        LinearGradientBrush gradientColor4 = new LinearGradientBrush();
        gradientColor4.GradientStops = new GradientStopCollection()
            {
                new GradientStop() { Offset = 1, Color = Color.FromRgb(221, 214, 243) },
                new GradientStop() { Offset = 0, Color = Color.FromRgb(250, 172, 168) }
            };

        LinearGradientBrush gradientColor5 = new LinearGradientBrush();
        gradientColor5.GradientStops = new GradientStopCollection()
            {
                new GradientStop() { Offset = 1, Color = Color.FromRgb(168, 234, 238) },
                new GradientStop() { Offset = 0, Color = Color.FromRgb(123, 176, 249) }
            };

        List<Brush> brushes = new();
        brushes.Add(gradientColor1);
        brushes.Add(gradientColor2);
        brushes.Add(gradientColor3);
        brushes.Add(gradientColor4);
        brushes.Add(gradientColor5);

        return brushes;

    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion

}