using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class CharacterMovement : MonoBehaviour
{
    // Reference scripts
    public Character character;

    // Get componenets
    public NavMeshAgent characterNav;
    public Camera cam;

    // Variables
    bool focusedTarget;
    bool partyMember;
    bool turnBasedMode;
    bool groupedTogether;

     public float followDistance = 2f;
     public Character leader;


    // Start is called before the first frame update
    void Start()
    {
        findCharacters();
        characterNav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        findCharacters();
        UpdateCharacterStatus();
        MovePlayer();
    }

    // Move character
    void MovePlayer()
    {
        // If character in party
        if(partyMember && groupedTogether)
        {
            // If player is controlling this character directly and is not in turnbased mode
            if(focusedTarget)
            {
                // Check if left mouse button clicked
                if(Input.GetMouseButton(0))
                {
                    // Cast a ray from the position of mouse cursor on-screen toward the 3D scene
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit) && NavMesh.SamplePosition(hit.point, out NavMeshHit navMeshHit, 1.0f, NavMesh.AllAreas))
                    {
                        // Set the destination for the NavMeshAgent to the clicked position
                        characterNav.SetDestination(navMeshHit.position);
                    }
                }
            }
            // If character is NPC and in the party 
            if(!focusedTarget)
            {
                // Calculate the target position slightly behind the character
                Vector3 targetPosition = leader.transform.position - leader.transform.forward * followDistance;

                // Move and look at leader
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 3f);
                transform.LookAt(leader.transform);
            }
        }
    }

    void UpdateCharacterStatus()
    {
        focusedTarget = character.focusedTarget;
        partyMember = character.partyMember;
        turnBasedMode = character.turnBasedMode;
        groupedTogether = character.groupedTogether;
    }


    void findCharacters()
    {
        Character[] currentCharacters = FindObjectsOfType<Character>();
        if(currentCharacters != null) {
            Character[] focusedCharacter = currentCharacters.Where(obj => obj.focusedTarget == true).ToArray();
            if(focusedCharacter != null) {
                leader =  focusedCharacter[0];
            }
        }
    }

    // END OF CODE
}
