using Data.Models.Problems;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ChoiceProblemController : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject Controller;
    public RigidbodyFirstPersonController RbController;

    public int ProblemNumber;
    
    private static List<T> GetRandomlyOrderedList<T>(List<T> originalList)
    {
        var originalListClone = new List<T>(originalList);
        var randomizedList = new List<T>();
        
        var random = new System.Random();
        while (originalListClone.Count > 0)
        {
            var randomNumber = random.Next(0, originalListClone.Count - 1);
            randomizedList.Add(originalListClone[randomNumber]);
            originalListClone.RemoveAt(randomNumber);
        }

        return randomizedList;
    }


    // Use this for initialization
    private void Start()
    {
        Cursor.visible = false;

    }

    private void ToggleFreezeOfPlayer()
    {
        Controller.GetComponent<PlayerController>().ToggleFreeze();
        RbController.lookRotationEnabled = !RbController.lookRotationEnabled;
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Debug.Log(Cursor.lockState);
        }
        else if (Cursor.lockState == CursorLockMode.Confined)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log(Cursor.lockState);
        }

        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
        else if (!Cursor.visible)
        {
            Cursor.visible = true;
        }
    }
}
