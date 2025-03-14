﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

using System.Linq;

// level 5 on pc. 8
public enum GameMode
{                                                         // b
    idle,
    playing,
    levelEnd
}
public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S; // a private Singleton

    [Header("Set in Inspector")]
    public Text uitLevel;  // The UIText_Level Text
    public Text uitShots;  // The UIText_Shots Text
    public Text uitButton; // The Text on UIButton_View
    public Vector3 castlePos; // The place to put castles
    public GameObject[] castles;   // An array of the castles
    public AudioScript audioManager;

    [Header("Set Dynamically")]
    public static int level;    // The current level
    public int levelMax;  // The number of levels
    public int shotsTaken;
    public GameObject castle;    // The current castle
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot"; // FollowCam mode


    public static bool hasBeenInitialized = false;
    private static int[] lvlArray = new int[12];

    void Start()
    {
        S = this; // Define the Singleton
        levelMax = castles.Length;

        audioManager.PlayBackground();

        StartLevel();
        if (hasBeenInitialized == false)
        {
            for (int i = 0; i < 12; i++)
            {
                lvlArray[i] = 13;
            }
            hasBeenInitialized = true;
        }

    }
    void StartLevel()
    {
        // Get rid of the old castle if one exists
        if (castle != null)
        {
            Destroy(castle);
        }

        // Destroy old projectiles if they exist
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }

        StartCoroutine(CastleSleepCoroutine());
        // Instantiate the new castle
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;

        // Reset the camera
        SwitchView("Show Both");
        ProjectileLine.S.Clear();

        // Reset the goal
        Goal.goalMet = false;

        UpdateGUI();

        mode = GameMode.playing;

    }
    IEnumerator CastleSleepCoroutine()
    {
        yield return new WaitForSeconds(0.05f);

        var walls = GameObject.FindGameObjectsWithTag("WallSimple");
        var slabs = GameObject.FindGameObjectsWithTag("Slab");
        var combined = walls.Concat(slabs);

        foreach (var gameObj in combined)
        {
            Rigidbody rb = gameObj.GetComponent<Rigidbody>();
            rb.Sleep();
        }
    }


    public void RestartLevel()
    {
        audioManager.PlayRestart();
        StartLevel();
    }

    void UpdateGUI()
    {
        // Show the data in the GUITexts
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }

    void Update()
    {
        Goal.checkPigs();

        if (Goal.goalMet)
        {
            lvlArray[level] = level;
        }
        UpdateGUI();

        // Check for level end
        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            // Change mode to stop checking for level end
            mode = GameMode.levelEnd;
            // Zoom out
            SwitchView("Show Both");
            // Start the next level in 2 seconds
            Invoke("NextLevel", 2f);
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            PlayerPrefsX.SetIntArray("levelPassed", lvlArray);
            SceneManager.LoadScene("Menu");
        }
    }

    void NextLevel()
    {
        audioManager.PlayYouWin();
        if (level == (levelMax - 1))
        {
            PlayerPrefsX.SetIntArray("levelPassed", lvlArray);
            SceneManager.LoadScene("Menu");
        }
        else
        {
            level++;
            StartLevel();
        }
    }
    public void SwitchLevel(int lvl)
    {
        level = lvl;
        SceneManager.LoadScene("GameScene");
    }


    public void SwitchView(string eView = "")
    {                                    // c
        if (eView == "")
        {
            eView = uitButton.text;
        }
        showing = eView;
        switch (showing)
        {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Castle";
                break;

            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButton.text = "Show Both";
                break;

            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;

        }
    }

    // Static method that allows code anywhere to increment shotsTaken
    public static void ShotFired()
    {                                            // d
        S.shotsTaken++;
    }
}
