using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : PocketPetsSceneManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void playerTapped(GameObject player)
    {
        throw new System.NotImplementedException();
    }

    public override void petTapped(GameObject pet)
    {
        SceneManager.LoadScene(PocketPetsConstants.SCENE_CAPTURE, LoadSceneMode.Additive);
    }
}
