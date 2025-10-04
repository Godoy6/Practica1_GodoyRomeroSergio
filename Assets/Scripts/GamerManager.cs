using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerManager : MonoBehaviour
{
    public static GamerManager instance;
    public int point = 0;
    public GameObject Corrutine;
    private Corrutine text;

    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else 
        {
            Destroy(gameObject);
        }
    }

    public void IncreasePoint()
    {
        point++;
        text.StartFade();
    }

    public void Start() // Start is called before the first frame update
    {
        text = FindObjectOfType<Corrutine>();
    }

    void Update() // Update is called once per frame
    {
        
    }
}