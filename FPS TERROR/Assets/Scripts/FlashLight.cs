using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light lanterna;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lanterna.enabled = !lanterna.enabled;
        }
    }
}
