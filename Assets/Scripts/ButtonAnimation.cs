using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    public RectMask2D mask;
    [SerializeField] private float animSpeed;
    // Start is called before the first frame update
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) {
            if (mask.rectTransform.sizeDelta.x < 700) mask.rectTransform.sizeDelta += new Vector2(animSpeed, 0);
        }
        else
        {
            if (mask.rectTransform.sizeDelta.x > 0) mask.rectTransform.sizeDelta -= new Vector2(animSpeed, 0);
        }
    }
    private void OnMouseOver()
    {
        Debug.Log("dsa");
    }
}
