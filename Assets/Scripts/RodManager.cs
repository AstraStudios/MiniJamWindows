using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RodManager : MonoBehaviour
{
    [Header("Preset UI")]
    //Not for main scene
    [SerializeField] Slider charge_power_slider;
    [SerializeField] GameObject hitText;
    [SerializeField] GameObject fish_caught_text;
    [SerializeField] TMP_Text fishStatText;
    [SerializeField] GameObject fishStatObj;

    // add these for each rod
    [Header("Rod Independents")]
    [SerializeField] float rodStrength;
    //[SerializeField] float rodUseAmount; // define later

    [Header("Rod Essientals")]
    [SerializeField] GameObject rod_tip;
    [SerializeField] GameObject bobber_prefab;
    [SerializeField] FishLogic fishLogicScript;

    Vector3 water_point; // where the line is being cast to

    float charge_power = 0f;

    float reelSpeed = .5f;
    float fish_speed;
    public float fishWeight;
    float in_air_time = 0f;

    public enum BobberState
    {
        InHand,
        Swinging,
        InAir,
        WaitingInWater,
        CaughtInWater,
    }
    BobberState bobber_state = BobberState.InHand;
    GameObject bobber;
    float hit_countdown;

    private void Update()
    {
        if (bobber_state == BobberState.InHand)
        {
            if (Input.GetMouseButtonDown(0))
            {
                bobber = Instantiate(bobber_prefab);
                bobber.transform.position = rod_tip.transform.position;

                bobber_state = BobberState.InAir;
                in_air_time = 0f;

                water_point = new Vector3(Random.Range(-3, 0), Random.Range(-3, 3), 0);
            }
        }

        else if (bobber_state == BobberState.InAir)
        {
            in_air_time += Time.deltaTime * .5f;
            in_air_time = Mathf.Clamp(in_air_time, 0f, 1f);

            Vector3 air_point = water_point + new Vector3(2, 4f, 0);

            Vector3 ab = Vector3.Lerp(rod_tip.transform.position, air_point, in_air_time);
            Vector3 bc = Vector3.Lerp(air_point, water_point, in_air_time);

            bobber.transform.position = Vector3.Lerp(ab, bc, in_air_time);

            if (in_air_time == 1f)
            {
                fishLogicScript.ChooseFish();
                hit_countdown = 5f; // RANDOMIZE TIMER

                bobber_state = BobberState.WaitingInWater;
            }
        }

        else if (bobber_state == BobberState.WaitingInWater)
        {
            hit_countdown -= Time.deltaTime;

            // reel in (resets timer)
            if (Input.GetMouseButton(0))
            {
                float distance = reelSpeed * Time.deltaTime;
                bobber.transform.position = Vector2.MoveTowards(bobber.transform.position, rod_tip.transform.position, distance);

                hit_countdown = 5f;
            }

            if (hit_countdown <= 0f)
            {
                bobber_state = BobberState.CaughtInWater;
                FishCaught();
            }
        }

            
        // fish fighting mechanics
        else if (bobber_state == BobberState.CaughtInWater)
        {
            // calculate fish weight
            fishWeight = Random.Range((float) fishLogicScript.fishon.minWeight, (float)fishLogicScript.fishon.maxWeight);

            // swim away
            bobber.transform.position += (bobber.transform.position - rod_tip.transform.position).normalized * fish_speed * Time.deltaTime * .1f;

            // reel in
            if (Input.GetMouseButtonDown(0))
                bobber.transform.position -= (bobber.transform.position - rod_tip.transform.position).normalized * rodStrength * .01f;
        }

        // if the bobber is close enough, pull up
        if (
            (bobber_state == BobberState.WaitingInWater ||
             bobber_state == BobberState.CaughtInWater) &&
            Vector2.Distance(bobber.transform.position, rod_tip.transform.position) <= .5f)
        {
            Destroy(bobber);

            if (bobber_state == BobberState.CaughtInWater)
            {
                fishLogicScript.CatchUIFish(fishWeight);
                StartCoroutine(DisplayStatsForSeconds());
                fish_speed = 0f;
            }

            bobber_state = BobberState.InHand;
        }
    }

    void FishCaught()
    {
        StartCoroutine(DisplayHitUISeconds());
        fish_speed = fishLogicScript.fishon.fightPower;
    }
    IEnumerator DisplayHitUISeconds()
    {
        hitText.SetActive(true);
        yield return new WaitForSeconds(2);
        hitText.SetActive(false);
    }

    IEnumerator DisplayStatsForSeconds()
    {
        fishStatObj.SetActive(true);
        fishStatText.text = ("You caught a " + fishLogicScript.fishon.Name + " that weights " + Mathf.Round(fishWeight) + "lb. Good Job!");
        yield return new WaitForSeconds(5);
        fishStatObj.SetActive(false);
    }
}
