using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> droppables;
    [SerializeField] public Vector2 range;
    [SerializeField] public float yPos;
    [SerializeField] public float timeBetweenSpawns;
    [SerializeField] public Transform dropPos;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenSpawns)
        {
            Spawn();
            timer = 0;
        }
    }

    public void Spawn()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            GameObject spawnable = Instantiate(droppables[Random.Range(0, droppables.Capacity)]);
            spawnable.transform.position = dropPos.transform.position;
        }
    }
}
