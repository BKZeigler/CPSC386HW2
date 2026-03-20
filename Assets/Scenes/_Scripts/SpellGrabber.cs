using TMPro;
using UnityEngine;

public class SpellGrabber : MonoBehaviour
{

    [SerializeField] private string inputText;

    [SerializeField] private TMP_InputField inputField;
    SpellChecker spellChecker;

    public void Awake()
    {
        spellChecker = FindFirstObjectByType<SpellChecker>(); // find spell checker
    }

    public void GrabSpellFromInput(string input) // Grabs spell name input by player and calls to spellchecker to check it
    {
        inputText = input.ToUpper(); // makes typed spell uppercase to match database names
        spellChecker.CheckSpell(inputText); // calls spells checkers CheckSpell
        inputField.text = ""; // reset input text after checking
    }

}
