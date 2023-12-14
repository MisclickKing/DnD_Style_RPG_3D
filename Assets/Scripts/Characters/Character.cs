using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    /*
        CHARACTER VARIABLES
    */

    // Attributes
    public string charName;
    public int health;
    public int currentHealth;
    public int steps;
    public int actionPoints;
    public int bonusActionPoints;

    public string attackType;
    public int damage;
    public float attackRange;


    // Bool varialble
    public bool partyMember;
    public bool groupedTogether;
    
    public bool focusedTarget;
    public bool turnBasedMode;
    public bool hostile;
    public bool myTurn;

    /*
        FUNCTIONS AND METHODS
    */

    // Methods to set variables
    protected void SetCharacterAttributes(string name, int health, int steps, int actionPoints, int bonusActionPoints)
    {
        charName = name;
        this.health = health;
        this.steps = steps;
        this.actionPoints = actionPoints;
        this.bonusActionPoints = bonusActionPoints;
    }

    protected void SetCharacterAttackAttributes(string attack, int damage, float attackRange)
    {
        attackType = attack;
        this.damage = damage;
        this.attackRange = attackRange;
    }

    protected void SetCharacterBooleans(bool isPartyMember, bool isGroupedTogether, bool isFocusedTarget, bool isTurnBasedMode, bool isHostile, bool turn)
    {
        partyMember = isPartyMember;
        groupedTogether = isGroupedTogether;
        focusedTarget = isFocusedTarget;
        turnBasedMode = isTurnBasedMode;
        hostile = isHostile;
        myTurn = turn;
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
    }

    public void DealDamage(Character character, int damageDone)
    {
        character.TakeDamage(damageDone);
    }
}
