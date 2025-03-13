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
class PostFlagCopyConfigApprovalRequestExample
{
    fun postFlagCopyConfigApprovalRequest()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val source = SourceFlag(
            key = "environment-key-123abc",
            version = 1,
        )

        val createCopyFlagConfigApprovalRequestRequest = CreateCopyFlagConfigApprovalRequestRequest(
            description = "copy flag settings to another environment",
            comment = "optional comment",
            notifyMemberIds = listOf (
                "1234a56b7c89d012345e678f",
            ),
            notifyTeamKeys = listOf (
                "example-reviewer-team",
            ),
            includedActions = listOf (
                CreateCopyFlagConfigApprovalRequestRequest.IncludedActions.updateOn,
            ),
            excludedActions = listOf (
                CreateCopyFlagConfigApprovalRequestRequest.ExcludedActions.updateOn,
            ),
            source = source,
        )

        try
        {
            val response = ApprovalsApi().postFlagCopyConfigApprovalRequest(
                projectKey = "projectKey_string",
                featureFlagKey = "featureFlagKey_string",
                environmentKey = "environmentKey_string",
                createCopyFlagConfigApprovalRequestRequest = createCopyFlagConfigApprovalRequestRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ApprovalsApi#postFlagCopyConfigApprovalRequest")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ApprovalsApi#postFlagCopyConfigApprovalRequest")
            e.printStackTrace()
        }
    }
}
