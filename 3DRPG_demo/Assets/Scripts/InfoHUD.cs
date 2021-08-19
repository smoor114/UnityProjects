using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoHUD : MonoBehaviour
{

	public Text nameText;
	public Text descText;
	public Text levelText;
	public HPBar hpBar;
	public Image spriteView;


    public void SetData(Monster monster) {
    	nameText.text = monster.Base.name;
    	descText.text = monster.Base.desc;
    	levelText.text = "lv " + monster.Level;
    	spriteView.sprite = monster.Base.frontSprite;
    	hpBar.SetHP((float) monster.HP / monster.MaxHP);
    }
}
