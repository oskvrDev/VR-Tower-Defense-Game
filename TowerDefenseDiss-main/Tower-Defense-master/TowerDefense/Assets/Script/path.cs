using UnityEngine;

public class path : MonoBehaviour
{
    public static Transform[] paths;


    void Awake()
    {
        paths = new Transform[transform.childCount];
        for (int i = 0; i < paths.Length; i++)
        {
            paths[i] = transform.GetChild(i);
        }
    }
}
