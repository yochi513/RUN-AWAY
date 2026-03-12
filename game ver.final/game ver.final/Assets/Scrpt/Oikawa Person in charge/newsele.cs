using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class newsele : MonoBehaviour
{
    Button selec;

    // Start is called before the first frame update
    void Start()
    {
       selec = GameObject.Find("/Canvas/Button").GetComponent<Button>();

        selec.Select();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
