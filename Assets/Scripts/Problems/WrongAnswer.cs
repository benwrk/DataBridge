﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongAnswer : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(TaskOnClick);
    }


    private void TaskOnClick()
    {
        _button.interactable = false;
    }
}
