using Godot;
using System;

public class Character
{
    public string name { get; }
    public int health, mana, damage;

    // Constructor that takes one argument:
    public Character(string name = "unknown", int health = 10, int mana = 5, int damage = 2)
    {
        this.name = name;
        this.health = health;
        this.mana = mana;
        this.damage = damage;
    }

    // Constructor that takes no arguments:
    // public Character()
    // {
    //     Character("unknown");
    // }

    // Auto-implemented readonly property:

    // Method that overrides the base class (System.Object) implementation.
    public override string ToString()
    {
        string s = "";
        s += name;
        s += "\nHealth: " + health.ToString() + " Mana: " + mana.ToString();
        return s;
    }
}

public class Enemy
{
    public string name { get; }
    public int health, damage;

    // Constructor that takes one argument:
    public Enemy(string name = "unknown", int health = 10, int damage = 2)
    {
        this.name = name;
        this.health = health;
        this.damage = damage;
    }

    // Auto-implemented readonly property:

    // Method that overrides the base class (System.Object) implementation.
    public override string ToString()
    {
        string s = "";
        s += name;
        s += "\nHealth: " + health.ToString();
        return s;
    }
}


public class BattleScript : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    //[Export]
    public Character character;
    //[Export]
    public Enemy enemy;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        character = new Character("Jack");
        enemy = new Enemy();
    }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
      Label characterLabel = (Label) GetNode("Panel/CharacterData/Character1Label");
      characterLabel.Text = character.ToString();
      Label enemyLabel = (Label) GetNode("Panel/EnemyData/Enemy1Label");
      enemyLabel.Text = enemy.ToString();
    }

    public void _on_AttackButton_pressed()
    {
        enemy.health -= character.damage;
    }

    public void _on_SpellButton_pressed()
    {
        if (character.mana > 0)
        {
            enemy.health -= character.damage * 2;
            character.mana -= 1;
        }
    }
}
