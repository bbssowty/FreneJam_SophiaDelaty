using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform lSpawn;
    [SerializeField] private Transform rSpawn;
    [SerializeField] private GameObject lUnitPrefab;
    [SerializeField] private GameObject rUnitPrefab;
    [SerializeField] private UnitData unitData; //jme suis arretee la

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) { SendUnit(true); }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { SendUnit(false); }
    }
    
    private void SendUnit(bool left)
    {
        if (left == true) 
        {
            GameObject obj = Instantiate(lUnitPrefab);
            obj.transform.position = lSpawn.position;
        }

        if (left == false) 
        {
            GameObject obj = Instantiate(rUnitPrefab);
            obj.transform.position = rSpawn.position;
        }
    }
}
