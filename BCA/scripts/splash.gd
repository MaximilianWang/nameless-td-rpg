extends Node

# class member variables go here, for example:
# var a = 2
# var b = "textvar"
onready var anim = get_node("start_anim")

func _ready():
	# Called every time the node is added to the scene.
	# Initialization here
	if(not anim.is_playing()):
    	anim.play("title_intro")
	
	pass

#func _process(delta):
#	# Called every frame. Delta is time since last frame.
#	# Update game logic here.
#	pass



func _on_start_pressed():
	get_node("/root/scene_manager").startGame("level_1")
