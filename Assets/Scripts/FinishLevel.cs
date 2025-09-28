using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private Scene currentScene;
    void Start()
    {
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentScene.name == "Level1")
            {
                Debug.Log("Level Complete!");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
            }
            else if (currentScene.name == "Level2")
            {
                Debug.Log("Game Complete!");
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameFinish");
            }
        }
    }
}
