using System;
using UnityEngine;

public class CharacterRayCast : MonoBehaviour
{
    public Character character;
    public GameObject gameLogic;

    bool groupedTogether;
    bool turnBasedMode;

    public float sightRange = 10f;
    Ray theRay;


    // Update is called once per frame
    void Update()
    {
        CreateRayCast();
        UpdateCharacterStatus();
        IfSeen();
    }

    void CreateRayCast()
    {
        Vector3 direction = Vector3.forward;
        theRay = new Ray(transform.position, transform.TransformDirection(direction * sightRange));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * sightRange));
    }

    void IfSeen()
    {
        if(Physics.Raycast(theRay, out RaycastHit hit, sightRange))
        {
            // If not an enemy
            if (tag != "Enemy")
            {
                // Join party
                if(hit.collider.tag == "Player" && character.groupedTogether == false)
                {
                    character.groupedTogether = true;
                }
            }
            // If it is an enemy
            else if(tag == "Enemy")
            {
                if(hit.collider.tag == "Player" && character.turnBasedMode == false)
                {
                    TurnBasedOn();
                }
            }
        }
    }

    void UpdateCharacterStatus()
    {
        groupedTogether = character.groupedTogether;
        turnBasedMode = character.turnBasedMode;
    }

    void TurnBasedOn()
    {
        Character[] currentCharacters = FindObjectsOfType<Character>();

        foreach (Character character in currentCharacters)
        {
            if (character != null)
            {
                character.turnBasedMode = true;
            }
        }
    }
}
