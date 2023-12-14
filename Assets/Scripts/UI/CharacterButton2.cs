using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterButton2 : MonoBehaviour
{
  public Button button;
  public Image image;
  public TextMeshProUGUI text;

  public Character mainCharacter;
  public Character tank;

  bool groupedTogether;

    // Start is called before the first frame update
  void Start()
  {
    UpdateCharacterStatus();
    Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
  }

  void Update()
  {
    UpdateCharacterStatus();
    ActivateButton();
  }

  void TaskOnClick()
  {
		tank.focusedTarget = true;
    mainCharacter.focusedTarget = false;
	}

  void ActivateButton()
  {
    if(tank.groupedTogether == true)
    {
      button.enabled = true;
      image.enabled = true;
      text.enabled = true;
    }
  }

  void UpdateCharacterStatus()
  {
    groupedTogether = tank.groupedTogether;
  }
}
