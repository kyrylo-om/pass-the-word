using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeAnimation : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;
    public GameObject g;
    public GameObject h;
    public GameObject i;
    public GameObject j;
    public GameObject k;
    public GameObject l;
    public GameObject m;
    public GameObject n;
    public GameObject o;
    public GameObject p;
    public GameObject q;
    public GameObject r;
    public GameObject s;
    public GameObject t;
    public GameObject u;
    public GameObject v;
    public GameObject w;
    public GameObject x;
    public GameObject y;
    public GameObject z;
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public GameObject a4;
    public GameObject a5;
    public GameObject a6;
    public GameObject a7;
    public GameObject a8;
    public GameObject a9;
    public GameObject a0;
    public GameObject tab;
    public GameObject capsLock;
    public GameObject leftShift;
    public GameObject leftControl;
    public GameObject leftWindows;
    public GameObject leftAlt;
    public GameObject space;
    public GameObject rightAlt;
    public GameObject rightWindows;
    public GameObject function;
    public GameObject rightControl;
    public GameObject rightShift;
    public GameObject backspace;
    public GameObject enter;
    public GameObject minus;
    public GameObject plus;
    public GameObject tilda;
    public GameObject leftBracket;
    public GameObject rightBracket;
    public GameObject column;
    public GameObject quote;
    public GameObject backslash;
    public GameObject slash;
    public GameObject comma;
    public GameObject dot;
    public GameObject esc;
    public GameObject f1;
    public GameObject f2;
    public GameObject f3;
    public GameObject f4;
    public GameObject f5;
    public GameObject f6;
    public GameObject f7;
    public GameObject f8;
    public GameObject f9;
    public GameObject f10;
    public GameObject f11;
    public GameObject f12;
    public GameObject printScreen;
    public GameObject scrollLock;
    public GameObject pause;
    public GameObject insert;
    public GameObject home;
    public GameObject pgUp;
    public GameObject pgDown;
    public GameObject end;
    public GameObject delete;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject upArrow;
    public GameObject downArrow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(KeyDownAnim(a));
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(KeyDownAnim(b));
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(KeyDownAnim(c));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(KeyDownAnim(d));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(KeyDownAnim(e));
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(KeyDownAnim(f));
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(KeyDownAnim(g));
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(KeyDownAnim(h));
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(KeyDownAnim(i));
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(KeyDownAnim(j));
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(KeyDownAnim(k));
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(KeyDownAnim(l));
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(KeyDownAnim(m));
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(KeyDownAnim(n));
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(KeyDownAnim(o));
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(KeyDownAnim(p));
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(KeyDownAnim(q));
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(KeyDownAnim(r));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(KeyDownAnim(s));
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(KeyDownAnim(t));
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(KeyDownAnim(u));
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(KeyDownAnim(v));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(KeyDownAnim(w));
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(KeyDownAnim(x));
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            StartCoroutine(KeyDownAnim(y));
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(KeyDownAnim(z));
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(KeyDownAnim(a1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(KeyDownAnim(a2));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(KeyDownAnim(a3));
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(KeyDownAnim(a4));
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            StartCoroutine(KeyDownAnim(a5));
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            StartCoroutine(KeyDownAnim(a6));
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            StartCoroutine(KeyDownAnim(a7));
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            StartCoroutine(KeyDownAnim(a8));
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            StartCoroutine(KeyDownAnim(a9));
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            StartCoroutine(KeyDownAnim(a0));
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            StartCoroutine(KeyDownAnim(minus));
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            StartCoroutine(KeyDownAnim(plus));
        }
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            StartCoroutine(KeyDownAnim(leftBracket));
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            StartCoroutine(KeyDownAnim(rightBracket));
        }
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            StartCoroutine(KeyDownAnim(column));
        }
        if (Input.GetKeyDown(KeyCode.Quote))
        {
            StartCoroutine(KeyDownAnim(quote));
        }
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            StartCoroutine(KeyDownAnim(backslash));
        }
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            StartCoroutine(KeyDownAnim(comma));
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            StartCoroutine(KeyDownAnim(dot));
        }
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            StartCoroutine(KeyDownAnim(slash));
        }
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            StartCoroutine(KeyDownAnim(capsLock));
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            StartCoroutine(KeyDownAnim(leftShift));
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(KeyDownAnim(tab));
        }
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            StartCoroutine(KeyDownAnim(tilda));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(KeyDownAnim(esc));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(KeyDownAnim(space));
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StartCoroutine(KeyDownAnim(backspace));
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(KeyDownAnim(enter));
        }

    }
    IEnumerator KeyDownAnim(GameObject key)
    {
        if (key.tag == "Key Animatable")
        {
            key.tag = "Untagged";
            while (key.transform.localPosition.z >= 0.005f)
            {
                key.transform.localPosition -= new Vector3(0, 0, 0.002f);
                yield return new WaitForEndOfFrame();
            }
            if (key.transform.localPosition.z < 0.005f) StartCoroutine(KeyUpAnim(key));
        }
        
    }
    IEnumerator KeyUpAnim(GameObject key)
    {
        while (key.transform.localPosition.z < 0.02f)
        {
            key.transform.localPosition += new Vector3(0, 0, 0.002f);
            yield return new WaitForEndOfFrame();
        }
        key.tag = "Key Animatable";
    }
}