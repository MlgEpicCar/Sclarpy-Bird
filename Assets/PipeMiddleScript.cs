using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{

    public LogicScript logic;
    public BirdScript birdLogic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdLogic = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>(); // birdLogic is similar to an instance of BirdScript.cs, it is the same code but accesable via PipeMiddleScript.cs and typically you could link it by dragging and dropping inside of Unity itself, but since the pipes don't spawn frame 0 they don't get this luxury and have to access the birdLogic at the moment they are created. >_< <3 :3 UwU
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && birdLogic.alive) // Layer 3 is the bird layer
        {
            logic.addScore(1);
        }
    }
}
