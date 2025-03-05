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
class PostApprovalRequestForFlagExample
{
    fun postApprovalRequestForFlag()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val createFlagConfigApprovalRequestRequest = CreateFlagConfigApprovalRequestRequest(
            description = "Requesting to update targeting",
            instructions = listOf (),
            comment = "optional comment",
            executionDate = 1706701522000,
            operatingOnId = "6297ed79dee7dc14e1f9a80c",
            notifyMemberIds = listOf (
                "1234a56b7c89d012345e678f",
            ),
            notifyTeamKeys = listOf (
                "example-reviewer-team",
            ),
            integrationConfig = null,
        )

        try
        {
            val response = ApprovalsApi().postApprovalRequestForFlag(
                projectKey = null,
                featureFlagKey = null,
                environmentKey = null,
                createFlagConfigApprovalRequestRequest = createFlagConfigApprovalRequestRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ApprovalsApi#postApprovalRequestForFlag")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ApprovalsApi#postApprovalRequestForFlag")
            e.printStackTrace()
        }
    }
}
