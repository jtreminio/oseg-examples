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
class DeleteApprovalRequestForFlagExample
{
    fun deleteApprovalRequestForFlag()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        try
        {
            ApprovalsApi().deleteApprovalRequestForFlag(
                projectKey = "projectKey_string",
                featureFlagKey = "featureFlagKey_string",
                environmentKey = "environmentKey_string",
                id = "id_string",
            )
        } catch (e: ClientException) {
            println("4xx response calling ApprovalsApi#deleteApprovalRequestForFlag")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ApprovalsApi#deleteApprovalRequestForFlag")
            e.printStackTrace()
        }
    }
}
