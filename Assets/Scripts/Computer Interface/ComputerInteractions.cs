using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ComputerInteractions : MonoBehaviour
{
    //SAFETYNET VARIABLES

    public SceneLogic sceneLogic;
    public GameObject passwordTab;

    public Canvas movingCanvas;
    public Text passwordText;
    public Text passwordTextCensored;
    public Text idText;
    public Text attemptsText;
    public Image enterButton;
    public Image earth;
    public Animator PTanimator;
    public RectMask2D enterButtonMask;

    public float enterButtonAnimSpeed;
    public string password;
    public string id;
    public int attempts = 4;
    public string passwordTabInput = "id";
    private bool isPTIdAnimRunning;
    private bool isPTPasswordAnimRunning;
    public string currentTab = "printer";

    public GameObject historyTab;

    //DATABASE VARIABLES

    public GameObject printerTab;

    public Animator databaseAnimator;
    public GameObject databaseItemPrefab;
    public TMP_Text resultsText;
    public RectTransform content;
    public GameObject printButton;
    public Image checkmark;
    public Text searchButtonText;
    public Text nameToFindText;
    public Text queryingText;
    public Text noResultsText;
    public Image loadingArrow;
    public Image consoleArrow;
    public Image underscore;
    public Text infoText;
    public Text moreInfoText;
    public Text personNameText;
    public Image personPortrait;
    public Text printText;
    public GameObject infoOption1;
    public GameObject infoOption2;
    public GameObject infoOption3;
    public GameObject infoOption4;
    public GameObject paperPrefab;
    public string nameToFind;
    [SerializeField] private int scrollSpeed;
    private float scrollingVelocity;
    private int panelHeight;
    private bool isSearching;
    public bool isThereConsoleText = false;
    public bool showCompromised = false;
    public bool personInfoWindowOpened = false;
    public bool option1Clicked = false;
    public bool option2Clicked = false;
    public bool option3Clicked = false;
    public bool option4Clicked = false;
    public bool isPlayingPrintAnim = false;
    public Person openedPerson;

    //GENERAL VARIABLES

    private int backspaceTimer = 0;
    public Text consoleText;

    public Image worldCursor;
    public Image monitorCursor;
    private bool isMonitorCursorActive;
    // Start is called before the first frame update
    void Start()
    {
        StartConsoleTextAnim();
        StartCoroutine(ConsoleAnim());
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit);
        if (raycastHit.collider != null)
        {
            if (raycastHit.transform.name == "MonitorCollider")
            {
                worldCursor.GetComponent<Image>().enabled = false;
                monitorCursor.GetComponent<RectTransform>().anchoredPosition = new Vector3(raycastHit.point.x * 130 + 5, raycastHit.point.y * 130 - 185, 0);
            }
            else worldCursor.GetComponent<Image>().enabled = true;
        }

        if (isMonitorCursorActive)
        {

        }
        if (currentTab == "printer")
        {
            PrinterTab();
        }
        if (currentTab == "history")
        {
            HistoryTab();
        }
        if (currentTab == "password")
        {
            PasswordTab();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentTab == "password")
            {
                SwitchMenu("printer");
            }
            else if (currentTab == "printer")
            {
                SwitchMenu("password");
            }
        }
    }
    public void SwitchMenu(string menu)
    {
        //passwordTab.GetComponent<Canvas>().enabled = false;
        //historyTab.GetComponent<Canvas>().enabled = false;
        //printerTab.GetComponent<Canvas>().enabled = false;

        if (menu == "password")
        {
            passwordTab.GetComponent<Canvas>().enabled = true;
            printerTab.GetComponent<Canvas>().enabled = false;
            PTanimator.SetBool("IsPlayingInitAnim", true);
            PTanimator.SetBool("IsPointerOverLine1", false);
            PTanimator.SetBool("IsPointerOverLine2", false);
            PTanimator.SetBool("IsLine1Active", false);
            PTanimator.SetBool("IsLine2Active", false);
            passwordTabInput = "none";
            databaseAnimator.SetBool("IsPlayingInitAnim", false);
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("DatabaseItem")) Destroy(obj);
            resultsText.text = "";
            noResultsText.text = "";
        }
        if (menu == "history")
        {
            //historyTab.GetComponent<Canvas>().enabled = true;
        }
        if (menu == "printer")
        {
            databaseAnimator.SetBool("IsPlayingInitAnim", true);
            PTanimator.SetBool("PasswordCensored", true);
            passwordTab.GetComponent<Canvas>().enabled = false;
            printerTab.GetComponent<Canvas>().enabled = true;
            PTanimator.SetBool("IsPlayingInitAnim", false);
            PTanimator.SetTrigger("Reset");
            Invoke("StartDatabaseSearch", 0.4f);
            if (personInfoWindowOpened) databaseAnimator.SetTrigger("OpenWindow");
        }
        currentTab = menu;
    }

    public void PasswordTab()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            EnterButtonClick();
            PTanimator.SetTrigger("EnterKeyPressed");
        }
        movingCanvas.transform.localPosition = new Vector3(0 + monitorCursor.transform.position.x * 5, 1.39f + monitorCursor.transform.position.y * 5, 0);
        earth.transform.localPosition = new Vector3(0 - monitorCursor.transform.position.x * 10, 0 - monitorCursor.transform.position.y * 10, 0);
        if (passwordTabInput == "id")
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    id += "a";
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    id += "b";
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    id += "c";
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    id += "d";
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    id += "e";
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    id += "f";
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    id += "g";
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    id += "h";
                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    id += "i";
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    id += "j";
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    id += "k";
                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    id += "l";
                }
                if (Input.GetKeyDown(KeyCode.M))
                {
                    id += "m";
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    id += "n";
                }
                if (Input.GetKeyDown(KeyCode.O))
                {
                    id += "o";
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    id += "p";
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    id += "q";
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    id += "r";
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    id += "s";
                }
                if (Input.GetKeyDown(KeyCode.T))
                {
                    id += "t";
                }
                if (Input.GetKeyDown(KeyCode.U))
                {
                    id += "u";
                }
                if (Input.GetKeyDown(KeyCode.V))
                {
                    id += "v";
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    id += "w";
                }
                if (Input.GetKeyDown(KeyCode.X))
                {
                    id += "x";
                }
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    id += "y";
                }
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    id += "z";
                }
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    id += "1";
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    id += "2";
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    id += "3";
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    id += "4";
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    id += "5";
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    id += "6";
                }
                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    id += "7";
                }
                if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    id += "8";
                }
                if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    id += "9";
                }
                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    id += "0";
                }
                if (Input.GetKeyDown(KeyCode.Minus))
                {
                    id += "-";
                }
                if (Input.GetKeyDown(KeyCode.Equals))
                {
                    id += "=";
                }
                if (Input.GetKeyDown(KeyCode.LeftBracket))
                {
                    id += "[";
                }
                if (Input.GetKeyDown(KeyCode.RightBracket))
                {
                    id += "]";
                }
                if (Input.GetKeyDown(KeyCode.Semicolon))
                {
                    id += ";";
                }
                if (Input.GetKeyDown(KeyCode.Quote))
                {
                    id += "'";
                }
                if (Input.GetKeyDown(KeyCode.Backslash))
                {
                    id += "\\";
                }
                if (Input.GetKeyDown(KeyCode.Comma))
                {
                    id += ",";
                }
                if (Input.GetKeyDown(KeyCode.Period))
                {
                    id += ".";
                }
                if (Input.GetKeyDown(KeyCode.Slash))
                {
                    id += "/";
                }
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    id += "A";
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    id += "B";
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    id += "C";
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    id += "D";
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    id += "E";
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    id += "F";
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    id += "G";
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    id += "H";
                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    id += "I";
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    id += "J";
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    id += "K";
                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    id += "L";
                }
                if (Input.GetKeyDown(KeyCode.M))
                {
                    id += "M";
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    id += "N";
                }
                if (Input.GetKeyDown(KeyCode.O))
                {
                    id += "O";
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    id += "P";
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    id += "Q";
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    id += "R";
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    id += "S";
                }
                if (Input.GetKeyDown(KeyCode.T))
                {
                    id += "T";
                }
                if (Input.GetKeyDown(KeyCode.U))
                {
                    id += "U";
                }
                if (Input.GetKeyDown(KeyCode.V))
                {
                    id += "V";
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    id += "W";
                }
                if (Input.GetKeyDown(KeyCode.X))
                {
                    id += "X";
                }
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    id += "Y";
                }
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    id += "Z";
                }
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    id += "!";
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    id += "@";
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    id += "#";
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    id += "$";
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    id += "%";
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    id += "^";
                }
                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    id += "&";
                }
                if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    id += "*";
                }
                if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    id += "(";
                }
                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    id += ")";
                }
                if (Input.GetKeyDown(KeyCode.Minus))
                {
                    id += "_";
                }
                if (Input.GetKeyDown(KeyCode.Equals))
                {
                    id += "+";
                }
                if (Input.GetKeyDown(KeyCode.LeftBracket))
                {
                    id += "{";
                }
                if (Input.GetKeyDown(KeyCode.RightBracket))
                {
                    id += "}";
                }
                if (Input.GetKeyDown(KeyCode.Semicolon))
                {
                    id += ":";
                }
                if (Input.GetKeyDown(KeyCode.Quote))
                {
                    id += "\"";
                }
                if (Input.GetKeyDown(KeyCode.Backslash))
                {
                    id += "|";
                }
                if (Input.GetKeyDown(KeyCode.Comma))
                {
                    id += "<";
                }
                if (Input.GetKeyDown(KeyCode.Period))
                {
                    id += ">";
                }
                if (Input.GetKeyDown(KeyCode.Slash))
                {
                    id += "?";
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                id += " ";
            }
            if (Input.GetKey(KeyCode.Backspace))
            {
                if (backspaceTimer == 0 && id != "" || backspaceTimer >= 30 && id != "") id = id.Remove(id.Length - 1);
                backspaceTimer++;
            }
            if (Input.GetKeyUp(KeyCode.Backspace)) backspaceTimer = 0;
            if (!isPTIdAnimRunning) idText.text = id;
        }

        if (passwordTabInput == "password")
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    password += "a";
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    password += "b";
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    password += "c";
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    password += "d";
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    password += "e";
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    password += "f";
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    password += "g";
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    password += "h";
                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    password += "i";
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    password += "j";
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    password += "k";
                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    password += "l";
                }
                if (Input.GetKeyDown(KeyCode.M))
                {
                    password += "m";
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    password += "n";
                }
                if (Input.GetKeyDown(KeyCode.O))
                {
                    password += "o";
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    password += "p";
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    password += "q";
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    password += "r";
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    password += "s";
                }
                if (Input.GetKeyDown(KeyCode.T))
                {
                    password += "t";
                }
                if (Input.GetKeyDown(KeyCode.U))
                {
                    password += "u";
                }
                if (Input.GetKeyDown(KeyCode.V))
                {
                    password += "v";
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    password += "w";
                }
                if (Input.GetKeyDown(KeyCode.X))
                {
                    password += "x";
                }
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    password += "y";
                }
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    password += "z";
                }
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    password += "1";
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    password += "2";
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    password += "3";
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    password += "4";
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    password += "5";
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    password += "6";
                }
                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    password += "7";
                }
                if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    password += "8";
                }
                if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    password += "9";
                }
                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    password += "0";
                }
                if (Input.GetKeyDown(KeyCode.Minus))
                {
                    password += "-";
                }
                if (Input.GetKeyDown(KeyCode.Equals))
                {
                    password += "=";
                }
                if (Input.GetKeyDown(KeyCode.LeftBracket))
                {
                    password += "[";
                }
                if (Input.GetKeyDown(KeyCode.RightBracket))
                {
                    password += "]";
                }
                if (Input.GetKeyDown(KeyCode.Semicolon))
                {
                    password += ";";
                }
                if (Input.GetKeyDown(KeyCode.Quote))
                {
                    password += "'";
                }
                if (Input.GetKeyDown(KeyCode.Backslash))
                {
                    password += "\\";
                }
                if (Input.GetKeyDown(KeyCode.Comma))
                {
                    password += ",";
                }
                if (Input.GetKeyDown(KeyCode.Period))
                {
                    password += ".";
                }
                if (Input.GetKeyDown(KeyCode.Slash))
                {
                    password += "/";
                }
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    password += "A";
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    password += "B";
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    password += "C";
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    password += "D";
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    password += "E";
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    password += "F";
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    password += "G";
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    password += "H";
                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    password += "I";
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    password += "J";
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    password += "K";
                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    password += "L";
                }
                if (Input.GetKeyDown(KeyCode.M))
                {
                    password += "M";
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    password += "N";
                }
                if (Input.GetKeyDown(KeyCode.O))
                {
                    password += "O";
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    password += "P";
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    password += "Q";
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    password += "R";
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    password += "S";
                }
                if (Input.GetKeyDown(KeyCode.T))
                {
                    password += "T";
                }
                if (Input.GetKeyDown(KeyCode.U))
                {
                    password += "U";
                }
                if (Input.GetKeyDown(KeyCode.V))
                {
                    password += "V";
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    password += "W";
                }
                if (Input.GetKeyDown(KeyCode.X))
                {
                    password += "X";
                }
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    password += "Y";
                }
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    password += "Z";
                }
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    password += "!";
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    password += "@";
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    password += "#";
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    password += "$";
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    password += "%";
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    password += "^";
                }
                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    password += "&";
                }
                if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    password += "*";
                }
                if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    password += "(";
                }
                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    password += ")";
                }
                if (Input.GetKeyDown(KeyCode.Minus))
                {
                    password += "_";
                }
                if (Input.GetKeyDown(KeyCode.Equals))
                {
                    password += "+";
                }
                if (Input.GetKeyDown(KeyCode.LeftBracket))
                {
                    password += "{";
                }
                if (Input.GetKeyDown(KeyCode.RightBracket))
                {
                    password += "}";
                }
                if (Input.GetKeyDown(KeyCode.Semicolon))
                {
                    password += ":";
                }
                if (Input.GetKeyDown(KeyCode.Quote))
                {
                    password += "\"";
                }
                if (Input.GetKeyDown(KeyCode.Backslash))
                {
                    password += "|";
                }
                if (Input.GetKeyDown(KeyCode.Comma))
                {
                    password += "<";
                }
                if (Input.GetKeyDown(KeyCode.Period))
                {
                    password += ">";
                }
                if (Input.GetKeyDown(KeyCode.Slash))
                {
                    password += "?";
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                password += " ";
            }
            if (Input.GetKey(KeyCode.Backspace))
            {
                if (backspaceTimer == 0 && password != "" || backspaceTimer >= 30 && password != "") password = password.Remove(password.Length - 1);
                backspaceTimer++;
            }
            if (Input.GetKeyUp(KeyCode.Backspace)) backspaceTimer = 0;
            if (!isPTPasswordAnimRunning)
            {
                passwordText.text = password;
                passwordTextCensored.text = String.Concat(Enumerable.Repeat("*", password.Length));
            }
        }
    }

    public void DeselectLines()
    {
        PTanimator.SetBool("IsLine1Active", false);
        PTanimator.SetBool("IsLine2Active", false);
        passwordTabInput = "none";
        PTanimator.SetBool("PasswordCensored", true);
    }
    public void EnterButtonClick()
    {
        if (id == "admin" && password == "admin1234password")
        {
            PTanimator.SetTrigger("LoginSuccess");
        }
        else
        {
            PTanimator.SetTrigger("LoginFailure");
            passwordTabInput = "none";
            DeselectLines();
            attempts -= 1;
            attemptsText.text = "Attempts remaining: " + Convert.ToString(attempts);
        }
    }
    public void SwitchPasswordTabField(string input)
    {
        if (passwordTabInput != input)
        {
            //enterBar1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/passwordTabEnterBarInactive");
            //enterBar2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/passwordTabEnterBarInactive");
            if (input == "id")
            {
                if (passwordTabInput != "none") PTanimator.SetBool("IsLine2Active", false);
                PTanimator.SetBool("IsLine1Active", true);
                PTanimator.SetBool("PasswordCensored", true);
            }
            else if (input == "password")
            {
                if (passwordTabInput != "none") PTanimator.SetBool("IsLine1Active", false);
                PTanimator.SetBool("IsLine2Active", true);
                PTanimator.SetBool("PasswordCensored", false);
            }

            passwordTabInput = input;
        }
    }

    public void HistoryTab()
    {

    }
    public void PrinterTab()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            databaseAnimator.SetTrigger("EnterKeyPressed");
            StartDatabaseSearch();
        }

        scrollingVelocity -= Input.mouseScrollDelta.y * scrollSpeed;
        content.anchoredPosition += new Vector2(0, scrollingVelocity);

        if (Math.Sign(scrollingVelocity) > 0 && scrollingVelocity > 0) scrollingVelocity -= 2;
        else if (Math.Sign(scrollingVelocity) < 0 && scrollingVelocity < 0) scrollingVelocity += 2;

        if (content.anchoredPosition.y < 0)
        {
            scrollingVelocity = 0;
            content.anchoredPosition = new Vector2(0, 0);
        }
        if (content.anchoredPosition.y > panelHeight)
        {
            scrollingVelocity = 0;
            content.anchoredPosition = new Vector2(0, panelHeight);
        }

        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                nameToFind += "a";
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                nameToFind += "b";
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                nameToFind += "c";
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                nameToFind += "d";
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                nameToFind += "e";
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                nameToFind += "f";
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                nameToFind += "g";
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                nameToFind += "h";
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                nameToFind += "i";
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                nameToFind += "j";
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                nameToFind += "k";
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                nameToFind += "l";
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                nameToFind += "m";
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                nameToFind += "n";
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                nameToFind += "o";
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                nameToFind += "p";
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                nameToFind += "q";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                nameToFind += "r";
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                nameToFind += "s";
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                nameToFind += "t";
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                nameToFind += "u";
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                nameToFind += "v";
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                nameToFind += "w";
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                nameToFind += "x";
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                nameToFind += "y";
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                nameToFind += "z";
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                nameToFind += "1";
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                nameToFind += "2";
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                nameToFind += "3";
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                nameToFind += "4";
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                nameToFind += "5";
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                nameToFind += "6";
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                nameToFind += "7";
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                nameToFind += "8";
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                nameToFind += "9";
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                nameToFind += "0";
            }
            if (Input.GetKeyDown(KeyCode.Minus))
            {
                nameToFind += "-";
            }
            if (Input.GetKeyDown(KeyCode.Equals))
            {
                nameToFind += "=";
            }
            if (Input.GetKeyDown(KeyCode.LeftBracket))
            {
                nameToFind += "[";
            }
            if (Input.GetKeyDown(KeyCode.RightBracket))
            {
                nameToFind += "]";
            }
            if (Input.GetKeyDown(KeyCode.Semicolon))
            {
                nameToFind += ";";
            }
            if (Input.GetKeyDown(KeyCode.Quote))
            {
                nameToFind += "'";
            }
            if (Input.GetKeyDown(KeyCode.Backslash))
            {
                nameToFind += "\\";
            }
            if (Input.GetKeyDown(KeyCode.Comma))
            {
                nameToFind += ",";
            }
            if (Input.GetKeyDown(KeyCode.Period))
            {
                nameToFind += ".";
            }
            if (Input.GetKeyDown(KeyCode.Slash))
            {
                nameToFind += "/";
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                nameToFind += "A";
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                nameToFind += "B";
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                nameToFind += "C";
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                nameToFind += "D";
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                nameToFind += "E";
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                nameToFind += "F";
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                nameToFind += "G";
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                nameToFind += "H";
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                nameToFind += "I";
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                nameToFind += "J";
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                nameToFind += "K";
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                nameToFind += "L";
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                nameToFind += "M";
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                nameToFind += "N";
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                nameToFind += "O";
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                nameToFind += "P";
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                nameToFind += "Q";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                nameToFind += "R";
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                nameToFind += "S";
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                nameToFind += "T";
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                nameToFind += "U";
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                nameToFind += "V";
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                nameToFind += "W";
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                nameToFind += "X";
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                nameToFind += "Y";
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                nameToFind += "Z";
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                nameToFind += "!";
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                nameToFind += "@";
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                nameToFind += "#";
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                nameToFind += "$";
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                nameToFind += "%";
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                nameToFind += "^";
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                nameToFind += "&";
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                nameToFind += "*";
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                nameToFind += "(";
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                nameToFind += ")";
            }
            if (Input.GetKeyDown(KeyCode.Minus))
            {
                nameToFind += "_";
            }
            if (Input.GetKeyDown(KeyCode.Equals))
            {
                nameToFind += "+";
            }
            if (Input.GetKeyDown(KeyCode.LeftBracket))
            {
                nameToFind += "{";
            }
            if (Input.GetKeyDown(KeyCode.RightBracket))
            {
                nameToFind += "}";
            }
            if (Input.GetKeyDown(KeyCode.Semicolon))
            {
                nameToFind += ":";
            }
            if (Input.GetKeyDown(KeyCode.Quote))
            {
                nameToFind += "\"";
            }
            if (Input.GetKeyDown(KeyCode.Backslash))
            {
                nameToFind += "|";
            }
            if (Input.GetKeyDown(KeyCode.Comma))
            {
                nameToFind += "<";
            }
            if (Input.GetKeyDown(KeyCode.Period))
            {
                nameToFind += ">";
            }
            if (Input.GetKeyDown(KeyCode.Slash))
            {
                nameToFind += "?";
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            nameToFind += " ";
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            if (backspaceTimer == 0 && nameToFind != "" || backspaceTimer >= 30 && nameToFind != "") nameToFind = nameToFind.Remove(nameToFind.Length - 1);
            backspaceTimer++;
        }
        if (Input.GetKeyUp(KeyCode.Backspace)) backspaceTimer = 0;

        if (nameToFind.Length >= 27)
        {
            nameToFind = nameToFind.Remove(nameToFind.Length - 1);
        }

        nameToFindText.text = nameToFind;

        if (nameToFind == "" && isThereConsoleText)
        {
            isThereConsoleText = false;
            underscore.enabled = false;
            consoleArrow.enabled = true;
            searchButtonText.text = "Show all";
        }
        else if (nameToFind != "" && !isThereConsoleText)
        {
            isThereConsoleText = true;
            consoleArrow.enabled = true;
            underscore.enabled = true;
            searchButtonText.text = "Initialize search";
        }

        underscore.rectTransform.anchoredPosition = new Vector2(-200 + 16.4f * nameToFind.Length, -10);
    }

    public void StartDatabaseSearch()
    {
        if (!isSearching) StartCoroutine(SearchAnimation());
    }
    public IEnumerator SearchAnimation()
    {
        isSearching = true;
        resultsText.text = "";
        noResultsText.text = "";
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("DatabaseItem")) Destroy(obj);
        int duration = UnityEngine.Random.Range(20, 50);

        queryingText.color = new Color(0, 0.59f, 0.05f, 1);
        loadingArrow.color = new Color(0, 0.59f, 0.05f, 1);
        for (int i = 0; i < duration; i++)
        {
            loadingArrow.transform.localEulerAngles -= new Vector3(0, 0, 7);
            yield return new WaitForSeconds(0.001f);
        }
        queryingText.color = new Color(0, 0.59f, 0.05f, 0);
        loadingArrow.color = new Color(0, 0.59f, 0.05f, 0);

        StartCoroutine(SearchDatabase(nameToFindText.text));
    }
    //would be cooler if i made the progress random
    public void StartPrinting()
    {
        if (!isPlayingPrintAnim)
        {
            databaseAnimator.SetBool("IsPointerDownPrintButton", false);
            StartCoroutine(PrintingTextAnim());
            StartCoroutine(PrintPaper());
        }
    }
    public IEnumerator PrintingTextAnim()
    {
        isPlayingPrintAnim = true;
        printText.text = "Printing";
        yield return new WaitForSeconds(0.2f);
        printText.text = "Printing.";
        yield return new WaitForSeconds(0.2f);
        printText.text = "Printing..";
        yield return new WaitForSeconds(0.2f);
        printText.text = "Printing...";
        yield return new WaitForSeconds(0.4f);
        printText.text = "Print";

        yield return new WaitForSeconds(0.4f);
        isPlayingPrintAnim = false;
    }
    public IEnumerator PrintPaper()
    {
        GameObject paper = Instantiate(paperPrefab, new Vector3(6.6f, -0.2f, 1.5f), Quaternion.Euler(0, 5, 0));
        paper.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = openedPerson.firstName + " " + openedPerson.secondName;
        paper.transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().text = openedPerson.age.ToString();
        paper.transform.GetChild(0).transform.GetChild(4).GetComponent<Text>().text = openedPerson.parent1.firstName;
        paper.transform.GetChild(0).transform.GetChild(5).GetComponent<Text>().text = openedPerson.dateOfBirth;
        paper.transform.GetChild(0).transform.GetChild(6).GetComponent<Text>().text = openedPerson.citizenship;
        paper.transform.GetChild(0).transform.GetChild(8).GetComponent<Text>().text = openedPerson.id;

        if (openedPerson.gender == "male") paper.transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/malePortrait");
        else if (openedPerson.gender == "female") paper.transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/femalePortrait");

        while (paper.transform.position.z > -1.4f)
        {
            paper.transform.localPosition -= paper.transform.forward * Time.deltaTime * 3;
            yield return new WaitForEndOfFrame();
        }
        paper.transform.position = new Vector3(UnityEngine.Random.Range(-4, 4), -2.1f, UnityEngine.Random.Range(-6.5f, -3.8f));
        paper.transform.rotation = Quaternion.Euler(0, UnityEngine.Random.Range(-50, 50), 0);
        List<GameObject> sortedPapers = GameObject.FindGameObjectsWithTag("Paper").OrderBy(o => o.transform.position.y).ToList();
        for (int i = 0; i < sortedPapers.Count; i++)
        {
            sortedPapers[i].transform.position = new Vector3(sortedPapers[i].transform.position.x, -2.1f + Convert.ToSingle(i) / 500f, sortedPapers[i].transform.position.z);
        }
        paper = null;
        yield break;
    }
    public IEnumerator SearchDatabase(string prompt)
    {
        content.anchoredPosition = new Vector2(0, 0);
        int count = 0;
        //List<Person> searchResults = new List<Person>();

        foreach (Person person in sceneLogic.people.Values)
        {
            if ((person.firstName + " " + person.secondName).ToLower().Contains(prompt.ToLower()) || person.id.ToLower() == prompt.ToLower())
            {
                GameObject item = Instantiate(databaseItemPrefab);
                item.GetComponent<ItemScript>().attachedPerson = person;
                item.transform.SetParent(gameObject.transform.GetChild(2).transform.GetChild(1).transform.GetChild(3).transform.GetChild(0), false);
                item.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 250 - 80 * count, 0);
                item.transform.GetChild(0).GetComponent<TMP_Text>().text = person.firstName + " " + person.secondName + " | " + person.id;
                if (person.isDead || person.isCompromised || person.age < 18)
                {
                    item.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(0.8f, 0.8f, 0.8f);
                    item.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    if (person.isDead) item.transform.GetChild(3).GetComponent<TMP_Text>().text = "dead";
                    if (person.isCompromised) item.transform.GetChild(3).GetComponent<TMP_Text>().text = "compromised";
                    if (person.age < 18) item.transform.GetChild(3).GetComponent<TMP_Text>().text = "underage";
                }
                count++;
                if (count < 10)
                {
                    yield return new WaitForSeconds(0.03f);
                }
            }
        }
        if (count == 0)
        {
            noResultsText.text = "No results found.";
        }
        else
        {
            resultsText.text = "showing " + count + " out of " + sceneLogic.people.Count + " available results within employee's work limit.";
        }
        panelHeight = Math.Clamp(count * 80 - 580, 0, 999999999);
        isSearching = false;
    }
    public void OpenPersonInfo(string name, int age, string gender, string citizenship, Person attachedPerson)
    {
        openedPerson = attachedPerson;
        personInfoWindowOpened = true;
        personNameText.text = name;
        infoText.text = "Age: " + (attachedPerson.isDead ? "dead" : age.ToString()) + "\nGender: " + gender + "\nCitizenship: " + citizenship;
        if (attachedPerson.isDead || age < 18)
        {
            moreInfoText.text = "Extended information unavailable";
            infoOption1.SetActive(false);
            infoOption2.SetActive(false);
            infoOption3.SetActive(false);
            infoOption4.SetActive(false);
            printButton.SetActive(false);
        }
        else
        {
            moreInfoText.text = "Select information to print:";
            infoOption1.SetActive(true);
            infoOption2.SetActive(true);
            infoOption3.SetActive(true);
            infoOption4.SetActive(true);
            printButton.SetActive(true);
        }

        databaseAnimator.SetTrigger("OpenWindow");
    }
    public void ClosePersonInfo()
    {
        if (personInfoWindowOpened)
        {
            openedPerson = null;
            personInfoWindowOpened = false;
            databaseAnimator.SetTrigger("CloseWindow");
        }
    }

    public void CheckmarkHover()
    {
        if (!showCompromised)
        {
            checkmark.color = new Color(0.08f, 0.68f, 0, 0.2f);
        }
    }
    public void CheckmarkOut()
    {
        if (!showCompromised)
        {
            checkmark.color = new Color(0.08f, 0.68f, 0, 0);
        }
    }
    public void CheckmarkClick()
    {
        showCompromised = !showCompromised;
        StartDatabaseSearch();
        if (showCompromised)
        {
            checkmark.color = new Color(0.08f, 0.68f, 0, 1);
        }
        else
        {
            checkmark.color = new Color(0.08f, 0.68f, 0, 0);
        }
    }

    public void Option1Click()
    {
        option1Clicked = !option1Clicked;
        databaseAnimator.SetBool("IsOption1Clicked", option1Clicked);
    }
    public void Option2Click()
    {
        option2Clicked = !option2Clicked;
        databaseAnimator.SetBool("IsOption2Clicked", option2Clicked);
    }
    public void Option3Click()
    {
        option3Clicked = !option3Clicked;
        databaseAnimator.SetBool("IsOption3Clicked", option3Clicked);
    }
    public void Option4Click()
    {
        option4Clicked = !option4Clicked;
        databaseAnimator.SetBool("IsOption4Clicked", option4Clicked);
    }

    public IEnumerator ConsoleAnim()
    {
        bool animIterator = true;
        while (true)
        {
            if (!isThereConsoleText)
            {
                if (animIterator)
                {
                    consoleArrow.enabled = false;
                    animIterator = false;
                }
                else if (!animIterator)
                {
                    consoleArrow.enabled = true;
                    animIterator = true;
                }
            }
            if (isThereConsoleText)
            {
                if (animIterator)
                {
                    underscore.enabled = false;
                    animIterator = false;
                }
                else if (!animIterator)
                {
                    underscore.enabled = true;
                    animIterator = true;
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void SetBoolParameter(string input)
    {
        string[] words = input.Split(' ');
        bool value = false;
        if (words[2] == "true") value = true;
        if (words[2] == "false") value = false;
        if (words[0] == "PT") PTanimator.SetBool(words[1], value);
        if (words[0] == "DT") databaseAnimator.SetBool(words[1], value);
    }

    public void StartConsoleTextAnim()
    {
        StartCoroutine(ConsoleTextAnim());
    }
    IEnumerator ConsoleTextAnim()
    {
        string text = "NOBILITY Corporation\r\n\r\n\0Microforms Wisdoms [Version 10.0.10945.3448]\r\n(copyright) Microforms Corporation. All rights reserved.\0\r\n\r\n\r\nOperating system: Wisdoms 7 (32 bit); IP: 197.108.64.21; Device name: Rostov's PC; Connected network: roshome; Domain: HC_Service; \r\nDate: 04.10.2023;\0\r\nEmployeePersonalInformation = {['name'] = \"michael\", ['surname'] = \"rostov\", ['age'] = 37, ['gender'] = \"m\", [dateOfBirth'] = \"02.11.1986\",\r\n['citizenship'] = \"canada\", ['uniqueId'] = \"nGi5p2\"}\r\n\r\n\0inc.NOBILITYNetwork Status . . . . . . . . . . . . . . . . . . . . . . . . . . : Available\r\nGovernmentServices Status. . . . . . . . . . . . . . . . . . . . . . . . . . . : Blocked\r\nVPN Status . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . : Connected          (France, Paris)\r\nSafetyProtocols. . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . : Disabled\r\nPeopleDatabaseStatus . . . . . . . . . . . . . . . . . . . . . . . . . . . . . : Accessed\r\nHistoryBrowserServices . . . . . . . . . . . . . . . . . . . . . . . . . . . . : Available\r\ninc.NOBILITYApproval . . . . . . . . . . . . . . . . . . . . . . . . . . . . . : Granted\r\n\r\n\r\nUniqueNOBILITYIdentificationKey: 99C16B81-D151-4EE0-A8C4-493C9091E944\r\n\r\n\r\n\0Startup initialized\0        Awaiting input...\\\n\n(?????? Tab)";
        int i = 0;
        int speed = 2;
        while (i < text.Length)
        {
            for (int j = 0; j < speed && i < text.Length; j++)
            {
                if (text[i] == '\0')
                {
                    i++;

                    yield return new WaitForSeconds(0.5f);
                }
                else
                {
                    consoleText.text += text[i];
                    i++;
                }
            }
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }
}