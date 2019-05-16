extends Camera2D

var player;

func _ready():
	player = get_parent().find_node("Player")
	print(player)
	

func _physics_process(delta):
	self.global_position = lerp(self.global_position, player.global_position, 0.2)