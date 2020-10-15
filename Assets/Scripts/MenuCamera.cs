using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCamera : MonoBehaviour
{
    [Header("Set Dynamically")]
    public static int level;    // The current level

    public void SwitchLevel(int lvl)
    {
        level = lvl;
        SceneManager.LoadScene("GameScene");
    }
}
