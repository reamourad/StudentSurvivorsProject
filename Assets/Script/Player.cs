using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5F;
    Animator animator; 
    public static int maxHp;
    public static int hp;
    public bool isInvincible = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    public bool isAlive = true;
    internal int currentExp;
    internal int expToLevel = 5;
    internal int currentLevel;
    public BaseWeapon[] weapons;
    [SerializeField] GameObject upgradeMenu;
    private AudioSource audioSource;
    Volume volume;
    DepthOfField depthOfField;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        //Update to chosen character
        spriteRenderer.sprite = CharacterManager.currentCharacter.sprite;
        maxHp = CharacterManager.currentCharacter.health;
        speed = CharacterManager.currentCharacter.speed;
        int weaponInt = CharacterManager.currentCharacter.baseWeapon;
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = CharacterManager.currentCharacter.controller;


        weapons[weaponInt].LevelUp();
        
        audioSource = GetComponent<AudioSource>();
        hp = maxHp;
        volume = Camera.main.GetComponent<Volume>();
        volume.profile.TryGet(out depthOfField);

        foreach (BaseWeapon weapon in weapons)
        {
            weapon.damage += TitleManager.saveData.damagePermanent;
        }
        speed += TitleManager.saveData.speedPermanent;
        material = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Im updating!");

        //Movement
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        transform.position += new Vector3(inputX, inputY) * speed * Time.deltaTime;

        if (inputX != 0)
        {
            transform.localScale = new Vector3(inputX > 0 ? -1 : 1, 1, 1);
        }

        bool isRunning = (inputX != 0 || inputY != 0); //if im moving bool is true
        animator.SetBool("isRunning", isRunning);

    }
    public bool OnDamage()
    {
        if (!isInvincible)
        {
            //StartCoroutine(Camera.main.GetComponent<PlayerCamera>().ShakeCoroutine(1, 0.5f));
            //Becomes invicible
            StartCoroutine(InvisibleCoroutine());
            //Check if dead
            if (--hp <= 0)
            {
                SceneManager.LoadScene("Title");
                Destroy(gameObject);
            }
            return true;
        }
        return false;      
    }

    IEnumerator InvisibleCoroutine()
    {
        isInvincible = true;
        spriteRenderer.color = Color.red;
        //material.SetFloat("_Flash", 0.33f);
        yield return new WaitForSeconds(0.5F);
        //material.SetFloat("_Flash", 0f);
        spriteRenderer.color = Color.white;
        isInvincible = false;
    }

    internal void AddExp()
    {
        currentExp++;
        if(currentExp >= expToLevel)
        {
            currentExp = 0;
            expToLevel += 5;
            currentLevel++;

            audioSource.Play();
            depthOfField.mode.Override((DepthOfFieldMode)1); 
            upgradeMenu.SetActive(true);
            upgradeMenu.GetComponent<UpgradeMenu>().createUpgrades();
        }

    }

    internal void Add50Health()
    {
        int healthToAdd = maxHp/2;
        if(healthToAdd + hp >= maxHp)
        {
            hp = maxHp;
        }
        else
        {
            hp += healthToAdd;
        }
    }

    internal void Add25Health()
    {
        int healthToAdd = maxHp / 4;
        if (healthToAdd + hp >= maxHp)
        {
            hp = maxHp;
        }
        else
        {
            hp += healthToAdd;
        }
    }

    public float GetHpRatio()
    {
        return (float)hp / maxHp;
    }
}