namespace DawnOfTheRed;

public class RueLizardHooks
{
    public static void Apply()
    {
        On.Lizard.ctor += Lizard_ctor;
        On.LizardBreeds.BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate += LizardBreeds_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate;

        Debug.LogWarning("Rue Lizard Loading DawnOFTheRed");
    }

    private static CreatureTemplate LizardBreeds_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate(On.LizardBreeds.orig_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate orig, CreatureType type, CreatureTemplate lizardAncestor, CreatureTemplate pinkTemplate, CreatureTemplate blueTemplate, CreatureTemplate greenTemplate)
    {
        var result = orig(type, lizardAncestor, pinkTemplate, blueTemplate, greenTemplate);

        if (type == DorEnums.CreatureType.RueLizard)
        {
            var lizardBreedParams = new LizardBreedParams(type)
            {
                terrainSpeeds = new LizardBreedParams.SpeedMultiplier[Enum.GetNames(typeof(AItile.Accessibility)).Length]
            };
            for (var i = 0; i < lizardBreedParams.terrainSpeeds.Length; i++)
            {
                lizardBreedParams.terrainSpeeds[i] = new LizardBreedParams.SpeedMultiplier(1.35f, 1f, 1f, 1f);
            }

            lizardBreedParams.bodyRadFac = 1f;
            lizardBreedParams.pullDownFac = 1f;
            var tileTypeResistances = new List<TileTypeResistance>();
            var tileConnectionResistances = new List<TileConnectionResistance>();

            lizardBreedParams.terrainSpeeds[1] = new LizardBreedParams.SpeedMultiplier(1.35f, 1.3f, 1.3f, 1.3f);
            tileTypeResistances.Add(new TileTypeResistance(AItile.Accessibility.Floor, 1f, 0));

            lizardBreedParams.terrainSpeeds[2] = new LizardBreedParams.SpeedMultiplier(1f, 1f, 1f, 1f);
            tileTypeResistances.Add(new TileTypeResistance(AItile.Accessibility.Corridor, 1f, 0));

            lizardBreedParams.terrainSpeeds[3] = new LizardBreedParams.SpeedMultiplier(1.2f, 1.35f, 1.3f, 1.3f);
            tileTypeResistances.Add(new TileTypeResistance(AItile.Accessibility.Climb, 0.5f, 0));

            lizardBreedParams.terrainSpeeds[4] = new LizardBreedParams.SpeedMultiplier(1.25f, 1.2f, 1.15f, 1.25f);
            tileTypeResistances.Add(new TileTypeResistance(AItile.Accessibility.Wall, 0.5f, 0));

            lizardBreedParams.terrainSpeeds[5] = new LizardBreedParams.SpeedMultiplier(1.05f, 1f, 1f, 1f);
            tileTypeResistances.Add(new TileTypeResistance(AItile.Accessibility.Ceiling, 1f, 0));

            lizardBreedParams.terrainSpeeds[6] = new LizardBreedParams.SpeedMultiplier(1f, 1f, 1f, 1f);

            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.DropToFloor, 1f, 0));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.DropToClimb, 1f, 0));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.ShortCut, 1f, 0));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.ReachOverGap, 1f, 0));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.ReachUp, 1f, 0));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.ReachDown, 1f, 0));
            tileConnectionResistances.Add(new TileConnectionResistance(MovementConnection.MovementType.CeilingSlope, 1f, 0));

            lizardBreedParams.biteDelay = 1;
            lizardBreedParams.biteInFront = 22f;
            lizardBreedParams.biteHomingSpeed = 1.85f;
            lizardBreedParams.biteChance = 0.9f;
            lizardBreedParams.attemptBiteRadius = 94f;
            lizardBreedParams.getFreeBiteChance = 0.55f;
            lizardBreedParams.biteDamage = 1.45f;
            lizardBreedParams.biteDamageChance = 0.8f;
            lizardBreedParams.toughness = 2.45f;
            lizardBreedParams.stunToughness = 2.40f;

            lizardBreedParams.aggressionCurveExponent = 10f;
            lizardBreedParams.idleCounterSubtractWhenCloseToIdlePos = 0;

            lizardBreedParams.regainFootingCounter = 4;
            lizardBreedParams.floorLeverage = 1f;
            lizardBreedParams.maxMusclePower = 2.8f;
            lizardBreedParams.wiggleDelay = 15;
            lizardBreedParams.bodyStiffnes = 0.05f;
            lizardBreedParams.swimSpeed = 0.35f;
            lizardBreedParams.headShieldAngle = 100f;
            lizardBreedParams.canExitLounge = true;
            lizardBreedParams.canExitLoungeWarmUp = true;
            lizardBreedParams.findLoungeDirection = 1f;
            lizardBreedParams.loungeDistance = 80f;
            lizardBreedParams.preLoungeCrouch = 35;
            lizardBreedParams.preLoungeCrouchMovement = -0.3f;
            lizardBreedParams.loungeSpeed = 2.5f;
            lizardBreedParams.loungeMaximumFrames = 20;
            lizardBreedParams.loungePropulsionFrames = 8;
            lizardBreedParams.loungeJumpyness = 0.9f;
            lizardBreedParams.loungeDelay = 310;
            lizardBreedParams.riskOfDoubleLoungeDelay = 0.8f;
            lizardBreedParams.postLoungeStun = 20;
            lizardBreedParams.loungeTendensy = 0.2f;
            lizardBreedParams.perfectVisionAngle = 0.89f;
            lizardBreedParams.periferalVisionAngle = 0.08f;
            lizardBreedParams.biteDominance = 0.6f;
            lizardBreedParams.limbThickness = 1.05f;
            lizardBreedParams.stepLength = 0.4f;
            lizardBreedParams.liftFeet = 0f;
            lizardBreedParams.feetDown = 0f;
            lizardBreedParams.noGripSpeed = 0.2f;
            lizardBreedParams.limbSpeed = 6.5f;
            lizardBreedParams.limbGripDelay = 1;
            lizardBreedParams.smoothenLegMovement = true;
            lizardBreedParams.legPairDisplacement = 0f;
            lizardBreedParams.walkBob = 0.4f;
            lizardBreedParams.tailStiffness = 400f;
            lizardBreedParams.tailStiffnessDecline = 0.1f;
            lizardBreedParams.tailColorationStart = 0.1f;
            lizardBreedParams.tailColorationExponent = 1.2f;
            lizardBreedParams.neckStiffness = 0f;
            lizardBreedParams.jawOpenAngle = 109.1f;
            lizardBreedParams.jawOpenLowerJawFac = 0.55f;
            lizardBreedParams.jawOpenMoveJawsApart = 20f;
            lizardBreedParams.headGraphics = new int[5];
            lizardBreedParams.framesBetweenLookFocusChange = 20;
            lizardBreedParams.tongue = true;
            lizardBreedParams.tongueAttackRange = 140f;
            lizardBreedParams.tongueWarmUp = 10;
            lizardBreedParams.tongueSegments = 5;
            lizardBreedParams.tongueChance = 0.25f;
            lizardBreedParams.tamingDifficulty = 7.3f;
            lizardBreedParams.tailSegments = Random.Range(7, 9);
            lizardBreedParams.tailLengthFactor = 1.1f;
            lizardBreedParams.danger = 2f;
            lizardBreedParams.standardColor = Color.red;
            lizardBreedParams.headSize = 1f;
            lizardBreedParams.bodySizeFac = 1.1f;
            lizardBreedParams.limbSize = 0.95f;
            lizardBreedParams.bodyLengthFac = 1.05f;
            lizardBreedParams.bodyMass = 1.95f;
            lizardBreedParams.limbQuickness = 0.7f;
            lizardBreedParams.wiggleSpeed = 1f;
            lizardBreedParams.baseSpeed = 4.05f;

            result = new CreatureTemplate(type, lizardAncestor, tileTypeResistances, tileConnectionResistances, new CreatureTemplate.Relationship(CreatureTemplate.Relationship.Type.Attacks, 0.5f))
            {
                name = "RueLizard",
                waterPathingResistance = 5f,
                visualRadius = 950f,
                waterVision = 0.4f,
                throughSurfaceVision = 0.85f,
                breedParameters = lizardBreedParams,
                baseDamageResistance = lizardBreedParams.toughness * 2f,
                baseStunResistance = lizardBreedParams.toughness

            };
            result.damageRestistances[(int)Creature.DamageType.Bite, 0] = 2.5f;
            result.damageRestistances[(int)Creature.DamageType.Bite, 1] = 3f;
            result.meatPoints = 8;
            result.doPreBakedPathing = false;
            result.preBakedPathingAncestor = blueTemplate;
            result.virtualCreature = false;
            result.pickupAction = "Bite";
            result.jumpAction = "Call";
            result.throwAction = "Launch";
            result.wormGrassImmune = false;
        }

        return result;
    }

    private static void Lizard_ctor(On.Lizard.orig_ctor orig, Lizard self, AbstractCreature abstractCreature, World world)
    {
        orig(self, abstractCreature, world);
        if (self.Template.type == DorEnums.CreatureType.RueLizard)
        {
            self.effectColor = Custom.HSL2RGB(Custom.WrappedRandomVariation(0.0025f, 0.02f, 0.6f), 1f, Custom.ClampedRandomVariation(0.5f, 0.15f, 0.1f));
        }
    }
}