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
        if(Input.GetKeyUp(KeyCode.C))
        {
            StartCoroutine(Animation());
        }
    }

    IEnumerator Animation()
    {
        for(int i = 0; i < 500; i++)
        {
            GameObject num = Instantiate(numPrefab);
            num.transform.SetParent(gameObject.transform, false);
            num.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-440, 440), Random.Range(-230, 230), 0);
            num.GetComponent<Text>().text = Random.Range(0, 10).ToString();
        }
        GameObject[] nums = GameObject.FindGameObjectsWithTag("Num");
        int count = 0;
        foreach(GameObject num in nums)
        {
            StartCoroutine(Fade(num));
            count++;
            if(count == 25)
            {
                yield return new WaitForEndOfFrame();
                count = 0;
            }
        }
    }
    IEnumerator Fade(GameObject gameObject)
    {
        while(gameObject.GetComponent<Text>().color.a > 0)
        {
            gameObject.GetComponent<Text>().color -= new Color(0, 0, 0, 0.25f);
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
