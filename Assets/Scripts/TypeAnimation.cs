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

    
    private int KeyAnimTimer = 0;
    private bool isKeyDownAnim = false;
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

        if (Input.GetKeyUp(KeyCode.A))
        {
            StartCoroutine(KeyUpAnim(a));
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            StartCoroutine(KeyUpAnim(b));
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            StartCoroutine(KeyUpAnim(c));
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            StartCoroutine(KeyUpAnim(d));
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            StartCoroutine(KeyUpAnim(e));
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            StartCoroutine(KeyUpAnim(f));
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            StartCoroutine(KeyUpAnim(g));
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            StartCoroutine(KeyUpAnim(h));
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            StartCoroutine(KeyUpAnim(i));
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            StartCoroutine(KeyUpAnim(j));
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            StartCoroutine(KeyUpAnim(k));
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            StartCoroutine(KeyUpAnim(l));
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            StartCoroutine(KeyUpAnim(m));
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            StartCoroutine(KeyUpAnim(n));
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            StartCoroutine(KeyUpAnim(o));
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            StartCoroutine(KeyUpAnim(p));
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            StartCoroutine(KeyUpAnim(q));
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            StartCoroutine(KeyUpAnim(r));
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            StartCoroutine(KeyUpAnim(s));
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            StartCoroutine(KeyUpAnim(t));
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            StartCoroutine(KeyUpAnim(u));
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            StartCoroutine(KeyUpAnim(v));
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            StartCoroutine(KeyUpAnim(w));
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            StartCoroutine(KeyUpAnim(x));
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            StartCoroutine(KeyUpAnim(y));
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            StartCoroutine(KeyUpAnim(z));
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            StartCoroutine(KeyUpAnim(a1));
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            StartCoroutine(KeyUpAnim(a2));
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            StartCoroutine(KeyUpAnim(a3));
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            StartCoroutine(KeyUpAnim(a4));
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            StartCoroutine(KeyUpAnim(a5));
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            StartCoroutine(KeyUpAnim(a6));
        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            StartCoroutine(KeyUpAnim(a7));
        }
        if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            StartCoroutine(KeyUpAnim(a8));
        }
        if (Input.GetKeyUp(KeyCode.Alpha9))
        {
            StartCoroutine(KeyUpAnim(a9));
        }
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            StartCoroutine(KeyUpAnim(a0));
        }
        if (Input.GetKeyUp(KeyCode.Minus))
        {
            StartCoroutine(KeyUpAnim(minus));
        }
        if (Input.GetKeyUp(KeyCode.Equals))
        {
            StartCoroutine(KeyUpAnim(plus));
        }
        if (Input.GetKeyUp(KeyCode.LeftBracket))
        {
            StartCoroutine(KeyUpAnim(leftBracket));
        }
        if (Input.GetKeyUp(KeyCode.RightBracket))
        {
            StartCoroutine(KeyUpAnim(rightBracket));
        }
        if (Input.GetKeyUp(KeyCode.Semicolon))
        {
            StartCoroutine(KeyUpAnim(column));
        }
        if (Input.GetKeyUp(KeyCode.Quote))
        {
            StartCoroutine(KeyUpAnim(quote));
        }
        if (Input.GetKeyUp(KeyCode.Backslash))
        {
            StartCoroutine(KeyUpAnim(backslash));
        }
        if (Input.GetKeyUp(KeyCode.Comma))
        {
            StartCoroutine(KeyUpAnim(comma));
        }
        if (Input.GetKeyUp(KeyCode.Period))
        {
            StartCoroutine(KeyUpAnim(dot));
        }
        if (Input.GetKeyUp(KeyCode.Slash))
        {
            StartCoroutine(KeyUpAnim(slash));
        }
        if (Input.GetKeyUp(KeyCode.CapsLock))
        {
            StartCoroutine(KeyUpAnim(capsLock));
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            StartCoroutine(KeyUpAnim(leftShift));
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            StartCoroutine(KeyUpAnim(tab));
        }
        if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            StartCoroutine(KeyUpAnim(tilda));
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            StartCoroutine(KeyUpAnim(esc));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(KeyUpAnim(space));
        }
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            StartCoroutine(KeyUpAnim(backspace));
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StartCoroutine(KeyUpAnim(enter));
        }

    }
    IEnumerator KeyDownAnim(GameObject key)
    {
        while(key.transform.localPosition.y >= -0.12f)
        {
            isKeyDownAnim = true;
            key.transform.localPosition -= new Vector3(0, 0.02f, 0);
            yield return new WaitForEndOfFrame();
        }
        if(key.transform.localPosition.y < -0.12f) isKeyDownAnim = false;
    }
    IEnumerator KeyUpAnim(GameObject key)
    {
        while (key.transform.localPosition.y < 0.02f)
        {
            if(!isKeyDownAnim) key.transform.localPosition += new Vector3(0, 0.02f, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}
