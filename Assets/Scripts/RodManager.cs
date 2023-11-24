using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RodManager : MonoBehaviour
{
    [Header("Preset UI")]
    //Add stuff here

    // add these for each rod
    [Header("Rod Independents")]
    [SerializeField] GameObject rod;
    [SerializeField] string rodName;
    [SerializeField] float rodStrength;
    //[SerializeField] float rodUseAmount; // define later
    [SerializeField] float rodPrice;

    [Header("Rod Essientals")]
    [SerializeField] GameObject lineStartPoint;
    [SerializeField] GameObject bobber;
    [SerializeField] Material lineMat;

    LineRenderer lineRenderer;

    float power = -3;
    bool casting = false;

    float reelSpeed = 2f;

    private void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = .1f;
        lineRenderer.endWidth = .1f;
        lineRenderer.material = lineMat;
    }

    private void Update()
    {
        // to cast
        if (Input.GetMouseButton(1)) casting = true;

        if (Input.GetMouseButtonUp(1))
        {
            if (!GameObject.Find("PlaceHolderBobber(Clone)")) {Instantiate(bobber, new Vector2(Random.Range(-7, 7), power), Quaternion.identity);}
            if (GameObject.Find("PlaceHolderBobber(Clone)")) Debug.Log("Already casted");

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, lineStartPoint.transform.position);
            lineRenderer.SetPosition(1, GameObject.Find("PlaceHolderBobber(Clone)").transform.position);
        }
        if (casting)
        {
            if (power < 4) power += Time.deltaTime; // try to use delta time instead of a constant
            if (power >= 4) { power = 4; casting = false; } // maybe run a `finish_cast` function or something
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
        if(GameObject.Find("PlaceHolderBobber(Clone)")) if (Vector2.Distance(GameObject.Find("PlaceHolderBobber(Clone)").transform.position, lineStartPoint.transform.position) <= 1) if (Input.GetKeyDown(KeyCode.E)) Destroy(GameObject.Find("PlaceHolderBobber(Clone)"));
    }

}
