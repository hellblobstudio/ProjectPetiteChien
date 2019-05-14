using Godot;
using System;

public class PlayerMovement : KinematicBody2D
{
    public float gravity = 9.81f;
    public float speed = 200f;
    public int frameRate = 60;

    private Vector2 motion;

    public override void _Ready()
    {
        motion = new Vector2();
        gravity *= frameRate;
        speed *= frameRate;
    }

    public override void _PhysicsProcess(float delta)
    {
        motion.y += gravity * delta;

        if (Input.IsActionPressed("WalkLeft"))
        {
            motion.x = -speed * delta;
        }
        if (Input.IsActionPressed("WalkRight"))
        {
            motion.x = speed * delta;
        }
        if (Input.IsActionPressed("Jump"))
        {

        }
        this.MoveAndSlide(motion, new Vector2(0, -1f));

        motion.x = 0;
    }
}
