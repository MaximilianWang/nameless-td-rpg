using System;
using Godot;

public class Game : Node {
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    private string levelName = "level_1";
    private Level currentLevel;

    public void setLevelName (string l) {
        levelName = l;
    }

    public override void _Ready () {
        GD.Print ("game ready called");
        if (!loadLevel ()) {
            //failed to load level, go back to main menu
        }
        
        currentLevel.start(false);
        
        // Called every time the node is added to the scene.
        // Initialization here

    }

    private bool loadLevel () {

        var scn = ResourceLoader.Load ("res://scenes/levels/level_1.tscn") as PackedScene;
        var inst = scn.Instance ();
        if (!(inst is Level)) {
            GD.Print ("Next level loaded " + currentLevel.GetClass () + " is wrong type");
            return false;
        }
        GD.Print ("DSADSA");
        currentLevel = (Level) inst;

        AddChild (currentLevel);
        MoveChild (currentLevel, 0);
        return true;
    }

    //    public override void _Process(float delta)
    //    {
    //        // Called every frame. Delta is time since last frame.
    //        // Update game logic here.
    //        
    //    }
}