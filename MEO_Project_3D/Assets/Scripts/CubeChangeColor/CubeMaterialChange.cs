using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeMaterialChange : MonoBehaviour
{
    public List<Color> Colors;
    public List<bool> Zanytnost;
    Renderer Rend;
    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            Rend = other.gameObject.GetComponent<Renderer>();
            for (int i = 0; i < Colors.Count; i++)
            {
                if (Zanytnost[i] != true)
                {
                    if (other.gameObject.GetComponent<CubeIndex>().BeingChange == false)
                    {
                        Rend.material.color = Colors[i];
                        Zanytnost[i] = true;
                        other.gameObject.GetComponent<CubeIndex>().BeingChange = true;
                        other.gameObject.GetComponent<CubeIndex>().ColorIndex = i;
                        break;
                    }
                    else
                    {
                        int randCol = Random.Range(0, Colors.Count);
                        Debug.Log(randCol);
                        if (Zanytnost[randCol] != true)
                        {
                            
                            Rend.material.color = Colors[randCol];
                            Zanytnost[other.gameObject.GetComponent<CubeIndex>().ColorIndex] = false;
                            Zanytnost[randCol] = true;
                            other.gameObject.GetComponent<CubeIndex>().ColorIndex = randCol;
                            break;
                        }
                        else
                        {
                            while (Zanytnost[randCol] == true)
                            {
                                randCol = Random.Range(0, Colors.Count);
                            }
                            if (Zanytnost[randCol] != true)
                            {
                                Rend.material.color = Colors[randCol];
                                Zanytnost[other.gameObject.GetComponent<CubeIndex>().ColorIndex] = false;
                                Zanytnost[randCol] = true;
                                other.gameObject.GetComponent<CubeIndex>().ColorIndex = randCol;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
