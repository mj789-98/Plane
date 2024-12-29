using UnityEngine;

public class CollisionSetup : MonoBehaviour
{
    void Awake()  // Using Awake instead of Start to set this up as early as possible
    {
        // This one line completely disables collisions between Enemy (6) and Meteor (7)
        Physics.IgnoreLayerCollision(6, 7, true);
    }
}