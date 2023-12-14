using UnityEngine;
using UnityEngine.UI;

public class CharacterButton1 : MonoBehaviour
{
    public Button button;

    public Character mainCharacter;
    public Character tank;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        mainCharacter.focusedTarget = true;
		tank.focusedTarget = false;
	}
}
