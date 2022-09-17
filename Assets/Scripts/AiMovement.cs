using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    Animator animator;
    private string currentState;

    const string Idle = "Idle";
    const string MovingLeft = "WalkLeft";
    const string MovingRight = "WalkRight";
    const string MovingUp = "WalkUp";
    const string MovingDown = "WalkDown";


    Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        previousPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        //Debug.Log(transform.position - previousPosition);
        if (transform.position != previousPosition)
        {
            float deltaX = transform.position.x - previousPosition.x;
            float deltaY = transform.position.y - previousPosition.y;
            if (Mathf.Abs(deltaX) < Mathf.Abs(deltaY)) // horizontal movement < vertical movement 
            {
                if (previousPosition.y < transform.position.y)
                {
                    ChangeAnimationState(MovingUp);
                }
                else if (previousPosition.y > transform.position.y)
                {
                    ChangeAnimationState(MovingDown);
                }
            }
            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY)) // horizontal movement > vertical movement 
            {

                if (previousPosition.x < transform.position.x)
                {
                    ChangeAnimationState(MovingRight);
                }
                else if (previousPosition.x > transform.position.x)
                {
                    ChangeAnimationState(MovingLeft);
                }
            }

            previousPosition = transform.position;
        }
        else
        {
            ChangeAnimationState(Idle);
        }
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);
    }
}