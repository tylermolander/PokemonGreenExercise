using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    PlayerStats thePlayerStats;
    public Text LevelText;

    static bool UIExists;


	void Start () 
	{
	    if (!UIExists)
	    {
	        UIExists = true;
	        DontDestroyOnLoad(transform.gameObject);
	    }
	    else
	    {
	        Destroy(gameObject);
	    }

	    thePlayerStats = GetComponent<PlayerStats>();
	}
	
	void Update ()
	{
	    healthBar.maxValue = playerHealth.playerMaxHealth;
	    healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        LevelText.text = "LV: " + thePlayerStats.currentLevel;
	}
}
