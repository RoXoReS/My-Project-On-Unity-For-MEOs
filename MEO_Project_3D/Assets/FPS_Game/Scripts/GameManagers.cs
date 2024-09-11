using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagers : MonoBehaviour
{
    [Header("Инвентарь")]
    public List<GameObject> Weapon = new List<GameObject>();
    [Header("Башни для защиты")]
    public List<GameObject> Tower = new List<GameObject>();
    public Button[] TowerMenuButtons;
    [Space]
    [Header("Обьекты")]
    public GameObject Player;
    public GameObject Camera;
    [Space]
    [Header("Настройки игры")]
    public bool CanInput;
    void Start()
    {
        CanInput = true;
        CheckInput();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckInput()
    {
        if (CanInput == true)
        {
            Player.GetComponent<PlayerManager>().CanINPUT = true;
            Weapon[Player.GetComponent<PlayerManager>().IndexOfWearing].GetComponent<WeaponManager>().CanFire = true;
            Camera.GetComponent<CameraManager>().CanINPUT = true;
        }
        else if (CanInput == false)
        {
            Player.GetComponent<PlayerManager>().CanINPUT = false;
            if (Weapon[Player.GetComponent<PlayerManager>().IndexOfWearing].GetComponent<WeaponManager>() != null)
            {
                Weapon[Player.GetComponent<PlayerManager>().IndexOfWearing].GetComponent<WeaponManager>().CanFire = false;
            }
            Camera.GetComponent<CameraManager>().CanINPUT = false;
        }
    }

    public void SpawnTower(Transform pos, int TowerIndex)
    {
        Instantiate(Tower[TowerIndex], pos.position, Quaternion.identity);
    }
}
