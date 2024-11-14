extends Node2D

const EXPLODE = preload("res://assets/explode.wav")

@export var gem_scene: PackedScene
@onready var score: Label = $Score
@onready var timer: Timer = $Timer
@onready var audio_2d_player: AudioStreamPlayer2D = $Audio2DPlayer

var _score: int = 0

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	spawn_gem()

func spawn_gem() -> void:
	var new_gem: Gem = gem_scene.instantiate()
	var xpos: float = randf_range(70, 1050)
	new_gem.on_gem_off_screen.connect(game_over)
	new_gem.position = Vector2(xpos, -50)
	add_child(new_gem)
	
func stop_all() -> void:
	timer.stop()
	for child in get_children():
		child.set_process(false)

func play_game_over() -> void:
	audio_2d_player.stop()
	audio_2d_player.stream = EXPLODE
	audio_2d_player.play()

func game_over() -> void:
	stop_all()
	play_game_over()

func _on_timer_timeout() -> void:
	spawn_gem()

func _on_paddle_area_entered(area: Area2D) -> void:
	_score += 1
	audio_2d_player.position = area.position
	audio_2d_player.play()
	score.text = "%04d" % _score
	area.queue_free()
