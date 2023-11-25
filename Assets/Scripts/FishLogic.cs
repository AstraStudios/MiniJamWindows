using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishLogic : MonoBehaviourSingletonPersistent<FishLogic>
{
    public Fish fishon;

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

    [Header("Lakes")]
    [SerializeField] List<Fish> LakePowell = new List<Fish>();
    [SerializeField] List<Fish> Everglades = new List<Fish>();
    [SerializeField] List<Fish> LakeFork = new List<Fish>();
    [SerializeField] List<Fish> LakeMichigan = new List<Fish>();

    private void Awake()
    {
        base.Awake();
        LakePowell.AddRange(new List<Fish>
        {
            new Fish { Name = "Catfish", minWeight = 2, maxWeight = 15, fishSprite = CatfishSprite, fightPower = 5 },
            new Fish { Name = "Striped Bass", minWeight = 5, maxWeight = 20, fishSprite = StripedBassSprite, fightPower = 6 },
            new Fish { Name = "Largemouth Bass", minWeight = 1, maxWeight = 12, fishSprite = LargemouthBassSprite, fightPower = 3 },
            new Fish { Name = "Bluegill", minWeight = .1, maxWeight = 1.4, fishSprite = BlueGillSprite, fightPower = 1 }
        });
        Everglades.AddRange(new List<Fish>
        {
            new Fish { Name = "Sea Trout", minWeight = 1, maxWeight = 4, fishSprite = SeaTroutSprite, fightPower = 4 },
            new Fish { Name = "Tarpon", minWeight = 50, maxWeight = 280, fishSprite = TarponSprite, fightPower = 10 },
            new Fish { Name = "Snook", minWeight = 5, maxWeight = 10, fishSprite = SnookSprite, fightPower = 7 },
            new Fish { Name = "RedFish", minWeight = 4, maxWeight = 45, fishSprite = RedFishSprite, fightPower = 5 }
        });
        LakeFork.AddRange(new List<Fish>
        {
            new Fish { Name = "Catfish", minWeight = 2, maxWeight = 15, fishSprite = CatfishSprite, fightPower = 5 },
            new Fish { Name = "Largemouth Bass", minWeight = 1, maxWeight = 12, fishSprite = LargemouthBassSprite, fightPower = 3 },
            new Fish { Name = "Crappie", minWeight = .1, maxWeight = 3.67, fishSprite = CrappieSprite, fightPower = 2 },
            new Fish { Name = "Sunfish", minWeight = .1, maxWeight = 2.1, fishSprite = SunfishSprite, fightPower = 1 },
            new Fish { Name = "Bluegill", minWeight = .1, maxWeight = 1.4, fishSprite = BlueGillSprite, fightPower = 1 }
        });
        LakeMichigan.AddRange(new List<Fish>
        {
            new Fish { Name = "Smallmouth Bass", minWeight = .8, maxWeight = 12, fishSprite = SmallmouthBassSprite, fightPower = 4 },
            new Fish { Name = "Rainbow Trout", minWeight = 1, maxWeight = 6, fishSprite = RainbowTroutSprite, fightPower = 5 },
            new Fish { Name = "Largemouth Bass", minWeight = 1, maxWeight = 12, fishSprite = LargemouthBassSprite, fightPower = 3 },
            new Fish { Name = "Salmon", minWeight = 3, maxWeight = 12, fishSprite = SalmonSprite, fightPower = 7 }
        });
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

    }
}
