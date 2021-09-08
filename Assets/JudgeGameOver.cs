using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeGameOver :MonoBehaviour
{
    CreateFoods createFoods;

    private void Start()
    {
        createFoods = GameObject.Find("Main Camera").GetComponent<CreateFoods>();
    }

    public void OnTriggerEnter(Collider other)
    {
        createFoods.GoStatus = Status.GameOver;
    }
}
