using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] Enemies;

    int EnemyCount;

    private void Awake()
    {
       int ManagersInGame = GameObject.FindObjectsOfType<GameManager>().Length;
       if(ManagersInGame > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        EnemyCount = Enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //We need to pause the game if EnemyCount is less than 1. Use a version of Unreal's delegates.
        //We pause the game with Time.timeScale = 0;
        //Another way would be to have a boolean called IsGamePaused. If its false
    }

    public void GameStart()
    {
        SceneManager.LoadScene(0);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject.Find("Canvas").SetActive(false);

        foreach(GameObject Enemy in Enemies)
        {
            float minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
            float maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;

            float PositionOfEnemyInX = Random.Range(minX, maxX);

            Instantiate(Enemy, new Vector2(PositionOfEnemyInX, 1.2f), Quaternion.identity);
        }
    }
}
