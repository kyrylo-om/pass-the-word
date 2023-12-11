using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    private bool isMouseOver;
    [SerializeField] private Image itemGlow;
    public Person attachedPerson;
    public ComputerInteractions computerInteractions;
    // Start is called before the first frame update
    void Start()
    {
        computerInteractions = GameObject.FindGameObjectWithTag("Computer Interface").GetComponent<ComputerInteractions>();
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
    public void OpenPersonInfo()
    {
        computerInteractions.OpenPersonInfo(attachedPerson.name, attachedPerson.age, attachedPerson.gender, attachedPerson.citizenship, attachedPerson);
    }
}
