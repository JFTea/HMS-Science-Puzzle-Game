using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    /// <summary>
    /// The current state of the object
    /// </summary>
    public PickupType state;

    /// <summary>
    /// Private reference to the player object
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Private reference to the player camera
    /// </summary>
    [SerializeField]
    private GameObject playerCamera;

    /// <summary>
    /// Private reference to the original time of the object
    /// </summary>
    [SerializeField]
    private GameObject originalTime;

    /// <summary>
    /// Private reference to the root gameobject in the scene
    /// </summary>
    [SerializeField]
    private GameObject root;

    /// <summary>
    /// Private boolean saying whether the object has collided with a wall or other object
    /// </summary>
    private bool collided = false;

    /// <summary>
    /// Private reference to the objects rigidbody
    /// </summary>
    private Rigidbody rigid;

    /// <summary>
    /// Returns true if the player is near the object
    /// </summary>
    private bool nearObject = false;

    /// <summary>
    /// The available states to the object
    /// </summary>
    public enum PickupType
    {
        onGround,
        pickUP,
        Solved
    }

    void Start()
    {
        // Sets the default state
        state = PickupType.onGround;

        rigid = GetComponent<Rigidbody>();
    }

    // Fixed update is used due to the physics engine being used
    private void FixedUpdate()
    {
        if (state == PickupType.pickUP)
        {
            RemoveForces();
            gameObject.transform.SetParent(root.transform, true);

            // If the gameobject is not collided with a wall then it will move with the player view
            if (!collided)
            {
                // Got the idea for this position formula from this Unity forum post https://answers.unity.com/questions/46583/how-to-get-the-look-or-forward-vector-of-the-camer.html
                // I forgot that the camera also points in the same forward direction of the GameObject it is attached to
                rigid.AddForce((playerCamera.transform.position + playerCamera.transform.forward * 2 - transform.position) * 10, ForceMode.Impulse);
            }


        }
        else if (state == PickupType.onGround)
        {
            // Removes any forces made from player movement
            RemoveForces();
            gameObject.transform.SetParent(originalTime.transform, true);
            //Allows the gameobject to be affected by gravity
            rigid.useGravity = true;
        }
        else if (state == PickupType.Solved)
        {
            // Sets the parent of the object to the time of the solved puzzle
            gameObject.transform.SetParent(originalTime.transform, true);

            //Removes the rigidbody as the player was able to make the object fly off after a puzzle was solved
            Destroy(gameObject.GetComponent<Rigidbody>());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nearObject)
        {
            PickUp();
        }

        // Allows the user to drop the currently picked up object
        if (Input.GetKeyDown(KeyCode.R) && state == PickupType.pickUP)
        {
            state = PickupType.onGround;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearObject = true;
        }
    }
    /// <summary>
    /// Allows the player to pick up the game object
    /// </summary>
    private void PickUp()
    {
        // Allows the player to pick up the object
        if (state == PickupType.onGround)
        {
            state = PickupType.pickUP;

            // Removes all active forces on the gameobject to it does not fly off due to momentum when picked up
            RemoveForces();
            rigid.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearObject = false;
        }
    }


    /// <summary>
    /// Removes all active forces on a gameobject
    /// </summary>
    private void RemoveForces()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
}

