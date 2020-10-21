using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCamera : MonoBehaviour
{
    public AudioScript audioManager;
    public void SwitchLevel(int lvl)
    {
        SceneManager.LoadScene("GameScene");
        MissionDemolition.level = lvl;
    }
    void Start()
    {
        audioManager.PlayBackground();
    }
}
