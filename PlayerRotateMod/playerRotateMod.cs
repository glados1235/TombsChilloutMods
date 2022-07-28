using MelonLoader;
using UnityEngine;

namespace MyProject
{


    public class playerRotateMod : MelonMod
    {


        public static bool rotateToggle;
        public static GameObject playerController;
  
        public override void OnApplicationStart()
        {

        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            buildIndex = 1;
            sceneName = "DontDestroyOnLoad";
            playerController = GameObject.Find("_PLAYERLOCAL");

        }

        public override void OnUpdate()
        {
            if (rotateToggle)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    playerController.transform.Rotate(1, 0, 0);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    playerController.transform.Rotate(-1, 0, 0);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    playerController.transform.Rotate(0, 0, 1);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    playerController.transform.Rotate(0, 0, -1);
                }
            }


            if (Input.GetKeyDown(KeyCode.O))
            {
                rotateToggle = !rotateToggle;
                playerController.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }



        }
    }
}