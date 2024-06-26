using Godot;
using System;
using System.Reflection.Metadata;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer animPlayerNode;
    [Export] private Sprite3D sprite3DNode;
    private Vector2 direction = new();

    public override void _Ready()
    {
        animPlayerNode.Play(GameCosntants.ANIM_IDLE);
    }
    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= 5;

        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(      
            GameCosntants.INPUT_MOVE_LEFT, GameCosntants.INPUT_MOVE_RIGHT, GameCosntants.INPUT_MOVE_FORWARD, GameCosntants.INPUT_MOVE_BACKWARD
        );
        if(direction == Vector2.Zero)
        {
            animPlayerNode.Play(GameCosntants.ANIM_IDLE);
        }
        else
        {
            animPlayerNode.Play(GameCosntants.ANIM_Move);
        }
    }
}
