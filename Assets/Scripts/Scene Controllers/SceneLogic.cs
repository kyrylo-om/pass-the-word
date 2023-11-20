using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SceneLogic : MonoBehaviour
{
    public Light spotLight;
    public Light pointLight;
    //public GameObject lampLight;
    System.Random rand = new System.Random();
    private bool isFlickering;
    public GameObject paperPrefab;
    Dictionary<string, GameObject> people = new Dictionary<string, GameObject>();

    public Image cursor;
    public bool isPointerOverMonitor;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        Invoke("LightFlicker",rand.Next(1,5));
    }

    // Update is called once per frame
    void Update()
    {
        cursor.transform.position = Input.mousePosition;
        //Debug.Log(people);
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            CreatePerson();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        }

        if (isFlickering)
        {
            double randomIntensity = rand.NextDouble();
            spotLight.intensity = Convert.ToSingle(randomIntensity * 0.3d + 1);
            pointLight.intensity = Convert.ToSingle(randomIntensity * 1d + 2);

        }
    }
    void LightFlicker()
    {
        isFlickering = true;
        Invoke("LightFlickerOff", Convert.ToSingle(rand.NextDouble() * 3));
    }
    void LightFlickerOff()
    {
        isFlickering = false;
        Invoke("LightFlicker", rand.Next(1, 20));
    }

    public void CreatePerson()
    {
        GameObject newPerson =  Instantiate(paperPrefab);
        newPerson.GetComponent<PersonInfo>().Initialize();
        people.Add(newPerson.GetComponent<PersonInfo>().name, newPerson);
    }
    
}
