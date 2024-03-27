using LizardCosmetics;
using static MonoMod.InlineRT.MonoModRule;

namespace DawnOfTheRed;

public class RueLizardHooks
{
    public static void Apply()
    {
        On.Lizard.ctor += Lizard_ctor;
        On.LizardBreeds.BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate += LizardBreeds_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate;
        On.Lizard.Update += Lizard_Update;
        On.LizardTongue.ctor += LizardTongue_ctor;
        On.LizardGraphics.ctor += LizardGraphics_ctor;

        Debug.LogWarning("Rue Lizard Loading DawnOFTheRed");
    }

    private static void LizardGraphics_ctor(On.LizardGraphics.orig_ctor orig, LizardGraphics self, PhysicalObject ow)
    {
        orig(self, ow);

        if (self.lizard.Template.type == DorEnums.CreatureType.RueLizard)
        {
            var state = Random.state;
            Random.InitState(self.lizard.abstractCreature.ID.RandomSeed);
            var num = self.startOfExtraSprites + self.extraSprites;
            self.ivarBodyColor = Color.red;

            //num = self.AddCosmetic(num, new Antennae(self, num));

            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new ShortBodyScales(self, num));
            }
            if (Random.value < 0.9f)
            {
                var e = new LongHeadScales(self, num)
                {
                    colored = false
                };
                e.numberOfSprites = e.scalesPositions.Length;
                var value = Random.value;
                var num2 = Mathf.Pow(Random.value, 0.45f);
                for (var i = 0; i < e.scalesPositions.Length; i++)
                {
                    e.scaleObjects[i] = new LizardScale(e)
                    {
                        length = Mathf.Lerp(10f, 30f, num),
                        width = Mathf.Lerp(1.0f, 1.4f, value * num)
                    };
                    e.backwardsFactors[i] = num2;
                }
                e.numberOfSprites = (e.colored ? (e.scalesPositions.Length * 2) : e.scalesPositions.Length);

                num = self.AddCosmetic(num, e);
            }
            if (Random.value < 0.9f)
            {
                var e = new SpineSpikes(self, num)
                {
                    colored = 0,
                    graphic = 4,
                    spineLength = Mathf.Lerp(0.3f, 0.55f, Random.value) * 1
                };
                e.numberOfSprites = e.bumps;

                num = self.AddCosmetic(num, e);
            }
            if (Random.value < 0.9f)
            {
                var e = new LongShoulderScales(self, num)
                {
                    rigor = 0f,
                    graphic = 4
                };
                e.GeneratePatchPattern(0.2f, Random.Range(6, 9), 0.9f, 2f);
                e.colored = false;
                var num4 = 0f;
                var num5 = 1f;
                var num2 = Mathf.Lerp(1f, 1f / Mathf.Lerp(1f, (float)e.scalesPositions.Length, Mathf.Pow(Random.value, 2f)), 0.5f);
                var num3 = Mathf.Lerp(5f, 15f, Random.value) * num2;
                var b = Mathf.Lerp(num3, 35f, Mathf.Pow(Random.value, 0.5f)) * num2;
                var p = Mathf.Lerp(0.1f, 0.9f, Random.value);
                e.scaleObjects = new LizardScale[e.scalesPositions.Length];
                e.backwardsFactors = new float[e.scalesPositions.Length];

                for (var i = 0; i < e.scalesPositions.Length; i++)
                {
                    if (e.scalesPositions[i].y > num4)
                    {
                        num4 = e.scalesPositions[i].y;
                    }
                    if (e.scalesPositions[i].y < num5)
                    {
                        num5 = e.scalesPositions[i].y;
                    }
                }

                for (var j = 0; j < e.scalesPositions.Length; j++)
                {
                    e.scaleObjects[j] = new LizardScale(e);
                    var num6 = Mathf.Pow(Mathf.InverseLerp(num5, num4, e.scalesPositions[j].y), p);
                    e.scaleObjects[j].length = (Mathf.Lerp(num3, b, Mathf.Lerp(Mathf.Sin(num6 * 3.1415927f), 1.1f, (num6 < 0.5f) ? 0.5f : 0.3f)));
                    e.scaleObjects[j].width = (Mathf.Lerp(1.0f, 1.2f, Mathf.Lerp(Mathf.Sin(num6 * 3.1415927f), 1.1f, (num6 < 0.5f) ? 0.5f : 0.3f)) * num2);
                    e.backwardsFactors[j] = e.scalesPositions[j].y * 0.7f;
                }
                e.numberOfSprites = (e.colored ? (e.scalesPositions.Length * 2) : e.scalesPositions.Length);

                num = self.AddCosmetic(num, e);
            }
            if (Random.value < 0.9f)
            {
                var e = new AxolotlGills(self, num)
                {
                    graphic = 6
                };
                num = self.AddCosmetic(num, e);
            }
            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new SnowAccumulation(self, num));
            }
            if (Random.value < 0.9f)
            {
                var e = new WingScales(self, num)
                {
                    graphic = (Random.value >= 0.4f) ? Random.Range(0, 5) : Random.Range(1, 5)
                };
                num = self.AddCosmetic(num, e);
            }
            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new JumpRings(self, num));
            }
            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new BodyStripes(self, num));
            }
            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new BumpHawk(self, num));
            }
            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new Whiskers(self, num));
            }
            if (Random.value < 0.9f)
            {
                num = self.AddCosmetic(num, new TailGeckoScales(self, num));
            }
            if (Random.value < 0.9f)
            {
                var e = new TailFin(self, num)
                {
                    colored = false
                };
                e.numberOfSprites = e.bumps * 2;
                _ = self.AddCosmetic(num, e);
            }

            Random.state = state;
        }
    }

    private static void LizardTongue_ctor(On.LizardTongue.orig_ctor orig, LizardTongue self, Lizard lizard)
    {
        orig(self, lizard);

        if (lizard is RueLizard) 
        {
            self.range = 350f;
            self.elasticRange = 0.1f;
            self.lashOutSpeed = 30f;
            self.reelInSpeed = 0.0043333336f;
            self.chunkDrag = 0f;
            self.terrainDrag = 0f;
            self.dragElasticity = 0.1f;
            self.emptyElasticity = 0.01f;
            self.involuntaryReleaseChance = 0.0033333334f;
            self.voluntaryReleaseChance = 1f;
            self.baseDragOnly = true;
            self.lizard.lizardParams.tongue = true;
        }
    }

    private static void Lizard_Update(On.Lizard.orig_Update orig, Lizard self, bool eu)
    {
        orig(self, eu);

        if (self is RueLizard && self.grabbedAttackCounter == 22 && self.JawReadyForBite && ((Random.value < self.lizardParams.getFreeBiteChance * Custom.LerpMap(self.grabbedBy[0].grabber.TotalMass, self.TotalMass, self.TotalMass * 3f, 1f, 0.1f) * self.LizardState.health && self.grabbedBy[0].grabber.Template.type != DorEnums.CreatureType.RueLizard && (self.grabbedBy[0].grabber.Template.type != CreatureType.Vulture || Random.value < 0.5f) && self.grabbedBy[0].grabber.Template.type != CreatureType.KingVulture) || (self.Template.type == DorEnums.CreatureType.RueLizard && Random.value < self.LizardState.health)))
        {
            self.DamageAttackClosestChunk(self.grabbedBy[0].grabber);
        }
    }

    private static CreatureTemplate LizardBreeds_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate(On.LizardBreeds.orig_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate orig, CreatureType type, CreatureTemplate lizardAncestor, CreatureTemplate pinkTemplate, CreatureTemplate blueTemplate, CreatureTemplate greenTemplate)
    {
        if (type == DorEnums.CreatureType.RueLizard)
        {
            var temp = orig(CreatureType.BlueLizard, lizardAncestor, pinkTemplate, blueTemplate, greenTemplate);

            var lizardBreedParams = (LizardBreedParams)temp.breedParameters;

            temp.type = type;
            temp.name = "RueLizard";

            lizardBreedParams.bodyRadFac = 1f;
            lizardBreedParams.pullDownFac = 1f;

            lizardBreedParams.biteDelay = 1;
            lizardBreedParams.biteInFront = 22f;
            lizardBreedParams.biteHomingSpeed = 1.85f;
            lizardBreedParams.biteChance = 0.9f;
            lizardBreedParams.attemptBiteRadius = 94f;
            lizardBreedParams.getFreeBiteChance = 0.95f;
            lizardBreedParams.biteDamage = 1.45f;
            lizardBreedParams.biteDamageChance = 0.8f;
            lizardBreedParams.toughness = 2.45f;
            lizardBreedParams.stunToughness = 2.40f;

            lizardBreedParams.aggressionCurveExponent = 0.095f;
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
            lizardBreedParams.tongueAttackRange = 350f;
            lizardBreedParams.tongueWarmUp = 8;
            lizardBreedParams.tongueSegments = 10;
            lizardBreedParams.tongueChance = 0.55f;

            lizardBreedParams.tamingDifficulty = 9999f;
            lizardBreedParams.tailSegments = Random.Range(7, 9);
            lizardBreedParams.tailLengthFactor = 1.1f;
            lizardBreedParams.danger = 2f;
            lizardBreedParams.standardColor = Color.red;
            lizardBreedParams.headSize = 1f;
            lizardBreedParams.bodySizeFac = 1.1f;
            lizardBreedParams.limbSize = 0.95f;
            lizardBreedParams.bodyLengthFac = 1.05f;
            lizardBreedParams.bodyMass = 0.95f;
            lizardBreedParams.limbQuickness = 0.7f;
            lizardBreedParams.wiggleSpeed = 1f;
            lizardBreedParams.baseSpeed = 4.05f;
            lizardBreedParams.terrainSpeeds[1] = new(1.35f, 1.3f, 1.3f, 1.3f);
            lizardBreedParams.terrainSpeeds[2] = new(1f, 1f, 1f, 1f);
            lizardBreedParams.terrainSpeeds[3] = new(1.2f, 1.35f, 1.3f, 1.3f);
            lizardBreedParams.terrainSpeeds[4] = new(1.25f, 1.35f, 1.3f, 1.3f);
            lizardBreedParams.terrainSpeeds[5] = new(1.05f, 1f, 1f, 1f);

            temp.waterPathingResistance = 5f;
            temp.visualRadius = 950f;
            temp.waterVision = 0.4f;
            temp.throughSurfaceVision = 0.85f;
            temp.breedParameters = lizardBreedParams;
            temp.baseDamageResistance = lizardBreedParams.toughness * 2f;
            temp.baseStunResistance = lizardBreedParams.toughness;

            temp.damageRestistances[(int)Creature.DamageType.Bite, 0] = 2.5f;
            temp.damageRestistances[(int)Creature.DamageType.Bite, 1] = 3f;
            temp.meatPoints = 8;
            temp.doPreBakedPathing = false;
            temp.preBakedPathingAncestor = StaticWorld.GetCreatureTemplate(CreatureType.BlueLizard);
            temp.requireAImap = true;
            temp.virtualCreature = false;
            temp.pickupAction = "Bite";
            temp.jumpAction = "Tongue";
            temp.throwAction = "Launch";
            temp.wormGrassImmune = false;
            temp.canSwim = true;
            temp.dangerousToPlayer = 10f;

            return temp;
        }

        return orig(type, lizardAncestor, pinkTemplate, blueTemplate, greenTemplate);
    }

    private static void Lizard_ctor(On.Lizard.orig_ctor orig, Lizard self, AbstractCreature abstractCreature, World world)
    {
        orig(self, abstractCreature, world);
        if (self.Template.type == DorEnums.CreatureType.RueLizard)
        {
            self.effectColor = Custom.HSL2RGB(Custom.WrappedRandomVariation(0.0025f, 0.02f, 0.6f), 1f, Custom.ClampedRandomVariation(0.5f, 0.15f, 0.1f));
        }

        if(self.Template.type == DorEnums.CreatureType.RueLizard && self.lizardParams.tongue)
        {
            self.tongue = new LizardTongue(self);
        }
    }
}