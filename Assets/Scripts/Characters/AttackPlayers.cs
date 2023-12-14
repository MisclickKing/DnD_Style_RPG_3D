using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayers : MonoBehaviour
{
    public Character character;
    Character nearestEnemy;
    public string targetTag = "Player";

    // Attack cool down timer
    private float currentCooldown = 0f;
    public float attackCooldown = 3f;
    Character enemyCharacter;


    // Update is called once per frame
    void Update()
    {
        if (currentCooldown > 0)
        {
            // Reduce the cooldown timer
            currentCooldown -= Time.deltaTime;
        }

        if (character.turnBasedMode && character.hostile && currentCooldown <= 0f)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);

            float closestDistance = float.MaxValue;

            foreach (GameObject enemyObject in enemies)
            {
                enemyCharacter = enemyObject.GetComponent<Character>();

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

        // Calculate the target position slightly behind the character
        Vector3 targetPosition = enemyCharacter.transform.position - enemyCharacter.transform.forward * character.attackRange;

        // Move and look at leader
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * .2f);
        transform.LookAt(enemyCharacter.transform);
    }
    
}
