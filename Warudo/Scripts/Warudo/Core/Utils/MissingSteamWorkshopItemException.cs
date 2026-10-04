using System;

namespace Warudo.Core.Utils {
    public class MissingSteamWorkshopItemException : Exception {
        public ulong WorkshopId { get; private set; }
        public MissingSteamWorkshopItemException(ulong workshopId) : base($"Workshop item {workshopId} is not downloaded yet") {
            WorkshopId = workshopId;
        }
    }
}
