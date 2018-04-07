extends Node

var scene_change_count = 0

var current_scene = null

var GAME_PATH = "res://scenes/game.tscn"

func _ready():
	var root = get_tree().get_root()
	current_scene = root.get_child( root.get_child_count() -1 )



func startGame(level = "level_1"):
	call_deferred("runGame", level)

func runGame(level):
	current_scene.free()
	var s = ResourceLoader.load(GAME_PATH)
	current_scene = s.instance()
	current_scene.level_name = level
	get_tree().get_root().add_child(current_scene)
	get_tree().set_current_scene( current_scene )




# old dummy test stuff

func get_change_count():
	return scene_change_count

func goto_scene(path, param = ""):
	call_deferred("_deferred_goto_scene",path, param)


func _deferred_goto_scene(path, param):
	scene_change_count = scene_change_count + 1
	current_scene.free()
	var s = ResourceLoader.load(path, param)
	current_scene = s.instance()
	get_tree().get_root().add_child(current_scene)
	get_tree().set_current_scene( current_scene )
