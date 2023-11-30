using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndInitialization : MonoBehaviour
{
    public Animator animator;
    public Canvas movingCanvas;
    public Image earth;
    public Image cursor;
    // Start is called before the first frame update
    void InitializationComplete()
    {
        animator.SetBool("IsPlayingInitAnim",false);
    }

    void Update()
    {
        
    }
}
