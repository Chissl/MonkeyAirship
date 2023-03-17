

namespace MonkeyAirship.Displays.Planes
{
    public class MoabRavagerPlaneBaseDisplay : ModDisplay
    {
        public override string BaseDisplay => "c72030d638703fd4789f3cf854b9e925";
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            foreach (var transform in node.gameObject.GetComponentsInChildren<Transform>())
            {
                transform.localScale *= .7f;
                
            }
            node.GetBone("SmokeTrails").transform.localScale = new Vector3(.5f, .6f, .6f);
            node.GetBone("SmokeTrails").transform.localPosition = new Vector3(-2.5f, 1, -15);


        }
    }
}
namespace MonkeyAirship.Displays.Planes
{
    public class MoabPlaneDisplay : ModDisplay
    {
        public override string BaseDisplay => "bafddc9e96223c849b29709ce057e33f";
        public override Il2CppAssets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name,0);

        }
    }
}
namespace MonkeyAirship.Displays
{
    public class ParagonPlaneDisplay : ModDisplay
    {
        public override string BaseDisplay => "a71703da4f9dd894e83e204d8cc74c50";
        public override Il2CppAssets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif
            foreach (var transform in node.gameObject.GetComponentsInChildren<Transform>())
            {
                transform.localScale *= .7f;

            }

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211, 0), 2);
            SetMeshTexture(node, Name, 2);
            SetMeshTexture(node, Name, 1);
            node.GetBone("FinRight").transform.localPosition = new Vector3(12f, 0, -8.5f);
            node.GetBone("Propeller").transform.localPosition = new Vector3(0, 0, -30.5f);

        }
    }
}