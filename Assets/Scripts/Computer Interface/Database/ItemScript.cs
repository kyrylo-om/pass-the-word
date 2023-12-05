using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    private bool isMouseOver;
    [SerializeField] private Image itemGlow;
    // Start is called before the first frame update
    void Start()
    {
        isMouseOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseOver && itemGlow.color.a < 0.3f)
        {
            itemGlow.color += new Color(0, 0, 0, 0.1f);
        }
        if (!isMouseOver && itemGlow.color.a > 0)
        {
            itemGlow.color -= new Color(0, 0, 0, 0.1f);
        }
    }

    public void MouseEnter()
    {
        isMouseOver = true;
    }
    public void MouseExit()
    {
        isMouseOver = false;
    }
}
