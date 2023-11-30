using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseInitAnim : MonoBehaviour
{

    public GameObject numPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyUp(KeyCode.C))
        //{
        //    foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Num")) Destroy(obj);
        //    for (int i = 0; i < 100; i++)
        //    {
        //        GameObject num = Instantiate(numPrefab);
        //        num.transform.SetParent(gameObject.transform, false);
        //        num.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-440, 440), Random.Range(-230, 230), 0);
        //        num.GetComponent<Text>().text = Random.Range(0, 10).ToString();
        //    }
        //    StartCoroutine(Animation());
        //}
    }

    IEnumerator Animation()
    {
        
        GameObject[] nums = GameObject.FindGameObjectsWithTag("Num");
        int count = 0;
        foreach(GameObject num in nums)
        {
            StartCoroutine(Fade(num));
            count++;
            if(count == 20)
            {
                yield return new WaitForEndOfFrame();
                count = 0;
            }
        }
    }
    IEnumerator Fade(GameObject gameObject)
    {
        while(gameObject.GetComponent<Text>().color.a < 0.2)
        {
            gameObject.GetComponent<Text>().color += new Color(0, 0, 0, 0.1f);
            yield return new WaitForEndOfFrame();
        }
    }
}
