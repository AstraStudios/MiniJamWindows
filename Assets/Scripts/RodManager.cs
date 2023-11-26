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
    [SerializeField] Slider castPowerSlider;
    [SerializeField] GameObject castPowerSliderObj;
    [SerializeField] GameObject hitText;
    [SerializeField] Slider reelSlider;
    [SerializeField] GameObject reelSliderObj;

    // add these for each rod
    [Header("Rod Independents")]
    [SerializeField] GameObject rodSprite;
    [SerializeField] float rodStrength;
    [SerializeField] SpriteRenderer spriteRenderer;
    //[SerializeField] float rodUseAmount; // define later

    [Header("Rod Essientals")]
    [SerializeField] GameObject lineStartPoint;
    [SerializeField] GameObject bobber;
    [SerializeField] Material lineMat;
    [SerializeField] FishLogic fishLogicScript;

    LineRenderer lineRenderer;

    float power = -3;
    bool casting = false;
    bool fishWeightSet = false;

    float reelSpeed = .5f;
    bool fishCaught = false;
    float pullawaySpeed;
    float totalSpeed;

    public float fishWeight;

    private void Start()
    {
        //spriteRenderer.sprite = rodSprite;
        Instantiate(rodSprite, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        // set up line rendering
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = .1f;
        lineRenderer.endWidth = .1f;
        lineRenderer.material = lineMat;
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        // to cast
        if (Input.GetMouseButton(1) && !GameObject.Find("PlaceHolderBobber(Clone)")) casting = true;

        if (Input.GetMouseButtonUp(1))
        {
            casting = false;
            castPowerSliderObj.SetActive(false);
            if (!GameObject.Find("PlaceHolderBobber(Clone)")) {Instantiate(bobber, new Vector2(Random.Range(-7, 7), power), Quaternion.identity);}
            if (GameObject.Find("PlaceHolderBobber(Clone)")) Debug.Log("Already casted");

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, lineStartPoint.transform.position);
            lineRenderer.SetPosition(1, GameObject.Find("PlaceHolderBobber(Clone)").transform.position);

            fishLogicScript.ChooseFish();
            StartCoroutine(WaitForHit());
        }
        if (casting)
        {
            castPowerSliderObj.SetActive(true);
            if (power < 4) power += Time.deltaTime * 2; castPowerSlider.value = power; // delta time * 2 because delta time is too slow
            if (power >= 4) { power = 4; casting = false; }
            Debug.Log(power);
        }
        // end cast
        // reel in
        if (Input.GetMouseButton(0))
        {
            float step = reelSpeed * Time.deltaTime;
            GameObject.Find("PlaceHolderBobber(Clone)").transform.position = Vector2.MoveTowards(GameObject.Find("PlaceHolderBobber(Clone)").transform.position, lineStartPoint.transform.position, step);
            lineRenderer.SetPosition(0, lineStartPoint.transform.position);
            lineRenderer.SetPosition(1, GameObject.Find("PlaceHolderBobber(Clone)").transform.position);
        }
        // pull up(hopefully gets better)
        if (GameObject.Find("PlaceHolderBobber(Clone)")) if (Vector2.Distance(GameObject.Find("PlaceHolderBobber(Clone)").transform.position, lineStartPoint.transform.position) <= 1) if (Input.GetKeyDown(KeyCode.E)) { Destroy(GameObject.Find("PlaceHolderBobber(Clone)")); power = -3; fishLogicScript.isFishOn = false; fishCaught = false; }
        // fish fighting mechanics
        if (fishLogicScript.isFishOn)
        {
            // make fish weight here
            if (!fishWeightSet) fishWeight = Random.Range((float) fishLogicScript.fishon.minWeight, (float)fishLogicScript.fishon.maxWeight);  fishWeightSet = true; Debug.Log(fishLogicScript.fishon.Name + fishWeight);
        }
        // make sure the fish moves when its not caught
        if (fishCaught && totalSpeed >= 0) GameObject.Find("PlaceHolderBobber(Clone)").transform.position = Vector2.MoveTowards(GameObject.Find("PlaceHolderBobber(Clone)").transform.position, new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)), totalSpeed * 1f * Time.deltaTime); Debug.Log("Moving");
        // if the fish has not been pulled up, reel in with that rods strength
        if (fishCaught && totalSpeed >= 0) { if (Input.GetMouseButton(0)) { totalSpeed -= .001f * rodStrength; } }
        // update the line every frame
        lineRenderer.SetPosition(0, lineStartPoint.transform.position);
        lineRenderer.SetPosition(1, GameObject.Find("PlaceHolderBobber(Clone)").transform.position);
        // debug speed
        Debug.Log(totalSpeed);
    }

    void FishCaught()
    {
        fishCaught = true;
        pullawaySpeed = fishLogicScript.fishon.fightPower;
        totalSpeed = pullawaySpeed;
    }

    IEnumerator WaitForHit()
    {
        yield return new WaitForSeconds(Random.Range(3, 15));
        FishCaught();
    }
}
