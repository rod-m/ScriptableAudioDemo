using System.Collections;
using System.Collections.Generic;
using SalfordGames;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] public PlayerProps playerProps;

    void Start()
    {
        Debug.Log($"My health is {playerProps.maxHealth}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
