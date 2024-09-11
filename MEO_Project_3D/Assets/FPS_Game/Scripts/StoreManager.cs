using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] GameManagers GamesManager;
    [SerializeField] SlotsManager SlotManager;
    [Header("Обьекты текста")]
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI Price;
    [SerializeField] TextMeshProUGUI Level;
    [SerializeField] TextMeshProUGUI FireRate;
    [SerializeField] TextMeshProUGUI Damage;
    [Header("Обьекты меню")]
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject TowerHave;
    [SerializeField] GameObject TowerNotHave;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTowerSettings(int IndexOfTower)
    {
        Menu.SetActive(false);
        TowerHave.SetActive(false);
        TowerNotHave.SetActive(false);
        if (SlotManager.Empty == true)
        {
            Menu.SetActive(true);
            TowerNotHave.SetActive(true);
            Name.text = GamesManager.Tower[IndexOfTower].GetComponent<TowerManager>().TowerName;
            Price.text = GamesManager.Tower[IndexOfTower].GetComponent<TowerManager>().TowerPrice.ToString();
            Level.text = GamesManager.Tower[IndexOfTower].GetComponent<TowerManager>().Level.ToString();
            FireRate.text = Mathf.Round(GamesManager.Tower[IndexOfTower].GetComponent<TowerManager>().FireRate).ToString();
            Damage.text = GamesManager.Tower[IndexOfTower].GetComponent<TowerManager>().Damage.ToString();
        }
    }
}
