using Godot;
using System;

public class PlayerMovement : KinematicBody2D, IDamageable
{
    public float gravity = 50f;
    public float speed = 800f;
    public int frameRate = 60;
    public int jumpStrength = -20;

    private Direction direction;

    private Vector2 motion;

    private AnimationNodeStateMachinePlayback playback;

    public override void _Ready()
    {
        motion = new Vector2();
        gravity *= frameRate;
        speed *= frameRate;
        jumpStrength *= frameRate;
        this.playback = ((AnimationTree)this.FindNode("AnimationTree")).playback;
        this.direction = Direction.Right;
    }

    public override void _PhysicsProcess(float delta)
    {
        if (!IsOnFloor())
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
            this.ChangeDirection(Direction.Left);
        }
        else if (Input.IsActionPressed("WalkRight"))
        {
            motion.x = speed * delta;
            this.ChangeDirection(Direction.Right);
        }
        else
        {
            motion.x = 0;
        }
        if (Input.IsActionPressed("Jump"))
        {
            if (IsOnFloor())
            {
                motion.y = jumpStrength;
            }
            else
            {
                if (motion.y <= 0)
                {
                    motion.y += Math.Min(jumpStrength * delta, gravity * delta);
                }
            }
        }
        this.MoveAndSlide(motion, new Vector2(0, -1f));
    }

    private void ChangeDirection(Direction to)
    {
        if(this.direction != to)
        {
                this.Scale = new Vector2(this.Scale.x * -1, this.Scale.y);
                this.direction = to;
        }
    }

    public override void _Process(float delta)
    {
        GD.Print(motion.x);
        if (motion.x != 0)
        {
            this.playback.Travel("Walk");
        }
        else
        {
            this.playback.Travel("Idle");
        }
    }

    public void takeDamage(Vector2 damageFrom)
    {
        throw new NotImplementedException();
    }
}
