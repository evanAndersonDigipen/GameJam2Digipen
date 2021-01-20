using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
/*
 * Name: Evan Anderson
 * Date: 1/19/2020
 * Desc: Switches level area/layer
 */
public class LayerSwitch : MonoBehaviour
{
    [Tooltip("Array of all the layers")]
    public GameObject[] LevelLayers = new GameObject[2];
    
    [Tooltip("the index of which layer it links to")]
    public int layerID;

    //Our layer
    GameObject ParentLayer;
    //LinkedLayer
    GameObject linkedLayer;

    //Our Tilemaps Renderers
    List<Tilemap> ourTilemaps = new List<Tilemap>();

    //Linked Tilemaps
    List<Tilemap> linkedTilemaps = new List<Tilemap>();

    //bools for the coroutines
    public bool fadeoutDone;
    public bool fadeinDone;

    // Start is called before the first frame update
    void Start()
    {
        fadeoutDone = false;
        ParentLayer = transform.parent.gameObject;
        linkedLayer = LevelLayers[layerID].gameObject;

        for (int i = 0; i < ParentLayer.transform.childCount; i++)
        {
            ourTilemaps.Add(ParentLayer.transform.GetChild(i).GetComponent<Tilemap>());
        }
        for (int i = 0; i < linkedLayer.transform.childCount; i++)
        {
            linkedLayer.transform.GetChild(i).GetComponent<Tilemap>().color = new Color(linkedLayer.transform.GetChild(i).GetComponent<Tilemap>().color.r, linkedLayer.transform.GetChild(i).GetComponent<Tilemap>().color.g, linkedLayer.transform.GetChild(i).GetComponent<Tilemap>().color.b, 0);
            linkedTilemaps.Add(linkedLayer.transform.GetChild(i).GetComponent<Tilemap>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetComponent<Tilemap>().color.a);
        if (fadeinDone && fadeoutDone)
        {
            ParentLayer.SetActive(false);
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Switch();
        }
    }
    void Switch()
    {
        
        linkedLayer.SetActive(true);
        linkedLayer.transform.GetChild(1).GetComponent<LayerSwitch>().fadeoutDone = false;
        linkedLayer.transform.GetChild(1).GetComponent<LayerSwitch>().fadeinDone = false;
        foreach (Tilemap i in ourTilemaps)
        {
            StartCoroutine(Fader(i, false));
        }
        foreach(Tilemap i in linkedTilemaps)
        {
            StartCoroutine(Fader(i, true));
        }
        

        
    }

    //I am your father
    IEnumerator Fader(Tilemap tm, bool In)
    {
        if (In)
        {
            while (tm.color.a != 1)
            {
                tm.color = Color.Lerp(tm.color, new Color(tm.color.r, tm.color.g, tm.color.b, 1), .01f);
                if(tm.color.a >= 0.5f)
                {
                    tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, 1);
                }
                
                yield return null;
            }
            
            yield return fadeinDone = true;
        }
        else
        {
            while (tm.color.a != 0)
            {
                tm.color = Color.Lerp(tm.color, new Color(tm.color.r, tm.color.g, tm.color.b, 0), .01f);
                Debug.Log(tm.color.a);
                if (tm.color.a <= 0.2f)
                {
                    tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, 0);
                }
                yield return null;
            }
            
            yield return fadeoutDone = true;
        }
        
    }
    
}
