using System;
using Godot;

public class SceneUtils : Node {

    private Node currentScene = null;

    private int waitFrame = 0;

    private int maxWait = 100;

    private ResourceInteractiveLoader loader;


    private static string GAME_PATH = "res://scenes/game.tscn";
    public override void _Ready () {

        var root = GetTree ().GetRoot ();
        currentScene = root.GetChild (root.GetChildCount () - 1);
    }

    public void startGame (string level = null) {
        CallDeferred ("runGame", level);

    }

    public override void _Process(float delta) {

        if (loader == null) {
            GD.Print("Loader done");
            //no need for processing anymore
            SetProcess(false);
            return;
        }

        if (waitFrame > 0) {
            //buffer for loading animation scene to appear
            waitFrame -= 1;
            return;
        }

        var t = OS.GetTicksMsec();
        while (OS.GetTicksMsec()  < (t + maxWait)) {
            var loadStatus = loader.Poll();

            if (loadStatus == Error.FileEof) {
                //load complete
                var scene = loader.GetResource() as PackedScene;

                Node newInstance = scene.Instance();
                loader = null;

                //do any stuff specific to any nodes
                 

                setNewScene(newInstance);

            }
        }
        
    } 

    private void setNewScene(Node scene) {
        GD.Print("Setting to new scene");

        currentScene = scene;
        

        GetTree().GetRoot().AddChild(currentScene);
        //GetTree().SetCurrentScene(currentScene);
        

    }
    private void runGame (string level) {

        //todo make loading screen
        loader = ResourceLoader.LoadInteractive (GAME_PATH);

        if (loader == null) {
            GD.Print ("Could not load level");
            return;
        }
        GD.Print("Loading for level: " + level + " began");
        SetProcess(true);
        currentScene.QueueFree();
        waitFrame = 1;
    }
}