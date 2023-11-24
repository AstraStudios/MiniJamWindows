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
    [SerializeField] string rodName;
    [SerializeField] float rodStrength;
    //[SerializeField] float rodUseAmount; // define later
    [SerializeField] float rodPrice;

    [Header("Rod Essientals")]
    [SerializeField] GameObject lineStartPoint;
    [SerializeField] GameObject bobber;
    [SerializeField] Material lineMat;

    LineRenderer lineRenderer;

    float power = 1;
    bool casting = false;

    private void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = .1f;
        lineRenderer.endWidth = .1f;
        lineRenderer.material = lineMat;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            casting = true;
            Instantiate(bobber, new Vector2(0, power / 10), Quaternion.identity);
        }

        if (casting)
        {
            if (power < 100) power += 1; // try to use delta time instead of a constant
            if (power >= 100) { power = 100; casting = false; } // maybe run a `finish_cast` function or something
        }
    }
}
