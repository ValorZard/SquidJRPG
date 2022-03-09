extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

class Character:
	var name: String
	var health: int
	var mana: int
	var damage: int
	
	func _init():
		name = "NONE"
		health = 10
		mana = 5
		damage = 2
	
	func _to_string() -> String:
		var character_string := name
		character_string += "\n Health: " + str(health) + " Mana: " + str(mana) 
		return character_string

class Enemy:
	var name: String
	var health: int
	var damage: int
	
	func _init():
		name = "NONE"
		health = 10
		#mana = 5
		damage = 2
	
	func _to_string() -> String:
		var enemy_string := name
		enemy_string += "\n Health: " + str(health)
		return enemy_string

var character : Character
var enemy : Enemy

# Called when the node enters the scene tree for the first time.
func _ready():
	# character data
	character = Character.new()
	character.name = "Jack"
	# enemy data
	enemy = Enemy.new()


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	$Panel/CharacterData/Character1Label.text = str(character)
	$"Panel/Enemy Data/Enemy1Label".text = str(enemy)


func _on_AttackButton_pressed():
	enemy.health -= character.damage


func _on_SpellButton_pressed():
	if character.mana > 0:
		enemy.health -= character.damage * 2
		character.mana -= 1
