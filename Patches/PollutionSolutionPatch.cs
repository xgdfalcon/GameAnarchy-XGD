using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICities;
using ColossalFramework;

namespace GameAnarchy.Patches {
    public class PollutionSolutionPatch{

        //It seems that if you make this too negative(i.e.Int32), it's less effective
        // (there's probably some underflow somewhere in that case)
        // Let's just use Int16.MinValue as a relatively safe number
        private const int NOISE_AMOUNT = Int16.MinValue;

        // This didn't have the same problem as the noise, but it's safer to stay away from the max Int32
        private const int POLLUTION_AMOUNT = Int16.MaxValue;

        // How frequently to remove the pollution, in frames
        // The game will process a different number of frames per wall time depending on the game speed and the ability of the computer
        // At 1x speed, there are 60 frames per second, so 60 here should be about once per "in game" second regardless of speed
        private const uint FRAME_INDEX_THRESHOLD = 60;

        public class PollutionLogic : ThreadingExtensionBase {
            private uint previousUpdatedFrameIndex = 0;
            public override void OnCreated(IThreading threading) {
                base.OnCreated(threading);
            }
            public override void OnReleased() {
                base.OnReleased();
            }
            public override void OnAfterSimulationFrame() {
                // Probably not in a normal game type if the district manager doesn't actually exist
                if (Singleton<DistrictManager>.exists &&
                    // No need to do anything if we're paused
                    !SimulationManager.instance.SimulationPaused &&
                    // Don't do things faster than once every FRAME_INDEX_THRESHOLD
                    SimulationManager.instance.m_currentFrameIndex - previousUpdatedFrameIndex > FRAME_INDEX_THRESHOLD) {
                    if (GAMod.RemoveNoisePollution) {
                        ImmaterialResourceManager.instance.AddResource(ImmaterialResourceManager.Resource.NoisePollution, NOISE_AMOUNT);
                    }
                    if (GAMod.RemoveGroundPollution) {
                        Singleton<NaturalResourceManager>.instance.AddPollutionDisposeRate(POLLUTION_AMOUNT);
                    }
                    if (GAMod.RemoveWaterPollution) {
                        Singleton<TerrainManager>.instance.WaterSimulation.AddPollutionDisposeRate(POLLUTION_AMOUNT);
                    }
                    previousUpdatedFrameIndex = SimulationManager.instance.m_currentFrameIndex;
                }
                base.OnAfterSimulationTick();
            }
        }
    }
}
