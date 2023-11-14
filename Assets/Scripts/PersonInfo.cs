using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonInfo : MonoBehaviour
{

    public string name;
    public int age;
    public string gender;
    public string dateOfBirth;
    public string citizenship;
    public string id;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        string[] possibleGenders = { "male", "female" };
        
        age = GenerateAge();
        gender = possibleGenders[UnityEngine.Random.Range(0, possibleGenders.Length)];
        name = GenerateName(gender);
        dateOfBirth = GenerateDateOfBirth(age);
        citizenship = GenerateCitizenship();
        id = GenerateID();

        transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = name;
        transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().text = age.ToString();
        transform.GetChild(0).transform.GetChild(4).GetComponent<Text>().text = gender;
        transform.GetChild(0).transform.GetChild(5).GetComponent<Text>().text = dateOfBirth;
        transform.GetChild(0).transform.GetChild(6).GetComponent<Text>().text = citizenship;
        transform.GetChild(0).transform.GetChild(8).GetComponent<Text>().text = id;

        if (gender == "male") transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/malePortrait");
        else if (gender == "female") transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/femalePortrait");
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

        for(int i = 0; i < 6; i++)
        {
            result += possibleChars[UnityEngine.Random.Range(0, possibleChars.Length)];
        }
        return result;
    }
}
