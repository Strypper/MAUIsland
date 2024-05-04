namespace MAUIsland;

public partial class BoolToObjectConverterPage : IGalleryPage
{
    #region [ Fields ]

    private readonly BoolToObjectConverterPageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public BoolToObjectConverterPage(BoolToObjectConverterPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;

    }
    #endregion

    #region [ Event Handlers ]


    private void BasePage_Loaded(object sender, EventArgs e)
    {
        if (NewWindowParameter is not null && viewModel.ControlInformation is null)
        {
            viewModel.SetControlInformation(NewWindowParameter);
            viewModel.RefreshCommand.Execute(null);
        }
    }
    #endregion
}