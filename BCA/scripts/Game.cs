using Godot;
using System;

public class Game : Node
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    private string levelName = "level_1";
    private Node currentLevel;

    public void setLevelName(string l) {
        levelName = l;
    }   

    public override void _Ready()
    {
		GD.Print("game ready called");
        loadLevel();
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

    private void loadLevel() {

        var scn = ResourceLoader.Load("res://scenes/levels/level_1.tscn") as PackedScene;
        currentLevel = scn.Instance();
        GD.Print("Next level loaded " + currentLevel.GetClass());
        AddChild(currentLevel);
        MoveChild(currentLevel, 0);
        
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
