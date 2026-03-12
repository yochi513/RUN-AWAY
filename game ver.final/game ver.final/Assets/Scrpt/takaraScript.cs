using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

//國重
public class takaraScript : MonoBehaviour
{
    [SerializeField] GameObject takara;
    [SerializeField] GameObject enemy;  
   // [SerializeField] float delayTime = 5.0f;  

    private bool isTriggered = false;  
    private float timer = 0.0f;  

    
    void Update()
    {
        if (isTriggered)
        {
            timer += Time.deltaTime;  
 
           
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("お宝とったどーーー！！！");
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && !isTriggered)
        {
            Destroy(takara);  
            isTriggered = true;
           

            SceneManager.LoadScene("testescapeScene");
        }
    }
}

