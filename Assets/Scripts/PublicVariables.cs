using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicVariables : MonoBehaviour
{
    public bool isMovingPaper = false;
    public GameState gameStateScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMovingPaper && gameStateScript.gameState == "paper")
        {
            gameStateScript.arrowDown.color = new Color(gameStateScript.arrowDown.color.r, gameStateScript.arrowDown.color.g, gameStateScript.arrowDown.color.b, Mathf.Clamp(gameStateScript.arrowDown.color.a - 0.1f, 0, 1));
            gameStateScript.deletePaperText.color = new Color(gameStateScript.deletePaperText.color.r, gameStateScript.deletePaperText.color.g, gameStateScript.deletePaperText.color.b, Mathf.Clamp(gameStateScript.deletePaperText.color.a - 0.1f, 0, 1));
        }
        else if (isMovingPaper && gameStateScript.gameState == "paper")
        {
            gameStateScript.arrowDown.color = new Color(gameStateScript.arrowDown.color.r, gameStateScript.arrowDown.color.g, gameStateScript.arrowDown.color.b, Mathf.Clamp(gameStateScript.arrowDown.color.a + 0.1f, 0, 1));
            gameStateScript.deletePaperText.color = new Color(gameStateScript.deletePaperText.color.r, gameStateScript.deletePaperText.color.g, gameStateScript.deletePaperText.color.b, Mathf.Clamp(gameStateScript.deletePaperText.color.a + 0.1f, 0, 1));
        }
    }
}
