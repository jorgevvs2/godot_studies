extends CharacterBody2D

const SPEED = 300.0
const JUMP_VELOCITY = -400.0
var previous_direction = 0
var is_turning = false  # Variável de controle para verificar se o personagem está virando

@onready var animated_sprite: AnimatedSprite2D = $AnimatedSprite2D

func _physics_process(delta: float) -> void:
	# Adicionar gravidade
	if not is_on_floor():
		velocity += get_gravity() * delta

	# Lidar com o pulo
	if Input.is_action_just_pressed("jump") and is_on_floor():
		velocity.y = JUMP_VELOCITY

	# Obter a direção do input e manipular o movimento/velocidade
	var direction := Input.get_axis("move_left", "move_right")
	
	# Se estiver virando, não mudar a animação para "run" até que a animação de "turn" acabe
	if not is_turning:
		if direction == 1 and previous_direction == -1:
			animated_sprite.flip_h = false
			animated_sprite.play("turn")
			is_turning = true  # Inicia o estado de virada
		elif direction == -1 and previous_direction == 1:
			animated_sprite.flip_h = true
			animated_sprite.play("turn")
			is_turning = true  # Inicia o estado de virada
		
		# Apenas troca para "run" quando não está virando
		if is_on_floor():
			if direction == 0:
				animated_sprite.play("idle")
			else:
				animated_sprite.play("run")
		else:
			animated_sprite.play("jump")
	
	# Controle de direção visual
	if direction == 1:
		animated_sprite.flip_h = false
	elif direction == -1:
		animated_sprite.flip_h = true
	
	# Atualiza a velocidade de movimento
	if direction:
		velocity.x = direction * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
	
	previous_direction = direction
	move_and_slide()

# Função chamada quando a animação termina
func _on_animation_finished():
	# Se a animação "turn" terminou, permitir que a animação "run" seja reproduzida
	if animated_sprite.animation == "turn":
		is_turning = false
