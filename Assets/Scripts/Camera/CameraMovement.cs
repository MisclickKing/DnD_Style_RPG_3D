using UnityEngine;
using System.Linq;

public class CameraMovement : MonoBehaviour
{
    public GameObject targetObj;
    private Transform target;

    private Vector3 cameraOffset;

    public float scrollSpeed = 5f;


    private Vector3 previousPosition;
    private float distanceToTarget = 8f;

    void Awake()
    {
        target = targetObj.transform;
        transform.position = new Vector3(target.position.x, target.position.y + 4.5f, target.position.z - 8f);
        transform.LookAt(target);
    }

    void Start()
    {
        cameraOffset = transform.position - target.position;
    }

    void LateUpdate()
    {
        UpdateTarget();
        CamRotate();
        CamZoom();
    }


    void CamZoom()
    {
        // Set max/min for camera zoom
        distanceToTarget = Mathf.Clamp(distanceToTarget, 4f, 18f);

        // Use mouse wheel to zoom in and out
        float zoomAug = Input.GetAxis("Mouse ScrollWheel");
        distanceToTarget -= zoomAug * scrollSpeed;
    }


    void CamRotate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            previousPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1))
        {
            Vector3 newPosition = Input.mousePosition;
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 0.1f; // Adjust rotation speed

            transform.position = target.position;

            transform.Rotate(Vector3.up, rotationAroundYAxis, Space.World);

            transform.Translate(Vector3.forward * -distanceToTarget);

            previousPosition = newPosition;
        }
        else
        {
            transform.position = target.position;
            transform.Translate(Vector3.forward * -distanceToTarget);
        }
    }

    void UpdateTarget()
    {
        Character[] currentCharacters = FindObjectsOfType<Character>();
        if(currentCharacters != null) {
            Character[] focusedCharacter = currentCharacters.Where(obj => obj.focusedTarget == true).ToArray();
            if(focusedCharacter != null) {
                target =  focusedCharacter[0].transform;
            }
        }
    }
}