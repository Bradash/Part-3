using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Merchant merchant;
    public Archer archer;
    public Thief thief;
    Vector3 villagerScale;

    public static string VillagerType;
    public TextMeshProUGUI textMeshProUGUI;
    public static Villager SelectedVillager { get; private set; }

    public void Dropdown(int options)
    {
        switch (options)
        {
            case 0:
                SetSelectedVillager(merchant);
                break;
            case 1:
                SetSelectedVillager(archer);
                break;
            case 2:
                SetSelectedVillager(thief);
                break;
        }
    }
    public static void SetSelectedVillager(Villager villager)
    {
        if (SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
            VillagerType = "None";
        }
        SelectedVillager = villager;
        VillagerType = villager.name;
        SelectedVillager.Selected(true);
    }
    private void Start()
    {
        villagerScale.x = 1f;
        villagerScale.y = 1f;
        villagerScale.z = 1f;
    }
    public void VillagerScale(float scale = 0.5f)
    {
        villagerScale.x = scale*2;
        villagerScale.y = scale*2;
        villagerScale.z = scale*2;

    }
    private void Update()
    {
        textMeshProUGUI.text = VillagerType;
        SelectedVillager.transform.localScale = villagerScale;
    }

}
