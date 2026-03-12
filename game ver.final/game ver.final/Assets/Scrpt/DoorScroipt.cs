using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ö†èd
public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject[] Control;
    private List<GameObject> hiddenObjects = new List<GameObject>();

    public void HideSpecifiedObjects()
    {
        foreach (GameObject obj in Control)
        {
            hiddenObjects.Add(obj);
            obj.SetActive(false);
        }
    }



    public void ShowSpecifiedObjects()
    {
        foreach (GameObject obj in hiddenObjects)
        {
            obj.SetActive(true);
        }
        hiddenObjects.Clear();
    }
}
