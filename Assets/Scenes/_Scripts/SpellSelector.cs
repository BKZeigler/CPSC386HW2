using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Scripting;

public class SpellSelector : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ReSelectField()
    {
        inputField.ActivateInputField();
    }
}
