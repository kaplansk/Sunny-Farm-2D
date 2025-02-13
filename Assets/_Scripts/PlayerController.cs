using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    public InputActionReference moveInput, actionInput;
    public Animator anim;



    public enum ToolType
    {
        plough,
        wateringCan,
        seeds,
        baskets
    }

    public ToolType currentTool;
    void Start()
    {
       
    }

    
    void Update()
    {
      //  theRB.linearVelocity = new Vector2(moveSpeed,0f);
      theRB.linearVelocity = moveInput.action.ReadValue<Vector2>().normalized *moveSpeed;



        if (theRB.linearVelocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(theRB.linearVelocity.x>0) 
        {
            transform.localScale = Vector3.one;
        }


        anim.SetFloat("speed",theRB.linearVelocity.magnitude);

        if (actionInput.action.WasPressedThisFrame())
        {
            UseTool();         
        }

        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            currentTool += 1;
        }
        if ((int)currentTool >= 4)
        {
            currentTool = ToolType.plough;
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            currentTool = ToolType.plough;
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            currentTool = ToolType.wateringCan;
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            currentTool = ToolType.seeds;
        }
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            currentTool = ToolType.baskets;
        }



    }

    void UseTool()
    {
        GrowBlock block =null;

        block = FindFirstObjectByType<GrowBlock>();

        //block.PloughSoil();

        if (block != null)
        {
            switch (currentTool)
            {
                case ToolType.plough:
                    block.PloughSoil();
                    break;

                case ToolType.wateringCan:
                    break;

                case ToolType.seeds:
                    break;

                case ToolType.baskets:
                    break;

            }
        }
    }
}
