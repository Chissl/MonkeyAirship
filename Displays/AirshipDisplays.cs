using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using System.Linq;
using UnityEngine;


namespace MonkeyAirship.Displays
{
    public class MonkeyAirshipBaseDisplay : ModDisplay
    {
        public override string BaseDisplay => "eff76d2b677b4b6499ee03b459d9b3fa";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);

        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display100 : ModDisplay
    {
        public override string BaseDisplay => "eff76d2b677b4b6499ee03b459d9b3fa";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            
        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display200 : ModDisplay
    {
        public override string BaseDisplay => "eff76d2b677b4b6499ee03b459d9b3fa";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);

        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display001 : ModDisplay
    {
        public override string BaseDisplay => "eff76d2b677b4b6499ee03b459d9b3fa";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);

        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display002 : ModDisplay
    {
        public override string BaseDisplay => "eff76d2b677b4b6499ee03b459d9b3fa";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);

        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display020 : ModDisplay
    {
        public override string BaseDisplay => "eff76d2b677b4b6499ee03b459d9b3fa";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            SetMeshTexture(node, Name, 1);

        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display010 : ModDisplay
    {
        public override string BaseDisplay => "eff76d2b677b4b6499ee03b459d9b3fa";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            SetMeshTexture(node, Name, 1);

        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display300 : ModDisplay
    {
        public override string BaseDisplay => "6ae6151188a6cdf488d13bcb9a972c47";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            foreach (var transform in node.gameObject.GetComponentsInChildren<Transform>())
            {
                transform.localScale *= .94f;

            }
            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 3);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211, 0), 2);
            SetMeshTexture(node, Name, 3);
            SetMeshTexture(node, Name, 2);
            SetMeshTexture(node, Name, 1);
            node.GetBone("RightTurbine").transform.localPosition = new Vector3(22f, 0, -22f);


        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display400 : ModDisplay
    {
        public override string BaseDisplay => "6ae6151188a6cdf488d13bcb9a972c47";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 3);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211, 0), 2);
            SetMeshTexture(node, Name, 3);
            SetMeshTexture(node, Name, 2);
            SetMeshTexture(node, Name, 1);
            node.GetBone("RightTurbine").transform.localPosition = new Vector3(22f, 0, -22f);


        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display500 : ModDisplay
    {
        public override string BaseDisplay => "f47778bfd841f614ca165ce4c190a661";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 3);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211, 0), 2);
            SetMeshTexture(node, Name, 3);
            SetMeshTexture(node, Name, 2);
            SetMeshTexture(node, Name, 1);


        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display030 : ModDisplay
    {
        public override string BaseDisplay => "a71703da4f9dd894e83e204d8cc74c50";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211, 0), 2);
            SetMeshTexture(node, Name, 2);
            SetMeshTexture(node, Name, 1);


        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display040 : ModDisplay
    {
        public override string BaseDisplay => "a71703da4f9dd894e83e204d8cc74c50";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211, 0), 2);
            SetMeshTexture(node, Name, 2);
            SetMeshTexture(node, Name, 1);


        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display050 : ModDisplay
    {
        public override string BaseDisplay => "a71703da4f9dd894e83e204d8cc74c50";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif
            foreach (var transform in node.gameObject.GetComponentsInChildren<Transform>())
            {
                transform.localScale *= 1.25f;

            }

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211, 0), 2);
            SetMeshTexture(node, Name, 2);
            SetMeshTexture(node, Name, 1);
            node.GetBone("FinRight").transform.localPosition = new Vector3(24f, 0, -17.5f);
            node.GetBone("Propeller").transform.localPosition = new Vector3(0, 0, -52f);

        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display003 : ModDisplay
    {
        public override string BaseDisplay => "eff76d2b677b4b6499ee03b459d9b3fa";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));

        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display004 : ModDisplay
    {
        public override string BaseDisplay => "6ae6151188a6cdf488d13bcb9a972c47";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211, 0), 2);
            SetMeshTexture(node, Name, 2);
            SetMeshTexture(node, Name, 1);

        }
    }
}
namespace MonkeyAirship.Displays
{
    public class Display005 : ModDisplay
    {
        public override string BaseDisplay => "f47778bfd841f614ca165ce4c190a661";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif

            SetMeshTexture(node, Name);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211));
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211, 0), 2);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211, 0), 3);
            SetMeshTexture(node, Name, 2);
            SetMeshTexture(node, Name, 1);
            SetMeshTexture(node, Name, 3);

        }
    }
}
namespace MonkeyAirship.Displays
{
    public class ParagonDisplay : ModDisplay
    {
        public override string BaseDisplay => "8fd8a703a31154a49b25ba34235ab76c";
        public override Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 100, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif


            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 0);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211), 1);
            SetMeshOutlineColor(node, new UnityEngine.Color(211, 211, 211, 0), 2);
            SetMeshTexture(node, Name, 2);
            SetMeshTexture(node, Name, 1);
            SetMeshTexture(node, Name, 0);

        }
    }
}
namespace MonkeyAirship.Displays
{
    public class BaseTowerModel : ModTowerDisplay<MonkeyAirship>
    {
        public override string BaseDisplay => "f0c7075edbd50f748a8c903c4065b9fc";
        public override bool UseForTower(int[] tiers)
        {
            return tiers.Sum() <= 5;
        }
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
# if DEBUG
            node.SaveMeshTexture();
            node.PrintInfo();

#endif
            /*            foreach (var transform in node.gameObject.GetComponentsInChildren<Transform>())
                        {
                            transform.localScale *= 1.25f;

                        }*/
            SetMeshTexture(node, Name);


        }
    }
}
