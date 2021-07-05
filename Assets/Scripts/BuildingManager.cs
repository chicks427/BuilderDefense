using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private BuildingTypeSO building;
    private BuildingTypeListSO buildingList;

    private void Start()
    {
        buildingList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        building = buildingList.list[0];
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(building.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            building = buildingList.list[0];
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            building = buildingList.list[1];
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }
}
