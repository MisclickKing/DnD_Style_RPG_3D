using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : Character
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
        SetCharacterAttributes("Zel", 30, 100, 1, 1);
        SetCharacterAttackAttributes("Range", 1, 3);
        SetCharacterBooleans(true, true, true, false, false, false);
        currentHealth = health;
    }
}
