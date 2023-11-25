using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishLogic : MonoBehaviourSingletonPersistent<FishLogic>
{
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
        List<Fish> currFish = new List<Fish>();

        switch (currLake)
        {
            case "LakePowell":
                for (int q = 0; q < LakePowell.Count; q++)
                {
                    
                }
                break;
        }
    }
}
