using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public MonsterBase Base { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }

    public Monster(MonsterBase m_Base, int m_Level)
    {
    	Base = m_Base;
    	Level = m_Level;
        HP = MaxHP;
    }

    public int MaxHP {
    	get {return Mathf.FloorToInt((Base.MaxHP * Level) / 100f)+10;}
    }
    public int Attack {
    	get {return Mathf.FloorToInt((Base.Attack * Level) / 100f)+5;}
    }
    public int Defense {
    	get {return Mathf.FloorToInt((Base.Defense * Level) / 100f)+5;}
    }
    public int Speed {
    	get {return Mathf.FloorToInt((Base.Speed * Level) / 100f)+5;}
    }
}
