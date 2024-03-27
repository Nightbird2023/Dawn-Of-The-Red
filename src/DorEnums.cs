namespace DawnOfTheRed;

public class DorEnums
{
    public static void Init()
    {
        RuntimeHelpers.RunClassConstructor(typeof(CreatureType).TypeHandle);
        RuntimeHelpers.RunClassConstructor(typeof(SandboxUnlock).TypeHandle);
    }
    
    public static void Unregister()
    {
        DorUtils.UnregisterEnums(typeof(CreatureType));
        DorUtils.UnregisterEnums(typeof(SandboxUnlock));
    }

    public static class CreatureType
    {
        public static CreatureTemplate.Type RueLizard = new(nameof(RueLizard), true);
    }

    public static class SandboxUnlock
    {
        public static MultiplayerUnlocks.SandboxUnlockID RueLizard = new(nameof(RueLizard), true);
    }
}