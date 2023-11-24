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

    private void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = .1f;
        lineRenderer.endWidth = .1f;
        lineRenderer.material = lineMat;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            CastOut();
        }
    }

    void CastOut()
    {
        while (Input.GetMouseButton(1))
        {
            if(power<100)power += 1;
            if (power >= 100) power = 100;
        }
        if (Input.GetMouseButtonUp(1))
        {
            bobber.transform.Translate(power / 100, 0, 0);
        }
    }
}
