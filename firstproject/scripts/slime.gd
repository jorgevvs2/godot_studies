extends AnimatedSprite2D

const SPEED = 60
var direction = 1

@onready var ray_cast_right: RayCast2D = $RayCastRight
@onready var ray_cast_left: RayCast2D = $RayCastLeft
@onready var slime: AnimatedSprite2D = $"."

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	if(ray_cast_right.is_colliding() || ray_cast_left.is_colliding()):
		direction *= -1
		if(direction < 0):
			slime.flip_h = true
		else:
			slime.flip_h = false
	
	position.x += SPEED * delta * direction
	
