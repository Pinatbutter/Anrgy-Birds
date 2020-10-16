using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class levelButtonScript : MonoBehaviour
{
    public Button[] levelButton;
    private ColorBlock colorBlue;


    void Start()
    {
        if(MissionDemolition.hasBeenInitialized)
            checkLevelsPassed();
        
    }

    private void checkLevelsPassed()
    {
        for (int i = 0; i < 2; i++)
        {
            if (PlayerPrefsX.GetIntArray("levelPassed")[i] != 13)
            {
                colorBlue = levelButton[i].colors;
                colorBlue.normalColor = Color.blue;
                colorBlue.highlightedColor = new Color32(115, 115, 255, 255);
                levelButton[i].colors = colorBlue;
            }
        }
    }

}
