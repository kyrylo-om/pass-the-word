using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraLook: MonoBehaviour
{
    public Camera Camera;   
    public GameState gameStateScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStateScript.gameState == "cameraDown")
        {
            Camera.transform.Rotate(3, 0, 0);
            if(Camera.transform.rotation.x >= 0.6f)
            {
                gameStateScript.arrowUp.enabled = true;
                gameStateScript.gameState = "paper";
            }
        }
        if (gameStateScript.gameState == "cameraUp")
        {
            Camera.transform.Rotate(-3, 0, 0);
            if (Camera.transform.rotation.x <= 0.07f)
            {
                gameStateScript.arrowDown.color = new Color(gameStateScript.arrowDown.color.r, gameStateScript.arrowDown.color.g, gameStateScript.arrowDown.color.b, 1);
                gameStateScript.gameState = "computer";
            }
        }
    }
}
