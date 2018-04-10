using Godot;
using System;

public abstract class Level : Node
{


    public override void _Ready()
    {
		GD.Print("level ready called");
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

}
