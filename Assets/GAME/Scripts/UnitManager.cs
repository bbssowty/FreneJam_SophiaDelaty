using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform lSpawn;
    [SerializeField] private Transform rSpawn;
    [SerializeField] private GameObject lUnitPrefab; //jsp si c bien un go
    [SerializeField] private GameObject rUnitPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) { SendUnit(true); }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { SendUnit(false); }
    }
    
    private void SendUnit(bool left)
    {
        if (left == true) 
        { 
            Debug.Log("left");
        }

        if (left == false) 
        {
            Debug.Log("right");
        }
    }
}
