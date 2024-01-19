using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private string nameLevel;
    [SerializeField] private GameObject painelInitialMenu;
    [SerializeField] private GameObject painelOptions;

    public void PlayGame()
    {
        SceneManager.LoadScene(nameLevel);
    }

    public void OpenOptions()
    {
        painelInitialMenu.SetActive(false);
        painelOptions.SetActive(true);
    }
    
    public void CloseOptions()
    {
        painelOptions?.SetActive(false);
        painelInitialMenu?.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}   