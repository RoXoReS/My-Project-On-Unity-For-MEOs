using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class EnemyManager : MonoBehaviour
{
    Rigidbody rb;
    int WCheck;
    int MaxHealth;

    [Header("Точки для дохода")]
    [SerializeField] WaveManager waveManager;
    [Space]
    [Header("Характеристики противника")]
    [SerializeField] int speed;
    [SerializeField] int damage;
    public int health;
    [Header("Обьекты для кода")]
    [SerializeField] Slider HealthBar;
    [SerializeField] TextMeshProUGUI HealthText;
    [SerializeField] Transform Player;
    void Start()
    {
        MaxHealth = health;
        HealthBar.maxValue = MaxHealth;
        WCheck = 0;
        rb = GetComponent<Rigidbody>();
        GameObject Players = GameObject.Find("Player");
        Player = Players.transform;
        GameObject Managers = GameObject.Find("Manager");
        waveManager = Managers.GetComponent<WaveManager>();
    }

    void Update()
    {
        Moving();
        HideHealthBar();
        UpdateHeathBar();
    }

    void Moving()
    {
        if (transform.position == waveManager.CheckPoints[WCheck].transform.position)
        {
            WCheck++;
        }
        float step = speed * Time.deltaTime;
        Vector3 GoTo = new Vector3(waveManager.CheckPoints[WCheck].transform.position.x, transform.position.y, waveManager.CheckPoints[WCheck].transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, GoTo, step);
    }

    void HideHealthBar()
    {
        float ToPlayerDist = Vector3.Distance(transform.position, Player.position);
        if (ToPlayerDist >= Player.gameObject.GetComponent<PlayerManager>().DistShowHealthBarEnemy)
        {
            HealthBar.gameObject.SetActive(false);
        }
        else
        {
            HealthBar.gameObject.SetActive(true);
        }
    }

    void UpdateHeathBar()
    {
        HealthBar.value = health;
        HealthText.text = health + "/" + MaxHealth;
        if (health > MaxHealth)
        {
            health = MaxHealth;
        }
        else if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
