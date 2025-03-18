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
class PostApprovalRequestApplyForFlagExample
{
    fun postApprovalRequestApplyForFlag()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val postApprovalRequestApplyRequest = PostApprovalRequestApplyRequest(
            comment = "Looks good, thanks for updating",
        )

        try
        {
            val response = ApprovalsApi().postApprovalRequestApplyForFlag(
                projectKey = "projectKey_string",
                featureFlagKey = "featureFlagKey_string",
                environmentKey = "environmentKey_string",
                id = "id_string",
                postApprovalRequestApplyRequest = postApprovalRequestApplyRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ApprovalsApi#postApprovalRequestApplyForFlag")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ApprovalsApi#postApprovalRequestApplyForFlag")
            e.printStackTrace()
        }
    }
}
