using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour
{
    Rigidbody rb;
    RaycastHit HitInfo;
    [Range(0, 2)]public int IndexOfWearing;
    public bool IsGrounded;
    [Header("Характеристики персонажа")]
    [SerializeField, Range(0, 100)] int Health;
    [SerializeField, Range(0, 30)] int Speed;
    [SerializeField, Range(0, 20)] int JumpForce;
    [SerializeField, Range(1, 5)] int InventorySlots;
    [HideInInspector] public bool CanINPUT;
    public float DistShowHealthBarEnemy;
    [Header("Свойства для кода")]
    [SerializeField] GameManagers Managers;
    [SerializeField] LayerMask UseMask;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject UseText;
    [SerializeField] GameObject UseText2;
    [SerializeField] GameObject BackgroundPanel;
    [SerializeField] GameObject AmmoPanel;
    [SerializeField] GameObject MenuTowerPanel;
    public TextMeshProUGUI Text;

    
    void Start()
    {
        IsGrounded = true;
        CanINPUT = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (CanINPUT == true)
        {
            Move();
            RayCastingUse();
            ChangeCell();
        }
    }

    void Move()
    {
        float MoveZ = Input.GetAxis("Vertical");
        float MoveX = Input.GetAxis("Horizontal");
        Vector3 MovePlayer = new Vector3(MoveX, 0, MoveZ);
        transform.Translate(MovePlayer * Speed * Time.deltaTime);
        if (Input.GetButton("Jump") && IsGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    void RayCastingUse()
    {
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out HitInfo, 5f, UseMask) == true)
        {
            UseText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {

            }
        }
        else
        {
            UseText.SetActive(false);
        }

    }

    void ChangeCell()
    {
        try
        {
            if (Managers.Weapon[IndexOfWearing].GetComponent<WeaponManager>() == null)
            {
                AmmoPanel.SetActive(false);
                BackgroundPanel.SetActive(false);
            }
            else if (Managers.Weapon[IndexOfWearing].GetComponent<WeaponManager>() != null)
            {
                AmmoPanel.SetActive(true);
                BackgroundPanel.SetActive(true);
            }
        }
        catch
        {
            AmmoPanel.SetActive(false);
            BackgroundPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Managers.Weapon[IndexOfWearing].SetActive(false);
            if (Managers.Weapon[IndexOfWearing].GetComponent<WeaponManager>() != null)
            {
                Managers.Weapon[IndexOfWearing].GetComponent<WeaponManager>().CanFire = true;
            }
            IndexOfWearing = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Managers.Weapon[IndexOfWearing].SetActive(false);
            if (Managers.Weapon[IndexOfWearing].GetComponent<WeaponManager>() != null)
            {
                Managers.Weapon[IndexOfWearing].GetComponent<WeaponManager>().CanFire = true;
            }
            IndexOfWearing = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Managers.Weapon[IndexOfWearing].SetActive(false);
            if (Managers.Weapon[IndexOfWearing].GetComponent<WeaponManager>() != null)
            {
                Managers.Weapon[IndexOfWearing].GetComponent<WeaponManager>().CanFire = true;
            }
            IndexOfWearing = 2;
        }
        if (Input.GetAxis("Mouse ScrollWheel") >= 1f)
        {
            Managers.Weapon[IndexOfWearing].SetActive(false);
            if (Managers.Weapon[IndexOfWearing].GetComponent<WeaponManager>() != null)
            {
                Managers.Weapon[IndexOfWearing].GetComponent<WeaponManager>().CanFire = true;
            }
            IndexOfWearing--;
            IndexOfWearing = Mathf.Clamp(IndexOfWearing, 0, Managers.Weapon.Count - 1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") <= -1f)
        {
            Managers.Weapon[IndexOfWearing].SetActive(false);
            if (Managers.Weapon[IndexOfWearing].GetComponent<WeaponManager>() != null)
            {
                Managers.Weapon[IndexOfWearing].GetComponent<WeaponManager>().CanFire = true;
            }
            IndexOfWearing++;
            IndexOfWearing = Mathf.Clamp(IndexOfWearing, 0, Managers.Weapon.Count - 1);
        }
        Managers.Weapon[IndexOfWearing].SetActive(true);
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        } 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Slot"))
        {
            UseText2.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Slot"))
        {
            if (Input.GetKeyDown(KeyCode.E) && MenuTowerPanel.activeSelf == false)
            {
                UseText2.SetActive(false);
                Camera.GetComponent<CameraManager>().lockedCursor = false;
                Managers.CanInput = false;
                MenuTowerPanel.SetActive(true);
                Managers.CheckInput();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && MenuTowerPanel.activeSelf == true)
            {
                Camera.GetComponent<CameraManager>().lockedCursor = true;
                Managers.CanInput = true;
                MenuTowerPanel.SetActive(false);
                Managers.CheckInput();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Slot"))
        {
            UseText2.SetActive(false);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        } 
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Camera.transform.position, Camera.transform.position + Camera.transform.forward * 5);
    }
}
