using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public Image arrowDown;
    public Image arrowUp;
    public Text deletePaperText;
    public string gameState = "computer";
    public PublicVariables publicVariables;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.y / Screen.height > 0.9 && gameState == "paper" && !publicVariables.isMovingPaper)
        {
            arrowUp.enabled = false;
            gameState = "cameraUp";
        }
        if (Input.mousePosition.y / Screen.height < 0.1 && gameState == "computer")
        {
            arrowDown.color = new Color(arrowDown.color.r, arrowDown.color.g, arrowDown.color.b, 0);
            gameState = "cameraDown";
        }
        //Input.mousePosition.y / Screen.height > 0.1 
    }
}
