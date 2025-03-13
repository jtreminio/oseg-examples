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
class UpdatePhaseStatusExample
{
    fun updatePhaseStatus()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val audiences1ReleaseGuardianConfiguration = ReleaseGuardianConfigurationInput(
            monitoringWindowMilliseconds = 60000,
            rolloutWeight = 50,
            rollbackOnRegression = true,
            randomizationUnit = "user",
        )

        val audiences1 = ReleaserAudienceConfigInput(
            audienceId = null,
            notifyMemberIds = listOf (
                "1234a56b7c89d012345e678f",
            ),
            notifyTeamKeys = listOf (
                "example-reviewer-team",
            ),
            releaseGuardianConfiguration = audiences1ReleaseGuardianConfiguration,
        )

        val audiences = arrayListOf<ReleaserAudienceConfigInput>(
            audiences1,
        )

        val updatePhaseStatusInput = UpdatePhaseStatusInput(
            status = null,
            audiences = audiences,
        )

        try
        {
            val response = ReleasesBetaApi().updatePhaseStatus(
                projectKey = null,
                flagKey = null,
                phaseId = null,
                updatePhaseStatusInput = updatePhaseStatusInput,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ReleasesBetaApi#updatePhaseStatus")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ReleasesBetaApi#updatePhaseStatus")
            e.printStackTrace()
        }
    }
}
