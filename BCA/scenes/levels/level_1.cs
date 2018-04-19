using System;
using Godot;

public class level_1 : Level {
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    private BaseLevelScenario localScenario;

    public override void _Ready () {
        GD.Print ("level 1 ready called");
        var children = GetChildren ();
        for (int i = 0; i < children.Length; i++) {
            if (children[i] is BaseLevelScenario) {
                localScenario = (BaseLevelScenario) children[i];
                break;
            }
        }

        // Called every time the node is added to the scene.
        // Initialization here

    }

    public override void start (bool skipScenario) {
        if (localScenario != null) {
            localScenario.start ();
        }
    }

    //    public override void _Process(float delta)
    //    {
    //        // Called every frame. Delta is time since last frame.
    //        // Update game logic here.
    //        
    //    }
}