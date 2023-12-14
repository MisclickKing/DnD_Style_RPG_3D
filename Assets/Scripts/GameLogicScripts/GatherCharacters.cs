using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherCharacters : MonoBehaviour
{
    Character[] currentCharacters;

    // Start is called before the first frame update
    void Start()
    {
        currentCharacters = FindObjectsOfType<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
