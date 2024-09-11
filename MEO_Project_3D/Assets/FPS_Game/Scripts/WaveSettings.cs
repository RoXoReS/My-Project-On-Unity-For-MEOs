using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSettings : MonoBehaviour
{
    [Header("Настройка противников")]
    [Tooltip("Кол-во легких противников")]
    public int CountLowLevelEnemies;
    [Tooltip("Кол-во средних противников")]
    public int CountMediumLevelEnemies;
    [Tooltip("Кол-во сложных противников")]
    public int CountHighLevelEnemies;
    [Tooltip("Будет ли на этой волне босс?")]
    public bool Boss;
    [Space,Space]
    [Header("Настройка волны")]
    [Tooltip("Время между волнами")]
    public int TimeBetweenWaves;
}
