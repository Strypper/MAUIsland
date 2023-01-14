﻿using MAUIsland.Animations;

namespace MAUIsland.Triggers;

[ContentProperty("Animation")]
public class BeginAnimation : TriggerAction<VisualElement>
{
    public AnimationBase Animation { get; set; }

    protected override async void Invoke(VisualElement sender)
    {
        if (Animation != null)
            await Animation.Begin();
    }
}
