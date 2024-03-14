using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public static string VillagerType;
    public TextMeshProUGUI textMeshProUGUI;
    public static Villager SelectedVillager { get; private set; }
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
