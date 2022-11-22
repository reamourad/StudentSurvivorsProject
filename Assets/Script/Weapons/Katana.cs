using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : BaseWeapon
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KatanaCoroutine());
    }

    internal override void LevelUp()
    {
        if (++level == 1)
        {
            gameObject.SetActive(true);
        }
        else
        {
            //up the size of your weapon by one
            gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        } 
    }

    IEnumerator KatanaCoroutine()
    {
        while (true)
        {
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
            yield return new WaitForSeconds(2f);
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EnnemyCollision(collision, damage);
    }
}
