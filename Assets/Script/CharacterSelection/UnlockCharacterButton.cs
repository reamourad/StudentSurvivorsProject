using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockCharacterButton : MonoBehaviour
{
    [SerializeField] private TMP_Text buttonText;
    private void Update()
    {
        buttonText.text = CharacterManager.currentCharacter.isLocked ? "Unlock (" + CharacterManager.currentCharacter.price.ToString() + ")" : "Submit";
    }

    public void onButtonClick()
    {
        if (CharacterManager.currentCharacter.isLocked)
        {
            if (TitleManager.saveData.gold >= CharacterManager.currentCharacter.price)
            {
                TitleManager.saveData.gold -= CharacterManager.currentCharacter.price;
                CharacterManager.currentCharacter.isLocked = false;
            }
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
}
