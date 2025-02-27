import localVarRequest from 'request';

export * from './aIConfig';
export * from './aIConfigPatch';
export * from './aIConfigPost';
export * from './aIConfigVariation';
export * from './aIConfigVariationPatch';
export * from './aIConfigVariationPost';
export * from './aIConfigVariationsResponse';
export * from './aIConfigs';
export * from './access';
export * from './accessAllowedReason';
export * from './accessAllowedRep';
export * from './accessDenied';
export * from './accessDeniedReason';
export * from './accessTokenPost';
export * from './actionInput';
export * from './actionOutput';
export * from './aiConfigsAccess';
export * from './aiConfigsAccessAllowedReason';
export * from './aiConfigsAccessAllowedRep';
export * from './aiConfigsAccessDenied';
export * from './aiConfigsAccessDeniedReason';
export * from './aiConfigsLink';
export * from './applicationCollectionRep';
export * from './applicationFlagCollectionRep';
export * from './applicationRep';
export * from './applicationVersionRep';
export * from './applicationVersionsCollectionRep';
export * from './approvalRequestResponse';
export * from './approvalSettings';
export * from './approvalsCapabilityConfig';
export * from './assignedToRep';
export * from './audience';
export * from './audienceConfiguration';
export * from './audiencePost';
export * from './auditLogEntryListingRep';
export * from './auditLogEntryListingRepCollection';
export * from './auditLogEntryRep';
export * from './auditLogEventsHookCapabilityConfigPost';
export * from './auditLogEventsHookCapabilityConfigRep';
export * from './authorizedAppDataRep';
export * from './bayesianBetaBinomialStatsRep';
export * from './bayesianNormalStatsRep';
export * from './bigSegmentStoreIntegration';
export * from './bigSegmentStoreIntegrationCollection';
export * from './bigSegmentStoreIntegrationCollectionLinks';
export * from './bigSegmentStoreIntegrationLinks';
export * from './bigSegmentStoreStatus';
export * from './bigSegmentTarget';
export * from './booleanDefaults';
export * from './booleanFlagDefaults';
export * from './branchCollectionRep';
export * from './branchRep';
export * from './bulkEditMembersRep';
export * from './bulkEditTeamsRep';
export * from './callerIdentityRep';
export * from './capabilityConfigPost';
export * from './capabilityConfigRep';
export * from './clause';
export * from './client';
export * from './clientCollection';
export * from './clientSideAvailability';
export * from './clientSideAvailabilityPost';
export * from './completedBy';
export * from './conditionInput';
export * from './conditionOutput';
export * from './conflict';
export * from './conflictOutput';
export * from './contextAttributeName';
export * from './contextAttributeNames';
export * from './contextAttributeNamesCollection';
export * from './contextAttributeValue';
export * from './contextAttributeValues';
export * from './contextAttributeValuesCollection';
export * from './contextInstanceEvaluation';
export * from './contextInstanceEvaluationReason';
export * from './contextInstanceEvaluations';
export * from './contextInstanceRecord';
export * from './contextInstanceSearch';
export * from './contextInstanceSegmentMembership';
export * from './contextInstanceSegmentMemberships';
export * from './contextInstances';
export * from './contextKindRep';
export * from './contextKindsCollectionRep';
export * from './contextRecord';
export * from './contextSearch';
export * from './contexts';
export * from './copiedFromEnv';
export * from './coreLink';
export * from './createApprovalRequestRequest';
export * from './createCopyFlagConfigApprovalRequestRequest';
export * from './createFlagConfigApprovalRequestRequest';
export * from './createPhaseInput';
export * from './createReleaseInput';
export * from './createReleasePipelineInput';
export * from './createWorkflowTemplateInput';
export * from './credibleIntervalRep';
export * from './customProperty';
export * from './customRole';
export * from './customRolePost';
export * from './customRoles';
export * from './customWorkflowInput';
export * from './customWorkflowMeta';
export * from './customWorkflowOutput';
export * from './customWorkflowStageMeta';
export * from './customWorkflowsListingOutput';
export * from './defaultClientSideAvailability';
export * from './defaultClientSideAvailabilityPost';
export * from './defaults';
export * from './dependentExperimentRep';
export * from './dependentFlag';
export * from './dependentFlagEnvironment';
export * from './dependentFlagsByEnvironment';
export * from './dependentMetricGroupRep';
export * from './dependentMetricGroupRepWithMetrics';
export * from './dependentMetricOrMetricGroupRep';
export * from './deploymentCollectionRep';
export * from './deploymentRep';
export * from './destination';
export * from './destinationPost';
export * from './destinations';
export * from './distribution';
export * from './dynamicOptions';
export * from './dynamicOptionsParser';
export * from './endpoint';
export * from './environment';
export * from './environmentPost';
export * from './environmentSummary';
export * from './environments';
export * from './evaluationReason';
export * from './evaluationsSummary';
export * from './executionOutput';
export * from './expandableApprovalRequestResponse';
export * from './expandableApprovalRequestsResponse';
export * from './expandedFlagRep';
export * from './expandedResourceRep';
export * from './experiment';
export * from './experimentAllocationRep';
export * from './experimentBayesianResultsRep';
export * from './experimentCollectionRep';
export * from './experimentEnabledPeriodRep';
export * from './experimentEnvironmentSettingRep';
export * from './experimentInfoRep';
export * from './experimentPatchInput';
export * from './experimentPost';
export * from './expiringTarget';
export * from './expiringTargetError';
export * from './expiringTargetGetResponse';
export * from './expiringTargetPatchResponse';
export * from './expiringUserTargetGetResponse';
export * from './expiringUserTargetItem';
export * from './expiringUserTargetPatchResponse';
export * from './export';
export * from './extinction';
export * from './extinctionCollectionRep';
export * from './failureReasonRep';
export * from './featureFlag';
export * from './featureFlagBody';
export * from './featureFlagConfig';
export * from './featureFlagScheduledChange';
export * from './featureFlagScheduledChanges';
export * from './featureFlagStatus';
export * from './featureFlagStatusAcrossEnvironments';
export * from './featureFlagStatuses';
export * from './featureFlags';
export * from './fileRep';
export * from './flagConfigApprovalRequestResponse';
export * from './flagConfigApprovalRequestsResponse';
export * from './flagConfigEvaluation';
export * from './flagConfigMigrationSettingsRep';
export * from './flagCopyConfigEnvironment';
export * from './flagCopyConfigPost';
export * from './flagDefaultsRep';
export * from './flagEventCollectionRep';
export * from './flagEventExperiment';
export * from './flagEventExperimentCollection';
export * from './flagEventExperimentIteration';
export * from './flagEventImpactRep';
export * from './flagEventMemberRep';
export * from './flagEventRep';
export * from './flagFollowersByProjEnvGetRep';
export * from './flagFollowersGetRep';
export * from './flagImportConfigurationPost';
export * from './flagImportIntegration';
export * from './flagImportIntegrationCollection';
export * from './flagImportIntegrationCollectionLinks';
export * from './flagImportIntegrationLinks';
export * from './flagImportStatus';
export * from './flagInput';
export * from './flagLinkCollectionRep';
export * from './flagLinkMember';
export * from './flagLinkPost';
export * from './flagLinkRep';
export * from './flagListingRep';
export * from './flagMigrationSettingsRep';
export * from './flagPrerequisitePost';
export * from './flagReferenceCollectionRep';
export * from './flagReferenceRep';
export * from './flagRep';
export * from './flagScheduledChangesInput';
export * from './flagSempatch';
export * from './flagStatusRep';
export * from './flagSummary';
export * from './flagTriggerInput';
export * from './followFlagMember';
export * from './followersPerFlag';
export * from './forbiddenErrorRep';
export * from './formVariable';
export * from './hMACSignature';
export * from './headerItems';
export * from './holdoutDetailRep';
export * from './holdoutPatchInput';
export * from './holdoutPostRequest';
export * from './holdoutRep';
export * from './holdoutsCollectionRep';
export * from './hunkRep';
export * from './import';
export * from './initiatorRep';
export * from './insightGroup';
export * from './insightGroupCollection';
export * from './insightGroupCollectionMetadata';
export * from './insightGroupCollectionScoreMetadata';
export * from './insightGroupScores';
export * from './insightGroupsCountByIndicator';
export * from './insightPeriod';
export * from './insightScores';
export * from './insightsChart';
export * from './insightsChartBounds';
export * from './insightsChartMetadata';
export * from './insightsChartMetric';
export * from './insightsChartSeries';
export * from './insightsChartSeriesDataPoint';
export * from './insightsChartSeriesMetadata';
export * from './insightsChartSeriesMetadataAxis';
export * from './insightsMetricIndicatorRange';
export * from './insightsMetricScore';
export * from './insightsMetricTierDefinition';
export * from './insightsRepository';
export * from './insightsRepositoryCollection';
export * from './insightsRepositoryProject';
export * from './insightsRepositoryProjectCollection';
export * from './insightsRepositoryProjectMappings';
export * from './instructionUserRequest';
export * from './integration';
export * from './integrationConfigurationCollectionRep';
export * from './integrationConfigurationPost';
export * from './integrationConfigurationsRep';
export * from './integrationDeliveryConfiguration';
export * from './integrationDeliveryConfigurationCollection';
export * from './integrationDeliveryConfigurationCollectionLinks';
export * from './integrationDeliveryConfigurationLinks';
export * from './integrationDeliveryConfigurationPost';
export * from './integrationDeliveryConfigurationResponse';
export * from './integrationMetadata';
export * from './integrationStatus';
export * from './integrationStatusRep';
export * from './integrationSubscriptionStatusRep';
export * from './integrations';
export * from './invalidRequestErrorRep';
export * from './ipList';
export * from './iterationInput';
export * from './iterationRep';
export * from './lastSeenMetadata';
export * from './layerCollectionRep';
export * from './layerConfigurationRep';
export * from './layerPatchInput';
export * from './layerPost';
export * from './layerRep';
export * from './layerReservationRep';
export * from './layerSnapshotRep';
export * from './leadTimeStagesRep';
export * from './legacyExperimentRep';
export * from './link';
export * from './maintainerRep';
export * from './maintainerTeam';
export * from './member';
export * from './memberDataRep';
export * from './memberImportItem';
export * from './memberPermissionGrantSummaryRep';
export * from './memberSummary';
export * from './memberTeamSummaryRep';
export * from './memberTeamsPostInput';
export * from './members';
export * from './membersPatchInput';
export * from './message';
export * from './methodNotAllowedErrorRep';
export * from './metricByVariation';
export * from './metricCollectionRep';
export * from './metricEventDefaultRep';
export * from './metricGroupCollectionRep';
export * from './metricGroupPost';
export * from './metricGroupRep';
export * from './metricGroupResultsRep';
export * from './metricInGroupRep';
export * from './metricInGroupResultsRep';
export * from './metricInMetricGroupInput';
export * from './metricInput';
export * from './metricListingRep';
export * from './metricPost';
export * from './metricRep';
export * from './metricSeen';
export * from './metricV2Rep';
export * from './metrics';
export * from './migrationSafetyIssueRep';
export * from './migrationSettingsPost';
export * from './modelConfig';
export * from './modelConfigPost';
export * from './modelError';
export * from './modification';
export * from './multiEnvironmentDependentFlag';
export * from './multiEnvironmentDependentFlags';
export * from './namingConvention';
export * from './newMemberForm';
export * from './notFoundErrorRep';
export * from './oauthClientPost';
export * from './optionsArray';
export * from './paginatedLinks';
export * from './parameterDefault';
export * from './parameterRep';
export * from './parentAndSelfLinks';
export * from './parentLink';
export * from './parentResourceRep';
export * from './patchFailedErrorRep';
export * from './patchFlagsRequest';
export * from './patchOperation';
export * from './patchSegmentExpiringTargetInputRep';
export * from './patchSegmentExpiringTargetInstruction';
export * from './patchSegmentInstruction';
export * from './patchSegmentRequest';
export * from './patchUsersRequest';
export * from './patchWithComment';
export * from './permissionGrantInput';
export * from './phase';
export * from './phaseInfo';
export * from './postApprovalRequestApplyRequest';
export * from './postApprovalRequestReviewRequest';
export * from './postDeploymentEventInput';
export * from './postFlagScheduledChangesInput';
export * from './postInsightGroupParams';
export * from './prerequisite';
export * from './project';
export * from './projectPost';
export * from './projectRep';
export * from './projectSummary';
export * from './projectSummaryCollection';
export * from './projects';
export * from './pullRequestCollectionRep';
export * from './pullRequestLeadTimeRep';
export * from './pullRequestRep';
export * from './putBranch';
export * from './randomizationSettingsPut';
export * from './randomizationSettingsRep';
export * from './randomizationUnitInput';
export * from './randomizationUnitRep';
export * from './rateLimitedErrorRep';
export * from './recentTriggerBody';
export * from './referenceRep';
export * from './relatedExperimentRep';
export * from './relativeDifferenceRep';
export * from './relayAutoConfigCollectionRep';
export * from './relayAutoConfigPost';
export * from './relayAutoConfigRep';
export * from './release';
export * from './releaseAudience';
export * from './releaseGuardianConfiguration';
export * from './releaseGuardianConfigurationInput';
export * from './releasePhase';
export * from './releasePipeline';
export * from './releasePipelineCollection';
export * from './releaseProgression';
export * from './releaseProgressionCollection';
export * from './releaserAudienceConfigInput';
export * from './repositoryCollectionRep';
export * from './repositoryPost';
export * from './repositoryRep';
export * from './resourceAccess';
export * from './resourceIDResponse';
export * from './resourceId';
export * from './reviewOutput';
export * from './reviewResponse';
export * from './rollout';
export * from './rootResponse';
export * from './rule';
export * from './ruleClause';
export * from './sdkListRep';
export * from './sdkVersionListRep';
export * from './sdkVersionRep';
export * from './segmentBody';
export * from './segmentMetadata';
export * from './segmentTarget';
export * from './segmentUserList';
export * from './segmentUserState';
export * from './series';
export * from './seriesIntervalsRep';
export * from './seriesListRep';
export * from './simpleHoldoutRep';
export * from './slicedResultsRep';
export * from './sourceEnv';
export * from './sourceFlag';
export * from './stageInput';
export * from './stageOutput';
export * from './statement';
export * from './statementPost';
export * from './statisticCollectionRep';
export * from './statisticRep';
export * from './statisticsRoot';
export * from './statusConflictErrorRep';
export * from './statusResponse';
export * from './statusServiceUnavailable';
export * from './storeIntegrationError';
export * from './subjectDataRep';
export * from './subscriptionPost';
export * from './tagsCollection';
export * from './tagsLink';
export * from './target';
export * from './targetResourceRep';
export * from './team';
export * from './teamCustomRole';
export * from './teamCustomRoles';
export * from './teamImportsRep';
export * from './teamMaintainers';
export * from './teamMembers';
export * from './teamPatchInput';
export * from './teamPostInput';
export * from './teamProjects';
export * from './teams';
export * from './teamsPatchInput';
export * from './timestampRep';
export * from './token';
export * from './tokenSummary';
export * from './tokens';
export * from './treatmentInput';
export * from './treatmentParameterInput';
export * from './treatmentRep';
export * from './treatmentResultRep';
export * from './triggerPost';
export * from './triggerWorkflowCollectionRep';
export * from './triggerWorkflowRep';
export * from './unauthorizedErrorRep';
export * from './updatePhaseStatusInput';
export * from './updateReleasePipelineInput';
export * from './upsertContextKindPayload';
export * from './upsertFlagDefaultsPayload';
export * from './upsertPayloadRep';
export * from './upsertResponseRep';
export * from './urlPost';
export * from './user';
export * from './userAttributeNamesRep';
export * from './userFlagSetting';
export * from './userFlagSettings';
export * from './userRecord';
export * from './userSegment';
export * from './userSegmentRule';
export * from './userSegments';
export * from './users';
export * from './usersRep';
export * from './validationFailedErrorRep';
export * from './valuePut';
export * from './variation';
export * from './variationEvalSummary';
export * from './variationOrRolloutRep';
export * from './variationSummary';
export * from './versionsRep';
export * from './webhook';
export * from './webhookPost';
export * from './webhooks';
export * from './weightedVariation';
export * from './workflowTemplateMetadata';
export * from './workflowTemplateOutput';
export * from './workflowTemplateParameter';
export * from './workflowTemplatesListingOutputRep';

import * as fs from 'fs';

export interface RequestDetailedFile {
    value: Buffer;
    options?: {
        filename?: string;
        contentType?: string;
    }
}

export type RequestFile = string | Buffer | fs.ReadStream | RequestDetailedFile;


import { AIConfig } from './aIConfig';
import { AIConfigPatch } from './aIConfigPatch';
import { AIConfigPost } from './aIConfigPost';
import { AIConfigVariation } from './aIConfigVariation';
import { AIConfigVariationPatch } from './aIConfigVariationPatch';
import { AIConfigVariationPost } from './aIConfigVariationPost';
import { AIConfigVariationsResponse } from './aIConfigVariationsResponse';
import { AIConfigs } from './aIConfigs';
import { Access } from './access';
import { AccessAllowedReason } from './accessAllowedReason';
import { AccessAllowedRep } from './accessAllowedRep';
import { AccessDenied } from './accessDenied';
import { AccessDeniedReason } from './accessDeniedReason';
import { AccessTokenPost } from './accessTokenPost';
import { ActionInput } from './actionInput';
import { ActionOutput } from './actionOutput';
import { AiConfigsAccess } from './aiConfigsAccess';
import { AiConfigsAccessAllowedReason } from './aiConfigsAccessAllowedReason';
import { AiConfigsAccessAllowedRep } from './aiConfigsAccessAllowedRep';
import { AiConfigsAccessDenied } from './aiConfigsAccessDenied';
import { AiConfigsAccessDeniedReason } from './aiConfigsAccessDeniedReason';
import { AiConfigsLink } from './aiConfigsLink';
import { ApplicationCollectionRep } from './applicationCollectionRep';
import { ApplicationFlagCollectionRep } from './applicationFlagCollectionRep';
import { ApplicationRep } from './applicationRep';
import { ApplicationVersionRep } from './applicationVersionRep';
import { ApplicationVersionsCollectionRep } from './applicationVersionsCollectionRep';
import { ApprovalRequestResponse } from './approvalRequestResponse';
import { ApprovalSettings } from './approvalSettings';
import { ApprovalsCapabilityConfig } from './approvalsCapabilityConfig';
import { AssignedToRep } from './assignedToRep';
import { Audience } from './audience';
import { AudienceConfiguration } from './audienceConfiguration';
import { AudiencePost } from './audiencePost';
import { AuditLogEntryListingRep } from './auditLogEntryListingRep';
import { AuditLogEntryListingRepCollection } from './auditLogEntryListingRepCollection';
import { AuditLogEntryRep } from './auditLogEntryRep';
import { AuditLogEventsHookCapabilityConfigPost } from './auditLogEventsHookCapabilityConfigPost';
import { AuditLogEventsHookCapabilityConfigRep } from './auditLogEventsHookCapabilityConfigRep';
import { AuthorizedAppDataRep } from './authorizedAppDataRep';
import { BayesianBetaBinomialStatsRep } from './bayesianBetaBinomialStatsRep';
import { BayesianNormalStatsRep } from './bayesianNormalStatsRep';
import { BigSegmentStoreIntegration } from './bigSegmentStoreIntegration';
import { BigSegmentStoreIntegrationCollection } from './bigSegmentStoreIntegrationCollection';
import { BigSegmentStoreIntegrationCollectionLinks } from './bigSegmentStoreIntegrationCollectionLinks';
import { BigSegmentStoreIntegrationLinks } from './bigSegmentStoreIntegrationLinks';
import { BigSegmentStoreStatus } from './bigSegmentStoreStatus';
import { BigSegmentTarget } from './bigSegmentTarget';
import { BooleanDefaults } from './booleanDefaults';
import { BooleanFlagDefaults } from './booleanFlagDefaults';
import { BranchCollectionRep } from './branchCollectionRep';
import { BranchRep } from './branchRep';
import { BulkEditMembersRep } from './bulkEditMembersRep';
import { BulkEditTeamsRep } from './bulkEditTeamsRep';
import { CallerIdentityRep } from './callerIdentityRep';
import { CapabilityConfigPost } from './capabilityConfigPost';
import { CapabilityConfigRep } from './capabilityConfigRep';
import { Clause } from './clause';
import { Client } from './client';
import { ClientCollection } from './clientCollection';
import { ClientSideAvailability } from './clientSideAvailability';
import { ClientSideAvailabilityPost } from './clientSideAvailabilityPost';
import { CompletedBy } from './completedBy';
import { ConditionInput } from './conditionInput';
import { ConditionOutput } from './conditionOutput';
import { Conflict } from './conflict';
import { ConflictOutput } from './conflictOutput';
import { ContextAttributeName } from './contextAttributeName';
import { ContextAttributeNames } from './contextAttributeNames';
import { ContextAttributeNamesCollection } from './contextAttributeNamesCollection';
import { ContextAttributeValue } from './contextAttributeValue';
import { ContextAttributeValues } from './contextAttributeValues';
import { ContextAttributeValuesCollection } from './contextAttributeValuesCollection';
import { ContextInstanceEvaluation } from './contextInstanceEvaluation';
import { ContextInstanceEvaluationReason } from './contextInstanceEvaluationReason';
import { ContextInstanceEvaluations } from './contextInstanceEvaluations';
import { ContextInstanceRecord } from './contextInstanceRecord';
import { ContextInstanceSearch } from './contextInstanceSearch';
import { ContextInstanceSegmentMembership } from './contextInstanceSegmentMembership';
import { ContextInstanceSegmentMemberships } from './contextInstanceSegmentMemberships';
import { ContextInstances } from './contextInstances';
import { ContextKindRep } from './contextKindRep';
import { ContextKindsCollectionRep } from './contextKindsCollectionRep';
import { ContextRecord } from './contextRecord';
import { ContextSearch } from './contextSearch';
import { Contexts } from './contexts';
import { CopiedFromEnv } from './copiedFromEnv';
import { CoreLink } from './coreLink';
import { CreateApprovalRequestRequest } from './createApprovalRequestRequest';
import { CreateCopyFlagConfigApprovalRequestRequest } from './createCopyFlagConfigApprovalRequestRequest';
import { CreateFlagConfigApprovalRequestRequest } from './createFlagConfigApprovalRequestRequest';
import { CreatePhaseInput } from './createPhaseInput';
import { CreateReleaseInput } from './createReleaseInput';
import { CreateReleasePipelineInput } from './createReleasePipelineInput';
import { CreateWorkflowTemplateInput } from './createWorkflowTemplateInput';
import { CredibleIntervalRep } from './credibleIntervalRep';
import { CustomProperty } from './customProperty';
import { CustomRole } from './customRole';
import { CustomRolePost } from './customRolePost';
import { CustomRoles } from './customRoles';
import { CustomWorkflowInput } from './customWorkflowInput';
import { CustomWorkflowMeta } from './customWorkflowMeta';
import { CustomWorkflowOutput } from './customWorkflowOutput';
import { CustomWorkflowStageMeta } from './customWorkflowStageMeta';
import { CustomWorkflowsListingOutput } from './customWorkflowsListingOutput';
import { DefaultClientSideAvailability } from './defaultClientSideAvailability';
import { DefaultClientSideAvailabilityPost } from './defaultClientSideAvailabilityPost';
import { Defaults } from './defaults';
import { DependentExperimentRep } from './dependentExperimentRep';
import { DependentFlag } from './dependentFlag';
import { DependentFlagEnvironment } from './dependentFlagEnvironment';
import { DependentFlagsByEnvironment } from './dependentFlagsByEnvironment';
import { DependentMetricGroupRep } from './dependentMetricGroupRep';
import { DependentMetricGroupRepWithMetrics } from './dependentMetricGroupRepWithMetrics';
import { DependentMetricOrMetricGroupRep } from './dependentMetricOrMetricGroupRep';
import { DeploymentCollectionRep } from './deploymentCollectionRep';
import { DeploymentRep } from './deploymentRep';
import { Destination } from './destination';
import { DestinationPost } from './destinationPost';
import { Destinations } from './destinations';
import { Distribution } from './distribution';
import { DynamicOptions } from './dynamicOptions';
import { DynamicOptionsParser } from './dynamicOptionsParser';
import { Endpoint } from './endpoint';
import { Environment } from './environment';
import { EnvironmentPost } from './environmentPost';
import { EnvironmentSummary } from './environmentSummary';
import { Environments } from './environments';
import { EvaluationReason } from './evaluationReason';
import { EvaluationsSummary } from './evaluationsSummary';
import { ExecutionOutput } from './executionOutput';
import { ExpandableApprovalRequestResponse } from './expandableApprovalRequestResponse';
import { ExpandableApprovalRequestsResponse } from './expandableApprovalRequestsResponse';
import { ExpandedFlagRep } from './expandedFlagRep';
import { ExpandedResourceRep } from './expandedResourceRep';
import { Experiment } from './experiment';
import { ExperimentAllocationRep } from './experimentAllocationRep';
import { ExperimentBayesianResultsRep } from './experimentBayesianResultsRep';
import { ExperimentCollectionRep } from './experimentCollectionRep';
import { ExperimentEnabledPeriodRep } from './experimentEnabledPeriodRep';
import { ExperimentEnvironmentSettingRep } from './experimentEnvironmentSettingRep';
import { ExperimentInfoRep } from './experimentInfoRep';
import { ExperimentPatchInput } from './experimentPatchInput';
import { ExperimentPost } from './experimentPost';
import { ExpiringTarget } from './expiringTarget';
import { ExpiringTargetError } from './expiringTargetError';
import { ExpiringTargetGetResponse } from './expiringTargetGetResponse';
import { ExpiringTargetPatchResponse } from './expiringTargetPatchResponse';
import { ExpiringUserTargetGetResponse } from './expiringUserTargetGetResponse';
import { ExpiringUserTargetItem } from './expiringUserTargetItem';
import { ExpiringUserTargetPatchResponse } from './expiringUserTargetPatchResponse';
import { Export } from './export';
import { Extinction } from './extinction';
import { ExtinctionCollectionRep } from './extinctionCollectionRep';
import { FailureReasonRep } from './failureReasonRep';
import { FeatureFlag } from './featureFlag';
import { FeatureFlagBody } from './featureFlagBody';
import { FeatureFlagConfig } from './featureFlagConfig';
import { FeatureFlagScheduledChange } from './featureFlagScheduledChange';
import { FeatureFlagScheduledChanges } from './featureFlagScheduledChanges';
import { FeatureFlagStatus } from './featureFlagStatus';
import { FeatureFlagStatusAcrossEnvironments } from './featureFlagStatusAcrossEnvironments';
import { FeatureFlagStatuses } from './featureFlagStatuses';
import { FeatureFlags } from './featureFlags';
import { FileRep } from './fileRep';
import { FlagConfigApprovalRequestResponse } from './flagConfigApprovalRequestResponse';
import { FlagConfigApprovalRequestsResponse } from './flagConfigApprovalRequestsResponse';
import { FlagConfigEvaluation } from './flagConfigEvaluation';
import { FlagConfigMigrationSettingsRep } from './flagConfigMigrationSettingsRep';
import { FlagCopyConfigEnvironment } from './flagCopyConfigEnvironment';
import { FlagCopyConfigPost } from './flagCopyConfigPost';
import { FlagDefaultsRep } from './flagDefaultsRep';
import { FlagEventCollectionRep } from './flagEventCollectionRep';
import { FlagEventExperiment } from './flagEventExperiment';
import { FlagEventExperimentCollection } from './flagEventExperimentCollection';
import { FlagEventExperimentIteration } from './flagEventExperimentIteration';
import { FlagEventImpactRep } from './flagEventImpactRep';
import { FlagEventMemberRep } from './flagEventMemberRep';
import { FlagEventRep } from './flagEventRep';
import { FlagFollowersByProjEnvGetRep } from './flagFollowersByProjEnvGetRep';
import { FlagFollowersGetRep } from './flagFollowersGetRep';
import { FlagImportConfigurationPost } from './flagImportConfigurationPost';
import { FlagImportIntegration } from './flagImportIntegration';
import { FlagImportIntegrationCollection } from './flagImportIntegrationCollection';
import { FlagImportIntegrationCollectionLinks } from './flagImportIntegrationCollectionLinks';
import { FlagImportIntegrationLinks } from './flagImportIntegrationLinks';
import { FlagImportStatus } from './flagImportStatus';
import { FlagInput } from './flagInput';
import { FlagLinkCollectionRep } from './flagLinkCollectionRep';
import { FlagLinkMember } from './flagLinkMember';
import { FlagLinkPost } from './flagLinkPost';
import { FlagLinkRep } from './flagLinkRep';
import { FlagListingRep } from './flagListingRep';
import { FlagMigrationSettingsRep } from './flagMigrationSettingsRep';
import { FlagPrerequisitePost } from './flagPrerequisitePost';
import { FlagReferenceCollectionRep } from './flagReferenceCollectionRep';
import { FlagReferenceRep } from './flagReferenceRep';
import { FlagRep } from './flagRep';
import { FlagScheduledChangesInput } from './flagScheduledChangesInput';
import { FlagSempatch } from './flagSempatch';
import { FlagStatusRep } from './flagStatusRep';
import { FlagSummary } from './flagSummary';
import { FlagTriggerInput } from './flagTriggerInput';
import { FollowFlagMember } from './followFlagMember';
import { FollowersPerFlag } from './followersPerFlag';
import { ForbiddenErrorRep } from './forbiddenErrorRep';
import { FormVariable } from './formVariable';
import { HMACSignature } from './hMACSignature';
import { HeaderItems } from './headerItems';
import { HoldoutDetailRep } from './holdoutDetailRep';
import { HoldoutPatchInput } from './holdoutPatchInput';
import { HoldoutPostRequest } from './holdoutPostRequest';
import { HoldoutRep } from './holdoutRep';
import { HoldoutsCollectionRep } from './holdoutsCollectionRep';
import { HunkRep } from './hunkRep';
import { Import } from './import';
import { InitiatorRep } from './initiatorRep';
import { InsightGroup } from './insightGroup';
import { InsightGroupCollection } from './insightGroupCollection';
import { InsightGroupCollectionMetadata } from './insightGroupCollectionMetadata';
import { InsightGroupCollectionScoreMetadata } from './insightGroupCollectionScoreMetadata';
import { InsightGroupScores } from './insightGroupScores';
import { InsightGroupsCountByIndicator } from './insightGroupsCountByIndicator';
import { InsightPeriod } from './insightPeriod';
import { InsightScores } from './insightScores';
import { InsightsChart } from './insightsChart';
import { InsightsChartBounds } from './insightsChartBounds';
import { InsightsChartMetadata } from './insightsChartMetadata';
import { InsightsChartMetric } from './insightsChartMetric';
import { InsightsChartSeries } from './insightsChartSeries';
import { InsightsChartSeriesDataPoint } from './insightsChartSeriesDataPoint';
import { InsightsChartSeriesMetadata } from './insightsChartSeriesMetadata';
import { InsightsChartSeriesMetadataAxis } from './insightsChartSeriesMetadataAxis';
import { InsightsMetricIndicatorRange } from './insightsMetricIndicatorRange';
import { InsightsMetricScore } from './insightsMetricScore';
import { InsightsMetricTierDefinition } from './insightsMetricTierDefinition';
import { InsightsRepository } from './insightsRepository';
import { InsightsRepositoryCollection } from './insightsRepositoryCollection';
import { InsightsRepositoryProject } from './insightsRepositoryProject';
import { InsightsRepositoryProjectCollection } from './insightsRepositoryProjectCollection';
import { InsightsRepositoryProjectMappings } from './insightsRepositoryProjectMappings';
import { InstructionUserRequest } from './instructionUserRequest';
import { Integration } from './integration';
import { IntegrationConfigurationCollectionRep } from './integrationConfigurationCollectionRep';
import { IntegrationConfigurationPost } from './integrationConfigurationPost';
import { IntegrationConfigurationsRep } from './integrationConfigurationsRep';
import { IntegrationDeliveryConfiguration } from './integrationDeliveryConfiguration';
import { IntegrationDeliveryConfigurationCollection } from './integrationDeliveryConfigurationCollection';
import { IntegrationDeliveryConfigurationCollectionLinks } from './integrationDeliveryConfigurationCollectionLinks';
import { IntegrationDeliveryConfigurationLinks } from './integrationDeliveryConfigurationLinks';
import { IntegrationDeliveryConfigurationPost } from './integrationDeliveryConfigurationPost';
import { IntegrationDeliveryConfigurationResponse } from './integrationDeliveryConfigurationResponse';
import { IntegrationMetadata } from './integrationMetadata';
import { IntegrationStatus } from './integrationStatus';
import { IntegrationStatusRep } from './integrationStatusRep';
import { IntegrationSubscriptionStatusRep } from './integrationSubscriptionStatusRep';
import { Integrations } from './integrations';
import { InvalidRequestErrorRep } from './invalidRequestErrorRep';
import { IpList } from './ipList';
import { IterationInput } from './iterationInput';
import { IterationRep } from './iterationRep';
import { LastSeenMetadata } from './lastSeenMetadata';
import { LayerCollectionRep } from './layerCollectionRep';
import { LayerConfigurationRep } from './layerConfigurationRep';
import { LayerPatchInput } from './layerPatchInput';
import { LayerPost } from './layerPost';
import { LayerRep } from './layerRep';
import { LayerReservationRep } from './layerReservationRep';
import { LayerSnapshotRep } from './layerSnapshotRep';
import { LeadTimeStagesRep } from './leadTimeStagesRep';
import { LegacyExperimentRep } from './legacyExperimentRep';
import { Link } from './link';
import { MaintainerRep } from './maintainerRep';
import { MaintainerTeam } from './maintainerTeam';
import { Member } from './member';
import { MemberDataRep } from './memberDataRep';
import { MemberImportItem } from './memberImportItem';
import { MemberPermissionGrantSummaryRep } from './memberPermissionGrantSummaryRep';
import { MemberSummary } from './memberSummary';
import { MemberTeamSummaryRep } from './memberTeamSummaryRep';
import { MemberTeamsPostInput } from './memberTeamsPostInput';
import { Members } from './members';
import { MembersPatchInput } from './membersPatchInput';
import { Message } from './message';
import { MethodNotAllowedErrorRep } from './methodNotAllowedErrorRep';
import { MetricByVariation } from './metricByVariation';
import { MetricCollectionRep } from './metricCollectionRep';
import { MetricEventDefaultRep } from './metricEventDefaultRep';
import { MetricGroupCollectionRep } from './metricGroupCollectionRep';
import { MetricGroupPost } from './metricGroupPost';
import { MetricGroupRep } from './metricGroupRep';
import { MetricGroupResultsRep } from './metricGroupResultsRep';
import { MetricInGroupRep } from './metricInGroupRep';
import { MetricInGroupResultsRep } from './metricInGroupResultsRep';
import { MetricInMetricGroupInput } from './metricInMetricGroupInput';
import { MetricInput } from './metricInput';
import { MetricListingRep } from './metricListingRep';
import { MetricPost } from './metricPost';
import { MetricRep } from './metricRep';
import { MetricSeen } from './metricSeen';
import { MetricV2Rep } from './metricV2Rep';
import { Metrics } from './metrics';
import { MigrationSafetyIssueRep } from './migrationSafetyIssueRep';
import { MigrationSettingsPost } from './migrationSettingsPost';
import { ModelConfig } from './modelConfig';
import { ModelConfigPost } from './modelConfigPost';
import { ModelError } from './modelError';
import { Modification } from './modification';
import { MultiEnvironmentDependentFlag } from './multiEnvironmentDependentFlag';
import { MultiEnvironmentDependentFlags } from './multiEnvironmentDependentFlags';
import { NamingConvention } from './namingConvention';
import { NewMemberForm } from './newMemberForm';
import { NotFoundErrorRep } from './notFoundErrorRep';
import { OauthClientPost } from './oauthClientPost';
import { OptionsArray } from './optionsArray';
import { PaginatedLinks } from './paginatedLinks';
import { ParameterDefault } from './parameterDefault';
import { ParameterRep } from './parameterRep';
import { ParentAndSelfLinks } from './parentAndSelfLinks';
import { ParentLink } from './parentLink';
import { ParentResourceRep } from './parentResourceRep';
import { PatchFailedErrorRep } from './patchFailedErrorRep';
import { PatchFlagsRequest } from './patchFlagsRequest';
import { PatchOperation } from './patchOperation';
import { PatchSegmentExpiringTargetInputRep } from './patchSegmentExpiringTargetInputRep';
import { PatchSegmentExpiringTargetInstruction } from './patchSegmentExpiringTargetInstruction';
import { PatchSegmentInstruction } from './patchSegmentInstruction';
import { PatchSegmentRequest } from './patchSegmentRequest';
import { PatchUsersRequest } from './patchUsersRequest';
import { PatchWithComment } from './patchWithComment';
import { PermissionGrantInput } from './permissionGrantInput';
import { Phase } from './phase';
import { PhaseInfo } from './phaseInfo';
import { PostApprovalRequestApplyRequest } from './postApprovalRequestApplyRequest';
import { PostApprovalRequestReviewRequest } from './postApprovalRequestReviewRequest';
import { PostDeploymentEventInput } from './postDeploymentEventInput';
import { PostFlagScheduledChangesInput } from './postFlagScheduledChangesInput';
import { PostInsightGroupParams } from './postInsightGroupParams';
import { Prerequisite } from './prerequisite';
import { Project } from './project';
import { ProjectPost } from './projectPost';
import { ProjectRep } from './projectRep';
import { ProjectSummary } from './projectSummary';
import { ProjectSummaryCollection } from './projectSummaryCollection';
import { Projects } from './projects';
import { PullRequestCollectionRep } from './pullRequestCollectionRep';
import { PullRequestLeadTimeRep } from './pullRequestLeadTimeRep';
import { PullRequestRep } from './pullRequestRep';
import { PutBranch } from './putBranch';
import { RandomizationSettingsPut } from './randomizationSettingsPut';
import { RandomizationSettingsRep } from './randomizationSettingsRep';
import { RandomizationUnitInput } from './randomizationUnitInput';
import { RandomizationUnitRep } from './randomizationUnitRep';
import { RateLimitedErrorRep } from './rateLimitedErrorRep';
import { RecentTriggerBody } from './recentTriggerBody';
import { ReferenceRep } from './referenceRep';
import { RelatedExperimentRep } from './relatedExperimentRep';
import { RelativeDifferenceRep } from './relativeDifferenceRep';
import { RelayAutoConfigCollectionRep } from './relayAutoConfigCollectionRep';
import { RelayAutoConfigPost } from './relayAutoConfigPost';
import { RelayAutoConfigRep } from './relayAutoConfigRep';
import { Release } from './release';
import { ReleaseAudience } from './releaseAudience';
import { ReleaseGuardianConfiguration } from './releaseGuardianConfiguration';
import { ReleaseGuardianConfigurationInput } from './releaseGuardianConfigurationInput';
import { ReleasePhase } from './releasePhase';
import { ReleasePipeline } from './releasePipeline';
import { ReleasePipelineCollection } from './releasePipelineCollection';
import { ReleaseProgression } from './releaseProgression';
import { ReleaseProgressionCollection } from './releaseProgressionCollection';
import { ReleaserAudienceConfigInput } from './releaserAudienceConfigInput';
import { RepositoryCollectionRep } from './repositoryCollectionRep';
import { RepositoryPost } from './repositoryPost';
import { RepositoryRep } from './repositoryRep';
import { ResourceAccess } from './resourceAccess';
import { ResourceIDResponse } from './resourceIDResponse';
import { ResourceId } from './resourceId';
import { ReviewOutput } from './reviewOutput';
import { ReviewResponse } from './reviewResponse';
import { Rollout } from './rollout';
import { RootResponse } from './rootResponse';
import { Rule } from './rule';
import { RuleClause } from './ruleClause';
import { SdkListRep } from './sdkListRep';
import { SdkVersionListRep } from './sdkVersionListRep';
import { SdkVersionRep } from './sdkVersionRep';
import { SegmentBody } from './segmentBody';
import { SegmentMetadata } from './segmentMetadata';
import { SegmentTarget } from './segmentTarget';
import { SegmentUserList } from './segmentUserList';
import { SegmentUserState } from './segmentUserState';
import { Series } from './series';
import { SeriesIntervalsRep } from './seriesIntervalsRep';
import { SeriesListRep } from './seriesListRep';
import { SimpleHoldoutRep } from './simpleHoldoutRep';
import { SlicedResultsRep } from './slicedResultsRep';
import { SourceEnv } from './sourceEnv';
import { SourceFlag } from './sourceFlag';
import { StageInput } from './stageInput';
import { StageOutput } from './stageOutput';
import { Statement } from './statement';
import { StatementPost } from './statementPost';
import { StatisticCollectionRep } from './statisticCollectionRep';
import { StatisticRep } from './statisticRep';
import { StatisticsRoot } from './statisticsRoot';
import { StatusConflictErrorRep } from './statusConflictErrorRep';
import { StatusResponse } from './statusResponse';
import { StatusServiceUnavailable } from './statusServiceUnavailable';
import { StoreIntegrationError } from './storeIntegrationError';
import { SubjectDataRep } from './subjectDataRep';
import { SubscriptionPost } from './subscriptionPost';
import { TagsCollection } from './tagsCollection';
import { TagsLink } from './tagsLink';
import { Target } from './target';
import { TargetResourceRep } from './targetResourceRep';
import { Team } from './team';
import { TeamCustomRole } from './teamCustomRole';
import { TeamCustomRoles } from './teamCustomRoles';
import { TeamImportsRep } from './teamImportsRep';
import { TeamMaintainers } from './teamMaintainers';
import { TeamMembers } from './teamMembers';
import { TeamPatchInput } from './teamPatchInput';
import { TeamPostInput } from './teamPostInput';
import { TeamProjects } from './teamProjects';
import { Teams } from './teams';
import { TeamsPatchInput } from './teamsPatchInput';
import { TimestampRep } from './timestampRep';
import { Token } from './token';
import { TokenSummary } from './tokenSummary';
import { Tokens } from './tokens';
import { TreatmentInput } from './treatmentInput';
import { TreatmentParameterInput } from './treatmentParameterInput';
import { TreatmentRep } from './treatmentRep';
import { TreatmentResultRep } from './treatmentResultRep';
import { TriggerPost } from './triggerPost';
import { TriggerWorkflowCollectionRep } from './triggerWorkflowCollectionRep';
import { TriggerWorkflowRep } from './triggerWorkflowRep';
import { UnauthorizedErrorRep } from './unauthorizedErrorRep';
import { UpdatePhaseStatusInput } from './updatePhaseStatusInput';
import { UpdateReleasePipelineInput } from './updateReleasePipelineInput';
import { UpsertContextKindPayload } from './upsertContextKindPayload';
import { UpsertFlagDefaultsPayload } from './upsertFlagDefaultsPayload';
import { UpsertPayloadRep } from './upsertPayloadRep';
import { UpsertResponseRep } from './upsertResponseRep';
import { UrlPost } from './urlPost';
import { User } from './user';
import { UserAttributeNamesRep } from './userAttributeNamesRep';
import { UserFlagSetting } from './userFlagSetting';
import { UserFlagSettings } from './userFlagSettings';
import { UserRecord } from './userRecord';
import { UserSegment } from './userSegment';
import { UserSegmentRule } from './userSegmentRule';
import { UserSegments } from './userSegments';
import { Users } from './users';
import { UsersRep } from './usersRep';
import { ValidationFailedErrorRep } from './validationFailedErrorRep';
import { ValuePut } from './valuePut';
import { Variation } from './variation';
import { VariationEvalSummary } from './variationEvalSummary';
import { VariationOrRolloutRep } from './variationOrRolloutRep';
import { VariationSummary } from './variationSummary';
import { VersionsRep } from './versionsRep';
import { Webhook } from './webhook';
import { WebhookPost } from './webhookPost';
import { Webhooks } from './webhooks';
import { WeightedVariation } from './weightedVariation';
import { WorkflowTemplateMetadata } from './workflowTemplateMetadata';
import { WorkflowTemplateOutput } from './workflowTemplateOutput';
import { WorkflowTemplateParameter } from './workflowTemplateParameter';
import { WorkflowTemplatesListingOutputRep } from './workflowTemplatesListingOutputRep';

/* tslint:disable:no-unused-variable */
let primitives = [
                    "string",
                    "boolean",
                    "double",
                    "integer",
                    "long",
                    "float",
                    "number",
                    "any"
                 ];

let enumsMap: {[index: string]: any} = {
        "AccessAllowedReason.EffectEnum": AccessAllowedReason.EffectEnum,
        "AccessDeniedReason.EffectEnum": AccessDeniedReason.EffectEnum,
        "AccessTokenPost.RoleEnum": AccessTokenPost.RoleEnum,
        "AiConfigsAccessAllowedReason.EffectEnum": AiConfigsAccessAllowedReason.EffectEnum,
        "AiConfigsAccessDeniedReason.EffectEnum": AiConfigsAccessDeniedReason.EffectEnum,
        "ApplicationRep.KindEnum": ApplicationRep.KindEnum,
        "ApprovalRequestResponse.ReviewStatusEnum": ApprovalRequestResponse.ReviewStatusEnum,
        "ApprovalRequestResponse.StatusEnum": ApprovalRequestResponse.StatusEnum,
        "BigSegmentStoreIntegration.IntegrationKeyEnum": BigSegmentStoreIntegration.IntegrationKeyEnum,
        "CreateCopyFlagConfigApprovalRequestRequest.IncludedActionsEnum": CreateCopyFlagConfigApprovalRequestRequest.IncludedActionsEnum,
        "CreateCopyFlagConfigApprovalRequestRequest.ExcludedActionsEnum": CreateCopyFlagConfigApprovalRequestRequest.ExcludedActionsEnum,
        "DependentMetricGroupRep.KindEnum": DependentMetricGroupRep.KindEnum,
        "DependentMetricGroupRepWithMetrics.KindEnum": DependentMetricGroupRepWithMetrics.KindEnum,
        "DependentMetricOrMetricGroupRep.KindEnum": DependentMetricOrMetricGroupRep.KindEnum,
        "Destination.KindEnum": Destination.KindEnum,
        "DestinationPost.KindEnum": DestinationPost.KindEnum,
        "Distribution.KindEnum": Distribution.KindEnum,
        "ExpandableApprovalRequestResponse.ReviewStatusEnum": ExpandableApprovalRequestResponse.ReviewStatusEnum,
        "ExpandableApprovalRequestResponse.StatusEnum": ExpandableApprovalRequestResponse.StatusEnum,
        "ExpandedFlagRep.KindEnum": ExpandedFlagRep.KindEnum,
        "FeatureFlag.KindEnum": FeatureFlag.KindEnum,
        "FeatureFlagBody.PurposeEnum": FeatureFlagBody.PurposeEnum,
        "FeatureFlagStatus.NameEnum": FeatureFlagStatus.NameEnum,
        "FlagConfigApprovalRequestResponse.ReviewStatusEnum": FlagConfigApprovalRequestResponse.ReviewStatusEnum,
        "FlagConfigApprovalRequestResponse.StatusEnum": FlagConfigApprovalRequestResponse.StatusEnum,
        "FlagCopyConfigPost.IncludedActionsEnum": FlagCopyConfigPost.IncludedActionsEnum,
        "FlagCopyConfigPost.ExcludedActionsEnum": FlagCopyConfigPost.ExcludedActionsEnum,
        "FlagEventImpactRep.SizeEnum": FlagEventImpactRep.SizeEnum,
        "FlagImportIntegration.IntegrationKeyEnum": FlagImportIntegration.IntegrationKeyEnum,
        "FlagImportStatus.StatusEnum": FlagImportStatus.StatusEnum,
        "FlagStatusRep.NameEnum": FlagStatusRep.NameEnum,
        "HoldoutDetailRep.StatusEnum": HoldoutDetailRep.StatusEnum,
        "HoldoutRep.StatusEnum": HoldoutRep.StatusEnum,
        "InstructionUserRequest.KindEnum": InstructionUserRequest.KindEnum,
        "MetricGroupPost.KindEnum": MetricGroupPost.KindEnum,
        "MetricGroupRep.KindEnum": MetricGroupRep.KindEnum,
        "MetricInGroupRep.KindEnum": MetricInGroupRep.KindEnum,
        "MetricInGroupRep.UnitAggregationTypeEnum": MetricInGroupRep.UnitAggregationTypeEnum,
        "MetricListingRep.KindEnum": MetricListingRep.KindEnum,
        "MetricListingRep.SuccessCriteriaEnum": MetricListingRep.SuccessCriteriaEnum,
        "MetricListingRep.UnitAggregationTypeEnum": MetricListingRep.UnitAggregationTypeEnum,
        "MetricListingRep.AnalysisTypeEnum": MetricListingRep.AnalysisTypeEnum,
        "MetricPost.KindEnum": MetricPost.KindEnum,
        "MetricPost.SuccessCriteriaEnum": MetricPost.SuccessCriteriaEnum,
        "MetricPost.UnitAggregationTypeEnum": MetricPost.UnitAggregationTypeEnum,
        "MetricRep.KindEnum": MetricRep.KindEnum,
        "MetricRep.SuccessCriteriaEnum": MetricRep.SuccessCriteriaEnum,
        "MetricRep.UnitAggregationTypeEnum": MetricRep.UnitAggregationTypeEnum,
        "MetricRep.AnalysisTypeEnum": MetricRep.AnalysisTypeEnum,
        "MetricV2Rep.KindEnum": MetricV2Rep.KindEnum,
        "MetricV2Rep.UnitAggregationTypeEnum": MetricV2Rep.UnitAggregationTypeEnum,
        "NamingConvention.CaseEnum": NamingConvention.CaseEnum,
        "NewMemberForm.RoleEnum": NewMemberForm.RoleEnum,
        "PatchSegmentExpiringTargetInstruction.KindEnum": PatchSegmentExpiringTargetInstruction.KindEnum,
        "PatchSegmentExpiringTargetInstruction.TargetTypeEnum": PatchSegmentExpiringTargetInstruction.TargetTypeEnum,
        "PatchSegmentInstruction.KindEnum": PatchSegmentInstruction.KindEnum,
        "PatchSegmentInstruction.TargetTypeEnum": PatchSegmentInstruction.TargetTypeEnum,
        "PermissionGrantInput.ActionSetEnum": PermissionGrantInput.ActionSetEnum,
        "PostApprovalRequestReviewRequest.KindEnum": PostApprovalRequestReviewRequest.KindEnum,
        "PostDeploymentEventInput.ApplicationKindEnum": PostDeploymentEventInput.ApplicationKindEnum,
        "PostDeploymentEventInput.EventTypeEnum": PostDeploymentEventInput.EventTypeEnum,
        "RandomizationUnitInput.StandardRandomizationUnitEnum": RandomizationUnitInput.StandardRandomizationUnitEnum,
        "RepositoryPost.TypeEnum": RepositoryPost.TypeEnum,
        "RepositoryRep.TypeEnum": RepositoryRep.TypeEnum,
        "ReviewResponse.KindEnum": ReviewResponse.KindEnum,
        "RuleClause.OpEnum": RuleClause.OpEnum,
        "Statement.EffectEnum": Statement.EffectEnum,
        "StatementPost.EffectEnum": StatementPost.EffectEnum,
        "StatisticRep.TypeEnum": StatisticRep.TypeEnum,
        "TreatmentResultRep.ModelEnum": TreatmentResultRep.ModelEnum,
        "UrlPost.KindEnum": UrlPost.KindEnum,
}

let typeMap: {[index: string]: any} = {
    "AIConfig": AIConfig,
    "AIConfigPatch": AIConfigPatch,
    "AIConfigPost": AIConfigPost,
    "AIConfigVariation": AIConfigVariation,
    "AIConfigVariationPatch": AIConfigVariationPatch,
    "AIConfigVariationPost": AIConfigVariationPost,
    "AIConfigVariationsResponse": AIConfigVariationsResponse,
    "AIConfigs": AIConfigs,
    "Access": Access,
    "AccessAllowedReason": AccessAllowedReason,
    "AccessAllowedRep": AccessAllowedRep,
    "AccessDenied": AccessDenied,
    "AccessDeniedReason": AccessDeniedReason,
    "AccessTokenPost": AccessTokenPost,
    "ActionInput": ActionInput,
    "ActionOutput": ActionOutput,
    "AiConfigsAccess": AiConfigsAccess,
    "AiConfigsAccessAllowedReason": AiConfigsAccessAllowedReason,
    "AiConfigsAccessAllowedRep": AiConfigsAccessAllowedRep,
    "AiConfigsAccessDenied": AiConfigsAccessDenied,
    "AiConfigsAccessDeniedReason": AiConfigsAccessDeniedReason,
    "AiConfigsLink": AiConfigsLink,
    "ApplicationCollectionRep": ApplicationCollectionRep,
    "ApplicationFlagCollectionRep": ApplicationFlagCollectionRep,
    "ApplicationRep": ApplicationRep,
    "ApplicationVersionRep": ApplicationVersionRep,
    "ApplicationVersionsCollectionRep": ApplicationVersionsCollectionRep,
    "ApprovalRequestResponse": ApprovalRequestResponse,
    "ApprovalSettings": ApprovalSettings,
    "ApprovalsCapabilityConfig": ApprovalsCapabilityConfig,
    "AssignedToRep": AssignedToRep,
    "Audience": Audience,
    "AudienceConfiguration": AudienceConfiguration,
    "AudiencePost": AudiencePost,
    "AuditLogEntryListingRep": AuditLogEntryListingRep,
    "AuditLogEntryListingRepCollection": AuditLogEntryListingRepCollection,
    "AuditLogEntryRep": AuditLogEntryRep,
    "AuditLogEventsHookCapabilityConfigPost": AuditLogEventsHookCapabilityConfigPost,
    "AuditLogEventsHookCapabilityConfigRep": AuditLogEventsHookCapabilityConfigRep,
    "AuthorizedAppDataRep": AuthorizedAppDataRep,
    "BayesianBetaBinomialStatsRep": BayesianBetaBinomialStatsRep,
    "BayesianNormalStatsRep": BayesianNormalStatsRep,
    "BigSegmentStoreIntegration": BigSegmentStoreIntegration,
    "BigSegmentStoreIntegrationCollection": BigSegmentStoreIntegrationCollection,
    "BigSegmentStoreIntegrationCollectionLinks": BigSegmentStoreIntegrationCollectionLinks,
    "BigSegmentStoreIntegrationLinks": BigSegmentStoreIntegrationLinks,
    "BigSegmentStoreStatus": BigSegmentStoreStatus,
    "BigSegmentTarget": BigSegmentTarget,
    "BooleanDefaults": BooleanDefaults,
    "BooleanFlagDefaults": BooleanFlagDefaults,
    "BranchCollectionRep": BranchCollectionRep,
    "BranchRep": BranchRep,
    "BulkEditMembersRep": BulkEditMembersRep,
    "BulkEditTeamsRep": BulkEditTeamsRep,
    "CallerIdentityRep": CallerIdentityRep,
    "CapabilityConfigPost": CapabilityConfigPost,
    "CapabilityConfigRep": CapabilityConfigRep,
    "Clause": Clause,
    "Client": Client,
    "ClientCollection": ClientCollection,
    "ClientSideAvailability": ClientSideAvailability,
    "ClientSideAvailabilityPost": ClientSideAvailabilityPost,
    "CompletedBy": CompletedBy,
    "ConditionInput": ConditionInput,
    "ConditionOutput": ConditionOutput,
    "Conflict": Conflict,
    "ConflictOutput": ConflictOutput,
    "ContextAttributeName": ContextAttributeName,
    "ContextAttributeNames": ContextAttributeNames,
    "ContextAttributeNamesCollection": ContextAttributeNamesCollection,
    "ContextAttributeValue": ContextAttributeValue,
    "ContextAttributeValues": ContextAttributeValues,
    "ContextAttributeValuesCollection": ContextAttributeValuesCollection,
    "ContextInstanceEvaluation": ContextInstanceEvaluation,
    "ContextInstanceEvaluationReason": ContextInstanceEvaluationReason,
    "ContextInstanceEvaluations": ContextInstanceEvaluations,
    "ContextInstanceRecord": ContextInstanceRecord,
    "ContextInstanceSearch": ContextInstanceSearch,
    "ContextInstanceSegmentMembership": ContextInstanceSegmentMembership,
    "ContextInstanceSegmentMemberships": ContextInstanceSegmentMemberships,
    "ContextInstances": ContextInstances,
    "ContextKindRep": ContextKindRep,
    "ContextKindsCollectionRep": ContextKindsCollectionRep,
    "ContextRecord": ContextRecord,
    "ContextSearch": ContextSearch,
    "Contexts": Contexts,
    "CopiedFromEnv": CopiedFromEnv,
    "CoreLink": CoreLink,
    "CreateApprovalRequestRequest": CreateApprovalRequestRequest,
    "CreateCopyFlagConfigApprovalRequestRequest": CreateCopyFlagConfigApprovalRequestRequest,
    "CreateFlagConfigApprovalRequestRequest": CreateFlagConfigApprovalRequestRequest,
    "CreatePhaseInput": CreatePhaseInput,
    "CreateReleaseInput": CreateReleaseInput,
    "CreateReleasePipelineInput": CreateReleasePipelineInput,
    "CreateWorkflowTemplateInput": CreateWorkflowTemplateInput,
    "CredibleIntervalRep": CredibleIntervalRep,
    "CustomProperty": CustomProperty,
    "CustomRole": CustomRole,
    "CustomRolePost": CustomRolePost,
    "CustomRoles": CustomRoles,
    "CustomWorkflowInput": CustomWorkflowInput,
    "CustomWorkflowMeta": CustomWorkflowMeta,
    "CustomWorkflowOutput": CustomWorkflowOutput,
    "CustomWorkflowStageMeta": CustomWorkflowStageMeta,
    "CustomWorkflowsListingOutput": CustomWorkflowsListingOutput,
    "DefaultClientSideAvailability": DefaultClientSideAvailability,
    "DefaultClientSideAvailabilityPost": DefaultClientSideAvailabilityPost,
    "Defaults": Defaults,
    "DependentExperimentRep": DependentExperimentRep,
    "DependentFlag": DependentFlag,
    "DependentFlagEnvironment": DependentFlagEnvironment,
    "DependentFlagsByEnvironment": DependentFlagsByEnvironment,
    "DependentMetricGroupRep": DependentMetricGroupRep,
    "DependentMetricGroupRepWithMetrics": DependentMetricGroupRepWithMetrics,
    "DependentMetricOrMetricGroupRep": DependentMetricOrMetricGroupRep,
    "DeploymentCollectionRep": DeploymentCollectionRep,
    "DeploymentRep": DeploymentRep,
    "Destination": Destination,
    "DestinationPost": DestinationPost,
    "Destinations": Destinations,
    "Distribution": Distribution,
    "DynamicOptions": DynamicOptions,
    "DynamicOptionsParser": DynamicOptionsParser,
    "Endpoint": Endpoint,
    "Environment": Environment,
    "EnvironmentPost": EnvironmentPost,
    "EnvironmentSummary": EnvironmentSummary,
    "Environments": Environments,
    "EvaluationReason": EvaluationReason,
    "EvaluationsSummary": EvaluationsSummary,
    "ExecutionOutput": ExecutionOutput,
    "ExpandableApprovalRequestResponse": ExpandableApprovalRequestResponse,
    "ExpandableApprovalRequestsResponse": ExpandableApprovalRequestsResponse,
    "ExpandedFlagRep": ExpandedFlagRep,
    "ExpandedResourceRep": ExpandedResourceRep,
    "Experiment": Experiment,
    "ExperimentAllocationRep": ExperimentAllocationRep,
    "ExperimentBayesianResultsRep": ExperimentBayesianResultsRep,
    "ExperimentCollectionRep": ExperimentCollectionRep,
    "ExperimentEnabledPeriodRep": ExperimentEnabledPeriodRep,
    "ExperimentEnvironmentSettingRep": ExperimentEnvironmentSettingRep,
    "ExperimentInfoRep": ExperimentInfoRep,
    "ExperimentPatchInput": ExperimentPatchInput,
    "ExperimentPost": ExperimentPost,
    "ExpiringTarget": ExpiringTarget,
    "ExpiringTargetError": ExpiringTargetError,
    "ExpiringTargetGetResponse": ExpiringTargetGetResponse,
    "ExpiringTargetPatchResponse": ExpiringTargetPatchResponse,
    "ExpiringUserTargetGetResponse": ExpiringUserTargetGetResponse,
    "ExpiringUserTargetItem": ExpiringUserTargetItem,
    "ExpiringUserTargetPatchResponse": ExpiringUserTargetPatchResponse,
    "Export": Export,
    "Extinction": Extinction,
    "ExtinctionCollectionRep": ExtinctionCollectionRep,
    "FailureReasonRep": FailureReasonRep,
    "FeatureFlag": FeatureFlag,
    "FeatureFlagBody": FeatureFlagBody,
    "FeatureFlagConfig": FeatureFlagConfig,
    "FeatureFlagScheduledChange": FeatureFlagScheduledChange,
    "FeatureFlagScheduledChanges": FeatureFlagScheduledChanges,
    "FeatureFlagStatus": FeatureFlagStatus,
    "FeatureFlagStatusAcrossEnvironments": FeatureFlagStatusAcrossEnvironments,
    "FeatureFlagStatuses": FeatureFlagStatuses,
    "FeatureFlags": FeatureFlags,
    "FileRep": FileRep,
    "FlagConfigApprovalRequestResponse": FlagConfigApprovalRequestResponse,
    "FlagConfigApprovalRequestsResponse": FlagConfigApprovalRequestsResponse,
    "FlagConfigEvaluation": FlagConfigEvaluation,
    "FlagConfigMigrationSettingsRep": FlagConfigMigrationSettingsRep,
    "FlagCopyConfigEnvironment": FlagCopyConfigEnvironment,
    "FlagCopyConfigPost": FlagCopyConfigPost,
    "FlagDefaultsRep": FlagDefaultsRep,
    "FlagEventCollectionRep": FlagEventCollectionRep,
    "FlagEventExperiment": FlagEventExperiment,
    "FlagEventExperimentCollection": FlagEventExperimentCollection,
    "FlagEventExperimentIteration": FlagEventExperimentIteration,
    "FlagEventImpactRep": FlagEventImpactRep,
    "FlagEventMemberRep": FlagEventMemberRep,
    "FlagEventRep": FlagEventRep,
    "FlagFollowersByProjEnvGetRep": FlagFollowersByProjEnvGetRep,
    "FlagFollowersGetRep": FlagFollowersGetRep,
    "FlagImportConfigurationPost": FlagImportConfigurationPost,
    "FlagImportIntegration": FlagImportIntegration,
    "FlagImportIntegrationCollection": FlagImportIntegrationCollection,
    "FlagImportIntegrationCollectionLinks": FlagImportIntegrationCollectionLinks,
    "FlagImportIntegrationLinks": FlagImportIntegrationLinks,
    "FlagImportStatus": FlagImportStatus,
    "FlagInput": FlagInput,
    "FlagLinkCollectionRep": FlagLinkCollectionRep,
    "FlagLinkMember": FlagLinkMember,
    "FlagLinkPost": FlagLinkPost,
    "FlagLinkRep": FlagLinkRep,
    "FlagListingRep": FlagListingRep,
    "FlagMigrationSettingsRep": FlagMigrationSettingsRep,
    "FlagPrerequisitePost": FlagPrerequisitePost,
    "FlagReferenceCollectionRep": FlagReferenceCollectionRep,
    "FlagReferenceRep": FlagReferenceRep,
    "FlagRep": FlagRep,
    "FlagScheduledChangesInput": FlagScheduledChangesInput,
    "FlagSempatch": FlagSempatch,
    "FlagStatusRep": FlagStatusRep,
    "FlagSummary": FlagSummary,
    "FlagTriggerInput": FlagTriggerInput,
    "FollowFlagMember": FollowFlagMember,
    "FollowersPerFlag": FollowersPerFlag,
    "ForbiddenErrorRep": ForbiddenErrorRep,
    "FormVariable": FormVariable,
    "HMACSignature": HMACSignature,
    "HeaderItems": HeaderItems,
    "HoldoutDetailRep": HoldoutDetailRep,
    "HoldoutPatchInput": HoldoutPatchInput,
    "HoldoutPostRequest": HoldoutPostRequest,
    "HoldoutRep": HoldoutRep,
    "HoldoutsCollectionRep": HoldoutsCollectionRep,
    "HunkRep": HunkRep,
    "Import": Import,
    "InitiatorRep": InitiatorRep,
    "InsightGroup": InsightGroup,
    "InsightGroupCollection": InsightGroupCollection,
    "InsightGroupCollectionMetadata": InsightGroupCollectionMetadata,
    "InsightGroupCollectionScoreMetadata": InsightGroupCollectionScoreMetadata,
    "InsightGroupScores": InsightGroupScores,
    "InsightGroupsCountByIndicator": InsightGroupsCountByIndicator,
    "InsightPeriod": InsightPeriod,
    "InsightScores": InsightScores,
    "InsightsChart": InsightsChart,
    "InsightsChartBounds": InsightsChartBounds,
    "InsightsChartMetadata": InsightsChartMetadata,
    "InsightsChartMetric": InsightsChartMetric,
    "InsightsChartSeries": InsightsChartSeries,
    "InsightsChartSeriesDataPoint": InsightsChartSeriesDataPoint,
    "InsightsChartSeriesMetadata": InsightsChartSeriesMetadata,
    "InsightsChartSeriesMetadataAxis": InsightsChartSeriesMetadataAxis,
    "InsightsMetricIndicatorRange": InsightsMetricIndicatorRange,
    "InsightsMetricScore": InsightsMetricScore,
    "InsightsMetricTierDefinition": InsightsMetricTierDefinition,
    "InsightsRepository": InsightsRepository,
    "InsightsRepositoryCollection": InsightsRepositoryCollection,
    "InsightsRepositoryProject": InsightsRepositoryProject,
    "InsightsRepositoryProjectCollection": InsightsRepositoryProjectCollection,
    "InsightsRepositoryProjectMappings": InsightsRepositoryProjectMappings,
    "InstructionUserRequest": InstructionUserRequest,
    "Integration": Integration,
    "IntegrationConfigurationCollectionRep": IntegrationConfigurationCollectionRep,
    "IntegrationConfigurationPost": IntegrationConfigurationPost,
    "IntegrationConfigurationsRep": IntegrationConfigurationsRep,
    "IntegrationDeliveryConfiguration": IntegrationDeliveryConfiguration,
    "IntegrationDeliveryConfigurationCollection": IntegrationDeliveryConfigurationCollection,
    "IntegrationDeliveryConfigurationCollectionLinks": IntegrationDeliveryConfigurationCollectionLinks,
    "IntegrationDeliveryConfigurationLinks": IntegrationDeliveryConfigurationLinks,
    "IntegrationDeliveryConfigurationPost": IntegrationDeliveryConfigurationPost,
    "IntegrationDeliveryConfigurationResponse": IntegrationDeliveryConfigurationResponse,
    "IntegrationMetadata": IntegrationMetadata,
    "IntegrationStatus": IntegrationStatus,
    "IntegrationStatusRep": IntegrationStatusRep,
    "IntegrationSubscriptionStatusRep": IntegrationSubscriptionStatusRep,
    "Integrations": Integrations,
    "InvalidRequestErrorRep": InvalidRequestErrorRep,
    "IpList": IpList,
    "IterationInput": IterationInput,
    "IterationRep": IterationRep,
    "LastSeenMetadata": LastSeenMetadata,
    "LayerCollectionRep": LayerCollectionRep,
    "LayerConfigurationRep": LayerConfigurationRep,
    "LayerPatchInput": LayerPatchInput,
    "LayerPost": LayerPost,
    "LayerRep": LayerRep,
    "LayerReservationRep": LayerReservationRep,
    "LayerSnapshotRep": LayerSnapshotRep,
    "LeadTimeStagesRep": LeadTimeStagesRep,
    "LegacyExperimentRep": LegacyExperimentRep,
    "Link": Link,
    "MaintainerRep": MaintainerRep,
    "MaintainerTeam": MaintainerTeam,
    "Member": Member,
    "MemberDataRep": MemberDataRep,
    "MemberImportItem": MemberImportItem,
    "MemberPermissionGrantSummaryRep": MemberPermissionGrantSummaryRep,
    "MemberSummary": MemberSummary,
    "MemberTeamSummaryRep": MemberTeamSummaryRep,
    "MemberTeamsPostInput": MemberTeamsPostInput,
    "Members": Members,
    "MembersPatchInput": MembersPatchInput,
    "Message": Message,
    "MethodNotAllowedErrorRep": MethodNotAllowedErrorRep,
    "MetricByVariation": MetricByVariation,
    "MetricCollectionRep": MetricCollectionRep,
    "MetricEventDefaultRep": MetricEventDefaultRep,
    "MetricGroupCollectionRep": MetricGroupCollectionRep,
    "MetricGroupPost": MetricGroupPost,
    "MetricGroupRep": MetricGroupRep,
    "MetricGroupResultsRep": MetricGroupResultsRep,
    "MetricInGroupRep": MetricInGroupRep,
    "MetricInGroupResultsRep": MetricInGroupResultsRep,
    "MetricInMetricGroupInput": MetricInMetricGroupInput,
    "MetricInput": MetricInput,
    "MetricListingRep": MetricListingRep,
    "MetricPost": MetricPost,
    "MetricRep": MetricRep,
    "MetricSeen": MetricSeen,
    "MetricV2Rep": MetricV2Rep,
    "Metrics": Metrics,
    "MigrationSafetyIssueRep": MigrationSafetyIssueRep,
    "MigrationSettingsPost": MigrationSettingsPost,
    "ModelConfig": ModelConfig,
    "ModelConfigPost": ModelConfigPost,
    "ModelError": ModelError,
    "Modification": Modification,
    "MultiEnvironmentDependentFlag": MultiEnvironmentDependentFlag,
    "MultiEnvironmentDependentFlags": MultiEnvironmentDependentFlags,
    "NamingConvention": NamingConvention,
    "NewMemberForm": NewMemberForm,
    "NotFoundErrorRep": NotFoundErrorRep,
    "OauthClientPost": OauthClientPost,
    "OptionsArray": OptionsArray,
    "PaginatedLinks": PaginatedLinks,
    "ParameterDefault": ParameterDefault,
    "ParameterRep": ParameterRep,
    "ParentAndSelfLinks": ParentAndSelfLinks,
    "ParentLink": ParentLink,
    "ParentResourceRep": ParentResourceRep,
    "PatchFailedErrorRep": PatchFailedErrorRep,
    "PatchFlagsRequest": PatchFlagsRequest,
    "PatchOperation": PatchOperation,
    "PatchSegmentExpiringTargetInputRep": PatchSegmentExpiringTargetInputRep,
    "PatchSegmentExpiringTargetInstruction": PatchSegmentExpiringTargetInstruction,
    "PatchSegmentInstruction": PatchSegmentInstruction,
    "PatchSegmentRequest": PatchSegmentRequest,
    "PatchUsersRequest": PatchUsersRequest,
    "PatchWithComment": PatchWithComment,
    "PermissionGrantInput": PermissionGrantInput,
    "Phase": Phase,
    "PhaseInfo": PhaseInfo,
    "PostApprovalRequestApplyRequest": PostApprovalRequestApplyRequest,
    "PostApprovalRequestReviewRequest": PostApprovalRequestReviewRequest,
    "PostDeploymentEventInput": PostDeploymentEventInput,
    "PostFlagScheduledChangesInput": PostFlagScheduledChangesInput,
    "PostInsightGroupParams": PostInsightGroupParams,
    "Prerequisite": Prerequisite,
    "Project": Project,
    "ProjectPost": ProjectPost,
    "ProjectRep": ProjectRep,
    "ProjectSummary": ProjectSummary,
    "ProjectSummaryCollection": ProjectSummaryCollection,
    "Projects": Projects,
    "PullRequestCollectionRep": PullRequestCollectionRep,
    "PullRequestLeadTimeRep": PullRequestLeadTimeRep,
    "PullRequestRep": PullRequestRep,
    "PutBranch": PutBranch,
    "RandomizationSettingsPut": RandomizationSettingsPut,
    "RandomizationSettingsRep": RandomizationSettingsRep,
    "RandomizationUnitInput": RandomizationUnitInput,
    "RandomizationUnitRep": RandomizationUnitRep,
    "RateLimitedErrorRep": RateLimitedErrorRep,
    "RecentTriggerBody": RecentTriggerBody,
    "ReferenceRep": ReferenceRep,
    "RelatedExperimentRep": RelatedExperimentRep,
    "RelativeDifferenceRep": RelativeDifferenceRep,
    "RelayAutoConfigCollectionRep": RelayAutoConfigCollectionRep,
    "RelayAutoConfigPost": RelayAutoConfigPost,
    "RelayAutoConfigRep": RelayAutoConfigRep,
    "Release": Release,
    "ReleaseAudience": ReleaseAudience,
    "ReleaseGuardianConfiguration": ReleaseGuardianConfiguration,
    "ReleaseGuardianConfigurationInput": ReleaseGuardianConfigurationInput,
    "ReleasePhase": ReleasePhase,
    "ReleasePipeline": ReleasePipeline,
    "ReleasePipelineCollection": ReleasePipelineCollection,
    "ReleaseProgression": ReleaseProgression,
    "ReleaseProgressionCollection": ReleaseProgressionCollection,
    "ReleaserAudienceConfigInput": ReleaserAudienceConfigInput,
    "RepositoryCollectionRep": RepositoryCollectionRep,
    "RepositoryPost": RepositoryPost,
    "RepositoryRep": RepositoryRep,
    "ResourceAccess": ResourceAccess,
    "ResourceIDResponse": ResourceIDResponse,
    "ResourceId": ResourceId,
    "ReviewOutput": ReviewOutput,
    "ReviewResponse": ReviewResponse,
    "Rollout": Rollout,
    "RootResponse": RootResponse,
    "Rule": Rule,
    "RuleClause": RuleClause,
    "SdkListRep": SdkListRep,
    "SdkVersionListRep": SdkVersionListRep,
    "SdkVersionRep": SdkVersionRep,
    "SegmentBody": SegmentBody,
    "SegmentMetadata": SegmentMetadata,
    "SegmentTarget": SegmentTarget,
    "SegmentUserList": SegmentUserList,
    "SegmentUserState": SegmentUserState,
    "Series": Series,
    "SeriesIntervalsRep": SeriesIntervalsRep,
    "SeriesListRep": SeriesListRep,
    "SimpleHoldoutRep": SimpleHoldoutRep,
    "SlicedResultsRep": SlicedResultsRep,
    "SourceEnv": SourceEnv,
    "SourceFlag": SourceFlag,
    "StageInput": StageInput,
    "StageOutput": StageOutput,
    "Statement": Statement,
    "StatementPost": StatementPost,
    "StatisticCollectionRep": StatisticCollectionRep,
    "StatisticRep": StatisticRep,
    "StatisticsRoot": StatisticsRoot,
    "StatusConflictErrorRep": StatusConflictErrorRep,
    "StatusResponse": StatusResponse,
    "StatusServiceUnavailable": StatusServiceUnavailable,
    "StoreIntegrationError": StoreIntegrationError,
    "SubjectDataRep": SubjectDataRep,
    "SubscriptionPost": SubscriptionPost,
    "TagsCollection": TagsCollection,
    "TagsLink": TagsLink,
    "Target": Target,
    "TargetResourceRep": TargetResourceRep,
    "Team": Team,
    "TeamCustomRole": TeamCustomRole,
    "TeamCustomRoles": TeamCustomRoles,
    "TeamImportsRep": TeamImportsRep,
    "TeamMaintainers": TeamMaintainers,
    "TeamMembers": TeamMembers,
    "TeamPatchInput": TeamPatchInput,
    "TeamPostInput": TeamPostInput,
    "TeamProjects": TeamProjects,
    "Teams": Teams,
    "TeamsPatchInput": TeamsPatchInput,
    "TimestampRep": TimestampRep,
    "Token": Token,
    "TokenSummary": TokenSummary,
    "Tokens": Tokens,
    "TreatmentInput": TreatmentInput,
    "TreatmentParameterInput": TreatmentParameterInput,
    "TreatmentRep": TreatmentRep,
    "TreatmentResultRep": TreatmentResultRep,
    "TriggerPost": TriggerPost,
    "TriggerWorkflowCollectionRep": TriggerWorkflowCollectionRep,
    "TriggerWorkflowRep": TriggerWorkflowRep,
    "UnauthorizedErrorRep": UnauthorizedErrorRep,
    "UpdatePhaseStatusInput": UpdatePhaseStatusInput,
    "UpdateReleasePipelineInput": UpdateReleasePipelineInput,
    "UpsertContextKindPayload": UpsertContextKindPayload,
    "UpsertFlagDefaultsPayload": UpsertFlagDefaultsPayload,
    "UpsertPayloadRep": UpsertPayloadRep,
    "UpsertResponseRep": UpsertResponseRep,
    "UrlPost": UrlPost,
    "User": User,
    "UserAttributeNamesRep": UserAttributeNamesRep,
    "UserFlagSetting": UserFlagSetting,
    "UserFlagSettings": UserFlagSettings,
    "UserRecord": UserRecord,
    "UserSegment": UserSegment,
    "UserSegmentRule": UserSegmentRule,
    "UserSegments": UserSegments,
    "Users": Users,
    "UsersRep": UsersRep,
    "ValidationFailedErrorRep": ValidationFailedErrorRep,
    "ValuePut": ValuePut,
    "Variation": Variation,
    "VariationEvalSummary": VariationEvalSummary,
    "VariationOrRolloutRep": VariationOrRolloutRep,
    "VariationSummary": VariationSummary,
    "VersionsRep": VersionsRep,
    "Webhook": Webhook,
    "WebhookPost": WebhookPost,
    "Webhooks": Webhooks,
    "WeightedVariation": WeightedVariation,
    "WorkflowTemplateMetadata": WorkflowTemplateMetadata,
    "WorkflowTemplateOutput": WorkflowTemplateOutput,
    "WorkflowTemplateParameter": WorkflowTemplateParameter,
    "WorkflowTemplatesListingOutputRep": WorkflowTemplatesListingOutputRep,
}

// Check if a string starts with another string without using es6 features
function startsWith(str: string, match: string): boolean {
    return str.substring(0, match.length) === match;
}

// Check if a string ends with another string without using es6 features
function endsWith(str: string, match: string): boolean {
    return str.length >= match.length && str.substring(str.length - match.length) === match;
}

const nullableSuffix = " | null";
const optionalSuffix = " | undefined";
const arrayPrefix = "Array<";
const arraySuffix = ">";
const mapPrefix = "{ [key: string]: ";
const mapSuffix = "; }";

export class ObjectSerializer {
    public static findCorrectType(data: any, expectedType: string) {
        if (data == undefined) {
            return expectedType;
        } else if (primitives.indexOf(expectedType.toLowerCase()) !== -1) {
            return expectedType;
        } else if (expectedType === "Date") {
            return expectedType;
        } else {
            if (enumsMap[expectedType]) {
                return expectedType;
            }

            if (!typeMap[expectedType]) {
                return expectedType; // w/e we don't know the type
            }

            // Check the discriminator
            let discriminatorProperty = typeMap[expectedType].discriminator;
            if (discriminatorProperty == null) {
                return expectedType; // the type does not have a discriminator. use it.
            } else {
                if (data[discriminatorProperty]) {
                    var discriminatorType = data[discriminatorProperty];
                    if(typeMap[discriminatorType]){
                        return discriminatorType; // use the type given in the discriminator
                    } else {
                        return expectedType; // discriminator did not map to a type
                    }
                } else {
                    return expectedType; // discriminator was not present (or an empty string)
                }
            }
        }
    }

    public static serialize(data: any, type: string): any {
        if (data == undefined) {
            return data;
        } else if (primitives.indexOf(type.toLowerCase()) !== -1) {
            return data;
        } else if (endsWith(type, nullableSuffix)) {
            let subType: string = type.slice(0, -nullableSuffix.length); // Type | null => Type
            return ObjectSerializer.serialize(data, subType);
        } else if (endsWith(type, optionalSuffix)) {
            let subType: string = type.slice(0, -optionalSuffix.length); // Type | undefined => Type
            return ObjectSerializer.serialize(data, subType);
        } else if (startsWith(type, arrayPrefix)) {
            let subType: string = type.slice(arrayPrefix.length, -arraySuffix.length); // Array<Type> => Type
            let transformedData: any[] = [];
            for (let index = 0; index < data.length; index++) {
                let datum = data[index];
                transformedData.push(ObjectSerializer.serialize(datum, subType));
            }
            return transformedData;
        } else if (startsWith(type, mapPrefix)) {
            let subType: string = type.slice(mapPrefix.length, -mapSuffix.length); // { [key: string]: Type; } => Type
            let transformedData: { [key: string]: any } = {};
            for (let key in data) {
                transformedData[key] = ObjectSerializer.serialize(
                    data[key],
                    subType,
                );
            }
            return transformedData;
        } else if (type === "Date") {
            return data.toISOString();
        } else {
            if (enumsMap[type]) {
                return data;
            }
            if (!typeMap[type]) { // in case we dont know the type
                return data;
            }

            // Get the actual type of this object
            type = this.findCorrectType(data, type);

            // get the map for the correct type.
            let attributeTypes = typeMap[type].getAttributeTypeMap();
            let instance: {[index: string]: any} = {};
            for (let index = 0; index < attributeTypes.length; index++) {
                let attributeType = attributeTypes[index];
                instance[attributeType.baseName] = ObjectSerializer.serialize(data[attributeType.name], attributeType.type);
            }
            return instance;
        }
    }

    public static deserialize(data: any, type: string): any {
        // polymorphism may change the actual type.
        type = ObjectSerializer.findCorrectType(data, type);
        if (data == undefined) {
            return data;
        } else if (primitives.indexOf(type.toLowerCase()) !== -1) {
            return data;
        } else if (endsWith(type, nullableSuffix)) {
            let subType: string = type.slice(0, -nullableSuffix.length); // Type | null => Type
            return ObjectSerializer.deserialize(data, subType);
        } else if (endsWith(type, optionalSuffix)) {
            let subType: string = type.slice(0, -optionalSuffix.length); // Type | undefined => Type
            return ObjectSerializer.deserialize(data, subType);
        } else if (startsWith(type, arrayPrefix)) {
            let subType: string = type.slice(arrayPrefix.length, -arraySuffix.length); // Array<Type> => Type
            let transformedData: any[] = [];
            for (let index = 0; index < data.length; index++) {
                let datum = data[index];
                transformedData.push(ObjectSerializer.deserialize(datum, subType));
            }
            return transformedData;
        } else if (startsWith(type, mapPrefix)) {
            let subType: string = type.slice(mapPrefix.length, -mapSuffix.length); // { [key: string]: Type; } => Type
            let transformedData: { [key: string]: any } = {};
            for (let key in data) {
                transformedData[key] = ObjectSerializer.deserialize(
                    data[key],
                    subType,
                );
            }
            return transformedData;
        } else if (type === "Date") {
            return new Date(data);
        } else {
            if (enumsMap[type]) {// is Enum
                return data;
            }

            if (!typeMap[type]) { // dont know the type
                return data;
            }
            let instance = new typeMap[type]();
            let attributeTypes = typeMap[type].getAttributeTypeMap();
            for (let index = 0; index < attributeTypes.length; index++) {
                let attributeType = attributeTypes[index];
                instance[attributeType.name] = ObjectSerializer.deserialize(data[attributeType.baseName], attributeType.type);
            }
            return instance;
        }
    }
}

export interface Authentication {
    /**
    * Apply authentication settings to header and query params.
    */
    applyToRequest(requestOptions: localVarRequest.Options): Promise<void> | void;
}

export class HttpBasicAuth implements Authentication {
    public username: string = '';
    public password: string = '';

    applyToRequest(requestOptions: localVarRequest.Options): void {
        requestOptions.auth = {
            username: this.username, password: this.password
        }
    }
}

export class HttpBearerAuth implements Authentication {
    public accessToken: string | (() => string) = '';

    applyToRequest(requestOptions: localVarRequest.Options): void {
        if (requestOptions && requestOptions.headers) {
            const accessToken = typeof this.accessToken === 'function'
                            ? this.accessToken()
                            : this.accessToken;
            requestOptions.headers["Authorization"] = "Bearer " + accessToken;
        }
    }
}

export class ApiKeyAuth implements Authentication {
    public apiKey: string = '';

    constructor(private location: string, private paramName: string) {
    }

    applyToRequest(requestOptions: localVarRequest.Options): void {
        if (this.location == "query") {
            (<any>requestOptions.qs)[this.paramName] = this.apiKey;
        } else if (this.location == "header" && requestOptions && requestOptions.headers) {
            requestOptions.headers[this.paramName] = this.apiKey;
        } else if (this.location == 'cookie' && requestOptions && requestOptions.headers) {
            if (requestOptions.headers['Cookie']) {
                requestOptions.headers['Cookie'] += '; ' + this.paramName + '=' + encodeURIComponent(this.apiKey);
            }
            else {
                requestOptions.headers['Cookie'] = this.paramName + '=' + encodeURIComponent(this.apiKey);
            }
        }
    }
}

export class OAuth implements Authentication {
    public accessToken: string = '';

    applyToRequest(requestOptions: localVarRequest.Options): void {
        if (requestOptions && requestOptions.headers) {
            requestOptions.headers["Authorization"] = "Bearer " + this.accessToken;
        }
    }
}

export class VoidAuth implements Authentication {
    public username: string = '';
    public password: string = '';

    applyToRequest(_: localVarRequest.Options): void {
        // Do nothing
    }
}

export type Interceptor = (requestOptions: localVarRequest.Options) => (Promise<void> | void);
