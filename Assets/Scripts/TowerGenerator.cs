using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector3 startPosition;
    [SerializeField]
    private GameObject[] poziomy;
    [SerializeField]
    private GameObject[] budowa;
    [Range(0, 27), SerializeField]
    private int towerSize;
    private int towerLevel;
    private GameObject[] tower;
    float baseSize = 5.25f;

    void Start()
    {
        Instantiate(poziomy[0], startPosition, Quaternion.identity);
        tower = new GameObject[9];
    }

    void Update()
    {

    }

    public void BuildTower()
    {
        towerSize++;
        towerLevel = towerSize / 3;
        if (towerSize%3 == 1)
        {
            tower[towerLevel] = Instantiate(budowa[0], startPosition + new Vector3(0, baseSize, 0)*(towerLevel + 1), Quaternion.identity);
        }
        else if (towerSize % 3 == 2)
        {
            if (tower[towerLevel] != null)
            {
                Destroy(tower[towerLevel]);
            }
            tower[towerLevel] = Instantiate(budowa[1], startPosition + new Vector3(0, baseSize, 0) * (towerLevel + 1), Quaternion.identity);
        }
        else if (towerSize % 3 == 0)
        {
            if (tower[towerLevel-1] != null)
            {
                Destroy(tower[towerLevel-1]);
            }
            tower[towerLevel] = Instantiate(poziomy[towerLevel], startPosition + new Vector3(0, baseSize, 0) * (towerLevel), Quaternion.identity);
        }
    }
}
