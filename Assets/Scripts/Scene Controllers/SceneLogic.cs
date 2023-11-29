using JetBrains.Annotations;
using OpenCover.Framework.Model;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;
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
    public Dictionary<string, Person> people = new Dictionary<string, Person>();

    public Image cursor;
    public bool isPointerOverMonitor;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        Invoke("LightFlicker",rand.Next(1,5));

        GenerateDatabase();
    }

    // Update is called once per frame
    void Update()
    {
        cursor.transform.position = Input.mousePosition;
        //Debug.Log(people);
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            GeneratePerson();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (string key in people.Keys.ToList())
            {
                Debug.Log("Key: " + key + "; Name: " + people[key].name);
            }
        }

        if (isFlickering)
        {
            double randomIntensity = rand.NextDouble();
            spotLight.intensity = Convert.ToSingle(randomIntensity * 0.3d + 1);
            pointLight.intensity = Convert.ToSingle(randomIntensity * 1d + 1);

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
    
    public void GenerateDatabase()
    {
        for(int i = 0; i < UnityEngine.Random.Range(200,250); i++)
        {
            GeneratePerson();
        }
    }
    public void GeneratePerson()
    {
        Person newPerson = new Person();
        people.Add(newPerson.id, newPerson);
    }

    
}

public class Person
{
    public SceneLogic sceneLogic = new SceneLogic();
    public string id;
    public int age;
    public string gender;
    public string dateOfBirth;
    public string citizenship;
    public string name;
    public Person()
    {
        id = GenerateID();
        while (sceneLogic.people.ContainsKey(id))
        {
            id = GenerateID();
        }
        age = GenerateAge();
        string[] possibleGenders = { "male", "female" };
        gender = possibleGenders[UnityEngine.Random.Range(0, possibleGenders.Length)];
        dateOfBirth = GenerateDateOfBirth(age);
        citizenship = GenerateCitizenship();
        name = GenerateName(gender);
    }
    public string GenerateName(string gender)
    {
        string firstName = "";
        string secondName = "";
        string[] MaleNames = { "Oliver", "Ethan", "Lucas", "Noah", "Mathias", "Daniel", "Miguel", "Arthur", "Sus", "Liam", "James", "John", "Robert", "Michael" };
        string[] FemaleNames = { "Olivia", "Vilgelmina", "Anna" };
        string[] surnames = { "Jones", "Sus" };
        if (gender == "male")
        {
            firstName = MaleNames[UnityEngine.Random.Range(0, MaleNames.Length)];
        }
        else if (gender == "female")
        {
            firstName = FemaleNames[UnityEngine.Random.Range(0, FemaleNames.Length)];
        }
        secondName = surnames[UnityEngine.Random.Range(0, surnames.Length)];

        return (firstName + " " + secondName);
    }
    public int GenerateAge()
    {

        int ageRange = UnityEngine.Random.Range(1, 20);

        if (ageRange < 3) return UnityEngine.Random.Range(14, 17);
        else if (ageRange < 15) return UnityEngine.Random.Range(18, 35);
        else if (ageRange < 19) return UnityEngine.Random.Range(36, 60);

        return UnityEngine.Random.Range(61, 100);
    }
    public string GenerateDateOfBirth(int age)
    {
        string date = Convert.ToString(UnityEngine.Random.Range(1, 29));
        string[] possibleMonths = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        string month = possibleMonths[UnityEngine.Random.Range(0, 11)];
        string year = Convert.ToString(2023 - age);

        return (date + " " + month + ", " + year);
    }
    public string GenerateCitizenship()
    {
        string[] possibleCitizenships = { "United States", "United States", "United States", "United States", "Great Britain", "Great Britain", "Great Britain", "Brazil", "Brazil", "France", "Germany", "China", "Japan", "Italy", "Ukraine", "South Africa", "India", "India", "Canada", "Canada", "Canada", "Australia" };

        return possibleCitizenships[UnityEngine.Random.Range(0, possibleCitizenships.Length)];
    }

    public string GenerateID()
    {
        string possibleChars = "1234567890abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        string result = "";

        for (int i = 0; i < 6; i++)
        {
            result += possibleChars[UnityEngine.Random.Range(0, possibleChars.Length)];
        }
        return result;
    }
}