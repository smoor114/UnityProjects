using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu (fileName = "Monster_", menuName = "Monster/Create new monster")]
public class MonsterBase : ScriptableObject
{
    
    [SerializeField] int m_ID;

    //Info
    [SerializeField] string name;
    [TextArea]
    public string desc;

    //Typing
    [SerializeField] MonsterType type1;
    [SerializeField] MonsterType type2;

    //Stats
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;

    //Sprites
    public Sprite frontSprite;
    //[SerializeField] Sprite backSprite;


    //TYPES
	public enum MonsterType
	{
		None,
		Normal,
		Fire,
		Grass,
		Water,
		Air,
		Dark,
		Light,
		Techno
	}

	public string Name {
    	get {return name;}
    }
    public string Description {
    	get {return desc;}
    }
    public int MaxHP {
    	get {return maxHP;}
    }
    public int Attack {
    	get {return attack;}
    }
    public int Defense {
    	get {return defense;}
    }
    public int Speed {
    	get {return speed;}
    }


	//Stat Increment Functions
	void incr_maxHP()
	{
		maxHP += 1;
	}
	void incr_attack()
	{
		attack += 1;
	}
	void incr_defense()
	{
		defense += 1;
	}
	void incr_speed()
	{
		speed += 1;
	}
}


