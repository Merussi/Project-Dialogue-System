using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] CoreGame coreGame;
    [SerializeField] EndScreen endScreen;
    [SerializeField] private string nameLevel;

    void Start()
    {
        coreGame= FindObjectOfType<CoreGame>();
        endScreen = FindObjectOfType<EndScreen>();

        coreGame.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);

      
    }


    public void OnEndGame()
    {
      
        endScreen.gameObject.SetActive(true);
        coreGame.gameObject.SetActive(false);
    }

    public void OnReplayGame()
    {
        SceneManager.LoadScene(nameLevel);
    }
}
