using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemies : MonoBehaviour
{
    public Character character;
    public CharacterMovement charMove;
    Character nearestEnemy;
    public string targetTag = "Enemy";

    // Attack cool down timer
    private float currentCooldown = 0f;
    public float attackCooldown = 10f;


    // Update is called once per frame
    void Update()
    {
        if (currentCooldown > 0)
        {
            // Reduce the cooldown timer
            currentCooldown -= Time.deltaTime;
        }

        if (character.turnBasedMode && character.focusedTarget && currentCooldown <= 0f)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);

            float closestDistance = float.MaxValue;

            foreach (GameObject enemyObject in enemies)
            {
                Character enemyCharacter = enemyObject.GetComponent<Character>();

                if (enemyCharacter != null)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemyObject.transform.position);

                    // Check if this enemy is closer than the current nearest one
                    if (distanceToEnemy < closestDistance && distanceToEnemy < character.attackRange)
                    {
                        closestDistance = distanceToEnemy;
                        nearestEnemy = enemyCharacter;
                    }
                }
            }

            // Engage the nearest enemy if conditions are met
            if (nearestEnemy != null)
            {
                character.DealDamage(nearestEnemy, character.damage);
                currentCooldown = attackCooldown;
            }
        }
        if (character.turnBasedMode && !character.focusedTarget && currentCooldown <= 0f)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);

            float closestDistance = float.MaxValue;

            foreach (GameObject enemyObject in enemies)
            {
                Character enemyCharacter = enemyObject.GetComponent<Character>();

                if (enemyCharacter != null)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemyObject.transform.position);

                    // Check if this enemy is closer than the current nearest one
                    if (distanceToEnemy < closestDistance && distanceToEnemy < character.attackRange)
                    {
                        closestDistance = distanceToEnemy;
                        nearestEnemy = enemyCharacter;
                    }
                }
            }

            // Engage the nearest enemy if conditions are met
            if (nearestEnemy != null)
            {
                character.DealDamage(nearestEnemy, character.damage);
                currentCooldown = attackCooldown;
            }
        }
    }
    
}
