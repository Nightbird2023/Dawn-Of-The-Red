namespace DawnOfTheRed;

public class RueLizardCritob : Critob
{
    public RueLizardCritob() : base(DorEnums.CreatureType.RueLizard)
    {
        Icon = new SimpleIcon("Kill_Standard_Lizard", Color.white);
        LoadedPerformanceCost = 100f;
        SandboxPerformanceCost = new SandboxPerformanceCost(1f, 1f);
        ShelterDanger = ShelterDanger.Hostile;
        CreatureName = nameof(DorEnums.CreatureType.RueLizard);
        RegisterUnlock(KillScore.Configurable(10), DorEnums.SandboxUnlock.RueLizard);
    }

    public override ArtificialIntelligence CreateRealizedAI(AbstractCreature acrit) => new LizardAI(acrit, acrit.world);

    public override Creature CreateRealizedCreature(AbstractCreature acrit) => new RueLizard(acrit, acrit.world);

    public override CreatureTemplate CreateTemplate() => LizardBreeds.BreedTemplate(Type, StaticWorld.GetCreatureTemplate(CreatureTemplate.Type.LizardTemplate), null, null, null);

    public override string DevtoolsMapName(AbstractCreature acrit) => "RueLizard";

    public override Color DevtoolsMapColor(AbstractCreature acrit) => Color.red;

    public override IEnumerable<RoomAttractivenessPanel.Category> DevtoolsRoomAttraction() => new[] { RoomAttractivenessPanel.Category.Lizards };

    public override IEnumerable<string> WorldFileAliases() => new[] { nameof(DorEnums.CreatureType.RueLizard) };

    public override CreatureType ArenaFallback() => CreatureType.RedLizard;

    public override int ExpeditionScore() => 10;

    public override CreatureState CreateState(AbstractCreature acrit) => new LizardState(acrit);

    public override void EstablishRelationships()
    {
        var self = new Relationships(Type);

        self.Eats(CreatureType.Slugcat, 1f);
        self.Eats(CreatureType.Fly, 0.25f);
        self.Eats(CreatureType.Snail, 0.7f);
        self.Eats(CreatureType.LanternMouse, 0.7f);
        self.Eats(CreatureType.CicadaA, 0.8f);
        self.Eats(CreatureType.CicadaB, 0.8f);
        self.Eats(CreatureType.Spider, 1f);
        self.Eats(CreatureType.JetFish, 0.15f);
        self.Eats(CreatureType.TubeWorm, 1f);
        self.Eats(CreatureType.Centipede, 1f);
        self.Eats(CreatureType.Centiwing, 0.7f);
        self.Eats(CreatureType.SmallCentipede, 1f);
        self.Eats(CreatureType.VultureGrub, 0.4f);
        self.Eats(CreatureType.EggBug, 0.45f);
        self.Eats(CreatureType.BigSpider, 0.75f);
        self.Eats(CreatureType.SpitterSpider, 0.75f);
        self.Eats(CreatureType.SmallNeedleWorm, 0.30f);
        self.Eats(CreatureType.BigNeedleWorm, 0.25f);
        self.Eats(CreatureType.DropBug, 0.25f);
        self.Eats(CreatureType.Hazer, 0.35f);
        self.Eats(MoreSlugcatsEnums.CreatureTemplateType.MotherSpider, 0.5f);
        self.Eats(MoreSlugcatsEnums.CreatureTemplateType.HunterDaddy, 1f);
        self.Eats(MoreSlugcatsEnums.CreatureTemplateType.FireBug, 0.25f);
        self.Eats(MoreSlugcatsEnums.CreatureTemplateType.Yeek, 0.75f);
        self.Eats(MoreSlugcatsEnums.CreatureTemplateType.SlugNPC, 0.8f);
        self.Eats(MoreSlugcatsEnums.CreatureTemplateType.ZoopLizard, 1f);

        self.EatenBy(CreatureType.Leech, 1f);
        self.EatenBy(CreatureType.Vulture, 0.5f);
        self.EatenBy(CreatureType.SeaLeech, 1f);
        self.EatenBy(CreatureType.BigEel, 1f);
        self.EatenBy(CreatureType.DaddyLongLegs, 1f);
        self.EatenBy(CreatureType.BrotherLongLegs, 0.5f);
        self.EatenBy(CreatureType.TentaclePlant, 1f);
        self.EatenBy(CreatureType.PoleMimic, 0f);
        self.EatenBy(CreatureType.MirosBird, 1f);
        self.EatenBy(CreatureType.Centipede, 1f);
        self.EatenBy(CreatureType.RedCentipede, 1f);
        self.EatenBy(CreatureType.Centiwing, 1f);
        self.EatenBy(CreatureType.SmallCentipede, 1f);
        self.EatenBy(CreatureType.VultureGrub, 1f);
        self.EatenBy(CreatureType.SpitterSpider, 0.5f);
        self.EatenBy(CreatureType.DropBug, 1f);
        self.EatenBy(CreatureType.KingVulture, 0.45f);
        self.EatenBy(MoreSlugcatsEnums.CreatureTemplateType.MirosVulture, 0.4f);
        self.EatenBy(MoreSlugcatsEnums.CreatureTemplateType.SpitLizard, 1f);
        self.EatenBy(MoreSlugcatsEnums.CreatureTemplateType.EelLizard, 0.65f);
        self.EatenBy(MoreSlugcatsEnums.CreatureTemplateType.MotherSpider, 0.5f);
        self.EatenBy(MoreSlugcatsEnums.CreatureTemplateType.TerrorLongLegs, 1f);
        self.EatenBy(MoreSlugcatsEnums.CreatureTemplateType.AquaCenti, 1f);
        self.EatenBy(MoreSlugcatsEnums.CreatureTemplateType.FireBug, 0.5f);
        self.EatenBy(MoreSlugcatsEnums.CreatureTemplateType.StowawayBug, 1f);
        self.EatenBy(MoreSlugcatsEnums.CreatureTemplateType.Inspector, 0.8f);
        self.EatenBy(MoreSlugcatsEnums.CreatureTemplateType.BigJelly, 1f);
        self.EatenBy(MoreSlugcatsEnums.CreatureTemplateType.JungleLeech, 1f);

        self.IgnoredBy(CreatureType.GarbageWorm);
        self.IgnoredBy(CreatureType.Deer);
        self.IgnoredBy(CreatureType.TubeWorm);
        self.IgnoredBy(CreatureType.Overseer);
        self.IgnoredBy(CreatureType.Hazer);
        self.IgnoredBy(MoreSlugcatsEnums.CreatureTemplateType.HunterDaddy);

        self.FearedBy(CreatureType.Slugcat, 1f);
        self.FearedBy(CreatureType.LanternMouse, 0.85f);
        self.FearedBy(CreatureType.CicadaA, 0.7f);
        self.FearedBy(CreatureType.CicadaB, 0.7f);
        self.FearedBy(CreatureType.Spider, 1f);
        self.FearedBy(CreatureType.JetFish, 0.2f);
        self.FearedBy(CreatureType.Scavenger, 1f);
        self.FearedBy(CreatureType.EggBug, 0.25f);
        self.FearedBy(CreatureType.BigSpider, 1f);
        self.FearedBy(MoreSlugcatsEnums.CreatureTemplateType.Yeek, 0.85f);
        self.FearedBy(MoreSlugcatsEnums.CreatureTemplateType.SlugNPC, 0.8f);

        self.AttackedBy(CreatureType.YellowLizard, 0.25f);
        self.AttackedBy(CreatureType.RedLizard, 0.8f);
        self.AttackedBy(MoreSlugcatsEnums.CreatureTemplateType.ScavengerElite, 0.75f);
        self.AttackedBy(MoreSlugcatsEnums.CreatureTemplateType.ScavengerKing, 1f);

        self.MakesUncomfortable(CreatureType.Fly, 0f);
        self.MakesUncomfortable(CreatureType.Snail, 0.7f);
        self.MakesUncomfortable(CreatureType.TempleGuard, 1f);
        self.MakesUncomfortable(CreatureType.SmallNeedleWorm, 1f);
        self.MakesUncomfortable(CreatureType.BigNeedleWorm, 1f);

        self.Ignores(CreatureType.Leech);
        self.Ignores(CreatureType.SeaLeech);
        self.Ignores(CreatureType.GarbageWorm);
        self.Ignores(CreatureType.Deer);
        self.Ignores(CreatureType.TempleGuard);
        self.Ignores(CreatureType.Overseer);
        self.Ignores(MoreSlugcatsEnums.CreatureTemplateType.JungleLeech);

        self.Fears(CreatureType.BigEel, 1f);
        self.Fears(CreatureType.DaddyLongLegs, 1f);
        self.Fears(CreatureType.BrotherLongLegs, 1f);
        self.Fears(CreatureType.TentaclePlant, 0.2f);
        self.Fears(CreatureType.PoleMimic, 1f);
        self.Fears(CreatureType.MirosBird, 1f);
        self.Fears(CreatureType.RedCentipede, 1f);
        self.Fears(MoreSlugcatsEnums.CreatureTemplateType.MirosVulture, 1f);
        self.Fears(MoreSlugcatsEnums.CreatureTemplateType.TerrorLongLegs, 1f);
        self.Fears(MoreSlugcatsEnums.CreatureTemplateType.AquaCenti, 1f);
        self.Fears(MoreSlugcatsEnums.CreatureTemplateType.StowawayBug, 1f);
        self.Fears(MoreSlugcatsEnums.CreatureTemplateType.BigJelly, 0.2f);
        self.Fears(MoreSlugcatsEnums.CreatureTemplateType.TrainLizard, 0.8f);

        self.Attacks(CreatureType.Slugcat, 1f);
        self.Attacks(CreatureType.LizardTemplate, 0.1f);
        self.Attacks(CreatureType.PinkLizard, 0.1f);
        self.Attacks(CreatureType.GreenLizard, 1f);
        self.Attacks(CreatureType.BlueLizard, 1f);
        self.Attacks(CreatureType.BlackLizard, 0.4f);
        self.Attacks(CreatureType.YellowLizard, 1f);
        self.Attacks(CreatureType.WhiteLizard, 0.75f);
        self.Attacks(CreatureType.WhiteLizard, 0.25f);
        self.Attacks(CreatureType.RedLizard, 1f);
        self.Attacks(CreatureType.BlackLizard, 0.8f);
        self.Attacks(CreatureType.BlackLizard, 0.2f);
        self.Attacks(CreatureType.Salamander, 1f);
        self.Attacks(CreatureType.CyanLizard, 1f);
        self.Attacks(CreatureType.Vulture, 0.8f);
        self.Attacks(CreatureType.Scavenger, 1f);
        self.Attacks(MoreSlugcatsEnums.CreatureTemplateType.SpitLizard, 1f);
        self.Attacks(MoreSlugcatsEnums.CreatureTemplateType.EelLizard, 1f);
        self.Attacks(CreatureType.KingVulture, 1f);
        self.Attacks(MoreSlugcatsEnums.CreatureTemplateType.ScavengerElite, 0.8f);
        self.Attacks(MoreSlugcatsEnums.CreatureTemplateType.Inspector, 0.8f);
        self.Attacks(MoreSlugcatsEnums.CreatureTemplateType.ZoopLizard, 0.5f);
        self.Attacks(MoreSlugcatsEnums.CreatureTemplateType.ScavengerKing, 1f);
        self.Attacks(MoreSlugcatsEnums.CreatureTemplateType.TrainLizard, 0.3f);

        //Add the other Lizards Here
        self.Attacks(DorEnums.CreatureType.RueLizard, 9999f);
        self.AttackedBy(DorEnums.CreatureType.RueLizard, 9999f);
    }
}