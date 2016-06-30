using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;
using AlomoEngine.Xml.DataTypes.Enums;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Engine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PathFindingMovementData : EngineObject
    {
        public PathFindingMovementData(IAlomoXmlFile parent) : base(parent) {}

        public int SpacePathfindMaxExpansions { get; set; }

        public double CurrentPathCostCoefficientSpace { get; set; }

        public int SpacePathfindFrameDelayDelta { get; set; }

        public double SpacePathFailureDistanceCutoffCoefficient { get; set; }

        public double SpacePathFailureMaxExpansionsCoefficient { get; set; }

        public double SpacePathFailureRotationExpansionIncrement { get; set; }

        public double SpacePathFailureForwardExpansionIncrement { get; set; }

        public int SpacePathingTries { get; set; }

        public int SpaceStaticObstacleAvoidanceBonusDistance { get; set; }

        public double MinObstacleCostSpace { get; set; }

        public double MaxObstacleCostSpace { get; set; }

        public double ObstacleAreaOverlapForMaxSpace { get; set; }

        public double XYExpansionDistanceSpace { get; set; }

        public double MaxRotationsSpace { get; set; }

        public double MatchFacingDeltaSpace { get; set; }

        public double OccupationRadiusCoefficientSpace { get; set; }

        public double DestinationSearchRadiusIncrementSpace { get; set; }

        public bool UseLinearCollisionChecks { get; set; }

        public double WaitOperatorCostCoefficient { get; set; }

        public int WaitOperatorBaseFrameTime { get; set; }

        public double WaitOperatorSpeedCoefficient { get; set; }

        public double LandWaitOperatorSpeedCoefficient { get; set; }

        public double SpaceLocomotorFacingLookaheadAcc { get; set; }

        public double FinalFacing180Penalty { get; set; }

        public double SpecialAlignedOperatorBonus { get; set; }

        public double ThreatExpansionDistance { get; set; }

        public double OffMapCostPenalty { get; set; }

        public double MaxLandFormationFormupFrames { get; set; }

        public int SpaceObjectTrackingInterval { get; set; }

        public int SpaceObjectTrackingTreeCount { get; set; }

        public bool ShouldDisplayPredictionPaths { get; set; }

        public bool ShouldDisplaySyncedPaths { get; set; }

        public double SyncedFrameInterval { get; set; }

        public double LandPredictionTimeInterval { get; set; }

        public double RepushDistance { get; set; }

        public double MinLandPredictionDistance { get; set; }

        public bool ShouldSkipLandFormup { get; set; }

        public bool ShouldInfantryTeamsSplitAcrossFormations { get; set; }

        public int VehicleFormationRecruitmentDistance { get; set; }

        public int InfantryFormationRecruitmentDistance { get; set; }

        public int CloseEnoughAngleForMoveStart { get; set; }

        public double DynamicObstacleOverlapPenalty { get; set; }

        public int DynamicAvoidanceRectangleBound { get; set; }

        public bool ShouldDisplayPotentialPath { get; set; }

        public double TurnInPlaceSlowdownCorvette { get; set; }

        public double TurnInPlaceSlowdownFrigate { get; set; }

        public double TurnInPlaceSlowdownCapital { get; set; }

        public double FormationMinimumSideError { get; set; }

        public double FormationMaximumSideError { get; set; }

        public double ApproximationSmoothCosAngle { get; set; }

        public double ApproximationForwardDistance { get; set; }

        public double MinimumStoppedVsStoppedOverlapCoefficient { get; set; }

        public double MovingVsMovingLookAheadTime { get; set; }

        public double LandTemporaryDestinationProximity { get; set; }

        public double LandDestinationProximity { get; set; }

        public double BetweenFormationSpacing { get; set; }

        public int Destination_Collision_Query_Extension { get; set; }

        public int FramesPerPositionApproximationRebuild { get; set; }

        [Description("each object only checks for pathfind collisions every 'n' frames")]
        public int FramesPerCollisionCheck { get; set; }

        public int MovementReevaluationFrameCount { get; set; }

        public int DynamicLandComplexityQuota { get; set; }

        public int DynamicLandQuotaResetInterval { get; set; }

        public double FinalFormationFacingMinimumAngle { get; set; }

        public double FinalFormationFacingDeltaCoefficient { get; set; }

        public double WalkAnimationCutoff { get; set; }

        public double DoubleClickMoveMaxSpeedRatio { get; set; }

        public int Fleeing_Infantry_Speed_Bonus { get; set; }

        public double IdleWalkBlendTime { get; set; }

        public double CrouchIdleWalkBlendTime { get; set; }

        public double MoveBlendTime { get; set; }

        public double CrouchMoveBlendTime { get; set; }

        public double TeamMoveBlendTime { get; set; }

        public double TeamCrouchMoveBlendTime { get; set; }

        public double InfantryTurnBlendTime { get; set; }


        public int LandObjectTrackingInterval { get; set; }
        public int LandObjectTrackingTreeCount { get; set; }
        public double MinObstacleCostLand { get; set; }
        public double MaxObstacleCostLand { get; set; }
        public double XYExpansionDistanceLand { get; set; }

        [Description("Global speed modifier to everything with engines, and when they are destroyed")]
        public double Engines_Disabled_Speed_Modifier { get; set; }
        public int Crouch_Move_Fire_Angle_Cutoff { get; set; }
        public int Max_Move_Frame_Delay { get; set; }
        public double Spread_Out_Spacing_Coefficient { get; set; }
        public double Max_Formation_Area { get; set; }
        public double Short_Range_Attack_Formation_Coefficient { get; set; }
        public double Solo_Attack_Range { get; set; }
        public double Base_Land_Targeting_Arc_Angle_Coefficient { get; set; }
        public bool Rotate_Formation_Facing_Moves { get; set; }
        public bool ShouldUseSpaceIdleMovement { get; set; }
        public double SpaceIdleMovementSpeed { get; set; }
        public double SpaceIdlePathCullCoefficient { get; set; }
        public double IdleMovementFrames { get; set; }

        public EngineStringTupel Preferred_Pathfinder_Types { get; set; }

        [Description("Clear space required along hyperspace in path for space reinforcements")]
        public double Space_Reinforcement_Collision_Check_Distance { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(SpacePathfindMaxExpansions), SpacePathfindMaxExpansions.ToString());
            node.SetValueOfLastTagOfName(nameof(CurrentPathCostCoefficientSpace), CurrentPathCostCoefficientSpace.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(SpacePathfindFrameDelayDelta), SpacePathfindFrameDelayDelta.ToString());
            node.SetValueOfLastTagOfName(nameof(SpacePathFailureDistanceCutoffCoefficient), SpacePathFailureDistanceCutoffCoefficient.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(SpacePathFailureMaxExpansionsCoefficient), SpacePathFailureMaxExpansionsCoefficient.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(SpacePathFailureRotationExpansionIncrement), SpacePathFailureRotationExpansionIncrement.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(SpacePathFailureForwardExpansionIncrement), SpacePathFailureForwardExpansionIncrement.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(SpacePathingTries), SpacePathingTries.ToString());
            node.SetValueOfLastTagOfName(nameof(SpacePathingTries), SpacePathingTries.ToString());
            node.SetValueOfLastTagOfName(nameof(MinObstacleCostSpace), MinObstacleCostSpace.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MaxObstacleCostSpace), MaxObstacleCostSpace.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(ObstacleAreaOverlapForMaxSpace), ObstacleAreaOverlapForMaxSpace.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(XYExpansionDistanceSpace), XYExpansionDistanceSpace.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MaxRotationsSpace), MaxRotationsSpace.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MatchFacingDeltaSpace), MatchFacingDeltaSpace.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(OccupationRadiusCoefficientSpace), OccupationRadiusCoefficientSpace.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(DestinationSearchRadiusIncrementSpace), DestinationSearchRadiusIncrementSpace.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(UseLinearCollisionChecks), UseLinearCollisionChecks.ToString());
            node.SetValueOfLastTagOfName(nameof(WaitOperatorCostCoefficient), WaitOperatorCostCoefficient.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(WaitOperatorBaseFrameTime), WaitOperatorBaseFrameTime.ToString());
            node.SetValueOfLastTagOfName(nameof(WaitOperatorSpeedCoefficient), WaitOperatorSpeedCoefficient.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(LandWaitOperatorSpeedCoefficient), LandWaitOperatorSpeedCoefficient.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(SpaceLocomotorFacingLookaheadAcc), SpaceLocomotorFacingLookaheadAcc.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(FinalFacing180Penalty), FinalFacing180Penalty.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(SpecialAlignedOperatorBonus), SpecialAlignedOperatorBonus.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(ThreatExpansionDistance), ThreatExpansionDistance.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(OffMapCostPenalty), OffMapCostPenalty.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MaxLandFormationFormupFrames), MaxLandFormationFormupFrames.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(SpaceObjectTrackingInterval), SpaceObjectTrackingInterval.ToString());
            node.SetValueOfLastTagOfName(nameof(SpaceObjectTrackingTreeCount), SpaceObjectTrackingTreeCount.ToString());
            node.SetValueOfLastTagOfName(nameof(ShouldDisplayPredictionPaths), ShouldDisplayPredictionPaths.ToString());
            node.SetValueOfLastTagOfName(nameof(ShouldDisplaySyncedPaths), ShouldDisplaySyncedPaths.ToString());
            node.SetValueOfLastTagOfName(nameof(SyncedFrameInterval), SyncedFrameInterval.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(LandPredictionTimeInterval), LandPredictionTimeInterval.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(RepushDistance), RepushDistance.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MinLandPredictionDistance), MinLandPredictionDistance.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(ShouldSkipLandFormup), ShouldSkipLandFormup.ToString());
            node.SetValueOfLastTagOfName(nameof(ShouldInfantryTeamsSplitAcrossFormations), ShouldInfantryTeamsSplitAcrossFormations.ToString());
            node.SetValueOfLastTagOfName(nameof(VehicleFormationRecruitmentDistance), VehicleFormationRecruitmentDistance.ToString());
            node.SetValueOfLastTagOfName(nameof(InfantryFormationRecruitmentDistance), InfantryFormationRecruitmentDistance.ToString());
            node.SetValueOfLastTagOfName(nameof(CloseEnoughAngleForMoveStart), CloseEnoughAngleForMoveStart.ToString());
            node.SetValueOfLastTagOfName(nameof(DynamicObstacleOverlapPenalty), DynamicObstacleOverlapPenalty.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(DynamicAvoidanceRectangleBound), DynamicAvoidanceRectangleBound.ToString());
            node.SetValueOfLastTagOfName(nameof(ShouldDisplayPotentialPath), ShouldDisplayPotentialPath.ToString());
            node.SetValueOfLastTagOfName(nameof(TurnInPlaceSlowdownCorvette), TurnInPlaceSlowdownCorvette.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(TurnInPlaceSlowdownFrigate), TurnInPlaceSlowdownFrigate.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(TurnInPlaceSlowdownCapital), TurnInPlaceSlowdownCapital.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(FormationMinimumSideError), FormationMinimumSideError.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(FormationMaximumSideError), FormationMaximumSideError.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(ApproximationSmoothCosAngle), ApproximationSmoothCosAngle.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(ApproximationForwardDistance), ApproximationForwardDistance.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MinimumStoppedVsStoppedOverlapCoefficient), MinimumStoppedVsStoppedOverlapCoefficient.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MovingVsMovingLookAheadTime), MovingVsMovingLookAheadTime.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(LandTemporaryDestinationProximity), LandTemporaryDestinationProximity.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(LandDestinationProximity), LandDestinationProximity.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(BetweenFormationSpacing), BetweenFormationSpacing.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Destination_Collision_Query_Extension), Destination_Collision_Query_Extension.ToString());
            node.SetValueOfLastTagOfName(nameof(FramesPerPositionApproximationRebuild), FramesPerPositionApproximationRebuild.ToString());
            node.SetValueOfLastTagOfName(nameof(FramesPerCollisionCheck), FramesPerCollisionCheck.ToString());
            node.SetValueOfLastTagOfName(nameof(MovementReevaluationFrameCount), MovementReevaluationFrameCount.ToString());
            node.SetValueOfLastTagOfName(nameof(DynamicLandComplexityQuota), DynamicLandComplexityQuota.ToString());
            node.SetValueOfLastTagOfName(nameof(DynamicLandQuotaResetInterval), DynamicLandQuotaResetInterval.ToString());
            node.SetValueOfLastTagOfName(nameof(FinalFormationFacingMinimumAngle), FinalFormationFacingMinimumAngle.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(FinalFormationFacingDeltaCoefficient), FinalFormationFacingDeltaCoefficient.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(WalkAnimationCutoff), WalkAnimationCutoff.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(DoubleClickMoveMaxSpeedRatio), DoubleClickMoveMaxSpeedRatio.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Fleeing_Infantry_Speed_Bonus), Fleeing_Infantry_Speed_Bonus.ToString());
            node.SetValueOfLastTagOfName(nameof(IdleWalkBlendTime), IdleWalkBlendTime.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(CrouchIdleWalkBlendTime), CrouchIdleWalkBlendTime.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MoveBlendTime), MoveBlendTime.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(CrouchMoveBlendTime), CrouchMoveBlendTime.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(TeamMoveBlendTime), TeamMoveBlendTime.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(TeamCrouchMoveBlendTime), TeamCrouchMoveBlendTime.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(InfantryTurnBlendTime), InfantryTurnBlendTime.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(LandObjectTrackingInterval), LandObjectTrackingInterval.ToString());
            node.SetValueOfLastTagOfName(nameof(LandObjectTrackingTreeCount), LandObjectTrackingTreeCount.ToString());
            node.SetValueOfLastTagOfName(nameof(MinObstacleCostLand), MinObstacleCostLand.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MaxObstacleCostLand), MaxObstacleCostLand.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(XYExpansionDistanceLand), XYExpansionDistanceLand.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Engines_Disabled_Speed_Modifier), Engines_Disabled_Speed_Modifier.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Crouch_Move_Fire_Angle_Cutoff), Crouch_Move_Fire_Angle_Cutoff.ToString());
            node.SetValueOfLastTagOfName(nameof(Max_Move_Frame_Delay), Max_Move_Frame_Delay.ToString());
            node.SetValueOfLastTagOfName(nameof(Spread_Out_Spacing_Coefficient), Spread_Out_Spacing_Coefficient.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Max_Formation_Area), Max_Formation_Area.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Short_Range_Attack_Formation_Coefficient), Short_Range_Attack_Formation_Coefficient.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Solo_Attack_Range), Solo_Attack_Range.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Base_Land_Targeting_Arc_Angle_Coefficient), Base_Land_Targeting_Arc_Angle_Coefficient.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Rotate_Formation_Facing_Moves), Rotate_Formation_Facing_Moves.ToString());
            node.SetValueOfLastTagOfName(nameof(ShouldUseSpaceIdleMovement), ShouldUseSpaceIdleMovement.ToString());
            node.SetValueOfLastTagOfName(nameof(SpaceIdleMovementSpeed), SpaceIdleMovementSpeed.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(SpaceIdlePathCullCoefficient), SpaceIdlePathCullCoefficient.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(IdleMovementFrames), IdleMovementFrames.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Preferred_Pathfinder_Types), Preferred_Pathfinder_Types.ToString(EngineSparators.Comma, true));

            node.SetValueOfLastTagOfName(nameof(Space_Reinforcement_Collision_Check_Distance), Space_Reinforcement_Collision_Check_Distance.ToString(CultureInfo.InvariantCulture));
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            SpacePathfindMaxExpansions = node.GetValueOfLastTagOfName(nameof(SpacePathfindMaxExpansions)).ToInteger();
            CurrentPathCostCoefficientSpace = node.GetValueOfLastTagOfName(nameof(CurrentPathCostCoefficientSpace)).ToEngineFloat();
            SpacePathfindFrameDelayDelta = node.GetValueOfLastTagOfName(nameof(SpacePathfindFrameDelayDelta)).ToInteger();
            SpacePathFailureDistanceCutoffCoefficient = node.GetValueOfLastTagOfName(nameof(SpacePathFailureDistanceCutoffCoefficient)).ToEngineFloat();
            SpacePathFailureMaxExpansionsCoefficient = node.GetValueOfLastTagOfName(nameof(SpacePathFailureMaxExpansionsCoefficient)).ToEngineFloat();
            SpacePathFailureRotationExpansionIncrement = node.GetValueOfLastTagOfName(nameof(SpacePathFailureRotationExpansionIncrement)).ToEngineFloat();
            SpacePathFailureForwardExpansionIncrement = node.GetValueOfLastTagOfName(nameof(SpacePathFailureForwardExpansionIncrement)).ToEngineFloat();
            SpacePathingTries = node.GetValueOfLastTagOfName(nameof(SpacePathingTries)).ToInteger();
            SpaceStaticObstacleAvoidanceBonusDistance = node.GetValueOfLastTagOfName(nameof(SpaceStaticObstacleAvoidanceBonusDistance)).ToInteger();
            MinObstacleCostSpace = node.GetValueOfLastTagOfName(nameof(MinObstacleCostSpace)).ToEngineFloat();
            MaxObstacleCostSpace = node.GetValueOfLastTagOfName(nameof(MaxObstacleCostSpace)).ToEngineFloat();
            ObstacleAreaOverlapForMaxSpace = node.GetValueOfLastTagOfName(nameof(ObstacleAreaOverlapForMaxSpace)).ToEngineFloat();
            XYExpansionDistanceSpace = node.GetValueOfLastTagOfName(nameof(XYExpansionDistanceSpace)).ToEngineFloat();
            MaxRotationsSpace = node.GetValueOfLastTagOfName(nameof(MaxRotationsSpace)).ToEngineFloat();
            MatchFacingDeltaSpace = node.GetValueOfLastTagOfName(nameof(MatchFacingDeltaSpace)).ToEngineFloat();
            OccupationRadiusCoefficientSpace = node.GetValueOfLastTagOfName(nameof(OccupationRadiusCoefficientSpace)).ToEngineFloat();
            DestinationSearchRadiusIncrementSpace = node.GetValueOfLastTagOfName(nameof(DestinationSearchRadiusIncrementSpace)).ToEngineFloat();
            UseLinearCollisionChecks = node.GetValueOfLastTagOfName(nameof(UseLinearCollisionChecks)).ToEngineBoolean();
            WaitOperatorCostCoefficient = node.GetValueOfLastTagOfName(nameof(WaitOperatorCostCoefficient)).ToEngineFloat();
            WaitOperatorBaseFrameTime = node.GetValueOfLastTagOfName(nameof(WaitOperatorBaseFrameTime)).ToInteger();
            WaitOperatorSpeedCoefficient = node.GetValueOfLastTagOfName(nameof(WaitOperatorSpeedCoefficient)).ToEngineFloat();
            LandWaitOperatorSpeedCoefficient = node.GetValueOfLastTagOfName(nameof(LandWaitOperatorSpeedCoefficient)).ToEngineFloat();
            SpaceLocomotorFacingLookaheadAcc = node.GetValueOfLastTagOfName(nameof(SpaceLocomotorFacingLookaheadAcc)).ToEngineFloat();
            FinalFacing180Penalty = node.GetValueOfLastTagOfName(nameof(FinalFacing180Penalty)).ToEngineFloat();
            SpecialAlignedOperatorBonus = node.GetValueOfLastTagOfName(nameof(SpecialAlignedOperatorBonus)).ToEngineFloat();
            ThreatExpansionDistance = node.GetValueOfLastTagOfName(nameof(ThreatExpansionDistance)).ToEngineFloat();
            OffMapCostPenalty = node.GetValueOfLastTagOfName(nameof(OffMapCostPenalty)).ToEngineFloat();
            MaxLandFormationFormupFrames = node.GetValueOfLastTagOfName(nameof(MaxLandFormationFormupFrames)).ToEngineFloat();
            SpaceObjectTrackingInterval = node.GetValueOfLastTagOfName(nameof(SpaceObjectTrackingInterval)).ToInteger();
            SpaceObjectTrackingTreeCount = node.GetValueOfLastTagOfName(nameof(SpaceObjectTrackingTreeCount)).ToInteger();
            ShouldDisplayPredictionPaths = node.GetValueOfLastTagOfName(nameof(ShouldDisplayPredictionPaths)).ToEngineBoolean();
            ShouldDisplaySyncedPaths = node.GetValueOfLastTagOfName(nameof(ShouldDisplaySyncedPaths)).ToEngineBoolean();
            SyncedFrameInterval = node.GetValueOfLastTagOfName(nameof(SyncedFrameInterval)).ToEngineFloat();
            LandPredictionTimeInterval = node.GetValueOfLastTagOfName(nameof(LandPredictionTimeInterval)).ToEngineFloat();
            RepushDistance = node.GetValueOfLastTagOfName(nameof(RepushDistance)).ToEngineFloat();
            MinLandPredictionDistance = node.GetValueOfLastTagOfName(nameof(MinLandPredictionDistance)).ToEngineFloat();
            ShouldSkipLandFormup = node.GetValueOfLastTagOfName(nameof(ShouldSkipLandFormup)).ToEngineBoolean();
            ShouldInfantryTeamsSplitAcrossFormations = node.GetValueOfLastTagOfName(nameof(ShouldInfantryTeamsSplitAcrossFormations)).ToEngineBoolean();
            VehicleFormationRecruitmentDistance = node.GetValueOfLastTagOfName(nameof(VehicleFormationRecruitmentDistance)).ToInteger();
            InfantryFormationRecruitmentDistance = node.GetValueOfLastTagOfName(nameof(InfantryFormationRecruitmentDistance)).ToInteger();
            CloseEnoughAngleForMoveStart = node.GetValueOfLastTagOfName(nameof(CloseEnoughAngleForMoveStart)).ToInteger();
            DynamicObstacleOverlapPenalty = node.GetValueOfLastTagOfName(nameof(DynamicObstacleOverlapPenalty)).ToEngineFloat();
            DynamicAvoidanceRectangleBound = node.GetValueOfLastTagOfName(nameof(DynamicAvoidanceRectangleBound)).ToInteger();
            ShouldDisplayPotentialPath = node.GetValueOfLastTagOfName(nameof(ShouldDisplayPotentialPath)).ToEngineBoolean();

            TurnInPlaceSlowdownCorvette = node.GetValueOfLastTagOfName(nameof(TurnInPlaceSlowdownCorvette)).ToEngineFloat();
            TurnInPlaceSlowdownFrigate = node.GetValueOfLastTagOfName(nameof(TurnInPlaceSlowdownFrigate)).ToEngineFloat();
            TurnInPlaceSlowdownCapital = node.GetValueOfLastTagOfName(nameof(TurnInPlaceSlowdownCapital)).ToEngineFloat();
            FormationMinimumSideError = node.GetValueOfLastTagOfName(nameof(FormationMinimumSideError)).ToEngineFloat();
            FormationMaximumSideError = node.GetValueOfLastTagOfName(nameof(FormationMaximumSideError)).ToEngineFloat();
            ApproximationSmoothCosAngle = node.GetValueOfLastTagOfName(nameof(ApproximationSmoothCosAngle)).ToEngineFloat();
            ApproximationForwardDistance = node.GetValueOfLastTagOfName(nameof(ApproximationForwardDistance)).ToEngineFloat();
            MinimumStoppedVsStoppedOverlapCoefficient = node.GetValueOfLastTagOfName(nameof(MinimumStoppedVsStoppedOverlapCoefficient)).ToEngineFloat();
            MovingVsMovingLookAheadTime = node.GetValueOfLastTagOfName(nameof(MovingVsMovingLookAheadTime)).ToEngineFloat();
            LandTemporaryDestinationProximity = node.GetValueOfLastTagOfName(nameof(LandTemporaryDestinationProximity)).ToEngineFloat();
            LandDestinationProximity = node.GetValueOfLastTagOfName(nameof(LandDestinationProximity)).ToEngineFloat();
            BetweenFormationSpacing = node.GetValueOfLastTagOfName(nameof(BetweenFormationSpacing)).ToEngineFloat();

            Destination_Collision_Query_Extension = node.GetValueOfLastTagOfName(nameof(Destination_Collision_Query_Extension)).ToInteger();
            FramesPerPositionApproximationRebuild = node.GetValueOfLastTagOfName(nameof(FramesPerPositionApproximationRebuild)).ToInteger();
            FramesPerCollisionCheck = node.GetValueOfLastTagOfName(nameof(FramesPerCollisionCheck)).ToInteger();
            MovementReevaluationFrameCount = node.GetValueOfLastTagOfName(nameof(MovementReevaluationFrameCount)).ToInteger();
            DynamicLandComplexityQuota = node.GetValueOfLastTagOfName(nameof(DynamicLandComplexityQuota)).ToInteger();
            DynamicLandQuotaResetInterval = node.GetValueOfLastTagOfName(nameof(DynamicLandQuotaResetInterval)).ToInteger();

            FinalFormationFacingMinimumAngle = node.GetValueOfLastTagOfName(nameof(FinalFormationFacingMinimumAngle)).ToEngineFloat();
            FinalFormationFacingDeltaCoefficient = node.GetValueOfLastTagOfName(nameof(FinalFormationFacingDeltaCoefficient)).ToEngineFloat();
            WalkAnimationCutoff = node.GetValueOfLastTagOfName(nameof(WalkAnimationCutoff)).ToEngineFloat();
            DoubleClickMoveMaxSpeedRatio = node.GetValueOfLastTagOfName(nameof(DoubleClickMoveMaxSpeedRatio)).ToEngineFloat();

            Fleeing_Infantry_Speed_Bonus = node.GetValueOfLastTagOfName(nameof(Fleeing_Infantry_Speed_Bonus)).ToInteger();

            IdleWalkBlendTime = node.GetValueOfLastTagOfName(nameof(IdleWalkBlendTime)).ToEngineFloat();
            CrouchIdleWalkBlendTime = node.GetValueOfLastTagOfName(nameof(CrouchIdleWalkBlendTime)).ToEngineFloat();
            MoveBlendTime = node.GetValueOfLastTagOfName(nameof(MoveBlendTime)).ToEngineFloat();
            CrouchMoveBlendTime = node.GetValueOfLastTagOfName(nameof(CrouchMoveBlendTime)).ToEngineFloat();
            TeamMoveBlendTime = node.GetValueOfLastTagOfName(nameof(TeamMoveBlendTime)).ToEngineFloat();
            TeamCrouchMoveBlendTime = node.GetValueOfLastTagOfName(nameof(TeamCrouchMoveBlendTime)).ToEngineFloat();
            InfantryTurnBlendTime = node.GetValueOfLastTagOfName(nameof(InfantryTurnBlendTime)).ToEngineFloat();

            LandObjectTrackingInterval = node.GetValueOfLastTagOfName(nameof(LandObjectTrackingInterval)).ToInteger();
            LandObjectTrackingTreeCount = node.GetValueOfLastTagOfName(nameof(LandObjectTrackingTreeCount)).ToInteger();
            MinObstacleCostLand = node.GetValueOfLastTagOfName(nameof(MinObstacleCostLand)).ToEngineFloat();
            MaxObstacleCostLand = node.GetValueOfLastTagOfName(nameof(MaxObstacleCostLand)).ToEngineFloat();
            XYExpansionDistanceLand = node.GetValueOfLastTagOfName(nameof(XYExpansionDistanceLand)).ToEngineFloat();

            Engines_Disabled_Speed_Modifier = node.GetValueOfLastTagOfName(nameof(Engines_Disabled_Speed_Modifier)).ToEngineFloat();
            Crouch_Move_Fire_Angle_Cutoff = node.GetValueOfLastTagOfName(nameof(Crouch_Move_Fire_Angle_Cutoff)).ToInteger();
            Max_Move_Frame_Delay = node.GetValueOfLastTagOfName(nameof(Max_Move_Frame_Delay)).ToInteger();
            Spread_Out_Spacing_Coefficient = node.GetValueOfLastTagOfName(nameof(Spread_Out_Spacing_Coefficient)).ToEngineFloat();
            Max_Formation_Area = node.GetValueOfLastTagOfName(nameof(Max_Formation_Area)).ToEngineFloat();
            Short_Range_Attack_Formation_Coefficient = node.GetValueOfLastTagOfName(nameof(Short_Range_Attack_Formation_Coefficient)).ToEngineFloat();
            Solo_Attack_Range = node.GetValueOfLastTagOfName(nameof(Solo_Attack_Range)).ToEngineFloat();
            Base_Land_Targeting_Arc_Angle_Coefficient = node.GetValueOfLastTagOfName(nameof(Base_Land_Targeting_Arc_Angle_Coefficient)).ToEngineFloat();
            Rotate_Formation_Facing_Moves = node.GetValueOfLastTagOfName(nameof(Rotate_Formation_Facing_Moves)).ToEngineBoolean();
            ShouldUseSpaceIdleMovement = node.GetValueOfLastTagOfName(nameof(ShouldUseSpaceIdleMovement)).ToEngineBoolean();
            SpaceIdleMovementSpeed = node.GetValueOfLastTagOfName(nameof(SpaceIdleMovementSpeed)).ToEngineFloat();
            SpaceIdlePathCullCoefficient = node.GetValueOfLastTagOfName(nameof(SpaceIdlePathCullCoefficient)).ToEngineFloat();
            IdleMovementFrames = node.GetValueOfLastTagOfName(nameof(IdleMovementFrames)).ToEngineFloat();

            Preferred_Pathfinder_Types = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Preferred_Pathfinder_Types)));

            Space_Reinforcement_Collision_Check_Distance = node.GetValueOfLastTagOfName(nameof(Space_Reinforcement_Collision_Check_Distance)).ToEngineFloat();
        }
    }
}
