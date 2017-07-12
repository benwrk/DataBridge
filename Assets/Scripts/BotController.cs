using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BotController : MonoBehaviour
{

    public enum MoveType { Time, Speed }
    public static BotController instance;

    void Awake()
    {
        if (instance)
        {
            Debug.LogWarning("Only one instance of the MoveObject script in a scene is allowed");
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(instance.TranslateTo(gameObject.transform, new Vector3(2.08f, 0.05f, 22.62f), 2.5f, MoveType.Speed));
        StartCoroutine(instance.Rotation(gameObject.transform, new Vector3(0f, -90f, 0f), 2.5f));
    }


    /* public IEnumerator LookAtPlayer()
    {
        yield return gameObject.transform.LookAt(mainPlayer.transform);
    }*/


    public IEnumerator TranslateTo(Transform thisTransform, Vector3 endPos, float value, MoveType moveType)
    {
        yield return Translation(thisTransform, thisTransform.position, endPos, value, moveType);
    }

    public IEnumerator Translation(Transform thisTransform, Vector3 endPos, float value, MoveType moveType)
    {
        yield return Translation(thisTransform, thisTransform.position, thisTransform.position + endPos, value, moveType);
    }

    public IEnumerator Translation(Transform thisTransform, Vector3 startPos, Vector3 endPos, float value, MoveType moveType)
    {


        // conditional operator x ? y : z , if x is true , then y and if x is false then z
        //if MoveType is Time then true, else false i.e speed
        float rate = (moveType == MoveType.Time) ? 1.0f / value : 1.0f / Vector3.Distance(startPos, endPos) * value;

        float t = 0.0f;
        while (t < 1.0)
        {
            t += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0.0f, 1.0f, t));
            yield return null;
        }
    }

    public IEnumerator Rotation(Transform thisTransform, Vector3 degrees, float time)
    {
        Quaternion startRotation = thisTransform.rotation;
        Quaternion endRotation = thisTransform.rotation * Quaternion.Euler(degrees);
        float rate = 1.0f / time;
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime * rate;
            thisTransform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }
    }
}
