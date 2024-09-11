using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WaveManager : MonoBehaviour
{
    [Header("Настройки режимов игровых волн")]
    [SerializeField] List<WaveSettings> WavesCount;
    [SerializeField] List<Transform> SpawnPoints;
    [SerializeField] public List<GameObject> CheckPoints;
    [SerializeField] List<GameObject> Enemies;
    [SerializeField] List<GameObject> Bosses;
    [SerializeField] TextMeshProUGUI TimeText;
    int Seconds;
    int Minutes;
    void Start()
    {
        InvokeRepeating(nameof(SpawningEnemy), 1f, 10f);
    }

    void Update()
    {
        Seconds = (int)Mathf.Round(Time.time);
        
        if (Seconds >= 60)
        {
            Minutes = (int)Mathf.Round(Seconds / 60);
            Seconds = Seconds % 60;
        }
        TimeText.text = Minutes.ToString() + ":" + Seconds.ToString("D2");
    }

    void SpawningEnemy()
    {
        Instantiate(Enemies[Random.Range(0, Enemies.Count)], SpawnPoints[Random.Range(0, SpawnPoints.Count)].position, Quaternion.identity);
    }
}
