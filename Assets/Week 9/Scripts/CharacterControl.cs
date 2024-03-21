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
    

    private void Update()
    {
        textMeshProUGUI.text = VillagerType;
    }

}
