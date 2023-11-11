using UnityEngine;
using System;
using System.Collections;

public class BuildingSlot : MonoBehaviour
{
    private GameObject _building;
    private BuildingManager _buildingManager;

    public bool IsEmpty { get; set; }

    private void Start()
    {
        IsEmpty = true;
        _buildingManager = FindObjectOfType<BuildingManager>();
    }

    public void SetBuilding()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Tower"))
            {
                _building = child.gameObject;
            }
        }
        StartCoroutine(CheckSlot());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && IsEmpty)
        {
            _buildingManager.SetSlot(this);
            _buildingManager.OpenBuilingPanel();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && IsEmpty)
        {
            _buildingManager.CloseBuilingPanel();
        }
    }

    private IEnumerator CheckSlot()
    {
        while(true)
        {
            if(_building == null)
                IsEmpty = true;
            else
                IsEmpty = false;
            
            yield return new WaitForSeconds(1);
        }
    }
}
