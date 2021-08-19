using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSystem : MonoBehaviour
{
	public InfoUnit selUnit;
	public InfoHUD selHUD;
    // Start is called before the first frame update
    void Start()
    {
        SetupBattle();
    }

    // Update is called once per frame
    public void SetupBattle()
    {
        selUnit.Setup();
        selHUD.SetData(selUnit.monster);
    }
}
