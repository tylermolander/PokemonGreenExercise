using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    public int damageToGive;
    int currentDamage;

    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber; //damage numbers prefab, which contains UI text object

    PlayerStats thePlayerStats;

    void Start()
    {
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentDamage = damageToGive + thePlayerStats.currentAttack;
            
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero)); //(gameobject) "casts" the instance into a clone?
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage; //the damage number (a text UI) of the instance is assigned the damage pt of the weapon

        }
    }

}
