using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ComputerInteractions : MonoBehaviour
{
    public GameObject passwordTab;

    public Canvas movingCanvas;
    public Text passwordText;
    public Text idText;
    public Text attemptsText;
    public Image enterButton;
    public Image earth;
    public Animator animator;
    public RectMask2D enterButtonMask;

    public float enterButtonAnimSpeed;
    public string password;
    public string id;
    public int attempts = 4;
    public string passwordTabInput = "id";
    private bool isPTIdAnimRunning;
    private bool isPTPasswordAnimRunning;

    public GameObject historyTab;

    public GameObject printerTab;

    public GameObject printButton;
    public Text nameToFindText;
    public string nameToFind;


    public string currentTab = "printer";
    private int backspaceTimer = 0;
    public Text consoleText;

    public Image worldCursor;
    public Image monitorCursor;
    private bool isMonitorCursorActive;
    // Start is called before the first frame update
    void Start()
    {
        StartConsoleTextAnim();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            EnterButtonClick();
            animator.SetTrigger("EnterKeyPressed");
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit);
        if(raycastHit.collider != null)
        {
            if (raycastHit.transform.name == "MonitorCollider")
            {
                worldCursor.GetComponent<Image>().enabled = false;
                monitorCursor.transform.position = new Vector3(raycastHit.point.x + 0.1f, raycastHit.point.y - 0.1f, 0.25f);
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
            animator.SetBool("IsPlayingInitAnim", true);
            animator.SetBool("IsPointerOverLine1", false);
            animator.SetBool("IsPointerOverLine2", false);
            animator.SetBool("IsLine1Active", false);
            animator.SetBool("IsLine2Active", false);
            passwordTabInput = "none";
        }
        if (menu == "history")
        {
            //historyTab.GetComponent<Canvas>().enabled = true;
        }
        if (menu == "printer") 
        {
            passwordTab.GetComponent<Canvas>().enabled = false; 
            animator.SetBool("IsPlayingInitAnim", false);
            animator.SetTrigger("Reset");
        }
        currentTab = menu;
    }

    public void PasswordTab()
    {
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
                if (backspaceTimer == 0 && id != "" || backspaceTimer >= 60 && id != "") id = id.Remove(id.Length - 1);
                backspaceTimer++;
            }
            if (Input.GetKeyUp(KeyCode.Backspace)) backspaceTimer = 0;
            if (!isPTIdAnimRunning) idText.text = id;
        }

        if(passwordTabInput == "password")
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
                if (backspaceTimer == 0 && password != "" || backspaceTimer >= 60 && password != "") password = password.Remove(password.Length - 1);
                backspaceTimer++;
            }
            if (Input.GetKeyUp(KeyCode.Backspace)) backspaceTimer = 0;
            if(!isPTPasswordAnimRunning) passwordText.text = password;
        }
    }

    public void DeselectLines()
    {
        animator.SetBool("IsLine1Active", false);
        animator.SetBool("IsLine2Active", false);
        passwordTabInput = "none";
    }
    public void EnterButtonClick()
    {
        if(id == "admin" && password == "admin1234password")
        {
            animator.SetTrigger("LoginSuccess");
        }
        else
        {
            animator.SetTrigger("LoginFailure");
            passwordTabInput = "none";
            DeselectLines();
            attempts -= 1;
            attemptsText.text = "Attempts remaining: " + Convert.ToString(attempts);
        }
    }
    public void SwitchPasswordTabField(string input)
    {
        if(passwordTabInput != input)
        {
            //enterBar1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/passwordTabEnterBarInactive");
            //enterBar2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/passwordTabEnterBarInactive");
            if (input == "id")
            {
                if(passwordTabInput != "none") animator.SetBool("IsLine2Active", false);
                animator.SetBool("IsLine1Active", true);
            }
            else if (input == "password")
            {
                if (passwordTabInput != "none") animator.SetBool("IsLine1Active", false);
                animator.SetBool("IsLine2Active", true);
            }

            passwordTabInput = input;
        }
    }

    public void HistoryTab()
    {

    }
    public void PrinterTab()
    {
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
            if (backspaceTimer == 0 && nameToFind != "" || backspaceTimer >= 60 && nameToFind != "") nameToFind = nameToFind.Remove(nameToFind.Length - 1);
            backspaceTimer++;
        }
        if (Input.GetKeyUp(KeyCode.Backspace)) backspaceTimer = 0;
        //nameToFindText.text = nameToFind;
    }

    public void FindPerson()
    {
        printButton.SetActive(true);
    }

    public void SetBoolParameter(string input)
    {
        string[] words = input.Split(' ');
        bool value = false;
        if (words[1] == "true") value = true;
        if (words[1] == "false") value = false;
        animator.SetBool(words[0], value);
    }

    public void StartConsoleTextAnim()
    {
        StartCoroutine(ConsoleTextAnim());
    }
    IEnumerator ConsoleTextAnim()
    {
        string text = "NOBILITY Corporation\r\n\r\n\0Microforms Wisdoms [Version 10.0.10945.3448]\r\n(copyright) Microforms Corporation. All rights reserved.\0\r\n\r\n\r\nOperating system: Wisdoms 7 (32 bit); IP: 197.108.64.21; Device name: Rostov's PC; Connected network: roshome; Domain: HC_Service; \r\nDate: 04.10.2023;\0\r\nEmployeePersonalInformation = {['name'] = \"michael\", ['surname'] = \"rostov\", ['age'] = 37, ['gender'] = \"m\", [dateOfBirth'] = \"02.11.1986\",\r\n['citizenship'] = \"canada\", ['uniqueId'] = \"nGi5p2\"}\r\n\r\n\0inc.NOBILITYNetwork Status . . . . . . . . . . . . . . . . . . . . . . . . . . : Available\r\nGovernmentServices Status. . . . . . . . . . . . . . . . . . . . . . . . . . . : Blocked\r\nVPN Status . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . : Connected          (France, Paris)\r\nSafetyProtocols. . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . : Disabled\r\nPeopleDatabaseStatus . . . . . . . . . . . . . . . . . . . . . . . . . . . . . : Accessed\r\nHistoryBrowserServices . . . . . . . . . . . . . . . . . . . . . . . . . . . . : Available\r\ninc.NOBILITYApproval . . . . . . . . . . . . . . . . . . . . . . . . . . . . . : Granted\r\n\r\n\r\nUniqueNOBILITYIdentificationKey: 99C16B81-D151-4EE0-A8C4-493C9091E944\r\n\r\n\r\n\0Startup initialized\0        Awaiting input...\\\n\n(Íàæì³òü Tab)";
        int i = 0;
        int speed = 2;
        while(i < text.Length)
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
