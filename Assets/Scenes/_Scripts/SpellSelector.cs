using UnityEngine;
using TMPro;

public class SpellSelector : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    public void ReSelectField()
    {
        inputField.ActivateInputField(); // reselect input field after spell is launched so player can type again without clicking
    }
}
