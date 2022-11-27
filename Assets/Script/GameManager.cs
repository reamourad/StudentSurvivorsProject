using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] private GameObject merman;
    [SerializeField] private GameObject zombie;
    [SerializeField] private GameObject giant;
    [SerializeField] private GameObject zombie2;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject level1Background;
    [SerializeField] private GameObject level2Background;
    [SerializeField] private GameObject levelCanvas;
    Volume volume;
    private int level;
    public static DeathData deathData;


    int spawnCounter = 1;
    // Start is called before the first frame update
    void Start()
    {
        volume = Camera.main.GetComponent<Volume>();
        volume.enabled = PostProcessingController.postProcessing; 
        level = CharacterManager.currentCharacter.currentLevel;
        Debug.Log(CharacterManager.currentCharacter.currentLevel);
        deathData = new DeathData();
        StartCoroutine(SpawnEnemyCoroutine());
        if(level == 2)
        {
            level1Background.SetActive(false);
            level2Background.SetActive(true);
        }
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        if(level == 1)
        {
            //First wave 16 seconds
            SpawnEnnemies(merman, 3);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(zombie, 3);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(zombie, 3);
            SpawnEnnemies(giant, 5);
            yield return new WaitForSeconds(5f);

            Time.timeScale = 0;
            levelCanvas.SetActive(true);
            Debug.Log("First wave done!");

            //Second wave 30 seconds
            SpawnEnnemies(merman, 5, true);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(zombie2, 5);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(zombie, 10, true);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(merman, 7);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(zombie2, 7, true);
            yield return new WaitForSeconds(4f);
            SpawnEnnemies(zombie2, 7);
            yield return new WaitForSeconds(10f);
            Debug.Log("Second wave done!");



            //Second wave 30 seconds
            SpawnEnnemies(merman, 5, true);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(zombie2, 5);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(zombie, 10, true);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(merman, 7);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(zombie2, 7, true);
            yield return new WaitForSeconds(4f);
            SpawnEnnemies(zombie2, 7);
            yield return new WaitForSeconds(10f);
            Debug.Log("Second wave done!");

            //Third wave 39 seconds
            SpawnEnnemies(merman, 10);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(zombie2, 10);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(zombie, 11);
            yield return new WaitForSeconds(4f);
            SpawnEnnemies(merman, 12);
            yield return new WaitForSeconds(4f);
            SpawnEnnemies(zombie2, 11, true);
            yield return new WaitForSeconds(4f);
            SpawnEnnemies(zombie2, 12);
            yield return new WaitForSeconds(4f);
            SpawnEnnemies(merman, 10);
            yield return new WaitForSeconds(10f);
            Debug.Log("Third wave done!");

            //Fourth wave 23 seconds
            SpawnEnnemies(merman, 5, false, 2);
            SpawnEnnemies(zombie2, 5, false, 2);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(merman, 5, false, 2);
            SpawnEnnemies(zombie, 5, false, 2);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(merman, 5, true, 2);
            SpawnEnnemies(zombie, 5, true, 2);
            SpawnEnnemies(zombie2, 5, true, 2);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(zombie2, 5, false, 4);
            yield return new WaitForSeconds(8f);
            Debug.Log("Fourth wave done!");

            //Fifth Wave 30 seconds
            SpawnEnnemies(merman, 7, true);
            SpawnEnnemies(zombie, 7, false, 2);
            SpawnEnnemies(zombie2, 10, false, 2);
            yield return new WaitForSeconds(10f);
            SpawnEnnemies(merman, 10, false, 2);
            SpawnEnnemies(zombie, 5, true, 2);
            SpawnEnnemies(zombie2, 7, false, 2);
            yield return new WaitForSeconds(10f);
            SpawnEnnemies(merman, 10, false, 3);
            SpawnEnnemies(zombie, 10, true, 3);
            SpawnEnnemies(zombie2, 10, false, 2);
            yield return new WaitForSeconds(10f);
            Debug.Log("5th wave done!");


            //Sixth Wave
            SpawnEnnemies(merman, 5, false, 2);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(zombie2, 10, false, 2);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(zombie, 10, true);
            SpawnEnnemies(merman, 10, false, 4);
            yield return new WaitForSeconds(10f);
            SpawnEnnemies(merman, 13, false, 2);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(zombie2, 11, true, 4);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(zombie2, 12, false);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(merman, 10, false, 2);
            yield return new WaitForSeconds(10f);
            SpawnEnnemies(merman, 11, false, 4);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(zombie2, 15, false, 2);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(merman, 10, false, 2);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(merman, 20, false, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnnemies(zombie2, 11, true);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(zombie2, 12, false);
            yield return new WaitForSeconds(10f);
            SpawnEnnemies(merman, 10, false, 4);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(merman, 15, false, 2);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(zombie2, 10, false, 3);
            yield return new WaitForSeconds(5f);
            SpawnEnnemies(zombie, 11, true);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(merman, 12, false, 3);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(zombie2, 11, true);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(zombie2, 12, false, 3);
            yield return new WaitForSeconds(3f);
            SpawnEnnemies(merman, 10, false, 2);
            yield return new WaitForSeconds(10f);
            Debug.Log("6th wave done!");

            //Fifth Wave 50 seconds
            SpawnEnnemies(merman, 7, true);
            SpawnEnnemies(zombie, 7, false, 3);
            SpawnEnnemies(zombie2, 10, false, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnnemies(merman, 10, false, 3);
            SpawnEnnemies(zombie, 5, true, 3);
            SpawnEnnemies(zombie2, 7, false, 3);
            yield return new WaitForSeconds(10f);
            SpawnEnnemies(merman, 10, false, 4);
            SpawnEnnemies(zombie, 10, true, 4);
            SpawnEnnemies(zombie2, 10, false, 2);

            Debug.Log("5th wave done!");



            SpawnEnnemies(boss, 1);
            yield return new WaitForSeconds(10f);
        }

        if(level == 2)
        {
            if (player)
            {
                SpawnEnnemies(merman, 15 * spawnCounter, false, spawnCounter);
                yield return new WaitForSeconds(4f);
                SpawnEnnemies(zombie, 15 * spawnCounter, true, spawnCounter);
                yield return new WaitForSeconds(4f);
                spawnCounter++;
            }
        }
        
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            //Timer
            int minutes = (int)Time.timeSinceLevelLoad / 60;
            int seconds = (int)Time.timeSinceLevelLoad % 60;
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }
    }

    public void onLevelButtonClick()
    {
        CharacterManager.currentCharacter.currentLevel++;
        Debug.Log(CharacterManager.currentCharacter.currentLevel);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        //reset everything 
        
    }

    void SpawnEnnemies(GameObject ennemyPrefab, int numberOfEnnemies, bool isWaveTracking = false, int additionalHealth = 0)
    {
        if (player != null)
        {
            for (int i = 0; i < numberOfEnnemies; i++)
            {
                Vector3 spawnPosition = Random.insideUnitCircle.normalized * 8;

                if (isWaveTracking)
                {
                    spawnPosition = new Vector3(10, i, 0);
                }
                spawnPosition += player.transform.position;

                GameObject enemyObject = Instantiate(ennemyPrefab, spawnPosition, Quaternion.identity);
                Ennemy ennemy = enemyObject.GetComponent<Ennemy>();

                ennemy.isTrackingPlayer = !isWaveTracking;
                ennemy.ennemyHP += additionalHealth;
            }

        }
    }

}
