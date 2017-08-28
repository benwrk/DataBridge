using UnityEngine;

public class MainLights : MonoBehaviour
{
    public void IncreaseRange()
    {
        var lightObjects = GameObject.FindGameObjectsWithTag("Light");

        foreach (var lightObject in lightObjects)
        {
            lightObject.GetComponent<Animator>().Play("Lights on", 0, 0);
        }
    }
}
