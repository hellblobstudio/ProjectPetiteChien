using Godot;
using System;

public class PlayerMovement : KinematicBody2D
{
    public float gravity = 30f;
    public float speed = 500f;
    public int frameRate = 60;
    public int jumpStrength = -900;

    private Vector2 motion;

    public override void _Ready()
    {
        motion = new Vector2();
        gravity *= frameRate;
        speed *= frameRate;
    }

    public override void _PhysicsProcess(float delta)
    {
        if(!IsOnFloor())
        {
            motion.y += gravity * delta;
        }
        else
        {
            motion.y = 0;
        }
        
        if (Input.IsActionPressed("WalkLeft"))
        {
            motion.x = -speed * delta;
        }
        if (Input.IsActionPressed("WalkRight"))
        {
            motion.x = speed * delta;
        }
        if (Input.IsActionPressed("Jump") && IsOnFloor())
        {
            motion.y = jumpStrength;
        }
        this.MoveAndSlide(motion, new Vector2(0, -1f));

        motion.x = 0;
    }
}
