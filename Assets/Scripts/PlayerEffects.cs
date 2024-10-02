using UnityEngine;
using System.Collections;

public class PlayerEffects : MonoBehaviour
{
   public void AddSpeed(int speedGiven, float speedDuration)
    {
        PlayerMovement.instance.moveSpeed += speedGiven;
        StartCoroutine(RemoveSpeed(speedGiven, speedDuration));
    }

    private IEnumerator RemoveSpeed(int speedGiven, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        PlayerMovement.instance.moveSpeed -= speedGiven;
    }

    public void AddJump(int JumpGiven, float jumpDuration)
    {
        PlayerMovement.instance.jumpForce += JumpGiven;
        StartCoroutine(RemoveJump(JumpGiven, jumpDuration));
    }

    private IEnumerator RemoveJump(int JumpGiven, float jumpDuration)
    {
        yield return new WaitForSeconds(jumpDuration);
        PlayerMovement.instance.jumpForce -= JumpGiven;
    }
}
    
