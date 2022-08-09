using MelonLoader;
using UnityEngine;

namespace MyProject
{


    public class playerRotateMod : MelonMod
    {


        public static bool rotateToggle;
        public static GameObject playerController;
        public static float rotSpeed;
        public static Quaternion SavedRot;


        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            buildIndex = 1;
            sceneName = "DontDestroyOnLoad";
            playerController = GameObject.Find("_PLAYERLOCAL");
            rotSpeed = 1f;

        }


        public override void OnUpdate()
        {
            if (playerController != null)
            {
                if (rotateToggle)
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        playerController.transform.Rotate(rotSpeed, 0, 0);
                    }
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        playerController.transform.Rotate(-rotSpeed, 0, 0);
                    }
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        playerController.transform.Rotate(0, 0, -rotSpeed);
                    }
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        playerController.transform.Rotate(0, 0, rotSpeed);
                    }
                }
                else
                {
                    SavedRot = playerController.transform.localRotation;
                }

                if (Input.GetKey(KeyCode.U) && rotSpeed <= 10000)
                {
                    rotSpeed += 0.02f;
                }
                if (Input.GetKey(KeyCode.J) && rotSpeed >= 0.8f)
                {
                    rotSpeed -= 0.02f;
                }
                if (Input.GetKeyDown(KeyCode.O))
                {
                    rotSpeed = 0.8f;
                    rotateToggle = !rotateToggle;
                    playerController.transform.localRotation = SavedRot;
                }
            }
        }
    }
}