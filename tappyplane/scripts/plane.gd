extends CharacterBody2D

class_name Tappy

const GRAVITY: float = 600.0
const POWER: float = -200.0

@onready var animated_sprite_2d: AnimatedSprite2D = $AnimatedSprite2D
@onready var animation_player: AnimationPlayer = $AnimationPlayer
@onready var audio_stream_player_2d: AudioStreamPlayer2D = $AudioStreamPlayer2D

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _physics_process(delta: float) -> void:
	velocity.y += GRAVITY * delta 
	fly()
	move_and_slide()
	
	if is_on_floor() == true:
		die()

func fly() -> void:
	if Input.is_action_just_pressed("fly") == true:
		velocity.y = POWER
		animation_player.play("power")

func die() -> void:
	set_physics_process(false)
	animated_sprite_2d.stop()
	audio_stream_player_2d.stop()
	SignalManager.on_plane_died.emit()
