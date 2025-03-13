package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PostReleasePipelineExample
{
    fun postReleasePipeline()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val phases1Audiences1ConfigurationReleaseGuardianConfiguration = ReleaseGuardianConfiguration(
            monitoringWindowMilliseconds = 60000,
            rolloutWeight = 50,
            rollbackOnRegression = true,
            randomizationUnit = "user",
        )

        val phases1Audiences1Configuration = AudienceConfiguration(
            releaseStrategy = "the-release-strategy",
            requireApproval = true,
            notifyMemberIds = listOf (
                "1234a56b7c89d012345e678f",
            ),
            notifyTeamKeys = listOf (
                "example-reviewer-team",
            ),
            releaseGuardianConfiguration = phases1Audiences1ConfigurationReleaseGuardianConfiguration,
        )

        val phases1Audiences1 = AudiencePost(
            environmentKey = "the-environment-key",
            name = "Some name",
            segmentKeys = listOf (),
            configuration = phases1Audiences1Configuration,
        )

        val phases1Audiences = arrayListOf<AudiencePost>(
            phases1Audiences1,
        )

        val phases1 = CreatePhaseInput(
            name = "Phase 1 - Testing",
            audiences = phases1Audiences,
        )

        val phases = arrayListOf<CreatePhaseInput>(
            phases1,
        )

        val createReleasePipelineInput = CreateReleasePipelineInput(
            key = "standard-pipeline",
            name = "Standard Pipeline",
            description = "Standard pipeline to roll out to production",
            isProjectDefault = false,
            isLegacy = false,
            tags = listOf (
                "example-tag",
            ),
            phases = phases,
        )

        try
        {
            val response = ReleasePipelinesBetaApi().postReleasePipeline(
                projectKey = "the-project-key",
                createReleasePipelineInput = createReleasePipelineInput,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ReleasePipelinesBetaApi#postReleasePipeline")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ReleasePipelinesBetaApi#postReleasePipeline")
            e.printStackTrace()
        }
    }
}
