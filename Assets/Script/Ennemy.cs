using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ennemy : MonoBehaviour
{
    [SerializeField] GameObject crystalPrefab;
    [SerializeField] GameObject health50Prefab;
    [SerializeField] GameObject health25Prefab;
    [SerializeField] GameObject magnetPrefab;
    [SerializeField] GameObject goldPrefab;
    protected GameObject player;
    private bool isFaster = false;
    [SerializeField] private float speed = 0.2F;
    [SerializeField] public int ennemyHP = 3;
    public int currentHP;
    public bool isTrackingPlayer;
    public bool isBoss;
    [SerializeField] GameObject damagePrefab;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] GameObject healthUI;
    private AudioSource audioSource;
    Material material;


    public Slider slider;

    protected virtual void Start()
    {
        currentHP = ennemyHP;
        audioSource = GetComponent<AudioSource>();
        audioSource.time = 0.2f;
        player = GameObject.FindGameObjectWithTag("Player");
        slider.maxValue = ennemyHP;
        slider.value = ennemyHP;
        StartCoroutine(DestroySelfCoroutine());
        material = spriteRenderer.material;
        if (isBoss)
        {
            material.SetFloat("_ColorChange", 30f);
            StartCoroutine(BossCameraCoroutine());
        }
    }

    IEnumerator BossCameraCoroutine()
    {
        //Pause time
        Time.timeScale = 0;
        //Find the PlayerScript on the camera and change the target to the boss
        Camera.main.GetComponent<PlayerCamera>().target = transform;
        //Wait for a few real time seconds
        yield return new WaitForSecondsRealtime(5f);
        //Change the target back to the player
        Camera.main.GetComponent<PlayerCamera>().target = player.transform;
        //Wait for a few real time seconds
        yield return new WaitForSecondsRealtime(5f);
        //Restore time
        Time.timeScale = 1;
    }
    IEnumerator DestroySelfCoroutine()
    {
        if (!isTrackingPlayer)
        {
            yield return new WaitForSeconds(120f);
            Destroy(gameObject);
        }
        
    }
    protected virtual void Update()
    {
        if(player != null)
        {
            //Follow the player
            Vector3 destination = player.transform.position;
            Vector3 source = transform.position;
            Vector3 direction = destination - source;
            if (!isTrackingPlayer)
            {
                direction = new Vector3(-1, 0, 0);
            }
            direction.Normalize();

            transform.position += direction * Time.deltaTime * speed;
            //Making the character turn based on where the player is 
            if (isTrackingPlayer)
            {
                int scaleX = direction.x > 0 ? -1 : 1;
                transform.localScale = new Vector3(scaleX, 1, 1);
            }

        }


    }

    internal virtual void Damage(int damage)
    {
        //Check if dead 
        currentHP -= damage;
        if (isBoss)
        {
            material.SetFloat("_ColorChange", material.GetFloat("_ColorChange") - 0.5f);
            if (currentHP <= (ennemyHP / 2) && !isFaster)
            {
                isFaster = true;
                speed = speed * 2;
                Debug.Log("Sped up");
            }
        }
        if (currentHP <= 0)
        {
            float randomHealth50 = Random.Range(0, 11);
            float randomHealth25 = Random.Range(0, 11);
            float randomMagnet = Random.Range(0, 11);
            float randomGold = Random.Range(0, 11);
            if (randomHealth50 == 1)
            {
                Instantiate(health50Prefab, transform.position, Quaternion.identity);
            }
            else if (randomHealth25 == 1)
            {
                Instantiate(health25Prefab, transform.position, Quaternion.identity);
            }
            else if (randomMagnet == 1)
            {
                Instantiate(magnetPrefab, transform.position, Quaternion.identity);
            }
            else if (randomGold == 1)
            {
                Instantiate(goldPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(crystalPrefab, transform.position, Quaternion.identity);
            }
            audioSource.Play();
            StartCoroutine(SoundCoroutine());

          
        }
        //Display new health
        slider.value = currentHP;
        //display damage
        SpawnDamage(damage);
    }
    IEnumerator SoundCoroutine()
    {
        audioSource.Play();
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;
        healthUI.SetActive(false);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }

    private void SpawnDamage(int damage)
    {
        Vector3 spawnPosition = transform.position + new Vector3(0,1,0);
        damagePrefab.GetComponent<DamagePopUp>().damage = damage.ToString();
        GameObject damageObject = Instantiate(damagePrefab, spawnPosition, Quaternion.identity);
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            if (player.OnDamage())
            {
                if (!isBoss)
                {
                    Destroy(gameObject);
                }
                else
                {
                    //StartCoroutine(gameObject.GetComponent<Boss>().DistortCoroutine());
                }
            }
        }
    }
}