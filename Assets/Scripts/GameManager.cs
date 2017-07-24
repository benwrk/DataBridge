using Data;
using Data.Models.Clues;
using Data.Models.Problems;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public IList<Problem> Problems;
    public IList<Clue> Clues;

    public int Level;

    private void Awake()
    {
        Problems = XmlParser.GetProblems(Level);
        Clues = XmlParser.GetClues(Level);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GameStates.IsGrabbing && Input.GetMouseButtonUp(1))
            GameStates.FloatingObjectsEnabled = !GameStates.FloatingObjectsEnabled;

    }
}