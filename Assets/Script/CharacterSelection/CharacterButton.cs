using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] GameObject characterCanvas;
    [SerializeField] TMP_Text characterText;

    public void onCharacterClick()
    {
        CharacterManager.currentCharacter = characterCanvas.GetComponent<CharacterCanvas>();
        characterText.text = CharacterManager.currentCharacter.characterName + ": " + CharacterManager.currentCharacter.health.ToString() + " health, " + CharacterManager.currentCharacter.speed.ToString() + " base speed, " + CharacterManager.currentCharacter.description;
    }
}
