using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishLogic : MonoBehaviour
{
    public Fish fishon;
    public bool isFishOn = false;

    [Header("Fish Sprites")]
    [SerializeField] Sprite CatfishSprite;
    [SerializeField] Sprite StripedBassSprite;
    [SerializeField] Sprite LargemouthBassSprite;
    [SerializeField] Sprite BlueGillSprite;
    [SerializeField] Sprite SeaTroutSprite;
    [SerializeField] Sprite TarponSprite;
    [SerializeField] Sprite SnookSprite;
    [SerializeField] Sprite RedFishSprite;
    [SerializeField] Sprite CrappieSprite;
    [SerializeField] Sprite SunfishSprite;
    [SerializeField] Sprite SmallmouthBassSprite;
    [SerializeField] Sprite RainbowTroutSprite;
    [SerializeField] Sprite SalmonSprite;

    // lakes
    [SerializeField] List<Fish> LakePowell = new List<Fish>();
    List<Fish> Everglades = new List<Fish>();
    List<Fish> LakeFork = new List<Fish>();
    List<Fish> LakeMichigan = new List<Fish>();

    private void Awake()
    {
        LakePowell.Add(new Fish("Catfish", 2, 15, 5, CatfishSprite));
        LakePowell.Add(new Fish("Striped Bass", 5, 20, 5, StripedBassSprite));
        LakePowell.Add(new Fish("Largemouth Bass", 1, 12, 3, LargemouthBassSprite));
        LakePowell.Add(new Fish("Bluegill", 0.1, 1.4, 1, BlueGillSprite));
        Everglades.Add(new Fish("Sea Trout", 1, 4, 5, SeaTroutSprite));
        Everglades.Add(new Fish("Tarpon", 50, 280, 10, TarponSprite));
        Everglades.Add(new Fish("Snook", 5, 10, 7, SnookSprite));
        Everglades.Add(new Fish("Redfish", 4, 45, 6, RedFishSprite));
        LakeFork.Add(new Fish("Catfish", 2, 15, 5, CatfishSprite));
        LakeFork.Add(new Fish("Largemouth Bass", 1, 12, 3, LargemouthBassSprite));
        LakeFork.Add(new Fish("Crappie", 0.1, 3.67, 4, CrappieSprite));
        LakeFork.Add(new Fish("Sunfish", 0.1, 12, 1, SunfishSprite));
        LakeFork.Add(new Fish("Bluegill", 0.1, 1.4, 1, BlueGillSprite));
        LakeMichigan.Add(new Fish("Smallmouth Bass", 0.8, 12, 2, SmallmouthBassSprite));
        LakeMichigan.Add(new Fish("Rainbow Trout", 1, 6, 4, RainbowTroutSprite));
        LakeMichigan.Add(new Fish("Largemouth Bass", 1, 12, 3, LargemouthBassSprite));
        LakeMichigan.Add(new Fish("Salmon", 3, 12, 6, SalmonSprite));
    }

    public void ChooseFish()
    {
        string currLake = SceneManager.GetActiveScene().name;
        int randFish = Random.Range(0, 100);

        switch (currLake)
        {
            case "LakePowell":
                if (randFish < 5 && randFish > 0) fishon = LakePowell[1];
                if (randFish < 20 && randFish > 6) fishon = LakePowell[0];
                if (randFish < 50 && randFish > 21) fishon = LakePowell[2];
                if (randFish <= 100 && randFish > 51) fishon = LakePowell[3];
                break;
            case "Everglades":
                if (randFish <= 100 && randFish > 51) fishon = Everglades[0];
                if (randFish <= 2 && randFish > 0) fishon = Everglades[1];
                if (randFish < 11 && randFish > 3) fishon = Everglades[2];
                if (randFish < 50 && randFish > 12) fishon = Everglades[3];
                break;
            case "LakeFork":
                if (randFish < 10 && randFish > 0) fishon = LakeFork[0];
                if (randFish < 35 && randFish > 11) fishon = LakeFork[1];
                if (randFish < 50 && randFish > 36) fishon = LakeFork[2];
                if (randFish < 70 && randFish > 51) fishon = LakeFork[3];
                if (randFish <= 100 && randFish > 71) fishon = LakeFork[4];
                break;
            case "LakeMichigan":
                if (randFish < 60 && randFish > 0) fishon = LakeMichigan[0];
                if (randFish < 70 && randFish > 61) fishon = LakeMichigan[1];
                if (randFish < 95 && randFish > 71) fishon = LakeMichigan[2];
                if (randFish <= 100 && randFish > 96) fishon = LakeMichigan[3];
                break;
        }
        isFishOn = true;
    }
}
