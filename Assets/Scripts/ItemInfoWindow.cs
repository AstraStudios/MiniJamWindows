using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FishInfoPopup : MonoBehaviourSingletonPersistent<FishInfoPopup>
{
    public List<my_text_item> text_queue;

    [SerializeField] private TMP_Text info_text;

    private void Awake()
    {
        base.Awake();
        text_queue = new List<my_text_item>();
    }

    private void Update()
    {
        if (text_queue.Count > 0)
            info_text.text = text_queue[text_queue.Count - 1].text;
        else
            info_text.text = "Hover over something for more info!";
    }
}

public class my_text_item
{
    public string text;
    public float id;

    public override int GetHashCode() => id.GetHashCode();
    public bool Equals(my_text_item obj)
    {
        return id == ((my_text_item)obj).id;
    }

    public my_text_item(string text_)
    {
        text = text_;
        id = Time.time; 
    }

}

