using UnityEngine;
using System.Collections;

public class PusherScript : MonoBehaviour
{
    private Vector3 origin;

    void Update()
    {
        Vector3 offset = new Vector3(0, 0, 2 * Mathf.Sin(Time.time));
        GetComponent<Rigidbody>().MovePosition(origin + offset);
    }

    void Awake()
    {
        origin = GetComponent<Rigidbody>().position;
    }
}
