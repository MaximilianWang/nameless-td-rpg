using System;
using Godot;

public class Splash : Node {
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    private AnimationPlayer animation;
    public override void _Ready () {
        animation = GetNode("start_anim") as AnimationPlayer;
        if (!animation.IsPlaying()) {
            animation.Play("title_intro");
        }
        // Called every time the node is added to the scene.
        // Initialization here

    }
    private void _on_start_pressed () {
        // Replace with function body
		get_node("/root/SceneUtils").startGame("level_1")
    }

    //    public override void _Process(float delta)
    //    {
    //        // Called every frame. Delta is time since last frame.
    //        // Update game logic here.
    //        
    //    }
}