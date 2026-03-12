using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasClear : MonoBehaviour
{
    [SerializeField] GameObject Claer;
    static float times;
  

    // Start is called before the first frame update
    void Start()
    {
        times = 0;
        Claer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        times += Time.deltaTime;
        int remaining = (int)times;
        Debug.Log(times);

        if (remaining == 3)
        {
            Claer.SetActive(true);
        }

    }
}
