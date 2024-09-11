using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public Slider HealthBarPlayer;
    void Start()
    {
        HealthBarPlayer.maxValue = Player.GetComponent<MoveCharacter>().Heath;
    }

    void Update()
    {
        HealthBarPlayer.value = Player.GetComponent<MoveCharacter>().Heath;
    }
}
