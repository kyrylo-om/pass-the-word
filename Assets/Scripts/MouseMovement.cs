using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseMovement : MonoBehaviour
{
    public Image monitorCursor;
    [SerializeField] private int mouseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(4.2f + monitorCursor.rectTransform.anchoredPosition.x / mouseSpeed, -2, -1f + monitorCursor.rectTransform.anchoredPosition.y / mouseSpeed);
    }
}
