using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUnit : MonoBehaviour
{
    public MonsterBase _base;
    public int level;

    public Monster monster { get; set; }

    public void Setup()
    {
    	new Monster(_base, level);
    }
}
