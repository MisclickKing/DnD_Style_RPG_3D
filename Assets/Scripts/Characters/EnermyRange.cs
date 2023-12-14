using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyRange : Character
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
        SetCharacterAttributes("Range Enemy", 25, 100, 1, 1);
        SetCharacterAttackAttributes("Range", 3, 20);
        SetCharacterBooleans(false, false, false, false, true, false);
        currentHealth = health;
    }
}
