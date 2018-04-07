using System;
using Godot;

public class SceneUtils : Node {

    Node currentScene = null;

    string GAME_PATH = "res://scenes/game.tscn";
    public override void _Ready () {

        var root = GetTree ().GetRoot ();
        currentScene = root.GetChild (root.GetChildCount () - 1);
    }

    public void startGame (string level = null) {
        CallDeferred ("runGame", level);

    }

    private void runGame (string level) {

        currentScene.Free ();
        //todo make loading screen
        var scene = ResourceLoader.Load (GAME_PATH) as PackedScene;

        if (scene == null) {
            GD.Print ("Could not load level");
            return;
        }
        currentScene = scene.Instance ();
        if (level != null) {
            currentScene.SetLevel (level); //once game scene loaded, parse set level and use it to create loading screen to load actual level and level scenario
        }
        GetTree().GetRoot().AddChild(currentScene);
        GetTree().SetCurrentScene(currentScene);
    }
    func startGame (level = "level_1"):
        call_deferred ("runGame", level)

    func runGame (level):
        current_scene.free ()
    var s = ResourceLoader.load (GAME_PATH)
    current_scene = s.instance ()
    current_scene.level_name = level
    get_tree ().get_root ().add_child (current_scene)
    get_tree ().set_current_scene (current_scene)

}