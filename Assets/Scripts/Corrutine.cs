using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrutine : MonoBehaviour
{
    public TMPro.TMP_Text point;
    void Start() // Start is called before the first frame update
    {
        point = GetComponent<TMPro.TMP_Text>();
    }

    void Update() // Update is called once per frame
    {
        point.text = "Point:" + GamerManager.instance.point;
    }

    IEnumerator Fade() 
    { 
        for(float i = 1f; i >= 0f; i -= 0.2f)
        {
            Color c = point.color;
            c.a = i;
            point.color = c;
            yield return new WaitForSeconds(0.1f);
        }

        for(float i = 0f; i <= 1f; i += 0.2f) 
        {
            Color c = point.color;
            c.a = i;
            point.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void StartFade() 
    {
        StartCoroutine(Fade());
    }
}