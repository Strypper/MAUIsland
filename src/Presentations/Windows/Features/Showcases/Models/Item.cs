﻿namespace MAUIsland.Showcases;

public partial class Item : BaseModel
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    string url;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    ItemType type;
}
