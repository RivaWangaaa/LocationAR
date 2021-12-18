using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

public class PetFactory : Singleton<PetFactory>
{
    [SerializeField] private Pet[] availablePets;
    [SerializeField] private Player player;
    [SerializeField] private float waitTime = 180.0f;
    [SerializeField] private int startingPets = 5;
    [SerializeField] private float minRange = 5.0f;
    [SerializeField] private float maxRange = 50.0f;

    private List<Pet> livePets = new List<Pet>();
    private Pet selectedPet;

    public List<Pet> LivePets
    {
        get { return livePets; }
    }

    public Pet SelectedPet
    {
        get { return selectedPet; }
    }
    private void Awake()
    {
        Assert.IsNotNull(availablePets);
        Assert.IsNotNull(player);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startingPets; i++)
        {
            InstantiatePet();
        }

        StartCoroutine(GeneratePets());
    }

    public void PetWasSelected(Pet pet)
    {
        selectedPet = pet;
    }
    
    private IEnumerator GeneratePets()
    {
        while (true)
        {
            InstantiatePet();
            yield return new WaitForSeconds(waitTime);
        }
    }
    private void InstantiatePet()
    {
        int index = Random.Range(0, availablePets.Length);
        float x = player.transform.position.x + GenerateRange();
        float z = player.transform.position.z + GenerateRange();
        float y = player.transform.position.y + 6;
        livePets.Add(Instantiate(availablePets[index], new Vector3(x, y, z), Quaternion.identity));
    }

    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;
        return randomNum * (isPositive ? 1 : -1);
    }

}
