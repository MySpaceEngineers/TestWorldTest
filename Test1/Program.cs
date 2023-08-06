using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using VRage;
using VRage.Audio;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
        IMyTextSurface panel;
        MyIni ini = new MyIni();
        string iniText;

        public Program()
        {
            if (Me.SurfaceCount > 0)
            {
                panel = Me.GetSurface(0);
                panel.ContentType = ContentType.TEXT_AND_IMAGE;
                panel.ClearImagesFromSelection();
                Clear();
                Append("START");
            }

            MyIniParseResult result;
            if (!ini.TryParse(Me.CustomData, out result))
                throw new Exception(result.ToString());

            iniText = ini.Get("test", "text").ToString();
            Runtime.UpdateFrequency = UpdateFrequency.Once;
        }

        public void Save()
        {
        }

        public void Main(string argument, UpdateType updateSource)
        {
            // for external debugging
            if (argument.Equals("BREAK"))
            {
                try { throw new InvalidOperationException("break"); } catch (Exception) { }
                return;
            }

            Append(iniText);
        }

        private void Clear()
        {
            panel?.WriteText("", false);
        }

        private void Append(string text)
        {
            panel?.WriteText($"{text}\n", true);
        }
    }
}
