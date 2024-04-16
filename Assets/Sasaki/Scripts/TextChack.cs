using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChack : MonoBehaviour
{
    [SerializeField, Header("storyText")]
    private GameObject story;

    [SerializeField, Header("allText")]
    private GameObject allText;

    [SerializeField, Header("SceneChanger")]
    private GameObject SceneChanger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            story.gameObject.SetActive(false);
            allText.gameObject.SetActive(true);
            SceneChanger.gameObject.SetActive(true);
        }
    }
}
