using UnityEngine;

public class CloudMoveScript : MonoBehaviour
{
    public LogicScript logic;
    private float moveSpeed = 6f;
    private float deadZone = -30;
    private float denominator = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        float playerScore = logic.playerScore;
        moveSpeed = moveSpeed + playerScore / denominator;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
