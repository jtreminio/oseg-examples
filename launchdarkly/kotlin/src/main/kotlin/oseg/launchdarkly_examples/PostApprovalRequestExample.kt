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
class PostApprovalRequestExample
{
    fun postApprovalRequest()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val createApprovalRequestRequest = CreateApprovalRequestRequest(
            resourceId = "proj/projKey:env/envKey:flag/flagKey",
            description = "Requesting to update targeting",
            instructions = listOf (),
            comment = "optional comment",
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
            val response = ApprovalsApi().postApprovalRequest(
                createApprovalRequestRequest = createApprovalRequestRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ApprovalsApi#postApprovalRequest")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ApprovalsApi#postApprovalRequest")
            e.printStackTrace()
        }
    }
}
