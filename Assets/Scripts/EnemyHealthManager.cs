using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour 
{


    public int MaxHealth;
    public int CurrentHealth;

    PlayerStats thePlayerStats;

    public int expToGive;

    public string enemyQuestName;
    QuestManager theQM;

    void Start ()
    {
        CurrentHealth = MaxHealth;

        thePlayerStats = FindObjectOfType<PlayerStats>();
        theQM = FindObjectOfType<QuestManager>();
    }
	
    void Update () 
    {
        if (CurrentHealth <= 0)
        {
            theQM.enemyKilled = enemyQuestName;

            Destroy(gameObject);

            thePlayerStats.AddExperience(expToGive);  //when the enemy health is <= zero, add exp to the player
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }

}
