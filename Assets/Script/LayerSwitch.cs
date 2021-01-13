using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LayerSwitch : MonoBehaviour
{
    [Tooltip("Array of all the layers")]
    public GameObject[] LevelLayers = new GameObject[2];
    
    [Tooltip("the index of which layer it links to")]
    public int linkedLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Tilemap linkedTM = LevelLayers[linkedLayer].transform.GetChild(1).GetComponent<Tilemap>();
        Tilemap thisTM = GetComponent<Tilemap>();
        LevelLayers[linkedLayer].SetActive(true);
        /*linkedTM.color = new Color(linkedTM.color.r, linkedTM.color.g, linkedTM.color.b, 0);
        linkedTM.color = Color.Lerp(linkedTM.color, new Color(linkedTM.color.r, linkedTM.color.g, linkedTM.color.b, 1), .01f);
        thisTM.color = Color.Lerp(linkedTM.color, new Color(linkedTM.color.r, linkedTM.color.g, linkedTM.color.b, 0), .01f);*/
        transform.parent.gameObject.SetActive(false);
    }
}
