using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Linq;
using System;

public class DragPaper : MonoBehaviour
{
    public PublicVariables publicVariables;
    public GameState gameStateScript;
    public float paperRotatingSpeed;
    public bool isMovingPaper;
    private float xDifference;
    private float zDifference;
    bool isBeingDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        publicVariables = GameObject.FindGameObjectWithTag("Scene Logic").GetComponent<PublicVariables>();
        gameStateScript = GameObject.FindGameObjectWithTag("Game State Manager").GetComponent<GameState>();
        //gameObject.transform.position = new Vector3(0, -2, 0);
        gameObject.tag = "Paper";
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        if (isMovingPaper)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                gameObject.transform.position = new Vector3(Mathf.Clamp(raycastHit.point.x + xDifference,-4,4), gameObject.transform.position.y, Mathf.Clamp(raycastHit.point.z + zDifference, -10, -3.8f));
            }
            //gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,1, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
            gameObject.transform.eulerAngles += new Vector3(0, Input.mouseScrollDelta.y * paperRotatingSpeed, 0);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isMovingPaper = false;
            publicVariables.isMovingPaper = false;
        }
        if(isBeingDestroyed)
        {
            gameObject.transform.position = new Vector3(transform.position.x, -2, transform.position.z - 0.3f);
            if (transform.position.z < -10) Destroy(gameObject);
        }
        

    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                xDifference = gameObject.transform.position.x - raycastHit.point.x;
                zDifference = gameObject.transform.position.z - raycastHit.point.z;
            }
            gameObject.transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);

            List<GameObject> sortedPapers = GameObject.FindGameObjectsWithTag("Paper").OrderBy(o => o.transform.position.y).ToList();
            for(int i = 0; i < sortedPapers.Count; i++)
            {
                sortedPapers[i].transform.position = new Vector3(sortedPapers[i].transform.position.x, -2f + Convert.ToSingle(i) / 500f, sortedPapers[i].transform.position.z);
            }
            isMovingPaper = true;
            publicVariables.isMovingPaper = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if(Input.mousePosition.y / Screen.height < 0.1) isBeingDestroyed = true;
        }
    }
}
