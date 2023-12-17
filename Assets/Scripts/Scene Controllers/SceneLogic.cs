﻿using JetBrains.Annotations;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Assertions.Must;

public class SceneLogic : MonoBehaviour
{
    public static SceneLogic instance;
    public Light spotLight;
    public Light pointLight;
    //public GameObject lampLight;
    System.Random rand = new System.Random();
    private bool isFlickering;
    public Dictionary<string, Person> people = new Dictionary<string, Person>();
    public Image cursor;
    public bool isPointerOverMonitor;
    // Start is called before the first frame update
    void Start()
    {
        instance = gameObject.GetComponent<SceneLogic>();
        Cursor.visible = false;

        Invoke("LightFlicker",rand.Next(1,5));

        GenerateDatabase();
    }

    // Update is called once per frame
    void Update()
    {
        cursor.transform.position = Input.mousePosition;

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
    public string firstName;
    public string secondName;
    public string id;
    public int age;
    public string dateOfBirth;
    public string gender;
    public string citizenship;
    public string birthCountry;
    public string birthPlace;
    public Dictionary<string, Person> parents = new Dictionary<string, Person>();
    public Person spouse;
    public Dictionary<string, Person> children = new Dictionary<string, Person>();
    public Dictionary<string, Person> siblings = new Dictionary<string, Person>();
    public Dictionary<string, Person> exes = new Dictionary<string, Person>();
    public Dictionary<string, Person> pets = new Dictionary<string, Person>();

    public Person()
    {
        if(parents.Count == 0)
        {
            Debug.Log("das");
        }
        id = GenerateID();
        while (SceneLogic.instance.people.ContainsKey(id))
        {
            id = GenerateID();
        }
        age = GenerateAge();
        string[] possibleGenders = { "male", "female" };
        gender = possibleGenders[UnityEngine.Random.Range(0, possibleGenders.Length)];
        dateOfBirth = GenerateDateOfBirth(age);
        citizenship = GenerateCitizenship();
        firstName = GenerateFirstName(gender, citizenship);
    }
    public string GenerateFirstName(string gender, string citizenship)
    {
        string firstName = "";

        switch(citizenship)
        {
            case "South Africa":
                if (gender == "male")
                {
                    string[] maleNames = { "Lethabo", "Melokuhle", "Lethokuhle", "Omphile", "Ofentse", "Lubanzi", "Junior", "Siphosethu", "Lwandle", "Banele" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Lethabo", "Melokuhle", "Lethokuhle", "Omphile", "Iminathi", "Lisakhanya", "Amahle", "Lesedi", "Asemahle", "Rethabile" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Egypt":
            case "United Arab Emirates":
            case "Saudi Arabia":
            case "Turkey":
            case "Iran":
                if (gender == "male")
                {
                    string[] maleNames = { "Mohamed", "Mohamed", "Mohamed", "Mohamed", "Mohamed", "Mohamed", "Mohamed", "Mohamed", "Mohamed", "Mohamed", "Youssef", "Ahmed", "Ahmed", "Ahmed", "Ahmed", "Ahmed", "Mahmoud", "Mustafa", "Mustafa", "Mustafa", "Mustafa", "Mustafa", "Khaled", "Omar", "Ali", "Ibrahim", "Taha", "Hussein", "Hasan", "Bandar", "Abdullah", "Fahd" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Shaimaa", "Fatma", "Maha", "Reem", "Farida", "Aya", "Shahd", "Sahar", "Fatin", "Habiba", "Emine", "Hatice", "Zeynep", "Elif", "Meryem", "Zehra", "Serife", "Sara", "Mariam", "Ayesha", "Nora", "Latifa", "Hessa", "Zeinab", "Fatemeh", "Leyla" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Brazil":
            case "Spain":
            case "Portugal":
                if (gender == "male")
                {
                    string[] maleNames = { "Miguel", "Arthur", "Gael", "Theo", "Gabriel", "Jose", "Joao", "Antonio", "Francisco", "Pedro", "Carlos", "Marcos", "Martin", "Hugo", "Alejandro", "Pablo" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Helena", "Alice", "Laura", "Sophia", "Cecilia", "Isabella", "Maria", "Ana", "Francisca", "Adriana", "Juliana", "Patricia", "Carla" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Argentina":
                if (gender == "male")
                {
                    string[] maleNames = { "Mateo", "Bautista", "Juan", "Felipe", "Bruno", "Noah", "Benicio", "Thiago", "Ciro", "Liam" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Emma", "Olivia", "Martina", "Isabella", "Alma", "Catalina", "Mia", "Ambar", "Victoria", "Delfina" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Mexico":
                if (gender == "male")
                {
                    string[] maleNames = { "Santiago", "Mateo", "Sebastian", "Leonardo", "Matias", "Emiliano", "Diego", "Daniel", "Miguel", "Angel" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Sofia", "Valentina", "Regina", "Maria Jose", "Ximena", "Camila", "Maria Fernanda", "Valeria", "Victoria", "Renata" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "United States":
            case "Canada":
            case "Great Britain":
            case "Ireland":
            case "Australia":
                if (gender == "male")
                {
                    string[] maleNames = { "Liam", "Noah", "Oliver", "James", "William", "Henry", "Lucas", "Theodore", "John", "Robert", "Michael", "Charles", "Richard", "Leo", "Benjamin", "Thomas", "Jacob", "Edouard", "Louis", "David", "Mark", "Steven", "Daniel", "Donald", "Kevin", "Gary", "Scott", "Chris", "Larry", "Matthew" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Olivia", "Emma", "Mary", "Patricia", "Linda", "Barbara", "Elizabeth", "Jennifer", "Maria", "Susan", "Margaret", "Dorothy", "Amelia", "Tiffany", "Charlotte", "Sophia", "Chloe", "Mia", "Lily", "Mila", "Florence", "Alice", "Juliette", "Rose", "Jennifer", "Nancy", "Amy" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "India":
                if (gender == "male")
                {
                    string[] maleNames = { "Muhammad", "Ram", "Sri", "Santosh", "Sanjay", "Sunil", "Rajesh", "Ramesh", "Ashok", "Manoj", "Abdul", "Anil" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Sunita", "Anita", "Gita", "Rekha", "Lakshmi", "Manju", "Shanti", "Usha", "Asha" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "China":
                if (gender == "male")
                {
                    string[] maleNames = { "Nushi", "Wei", "Yan", "Li", "Ying", "Hui", "Lei", "Hong", "Yu", "Min", "Xin", "Bin", "Ping", "Lin", "Yong", "Ming", "Qin", "Peng", "Qiang", "Yun", "Jin" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Nushi", "Wei", "Yan", "Li", "Ying", "Hui", "Lei", "Hong", "Yu", "Min", "Xin", "Bin", "Ping", "Lin", "Yong", "Ming", "Qin", "Peng", "Qiang", "Yun", "Jin" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Japan":
                if (gender == "male")
                {
                    string[] maleNames = { "Kenji", "Hiroshi", "Toshio", "Yoshio", "Kazuo", "Akira", "Masao", "Kiyoshi", "Takashi", "Yukio", "Hideo", "Koichi", "Koji", "Takeshi" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Kenji", "Shigeru", "Sachiko", "Masako", "Katsumi", "Yoko", "Michiko", "Yoshiko", "Hiromi", "Hiroko", "Keiko", "Hisako", "Yoshimi" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "South Korea":
                if (gender == "male")
                {
                    string[] maleNames = { "Seo-Jun", "Ji-U", "Min-Jun", "Seo-Jun", "Ju-Won", "Ye-Jun", "Si-U", "Do-Yun", "Ji-Hu", "Seo-Jin", "Ji-Ho", "Ha-Jun" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Ji-U", "Seo-Yun", "Seo-Yeon", "Min-Seo", "Seo-Hyeon", "Ji-Min", "Ji-Won", "Ha-Yun", "Yun-Seo", "Ha-Eun", "Ji-Yu" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Belgium":
                if (gender == "male")
                {
                    string[] maleNames = { "Marc", "Jean", "Michel", "Luc", "Patrick", "Jan", "Philippe", "Paul", "Joseph", "Pierre", "Roger", "Willy", "Eric" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Marie", "Nathalie", "Monique", "Martine", "Anne", "Isabelle", "Christine", "Nicole" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Denmark":
            case "Germany":
                if (gender == "male")
                {
                    string[] maleNames = { "Peter", "Michael", "Wolfgang", "Thomas", "Klaus", "Werner", "Karl", "August", "Emil", "Noah", "Matteo", "Elias", "Leon", "Theo", "Paul", "Henry" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Emilia", "Mia", "Sophia", "Emma", "Hannah", "Lina", "Mila", "Ella", "Clara", "Freja", "Frida", "Agnes", "Olivia", "Nora" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "France":
                if (gender == "male")
                {
                    string[] maleNames = { "Jean", "Michael", "Claude", "Philippe", "Francis", "Pierre", "Alain", "Bernard", "Andre", "Jacques", "Christophe", "Laurent", "Nicolas" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Marie", "Claude", "Dominique", "Nathalie", "Isabelle", "Catherine", "Sylvie", "Monique", "Christine", "Anne" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Greece":
                if (gender == "male")
                {
                    string[] maleNames = { "Georgios", "Ioannis", "Konstantinos", "Dimitrios", "Nikolaos", "Panagiotis", "Vasileios", "Christos", "Antonios" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Georgia", "Eleni", "Aikaterini", "Vasiliki", "Evangelia", "Eirini", "Angeliki", "Dimitra", "Panagiota" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Italy":
                if (gender == "male")
                {
                    string[] maleNames = { "Giuseppe", "Giovanni", "Antonio", "Francesco", "Andrea", "Luigi", "Mario", "Salvatore", "Vincenzo", "Roberto", "Marco" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Andrea", "Rosa", "Angela", "Giovanna", "Giuseppina", "Francesca", "Paola", "Lucia", "Carmela", "Daniela" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Netherlands":
                if (gender == "male")
                {
                    string[] maleNames = { "Jan", "Hans", "Rob", "Henk", "Paul", "Jeroen", "Frank", "Marcel", "Erik", "Mark", "Bart" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Karin", "Sandra", "Esther", "Linda", "Petra", "Yvonne", "Ellen", "Ingrid" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Poland":
                if (gender == "male")
                {
                    string[] maleNames = { "Piotr", "Tomasz", "Marcin", "Krzysztof", "Andrzej", "Marek", "Maciej", "Grzegorz", "Jacek", "Wojciech", "Mariusz", "Jakub" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Katarzyna", "Aneta", "Agnieszka", "Joanna", "Magdalena", "Ewa", "Marta", "Karolina", "Justyna", "Kasia" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Sweden":
                if (gender == "male")
                {
                    string[] maleNames = { "Lars", "Per", "Karl", "Jan", "Nils", "Sven", "Erik", "Johan", "Bjorn" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Karin", "Lena", "Kerstin", "Sara", "Ulla", "Linda", "Jenny" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Ukraine":
                if (gender == "male")
                {
                    string[] maleNames = { "Serhii", "Ivan", "Yuri", "Andrii", "Igor", "Hryhoriy", "Stepan", "Yaroslav", "Kyrylo", "Stanislav", "Tymur", "Artem", "Taras", "Illya", "Lev" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Myroslava", "Sofia", "Valeria", "Mariya", "Nina", "Kateryna", "Anastasia", "Iryna", "Khrystia", "Solomia", "Lesia", "Ivanna", "Daryna" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
            case "Russia":
                string[] surnames = { "Idiotin", "Ivanov", "Kuznetsov", "Petrov", "Popov", "Smirnov", "" };
                if (gender == "male")
                {
                    string[] maleNames = { "Sergey", "Aleksandr", "Vladimir", "Maksim", "Lenslav", "Aleksey", "Evgeniy", "Nikita", "Anton" };
                    firstName = maleNames[UnityEngine.Random.Range(0, maleNames.Length)];
                }
                if (gender == "female")
                {
                    string[] femaleNames = { "Nadezhda", "Darya", "Vasilisa", "Svetlana", "Lyudmila", "Galina", "Valentina", "Lyubov" };
                    firstName = femaleNames[UnityEngine.Random.Range(0, femaleNames.Length)];
                }
                break;
        }

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
        string date = Convert.ToString(UnityEngine.Random.Range(1, 30));
        string[] possibleMonths = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        string month = possibleMonths[UnityEngine.Random.Range(0, 11)];
        string year = Convert.ToString(2023 - age);

        return (date + " " + month + ", " + year);
    }
    public string GenerateCitizenship()
    {
        string[] possibleCitizenships = { "United States", "United States", "United States", "Great Britain", "Great Britain", "Brazil", "France", "Germany", "China", "Japan", "Italy", "Ukraine", "South Africa", "India", "Canada", "Canada", "Australia", "Egypt", "United Arab Emirates", "Saudi Arabia", "Turkey", "Iran", "Spain", "Portugal", "Argentina", "Mexico", "Ireland", "South Korea", "North Korea", "Belgium", "Denmark", "Greece", "Netherlands", "Poland", "Sweden", "Russia" };

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