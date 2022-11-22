using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLock : MonoBehaviour
{
    public GameObject canvas;
    private Image spriteRenderer;
    private void Start()
    {
        spriteRenderer = this.GetComponent<Image>();
    }
    private void Update()
    {
        spriteRenderer.enabled = canvas.GetComponent<CharacterCanvas>().isLocked; 
    }
}
