using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioController audioController;
    [SerializeField] AudioClip audioClip;
    public void StartGame()
    {
        audioController.PlaySfx(audioClip);
        SceneManager.LoadScene("Game");
    }

}
