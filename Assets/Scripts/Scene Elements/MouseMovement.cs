using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseMovement : MonoBehaviour
{
    public Image monitorCursor;
    [SerializeField] private int mouseSpeed;
    private bool isKeyDownAnim;
    [SerializeField] private GameObject mouseButton1;
    [SerializeField] private GameObject mouseButton2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(6f + monitorCursor.rectTransform.anchoredPosition.x / mouseSpeed, -2.1f, -0f + monitorCursor.rectTransform.anchoredPosition.y / mouseSpeed);

        if (Input.GetKeyDown(KeyCode.Mouse0)) mouseButton1.transform.localPosition = new Vector3(0, -0.017f, 0);
        if (Input.GetKeyDown(KeyCode.Mouse1)) mouseButton2.transform.localPosition = new Vector3(0, -0.017f, 0);

        if (Input.GetKeyUp(KeyCode.Mouse0)) mouseButton1.transform.localPosition = new Vector3(0, 0, 0);
        if (Input.GetKeyUp(KeyCode.Mouse1)) mouseButton2.transform.localPosition = new Vector3(0, 0, 0);
    }
}
