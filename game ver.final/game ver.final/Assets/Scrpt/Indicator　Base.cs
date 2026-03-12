using UnityEngine;

//ö†èd
public class IndicatorBase : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Transform Camera;
    [SerializeField] Transform Exit;
    [SerializeField] RectTransform Indicator;

    void Update()
    {
        var rot = Quaternion.LookRotation(Exit.position - Player.position);
        var angle = (Camera.eulerAngles - rot.eulerAngles).y;
        Indicator.localEulerAngles = new Vector3(0, 0, angle);
    }
}
