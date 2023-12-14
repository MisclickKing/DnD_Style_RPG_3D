using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Character
{
    // Start is called before the first frame update
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        print(currentHealth);
    }


    void Start()
    {
        SetCharacterAttributes("Melee Enemy", 25, 100, 1, 1);
        SetCharacterAttackAttributes("Melee", 3, 2);
        SetCharacterBooleans(false, false, false, false, true, false);
        currentHealth = health;
    }
}
