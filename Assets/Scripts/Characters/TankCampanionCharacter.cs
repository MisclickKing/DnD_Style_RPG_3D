using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCampanionCharacter : Character
{
     // Start is called before the first frame update
    void Start()
    {
        SetCharacterAttributes("Melanie", 45, 100, 1, 1);
        SetCharacterAttackAttributes("Melee", 8, 4);
        SetCharacterBooleans(true, false, false, false, false, false);
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColors();
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        print(currentHealth);
    }

    void UpdateColors()
    {
        Renderer renderer = GetComponent<Renderer>();

        if(partyMember == true && groupedTogether)
        {
            renderer.material.color = Color.green; 
        }
        else if(hostile == true)
        {
            renderer.material.color = Color.red; 
        } 
        else
        {
            renderer.material.color = Color.yellow; 
        }
    }
}
