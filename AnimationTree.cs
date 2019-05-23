using Godot;
using System;

public class AnimationTree : Godot.AnimationTree
{
    public AnimationNodeStateMachinePlayback playback;

    public override void _Ready()
    {
        this.playback = (AnimationNodeStateMachinePlayback)this.Get("parameters/playback");
        this.playback.Start("Idle");
    }
}
